using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangGame
{
    public partial class frmCustomer : MaterialForm
    {
        public frmCustomer()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            UIHelper.UICommon.ApplyTheme(this, true);
        }
    }
}
