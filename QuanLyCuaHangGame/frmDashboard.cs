using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyCuaHangGame.UIHelper;
using QuanLyCuaHangGame.BLL;

namespace QuanLyCuaHangGame
{
    public partial class frmDashboard : MaterialForm
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)] bool bShow);

        private const int SB_VERT = 1;
        private const int SB_HORZ = 0;

        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.DataGridView dgvPhien;
        private System.Windows.Forms.Panel pnlChartFilter;

        // ── Snapshot KPI — làm mới cứ 30 giây ──
        private int     _activeMachineCount = 0;
        private int     _totalMachineCount  = 0;
        private int     _memberCount        = 0;
        private int     _brokenCount        = 0;
        private decimal _revenueToday       = 0;

        public frmDashboard()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            UICommon.ApplyTheme(this);

            // Ẩn thanh Tab mặc định của Windows để dùng Drawer (Sidebar) làm menu chính
            mainTabControl.Appearance = TabAppearance.FlatButtons;
            mainTabControl.ItemSize = new Size(0, 1);
            mainTabControl.SizeMode = TabSizeMode.Fixed;

            this.Load += FrmDashboard_Load;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            InitializeModernDashboardUI();
            
            // Ẩn thanh cuộn dọc mặc định của Windows nhưng vẫn cho phép cuộn bằng con lăn chuột (SaaS style)
            flpSoDo.Paint += (s, ev) => {
                ShowScrollBar(flpSoDo.Handle, SB_VERT, false);
                ShowScrollBar(flpSoDo.Handle, SB_HORZ, false);
            };

            LoadSoDoPhongMay();
            LoadChart();
            LoadDataGridView();
            
            // Đặt toàn bộ nền của Form và tất cả các TabPage thành màu Trắng tinh tế
            this.BackColor = Color.White;
            foreach (TabPage tab in mainTabControl.TabPages)
            {
                tab.BackColor = Color.White;
            }
            
            // ── Helper ẩn header MaterialSkin trùng lặp khi nhúng form con vào TabPage ──
            // MaterialSkin vẽ thanh tiêu đề cao 64px ngay cả khi TopLevel=false.
            // Giải pháp: đặt Location.Y = -64 để đẩy header ra ngoài vùng clip của TabPage.
            void EmbedChildForm(Form childForm, TabPage targetTab)
            {
                if (childForm is MaterialForm matForm)
                {
                    matForm.FormStyle = MaterialForm.FormStyles.StatusAndActionBar_None;
                    matForm.Padding = new Padding(3);
                }
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.BackColor = Color.White;
                childForm.Dock = DockStyle.Fill;
                targetTab.Controls.Add(childForm);
                childForm.Show();
            }

            // Nhúng các Form con vào từng Tab tương ứng — header trùng đã được ẩn
            EmbedChildForm(new frmComputerMap(),  tabPageSoDo);       // Tab 1 – Sơ đồ phòng máy
            EmbedChildForm(new frmComputer(),     tabPageMayTinh);    // Tab 3 – Quản lý máy tính
            EmbedChildForm(new frmCustomer(),     tabPageHoiVien);    // Tab 4 – Hội viên
            EmbedChildForm(new GUI.frmService(),  tabPageDichVu);     // Tab 5 – Dịch vụ
            EmbedChildForm(new frmPayment(),      tabPageThanhToan);  // Tab 6 – Thanh toán
            EmbedChildForm(new GUI.frmUser(),     tabPageTaiKhoan);   // Tab 8 – Tài khoản (Admin)

            // Phân quyền: Ẩn tab Tài khoản nếu không phải Admin
            if (!SessionContext.IsAdmin)
            {
                mainTabControl.TabPages.Remove(tabPageTaiKhoan);
            }

            // Embed frmReport into tabPageBaoCao
            frmReport frmRep = new frmReport();
            frmRep.TopLevel = false;
            frmRep.FormBorderStyle = FormBorderStyle.None;
            frmRep.Dock = DockStyle.Fill;
            tabPageBaoCao.Controls.Add(frmRep);
            frmRep.Show();

            // Di chuyển pnlFooter từ tabPageDashboard ra ngoài Form chính để hiển thị trên tất cả các tab
            tabPageDashboard.Controls.Remove(pnlFooter);
            this.Controls.Add(pnlFooter);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.SendToBack(); // Quan trọng: Đưa xuống dưới cùng Z-order để nó giành không gian trước, tránh bị mainTabControl (Fill) che khuất hoặc đè lên.
            mainTabControl.BringToFront(); // Đưa mainTabControl lên trên để nó lấp đầy phần không gian còn lại.

            // Bind SelectedIndexChanged to update Title and Footer
            mainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
            MainTabControl_SelectedIndexChanged(this, EventArgs.Empty);
            
            // Ép buộc áp dụng style chuẩn SaaS sau khi MaterialSkin load xong
            ApplyKPICardStyles();
            DashboardUIHelper.ApplyGlobalModernStyle(this);
            LoadKPIData(); // Tải số liệu KPI thực từ DB
            
            mainTabControl.SelectedIndex = 0; // Đặt mặc định mở tab Dashboard đầu tiên khi khởi động

            // Add Coming Soon labels to empty tabs
            Label lblComingSoon1 = new Label();
            lblComingSoon1.Text = "Tính năng Đang được phát triển...";
            lblComingSoon1.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblComingSoon1.ForeColor = Color.Gray;
            lblComingSoon1.AutoSize = true;
            lblComingSoon1.Location = new Point(50, 50);
            tabPageThueMay.Controls.Add(lblComingSoon1);

            Label lblComingSoon2 = new Label();
            lblComingSoon2.Text = "Tính năng Đang được phát triển...";
            lblComingSoon2.Font = new Font("Inter", 16F, FontStyle.Bold);
            lblComingSoon2.ForeColor = Color.Gray;
            lblComingSoon2.AutoSize = true;
            lblComingSoon2.Location = new Point(50, 50);
            tabPageBaoCao.Controls.Add(lblComingSoon2);

            // Khởi tạo Timer tự làm mới (Interval = 30000ms, Enabled = true)
            tmrRefresh = new System.Windows.Forms.Timer();
            tmrRefresh.Interval = 30000;
            tmrRefresh.Tick += TmrRefresh_Tick;
            tmrRefresh.Enabled = true;
            tmrRefresh.Start();
        }

        private void ApplyKPICardStyles()
        {
            DashboardUIHelper.ApplyKPICardStyles(
                lblDoanhThuValue, lblDoanhThuSub,
                lblMayValue, lblMaySub,
                lblHoiVienValue, lblHoiVienSub,
                lblXuLyValue, lblXuLySub);

            // Áp dụng màu nền footer và style nhãn thông tin
            DashboardUIHelper.StyleFooter(pnlFooter, lblFooter);
        }

        /// <summary>Tải số liệu KPI thực từ DB và cập nhật 4 thẻ KPI + footer.</summary>
        private void LoadKPIData()
        {
            try
            {
                var compSvc   = new BLL.Services.ComputerService();
                var custSvc   = new BLL.Services.CustomerService();
                var sessSvc   = new BLL.Services.SessionService();
                var reportSvc = new BLL.Services.ReportService();

                // ① Doanh thu hôm nay (Invoice đã thanh toán)
                _revenueToday = reportSvc.GetTotalRevenue(DateTime.Today, DateTime.Now);
                lblDoanhThuValue.Text = _revenueToday.ToString("N0") + "đ";
                lblDoanhThuSub.Text   = "Hôm nay – " + DateTime.Today.ToString("dd/MM/yyyy");

                // ② Máy đang chạy / tổng số máy
                var allComputers    = compSvc.GetAllComputers().ToList();
                _totalMachineCount  = allComputers.Count;
                _activeMachineCount = sessSvc.GetActiveSessions().Count();
                lblMayValue.Text = $"{_activeMachineCount}/{_totalMachineCount}";
                lblMaySub.Text   = "máy đang hoạt động";

                // ③ Tổng hội viên
                _memberCount = custSvc.GetAllCustomers().Count();
                lblHoiVienValue.Text = _memberCount.ToString();
                lblHoiVienSub.Text   = "hội viên đã đăng ký";

                // ④ Máy cần xử lý (Hỏng hoặc Dừng)
                _brokenCount = allComputers.Count(c => c.Condition == "Hỏng" || c.Status == "Dừng");
                lblXuLyValue.Text = _brokenCount.ToString();
                lblXuLySub.Text   = _brokenCount > 0
                    ? $"{_brokenCount} máy cần sửa chữa"
                    : "Tất cả máy hoạt động tốt";

                // ⑤ Đồng bộ footer
                UpdateFooter();
            }
            catch
            {
                // Giữ nguyên giá trị hiện tại nếu DB lỗi
            }
        }

        /// <summary>Cập nhật thanh footer theo tab đang hiển thị và snapshot KPI.</summary>
        private void UpdateFooter()
        {
            if (lblFooter == null) return;
            string userName = BLL.SessionContext.CurrentUserName ?? "Admin";
            if (mainTabControl.SelectedIndex == 3) // Tab Quản lý máy tính
            {
                lblFooter.Text = $"Tổng: {_totalMachineCount} máy    |    Hỏng: {_brokenCount}    |    Chế độ: {(BLL.SessionContext.IsAdmin ? "Admin – toàn quyền" : "Nhân viên")}";
            }
            else
            {
                lblFooter.Text = $"Nhân viên: {userName}    |    Hôm nay: {DateTime.Today:dd/MM/yyyy}    |    Máy đang chạy: {_activeMachineCount}/{_totalMachineCount}    |    Doanh thu hôm nay: {_revenueToday:N0}đ";
            }
        }

        private void InitializeModernDashboardUI()
        {
            // 1. Tạo DataGridView
            dgvPhien = new DataGridView();
            cardPhien.Controls.Remove(lvPhien);
            cardPhien.Controls.Add(dgvPhien);
            
            dgvPhien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhien.Location = new Point(17, 45);
            dgvPhien.Size = new Size(1020, 150);
            
            dgvPhien.Columns.Add("colMay", "Máy");
            dgvPhien.Columns.Add("colHoiVien", "Hội viên / Khách");
            dgvPhien.Columns.Add("colLoai", "Loại");
            dgvPhien.Columns["colLoai"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhien.Columns.Add("colGioBatDau", "Giờ bắt đầu");
            dgvPhien.Columns.Add("colThoiGian", "Thời gian");
            dgvPhien.Columns.Add("colTienGio", "Tiền giờ");
            dgvPhien.Columns.Add("colDichVu", "Dịch vụ");
            
            // Cột Thao tác dạng Text "ĐÓNG" màu xanh như hình
            DataGridViewTextBoxColumn colThaoTac = new DataGridViewTextBoxColumn();
            colThaoTac.Name = "colThaoTac";
            colThaoTac.HeaderText = "Thao tác";
            colThaoTac.DefaultCellStyle.ForeColor = DashboardUIHelper.ThemeColor;
            colThaoTac.DefaultCellStyle.SelectionForeColor = DashboardUIHelper.ThemeColor;
            colThaoTac.DefaultCellStyle.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            dgvPhien.Columns.Add(colThaoTac);

            // Vẽ Custom Badge cho cột "Loại" (Hội viên/Vãng lai) bo góc tuyệt đẹp
            dgvPhien.CellPainting += (s, e) => {
                if (e.RowIndex >= 0 && dgvPhien.Columns[e.ColumnIndex].Name == "colLoai")
                {
                    e.PaintBackground(e.CellBounds, true);
                    
                    string val = e.Value?.ToString() ?? "";
                    Color bgBadg = Color.FromArgb(219, 234, 254); // Light blue
                    Color textBadg = Color.FromArgb(29, 78, 216); // Dark blue
                    
                    if (val == "Vãng lai")
                    {
                        bgBadg = Color.FromArgb(254, 237, 222); // Light orange
                        textBadg = Color.FromArgb(194, 65, 12); // Orange
                    }
                    
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    int padX = 14;
                    int padY = 4;
                    Size size = TextRenderer.MeasureText(val, new Font("Inter", 9F, FontStyle.Bold));
                    int badgeW = size.Width + padX * 2;
                    int badgeH = size.Height + padY * 2;
                    
                    Rectangle badgeRect = new Rectangle(
                        e.CellBounds.X + (e.CellBounds.Width - badgeW) / 2,
                        e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2,
                        badgeW,
                        badgeH
                    );
                    
                    using (var path = UICommon.GetRoundedRectPath(badgeRect, 10))
                    {
                        using (var brush = new SolidBrush(bgBadg))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                    }
                    
                    TextRenderer.DrawText(e.Graphics, val, new Font("Inter", 9F, FontStyle.Bold), badgeRect, textBadg, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    
                    e.Handled = true;
                }
            };

            DashboardUIHelper.StyleModernDataGridView(dgvPhien);

            // Thêm sự kiện click để Đóng phiên chơi (Thanh toán) trực tiếp từ DataGridView
            dgvPhien.CellContentClick += (s, e) => {
                if (e.RowIndex >= 0 && dgvPhien.Columns[e.ColumnIndex].Name == "colThaoTac")
                {
                    try
                    {
                        string compCode = dgvPhien.Rows[e.RowIndex].Cells["colMay"].Value?.ToString();
                        if (string.IsNullOrEmpty(compCode)) return;

                        var sessionService = new BLL.Services.SessionService();
                        var activeSession = sessionService.GetActiveSessions()
                            .FirstOrDefault(sess => sess.Computer?.Code == compCode);

                        if (activeSession != null)
                        {
                            using (var dlg = new frmPayment(activeSession.Id, BLL.SessionContext.CurrentUserId))
                            {
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    LoadSoDoPhongMay();
                                    LoadDataGridView();
                                    ApplyKPICardStyles();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MaterialSkin.Controls.MaterialMessageBox.Show("Lỗi khi xử lý thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            // Ẩn thanh cuộn mặc định của DataGridView nhưng vẫn cho phép cuộn bằng con lăn chuột (SaaS style)
            dgvPhien.ScrollBars = ScrollBars.None;
            dgvPhien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhien.MouseWheel += (s, ev) => {
                if (dgvPhien.Rows.Count == 0) return;
                try
                {
                    int newIndex = dgvPhien.FirstDisplayedScrollingRowIndex;
                    if (ev.Delta > 0)
                    {
                        newIndex = Math.Max(0, newIndex - 1);
                    }
                    else if (ev.Delta < 0)
                    {
                        newIndex = Math.Min(dgvPhien.Rows.Count - 1, newIndex + 1);
                    }
                    dgvPhien.FirstDisplayedScrollingRowIndex = newIndex;
                }
                catch { }
            };
        }


        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedIndex)
            {
                case 0:
                    this.Text = "Dashboard – Tổng quan hệ thống";
                    break;
                case 1:
                    this.Text = "Sơ đồ phòng máy";
                    break;
                case 2:
                    this.Text = "Thuê máy";
                    break;
                case 3:
                    this.Text = "Quản lý máy tính — Chế độ: Admin";
                    break;
                case 4:
                    this.Text = "Quản lý hội viên";
                    break;
                case 5:
                    this.Text = "Quản lý dịch vụ";
                    break;
                case 6:
                    this.Text = "Thanh toán";
                    break;
                case 7:
                    this.Text = "Báo cáo";
                    break;
                case 8:
                    this.Text = "Quản lý tài khoản";
                    break;
                default:
                    this.Text = "GameStore Management";
                    break;
            }

            // Cập nhật footer theo tab hiện tại với số liệu thực
            UpdateFooter();
        }

        private void LoadSoDoPhongMay()
        {
            flpSoDo.Controls.Clear();
            try
            {
                var computerService = new BLL.Services.ComputerService();
                var listComputers = computerService.GetAllComputers().OrderBy(c => c.Code).ToList();
                
                foreach (var comp in listComputers)
                {
                    Button btn = new Button();
                    btn.Size = new Size(88, 55);
                    
                    string displayStatus = comp.Status;
                    if (comp.Condition == "Hỏng" || comp.Status == "Dừng")
                    {
                        displayStatus = "Hỏng";
                    }
                    else if (comp.Status == "Đang dùng")
                    {
                        var sessionService = new BLL.Services.SessionService();
                        var activeSession = sessionService.GetActiveSessions()
                            .FirstOrDefault(s => s.ComputerId == comp.Id);
                        if (activeSession != null)
                        {
                            double totalMinutes = (DateTime.Now - activeSession.StartTime).TotalMinutes;
                            int h = (int)totalMinutes / 60;
                            int m = (int)totalMinutes % 60;
                            displayStatus = $"{h}g {m}p";
                        }
                    }
                    
                    btn.Text = $"{comp.Code}\n{displayStatus}";
                    DashboardUIHelper.FormatRoomMapButton(btn, displayStatus);
                    flpSoDo.Controls.Add(btn);
                }
            }
            catch
            {
                // Fallback to static data if DB fails
                string[] pcs = { "PC01", "PC02", "PC03", "PC04", "PC05", "PC06", "PC07", "PC08", "PC09", "PC10", 
                                 "PC11", "PC12", "PC13", "PC14", "PC15", "PC16", "PC17", "PC18", "PC19", "PC20" };
                string[] statuses = { "Trống", "Trống", "1g 23p", "Trống", "0g 43p", "Trống", "Hỏng", "Trống", "2g 08p", "Trống", 
                                      "Trống", "1g 05p", "Trống", "Trống", "Trống", "0g 32p", "Trống", "Trống", "Hỏng", "Trống" };

                for (int i = 0; i < Math.Min(pcs.Length, 20); i++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(88, 55);
                    btn.Text = pcs[i] + "\n" + statuses[i];
                    DashboardUIHelper.FormatRoomMapButton(btn, statuses[i]);
                    flpSoDo.Controls.Add(btn);
                }
            }
        }

        private void InitializeChartFilter()
        {
            if (pnlChartFilter != null) return;

            pnlChartFilter = new Panel();
            pnlChartFilter.Size = new Size(260, 32);
            pnlChartFilter.BackColor = Color.FromArgb(243, 244, 246); // Light grey background #F3F4F6
            pnlChartFilter.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, pnlChartFilter.Width, pnlChartFilter.Height), 16));

            string[] tabs = { "Ngày", "Tuần", "Tháng", "Năm" };
            int btnW = 60;
            for (int i = 0; i < tabs.Length; i++)
            {
                Button btn = new Button();
                btn.Text = tabs[i];
                btn.Size = new Size(btnW, 26);
                btn.Location = new Point(3 + i * 64, 3);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Inter", 9F, FontStyle.Bold);
                
                if (i == 0) // "Ngày" active
                {
                    btn.BackColor = DashboardUIHelper.ThemeColor;
                    btn.ForeColor = Color.White;
                    btn.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, btn.Width, btn.Height), 13));
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(156, 163, 175); // Màu xám trung tính nhạt #9CA3AF
                }

                pnlChartFilter.Controls.Add(btn);
            }

            cardChart.Controls.Add(pnlChartFilter);
        }

        private void LoadChart()
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisY.Clear();
            
            // Cấu hình Tooltip chỉ hiển thị duy nhất 1 dòng của series đang được hover
            chartDoanhThu.DataTooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.OnlySender
            };

            // Nhãn custom màu tím đậm sang trọng đồng bộ với màu chủ đạo
            lblChartTitle.Visible = false;
            Color mainThemeColor = DashboardUIHelper.ThemeColor;
            var wpfThemeColor = System.Windows.Media.Color.FromRgb(mainThemeColor.R, mainThemeColor.G, mainThemeColor.B);
            
            // Tìm hoặc tạo nhãn Custom
            Label lblCustomChartTitle = cardChart.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblCustomChartTitle");
            if (lblCustomChartTitle == null)
            {
                lblCustomChartTitle = new Label();
                lblCustomChartTitle.Name = "lblCustomChartTitle";
                lblCustomChartTitle.Text = "DOANH THU";
                lblCustomChartTitle.Font = new Font("Inter", 12F, FontStyle.Bold);
                lblCustomChartTitle.ForeColor = mainThemeColor; // Màu chủ đạo thương hiệu
                lblCustomChartTitle.AutoSize = true;
                lblCustomChartTitle.Location = new Point(20, 16);
                cardChart.Controls.Add(lblCustomChartTitle);
            }
            else
            {
                lblCustomChartTitle.ForeColor = mainThemeColor;
            }

            // Khởi tạo bộ lọc Ngày/Tuần/Tháng/Năm dạng Pill-tabs
            InitializeChartFilter();

            // Cấu hình ColumnSeries (biểu đồ cột mờ nền bên dưới)
            var columnSeries = new ColumnSeries
            {
                Title = "Doanh thu ngày",
                Values = new ChartValues<double> { 6.8, 9.2, 6.7, 9.8, 8.8, 13.5, 5.1, 9.3, 6.8, 11.2 },
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(35, wpfThemeColor.R, wpfThemeColor.G, wpfThemeColor.B)), // Cột mờ trong suốt theo màu chủ đạo
                MaxColumnWidth = 45, // Tăng thêm độ rộng của cột to hơn nữa theo yêu cầu!
                ColumnPadding = 8,
                IsHitTestVisible = false // Ẩn khỏi Tooltip để chỉ hiển thị đúng 1 dòng "Doanh thu"
            };

            // Cấu hình LineSeries với Spline cong và Gradient màu chủ đạo tuyệt đẹp
            var lineSeries = new LineSeries
            {
                Title = "Doanh thu",
                Values = new ChartValues<double> { 6.8, 9.2, 6.7, 9.8, 8.8, 13.5, 5.1, 9.3, 6.8, 11.2 },
                LineSmoothness = 0.6, // Tạo đường cong spline mượt mà
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 10,
                PointForeground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)), // Tâm màu trắng tròn trịa
                Stroke = new System.Windows.Media.SolidColorBrush(wpfThemeColor), // Đường viền màu chủ đạo
                StrokeThickness = 3,
                Fill = new System.Windows.Media.LinearGradientBrush
                {
                    StartPoint = new System.Windows.Point(0, 0),
                    EndPoint = new System.Windows.Point(0, 1),
                    GradientStops = new System.Windows.Media.GradientStopCollection
                    {
                        new System.Windows.Media.GradientStop(System.Windows.Media.Color.FromArgb(40, wpfThemeColor.R, wpfThemeColor.G, wpfThemeColor.B), 0), // Gradient mờ màu chủ đạo
                        new System.Windows.Media.GradientStop(System.Windows.Media.Color.FromArgb(0, wpfThemeColor.R, wpfThemeColor.G, wpfThemeColor.B), 1)
                    }
                }
            };

            chartDoanhThu.Series.Add(columnSeries);
            chartDoanhThu.Series.Add(lineSeries);

            // Trục X hiển thị các ngày chuẩn định dạng
            chartDoanhThu.AxisX.Add(new Axis
            {
                Title = "",
                Labels = new[] { "12/05", "13/05", "14/05", "15/05", "16/05", "17/05", "18/05", "19/05", "20/05", "21/05" },
                Separator = new Separator
                {
                    IsEnabled = false // Tắt đường lưới dọc để biểu đồ thông thoáng
                }
            });

            // Trục Y hiển thị các mốc doanh thu (5M, 10M, 15M, 20M) và lưới nét đứt mờ
            chartDoanhThu.AxisY.Add(new Axis
            {
                Title = "",
                LabelFormatter = value => value + "M",
                ShowLabels = true,
                MinValue = 0, // Cột và đường xuất phát từ mốc 0M phẳng phiêu
                Separator = new Separator
                {
                    IsEnabled = true,
                    StrokeThickness = 1,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(20, 0, 0, 0)), // Đường lưới ngang nét đứt rất mờ
                    StrokeDashArray = new System.Windows.Media.DoubleCollection { 3 } 
                }
            });

            chartDoanhThu.Update(true, true);
        }

        private void LoadDataGridView()
        {
            if (dgvPhien == null) return;
            
            dgvPhien.Rows.Clear();
            try
            {
                var sessionService = new BLL.Services.SessionService();
                var activeSessions = sessionService.GetActiveSessions().ToList();
                
                foreach (var session in activeSessions)
                {
                    string computerCode = session.Computer?.Code ?? "MAY-??";
                    string khach = session.Customer != null ? session.Customer.FullName : (session.GuestName ?? "Khách vãng lai");
                    string loai = session.Customer != null ? "Hội viên" : "Vãng lai";
                    string startStr = session.StartTime.ToString("HH:mm");
                    
                    double totalMinutes = (DateTime.Now - session.StartTime).TotalMinutes;
                    int h = (int)totalMinutes / 60;
                    int m = (int)totalMinutes % 60;
                    string timeUsed = $"{h}g {m}p";
                    
                    decimal sessionAmount = (decimal)(totalMinutes / 60.0) * session.PricePerHour;
                    string tienGio = $"{sessionAmount:N0}đ";
                    
                    // Lấy dịch vụ
                    var services = sessionService.GetServicesForSession(session.Id).ToList();
                    string dichVu = services.Any() ? $"{services.Sum(s => s.Quantity * s.UnitPrice):N0}đ" : "-";
                    
                    dgvPhien.Rows.Add(computerCode, khach, loai, startStr, timeUsed, tienGio, dichVu, "ĐÓNG");
                }
            }
            catch
            {
                // Fallback to static data if DB fails
                dgvPhien.Rows.Add("PC05", "Phạm Quốc Huy", "Hội viên", "14:30", "1g 23p", "41,000đ", "20,000đ", "ĐÓNG");
                dgvPhien.Rows.Add("PC12", "Trần Minh Bình", "Vãng lai", "15:10", "0g 43p", "10,750đ", "-", "ĐÓNG");
                dgvPhien.Rows.Add("PC03", "Lê Thanh Hải", "Hội viên", "13:55", "2g 08p", "32,000đ", "15,000đ", "ĐÓNG");
                dgvPhien.Rows.Add("PC19", "Khách VIP", "Hội viên", "12:00", "4g 15p", "50,000đ", "Nước/Mì", "ĐÓNG");
            }
        }

        // Sự kiện Timer Tick làm mới toàn bộ dữ liệu Dashboard cứ sau 30 giây
        private void TmrRefresh_Tick(object sender, EventArgs e)
        {
            LoadSoDoPhongMay();
            LoadDataGridView();
            ApplyKPICardStyles();
            LoadKPIData(); // Cập nhật KPI cards + footer với số liệu mới nhất
        }
    }
}
