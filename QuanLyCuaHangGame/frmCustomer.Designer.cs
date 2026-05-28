using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangGame
{
    partial class frmCustomer
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRegister = new MaterialSkin.Controls.MaterialButton();
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox2();
            this.mlvHoiVien = new MaterialSkin.Controls.MaterialListView();
            this.colHoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoDu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cardUser = new MaterialSkin.Controls.MaterialCard();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblCardName = new System.Windows.Forms.Label();
            this.lblCardInfo = new System.Windows.Forms.Label();
            this.lblCardBalanceTitle = new System.Windows.Forms.Label();
            this.lblCardBalance = new System.Windows.Forms.Label();
            this.lblCardRegDate = new System.Windows.Forms.Label();
            this.lblCardPin = new System.Windows.Forms.Label();
            this.cardNapTien = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtMoney = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtNote = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnNapTien = new MaterialSkin.Controls.MaterialButton();
            this.cardHistory = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.mlvHistory = new MaterialSkin.Controls.MaterialListView();
            this.colLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMoTa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelTop.SuspendLayout();
            this.cardUser.SuspendLayout();
            this.cardNapTien.SuspendLayout();
            this.cardHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.Controls.Add(this.btnRegister);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Location = new System.Drawing.Point(20, 75);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(880, 55);
            this.panelTop.TabIndex = 5;
            // 
            // btnRegister
            // 
            this.btnRegister.AutoSize = false;
            this.btnRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRegister.Depth = 0;
            this.btnRegister.HighEmphasis = true;
            this.btnRegister.Icon = null;
            this.btnRegister.Location = new System.Drawing.Point(0, 5);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRegister.Size = new System.Drawing.Size(190, 45);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "👤 ĐĂNG KÝ HỘI VIÊN";
            this.btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegister.UseAccentColor = false;
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AnimateReadOnly = false;
            this.txtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.HideSelection = true;
            this.txtSearch.Hint = "Tìm theo tên, SĐT, username";
            this.txtSearch.LeadingIcon = null;
            this.txtSearch.Location = new System.Drawing.Point(220, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PrefixSuffixText = null;
            this.txtSearch.ReadOnly = false;
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(650, 48);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TabStop = false;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.TrailingIcon = null;
            this.txtSearch.UseSystemPasswordChar = false;
            // 
            // mlvHoiVien
            // 
            this.mlvHoiVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mlvHoiVien.AutoSizeTable = false;
            this.mlvHoiVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mlvHoiVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvHoiVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHoTen,
            this.colSDT,
            this.colUsername,
            this.colSoDu,
            this.colTrangThai});
            this.mlvHoiVien.Depth = 0;
            this.mlvHoiVien.FullRowSelect = true;
            this.mlvHoiVien.HideSelection = false;
            this.mlvHoiVien.Location = new System.Drawing.Point(20, 140);
            this.mlvHoiVien.MinimumSize = new System.Drawing.Size(200, 100);
            this.mlvHoiVien.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mlvHoiVien.MouseState = MaterialSkin.MouseState.OUT;
            this.mlvHoiVien.Name = "mlvHoiVien";
            this.mlvHoiVien.OwnerDraw = true;
            this.mlvHoiVien.Size = new System.Drawing.Size(502, 392);
            this.mlvHoiVien.TabIndex = 1;
            this.mlvHoiVien.UseCompatibleStateImageBehavior = false;
            this.mlvHoiVien.View = System.Windows.Forms.View.Details;
            // 
            // colHoTen
            // 
            this.colHoTen.Text = "Họ tên";
            this.colHoTen.Width = 140;
            // 
            // colSDT
            // 
            this.colSDT.Text = "SĐT";
            this.colSDT.Width = 110;
            // 
            // colUsername
            // 
            this.colUsername.Text = "Username";
            this.colUsername.Width = 100;
            // 
            // colSoDu
            // 
            this.colSoDu.Text = "Số dư";
            this.colSoDu.Width = 100;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng thái";
            this.colTrangThai.Width = 90;
            // 
            // cardUser
            // 
            this.cardUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cardUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardUser.Controls.Add(this.lblCardTitle);
            this.cardUser.Controls.Add(this.lblCardName);
            this.cardUser.Controls.Add(this.lblCardInfo);
            this.cardUser.Controls.Add(this.lblCardBalanceTitle);
            this.cardUser.Controls.Add(this.lblCardBalance);
            this.cardUser.Controls.Add(this.lblCardRegDate);
            this.cardUser.Controls.Add(this.lblCardPin);
            this.cardUser.Depth = 0;
            this.cardUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardUser.Location = new System.Drawing.Point(539, 130);
            this.cardUser.Margin = new System.Windows.Forms.Padding(14);
            this.cardUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardUser.Name = "cardUser";
            this.cardUser.Padding = new System.Windows.Forms.Padding(14);
            this.cardUser.Size = new System.Drawing.Size(361, 160);
            this.cardUser.TabIndex = 2;
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardTitle.ForeColor = System.Drawing.Color.White;
            this.lblCardTitle.Location = new System.Drawing.Point(17, 14);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(143, 19);
            this.lblCardTitle.TabIndex = 0;
            this.lblCardTitle.Text = "TÀI KHOẢN HỘI VIÊN";
            // 
            // lblCardName
            // 
            this.lblCardName.AutoSize = true;
            this.lblCardName.BackColor = System.Drawing.Color.Transparent;
            this.lblCardName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardName.ForeColor = System.Drawing.Color.White;
            this.lblCardName.Location = new System.Drawing.Point(17, 33);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.Size = new System.Drawing.Size(190, 25);
            this.lblCardName.TabIndex = 1;
            this.lblCardName.Text = "GAMEZONE · pqhuy";
            // 
            // lblCardInfo
            // 
            this.lblCardInfo.AutoSize = true;
            this.lblCardInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCardInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCardInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCardInfo.Location = new System.Drawing.Point(17, 56);
            this.lblCardInfo.Name = "lblCardInfo";
            this.lblCardInfo.Size = new System.Drawing.Size(209, 19);
            this.lblCardInfo.TabIndex = 2;
            this.lblCardInfo.Text = "Phạm Quốc Huy · 0912 345 678";
            // 
            // lblCardBalanceTitle
            // 
            this.lblCardBalanceTitle.AutoSize = true;
            this.lblCardBalanceTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCardBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCardBalanceTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCardBalanceTitle.Location = new System.Drawing.Point(17, 82);
            this.lblCardBalanceTitle.Name = "lblCardBalanceTitle";
            this.lblCardBalanceTitle.Size = new System.Drawing.Size(58, 19);
            this.lblCardBalanceTitle.TabIndex = 3;
            this.lblCardBalanceTitle.Text = "Số dư ví";
            // 
            // lblCardBalance
            // 
            this.lblCardBalance.AutoSize = true;
            this.lblCardBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblCardBalance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCardBalance.ForeColor = System.Drawing.Color.White;
            this.lblCardBalance.Location = new System.Drawing.Point(97, 82);
            this.lblCardBalance.Name = "lblCardBalance";
            this.lblCardBalance.Size = new System.Drawing.Size(120, 32);
            this.lblCardBalance.TabIndex = 4;
            this.lblCardBalance.Text = "150,000đ";
            // 
            // lblCardRegDate
            // 
            this.lblCardRegDate.AutoSize = true;
            this.lblCardRegDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCardRegDate.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblCardRegDate.ForeColor = System.Drawing.Color.White;
            this.lblCardRegDate.Location = new System.Drawing.Point(17, 132);
            this.lblCardRegDate.Name = "lblCardRegDate";
            this.lblCardRegDate.Size = new System.Drawing.Size(128, 17);
            this.lblCardRegDate.TabIndex = 5;
            this.lblCardRegDate.Text = "Đăng ký: 01/01/2024";
            // 
            // lblCardPin
            // 
            this.lblCardPin.AutoSize = true;
            this.lblCardPin.BackColor = System.Drawing.Color.Transparent;
            this.lblCardPin.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblCardPin.ForeColor = System.Drawing.Color.White;
            this.lblCardPin.Location = new System.Drawing.Point(125, 132);
            this.lblCardPin.Name = "lblCardPin";
            this.lblCardPin.Size = new System.Drawing.Size(55, 17);
            this.lblCardPin.TabIndex = 6;
            this.lblCardPin.Text = "PIN: ****";
            // 
            // cardNapTien
            // 
            this.cardNapTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cardNapTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardNapTien.Controls.Add(this.materialLabel2);
            this.cardNapTien.Controls.Add(this.txtMoney);
            this.cardNapTien.Controls.Add(this.txtNote);
            this.cardNapTien.Controls.Add(this.btnNapTien);
            this.cardNapTien.Depth = 0;
            this.cardNapTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardNapTien.Location = new System.Drawing.Point(539, 310);
            this.cardNapTien.Margin = new System.Windows.Forms.Padding(14);
            this.cardNapTien.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardNapTien.Name = "cardNapTien";
            this.cardNapTien.Padding = new System.Windows.Forms.Padding(14);
            this.cardNapTien.Size = new System.Drawing.Size(361, 215);
            this.cardNapTien.TabIndex = 3;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(17, 14);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(106, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Nạp tiền vào ví";
            // 
            // txtMoney
            // 
            this.txtMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoney.AnimateReadOnly = false;
            this.txtMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMoney.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMoney.Depth = 0;
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMoney.HideSelection = true;
            this.txtMoney.Hint = "Số tiền (VNĐ)";
            this.txtMoney.LeadingIcon = null;
            this.txtMoney.Location = new System.Drawing.Point(15, 35);
            this.txtMoney.MaxLength = 50;
            this.txtMoney.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.PasswordChar = '\0';
            this.txtMoney.PrefixSuffixText = null;
            this.txtMoney.ReadOnly = false;
            this.txtMoney.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMoney.SelectedText = "";
            this.txtMoney.SelectionLength = 0;
            this.txtMoney.SelectionStart = 0;
            this.txtMoney.ShortcutsEnabled = true;
            this.txtMoney.Size = new System.Drawing.Size(331, 48);
            this.txtMoney.TabIndex = 0;
            this.txtMoney.TabStop = false;
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMoney.TrailingIcon = null;
            this.txtMoney.UseSystemPasswordChar = false;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.AnimateReadOnly = false;
            this.txtNote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNote.Depth = 0;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNote.HideSelection = true;
            this.txtNote.Hint = "Ghi chú";
            this.txtNote.LeadingIcon = null;
            this.txtNote.Location = new System.Drawing.Point(15, 95);
            this.txtNote.MaxLength = 50;
            this.txtNote.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.PrefixSuffixText = null;
            this.txtNote.ReadOnly = false;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNote.SelectedText = "";
            this.txtNote.SelectionLength = 0;
            this.txtNote.SelectionStart = 0;
            this.txtNote.ShortcutsEnabled = true;
            this.txtNote.Size = new System.Drawing.Size(331, 48);
            this.txtNote.TabIndex = 1;
            this.txtNote.TabStop = false;
            this.txtNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNote.TrailingIcon = null;
            this.txtNote.UseSystemPasswordChar = false;
            // 
            // btnNapTien
            // 
            this.btnNapTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNapTien.AutoSize = false;
            this.btnNapTien.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNapTien.BackColor = System.Drawing.Color.Green;
            this.btnNapTien.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNapTien.Depth = 0;
            this.btnNapTien.HighEmphasis = true;
            this.btnNapTien.Icon = null;
            this.btnNapTien.Location = new System.Drawing.Point(15, 155);
            this.btnNapTien.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNapTien.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNapTien.Name = "btnNapTien";
            this.btnNapTien.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNapTien.Size = new System.Drawing.Size(331, 40);
            this.btnNapTien.TabIndex = 2;
            this.btnNapTien.Text = "NẠP TIỀN";
            this.btnNapTien.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNapTien.UseAccentColor = false;
            this.btnNapTien.UseVisualStyleBackColor = false;
            // 
            // cardHistory
            // 
            this.cardHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardHistory.Controls.Add(this.materialLabel1);
            this.cardHistory.Controls.Add(this.mlvHistory);
            this.cardHistory.Depth = 0;
            this.cardHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardHistory.Location = new System.Drawing.Point(20, 545);
            this.cardHistory.Margin = new System.Windows.Forms.Padding(14);
            this.cardHistory.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardHistory.Name = "cardHistory";
            this.cardHistory.Padding = new System.Windows.Forms.Padding(14);
            this.cardHistory.Size = new System.Drawing.Size(880, 155);
            this.cardHistory.TabIndex = 4;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(17, 14);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(184, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Lịch sử giao dịch gần đây";
            // 
            // mlvHistory
            // 
            this.mlvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mlvHistory.AutoSizeTable = false;
            this.mlvHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mlvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLoai,
            this.colMoTa,
            this.colSoTien,
            this.colNgay});
            this.mlvHistory.Depth = 0;
            this.mlvHistory.FullRowSelect = true;
            this.mlvHistory.HideSelection = false;
            this.mlvHistory.Location = new System.Drawing.Point(15, 40);
            this.mlvHistory.MinimumSize = new System.Drawing.Size(200, 80);
            this.mlvHistory.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mlvHistory.MouseState = MaterialSkin.MouseState.OUT;
            this.mlvHistory.Name = "mlvHistory";
            this.mlvHistory.OwnerDraw = true;
            this.mlvHistory.Size = new System.Drawing.Size(848, 105);
            this.mlvHistory.TabIndex = 0;
            this.mlvHistory.UseCompatibleStateImageBehavior = false;
            this.mlvHistory.View = System.Windows.Forms.View.Details;
            // 
            // colLoai
            // 
            this.colLoai.Text = "Loại";
            this.colLoai.Width = 70;
            // 
            // colMoTa
            // 
            this.colMoTa.Text = "Mô tả";
            this.colMoTa.Width = 90;
            // 
            // colSoTien
            // 
            this.colSoTien.Text = "Số tiền";
            this.colSoTien.Width = 70;
            // 
            // colNgay
            // 
            this.colNgay.Text = "Ngày";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 720);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.mlvHoiVien);
            this.Controls.Add(this.cardUser);
            this.Controls.Add(this.cardNapTien);
            this.Controls.Add(this.cardHistory);
            this.MinimumSize = new System.Drawing.Size(920, 720);
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hội viên";
            this.panelTop.ResumeLayout(false);
            this.cardUser.ResumeLayout(false);
            this.cardUser.PerformLayout();
            this.cardNapTien.ResumeLayout(false);
            this.cardNapTien.PerformLayout();
            this.cardHistory.ResumeLayout(false);
            this.cardHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private MaterialSkin.Controls.MaterialButton btnRegister;
        private MaterialSkin.Controls.MaterialTextBox2 txtSearch;
        private MaterialSkin.Controls.MaterialListView mlvHoiVien;
        private MaterialSkin.Controls.MaterialCard cardUser;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblCardName;
        private System.Windows.Forms.Label lblCardInfo;
        private System.Windows.Forms.Label lblCardBalanceTitle;
        private System.Windows.Forms.Label lblCardBalance;
        private System.Windows.Forms.Label lblCardRegDate;
        private System.Windows.Forms.Label lblCardPin;
        private MaterialSkin.Controls.MaterialCard cardNapTien;
        private MaterialSkin.Controls.MaterialTextBox2 txtMoney;
        private MaterialSkin.Controls.MaterialTextBox2 txtNote;
        private MaterialSkin.Controls.MaterialButton btnNapTien;
        private MaterialSkin.Controls.MaterialCard cardHistory;
        private MaterialSkin.Controls.MaterialListView mlvHistory;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ColumnHeader colHoTen;
        private System.Windows.Forms.ColumnHeader colSDT;
        private System.Windows.Forms.ColumnHeader colUsername;
        private System.Windows.Forms.ColumnHeader colSoDu;
        private System.Windows.Forms.ColumnHeader colTrangThai;

        private System.Windows.Forms.ColumnHeader colLoai;
        private System.Windows.Forms.ColumnHeader colMoTa;
        private System.Windows.Forms.ColumnHeader colSoTien;
        private System.Windows.Forms.ColumnHeader colNgay;
    }
}