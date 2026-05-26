namespace QuanLyCuaHangGame.GUI
{
    partial class frmUser
    {
        private System.ComponentModel.IContainer components = null;

        // ── Toolbar ───────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnEdit;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private MaterialSkin.Controls.MaterialButton btnReset;

        // ── Body ──────────────────────────────────────────────────────
        private System.Windows.Forms.TableLayoutPanel tblBody;

        // ── Left – ListView ───────────────────────────────────────────
        private System.Windows.Forms.Panel pnlLeft;
        private MaterialSkin.Controls.MaterialListView lvUsers;

        // ── Right – Detail Card ───────────────────────────────────────
        private System.Windows.Forms.Panel pnlRight;
        private MaterialSkin.Controls.MaterialCard cardDetails;
        private System.Windows.Forms.TableLayoutPanel tblCard;
        private MaterialSkin.Controls.MaterialLabel lblTitle;
        private MaterialSkin.Controls.MaterialTextBox txtFullName;
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialTextBox txtConfirmPassword;
        private System.Windows.Forms.GroupBox gbRole;
        private MaterialSkin.Controls.MaterialRadioButton radAdmin;
        private MaterialSkin.Controls.MaterialRadioButton radStaff;
        private System.Windows.Forms.GroupBox gbStatus;
        private MaterialSkin.Controls.MaterialRadioButton radActive;
        private MaterialSkin.Controls.MaterialRadioButton radLocked;
        private System.Windows.Forms.TableLayoutPanel tblButtons;
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnEdit = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnReset = new MaterialSkin.Controls.MaterialButton();

            this.tblBody = new System.Windows.Forms.TableLayoutPanel();

            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lvUsers = new MaterialSkin.Controls.MaterialListView();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.cardDetails = new MaterialSkin.Controls.MaterialCard();
            this.tblCard = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new MaterialSkin.Controls.MaterialLabel();
            this.txtFullName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtConfirmPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.gbRole = new System.Windows.Forms.GroupBox();
            this.radAdmin = new MaterialSkin.Controls.MaterialRadioButton();
            this.radStaff = new MaterialSkin.Controls.MaterialRadioButton();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.radActive = new MaterialSkin.Controls.MaterialRadioButton();
            this.radLocked = new MaterialSkin.Controls.MaterialRadioButton();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();

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

            // ══════════════════════════════════════════════════════════
            // TOOLBAR
            // ══════════════════════════════════════════════════════════
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 60;
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);

            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToolbar.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpToolbar.WrapContents = false;

            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 10, 6, 0);

            this.btnEdit.Text = "Sửa";
            this.btnEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 10, 6, 0);

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 10, 6, 0);

            this.btnReset.Text = "Reset Mật Khẩu";
            this.btnReset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);

            this.flpToolbar.Controls.Add(this.btnAdd);
            this.flpToolbar.Controls.Add(this.btnEdit);
            this.flpToolbar.Controls.Add(this.btnDelete);
            this.flpToolbar.Controls.Add(this.btnReset);

            this.pnlToolbar.Controls.Add(this.flpToolbar);

            // ══════════════════════════════════════════════════════════
            // BODY – 55% list | 45% detail
            // ══════════════════════════════════════════════════════════
            this.tblBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBody.ColumnCount = 2;
            this.tblBody.RowCount = 1;
            this.tblBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55f));
            this.tblBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45f));
            this.tblBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.tblBody.Padding = new System.Windows.Forms.Padding(0);
            this.tblBody.Margin = new System.Windows.Forms.Padding(0);

            // ── LEFT PANEL ──────────────────────────────────────────
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10, 8, 6, 8);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);

            this.lvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvUsers.OwnerDraw = true;
            this.lvUsers.AutoSizeTable = false;
            this.lvUsers.UseCompatibleStateImageBehavior = false;

            System.Windows.Forms.ColumnHeader colFullName = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colUsername = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colRole = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colStatus = new System.Windows.Forms.ColumnHeader();

            colFullName.Text = "Họ và tên"; colFullName.Width = -2;
            colUsername.Text = "Tên đăng nhập"; colUsername.Width = 140;
            colRole.Text = "Vai trò"; colRole.Width = 90;
            colStatus.Text = "Trạng thái"; colStatus.Width = 100;

            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            {
                colFullName, colUsername, colRole, colStatus
            });

            this.pnlLeft.Controls.Add(this.lvUsers);

            // ── RIGHT PANEL ─────────────────────────────────────────
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 8, 10, 8);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);

            this.cardDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDetails.Padding = new System.Windows.Forms.Padding(0);

            // ── tblCard: 1 cột, các row tự co giãn ─────────────────
            this.tblCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCard.ColumnCount = 1;
            this.tblCard.RowCount = 8;
            // row 0 = title, 1-4 = textboxes, 5 = gbRole, 6 = gbStatus, 7 = buttons (fill)
            this.tblCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));      // lblTitle
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));      // txtFullName
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));      // txtUsername
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));      // txtPassword
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));      // txtConfirmPassword
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));      // gbRole
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));      // gbStatus
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f)); // buttons (đẩy xuống đáy)
            this.tblCard.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);

            // lblTitle
            this.lblTitle.Text = "Chi tiết tài khoản";
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 14f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblTitle.AutoSize = true;

            // txtFullName
            this.txtFullName.Hint = "Họ và tên";
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Multiline = false;
            this.txtFullName.AnimateReadOnly = false;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Font = new System.Drawing.Font("Roboto", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);

            // txtUsername
            this.txtUsername.Hint = "Tên đăng nhập (username)";
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Multiline = false;
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Roboto", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);

            // txtPassword
            this.txtPassword.Hint = "Mật khẩu mới";
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Multiline = false;
            this.txtPassword.Password = true;
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Roboto", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);

            // txtConfirmPassword
            this.txtConfirmPassword.Hint = "Xác nhận mật khẩu";
            this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Multiline = false;
            this.txtConfirmPassword.Password = true;
            this.txtConfirmPassword.AnimateReadOnly = false;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Roboto", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);

            // gbRole
            this.gbRole.Text = "Vai trò & Quyền hạn";
            this.gbRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRole.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.gbRole.Padding = new System.Windows.Forms.Padding(6);
            this.gbRole.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.gbRole.Height = 80;

            this.radAdmin.Text = "Admin";
            this.radAdmin.AutoSize = true;
            this.radAdmin.Ripple = true;
            this.radAdmin.Location = new System.Drawing.Point(8, 28);

            this.radStaff.Text = "Staff";
            this.radStaff.AutoSize = true;
            this.radStaff.Ripple = true;
            this.radStaff.Checked = true;
            this.radStaff.Location = new System.Drawing.Point(160, 28);

            this.gbRole.Controls.Add(this.radAdmin);
            this.gbRole.Controls.Add(this.radStaff);

            // gbStatus
            this.gbStatus.Text = "Trạng thái";
            this.gbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStatus.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.gbStatus.Padding = new System.Windows.Forms.Padding(6);
            this.gbStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.gbStatus.Height = 80;

            this.radActive.Text = "Hoạt động";
            this.radActive.AutoSize = true;
            this.radActive.Ripple = true;
            this.radActive.Checked = true;
            this.radActive.Location = new System.Drawing.Point(8, 28);

            this.radLocked.Text = "Khóa";
            this.radLocked.AutoSize = true;
            this.radLocked.Ripple = true;
            this.radLocked.Location = new System.Drawing.Point(160, 28);

            this.gbStatus.Controls.Add(this.radActive);
            this.gbStatus.Controls.Add(this.radLocked);

            // tblButtons – LƯU (fill) | HỦY (auto)
            this.tblButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblButtons.ColumnCount = 2;
            this.tblButtons.RowCount = 1;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tblButtons.Height = 52;
            this.tblButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tblButtons.Padding = new System.Windows.Forms.Padding(0);

            this.btnSave.Text = "Lưu tài khoản";
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 8, 8, 0);

            this.btnCancel.Text = "Hủy";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);

            this.tblButtons.Controls.Add(this.btnSave, 0, 0);
            this.tblButtons.Controls.Add(this.btnCancel, 1, 0);

            // Đưa controls vào tblCard
            this.tblCard.Controls.Add(this.lblTitle, 0, 0);
            this.tblCard.Controls.Add(this.txtFullName, 0, 1);
            this.tblCard.Controls.Add(this.txtUsername, 0, 2);
            this.tblCard.Controls.Add(this.txtPassword, 0, 3);
            this.tblCard.Controls.Add(this.txtConfirmPassword, 0, 4);
            this.tblCard.Controls.Add(this.gbRole, 0, 5);
            this.tblCard.Controls.Add(this.gbStatus, 0, 6);
            this.tblCard.Controls.Add(this.tblButtons, 0, 7);

            this.cardDetails.Controls.Add(this.tblCard);
            this.pnlRight.Controls.Add(this.cardDetails);

            // Đưa panel vào tblBody
            this.tblBody.Controls.Add(this.pnlLeft, 0, 0);
            this.tblBody.Controls.Add(this.pnlRight, 1, 0);

            // ══════════════════════════════════════════════════════════
            // FORM
            // ══════════════════════════════════════════════════════════
            this.Controls.Add(this.tblBody);
            this.Controls.Add(this.pnlToolbar);

            this.pnlToolbar.ResumeLayout(false);
            this.flpToolbar.ResumeLayout(false);
            this.tblBody.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.tblCard.ResumeLayout(false);
            this.tblButtons.ResumeLayout(false);
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
            this.PerformLayout();
        }
    }
}