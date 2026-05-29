namespace QuanLyCuaHangGame
{
    partial class dlgRegisterCustomer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.lblPhoneHint = new System.Windows.Forms.Label();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.lblUsernameHint = new System.Windows.Forms.Label();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtConfirmPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.grpPin = new System.Windows.Forms.GroupBox();
            this.txtPin = new MaterialSkin.Controls.MaterialTextBox();
            this.lblPinHint = new System.Windows.Forms.Label();
            this.btnGeneratePin = new MaterialSkin.Controls.MaterialButton();
            this.lblGeneratePinHint = new System.Windows.Forms.Label();
            this.pnlAlert = new System.Windows.Forms.Panel();
            this.lblAlertIcon = new System.Windows.Forms.Label();
            this.lblAlertText = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnCreateAccount = new MaterialSkin.Controls.MaterialButton();
            this.grpPin.SuspendLayout();
            this.pnlAlert.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtName.Hint = "Họ và tên *";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(40, 111);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 50;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(293, 50);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Phạm Quốc Huy";
            this.txtName.TrailingIcon = null;
            // 
            // txtPhone
            // 
            this.txtPhone.AnimateReadOnly = false;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Depth = 0;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtPhone.Hint = "Số điện thoại *";
            this.txtPhone.LeadingIcon = null;
            this.txtPhone.Location = new System.Drawing.Point(360, 111);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.MaxLength = 15;
            this.txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPhone.Multiline = false;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(293, 50);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.Text = "0912 345 678";
            this.txtPhone.TrailingIcon = null;
            // 
            // lblPhoneHint
            // 
            this.lblPhoneHint.AutoSize = true;
            this.lblPhoneHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneHint.ForeColor = System.Drawing.Color.Gray;
            this.lblPhoneHint.Location = new System.Drawing.Point(360, 175);
            this.lblPhoneHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneHint.Name = "lblPhoneHint";
            this.lblPhoneHint.Size = new System.Drawing.Size(294, 20);
            this.lblPhoneHint.TabIndex = 2;
            this.lblPhoneHint.Text = "Dùng để tìm kiếm tài khoản nhanh tại quầy";
            // 
            // txtUsername
            // 
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtUsername.Hint = "Username đăng nhập *";
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(40, 215);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(613, 50);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "pqhuy";
            this.txtUsername.TrailingIcon = null;
            // 
            // lblUsernameHint
            // 
            this.lblUsernameHint.AutoSize = true;
            this.lblUsernameHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameHint.ForeColor = System.Drawing.Color.Gray;
            this.lblUsernameHint.Location = new System.Drawing.Point(40, 279);
            this.lblUsernameHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsernameHint.Name = "lblUsernameHint";
            this.lblUsernameHint.Size = new System.Drawing.Size(272, 20);
            this.lblUsernameHint.TabIndex = 4;
            this.lblUsernameHint.Text = "Khách dùng để đăng nhập vào máy tính";
            // 
            // txtPassword
            // 
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtPassword.Hint = "Mật khẩu *";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(40, 320);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Password = true;
            this.txtPassword.Size = new System.Drawing.Size(293, 50);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "12345678";
            this.txtPassword.TrailingIcon = null;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AnimateReadOnly = false;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Depth = 0;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtConfirmPassword.Hint = "Xác nhận mật khẩu *";
            this.txtConfirmPassword.LeadingIcon = null;
            this.txtConfirmPassword.Location = new System.Drawing.Point(360, 320);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtConfirmPassword.Multiline = false;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Password = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(293, 50);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.Text = "12345678";
            this.txtConfirmPassword.TrailingIcon = null;
            // 
            // grpPin
            // 
            this.grpPin.Controls.Add(this.txtPin);
            this.grpPin.Controls.Add(this.lblPinHint);
            this.grpPin.Controls.Add(this.btnGeneratePin);
            this.grpPin.Controls.Add(this.lblGeneratePinHint);
            this.grpPin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.grpPin.Location = new System.Drawing.Point(40, 412);
            this.grpPin.Margin = new System.Windows.Forms.Padding(4);
            this.grpPin.Name = "grpPin";
            this.grpPin.Padding = new System.Windows.Forms.Padding(4);
            this.grpPin.Size = new System.Drawing.Size(613, 135);
            this.grpPin.TabIndex = 7;
            this.grpPin.TabStop = false;
            this.grpPin.Text = " PIN đăng nhập nhanh ";
            // 
            // txtPin
            // 
            this.txtPin.AnimateReadOnly = false;
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPin.Depth = 0;
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtPin.Hint = "Mã PIN 4 số";
            this.txtPin.LeadingIcon = null;
            this.txtPin.Location = new System.Drawing.Point(20, 31);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4);
            this.txtPin.MaxLength = 4;
            this.txtPin.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPin.Multiline = false;
            this.txtPin.Name = "txtPin";
            this.txtPin.Password = true;
            this.txtPin.Size = new System.Drawing.Size(267, 50);
            this.txtPin.TabIndex = 0;
            this.txtPin.Text = "1234";
            this.txtPin.TrailingIcon = null;
            this.txtPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPin_KeyPress);
            // 
            // lblPinHint
            // 
            this.lblPinHint.AutoSize = true;
            this.lblPinHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPinHint.ForeColor = System.Drawing.Color.Gray;
            this.lblPinHint.Location = new System.Drawing.Point(20, 98);
            this.lblPinHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPinHint.Name = "lblPinHint";
            this.lblPinHint.Size = new System.Drawing.Size(451, 20);
            this.lblPinHint.TabIndex = 1;
            this.lblPinHint.Text = "Khách dùng PIN thay mật khẩu khi đăng nhập nhanh tại quầy lễ tân";
            // 
            // btnGeneratePin
            // 
            this.btnGeneratePin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGeneratePin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGeneratePin.Depth = 0;
            this.btnGeneratePin.HighEmphasis = true;
            this.btnGeneratePin.Icon = null;
            this.btnGeneratePin.Location = new System.Drawing.Point(447, 44);
            this.btnGeneratePin.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnGeneratePin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGeneratePin.Name = "btnGeneratePin";
            this.btnGeneratePin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGeneratePin.Size = new System.Drawing.Size(106, 36);
            this.btnGeneratePin.TabIndex = 3;
            this.btnGeneratePin.Text = "TỰ SINH PIN";
            this.btnGeneratePin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnGeneratePin.UseAccentColor = false;
            this.btnGeneratePin.UseVisualStyleBackColor = true;
            this.btnGeneratePin.Click += new System.EventHandler(this.btnGeneratePin_Click);
            // 
            // lblGeneratePinHint
            // 
            this.lblGeneratePinHint.AutoSize = true;
            this.lblGeneratePinHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneratePinHint.ForeColor = System.Drawing.Color.Gray;
            this.lblGeneratePinHint.Location = new System.Drawing.Point(453, 22);
            this.lblGeneratePinHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeneratePinHint.Name = "lblGeneratePinHint";
            this.lblGeneratePinHint.Size = new System.Drawing.Size(92, 20);
            this.lblGeneratePinHint.TabIndex = 2;
            this.lblGeneratePinHint.Text = "Hoặc tự sinh";
            // 
            // pnlAlert
            // 
            this.pnlAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.pnlAlert.Controls.Add(this.lblAlertIcon);
            this.pnlAlert.Controls.Add(this.lblAlertText);
            this.pnlAlert.Location = new System.Drawing.Point(40, 572);
            this.pnlAlert.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAlert.Name = "pnlAlert";
            this.pnlAlert.Size = new System.Drawing.Size(613, 62);
            this.pnlAlert.TabIndex = 8;
            // 
            // lblAlertIcon
            // 
            this.lblAlertIcon.AutoSize = true;
            this.lblAlertIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblAlertIcon.Location = new System.Drawing.Point(13, 14);
            this.lblAlertIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertIcon.Name = "lblAlertIcon";
            this.lblAlertIcon.Size = new System.Drawing.Size(47, 32);
            this.lblAlertIcon.TabIndex = 0;
            this.lblAlertIcon.Text = "🛡️";
            // 
            // lblAlertText
            // 
            this.lblAlertText.AutoSize = true;
            this.lblAlertText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblAlertText.Location = new System.Drawing.Point(68, 4);
            this.lblAlertText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertText.Name = "lblAlertText";
            this.lblAlertText.Size = new System.Drawing.Size(528, 42);
            this.lblAlertText.TabIndex = 1;
            this.lblAlertText.Text = "Mật khẩu và PIN sẽ được mã hóa BCrypt trước khi lưu. Số dư ban đầu = 0đ.\r\nKhách c" +
    "ần nạp tiền sau khi đăng ký.";
            this.lblAlertText.Click += new System.EventHandler(this.lblAlertText_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(347, 658);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateAccount.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCreateAccount.Depth = 0;
            this.btnCreateAccount.HighEmphasis = true;
            this.btnCreateAccount.Icon = null;
            this.btnCreateAccount.Location = new System.Drawing.Point(453, 658);
            this.btnCreateAccount.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnCreateAccount.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCreateAccount.Size = new System.Drawing.Size(130, 36);
            this.btnCreateAccount.TabIndex = 10;
            this.btnCreateAccount.Text = "TẠO TÀI KHOẢN";
            this.btnCreateAccount.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCreateAccount.UseAccentColor = false;
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // dlgRegisterCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 738);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlAlert);
            this.Controls.Add(this.grpPin);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUsernameHint);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPhoneHint);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgRegisterCustomer";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký hội viên mới";
            this.grpPin.ResumeLayout(false);
            this.grpPin.PerformLayout();
            this.pnlAlert.ResumeLayout(false);
            this.pnlAlert.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialTextBox txtPhone;
        private System.Windows.Forms.Label lblPhoneHint;
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private System.Windows.Forms.Label lblUsernameHint;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialTextBox txtConfirmPassword;
        private System.Windows.Forms.GroupBox grpPin;
        private MaterialSkin.Controls.MaterialTextBox txtPin;
        private System.Windows.Forms.Label lblPinHint;
        private MaterialSkin.Controls.MaterialButton btnGeneratePin;
        private System.Windows.Forms.Label lblGeneratePinHint;
        private System.Windows.Forms.Panel pnlAlert;
        private System.Windows.Forms.Label lblAlertIcon;
        private System.Windows.Forms.Label lblAlertText;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnCreateAccount;
    }
}
