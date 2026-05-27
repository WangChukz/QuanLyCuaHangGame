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

        // Logic giống frmService
        private User _selectedUser;
        private int _currentUserId = 0;
        private bool _isEditing = false;

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

        private DialogResult SafeShowMessage(
            string text,
            string title,
            MessageBoxButtons btns,
            MessageBoxIcon icon)
        {
            var result = UIHelper.GameZoneDialog.Show(
                text,
                title,
                btns,
                icon,
                owner: this);

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

                    lvUsers.Columns[4].Width =
                        totalW
                        - lvUsers.Columns[0].Width
                        - lvUsers.Columns[1].Width
                        - lvUsers.Columns[2].Width
                        - lvUsers.Columns[3].Width;
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

        // Không auto load dữ liệu khi click
        private void LvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                // Không làm gì
            }
        }

        private void ResetForm()
        {
            _selectedUser = null;

            _currentUserId = 0;
            _isEditing = false;

            txtFullName.Text = "";
            txtUsername.Text = "";
            txtUsername.Enabled = true;

            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            radStaff.Checked = true;
            radActive.Checked = true;

            lvUsers.SelectedItems.Clear();

            btnSave.Text = "Thêm";
        }

        // HỦY
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        // LƯU
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text)
                || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                SafeShowMessage(
                    "Vui lòng nhập đủ họ tên và tên đăng nhập!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // ADD MODE
            if (!_isEditing)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    SafeShowMessage(
                        "Vui lòng nhập mật khẩu cho tài khoản mới!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!ValidatePassword(txtPassword.Text))
                {
                    ShowTooltipError(
                        "Tối thiểu 8 ký tự, bao gồm chữ cái và số",
                        txtPassword);

                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    SafeShowMessage(
                        "Mật khẩu xác nhận không khớp!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var checkUser = _users.FirstOrDefault(
                    u => u.Username.Equals(
                        txtUsername.Text,
                        StringComparison.OrdinalIgnoreCase));

                if (checkUser != null)
                {
                    SafeShowMessage(
                        "Tên đăng nhập đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

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

                    SafeShowMessage(
                        "Thêm tài khoản thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                }
                catch (Exception ex)
                {
                    SafeShowMessage(
                        "Lỗi khi thêm: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            // EDIT MODE
            else
            {
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    if (!ValidatePassword(txtPassword.Text))
                    {
                        ShowTooltipError(
                            "Tối thiểu 8 ký tự, bao gồm chữ cái và số",
                            txtPassword);

                        return;
                    }

                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        SafeShowMessage(
                            "Mật khẩu xác nhận không khớp!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }

                var user = _users.FirstOrDefault(u => u.Id == _currentUserId);

                if (user != null)
                {
                    user.FullName = txtFullName.Text.Trim();
                    user.Role = radAdmin.Checked ? "Admin" : "Staff";
                    user.IsActive = radActive.Checked;

                    try
                    {
                        _userService.UpdateUser(user);

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            _userService.ChangePassword(user.Id, txtPassword.Text);
                        }

                        SafeShowMessage(
                            "Cập nhật tài khoản thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        SafeShowMessage(
                            "Lỗi khi cập nhật: " + ex.Message,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidatePassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                    hasLetter = true;

                if (char.IsDigit(c))
                    hasDigit = true;
            }

            return hasLetter && hasDigit;
        }

        private void ShowTooltipError(string message, Control control)
        {
            ToolTip tooltip = new ToolTip();

            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Mật khẩu không hợp lệ";

            tooltip.Show(
                message,
                control,
                control.Width / 2,
                control.Height,
                3000);

            control.Focus();
        }

        private void cardDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        // THÊM
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ResetForm();

            _isEditing = false;
            _currentUserId = 0;

            btnSave.Text = "Thêm";

            txtFullName.Focus();
        }

        // SỬA
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                SafeShowMessage(
                    "Vui lòng chọn một tài khoản để sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int userId = (int)lvUsers.SelectedItems[0].Tag;

            var user = _users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                _selectedUser = user;

                _isEditing = true;
                _currentUserId = userId;

                btnSave.Text = "Cập nhật";

                txtFullName.Text = user.FullName;
                txtUsername.Text = user.Username;

                txtUsername.Enabled = false;

                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                if (user.Role == "Admin")
                    radAdmin.Checked = true;
                else
                    radStaff.Checked = true;

                if (user.IsActive)
                    radActive.Checked = true;
                else
                    radLocked.Checked = true;

                txtFullName.Focus();
            }
        }

        // XÓA
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

        // RESET PASSWORD
        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                SafeShowMessage(
                    "Vui lòng chọn một tài khoản để reset mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var confirm = SafeShowMessage(
                "Bạn có chắc chắn muốn reset mật khẩu của tài khoản này về mặc định (12345678a) không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                int userId = (int)lvUsers.SelectedItems[0].Tag;

                try
                {
                    _userService.ChangePassword(userId, "12345678a");

                    SafeShowMessage(
                        "Reset mật khẩu thành công! Mật khẩu mới là: 12345678a",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    SafeShowMessage(
                        "Lỗi khi reset mật khẩu: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}