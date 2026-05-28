namespace QuanLyCuaHangGame.GUI
{
    partial class frmService
    {
        private System.ComponentModel.IContainer components = null;

        // ── Toolbar ───────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.TableLayoutPanel tblToolbar;
        private System.Windows.Forms.FlowLayoutPanel flpToolbarLeft;
        private System.Windows.Forms.FlowLayoutPanel flpToolbarRight;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnEdit;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private System.Windows.Forms.Label lblCategoryFilter;
        private MaterialSkin.Controls.MaterialComboBox cboCategoryFilter;
        private MaterialSkin.Controls.MaterialTextBox txtSearch;

        // ── Body (Left + Right) ───────────────────────────────────────
        private System.Windows.Forms.TableLayoutPanel tblBody;

        // ── Left panel – ListView ─────────────────────────────────────
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ListView lvServices;

        // ── Right panel – Detail Card ─────────────────────────────────
        private System.Windows.Forms.Panel pnlRight;
        private MaterialSkin.Controls.MaterialCard cardDetails;
        private System.Windows.Forms.TableLayoutPanel tblCard;
        private MaterialSkin.Controls.MaterialLabel lblFormTitle;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialComboBox cboCategory;
        private MaterialSkin.Controls.MaterialTextBox txtPrice;
        private MaterialSkin.Controls.MaterialCheckbox chkAvailable;
        private System.Windows.Forms.TableLayoutPanel tblButtons;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;

        // ── Status bar ────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Label lblStatusTotal;
        private System.Windows.Forms.Label lblStatusDrink;
        private System.Windows.Forms.Label lblStatusFood;
        private System.Windows.Forms.Label lblStatusGame;
        private System.Windows.Forms.Label lblStatusOut;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.tblToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.flpToolbarLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnEdit = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.cboCategoryFilter = new MaterialSkin.Controls.MaterialComboBox();
            this.flpToolbarRight = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.tblBody = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lvServices = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAvail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.cardDetails = new MaterialSkin.Controls.MaterialCard();
            this.tblCard = new System.Windows.Forms.TableLayoutPanel();
            this.lblFormTitle = new MaterialSkin.Controls.MaterialLabel();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.cboCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.txtPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.chkAvailable = new MaterialSkin.Controls.MaterialCheckbox();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatusTotal = new System.Windows.Forms.Label();
            this.lblStatusDrink = new System.Windows.Forms.Label();
            this.lblStatusFood = new System.Windows.Forms.Label();
            this.lblStatusGame = new System.Windows.Forms.Label();
            this.lblStatusOut = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            this.tblToolbar.SuspendLayout();
            this.flpToolbarLeft.SuspendLayout();
            this.flpToolbarRight.SuspendLayout();
            this.tblBody.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.cardDetails.SuspendLayout();
            this.tblCard.SuspendLayout();
            this.tblButtons.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.flpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.tblToolbar);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(5, 107);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(5);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1704, 83);
            this.pnlToolbar.TabIndex = 1;
            // 
            // tblToolbar
            // 
            this.tblToolbar.ColumnCount = 2;
            this.tblToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblToolbar.Controls.Add(this.flpToolbarLeft, 0, 0);
            this.tblToolbar.Controls.Add(this.flpToolbarRight, 1, 0);
            this.tblToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblToolbar.Location = new System.Drawing.Point(0, 0);
            this.tblToolbar.Margin = new System.Windows.Forms.Padding(5);
            this.tblToolbar.Name = "tblToolbar";
            this.tblToolbar.Padding = new System.Windows.Forms.Padding(14, 7, 14, 7);
            this.tblToolbar.RowCount = 1;
            this.tblToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblToolbar.Size = new System.Drawing.Size(1704, 83);
            this.tblToolbar.TabIndex = 0;
            // 
            // flpToolbarLeft
            // 
            this.flpToolbarLeft.AutoSize = true;
            this.flpToolbarLeft.Controls.Add(this.btnAdd);
            this.flpToolbarLeft.Controls.Add(this.btnEdit);
            this.flpToolbarLeft.Controls.Add(this.btnDelete);
            this.flpToolbarLeft.Controls.Add(this.lblCategoryFilter);
            this.flpToolbarLeft.Controls.Add(this.cboCategoryFilter);
            this.flpToolbarLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToolbarLeft.Location = new System.Drawing.Point(19, 12);
            this.flpToolbarLeft.Margin = new System.Windows.Forms.Padding(5);
            this.flpToolbarLeft.Name = "flpToolbarLeft";
            this.flpToolbarLeft.Size = new System.Drawing.Size(549, 59);
            this.flpToolbarLeft.TabIndex = 0;
            this.flpToolbarLeft.WrapContents = false;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdd.Depth = 0;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(0, 13);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 13, 7, 0);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdd.Size = new System.Drawing.Size(74, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+ Thêm";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdd.UseAccentColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEdit.Depth = 0;
            this.btnEdit.HighEmphasis = true;
            this.btnEdit.Icon = null;
            this.btnEdit.Location = new System.Drawing.Point(81, 13);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 13, 7, 0);
            this.btnEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEdit.Size = new System.Drawing.Size(64, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnEdit.UseAccentColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDelete.Depth = 0;
            this.btnDelete.HighEmphasis = true;
            this.btnDelete.Icon = null;
            this.btnDelete.Location = new System.Drawing.Point(152, 13);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 13, 27, 0);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(64, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnDelete.UseAccentColor = false;
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.AutoSize = true;
            this.lblCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoryFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblCategoryFilter.Location = new System.Drawing.Point(243, 30);
            this.lblCategoryFilter.Margin = new System.Windows.Forms.Padding(0, 30, 7, 0);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(79, 20);
            this.lblCategoryFilter.TabIndex = 3;
            this.lblCategoryFilter.Text = "Danh mục:";
            // 
            // cboCategoryFilter
            // 
            this.cboCategoryFilter.AutoResize = false;
            this.cboCategoryFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboCategoryFilter.Depth = 0;
            this.cboCategoryFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboCategoryFilter.DropDownHeight = 174;
            this.cboCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoryFilter.DropDownWidth = 121;
            this.cboCategoryFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboCategoryFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboCategoryFilter.IntegralHeight = false;
            this.cboCategoryFilter.ItemHeight = 43;
            this.cboCategoryFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Đồ uống",
            "Đồ ăn",
            "Game",
            "Khác"});
            this.cboCategoryFilter.Location = new System.Drawing.Point(329, 13);
            this.cboCategoryFilter.Margin = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.cboCategoryFilter.MaxDropDownItems = 4;
            this.cboCategoryFilter.MouseState = MaterialSkin.MouseState.OUT;
            this.cboCategoryFilter.Name = "cboCategoryFilter";
            this.cboCategoryFilter.Size = new System.Drawing.Size(220, 49);
            this.cboCategoryFilter.StartIndex = 0;
            this.cboCategoryFilter.TabIndex = 4;
            // 
            // flpToolbarRight
            // 
            this.flpToolbarRight.Controls.Add(this.txtSearch);
            this.flpToolbarRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToolbarRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpToolbarRight.Location = new System.Drawing.Point(578, 12);
            this.flpToolbarRight.Margin = new System.Windows.Forms.Padding(5);
            this.flpToolbarRight.Name = "flpToolbarRight";
            this.flpToolbarRight.Size = new System.Drawing.Size(1107, 59);
            this.flpToolbarRight.TabIndex = 1;
            this.flpToolbarRight.WrapContents = false;
            // 
            // txtSearch
            // 
            this.txtSearch.AnimateReadOnly = false;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.Hint = "Tìm dịch vụ...";
            this.txtSearch.LeadingIcon = null;
            this.txtSearch.Location = new System.Drawing.Point(730, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(377, 50);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "";
            this.txtSearch.TrailingIcon = null;
            // 
            // tblBody
            // 
            this.tblBody.ColumnCount = 2;
            this.tblBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblBody.Controls.Add(this.pnlLeft, 0, 0);
            this.tblBody.Controls.Add(this.pnlRight, 1, 0);
            this.tblBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBody.Location = new System.Drawing.Point(5, 190);
            this.tblBody.Margin = new System.Windows.Forms.Padding(5);
            this.tblBody.Name = "tblBody";
            this.tblBody.RowCount = 1;
            this.tblBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBody.Size = new System.Drawing.Size(1704, 778);
            this.tblBody.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lvServices);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(17, 13, 10, 13);
            this.pnlLeft.Size = new System.Drawing.Size(937, 778);
            this.pnlLeft.TabIndex = 0;
            // 
            // lvServices
            // 
            this.lvServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colCat,
            this.colPrice,
            this.colAvail});
            this.lvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvServices.FullRowSelect = true;
            this.lvServices.GridLines = true;
            this.lvServices.HideSelection = false;
            this.lvServices.Location = new System.Drawing.Point(17, 13);
            this.lvServices.Margin = new System.Windows.Forms.Padding(5);
            this.lvServices.Name = "lvServices";
            this.lvServices.Size = new System.Drawing.Size(910, 752);
            this.lvServices.TabIndex = 0;
            this.lvServices.UseCompatibleStateImageBehavior = false;
            this.lvServices.OwnerDraw = true;
            this.lvServices.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Tên dịch vụ";
            this.colName.Width = 139;
            // 
            // colCat
            // 
            this.colCat.Text = "Danh mục";
            this.colCat.Width = 110;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Giá";
            this.colPrice.Width = 100;
            // 
            // colAvail
            // 
            this.colAvail.Text = "Có sẵn";
            this.colAvail.Width = 85;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.cardDetails);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(937, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10, 13, 17, 13);
            this.pnlRight.Size = new System.Drawing.Size(767, 778);
            this.pnlRight.TabIndex = 1;
            // 
            // cardDetails
            // 
            this.cardDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardDetails.Controls.Add(this.tblCard);
            this.cardDetails.Depth = 0;
            this.cardDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardDetails.Location = new System.Drawing.Point(10, 13);
            this.cardDetails.Margin = new System.Windows.Forms.Padding(24, 23, 24, 23);
            this.cardDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardDetails.Name = "cardDetails";
            this.cardDetails.Padding = new System.Windows.Forms.Padding(27, 20, 27, 27);
            this.cardDetails.Size = new System.Drawing.Size(740, 752);
            this.cardDetails.TabIndex = 0;
            // 
            // tblCard
            // 
            this.tblCard.ColumnCount = 1;
            this.tblCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCard.Controls.Add(this.lblFormTitle, 0, 0);
            this.tblCard.Controls.Add(this.txtName, 0, 1);
            this.tblCard.Controls.Add(this.cboCategory, 0, 2);
            this.tblCard.Controls.Add(this.txtPrice, 0, 3);
            this.tblCard.Controls.Add(this.chkAvailable, 0, 4);
            this.tblCard.Controls.Add(this.tblButtons, 0, 5);
            this.tblCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCard.Location = new System.Drawing.Point(27, 20);
            this.tblCard.Margin = new System.Windows.Forms.Padding(5);
            this.tblCard.Name = "tblCard";
            this.tblCard.Padding = new System.Windows.Forms.Padding(7);
            this.tblCard.RowCount = 6;
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCard.Size = new System.Drawing.Size(686, 705);
            this.tblCard.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Depth = 0;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFormTitle.Location = new System.Drawing.Point(7, 7);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 13);
            this.lblFormTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(672, 38);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Thêm / Sửa dịch vụ";
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Depth = 0;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Hint = "Tên dịch vụ";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(7, 58);
            this.txtName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.txtName.MaxLength = 50;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(672, 50);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "";
            this.txtName.TrailingIcon = null;
            // 
            // cboCategory
            // 
            this.cboCategory.AutoResize = false;
            this.cboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboCategory.Depth = 0;
            this.cboCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboCategory.DropDownHeight = 174;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.DropDownWidth = 121;
            this.cboCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboCategory.Hint = "Danh mục";
            this.cboCategory.IntegralHeight = false;
            this.cboCategory.ItemHeight = 43;
            this.cboCategory.Items.AddRange(new object[] {
            "Đồ uống",
            "Đồ ăn",
            "Game",
            "Khác"});
            this.cboCategory.Location = new System.Drawing.Point(7, 115);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.cboCategory.MaxDropDownItems = 4;
            this.cboCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(672, 49);
            this.cboCategory.StartIndex = 0;
            this.cboCategory.TabIndex = 2;
            // 
            // txtPrice
            // 
            this.txtPrice.AnimateReadOnly = false;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Depth = 0;
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrice.Hint = "Giá bán (VNĐ)";
            this.txtPrice.LeadingIcon = null;
            this.txtPrice.Location = new System.Drawing.Point(7, 171);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(672, 50);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Text = "";
            this.txtPrice.TrailingIcon = null;
            // 
            // chkAvailable
            // 
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Checked = true;
            this.chkAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAvailable.Depth = 0;
            this.chkAvailable.Location = new System.Drawing.Point(7, 228);
            this.chkAvailable.Margin = new System.Windows.Forms.Padding(0);
            this.chkAvailable.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkAvailable.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.ReadOnly = false;
            this.chkAvailable.Ripple = true;
            this.chkAvailable.Size = new System.Drawing.Size(124, 37);
            this.chkAvailable.TabIndex = 4;
            this.chkAvailable.Text = "Đang có sẵn";
            // 
            // tblButtons
            // 
            this.tblButtons.ColumnCount = 2;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblButtons.Controls.Add(this.btnSave, 0, 0);
            this.tblButtons.Controls.Add(this.btnCancel, 1, 0);
            this.tblButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblButtons.Location = new System.Drawing.Point(7, 620);
            this.tblButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblButtons.Size = new System.Drawing.Size(672, 78);
            this.tblButtons.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(0, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 7, 14, 0);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(594, 71);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "LƯU";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(608, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancel.UseAccentColor = false;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.pnlStatus.Controls.Add(this.flpStatus);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(5, 968);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1704, 60);
            this.pnlStatus.TabIndex = 2;
            // 
            // flpStatus
            // 
            this.flpStatus.Controls.Add(this.lblStatusTotal);
            this.flpStatus.Controls.Add(this.lblStatusDrink);
            this.flpStatus.Controls.Add(this.lblStatusFood);
            this.flpStatus.Controls.Add(this.lblStatusGame);
            this.flpStatus.Controls.Add(this.lblStatusOut);
            this.flpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpStatus.Location = new System.Drawing.Point(0, 0);
            this.flpStatus.Margin = new System.Windows.Forms.Padding(5);
            this.flpStatus.Name = "flpStatus";
            this.flpStatus.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.flpStatus.Size = new System.Drawing.Size(1704, 60);
            this.flpStatus.TabIndex = 0;
            this.flpStatus.WrapContents = false;
            // 
            // lblStatusTotal
            // 
            this.lblStatusTotal.Location = new System.Drawing.Point(26, 0);
            this.lblStatusTotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatusTotal.Name = "lblStatusTotal";
            this.lblStatusTotal.Size = new System.Drawing.Size(171, 38);
            this.lblStatusTotal.TabIndex = 0;
            // 
            // lblStatusDrink
            // 
            this.lblStatusDrink.Location = new System.Drawing.Point(207, 0);
            this.lblStatusDrink.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatusDrink.Name = "lblStatusDrink";
            this.lblStatusDrink.Size = new System.Drawing.Size(171, 38);
            this.lblStatusDrink.TabIndex = 1;
            // 
            // lblStatusFood
            // 
            this.lblStatusFood.Location = new System.Drawing.Point(388, 0);
            this.lblStatusFood.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatusFood.Name = "lblStatusFood";
            this.lblStatusFood.Size = new System.Drawing.Size(171, 38);
            this.lblStatusFood.TabIndex = 2;
            // 
            // lblStatusGame
            // 
            this.lblStatusGame.Location = new System.Drawing.Point(569, 0);
            this.lblStatusGame.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatusGame.Name = "lblStatusGame";
            this.lblStatusGame.Size = new System.Drawing.Size(171, 38);
            this.lblStatusGame.TabIndex = 3;
            // 
            // lblStatusOut
            // 
            this.lblStatusOut.Location = new System.Drawing.Point(750, 0);
            this.lblStatusOut.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatusOut.Name = "lblStatusOut";
            this.lblStatusOut.Size = new System.Drawing.Size(171, 38);
            this.lblStatusOut.TabIndex = 4;
            // 
            // frmService
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1714, 1033);
            this.Controls.Add(this.tblBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlStatus);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "frmService";
            this.Padding = new System.Windows.Forms.Padding(5, 107, 5, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý dịch vụ (Đồ ăn, nước uống)";
            this.pnlToolbar.ResumeLayout(false);
            this.tblToolbar.ResumeLayout(false);
            this.tblToolbar.PerformLayout();
            this.flpToolbarLeft.ResumeLayout(false);
            this.flpToolbarLeft.PerformLayout();
            this.flpToolbarRight.ResumeLayout(false);
            this.tblBody.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.cardDetails.ResumeLayout(false);
            this.tblCard.ResumeLayout(false);
            this.tblCard.PerformLayout();
            this.tblButtons.ResumeLayout(false);
            this.tblButtons.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.flpStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colCat;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colAvail;


    }
}