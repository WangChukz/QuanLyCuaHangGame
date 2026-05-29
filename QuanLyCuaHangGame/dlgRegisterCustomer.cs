using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.UIHelper;

namespace QuanLyCuaHangGame
{
    public partial class  dlgRegisterCustomer : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;

        public dlgRegisterCustomer()
        {
            InitializeComponent();
            
            this.Load += DlgRegisterCustomer_Load;
        }

        private void DlgRegisterCustomer_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            ApplyStyles();
            
            txtName.Focus();
        }

        private void ApplyStyles()
        {
            // Panel bảo mật (Security Alert) bo góc nhẹ
            pnlAlert.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, pnlAlert.Width, pnlAlert.Height), 8));
            
            // Xóa dữ liệu mẫu ban đầu
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtPin.Text = string.Empty;

            // Thiết kế nút bấm với tone DeepPurple
            btnCreateAccount.BackColor = DashboardUIHelper.ThemeColor;
            btnCreateAccount.ForeColor = Color.White;
        }

        private void btnGeneratePin_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            txtPin.Text = rnd.Next(0, 10000).ToString("D4");
        }

        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số hoặc phím điều khiển (như Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                string.IsNullOrWhiteSpace(txtPhone.Text) || 
                string.IsNullOrWhiteSpace(txtUsername.Text) || 
                string.IsNullOrWhiteSpace(txtPassword.Text) || 
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || 
                string.IsNullOrWhiteSpace(txtPin.Text))
            {
                MaterialSnackBar snackBar = new MaterialSnackBar("Vui lòng điền đầy đủ các trường bắt buộc!", 2500);
                snackBar.Show(this);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MaterialSnackBar snackBar = new MaterialSnackBar("Mật khẩu xác nhận không khớp!", 2500);
                snackBar.Show(this);
                txtConfirmPassword.Focus();
                return;
            }

            if (txtPin.Text.Length != 4)
            {
                MaterialSnackBar snackBar = new MaterialSnackBar("Mã PIN phải đủ 4 số!", 2500);
                snackBar.Show(this);
                txtPin.Focus();
                return;
            }

            // Mọi thứ hợp lệ
            MaterialSnackBar successSnack = new MaterialSnackBar("Đăng ký thành công!", 1500);
            successSnack.Show(this);
            
            // Timeout để snackbar hiển thị xong rồi đóng dialog
            Timer timer = new Timer { Interval = 1000 };
            timer.Tick += (s, ev) => 
            {
                timer.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            timer.Start();
        }

        private void lblAlertText_Click(object sender, EventArgs e)
        {

        }
    }
}
