using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace QuanLyCuaHangGame
{
    public partial class frmComputer : Form
    {
        public frmComputer()
        {
            InitializeComponent();
            
            // Hide tabs header if possible, we switch programmatically
            mainTabControl.SelectedIndex = 0;
            UpdateRoleUI(true); // true = Admin, false = Staff
            
            // Add dummy data for Admin
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC01", "Phòng A", "VIP", "i9/RTX4070", "Tốt", "30,000đ" }));
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC02", "Phòng A", "VIP", "i9/RTX4070", "Tốt", "30,000đ" }));
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC07", "Phòng A", "Standard", "i5/GTX1660", "Hỏng", "20,000đ" }));
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC11", "Phòng B", "Standard", "i7/RTX3060", "Đã sửa", "20,000đ" }));
            
            // Add dummy data for Staff
            lvStaff.Items.Add(new ListViewItem(new[] { "PC01", "Phòng A", "VIP", "Tốt", "Đang dùng" }));
            lvStaff.Items.Add(new ListViewItem(new[] { "PC02", "Phòng A", "VIP", "Tốt", "Trống" }));
            lvStaff.Items.Add(new ListViewItem(new[] { "PC07", "Phòng A", "Standard", "Hỏng", "Dừng" }));
            lvStaff.Items.Add(new ListViewItem(new[] { "PC11", "Phòng B", "Standard", "Đã sửa", "Trống" }));
        }

        private void btnRoleAdmin_Click(object sender, EventArgs e)
        {
            UpdateRoleUI(true);
        }

        private void btnRoleStaff_Click(object sender, EventArgs e)
        {
            UpdateRoleUI(false);
        }

        private void UpdateRoleUI(bool isAdmin)
        {
            string newTitle = isAdmin ? "Quản lý máy tính — Chế độ: Admin" : "Quản lý máy tính — Chế độ: Staff (Nhân viên phòng máy)";
            
            if (this.ParentForm != null)
            {
                this.ParentForm.Text = newTitle;
            }
            else
            {
                this.Text = newTitle;
            }

            if (isAdmin)
            {
                mainTabControl.SelectedIndex = 0;
                btnRoleAdmin.Type = MaterialButton.MaterialButtonType.Contained;
                btnRoleStaff.Type = MaterialButton.MaterialButtonType.Outlined;
            }
            else
            {
                mainTabControl.SelectedIndex = 1;
                btnRoleAdmin.Type = MaterialButton.MaterialButtonType.Outlined;
                btnRoleStaff.Type = MaterialButton.MaterialButtonType.Contained;
            }
        }

        private void btnAdminManageRoom_Click(object sender, EventArgs e)
        {
            dlgRoom frm = new dlgRoom();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefreshRoomComboBox();
            }
        }

        private void RefreshRoomComboBox()
        {
            // Update CBO
            cboAdminRoom.Items.Clear();
            cboAdminRoom.Items.AddRange(new object[] {
                "Phòng A",
                "Phòng B",
                "Phòng VIP",
                "Phòng Mới"
            });
            cboAdminRoom.SelectedIndex = 0;
            
            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Đã cập nhật danh sách phòng mới!", 2000);
            SnackBarMessage.Show(this);
        }
    }
}
