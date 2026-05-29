using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.BLL.Services;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame
{
    public partial class frmComputerMap : MaterialForm
    {
        private ComputerService _computerService;
        private QuanLyCuaHangGame.BLL.Services.SessionService _sessionService;
        private Computer _selectedComputer;

        public frmComputerMap()
        {
            InitializeComponent();

            _computerService = new ComputerService();
            _sessionService = new QuanLyCuaHangGame.BLL.Services.SessionService();

            // Bật DoubleBuffered cho FlowLayoutPanel và Form để chống lag/giật hình khi vẽ lại các ô máy
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, flpComputers, new object[] { true });
            this.DoubleBuffered = true;

            // Áp dụng theme chuẩn của nhóm
            UIHelper.UICommon.ApplyTheme(this);

            // Thiết lập lại màu sắc cho phần chú thích trạng thái để tránh bị theme ghi đè
            lblLegendIdle.ForeColor = Color.FromArgb(46, 125, 50);
            lblLegendBusy.ForeColor = Color.FromArgb(21, 101, 192);
            lblLegendBroken.ForeColor = Color.FromArgb(198, 40, 40);

            // Đăng ký sự kiện ForeColorChanged để khóa màu sắc, chống bị theme ghi đè khi form mất/nhận focus
            lblLegendIdle.ForeColorChanged += (s, e) => {
                if (lblLegendIdle.ForeColor != Color.FromArgb(46, 125, 50))
                    lblLegendIdle.ForeColor = Color.FromArgb(46, 125, 50);
            };
            lblLegendBusy.ForeColorChanged += (s, e) => {
                if (lblLegendBusy.ForeColor != Color.FromArgb(21, 101, 192))
                    lblLegendBusy.ForeColor = Color.FromArgb(21, 101, 192);
            };
            lblLegendBroken.ForeColorChanged += (s, e) => {
                if (lblLegendBroken.ForeColor != Color.FromArgb(198, 40, 40))
                    lblLegendBroken.ForeColor = Color.FromArgb(198, 40, 40);
            };

            ResetDetailPanel();
            WireUpEvents();
        }

        private void frmComputerMap_Load(object sender, EventArgs e)
        {
            // Áp dụng style hiện đại lúc Form Load để WinForms tự động tính toán DPI và căn lề đúng cách
            UIHelper.DashboardUIHelper.ApplyGlobalModernStyle(this);

            // Tải danh sách phòng máy vào ComboBox
            LoadRooms();
            // Vẽ sơ đồ phòng máy
            LoadComputerMap();

            // Khởi động Timer 15s để tự động cập nhật sơ đồ phòng máy
            tmrRefresh.Start();
        }

        private void LoadRooms()
        {
            try
            {
                cboRooms.Items.Clear();
                cboRooms.Items.Add("Tất cả phòng");

                var rooms = _computerService.GetAllRooms();
                foreach (var r in rooms)
                {
                    cboRooms.Items.Add(r.Name);
                }

                cboRooms.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Lỗi khi tải danh sách phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComputerMap()
        {
            try
            {
                flpComputers.SuspendLayout(); // Dừng vẽ giao diện tạm thời để chống lag/giật
                flpComputers.Controls.Clear();

                var listComputers = _computerService.GetAllComputers().OrderBy(c => c.Code).ToList();
                string selectedRoom = cboRooms.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedRoom) && selectedRoom != "Tất cả phòng")
                {
                    listComputers = listComputers.Where(c => c.Room != null && c.Room.Name == selectedRoom).ToList();
                }

                foreach (var comp in listComputers)
                {
                    ComputerButton btn = new ComputerButton();
                    btn.Size = new Size(110, 75);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Tag = comp;

                    // Định nghĩa nhãn text
                    string displayStatus = comp.Status;
                    
                    // Lọc màu sắc và thông tin hiển thị
                    if (comp.Condition == "Hỏng" || comp.Status == "Dừng")
                    {
                        btn.SetCustomColors(Color.FromArgb(254, 242, 242), Color.FromArgb(220, 38, 38));
                        displayStatus = "Hỏng";
                    }
                    else if (comp.Status == "Đang dùng")
                    {
                        btn.SetCustomColors(Color.FromArgb(239, 246, 255), Color.FromArgb(37, 99, 235));
                    }
                    else // Trống
                    {
                        btn.SetCustomColors(Color.FromArgb(240, 253, 244), Color.FromArgb(22, 163, 74));
                    }

                    btn.Text = $"{comp.Code}\n{displayStatus}";
                    btn.Click += ComputerButton_Click;

                    flpComputers.Controls.Add(btn);
                }

                // Tự động chọn máy đang chọn trước đó, hoặc máy đầu tiên trong danh sách để làm đầy giao diện lúc load
                if (flpComputers.Controls.Count > 0)
                {
                    ComputerButton selectBtn = null;
                    if (_selectedComputer != null)
                    {
                        selectBtn = flpComputers.Controls.Cast<ComputerButton>()
                            .FirstOrDefault(b => ((Computer)b.Tag).Id == _selectedComputer.Id);
                    }
                    
                    if (selectBtn == null)
                    {
                        selectBtn = (ComputerButton)flpComputers.Controls[0];
                    }

                    ComputerButton_Click(selectBtn, EventArgs.Empty);
                }
                else
                {
                    ResetDetailPanel();
                }
            }
            catch (Exception ex)
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Lỗi khi tải sơ đồ máy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flpComputers.ResumeLayout(); // Cho phép vẽ lại toàn bộ một lượt khi hoàn tất chèn nút
            }
        }

        private void ComputerButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _selectedComputer = (Computer)btn.Tag;

            UpdateDetailPanel();
        }

        private void UpdateDetailPanel()
        {
            if (_selectedComputer == null)
            {
                ResetDetailPanel();
                return;
            }

            lblDetailsTitle.Text = $"Chi tiết máy đang chọn — {_selectedComputer.Code} ({_selectedComputer.Status})";
            lblHardwareInfo.Text = $"Cấu hình: {_selectedComputer.Cpu} / {_selectedComputer.Gpu} / {_selectedComputer.Ram}";
            lblTierInfo.Text = $"Hạng máy: {_selectedComputer.Tier}";
            lblPriceInfo.Text = $"Giá giờ: {_computerService.GetCurrentPrice(_selectedComputer.Id):N0}đ/h";

            if (_selectedComputer.Condition == "Hỏng" || _selectedComputer.Status == "Dừng")
            {
                lblDetailsTitle.Text = $"Chi tiết máy đang chọn — {_selectedComputer.Code} (Hỏng)";
                lblCustomerInfo.Text = "Hội viên: -";
                lblTimeInfo.Text = "Thời gian: -";
                lblServiceInfo.Text = "Dịch vụ: -";

                btnOpenSession.Enabled = false;
                btnOrderService.Enabled = false;
                btnPayment.Enabled = false;
            }
            else if (_selectedComputer.Status == "Trống")
            {
                lblDetailsTitle.Text = $"Chi tiết máy đang chọn — {_selectedComputer.Code} (Trống)";
                lblCustomerInfo.Text = "Hội viên: Không có";
                lblTimeInfo.Text = "Thời gian: -";
                lblServiceInfo.Text = "Dịch vụ: -";

                btnOpenSession.Enabled = true;
                btnOrderService.Enabled = false;
                btnPayment.Enabled = false;
            }
            else if (_selectedComputer.Status == "Đang dùng")
            {
                lblDetailsTitle.Text = $"Chi tiết máy đang chọn — {_selectedComputer.Code} (Đang dùng)";
                btnOpenSession.Enabled = false;
                btnOrderService.Enabled = true;
                btnPayment.Enabled = true;

                var activeSession = _sessionService.GetActiveSessions()
                    .FirstOrDefault(s => s.ComputerId == _selectedComputer.Id);

                if (activeSession != null)
                {
                    lblCustomerInfo.Text = activeSession.Customer != null 
                        ? $"Hội viên: {activeSession.Customer.FullName} ({activeSession.Customer.Username})" 
                        : $"Khách vãng lai: {activeSession.GuestName}";
                    
                    double totalHours = (DateTime.Now - activeSession.StartTime).TotalHours;
                    lblTimeInfo.Text = $"Bắt đầu lúc: {activeSession.StartTime:HH:mm} — Đã chơi: {totalHours:N1} giờ";

                    var services = _sessionService.GetServicesForSession(activeSession.Id).ToList();
                    if (services.Any())
                    {
                        decimal serviceSum = services.Sum(s => s.Quantity * s.UnitPrice);
                        lblServiceInfo.Text = $"Dịch vụ: {serviceSum:N0}đ ({services.Count} món)";
                    }
                    else
                    {
                        lblServiceInfo.Text = "Dịch vụ: 0đ";
                    }
                }
                else
                {
                    lblCustomerInfo.Text = "Khách hàng: Đang tải...";
                    lblTimeInfo.Text = "Thời gian: Đang tính...";
                    lblServiceInfo.Text = "Dịch vụ: -";
                }
            }
        }

        private void ResetDetailPanel()
        {
            lblDetailsTitle.Text = "Vui lòng chọn một máy trên sơ đồ";
            lblCustomerInfo.Text = "Hội viên: -";
            lblTimeInfo.Text = "Thời gian: -";
            lblPriceInfo.Text = "Giá giờ: -";
            lblHardwareInfo.Text = "Cấu hình: -";
            lblTierInfo.Text = "Hạng máy: -";
            lblServiceInfo.Text = "Dịch vụ: -";

            btnOpenSession.Enabled = false;
            btnOrderService.Enabled = false;
            btnPayment.Enabled = false;
        }

        private void WireUpEvents()
        {
            btnRefresh.Click += (s, e) => LoadComputerMap();
            cboRooms.SelectedIndexChanged += (s, e) => LoadComputerMap();
            tmrRefresh.Tick += (s, e) => LoadComputerMap();

            btnOpenSession.Click += BtnOpenSession_Click;
            btnPayment.Click += BtnPayment_Click;
            btnOrderService.Click += BtnOrderService_Click;
            btnHistory.Click += BtnHistory_Click;
        }

        private void BtnOpenSession_Click(object sender, EventArgs e)
        {
            if (_selectedComputer == null || _selectedComputer.Status != "Trống") return;

            // Khởi tạo và hiển thị Dialog Mở máy cho khách
            using (var dlg = new dlgOpenSession(_selectedComputer.Id))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadComputerMap();
                    ResetDetailPanel();
                }
            }
        }

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            if (_selectedComputer == null || _selectedComputer.Status != "Đang dùng") return;

            var activeSession = _sessionService.GetActiveSessions()
                .FirstOrDefault(s => s.ComputerId == _selectedComputer.Id);

            if (activeSession == null)
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Không tìm thấy phiên hoạt động của máy đang chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tích hợp form thanh toán thực tế
            using (var dlg = new frmPayment(activeSession.Id, BLL.SessionContext.CurrentUserId))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadComputerMap();
                    ResetDetailPanel();
                }
            }
        }

        private void BtnOrderService_Click(object sender, EventArgs e)
        {
            if (_selectedComputer == null || _selectedComputer.Status != "Đang dùng") return;

            var activeSession = _sessionService.GetActiveSessions()
                .FirstOrDefault(s => s.ComputerId == _selectedComputer.Id);

            if (activeSession == null)
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Không tìm thấy phiên hoạt động của máy đang chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dlg = new QuanLyCuaHangGame.GUI.dlgAddService(activeSession.Id))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    UpdateDetailPanel();
                    LoadComputerMap();
                }
            }
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            MaterialSkin.Controls.MaterialMessageBox.Show("Tính năng xem lịch sử phiên máy đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class ComputerButton : Button
    {
        private Color _customBackColor = Color.Empty;
        private Color _customForeColor = Color.Empty;

        public void SetCustomColors(Color backColor, Color foreColor)
        {
            _customBackColor = backColor;
            _customForeColor = foreColor;
            base.BackColor = backColor;
            base.ForeColor = foreColor;
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                if (_customBackColor != Color.Empty)
                    base.BackColor = _customBackColor;
                else
                    base.BackColor = value;
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                if (_customForeColor != Color.Empty)
                    base.ForeColor = _customForeColor;
                else
                    base.ForeColor = value;
            }
        }
    }
}
