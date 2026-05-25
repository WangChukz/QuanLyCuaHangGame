using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangGame
{
    public partial class frmPayment : MaterialForm
    {
        // ──────────────── DỮ LIỆU GIẢ LẬP ────────────────
        private string _maMay      = "PC05";
        private string _tenMay     = "PC05 – VIP (30,000đ/h)";
        private string _thoiGian   = "1 giờ 45 phút";
        private string _tenKhach   = "Phạm Quốc Huy";
        private string _sdtKhach   = "0912 345 678";
        private decimal _tienGio   = 52500m;
        private decimal _tienPepsi = 20000m;
        private decimal _tienSnack = 15000m;
        private decimal _soDuHoiVien = 150000m;

        public frmPayment()
        {
            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.Blue200, TextShade.WHITE);

            LoadData();
        }

        private void LoadData()
        {
            // Thông tin phiên
            lblMayValue.Text = _tenMay;
            lblBatDauValue.Text = "14:30:00";
            lblKetThucValue.Text = "16:15:00 (ngay bây giờ)";
            lblThoiGianValue.Text = _thoiGian;

            // Hội viên
            lblTenValue.Text = _tenKhach;
            lblSDTValue.Text = _sdtKhach;
            lblSoDuValue.Text = $"Số dư hiện tại: {_soDuHoiVien:N0}đ";

            // Bảng hóa đơn
            lvHoaDon.Items.Clear();
            lvHoaDon.Items.Add(new ListViewItem(new string[] { "Tiền giờ chơi (1g 45p x 30,000đ/h)", $"{_tienGio:N0}đ" }));
            lvHoaDon.Items.Add(new ListViewItem(new string[] { "Nước ngọt Pepsi x 2", $"{_tienPepsi:N0}đ" }));
            lvHoaDon.Items.Add(new ListViewItem(new string[] { "Snack Oishi x 1", $"{_tienSnack:N0}đ" }));

            RefreshTotals();
        }

        private void RefreshTotals()
        {
            decimal tong = _tienGio + _tienPepsi + _tienSnack;
            lblTongTienValue.Text = $"{tong:N0}đ";

            // Trừ từ ví hội viên (ví chỉ trừ tối đa tới mức tổng hóa đơn nếu đủ tiền, hoặc hết sạch ví nếu không đủ)
            decimal tienTuVi = Math.Min(_soDuHoiVien, tong);
            txtViHoiVien.Text = tienTuVi.ToString("N0");
            lblSoDuSauValue.Text = $"Số dư sau TT: {(_soDuHoiVien - tienTuVi):N0}đ";

            decimal tienMat = 0;
            if (decimal.TryParse(txtTienMat.Text, out decimal parsedTienMat))
            {
                tienMat = parsedTienMat;
            }

            decimal conLai = tong - tienTuVi - tienMat;
            
            if (conLai <= 0)
            {
                cardStatus.BackColor = Color.FromArgb(236, 253, 245); // Light Green
                lblStatus.ForeColor = Color.FromArgb(22, 163, 74); // Green
                lblStatus.Text = $"✔ Đủ số dư thanh toán\n" +
                                 $"Số dư {_soDuHoiVien:N0}đ + Tiền mặt {tienMat:N0}đ >= Tổng {tong:N0}đ\n" +
                                 $"Tiền thừa: {Math.Abs(conLai):N0}đ";
            }
            else
            {
                cardStatus.BackColor = Color.FromArgb(254, 242, 242); // Light Red
                lblStatus.ForeColor = Color.FromArgb(220, 38, 38); // Red
                lblStatus.Text = $"❌ Thiếu số dư thanh toán\n" +
                                 $"Cần thanh toán thêm bằng tiền mặt.\n" +
                                 $"Thiếu: {conLai:N0}đ";
            }
        }

        private void txtTienMat_TextChanged(object sender, EventArgs e)
        {
            RefreshTotals();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            decimal tong = _tienGio + _tienPepsi + _tienSnack;
            decimal tienTuVi = Math.Min(_soDuHoiVien, tong);
            decimal tienMat = 0;
            decimal.TryParse(txtTienMat.Text, out tienMat);

            if (tienTuVi + tienMat < tong)
            {
                MessageBox.Show("Số tiền thanh toán chưa đủ!\nVui lòng nhập thêm tiền mặt.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Xác nhận thanh toán {tong:N0}đ\nTừ ví: {tienTuVi:N0}đ\nTiền mặt: {tienMat:N0}đ",
                "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                MessageBox.Show("✓ Thanh toán thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang in hóa đơn…\n(Tích hợp PDF/máy in tại đây)",
                "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy thanh toán?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
