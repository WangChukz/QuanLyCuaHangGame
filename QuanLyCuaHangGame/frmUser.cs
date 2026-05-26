using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.BLL;
using QuanLyCuaHangGame.BLL.Services;
using QuanLyCuaHangGame.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangGame.GUI
{
    public partial class frmUser : MaterialForm
    {
        private UserService _userService;
        private List<User> _users;
        private User _selectedUser;

        private bool _dialogOpen = false;
        private const int WM_SIZE = 0x0005;
        private const int WM_WINDOWPOSCHANGED = 0x0047;

        protected override void WndProc(ref Message m)
        {
            if (_dialogOpen && (m.Msg == WM_SIZE || m.Msg == WM_WINDOWPOSCHANGED))
                return;
            base.WndProc(ref m);
        }

        private void ReApplyLabelColors()
        {
            lblTitle.ForeColor = UIHelper.DashboardUIHelper.ThemeColor;
        }

        private DialogResult SafeShowMessage(string text, string title, MessageBoxButtons btns, MessageBoxIcon icon)
        {
            // Dùng GameZoneDialog (custom, không phải MaterialForm) để tránh
            // MaterialSkinManager trigger UpdateRendering làm vỡ layout form cha.
            var result = UIHelper.GameZoneDialog.Show(text, title, btns, icon, owner: this);
            ReApplyLabelColors();
            return result;
        }

        public frmUser()
        {
            InitializeComponent();
            UIHelper.UICommon.ApplyTheme(this, true);
            UIHelper.UserUIHelper.StyleUserListView(this.lvUsers);

            lblTitle.ForeColor = UIHelper.DashboardUIHelper.ThemeColor;

            _userService = new UserService();
            _users = new List<User>();
            
            InitializeListView();
            WireUpEvents();
            LoadData();
        }

        private void InitializeListView()
        {
            // lvUsers
            lvUsers.Columns.Clear();
            lvUsers.Columns.Add("Họ và tên", 140);
            lvUsers.Columns.Add("Username", 100);
            lvUsers.Columns.Add("Vai trò", 90);
            lvUsers.Columns.Add("Trạng thái", 90);
            lvUsers.Columns.Add("Tạo lúc", 90);

            ImageList imgList = new ImageList();
            imgList.ImageSize = new System.Drawing.Size(1, 40); 
            lvUsers.SmallImageList = imgList;
        }



        private void WireUpEvents()
        {
            lvUsers.SelectedIndexChanged += LvUsers_SelectedIndexChanged;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            // Gắn sự kiện cho các nút trên Toolbar
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnReset.Click += BtnReset_Click;

            lvUsers.Resize += (s, e) =>
            {
                if (lvUsers.Columns.Count == 5)
                {
                    int totalW = lvUsers.ClientSize.Width;
                    lvUsers.Columns[0].Width = (int)(totalW * 0.30);
                    lvUsers.Columns[1].Width = (int)(totalW * 0.20);
                    lvUsers.Columns[2].Width = (int)(totalW * 0.15);
                    lvUsers.Columns[3].Width = (int)(totalW * 0.15);
                    lvUsers.Columns[4].Width = totalW - lvUsers.Columns[0].Width - lvUsers.Columns[1].Width - lvUsers.Columns[2].Width - lvUsers.Columns[3].Width;
                }
            };
        }

        private void LoadData()
        {
            lvUsers.Items.Clear();
            _users = _userService.GetAllUsers().ToList();

            foreach (var user in _users)
            {
                var item = new ListViewItem(user.FullName);
                item.SubItems.Add(user.Username);
                item.SubItems.Add(user.Role);
                item.SubItems.Add(user.IsActive ? "Hoạt động" : "Khóa");
                item.SubItems.Add(user.CreatedAt.ToString("dd/MM/yyyy"));
                item.Tag = user.Id;
                lvUsers.Items.Add(item);
            }
            
            ResetForm();
        }

        private void LvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                int userId = (int)lvUsers.SelectedItems[0].Tag;
                _selectedUser = _users.FirstOrDefault(u => u.Id == userId);
                
                if (_selectedUser != null)
                {
                    txtFullName.Text = _selectedUser.FullName;
                    txtUsername.Text = _selectedUser.Username;
                    txtUsername.Enabled = false; // Disable username change on edit
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    
                    if (_selectedUser.Role == "Admin") radAdmin.Checked = true;
                    else radStaff.Checked = true;

                    if (_selectedUser.IsActive) radActive.Checked = true;
                    else radLocked.Checked = true;
                }
            }
        }

        private void ResetForm()
        {
            _selectedUser = null;
            txtFullName.Text = "";
            txtUsername.Text = "";
            txtUsername.Enabled = true;
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            radStaff.Checked = true;
            radActive.Checked = true;
            lvUsers.SelectedItems.Clear();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                SafeShowMessage("Vui lòng nhập đủ họ tên và tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedUser == null) // Add mode
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    SafeShowMessage("Vui lòng nhập mật khẩu cho tài khoản mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidatePassword(txtPassword.Text))
                {
                    ShowTooltipError("Tối thiểu 8 ký tự, bao gồm chữ cái và số", txtPassword);
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    SafeShowMessage("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var checkUser = _users.FirstOrDefault(u => u.Username.Equals(txtUsername.Text, StringComparison.OrdinalIgnoreCase));
                if (checkUser != null)
                {
                    SafeShowMessage("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newUser = new User
                {
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Role = radAdmin.Checked ? "Admin" : "Staff",
                    IsActive = radActive.Checked
                };

                try
                {
                    _userService.AddUser(newUser, txtPassword.Text);
                    SafeShowMessage("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    SafeShowMessage("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Edit mode
            {
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    if (!ValidatePassword(txtPassword.Text))
                    {
                        ShowTooltipError("Tối thiểu 8 ký tự, bao gồm chữ cái và số", txtPassword);
                        return;
                    }
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        SafeShowMessage("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                _selectedUser.FullName = txtFullName.Text.Trim();
                _selectedUser.Role = radAdmin.Checked ? "Admin" : "Staff";
                _selectedUser.IsActive = radActive.Checked;

                try
                {
                    _userService.UpdateUser(_selectedUser);
                    
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        _userService.ChangePassword(_selectedUser.Id, txtPassword.Text);
                    }
                    
                    SafeShowMessage("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    SafeShowMessage("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidatePassword(string password)
        {
            if (password.Length < 8) return false;
            bool hasLetter = false;
            bool hasDigit = false;
            foreach (char c in password)
            {
                if (char.IsLetter(c)) hasLetter = true;
                if (char.IsDigit(c)) hasDigit = true;
            }
            return hasLetter && hasDigit;
        }

        private void ShowTooltipError(string message, Control control)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Mật khẩu không hợp lệ";
            tooltip.Show(message, control, control.Width / 2, control.Height, 3000);
            control.Focus();
        }

        private void cardDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        // Sự kiện nhấn nút Thêm Mới
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Gọi hàm ResetForm có sẵn để xóa trắng các ô text và bỏ chọn listview
            ResetForm();
            txtFullName.Focus();
        }

        // Sự kiện nhấn nút Sửa
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                SafeShowMessage("Vui lòng chọn một tài khoản để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Dữ liệu đã được load lên form thông qua sự kiện LvUsers_SelectedIndexChanged
            txtFullName.Focus();
        }

        // Sự kiện nhấn nút Xóa
        // Sự kiện nhấn nút Xóa
        // Sự kiện nhấn nút Xóa
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                SafeShowMessage("Vui lòng chọn một tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = (int)lvUsers.SelectedItems[0].Tag;

            // Chặn người dùng tự xóa chính tài khoản họ đang đăng nhập
            if (SessionContext.CurrentUserId == userId)
            {
                SafeShowMessage("Bạn không thể xóa chính tài khoản đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = SafeShowMessage("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes || confirm == DialogResult.OK)
            {
                try
                {
                    _userService.DeleteUser(userId);
                    SafeShowMessage("Đã xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Load lại list view
                }
                catch (Exception ex)
                {
                    // Truy vết lỗi sâu nhất từ SQL Server
                    string errorMsg = ex.Message;
                    Exception inner = ex.InnerException;
                    while (inner != null)
                    {
                        errorMsg += "\n\nChi tiết SQL: " + inner.Message;
                        inner = inner.InnerException;
                    }
                    SafeShowMessage("Lỗi không xóa được:\n" + errorMsg, "Phân tích lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện nhấn nút Reset Mật Khẩu
        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                SafeShowMessage("Vui lòng chọn một tài khoản để reset mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = SafeShowMessage("Bạn có chắc chắn muốn reset mật khẩu của tài khoản này về mặc định (12345678a) không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                int userId = (int)lvUsers.SelectedItems[0].Tag;
                try
                {
                    // Reset về mật khẩu mặc định, bạn có thể tự đổi nếu muốn
                    _userService.ChangePassword(userId, "12345678a");
                    SafeShowMessage("Reset mật khẩu thành công! Mật khẩu mới là: 12345678a", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    SafeShowMessage("Lỗi khi reset mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
