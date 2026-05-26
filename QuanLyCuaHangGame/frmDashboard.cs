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

        public frmDashboard()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            UICommon.ApplyTheme(this);
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
            
            // Embed frmComputer into tabPageMayTinh (Tab 8)
            frmComputer frmComp = new frmComputer();
            frmComp.TopLevel = false;
            frmComp.FormBorderStyle = FormBorderStyle.None;
            frmComp.Dock = DockStyle.Fill;
            frmComp.BackColor = Color.White; // Nền của form con cũng màu trắng đồng bộ
            tabPageMayTinh.Controls.Add(frmComp);
            frmComp.Show();

            // Embed frmService into tabPageDichVu (Tab 9)
            GUI.frmService frmSvc = new GUI.frmService();
            frmSvc.TopLevel = false;
            frmSvc.FormBorderStyle = FormBorderStyle.None;
            frmSvc.Dock = DockStyle.Fill;
            frmSvc.BackColor = Color.White;
            tabPageDichVu.Controls.Add(frmSvc);
            frmSvc.Show();

            // Embed frmCustomer into tabPageHoiVien
            frmCustomer frmCust = new frmCustomer();
            frmCust.TopLevel = false;
            frmCust.FormBorderStyle = FormBorderStyle.None;
            frmCust.Dock = DockStyle.Fill;
            frmCust.BackColor = Color.White;
            tabPageHoiVien.Controls.Add(frmCust);
            frmCust.Show();

            // Embed frmPayment into tabPageThanhToan
            frmPayment frmPay = new frmPayment();
            frmPay.TopLevel = false;
            frmPay.FormBorderStyle = FormBorderStyle.None;
            frmPay.Dock = DockStyle.Fill;
            frmPay.BackColor = Color.White;
            tabPageThanhToan.Controls.Add(frmPay);
            frmPay.Show();

            // Embed frmUser into tabPageTaiKhoan
            GUI.frmUser frmU = new GUI.frmUser();
            frmU.TopLevel = false;
            frmU.FormBorderStyle = FormBorderStyle.None;
            frmU.Dock = DockStyle.Fill;
            frmU.BackColor = Color.White;
            tabPageTaiKhoan.Controls.Add(frmU);
            frmU.Show();

            // Phân quyền: Ẩn tab Tài khoản nếu không phải Admin
            if (!SessionContext.IsAdmin)
            {
                mainTabControl.TabPages.Remove(tabPageTaiKhoan);
            }

            // Di chuyển pnlFooter từ tabPageDashboard ra ngoài Form chính để hiển thị trên tất cả các tab
            tabPageDashboard.Controls.Remove(pnlFooter);
            this.Controls.Add(pnlFooter);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.BringToFront();

            // Bind SelectedIndexChanged to update Title and Footer
            mainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
            MainTabControl_SelectedIndexChanged(this, EventArgs.Empty);

            tabPageDashboard.SizeChanged += TabPageDashboard_SizeChanged;
            TabPageDashboard_SizeChanged(this, EventArgs.Empty);
            
            // Ép buộc áp dụng style chuẩn SaaS sau khi MaterialSkin load xong
            ApplyKPICardStyles();
            DashboardUIHelper.ApplyGlobalModernStyle(this);

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

            // Ẩn thanh cuộn mặc định của DataGridView nhưng vẫn cho phép cuộn bằng con lăn chuột (SaaS style)
            dgvPhien.ScrollBars = ScrollBars.None;
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

        private void TabPageDashboard_SizeChanged(object sender, EventArgs e)
        {
            int pad = 24; // Padding chuẩn
            int width = tabPageDashboard.ClientSize.Width;
            int height = tabPageDashboard.ClientSize.Height;

            if (width < 800) return;

            // 4 thẻ KPI
            int kpiWidth = (width - (5 * pad)) / 4;
            int kpiHeight = 110;

            cardDoanhThu.Location = new Point(pad, pad);
            cardDoanhThu.Size = new Size(kpiWidth, kpiHeight);

            cardMay.Location = new Point(pad * 2 + kpiWidth, pad);
            cardMay.Size = new Size(kpiWidth, kpiHeight);

            cardHoiVien.Location = new Point(pad * 3 + kpiWidth * 2, pad);
            cardHoiVien.Size = new Size(kpiWidth, kpiHeight);

            cardXuLy.Location = new Point(pad * 4 + kpiWidth * 3, pad);
            cardXuLy.Size = new Size(kpiWidth, kpiHeight);

            int footerGap = 36; // Khoảng cách an toàn để không dính với footer dưới cùng (Đã tăng để cách rộng rãi, đẹp mắt)

            // Dòng dưới cùng: Session DataGridView (100%)
            int bottomHeight = 240; 
            int sessionWidth = width - (2 * pad);

            cardPhien.Size = new Size(sessionWidth, bottomHeight);
            cardPhien.Location = new Point(pad, height - pad - bottomHeight - footerGap);

            // Ở giữa: Sơ đồ máy và Biểu đồ
            int middleY = pad * 2 + kpiHeight;
            int middleHeight = (height - pad - bottomHeight - footerGap) - middleY - pad;

            // Chiều rộng cân đối 50/50 giữa Sơ đồ phòng máy và Biểu đồ doanh thu
            int sodoWidth = (width - (3 * pad)) / 2;
            int chartWidth = sodoWidth;

            cardSoDo.Location = new Point(pad, middleY);
            cardSoDo.Size = new Size(sodoWidth, middleHeight);

            cardChart.Location = new Point(pad * 2 + sodoWidth, middleY);
            cardChart.Size = new Size(chartWidth, middleHeight);

            if (flpSoDo != null)
            {
                flpSoDo.AutoScroll = true;
                flpSoDo.Size = new Size(sodoWidth - 34, middleHeight - 65); 
                
                // Tự động điều chỉnh kích thước nút sơ đồ phòng máy để chia đều 5 cột cân đối, không lãng phí khoảng trống bên phải
                if (flpSoDo.Controls.Count > 0)
                {
                    int cols = 5; // 5 cột đều tăm tắp (20 máy / 5 = 4 hàng chẵn chằn chặn)
                    int availWidth = flpSoDo.ClientSize.Width - 24; // Trừ thêm khoảng rộng để dự phòng cho thanh cuộn dọc
                    int btnWidth = availWidth / cols;

                    foreach (Control ctrl in flpSoDo.Controls)
                    {
                        if (ctrl is Button btn)
                        {
                            btn.Size = new Size(btnWidth - 12, 56);
                        }
                    }
                }
            }

            if (chartDoanhThu != null)
            {
                chartDoanhThu.Location = new Point(17, 60);
                chartDoanhThu.Size = new Size(chartWidth - 34, middleHeight - 75);
            }

            if (pnlChartFilter != null)
            {
                pnlChartFilter.Location = new Point(cardChart.Width - pnlChartFilter.Width - 16, 12);
            }
            
            // Tự động căn chỉnh kích thước và cột DGV
            if (dgvPhien != null)
            {
                dgvPhien.Location = new Point(17, 45);
                dgvPhien.Size = new Size(sessionWidth - 34, bottomHeight - 65);
                dgvPhien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
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

            // Cập nhật nội dung footer động dựa trên Tab được chọn
            if (mainTabControl.SelectedIndex == 3) // Tab thứ 4 (Quản lý máy tính)
            {
                lblFooter.Text = "Tổng: 20 máy    |    VIP: 6    |    Standard: 14    |    Hỏng: 2    |    Chế độ: Admin – toàn quyền";
            }
            else
            {
                lblFooter.Text = $"Nhân viên: Admin    |    Hôm nay: {DateTime.Today:dd/MM/yyyy}    |    Máy đang chạy: 8    |    Doanh thu: 2,450,000đ";
            }
        }

        private void LoadSoDoPhongMay()
        {
            flpSoDo.Controls.Clear();
            
            string[] pcs = { "PC01", "PC02", "PC03", "PC04", "PC05", "PC06", "PC07", "PC08", "PC09", "PC10", 
                             "PC11", "PC12", "PC13", "PC14", "PC15", "PC16", "PC17", "PC18", "PC19", "PC20" };
            string[] statuses = { "Trống", "Trống", "1g23p", "Trống", "0g43p", "Trống", "Hỏng", "Trống", "2g08p", "Trống", 
                                  "Trống", "1g05p", "Trống", "Trống", "Trống", "0g32p", "Trống", "Trống", "Hỏng", "Trống" };

            for (int i = 0; i < 20; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(88, 55);
                btn.Text = pcs[i] + "\n" + statuses[i];
                DashboardUIHelper.FormatRoomMapButton(btn, statuses[i]);

                flpSoDo.Controls.Add(btn);
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
            
            dgvPhien.Rows.Add("PC05", "Phạm Quốc Huy", "Hội viên", "14:30", "1g 23p", "41,000đ", "20,000đ", "ĐÓNG");
            dgvPhien.Rows.Add("PC12", "Trần Minh Bình", "Vãng lai", "15:10", "0g 43p", "10,750đ", "-", "ĐÓNG");
            dgvPhien.Rows.Add("PC03", "Lê Thanh Hải", "Hội viên", "13:55", "2g 08p", "32,000đ", "15,000đ", "ĐÓNG");
            dgvPhien.Rows.Add("PC19", "Khách VIP", "Hội viên", "12:00", "4g 15p", "50,000đ", "Nước/Mì", "ĐÓNG");
        }

        // Sự kiện Timer Tick làm mới toàn bộ dữ liệu Dashboard cứ sau 30 giây
        private void TmrRefresh_Tick(object sender, EventArgs e)
        {
            LoadSoDoPhongMay();
            LoadDataGridView();
            ApplyKPICardStyles();

            // Đảm bảo cập nhật lại kích thước các nút trong Sơ đồ phòng máy
            TabPageDashboard_SizeChanged(this, EventArgs.Empty);
        }
    }
}
