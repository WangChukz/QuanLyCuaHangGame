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

namespace QuanLyCuaHangGame
{
    public partial class frmDashboard : MaterialForm
    {
        public frmDashboard()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Blue200, Accent.LightBlue200, TextShade.WHITE);

            this.Load += FrmDashboard_Load;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            LoadSoDoPhongMay();
            LoadChart();
            LoadListView();
            
            // Embed frmComputer into tabPageMayTinh (Tab 8)
            frmComputer frmComp = new frmComputer();
            frmComp.TopLevel = false;
            frmComp.FormBorderStyle = FormBorderStyle.None;
            frmComp.Dock = DockStyle.Fill;
            tabPageMayTinh.Controls.Add(frmComp);
            frmComp.Show();

            // Bind SelectedIndexChanged to update Title
            mainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedIndex)
            {
                case 0:
                    this.Text = "Đăng nhập";
                    break;
                case 1:
                    this.Text = "Quản lý tài khoản";
                    break;
                case 2:
                    this.Text = "Dashboard – Tổng quan hệ thống";
                    break;
                case 3:
                    this.Text = "Sơ đồ phòng máy";
                    break;
                case 4:
                    this.Text = "Thuê máy";
                    break;
                case 5:
                    this.Text = "Thanh toán";
                    break;
                case 6:
                    this.Text = "Quản lý hội viên";
                    break;
                case 7:
                    this.Text = "Quản lý máy tính — Chế độ: Admin";
                    break;
                case 8:
                    this.Text = "Quản lý dịch vụ";
                    break;
                case 9:
                    this.Text = "Báo cáo";
                    break;
                default:
                    this.Text = "GameStore Management";
                    break;
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
                btn.FlatStyle = FlatStyle.Flat;
                btn.Text = pcs[i] + "\n" + statuses[i];
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                btn.Margin = new Padding(4);
                btn.BackColor = Color.White;

                if (statuses[i] == "Trống")
                {
                    btn.FlatAppearance.BorderColor = Color.ForestGreen;
                    btn.ForeColor = Color.ForestGreen;
                }
                else if (statuses[i] == "Hỏng")
                {
                    btn.FlatAppearance.BorderColor = Color.Crimson;
                    btn.ForeColor = Color.Crimson;
                }
                else
                {
                    btn.FlatAppearance.BorderColor = Color.DodgerBlue;
                    btn.ForeColor = Color.DodgerBlue;
                }

                flpSoDo.Controls.Add(btn);
            }
        }

        private void LoadChart()
        {
            chartDoanhThu.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<double> { 2, 2, 2, 2, 3, 4, 2 },
                    DataLabels = true,
                    LabelPoint = point => point.Y + "k",
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(144, 202, 249))
                }
            };

            // Highlight T5 somehow (simulated by adding it as a separate color, but for simplicity we'll just use one color)

            chartDoanhThu.AxisX.Add(new Axis
            {
                Title = "",
                Labels = new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" },
                Separator = new Separator { Step = 1, IsEnabled = false }
            });

            chartDoanhThu.AxisY.Add(new Axis
            {
                Title = "",
                LabelFormatter = value => "",
                ShowLabels = false,
                Separator = new Separator { IsEnabled = false }
            });
            
            chartDoanhThu.Update(true, true);
        }

        private void LoadListView()
        {
            lvPhien.Items.Clear();
            
            var item1 = new ListViewItem(new[] { "PC05", "Phạm Quốc Huy", "Hội viên", "14:30", "1g 23p", "41,000đ", "20,000đ", "ĐÓNG" });
            var item2 = new ListViewItem(new[] { "PC12", "Trần Minh Bình", "Vãng lai", "15:10", "0g 43p", "10,750đ", "-", "ĐÓNG" });
            var item3 = new ListViewItem(new[] { "PC03", "Lê Thanh Hải", "Hội viên", "13:55", "2g 08p", "32,000đ", "15,000đ", "ĐÓNG" });

            lvPhien.Items.Add(item1);
            lvPhien.Items.Add(item2);
            lvPhien.Items.Add(item3);
        }
    }
}
