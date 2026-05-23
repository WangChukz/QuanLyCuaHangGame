using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace QuanLyCuaHangGame.GUI
{
    public partial class dlgTopUp : MaterialForm
    {


        public dlgTopUp()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Blue200, Accent.LightBlue200, TextShade.WHITE);

            btn50.Click += (s, e) => txtAmount.Text = "50000";
            btn100.Click += (s, e) => txtAmount.Text = "100000";
            btn200.Click += (s, e) => txtAmount.Text = "200000";
            btn500.Click += (s, e) => txtAmount.Text = "500000";
        }
    }
}
