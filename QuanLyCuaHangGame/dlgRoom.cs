using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace QuanLyCuaHangGame
{
    public partial class dlgRoom : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public dlgRoom()
        {
            InitializeComponent();
            
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

            // Dummy data for list view
            lvRooms.Items.Add(new ListViewItem(new[] { "Phòng A", "1", "12 máy", "Hoạt động" }));
            lvRooms.Items.Add(new ListViewItem(new[] { "Phòng B", "1", "8 máy", "Hoạt động" }));
            lvRooms.Items.Add(new ListViewItem(new[] { "Phòng VIP", "2", "4 máy", "Hoạt động" }));
            lvRooms.Items.Add(new ListViewItem(new[] { "Phòng Mới", "2", "0 máy", "Chưa kích hoạt" }));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Simulate saving
            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Lưu thông tin phòng thành công!", 2000);
            SnackBarMessage.Show(this);
        }
    }
}
