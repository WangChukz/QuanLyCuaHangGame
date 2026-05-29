using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangGame.BLL;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame
{
    public partial class frmPayment : MaterialForm
    {
        private readonly PaymentBLL _paymentBLL = new PaymentBLL();

        private int _sessionId;
        private int _closedByUserId;

        // Dữ liệu được tải từ DB
        private Session _session;
        private List<SessionService> _services;

        // Các giá trị tính toán
        private DateTime _endTime;
        private decimal _hoursUsed;
        private decimal _sessionAmount;
        private decimal _serviceAmount;
        private decimal _totalAmount;

        /// <summary>
        /// Constructor mặc định – dùng khi embed frmPayment vào tab Dashboard.
        /// Form sẽ hiển thị trống, cần gọi LoadSession(sessionId, userId) sau.
        /// </summary>
        public frmPayment()
        {
            InitializeComponent();
            UIHelper.UICommon.ApplyTheme(this, true);

            _sessionId = 0;
            _closedByUserId = 0;
        }

        /// <summary>
        /// Constructor có tham số – dùng khi mở popup thanh toán trực tiếp.
        /// </summary>
        public frmPayment(int sessionId, int closedByUserId)
        {
            InitializeComponent();
            UIHelper.UICommon.ApplyTheme(this, true);

            _sessionId = sessionId;
            _closedByUserId = closedByUserId;
        }

        /// <summary>
        /// Gọi phương thức này từ bên ngoài để nạp phiên thanh toán khi dùng constructor mặc định.
        /// </summary>
        public void LoadSession(int sessionId, int closedByUserId)
        {
            _sessionId = sessionId;
            _closedByUserId = closedByUserId;
            LoadPaymentDetails();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            // Embedded mode (sessionId = 0): chờ LoadSession() được gọi từ bên ngoài
            // khi người dùng chọn một phiên để thanh toán từ tab Dashboard hoặc Sơ đồ.
            if (_sessionId <= 0) return;
            LoadPaymentDetails();
        }

        /// <summary>
        /// Tải dữ liệu phiên từ DB và tính toán sơ bộ các khoản tiền.
        /// </summary>
        private void LoadPaymentDetails()
        {
            try
            {
                var details = _paymentBLL.GetPaymentDetails(_sessionId);
                if (details == null)
                {
                    MaterialSkin.Controls.MaterialMessageBox.Show("Không tìm thấy phiên chơi!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                _session  = details.Item1;
                _services = details.Item2;

                // Tính EndTime = bây giờ, sau đó tính các khoản
                _endTime       = DateTime.Now;
                _hoursUsed     = _paymentBLL.CalculateHoursUsed(_session.StartTime, _endTime);
                _sessionAmount = _paymentBLL.CalculateSessionAmount(_hoursUsed, _session.PricePerHour);
                _serviceAmount = _paymentBLL.CalculateServiceAmount(_services);
                _totalAmount   = _sessionAmount + _serviceAmount;

                // Tiêu đề form
                string tenKhach = _session.Customer?.FullName ?? _session.GuestName ?? "Khách vãng lai";
                this.Text = $"Thanh toán – {_session.Computer?.Code} · {tenKhach}";

                // --- Panel Thông tin phiên ---
                string tierText  = _session.Computer != null
                    ? $"{_session.Computer.Code} – {_session.Computer.Tier} ({_session.PricePerHour:N0}đ/h)"
                    : "(Không rõ)";
                lblMayValue.Text      = tierText;
                lblBatDauValue.Text   = _session.StartTime.ToString("HH:mm:ss");
                lblKetThucValue.Text  = $"{_endTime:HH:mm:ss} (ngay bây giờ)";

                int totalMinutes = (int)Math.Ceiling((_endTime - _session.StartTime).TotalMinutes);
                int h = totalMinutes / 60;
                int m = totalMinutes % 60;
                lblThoiGianValue.Text = h > 0
                    ? $"{h} giờ {m} phút"
                    : $"{m} phút";

                // --- Panel Hội viên ---
                if (_session.Customer != null)
                {
                    lblTenValue.Text   = _session.Customer.FullName;
                    lblSDTValue.Text   = _session.Customer.Phone;
                    lblSoDuValue.Text  = $"Số dư hiện tại: {_session.Customer.Balance:N0}đ";
                }
                else
                {
                    lblTenValue.Text   = _session.GuestName ?? "Khách vãng lai";
                    lblSDTValue.Text   = "—";
                    lblSoDuValue.Text  = "Khách vãng lai (không có ví)";
                    txtViHoiVien.ReadOnly = true;
                }

                // --- Bảng chi tiết hóa đơn ---
                lvHoaDon.Items.Clear();

                // Dòng tiền giờ chơi
                string moTaGio = h > 0
                    ? $"Tiền giờ chơi ({h}g {m}p × {_session.PricePerHour:N0}đ/h)"
                    : $"Tiền giờ chơi ({m}p × {_session.PricePerHour:N0}đ/h)";
                lvHoaDon.Items.Add(new ListViewItem(new[]
                {
                    moTaGio,
                    $"{_sessionAmount:N0}đ"
                }));

                // Các dòng dịch vụ
                foreach (var svc in _services)
                {
                    string tenDV = svc.ServiceItem?.Name ?? $"Dịch vụ #{svc.ServiceItemId}";
                    lvHoaDon.Items.Add(new ListViewItem(new[]
                    {
                        $"{tenDV} × {svc.Quantity}",
                        $"{svc.Quantity * svc.UnitPrice:N0}đ"
                    }));
                }

                // Tính và hiển thị
                RefreshTotals();
            }
            catch (Exception ex)
            {
                MaterialSkin.Controls.MaterialMessageBox.Show($"Lỗi khi tải dữ liệu thanh toán:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật lại tổng tiền và trạng thái thanh toán mỗi khi tiền mặt thay đổi.
        /// </summary>
        private void RefreshTotals()
        {
            if (_session == null) return;

            lblTongTienValue.Text = $"{_totalAmount:N0}đ";

            decimal balance = _session.Customer?.Balance ?? 0m;

            // Phân bổ tiền theo nghiệp vụ
            var split = _paymentBLL.CalculatePaymentSplit(_totalAmount, _session.Customer?.Balance);
            decimal truVi  = split.Item1;
            decimal conLai = split.Item2;

            txtViHoiVien.Text = truVi.ToString("N0");

            decimal soduSau = balance - truVi;
            lblSoDuSauValue.Text = $"Số dư sau TT: {soduSau:N0}đ";

            // Đọc tiền mặt bổ sung
            decimal.TryParse(txtTienMat.Text?.Replace(",", ""), out decimal tienMatExtra);

            decimal tongDaTra = truVi + tienMatExtra;
            decimal chenh     = tongDaTra - _totalAmount;

            if (chenh >= 0)
            {
                cardStatus.BackColor  = Color.FromArgb(236, 253, 245);
                lblStatus.ForeColor   = Color.FromArgb(22, 163, 74);
                lblStatus.Text        = $"✔ Đủ số dư thanh toán\n" +
                                        $"Số dư {balance:N0}đ ≥ Tổng {_totalAmount:N0}đ\n" +
                                        $"Số dư còn lại: {soduSau:N0}đ" +
                                        (chenh > 0 ? $"\nTiền thừa: {chenh:N0}đ" : "");
            }
            else
            {
                cardStatus.BackColor  = Color.FromArgb(254, 242, 242);
                lblStatus.ForeColor   = Color.FromArgb(220, 38, 38);
                lblStatus.Text        = $"❌ Thiếu số dư\n" +
                                        $"Cần thanh toán thêm tiền mặt.\n" +
                                        $"Còn thiếu: {Math.Abs(chenh):N0}đ";
            }
        }

        private void txtTienMat_TextChanged(object sender, EventArgs e)
        {
            RefreshTotals();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (_session == null) return;

            // Kiểm tra đủ tiền chưa
            decimal.TryParse(txtTienMat.Text?.Replace(",", ""), out decimal tienMatExtra);
            var split = _paymentBLL.CalculatePaymentSplit(_totalAmount, _session.Customer?.Balance);
            decimal tongDaTra = split.Item1 + tienMatExtra;

            if (tongDaTra < _totalAmount)
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Số tiền thanh toán chưa đủ!\nVui lòng nhập thêm tiền mặt.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hỏi xác nhận
            string tenKhach = _session.Customer?.FullName ?? _session.GuestName ?? "Khách vãng lai";
            var dr = MaterialSkin.Controls.MaterialMessageBox.Show(
                $"Xác nhận thanh toán:\n\n" +
                $"Khách: {tenKhach}\n" +
                $"Tổng: {_totalAmount:N0}đ\n" +
                $"Trừ ví: {split.Item1:N0}đ\n" +
                $"Tiền mặt: {tienMatExtra:N0}đ",
                "Xác nhận thanh toán",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dr != DialogResult.OK) return;

            try
            {
                btnXacNhan.Enabled = false;
                var invoice = _paymentBLL.ProcessPayment(
                    _sessionId,
                    _closedByUserId,
                    _session,
                    _services,
                    tienMatExtra);

                MaterialSkin.Controls.MaterialMessageBox.Show(
                    $"✓ Thanh toán thành công!\nHóa đơn #{invoice.Id} đã được tạo.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                btnXacNhan.Enabled = true;
                MaterialSkin.Controls.MaterialMessageBox.Show($"Lỗi khi xử lý thanh toán:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MaterialSkin.Controls.MaterialMessageBox.Show("Đang in hóa đơn…\n(Tích hợp PDF/máy in tại đây)",
                "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MaterialSkin.Controls.MaterialMessageBox.Show("Bạn có chắc muốn hủy thanh toán?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
