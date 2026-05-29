using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyCuaHangGame.UIHelper;

namespace QuanLyCuaHangGame
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
            this.Load += FrmReport_Load;
            this.SizeChanged += FrmReport_SizeChanged;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            ApplyStyles();
            LoadKPIs();
            LoadCharts();
            LoadMachineTab();
            LoadMemberTab();
            
            // Ẩn/hiện date picker mặc định
            cboKyBaoCao.SelectedIndex = 2; // Tháng này
            UpdateDatePickerVisibility();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.White;
            foreach (TabPage tab in mainTabControl.TabPages)
            {
                tab.BackColor = Color.White;
            }

            // Style KPI Cards using UIHelper if available, else manual
            Color purpleBg = Color.FromArgb(243, 239, 255);
            Color purpleText = DashboardUIHelper.ThemeColor;
            
            DashboardUIHelper.ApplyKPICardStyles(
                lblDoanhThuValue, lblDoanhThuSub,
                lblGioMayValue, lblGioMaySub,
                lblMayHoatDongValue, lblMayHoatDongSub,
                lblHoiVienMoiValue, lblHoiVienMoiSub);

            lblDoanhThuTitle.ForeColor = Color.Gray;
            lblGioMayTitle.ForeColor = Color.Gray;
            lblMayHoatDongTitle.ForeColor = Color.Gray;
            lblHoiVienMoiTitle.ForeColor = Color.Gray;

            DashboardUIHelper.ApplyGlobalModernStyle(this);
            
            // Pnl top filter
            pnlFilter.BackColor = Color.White;
        }

        private void LoadKPIs()
        {
            lblDoanhThuValue.Text = "48,200,000đ";
            lblDoanhThuSub.Text = "+8% tháng trước";
            lblDoanhThuSub.ForeColor = Color.FromArgb(34, 197, 94); // Green

            lblGioMayValue.Text = "1,240h";
            lblGioMaySub.Text = "trung bình 62h/máy";
            lblGioMaySub.ForeColor = Color.Gray;

            lblMayHoatDongValue.Text = "18/20";
            lblMayHoatDongSub.Text = "2 máy hỏng";
            lblMayHoatDongSub.ForeColor = Color.FromArgb(239, 68, 68); // Red

            lblHoiVienMoiValue.Text = "12";
            lblHoiVienMoiSub.Text = "+ tháng này";
            lblHoiVienMoiSub.ForeColor = Color.FromArgb(34, 197, 94);
        }

        private void LoadCharts()
        {
            // Cartesian Chart (Left)
            chartDoanhThu.Series.Clear();
            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisY.Clear();

            var wpfThemeColor = System.Windows.Media.Color.FromRgb(DashboardUIHelper.ThemeColor.R, DashboardUIHelper.ThemeColor.G, DashboardUIHelper.ThemeColor.B);

            var columnSeries = new ColumnSeries
            {
                Title = "Doanh thu",
                Values = new ChartValues<double> { 5.2, 6.1, 4.8, 7.5, 9.2, 8.1, 10.5, 6.4, 7.8, 12.1, 11.0, 9.5, 8.2, 7.1, 6.5 },
                Fill = new System.Windows.Media.SolidColorBrush(wpfThemeColor),
                MaxColumnWidth = 20,
                DataLabels = false
            };

            chartDoanhThu.Series.Add(columnSeries);
            chartDoanhThu.AxisX.Add(new Axis
            {
                Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" },
                Separator = new Separator { IsEnabled = false }
            });
            chartDoanhThu.AxisY.Add(new Axis
            {
                LabelFormatter = value => value + "M",
                Separator = new Separator
                {
                    IsEnabled = true,
                    StrokeThickness = 1,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(20, 0, 0, 0)),
                    StrokeDashArray = new System.Windows.Media.DoubleCollection { 3 }
                }
            });

            // Pie Chart (Right)
            chartCoCau.Series.Clear();
            chartCoCau.InnerRadius = 50;
            chartCoCau.LegendLocation = LegendLocation.Right;

            chartCoCau.Series.Add(new PieSeries
            {
                Title = "Tiền giờ chơi",
                Values = new ChartValues<double> { 60 },
                DataLabels = true,
                Fill = new System.Windows.Media.SolidColorBrush(wpfThemeColor)
            });
            chartCoCau.Series.Add(new PieSeries
            {
                Title = "Dịch vụ ăn uống",
                Values = new ChartValues<double> { 20 },
                DataLabels = true,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 197, 94))
            });
            chartCoCau.Series.Add(new PieSeries
            {
                Title = "Nạp thẻ game",
                Values = new ChartValues<double> { 20 },
                DataLabels = true,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(245, 158, 11))
            });
        }

        private void LoadMachineTab()
        {
            chartGioMay.Series.Clear();
            chartGioMay.AxisX.Clear();
            chartGioMay.AxisY.Clear();

            var rowSeries = new RowSeries
            {
                Title = "Giờ hoạt động",
                Values = new ChartValues<double> { 120, 95, 110, 80, 150 },
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(DashboardUIHelper.ThemeColor.R, DashboardUIHelper.ThemeColor.G, DashboardUIHelper.ThemeColor.B)),
                DataLabels = true
            };

            chartGioMay.Series.Add(rowSeries);
            chartGioMay.AxisY.Add(new Axis
            {
                Labels = new[] { "PC01", "PC02", "PC03", "PC04", "PC05" },
                Separator = new Separator { IsEnabled = false }
            });

            // Set cards for machine status
            cardTot.BackColor = Color.FromArgb(240, 253, 244);
            lblTot.ForeColor = Color.FromArgb(22, 163, 74);
            lblTot.Text = "16 Máy Tốt";

            cardDaSua.BackColor = Color.FromArgb(255, 247, 237);
            lblDaSua.ForeColor = Color.FromArgb(234, 88, 12);
            lblDaSua.Text = "2 Đã sửa";

            cardHong.BackColor = Color.FromArgb(254, 242, 242);
            lblHong.ForeColor = Color.FromArgb(220, 38, 38);
            lblHong.Text = "2 Hỏng";
        }

        private void LoadMemberTab()
        {
            lvHoiVien.Items.Clear();
            UICommon.AutoResizeListViewColumns(lvHoiVien, new double[] { 0.1, 0.3, 0.2, 0.2, 0.2 });

            lvHoiVien.Items.Add(new ListViewItem(new[] { "1", "Phạm Quốc Huy", "1,500,000đ", "50h", "500,000đ" }));
            lvHoiVien.Items.Add(new ListViewItem(new[] { "2", "Trần Minh Bình", "1,200,000đ", "40h", "300,000đ" }));
            lvHoiVien.Items.Add(new ListViewItem(new[] { "3", "Lê Thanh Hải", "950,000đ", "32h", "200,000đ" }));
            lvHoiVien.Items.Add(new ListViewItem(new[] { "4", "Nguyễn Văn A", "800,000đ", "25h", "150,000đ" }));
            lvHoiVien.Items.Add(new ListViewItem(new[] { "5", "Trương Tấn B", "600,000đ", "20h", "100,000đ" }));
        }

        private void FrmReport_SizeChanged(object sender, EventArgs e)
        {
            int pad = 24;
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            if (width < 800) return;

            // 1. Filter Panel Layout
            pnlFilter.SetBounds(pad, pad, width - (2 * pad), 60);

            // 2. KPI Cards
            int kpiY = pnlFilter.Bottom + 16;
            int kpiWidth = (width - (5 * pad)) / 4;
            int kpiHeight = 110;

            cardDoanhThu.SetBounds(pad, kpiY, kpiWidth, kpiHeight);
            cardGioMay.SetBounds(pad * 2 + kpiWidth, kpiY, kpiWidth, kpiHeight);
            cardMayHoatDong.SetBounds(pad * 3 + kpiWidth * 2, kpiY, kpiWidth, kpiHeight);
            cardHoiVienMoi.SetBounds(pad * 4 + kpiWidth * 3, kpiY, kpiWidth, kpiHeight);

            // 3. TabControl & Content
            int tabY = kpiY + kpiHeight + pad;
            int tabHeight = height - tabY - pad;
            
            // Adjust to tabSelector
            tabSelector.SetBounds(pad, tabY, width - 2 * pad, 48);
            mainTabControl.SetBounds(pad, tabSelector.Bottom + 8, width - 2 * pad, tabHeight - 56);

            // Layout Doanh Thu Tab
            int doanThuW = mainTabControl.ClientSize.Width;
            int doanThuH = mainTabControl.ClientSize.Height;
            if (doanThuW > 0 && doanThuH > 0)
            {
                int chartW = (doanThuW - pad * 3) / 2;
                cardChartDoanhThu.SetBounds(pad, pad, chartW, doanThuH - 2 * pad);
                cardChartCoCau.SetBounds(pad * 2 + chartW, pad, chartW, doanThuH - 2 * pad);
            }

            // Layout May Tinh Tab
            int mayTinhW = mainTabControl.ClientSize.Width;
            int mayTinhH = mainTabControl.ClientSize.Height;
            if (mayTinhW > 0 && mayTinhH > 0)
            {
                int statusW = (mayTinhW - pad * 4) / 3;
                int statusH = 80;
                cardTot.SetBounds(pad, pad, statusW, statusH);
                cardDaSua.SetBounds(pad * 2 + statusW, pad, statusW, statusH);
                cardHong.SetBounds(pad * 3 + statusW * 2, pad, statusW, statusH);

                cardChartGioMay.SetBounds(pad, pad * 2 + statusH, mayTinhW - 2 * pad, mayTinhH - statusH - 3 * pad);
            }
            
            // Layout Hoi Vien Tab
            int hoiVienW = mainTabControl.ClientSize.Width;
            int hoiVienH = mainTabControl.ClientSize.Height;
            if (hoiVienW > 0 && hoiVienH > 0)
            {
                cardHoiVien.SetBounds(pad, pad, hoiVienW - 2 * pad, hoiVienH - 2 * pad);
            }
        }

        private void cboKyBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDatePickerVisibility();
        }

        private void UpdateDatePickerVisibility()
        {
            if (cboKyBaoCao.SelectedItem != null && cboKyBaoCao.SelectedItem.ToString() == "Tùy chỉnh")
            {
                dtpTuNgay.Visible = true;
                dtpDenNgay.Visible = true;
            }
            else
            {
                dtpTuNgay.Visible = false;
                dtpDenNgay.Visible = false;
            }
        }
    }
}
