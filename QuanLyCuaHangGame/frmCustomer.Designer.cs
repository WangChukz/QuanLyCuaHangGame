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
            this.btnNapTienTop = new MaterialSkin.Controls.MaterialButton();
            this.btnHistoryTop = new MaterialSkin.Controls.MaterialButton();
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.cardHoiVien = new MaterialSkin.Controls.MaterialCard();
            this.mlvHoiVien = new System.Windows.Forms.ListView();
            this.colHoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoDu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cardUser = new System.Windows.Forms.Panel();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblCardName = new System.Windows.Forms.Label();
            this.lblCardInfo = new System.Windows.Forms.Label();
            this.lblCardBalanceTitle = new System.Windows.Forms.Label();
            this.lblCardBalance = new System.Windows.Forms.Label();
            this.lblCardRegDate = new System.Windows.Forms.Label();
            this.lblCardPin = new System.Windows.Forms.Label();
            this.cardNapTien = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtMoney = new MaterialSkin.Controls.MaterialTextBox();
            this.txtNote = new MaterialSkin.Controls.MaterialTextBox();
            this.btnNapTien = new MaterialSkin.Controls.MaterialButton();
            this.cardHistory = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.mlvHistory = new System.Windows.Forms.ListView();
            this.colLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMoTa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelTop.SuspendLayout();
            this.cardHoiVien.SuspendLayout();
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
            this.panelTop.Controls.Add(this.btnNapTienTop);
            this.panelTop.Controls.Add(this.btnHistoryTop);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Location = new System.Drawing.Point(20, 114);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1192, 69);
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
            this.btnRegister.Size = new System.Drawing.Size(189, 46);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "👤 ĐĂNG KÝ HỘI VIÊN";
            this.btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRegister.UseAccentColor = false;
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnNapTienTop
            // 
            this.btnNapTienTop.AutoSize = false;
            this.btnNapTienTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNapTienTop.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNapTienTop.Depth = 0;
            this.btnNapTienTop.HighEmphasis = true;
            this.btnNapTienTop.Icon = null;
            this.btnNapTienTop.Location = new System.Drawing.Point(203, 5);
            this.btnNapTienTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNapTienTop.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNapTienTop.Name = "btnNapTienTop";
            this.btnNapTienTop.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNapTienTop.Size = new System.Drawing.Size(160, 46);
            this.btnNapTienTop.TabIndex = 3;
            this.btnNapTienTop.Text = "💸 NẠP TIỀN";
            this.btnNapTienTop.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNapTienTop.UseAccentColor = false;
            this.btnNapTienTop.UseVisualStyleBackColor = true;
            // 
            // btnHistoryTop
            // 
            this.btnHistoryTop.AutoSize = false;
            this.btnHistoryTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHistoryTop.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHistoryTop.Depth = 0;
            this.btnHistoryTop.HighEmphasis = true;
            this.btnHistoryTop.Icon = null;
            this.btnHistoryTop.Location = new System.Drawing.Point(376, 5);
            this.btnHistoryTop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHistoryTop.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHistoryTop.Name = "btnHistoryTop";
            this.btnHistoryTop.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHistoryTop.Size = new System.Drawing.Size(207, 46);
            this.btnHistoryTop.TabIndex = 4;
            this.btnHistoryTop.Text = "📅 LỊCH SỬ GD";
            this.btnHistoryTop.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHistoryTop.UseAccentColor = false;
            this.btnHistoryTop.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AnimateReadOnly = false;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.Hint = "Tìm theo tên, SĐT, username";
            this.txtSearch.LeadingIcon = null;
            this.txtSearch.Location = new System.Drawing.Point(589, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(600, 50);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "";
            this.txtSearch.TrailingIcon = null;
            // 
            // cardHoiVien
            // 
            this.cardHoiVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardHoiVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardHoiVien.Controls.Add(this.mlvHoiVien);
            this.cardHoiVien.Depth = 0;
            this.cardHoiVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardHoiVien.Location = new System.Drawing.Point(20, 194);
            this.cardHoiVien.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardHoiVien.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardHoiVien.Name = "cardHoiVien";
            this.cardHoiVien.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardHoiVien.Size = new System.Drawing.Size(813, 242);
            this.cardHoiVien.TabIndex = 1;
            // 
            // mlvHoiVien
            // 
            this.mlvHoiVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mlvHoiVien.BackColor = System.Drawing.Color.MintCream;
            this.mlvHoiVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvHoiVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHoTen,
            this.colSDT,
            this.colUsername,
            this.colSoDu,
            this.colTrangThai});
            this.mlvHoiVien.FullRowSelect = true;
            this.mlvHoiVien.HideSelection = false;
            this.mlvHoiVien.Location = new System.Drawing.Point(13, 14);
            this.mlvHoiVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mlvHoiVien.MinimumSize = new System.Drawing.Size(200, 100);
            this.mlvHoiVien.Name = "mlvHoiVien";
            this.mlvHoiVien.OwnerDraw = true;
            this.mlvHoiVien.Size = new System.Drawing.Size(827, 215);
            this.mlvHoiVien.TabIndex = 1;
            this.mlvHoiVien.UseCompatibleStateImageBehavior = false;
            this.mlvHoiVien.View = System.Windows.Forms.View.Details;
            // 
            // colHoTen
            // 
            this.colHoTen.Text = "Họ tên";
            this.colHoTen.Width = 170;
            // 
            // colSDT
            // 
            this.colSDT.Text = "SĐT";
            this.colSDT.Width = 110;
            // 
            // colUsername
            // 
            this.colUsername.Text = "Username";
            this.colUsername.Width = 110;
            // 
            // colSoDu
            // 
            this.colSoDu.Text = "Số dư";
            this.colSoDu.Width = 110;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng thái";
            this.colTrangThai.Width = 110;
            // 
            // cardUser
            // 
            this.cardUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cardUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.cardUser.Controls.Add(this.lblCardTitle);
            this.cardUser.Controls.Add(this.lblCardName);
            this.cardUser.Controls.Add(this.lblCardInfo);
            this.cardUser.Controls.Add(this.lblCardBalanceTitle);
            this.cardUser.Controls.Add(this.lblCardBalance);
            this.cardUser.Controls.Add(this.lblCardRegDate);
            this.cardUser.Controls.Add(this.lblCardPin);
            this.cardUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardUser.Location = new System.Drawing.Point(848, 194);
            this.cardUser.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardUser.Name = "cardUser";
            this.cardUser.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardUser.Size = new System.Drawing.Size(364, 254);
            this.cardUser.TabIndex = 2;
            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCardTitle.Location = new System.Drawing.Point(17, 14);
            this.lblCardTitle.Name = "lblCardTitle";
            this.lblCardTitle.Size = new System.Drawing.Size(162, 20);
            this.lblCardTitle.TabIndex = 0;
            this.lblCardTitle.Text = "TÀI KHOẢN HỘI VIÊN";
            // 
            // lblCardName
            // 
            this.lblCardName.AutoSize = true;
            this.lblCardName.BackColor = System.Drawing.Color.Transparent;
            this.lblCardName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCardName.ForeColor = System.Drawing.Color.White;
            this.lblCardName.Location = new System.Drawing.Point(13, 38);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.Size = new System.Drawing.Size(242, 32);
            this.lblCardName.TabIndex = 1;
            this.lblCardName.Text = "GAMEZONE · pqhuy";
            // 
            // lblCardInfo
            // 
            this.lblCardInfo.AutoSize = true;
            this.lblCardInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCardInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCardInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCardInfo.Location = new System.Drawing.Point(17, 74);
            this.lblCardInfo.Name = "lblCardInfo";
            this.lblCardInfo.Size = new System.Drawing.Size(272, 25);
            this.lblCardInfo.TabIndex = 2;
            this.lblCardInfo.Text = "Phạm Quốc Huy · 0912 345 678";
            // 
            // lblCardBalanceTitle
            // 
            this.lblCardBalanceTitle.AutoSize = true;
            this.lblCardBalanceTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCardBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCardBalanceTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCardBalanceTitle.Location = new System.Drawing.Point(19, 103);
            this.lblCardBalanceTitle.Name = "lblCardBalanceTitle";
            this.lblCardBalanceTitle.Size = new System.Drawing.Size(79, 25);
            this.lblCardBalanceTitle.TabIndex = 3;
            this.lblCardBalanceTitle.Text = "Số dư ví";
            // 
            // lblCardBalance
            // 
            this.lblCardBalance.AutoSize = true;
            this.lblCardBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblCardBalance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardBalance.ForeColor = System.Drawing.Color.White;
            this.lblCardBalance.Location = new System.Drawing.Point(5, 124);
            this.lblCardBalance.Name = "lblCardBalance";
            this.lblCardBalance.Size = new System.Drawing.Size(181, 50);
            this.lblCardBalance.TabIndex = 4;
            this.lblCardBalance.Text = "150,000đ";
            // 
            // lblCardRegDate
            // 
            this.lblCardRegDate.AutoSize = true;
            this.lblCardRegDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCardRegDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardRegDate.ForeColor = System.Drawing.Color.White;
            this.lblCardRegDate.Location = new System.Drawing.Point(19, 185);
            this.lblCardRegDate.Name = "lblCardRegDate";
            this.lblCardRegDate.Size = new System.Drawing.Size(160, 20);
            this.lblCardRegDate.TabIndex = 5;
            this.lblCardRegDate.Text = "Đăng ký: 01/01/2024";
            // 
            // lblCardPin
            // 
            this.lblCardPin.AutoSize = true;
            this.lblCardPin.BackColor = System.Drawing.Color.Transparent;
            this.lblCardPin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardPin.ForeColor = System.Drawing.Color.White;
            this.lblCardPin.Location = new System.Drawing.Point(20, 220);
            this.lblCardPin.Name = "lblCardPin";
            this.lblCardPin.Size = new System.Drawing.Size(71, 20);
            this.lblCardPin.TabIndex = 6;
            this.lblCardPin.Text = "PIN: ****";
            // 
            // cardNapTien
            // 
            this.cardNapTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardNapTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardNapTien.Controls.Add(this.materialLabel2);
            this.cardNapTien.Controls.Add(this.txtMoney);
            this.cardNapTien.Controls.Add(this.txtNote);
            this.cardNapTien.Controls.Add(this.btnNapTien);
            this.cardNapTien.Depth = 0;
            this.cardNapTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardNapTien.Location = new System.Drawing.Point(848, 453);
            this.cardNapTien.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardNapTien.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardNapTien.Name = "cardNapTien";
            this.cardNapTien.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardNapTien.Size = new System.Drawing.Size(368, 229);
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
            this.txtMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoney.Depth = 0;
            this.txtMoney.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMoney.Hint = "Số tiền (VNĐ)";
            this.txtMoney.LeadingIcon = null;
            this.txtMoney.Location = new System.Drawing.Point(15, 42);
            this.txtMoney.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMoney.MaxLength = 50;
            this.txtMoney.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMoney.Multiline = false;
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(337, 50);
            this.txtMoney.TabIndex = 0;
            this.txtMoney.Text = "";
            this.txtMoney.TrailingIcon = null;
            this.txtMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoney_KeyPress);
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.AnimateReadOnly = false;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Depth = 0;
            this.txtNote.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNote.Hint = "Ghi chú";
            this.txtNote.LeadingIcon = null;
            this.txtNote.Location = new System.Drawing.Point(15, 108);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNote.MaxLength = 50;
            this.txtNote.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNote.Multiline = false;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(337, 50);
            this.txtNote.TabIndex = 1;
            this.txtNote.Text = "";
            this.txtNote.TrailingIcon = null;
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
            this.btnNapTien.Location = new System.Drawing.Point(15, 167);
            this.btnNapTien.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNapTien.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNapTien.Name = "btnNapTien";
            this.btnNapTien.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNapTien.Size = new System.Drawing.Size(337, 47);
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
            this.cardHistory.Location = new System.Drawing.Point(20, 453);
            this.cardHistory.Margin = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardHistory.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardHistory.Name = "cardHistory";
            this.cardHistory.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.cardHistory.Size = new System.Drawing.Size(813, 229);
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
            this.mlvHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mlvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLoai,
            this.colMoTa,
            this.colSoTien,
            this.colNgay});
            this.mlvHistory.FullRowSelect = true;
            this.mlvHistory.HideSelection = false;
            this.mlvHistory.Location = new System.Drawing.Point(15, 39);
            this.mlvHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mlvHistory.MinimumSize = new System.Drawing.Size(200, 80);
            this.mlvHistory.Name = "mlvHistory";
            this.mlvHistory.OwnerDraw = true;
            this.mlvHistory.Size = new System.Drawing.Size(825, 212);
            this.mlvHistory.TabIndex = 0;
            this.mlvHistory.UseCompatibleStateImageBehavior = false;
            this.mlvHistory.View = System.Windows.Forms.View.Details;
            // 
            // colLoai
            // 
            this.colLoai.Text = "Loại";
            this.colLoai.Width = 116;
            // 
            // colMoTa
            // 
            this.colMoTa.Text = "Mô tả";
            this.colMoTa.Width = 220;
            // 
            // colSoTien
            // 
            this.colSoTien.Text = "Số tiền";
            this.colSoTien.Width = 116;
            // 
            // colNgay
            // 
            this.colNgay.Text = "Ngày";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 720);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.cardHoiVien);
            this.Controls.Add(this.cardUser);
            this.Controls.Add(this.cardNapTien);
            this.Controls.Add(this.cardHistory);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(920, 720);
            this.Name = "frmCustomer";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hội viên";
            this.panelTop.ResumeLayout(false);
            this.cardHoiVien.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialButton btnNapTienTop;
        private MaterialSkin.Controls.MaterialButton btnHistoryTop;
        private MaterialSkin.Controls.MaterialTextBox txtSearch;
        private MaterialSkin.Controls.MaterialCard cardHoiVien;
        private System.Windows.Forms.ListView mlvHoiVien;
        private System.Windows.Forms.Panel cardUser;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblCardName;
        private System.Windows.Forms.Label lblCardInfo;
        private System.Windows.Forms.Label lblCardBalanceTitle;
        private System.Windows.Forms.Label lblCardBalance;
        private System.Windows.Forms.Label lblCardRegDate;
        private System.Windows.Forms.Label lblCardPin;
        private MaterialSkin.Controls.MaterialCard cardNapTien;
        private MaterialSkin.Controls.MaterialTextBox txtMoney;
        private MaterialSkin.Controls.MaterialTextBox txtNote;
        private MaterialSkin.Controls.MaterialButton btnNapTien;
        private MaterialSkin.Controls.MaterialCard cardHistory;
        private System.Windows.Forms.ListView mlvHistory;
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
