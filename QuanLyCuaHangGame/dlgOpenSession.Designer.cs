namespace QuanLyCuaHangGame
{
    partial class dlgOpenSession
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpComputerInfo = new System.Windows.Forms.GroupBox();
            this.lblCpuValue = new System.Windows.Forms.Label();
            this.lblCpu = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblTierValue = new System.Windows.Forms.Label();
            this.lblTier = new System.Windows.Forms.Label();
            this.lblCodeValue = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.tabOpenMode = new MaterialSkin.Controls.MaterialTabControl();
            this.tabMember = new System.Windows.Forms.TabPage();
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.cardMemberInfo = new MaterialSkin.Controls.MaterialCard();
            this.lblMemberBalanceValue = new MaterialSkin.Controls.MaterialLabel();
            this.lblMemberBalance = new MaterialSkin.Controls.MaterialLabel();
            this.lblMemberPhone = new MaterialSkin.Controls.MaterialLabel();
            this.lblMemberName = new MaterialSkin.Controls.MaterialLabel();
            this.txtPin = new MaterialSkin.Controls.MaterialTextBox();
            this.txtSearchMember = new MaterialSkin.Controls.MaterialTextBox();
            this.tabGuest = new System.Windows.Forms.TabPage();
            this.lblGuestHint = new System.Windows.Forms.Label();
            this.txtGuestName = new MaterialSkin.Controls.MaterialTextBox();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.grpComputerInfo.SuspendLayout();
            this.tabOpenMode.SuspendLayout();
            this.tabMember.SuspendLayout();
            this.cardMemberInfo.SuspendLayout();
            this.tabGuest.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpComputerInfo
            // 
            this.grpComputerInfo.Controls.Add(this.lblCpuValue);
            this.grpComputerInfo.Controls.Add(this.lblCpu);
            this.grpComputerInfo.Controls.Add(this.lblPriceValue);
            this.grpComputerInfo.Controls.Add(this.lblPrice);
            this.grpComputerInfo.Controls.Add(this.lblTierValue);
            this.grpComputerInfo.Controls.Add(this.lblTier);
            this.grpComputerInfo.Controls.Add(this.lblCodeValue);
            this.grpComputerInfo.Controls.Add(this.lblCode);
            this.grpComputerInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpComputerInfo.ForeColor = System.Drawing.Color.Gray;
            this.grpComputerInfo.Location = new System.Drawing.Point(15, 75);
            this.grpComputerInfo.Name = "grpComputerInfo";
            this.grpComputerInfo.Size = new System.Drawing.Size(650, 100);
            this.grpComputerInfo.TabIndex = 0;
            this.grpComputerInfo.TabStop = false;
            this.grpComputerInfo.Text = "Thông tin máy";
            // 
            // lblCpuValue
            // 
            this.lblCpuValue.AutoSize = true;
            this.lblCpuValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCpuValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCpuValue.Location = new System.Drawing.Point(400, 55);
            this.lblCpuValue.Name = "lblCpuValue";
            this.lblCpuValue.Size = new System.Drawing.Size(147, 17);
            this.lblCpuValue.TabIndex = 7;
            this.lblCpuValue.Text = "Intel Core i9-13900K";
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCpu.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCpu.Location = new System.Drawing.Point(400, 30);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(53, 13);
            this.lblCpu.TabIndex = 6;
            this.lblCpu.Text = "Cấu hình";
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPriceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPriceValue.Location = new System.Drawing.Point(280, 55);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(65, 17);
            this.lblPriceValue.TabIndex = 5;
            this.lblPriceValue.Text = "30,000đ/h";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPrice.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPrice.Location = new System.Drawing.Point(280, 30);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(46, 13);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá/giờ";
            // 
            // lblTierValue
            // 
            this.lblTierValue.AutoSize = true;
            this.lblTierValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTierValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTierValue.Location = new System.Drawing.Point(150, 55);
            this.lblTierValue.Name = "lblTierValue";
            this.lblTierValue.Size = new System.Drawing.Size(29, 17);
            this.lblTierValue.TabIndex = 3;
            this.lblTierValue.Text = "VIP";
            // 
            // lblTier
            // 
            this.lblTier.AutoSize = true;
            this.lblTier.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTier.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTier.Location = new System.Drawing.Point(150, 30);
            this.lblTier.Name = "lblTier";
            this.lblTier.Size = new System.Drawing.Size(35, 13);
            this.lblTier.TabIndex = 2;
            this.lblTier.Text = "Hạng";
            // 
            // lblCodeValue
            // 
            this.lblCodeValue.AutoSize = true;
            this.lblCodeValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCodeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblCodeValue.Location = new System.Drawing.Point(20, 52);
            this.lblCodeValue.Name = "lblCodeValue";
            this.lblCodeValue.Size = new System.Drawing.Size(49, 21);
            this.lblCodeValue.TabIndex = 1;
            this.lblCodeValue.Text = "PC01";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCode.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCode.Location = new System.Drawing.Point(20, 30);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(47, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Mã máy";
            // 
            // tabOpenMode
            // 
            this.tabOpenMode.Controls.Add(this.tabMember);
            this.tabOpenMode.Controls.Add(this.tabGuest);
            this.tabOpenMode.Depth = 0;
            this.tabOpenMode.Location = new System.Drawing.Point(15, 230);
            this.tabOpenMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabOpenMode.Multiline = true;
            this.tabOpenMode.Name = "tabOpenMode";
            this.tabOpenMode.SelectedIndex = 0;
            this.tabOpenMode.Size = new System.Drawing.Size(650, 200);
            this.tabOpenMode.TabIndex = 2;
            // 
            // tabMember
            // 
            this.tabMember.BackColor = System.Drawing.Color.White;
            this.tabMember.Controls.Add(this.lstCustomers);
            this.tabMember.Controls.Add(this.cardMemberInfo);
            this.tabMember.Controls.Add(this.txtPin);
            this.tabMember.Controls.Add(this.txtSearchMember);
            this.tabMember.Location = new System.Drawing.Point(4, 22);
            this.tabMember.Name = "tabMember";
            this.tabMember.Padding = new System.Windows.Forms.Padding(3);
            this.tabMember.Size = new System.Drawing.Size(642, 174);
            this.tabMember.TabIndex = 0;
            this.tabMember.Text = "Hội viên";
            // 
            // lstCustomers
            // 
            this.lstCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCustomers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.ItemHeight = 17;
            this.lstCustomers.Location = new System.Drawing.Point(15, 60);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(280, 53);
            this.lstCustomers.TabIndex = 1;
            // 
            // cardMemberInfo
            // 
            this.cardMemberInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardMemberInfo.Controls.Add(this.lblMemberBalanceValue);
            this.cardMemberInfo.Controls.Add(this.lblMemberBalance);
            this.cardMemberInfo.Controls.Add(this.lblMemberPhone);
            this.cardMemberInfo.Controls.Add(this.lblMemberName);
            this.cardMemberInfo.Depth = 0;
            this.cardMemberInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardMemberInfo.Location = new System.Drawing.Point(320, 10);
            this.cardMemberInfo.Margin = new System.Windows.Forms.Padding(14);
            this.cardMemberInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardMemberInfo.Name = "cardMemberInfo";
            this.cardMemberInfo.Padding = new System.Windows.Forms.Padding(14);
            this.cardMemberInfo.Size = new System.Drawing.Size(310, 150);
            this.cardMemberInfo.TabIndex = 3;
            // 
            // lblMemberBalanceValue
            // 
            this.lblMemberBalanceValue.AutoSize = true;
            this.lblMemberBalanceValue.Depth = 0;
            this.lblMemberBalanceValue.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblMemberBalanceValue.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblMemberBalanceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblMemberBalanceValue.Location = new System.Drawing.Point(15, 105);
            this.lblMemberBalanceValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMemberBalanceValue.Name = "lblMemberBalanceValue";
            this.lblMemberBalanceValue.Size = new System.Drawing.Size(32, 29);
            this.lblMemberBalanceValue.TabIndex = 3;
            this.lblMemberBalanceValue.Text = "0đ";
            // 
            // lblMemberBalance
            // 
            this.lblMemberBalance.AutoSize = true;
            this.lblMemberBalance.Depth = 0;
            this.lblMemberBalance.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMemberBalance.Location = new System.Drawing.Point(15, 75);
            this.lblMemberBalance.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMemberBalance.Name = "lblMemberBalance";
            this.lblMemberBalance.Size = new System.Drawing.Size(76, 19);
            this.lblMemberBalance.TabIndex = 2;
            this.lblMemberBalance.Text = "Số dư ví:";
            // 
            // lblMemberPhone
            // 
            this.lblMemberPhone.AutoSize = true;
            this.lblMemberPhone.Depth = 0;
            this.lblMemberPhone.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMemberPhone.Location = new System.Drawing.Point(15, 45);
            this.lblMemberPhone.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMemberPhone.Name = "lblMemberPhone";
            this.lblMemberPhone.Size = new System.Drawing.Size(43, 19);
            this.lblMemberPhone.TabIndex = 1;
            this.lblMemberPhone.Text = "SĐT: -";
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.Depth = 0;
            this.lblMemberName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMemberName.Location = new System.Drawing.Point(15, 15);
            this.lblMemberName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(60, 19);
            this.lblMemberName.TabIndex = 0;
            this.lblMemberName.Text = "Họ tên: -";
            // 
            // txtPin
            // 
            this.txtPin.AnimateReadOnly = false;
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPin.Depth = 0;
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPin.Hint = "PIN xác nhận (4 số)";
            this.txtPin.LeadingIcon = null;
            this.txtPin.Location = new System.Drawing.Point(15, 120);
            this.txtPin.MaxLength = 4;
            this.txtPin.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPin.Multiline = false;
            this.txtPin.Name = "txtPin";
            this.txtPin.Password = true;
            this.txtPin.Size = new System.Drawing.Size(280, 50);
            this.txtPin.TabIndex = 2;
            this.txtPin.TrailingIcon = null;
            // 
            // txtSearchMember
            // 
            this.txtSearchMember.AnimateReadOnly = false;
            this.txtSearchMember.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchMember.Depth = 0;
            this.txtSearchMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchMember.Hint = "Tìm hội viên (username / SĐT)";
            this.txtSearchMember.LeadingIcon = null;
            this.txtSearchMember.Location = new System.Drawing.Point(15, 5);
            this.txtSearchMember.MaxLength = 50;
            this.txtSearchMember.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearchMember.Multiline = false;
            this.txtSearchMember.Name = "txtSearchMember";
            this.txtSearchMember.Size = new System.Drawing.Size(280, 50);
            this.txtSearchMember.TabIndex = 0;
            this.txtSearchMember.TrailingIcon = null;
            // 
            // tabGuest
            // 
            this.tabGuest.BackColor = System.Drawing.Color.White;
            this.tabGuest.Controls.Add(this.lblGuestHint);
            this.tabGuest.Controls.Add(this.txtGuestName);
            this.tabGuest.Location = new System.Drawing.Point(4, 22);
            this.tabGuest.Name = "tabGuest";
            this.tabGuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabGuest.Size = new System.Drawing.Size(642, 174);
            this.tabGuest.TabIndex = 1;
            this.tabGuest.Text = "Khách vãng lai";
            // 
            // lblGuestHint
            // 
            this.lblGuestHint.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGuestHint.ForeColor = System.Drawing.Color.Gray;
            this.lblGuestHint.Location = new System.Drawing.Point(15, 95);
            this.lblGuestHint.Name = "lblGuestHint";
            this.lblGuestHint.Size = new System.Drawing.Size(500, 50);
            this.lblGuestHint.TabIndex = 1;
            this.lblGuestHint.Text = "Khách vãng lai thanh toán bằng tiền mặt trực tiếp tại quầy khi kết thúc phiên chơ" +
    "i.";
            // 
            // txtGuestName
            // 
            this.txtGuestName.AnimateReadOnly = false;
            this.txtGuestName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGuestName.Depth = 0;
            this.txtGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGuestName.Hint = "Tên khách vãng lai";
            this.txtGuestName.LeadingIcon = null;
            this.txtGuestName.Location = new System.Drawing.Point(15, 30);
            this.txtGuestName.MaxLength = 50;
            this.txtGuestName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtGuestName.Multiline = false;
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(300, 50);
            this.txtGuestName.TabIndex = 0;
            this.txtGuestName.Text = "Khách vãng lai";
            this.txtGuestName.TrailingIcon = null;
            // 
            // tabSelector
            // 
            this.tabSelector.BaseTabControl = this.tabOpenMode;
            this.tabSelector.Depth = 0;
            this.tabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSelector.Location = new System.Drawing.Point(15, 185);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(650, 40);
            this.tabSelector.TabIndex = 1;
            this.tabSelector.Text = "tabSelector";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnConfirm);
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Location = new System.Drawing.Point(15, 440);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(650, 50);
            this.pnlActions.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = null;
            this.btnConfirm.Location = new System.Drawing.Point(550, 7);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirm.Size = new System.Drawing.Size(83, 36);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "MỞ MÁY";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(460, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dlgOpenSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 500);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.tabOpenMode);
            this.Controls.Add(this.grpComputerInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgOpenSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mở máy cho khách";
            this.Load += new System.EventHandler(this.dlgOpenSession_Load);
            this.grpComputerInfo.ResumeLayout(false);
            this.grpComputerInfo.PerformLayout();
            this.tabOpenMode.ResumeLayout(false);
            this.tabMember.ResumeLayout(false);
            this.tabMember.PerformLayout();
            this.cardMemberInfo.ResumeLayout(false);
            this.cardMemberInfo.PerformLayout();
            this.tabGuest.ResumeLayout(false);
            this.tabGuest.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpComputerInfo;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblCodeValue;
        private System.Windows.Forms.Label lblTier;
        private System.Windows.Forms.Label lblTierValue;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblCpuValue;
        private MaterialSkin.Controls.MaterialTabControl tabOpenMode;
        private System.Windows.Forms.TabPage tabMember;
        private System.Windows.Forms.TabPage tabGuest;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private MaterialSkin.Controls.MaterialTextBox txtSearchMember;
        private MaterialSkin.Controls.MaterialTextBox txtPin;
        private System.Windows.Forms.ListBox lstCustomers;
        private MaterialSkin.Controls.MaterialCard cardMemberInfo;
        private MaterialSkin.Controls.MaterialLabel lblMemberName;
        private MaterialSkin.Controls.MaterialLabel lblMemberPhone;
        private MaterialSkin.Controls.MaterialLabel lblMemberBalance;
        private MaterialSkin.Controls.MaterialLabel lblMemberBalanceValue;
        private MaterialSkin.Controls.MaterialTextBox txtGuestName;
        private System.Windows.Forms.Label lblGuestHint;
        private System.Windows.Forms.Panel pnlActions;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialButton btnCancel;
    }
}
