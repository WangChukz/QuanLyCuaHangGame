using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.Model;
using QuanLyCuaHangGame.BLL.Services;

namespace QuanLyCuaHangGame.GUI
{
    public partial class frmUser : MaterialForm
    {


        public frmUser()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Blue700, Primary.Blue200, Accent.LightBlue200, TextShade.WHITE);
        }

    }
}
