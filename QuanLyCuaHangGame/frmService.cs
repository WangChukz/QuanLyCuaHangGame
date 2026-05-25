using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace QuanLyCuaHangGame.GUI
{
    public partial class frmService : MaterialForm
    {


        public frmService()
        {
            InitializeComponent();
            UIHelper.UICommon.ApplyTheme(this, true);
        }


    }
}
