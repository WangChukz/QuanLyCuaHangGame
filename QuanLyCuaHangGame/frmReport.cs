using System;
using System.Collections.Generic;
using System.Linq;
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
            ApplyStyles();
            
            cboKyBaoCao.SelectedIndex = 2; // Tháng này
            UpdateDatePickerVisibility();
            LoadReportData();

            // Trigger initial layout
            FrmReport_SizeChanged(this, EventArgs.Empty);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void LoadReportData()
        {
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today;

            string period = cboKyBaoCao.SelectedItem?.ToString() ?? "";
            switch (period)
            {
                case "Hôm nay":
                    from = DateTime.Today;
                    to = DateTime.Today;
                    break;
                case "Tuần này":
                    int diff = (7 + (DateTime.Today.DayOfWeek - DayOfWeek.Monday)) % 7;
                    from = DateTime.Today.AddDays(-1 * diff).Date;
                    to = from.AddDays(6);
                    break;
                case "Tháng này":
                    from = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    to = from.AddMonths(1).AddDays(-1);
                    break;
                case "Quý này":
                    int quarter = (DateTime.Today.Month - 1) / 3 + 1;
                    from = new DateTime(DateTime.Today.Year, (quarter - 1) * 3 + 1, 1);
                    to = from.AddMonths(3).AddDays(-1);
                    break;
                case "Năm nay":
                    from = new DateTime(DateTime.Today.Year, 1, 1);
                    to = new DateTime(DateTime.Today.Year, 12, 31);
                    break;
                case "Tùy chỉnh":
                    from = dtpTuNgay.Value.Date;
                    to = dtpDenNgay.Value.Date;
                    break;
                default:
                    from = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    to = from.AddMonths(1).AddDays(-1);
                    break;
            }

            var service = new QuanLyCuaHangGame.BLL.Services.ReportService();
            var data = service.GetReportData(from, to);

            LoadKPIs(data);
            LoadCharts(data);
            LoadMachineTab(data);
            LoadMemberTab(data);
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

        private void LoadKPIs(QuanLyCuaHangGame.BLL.Services.ReportData data)
        {
            lblDoanhThuValue.Text = data.TotalRevenue.ToString("N0") + "đ";
            lblDoanhThuSub.Text = "Hôm nay: " + data.TotalCashRevenue.ToString("N0") + "đ";
            lblDoanhThuSub.ForeColor = Color.FromArgb(34, 197, 94); // Green

            lblGioMayValue.Text = data.TotalMachineHours.ToString("N0") + "h";
            lblGioMaySub.Text = "trung bình " + (data.TotalMachines > 0 ? (data.TotalMachineHours / data.TotalMachines).ToString("N0") : "0") + "h/máy";
            lblGioMaySub.ForeColor = Color.Gray;

            lblMayHoatDongValue.Text = $"{data.TotalActiveMachines}/{data.TotalMachines}";
            lblMayHoatDongSub.Text = $"{data.BrokenMachines} máy hỏng";
            lblMayHoatDongSub.ForeColor = data.BrokenMachines > 0 ? Color.FromArgb(239, 68, 68) : Color.Gray;

            lblHoiVienMoiValue.Text = data.NewMembers.ToString("N0");
            lblHoiVienMoiSub.Text = "+ hội viên mới";
            lblHoiVienMoiSub.ForeColor = Color.FromArgb(34, 197, 94);
        }

        private void LoadCharts(QuanLyCuaHangGame.BLL.Services.ReportData data)
        {
            // Cartesian Chart (Left)
            var wpfThemeColor = System.Windows.Media.Color.FromRgb(DashboardUIHelper.ThemeColor.R, DashboardUIHelper.ThemeColor.G, DashboardUIHelper.ThemeColor.B);

            var revenueValues = new ChartValues<double>();
            var dateLabels = new List<string>();

            foreach (var kvp in data.RevenueByDay.OrderBy(k => k.Key))
            {
                revenueValues.Add((double)kvp.Value);
                dateLabels.Add(kvp.Key.ToString("dd/MM"));
            }

            if (chartDoanhThu.Series.Count == 0)
            {
                chartDoanhThu.Series.Add(new ColumnSeries
                {
                    Title = "Doanh thu",
                    Fill = new System.Windows.Media.SolidColorBrush(wpfThemeColor),
                    MaxColumnWidth = 30,
                    DataLabels = false
                });
            }
            chartDoanhThu.Series[0].Values = revenueValues;

            if (chartDoanhThu.AxisX.Count == 0)
            {
                chartDoanhThu.AxisX.Add(new Axis
                {
                    Separator = new Separator { IsEnabled = false }
                });
            }
            chartDoanhThu.AxisX[0].Labels = dateLabels.ToArray();

            if (chartDoanhThu.AxisY.Count == 0)
            {
                chartDoanhThu.AxisY.Add(new Axis
                {
                    LabelFormatter = value => value >= 1000000 ? (value / 1000000).ToString("N1") + "M" : (value / 1000).ToString("N0") + "K",
                    Separator = new Separator
                    {
                        IsEnabled = true,
                        StrokeThickness = 1,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(20, 0, 0, 0)),
                        StrokeDashArray = new System.Windows.Media.DoubleCollection { 3 }
                    }
                });
            }

            // Pie Chart (Right)
            chartCoCau.Series.Clear();
            chartCoCau.InnerRadius = 50;
            chartCoCau.LegendLocation = LegendLocation.Right;

            if (data.TotalSessionRevenue > 0)
            {
                chartCoCau.Series.Add(new PieSeries
                {
                    Title = "Tiền giờ chơi",
                    Values = new ChartValues<double> { (double)data.TotalSessionRevenue },
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(wpfThemeColor)
                });
            }
            if (data.TotalServiceRevenue > 0)
            {
                chartCoCau.Series.Add(new PieSeries
                {
                    Title = "Dịch vụ ăn uống",
                    Values = new ChartValues<double> { (double)data.TotalServiceRevenue },
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(34, 197, 94))
                });
            }
            if (data.TotalTopUpRevenue > 0)
            {
                chartCoCau.Series.Add(new PieSeries
                {
                    Title = "Nạp tài khoản",
                    Values = new ChartValues<double> { (double)data.TotalTopUpRevenue },
                    DataLabels = true,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(245, 158, 11))
                });
            }
        }

        private void LoadMachineTab(QuanLyCuaHangGame.BLL.Services.ReportData data)
        {
            if (chartGioMay.Series.Count == 0)
            {
                chartGioMay.Series.Add(new RowSeries
                {
                    Title = "Giờ hoạt động",
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(DashboardUIHelper.ThemeColor.R, DashboardUIHelper.ThemeColor.G, DashboardUIHelper.ThemeColor.B)),
                    DataLabels = true
                });
            }
            chartGioMay.Series[0].Values = new ChartValues<double>(data.TopMachineHours.Select(k => Math.Round(k.Value, 1)));

            if (chartGioMay.AxisY.Count == 0)
            {
                chartGioMay.AxisY.Add(new Axis
                {
                    Separator = new Separator { IsEnabled = false }
                });
            }
            chartGioMay.AxisY[0].Labels = data.TopMachineHours.Select(k => k.Key).ToArray();

            // Set cards for machine status
            cardTot.BackColor = Color.FromArgb(240, 253, 244);
            lblTot.ForeColor = Color.FromArgb(22, 163, 74);
            lblTot.Text = $"{data.GoodMachines} Máy Tốt";

            cardDaSua.BackColor = Color.FromArgb(255, 247, 237);
            lblDaSua.ForeColor = Color.FromArgb(234, 88, 12);
            lblDaSua.Text = $"{data.RepairedMachines} Đã sửa";

            cardHong.BackColor = Color.FromArgb(254, 242, 242);
            lblHong.ForeColor = Color.FromArgb(220, 38, 38);
            lblHong.Text = $"{data.BrokenMachines} Hỏng";
        }

        private void LoadMemberTab(QuanLyCuaHangGame.BLL.Services.ReportData data)
        {
            lvHoiVien.Items.Clear();
            UICommon.AutoResizeListViewColumns(lvHoiVien, new double[] { 0.1, 0.3, 0.2, 0.2, 0.2 });

            int index = 1;
            foreach(var mem in data.TopMembers)
            {
                lvHoiVien.Items.Add(new ListViewItem(new[] { 
                    index.ToString(), 
                    mem.FullName, 
                    mem.Balance.ToString("N0") + "đ", 
                    Math.Round(mem.TotalHours, 1) + "h", 
                    mem.TotalSpent.ToString("N0") + "đ" 
                }));
                index++;
            }
        }

        private void FrmReport_SizeChanged(object sender, EventArgs e)
        {
            int pad = 24;
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            if (width < 200 || height < 200) return;

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
            if (cboKyBaoCao.SelectedItem != null && cboKyBaoCao.SelectedItem.ToString() != "Tùy chỉnh")
            {
                LoadReportData();
            }
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
