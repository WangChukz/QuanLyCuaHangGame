namespace QuanLyCuaHangGame.GUI
{
    partial class frmUser
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialListView lvUsers;
        private MaterialSkin.Controls.MaterialTextBox txtFullName;
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialTextBox txtConfirmPassword;
        private MaterialSkin.Controls.MaterialRadioButton radAdmin;
        private MaterialSkin.Controls.MaterialRadioButton radStaff;
        private MaterialSkin.Controls.MaterialRadioButton radActive;
        private MaterialSkin.Controls.MaterialRadioButton radLocked;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lvUsers = new MaterialSkin.Controls.MaterialListView();
            this.txtFullName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtConfirmPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.radAdmin = new MaterialSkin.Controls.MaterialRadioButton();
            this.radStaff = new MaterialSkin.Controls.MaterialRadioButton();
            this.radActive = new MaterialSkin.Controls.MaterialRadioButton();
            this.radLocked = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnEdit = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnReset = new MaterialSkin.Controls.MaterialButton();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.cardDetails = new MaterialSkin.Controls.MaterialCard();
            this.lblTitle = new MaterialSkin.Controls.MaterialLabel();
            this.gbRole = new System.Windows.Forms.GroupBox();
            this.gbStatus = new System.Windows.Forms.GroupBox();

            this.pnlToolbar.SuspendLayout();
            this.flpToolbar.SuspendLayout();
            this.tblBody.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.cardDetails.SuspendLayout();
            this.tblCard.SuspendLayout();
            this.gbRole.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.tblButtons.SuspendLayout();
            this.SuspendLayout();

            // ── lvUsers ────────────────────────────────────────────────
            this.lvUsers.AutoSizeTable = false;
            this.lvUsers.BackColor = System.Drawing.Color.White;
            this.lvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvUsers.Depth = 0;
            this.lvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.OwnerDraw = true;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.Columns.Add("Họ tên", 140);
            this.lvUsers.Columns.Add("Username", 90);
            this.lvUsers.Columns.Add("Vai trò", 70);
            this.lvUsers.Columns.Add("Trạng thái", 85);

            // ── txtFullName ────────────────────────────────────────────
            this.txtFullName.AnimateReadOnly = false;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Depth = 0;
            this.txtFullName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFullName.Hint = "Họ và tên";
            this.txtFullName.LeadingIcon = null;
            this.txtFullName.Location = new System.Drawing.Point(16, 55);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Multiline = false;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(320, 50);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Text = "";
            this.txtFullName.TrailingIcon = null;

            // ── txtUsername ────────────────────────────────────────────
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.Hint = "Tên đăng nhập (username)";
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(16, 120);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 50);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Text = "";
            this.txtUsername.TrailingIcon = null;

            // ── txtPassword ────────────────────────────────────────────
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.Hint = "Mật khẩu mới";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(16, 185);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Multiline = false;
            this.txtPassword.Password = true;
            this.txtPassword.Size = new System.Drawing.Size(320, 50);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "";
            this.txtPassword.TrailingIcon = null;

            // ── txtConfirmPassword ─────────────────────────────────────
            this.txtConfirmPassword.AnimateReadOnly = false;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Depth = 0;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtConfirmPassword.Hint = "Xác nhận mật khẩu";
            this.txtConfirmPassword.LeadingIcon = null;
            this.txtConfirmPassword.Location = new System.Drawing.Point(16, 250);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Multiline = false;
            this.txtConfirmPassword.Password = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(320, 50);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.Text = "";
            this.txtConfirmPassword.TrailingIcon = null;

            // ── radAdmin ───────────────────────────────────────────────
            this.radAdmin.AutoSize = true;
            this.radAdmin.Depth = 0;
            this.radAdmin.Location = new System.Drawing.Point(12, 28);
            this.radAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.radAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.radAdmin.Name = "radAdmin";
            this.radAdmin.Ripple = true;
            this.radAdmin.Size = new System.Drawing.Size(81, 37);
            this.radAdmin.TabIndex = 0;
            this.radAdmin.Text = "Admin";

            // ── radStaff ───────────────────────────────────────────────
            this.radStaff.AutoSize = true;
            this.radStaff.Ripple = true;
            this.radStaff.Checked = true;
            this.radStaff.Depth = 0;
            this.radStaff.Location = new System.Drawing.Point(140, 28);
            this.radStaff.Margin = new System.Windows.Forms.Padding(0);
            this.radStaff.MouseState = MaterialSkin.MouseState.HOVER;
            this.radStaff.Name = "radStaff";
            this.radStaff.Ripple = true;
            this.radStaff.Size = new System.Drawing.Size(71, 37);
            this.radStaff.TabIndex = 1;
            this.radStaff.TabStop = true;
            this.radStaff.Text = "Staff";

            // ── radActive ──────────────────────────────────────────────
            this.radActive.AutoSize = true;
            this.radActive.Ripple = true;
            this.radActive.Checked = true;
            this.radActive.Depth = 0;
            this.radActive.Location = new System.Drawing.Point(12, 28);
            this.radActive.Margin = new System.Windows.Forms.Padding(0);
            this.radActive.MouseState = MaterialSkin.MouseState.HOVER;
            this.radActive.Name = "radActive";
            this.radActive.Ripple = true;
            this.radActive.Size = new System.Drawing.Size(110, 37);
            this.radActive.TabIndex = 0;
            this.radActive.TabStop = true;
            this.radActive.Text = "Hoạt động";

            // ── radLocked ──────────────────────────────────────────────
            this.radLocked.AutoSize = true;
            this.radLocked.Depth = 0;
            this.radLocked.Location = new System.Drawing.Point(140, 28);
            this.radLocked.Margin = new System.Windows.Forms.Padding(0);
            this.radLocked.MouseState = MaterialSkin.MouseState.HOVER;
            this.radLocked.Name = "radLocked";
            this.radLocked.Ripple = true;
            this.radLocked.Size = new System.Drawing.Size(72, 37);
            this.radLocked.TabIndex = 1;
            this.radLocked.Text = "Khóa";

            // ── gbRole ─────────────────────────────────────────────────
            this.gbRole.Controls.Add(this.radAdmin);
            this.gbRole.Controls.Add(this.radStaff);
            this.gbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbRole.Location = new System.Drawing.Point(16, 315);
            this.gbRole.Name = "gbRole";
            this.gbRole.Size = new System.Drawing.Size(320, 75);
            this.gbRole.TabIndex = 5;
            this.gbRole.TabStop = false;
            this.gbRole.Text = "Vai trò & Quyền hạn";

            // ── gbStatus ───────────────────────────────────────────────
            this.gbStatus.Controls.Add(this.radActive);
            this.gbStatus.Controls.Add(this.radLocked);
            this.gbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbStatus.Location = new System.Drawing.Point(16, 405);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(320, 75);
            this.gbStatus.TabIndex = 6;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Trạng thái";

            // ── btnCancel ──────────────────────────────────────────────
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = false;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(136, 500);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnCancel.UseAccentColor = false;

            // ── btnSave ────────────────────────────────────────────────
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(208, 500);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(128, 36);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu tài khoản";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;

            // ── lblTitle ───────────────────────────────────────────────
            this.lblTitle.AutoSize = true;
            this.lblTitle.Depth = 0;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết tài khoản";

            // ── cardDetails ────────────────────────────────────────────
            this.cardDetails.BackColor = System.Drawing.Color.White;
            this.cardDetails.Controls.Add(this.lblTitle);
            this.cardDetails.Controls.Add(this.txtFullName);
            this.cardDetails.Controls.Add(this.txtUsername);
            this.cardDetails.Controls.Add(this.txtPassword);
            this.cardDetails.Controls.Add(this.txtConfirmPassword);
            this.cardDetails.Controls.Add(this.gbRole);
            this.cardDetails.Controls.Add(this.gbStatus);
            this.cardDetails.Controls.Add(this.btnCancel);
            this.cardDetails.Controls.Add(this.btnSave);
            this.cardDetails.Depth = 0;
            this.cardDetails.Location = new System.Drawing.Point(16, 16);
            this.cardDetails.Margin = new System.Windows.Forms.Padding(14);
            this.cardDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardDetails.Name = "cardDetails";
            this.cardDetails.Padding = new System.Windows.Forms.Padding(16);
            // Cố định kích thước card thay vì Dock=Fill để tránh bị kéo giãn
            this.cardDetails.Size = new System.Drawing.Size(370, 560);
            this.cardDetails.TabIndex = 0;

            // ── pnlRight ───────────────────────────────────────────────
            this.pnlRight.Controls.Add(this.cardDetails);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(16);
            this.pnlRight.TabIndex = 0;

            // ── pnlLeft ────────────────────────────────────────────────
            this.pnlLeft.Controls.Add(this.lvUsers);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(420, 999);
            this.pnlLeft.TabIndex = 1;

            // ── Toolbar buttons ────────────────────────────────────────
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Depth = 0;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Location = new System.Drawing.Point(4, 6);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;

            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.Depth = 0;
            this.btnEdit.HighEmphasis = false;
            this.btnEdit.Location = new System.Drawing.Point(105, 6);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;

            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Depth = 0;
            this.btnDelete.HighEmphasis = false;
            this.btnDelete.Location = new System.Drawing.Point(177, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;

            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Depth = 0;
            this.btnReset.HighEmphasis = false;
            this.btnReset.Location = new System.Drawing.Point(249, 6);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(143, 36);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset Mật Khẩu";
            this.btnReset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;

            // ── flpToolbar ─────────────────────────────────────────────
            this.flpToolbar.Controls.Add(this.btnAdd);
            this.flpToolbar.Controls.Add(this.btnEdit);
            this.flpToolbar.Controls.Add(this.btnDelete);
            this.flpToolbar.Controls.Add(this.btnReset);
            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToolbar.Name = "flpToolbar";
            this.flpToolbar.TabIndex = 0;

            // ── pnlToolbar ─────────────────────────────────────────────
            this.pnlToolbar.Controls.Add(this.flpToolbar);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlToolbar.Size = new System.Drawing.Size(999, 55);
            this.pnlToolbar.TabIndex = 2;

            // ── frmUser ────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlToolbar);
            this.MinimumSize = new System.Drawing.Size(860, 640);
            this.Name = "frmUser";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản & Phân quyền";

            this.pnlToolbar.ResumeLayout(false);
            this.flpToolbar.ResumeLayout(false);
            this.tblBody.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.cardDetails.ResumeLayout(false);
            this.cardDetails.PerformLayout();
            this.gbRole.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.cardDetails.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản & Phân quyền";

            this.ResumeLayout(false);
        }
    }
}