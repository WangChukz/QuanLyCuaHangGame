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
            UIHelper.UICommon.ApplyTheme(this);

            btn50.Click += (s, e) => txtAmount.Text = "50000";
            btn100.Click += (s, e) => txtAmount.Text = "100000";
            btn200.Click += (s, e) => txtAmount.Text = "200000";
            btn500.Click += (s, e) => txtAmount.Text = "500000";
        }
    }
}
