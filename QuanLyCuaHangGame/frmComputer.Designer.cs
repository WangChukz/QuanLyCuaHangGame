namespace QuanLyCuaHangGame
{
    partial class frmComputer
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
            this.pnlRoleToggle = new System.Windows.Forms.Panel();
            this.lblRoleToggle = new System.Windows.Forms.Label();
            this.btnRoleAdmin = new MaterialSkin.Controls.MaterialButton();
            this.btnRoleStaff = new MaterialSkin.Controls.MaterialButton();
            this.mainTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.lvAdmin = new System.Windows.Forms.ListView();
            this.colAdminCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdminRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdminClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdminConfig = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdminStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdminPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cardAdminDetails = new MaterialSkin.Controls.MaterialCard();
            this.lblAdminDetailsTitle = new MaterialSkin.Controls.MaterialLabel();
            this.txtAdminCode = new MaterialSkin.Controls.MaterialTextBox();
            this.cboAdminRoom = new MaterialSkin.Controls.MaterialComboBox();
            this.cboAdminTypeClass = new MaterialSkin.Controls.MaterialComboBox();
            this.txtAdminCPU = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAdminGPU = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAdminRAM = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAdminDisk = new MaterialSkin.Controls.MaterialTextBox();
            this.cboAdminStatusEdit = new MaterialSkin.Controls.MaterialComboBox();
            this.grpAdminPrice = new System.Windows.Forms.GroupBox();
            this.txtAdminPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.lblAdminPriceDate = new MaterialSkin.Controls.MaterialLabel();
            this.dtpAdminPriceDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdminSave = new MaterialSkin.Controls.MaterialButton();
            this.btnAdminCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnAdminDeleteMachine = new System.Windows.Forms.Button();
            this.pnlAdminToolbar = new System.Windows.Forms.Panel();
            this.btnAdminAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnAdminEditAll = new MaterialSkin.Controls.MaterialButton();
            this.btnAdminDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnAdminManageRoom = new MaterialSkin.Controls.MaterialButton();
            this.btnAdminUpdatePrice = new MaterialSkin.Controls.MaterialButton();
            this.lblAdminStatus = new MaterialSkin.Controls.MaterialLabel();
            this.cboAdminStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.lblAdminClass = new MaterialSkin.Controls.MaterialLabel();
            this.cboAdminType = new MaterialSkin.Controls.MaterialComboBox();
            this.txtAdminSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.tabStaff = new System.Windows.Forms.TabPage();
            this.lvStaff = new System.Windows.Forms.ListView();
            this.colStaffCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStaffRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStaffClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStaffStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStaffState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cardStaffDetails = new MaterialSkin.Controls.MaterialCard();
            this.lblStaffDetailsTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblStaffMachineInfo = new MaterialSkin.Controls.MaterialLabel();
            this.lblStaffRoomInfo = new MaterialSkin.Controls.MaterialLabel();
            this.lblStaffConfigInfo = new MaterialSkin.Controls.MaterialLabel();
            this.cboStaffStatusEdit = new MaterialSkin.Controls.MaterialComboBox();
            this.txtStaffNotes = new MaterialSkin.Controls.MaterialTextBox();
            this.btnStaffSaveStatus = new System.Windows.Forms.Button();
            this.btnStaffCancel = new MaterialSkin.Controls.MaterialButton();
            this.lblStaffRestrictions = new System.Windows.Forms.Label();
            this.pnlStaffNotice = new System.Windows.Forms.Panel();
            this.lblStaffNotice = new System.Windows.Forms.Label();
            this.pnlStaffToolbar = new System.Windows.Forms.Panel();
            this.btnStaffUpdateStatus = new MaterialSkin.Controls.MaterialButton();
            this.lblStaffStatus = new MaterialSkin.Controls.MaterialLabel();
            this.cboStaffStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.lblStaffRoom = new MaterialSkin.Controls.MaterialLabel();
            this.cboStaffRoom = new MaterialSkin.Controls.MaterialComboBox();
            this.txtStaffSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.pnlRoleToggle.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.cardAdminDetails.SuspendLayout();
            this.grpAdminPrice.SuspendLayout();
            this.pnlAdminToolbar.SuspendLayout();
            this.tabStaff.SuspendLayout();
            this.cardStaffDetails.SuspendLayout();
            this.pnlStaffNotice.SuspendLayout();
            this.pnlStaffToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoleToggle
            // 
            this.pnlRoleToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.pnlRoleToggle.Controls.Add(this.lblRoleToggle);
            this.pnlRoleToggle.Controls.Add(this.btnRoleAdmin);
            this.pnlRoleToggle.Controls.Add(this.btnRoleStaff);
            this.pnlRoleToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleToggle.Location = new System.Drawing.Point(0, 0);
            this.pnlRoleToggle.Name = "pnlRoleToggle";
            this.pnlRoleToggle.Size = new System.Drawing.Size(1086, 50);
            this.pnlRoleToggle.TabIndex = 0;
            // 
            // lblRoleToggle
            // 
            this.lblRoleToggle.AutoSize = true;
            this.lblRoleToggle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleToggle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblRoleToggle.Location = new System.Drawing.Point(20, 16);
            this.lblRoleToggle.Name = "lblRoleToggle";
            this.lblRoleToggle.Size = new System.Drawing.Size(116, 17);
            this.lblRoleToggle.TabIndex = 0;
            this.lblRoleToggle.Text = "Xem theo vai trò:";
            // 
            // btnRoleAdmin
            // 
            this.btnRoleAdmin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRoleAdmin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRoleAdmin.Depth = 0;
            this.btnRoleAdmin.HighEmphasis = true;
            this.btnRoleAdmin.Icon = null;
            this.btnRoleAdmin.Location = new System.Drawing.Point(150, 7);
            this.btnRoleAdmin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRoleAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRoleAdmin.Name = "btnRoleAdmin";
            this.btnRoleAdmin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRoleAdmin.Size = new System.Drawing.Size(187, 36);
            this.btnRoleAdmin.TabIndex = 1;
            this.btnRoleAdmin.Text = "Admin - Chủ cửa hàng";
            this.btnRoleAdmin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRoleAdmin.UseAccentColor = false;
            this.btnRoleAdmin.UseVisualStyleBackColor = true;
            // 
            // btnRoleStaff
            // 
            this.btnRoleStaff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRoleStaff.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRoleStaff.Depth = 0;
            this.btnRoleStaff.HighEmphasis = true;
            this.btnRoleStaff.Icon = null;
            this.btnRoleStaff.Location = new System.Drawing.Point(330, 7);
            this.btnRoleStaff.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRoleStaff.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRoleStaff.Name = "btnRoleStaff";
            this.btnRoleStaff.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRoleStaff.Size = new System.Drawing.Size(244, 36);
            this.btnRoleStaff.TabIndex = 2;
            this.btnRoleStaff.Text = "Staff - Nhân viên phòng máy";
            this.btnRoleStaff.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRoleStaff.UseAccentColor = false;
            this.btnRoleStaff.UseVisualStyleBackColor = true;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabAdmin);
            this.mainTabControl.Controls.Add(this.tabStaff);
            this.mainTabControl.Depth = 0;
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 50);
            this.mainTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1086, 699);
            this.mainTabControl.TabIndex = 1;
            // 
            // tabAdmin
            // 
            this.tabAdmin.AutoScroll = true;
            this.tabAdmin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabAdmin.Controls.Add(this.lvAdmin);
            this.tabAdmin.Controls.Add(this.cardAdminDetails);
            this.tabAdmin.Controls.Add(this.pnlAdminToolbar);
            this.tabAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(1078, 673);
            this.tabAdmin.TabIndex = 0;
            this.tabAdmin.Text = "Admin";
            // 
            // lvAdmin
            // 
            this.lvAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvAdmin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAdminCode,
            this.colAdminRoom,
            this.colAdminClass,
            this.colAdminConfig,
            this.colAdminStatus,
            this.colAdminPrice});
            this.lvAdmin.FullRowSelect = true;
            this.lvAdmin.HideSelection = false;
            this.lvAdmin.Location = new System.Drawing.Point(10, 65);
            this.lvAdmin.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvAdmin.Name = "lvAdmin";
            this.lvAdmin.OwnerDraw = true;
            this.lvAdmin.Size = new System.Drawing.Size(500, 580);
            this.lvAdmin.TabIndex = 1;
            this.lvAdmin.UseCompatibleStateImageBehavior = false;
            this.lvAdmin.View = System.Windows.Forms.View.Details;
            this.lvAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // colAdminCode
            // 
            this.colAdminCode.Text = "Mã máy";
            this.colAdminCode.Width = 70;
            // 
            // colAdminRoom
            // 
            this.colAdminRoom.Text = "Phòng";
            this.colAdminRoom.Width = 70;
            // 
            // colAdminClass
            // 
            this.colAdminClass.Text = "Hạng";
            this.colAdminClass.Width = 70;
            // 
            // colAdminConfig
            // 
            this.colAdminConfig.Text = "Cấu hình";
            this.colAdminConfig.Width = 120;
            // 
            // colAdminStatus
            // 
            this.colAdminStatus.Text = "Tình trạng";
            this.colAdminStatus.Width = 80;
            // 
            // colAdminPrice
            // 
            this.colAdminPrice.Text = "Giá/h";
            this.colAdminPrice.Width = 80;
            // 
            // cardAdminDetails
            // 
            this.cardAdminDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardAdminDetails.Controls.Add(this.lblAdminDetailsTitle);
            this.cardAdminDetails.Controls.Add(this.txtAdminCode);
            this.cardAdminDetails.Controls.Add(this.cboAdminRoom);
            this.cardAdminDetails.Controls.Add(this.cboAdminTypeClass);
            this.cardAdminDetails.Controls.Add(this.txtAdminCPU);
            this.cardAdminDetails.Controls.Add(this.txtAdminGPU);
            this.cardAdminDetails.Controls.Add(this.txtAdminRAM);
            this.cardAdminDetails.Controls.Add(this.txtAdminDisk);
            this.cardAdminDetails.Controls.Add(this.cboAdminStatusEdit);
            this.cardAdminDetails.Controls.Add(this.grpAdminPrice);
            this.cardAdminDetails.Controls.Add(this.btnAdminSave);
            this.cardAdminDetails.Controls.Add(this.btnAdminCancel);
            this.cardAdminDetails.Controls.Add(this.btnAdminDeleteMachine);
            this.cardAdminDetails.Depth = 0;
            this.cardAdminDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardAdminDetails.Location = new System.Drawing.Point(520, 65);
            this.cardAdminDetails.Margin = new System.Windows.Forms.Padding(14);
            this.cardAdminDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardAdminDetails.Name = "cardAdminDetails";
            this.cardAdminDetails.Padding = new System.Windows.Forms.Padding(14);
            this.cardAdminDetails.Size = new System.Drawing.Size(540, 460);
            this.cardAdminDetails.TabIndex = 2;
            this.cardAdminDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // lblAdminDetailsTitle
            // 
            this.lblAdminDetailsTitle.AutoSize = true;
            this.lblAdminDetailsTitle.Depth = 0;
            this.lblAdminDetailsTitle.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAdminDetailsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblAdminDetailsTitle.Location = new System.Drawing.Point(17, 10);
            this.lblAdminDetailsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAdminDetailsTitle.Name = "lblAdminDetailsTitle";
            this.lblAdminDetailsTitle.Size = new System.Drawing.Size(230, 29);
            this.lblAdminDetailsTitle.TabIndex = 0;
            this.lblAdminDetailsTitle.Text = "Chi tiết đầy đủ - PC01";
            // 
            // txtAdminCode
            // 
            this.txtAdminCode.AnimateReadOnly = false;
            this.txtAdminCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdminCode.Depth = 0;
            this.txtAdminCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAdminCode.Hint = "Mã máy";
            this.txtAdminCode.LeadingIcon = null;
            this.txtAdminCode.Location = new System.Drawing.Point(17, 40);
            this.txtAdminCode.MaxLength = 50;
            this.txtAdminCode.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminCode.Multiline = false;
            this.txtAdminCode.Name = "txtAdminCode";
            this.txtAdminCode.Size = new System.Drawing.Size(506, 50);
            this.txtAdminCode.TabIndex = 1;
            this.txtAdminCode.Text = "PC01";
            this.txtAdminCode.TrailingIcon = null;
            // 
            // cboAdminRoom
            // 
            this.cboAdminRoom.AutoResize = false;
            this.cboAdminRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAdminRoom.Depth = 0;
            this.cboAdminRoom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboAdminRoom.DropDownHeight = 174;
            this.cboAdminRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdminRoom.DropDownWidth = 121;
            this.cboAdminRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdminRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboAdminRoom.FormattingEnabled = true;
            this.cboAdminRoom.Hint = "Phòng";
            this.cboAdminRoom.IntegralHeight = false;
            this.cboAdminRoom.ItemHeight = 43;
            this.cboAdminRoom.Items.AddRange(new object[] {
            "Phòng A",
            "Phòng B"});
            this.cboAdminRoom.Location = new System.Drawing.Point(17, 95);
            this.cboAdminRoom.MaxDropDownItems = 4;
            this.cboAdminRoom.MouseState = MaterialSkin.MouseState.OUT;
            this.cboAdminRoom.Name = "cboAdminRoom";
            this.cboAdminRoom.Size = new System.Drawing.Size(240, 49);
            this.cboAdminRoom.StartIndex = 0;
            this.cboAdminRoom.TabIndex = 2;
            // 
            // cboAdminTypeClass
            // 
            this.cboAdminTypeClass.AutoResize = false;
            this.cboAdminTypeClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAdminTypeClass.Depth = 0;
            this.cboAdminTypeClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboAdminTypeClass.DropDownHeight = 174;
            this.cboAdminTypeClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdminTypeClass.DropDownWidth = 121;
            this.cboAdminTypeClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdminTypeClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboAdminTypeClass.FormattingEnabled = true;
            this.cboAdminTypeClass.Hint = "Hạng máy";
            this.cboAdminTypeClass.IntegralHeight = false;
            this.cboAdminTypeClass.ItemHeight = 43;
            this.cboAdminTypeClass.Items.AddRange(new object[] {
            "VIP",
            "Standard"});
            this.cboAdminTypeClass.Location = new System.Drawing.Point(277, 95);
            this.cboAdminTypeClass.MaxDropDownItems = 4;
            this.cboAdminTypeClass.MouseState = MaterialSkin.MouseState.OUT;
            this.cboAdminTypeClass.Name = "cboAdminTypeClass";
            this.cboAdminTypeClass.Size = new System.Drawing.Size(240, 49);
            this.cboAdminTypeClass.StartIndex = 0;
            this.cboAdminTypeClass.TabIndex = 3;
            // 
            // txtAdminCPU
            // 
            this.txtAdminCPU.AnimateReadOnly = false;
            this.txtAdminCPU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdminCPU.Depth = 0;
            this.txtAdminCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAdminCPU.Hint = "CPU";
            this.txtAdminCPU.LeadingIcon = null;
            this.txtAdminCPU.Location = new System.Drawing.Point(17, 148);
            this.txtAdminCPU.MaxLength = 50;
            this.txtAdminCPU.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminCPU.Multiline = false;
            this.txtAdminCPU.Name = "txtAdminCPU";
            this.txtAdminCPU.Size = new System.Drawing.Size(506, 50);
            this.txtAdminCPU.TabIndex = 4;
            this.txtAdminCPU.Text = "Intel Core i9-13900K";
            this.txtAdminCPU.TrailingIcon = null;
            // 
            // txtAdminGPU
            // 
            this.txtAdminGPU.AnimateReadOnly = false;
            this.txtAdminGPU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdminGPU.Depth = 0;
            this.txtAdminGPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAdminGPU.Hint = "GPU";
            this.txtAdminGPU.LeadingIcon = null;
            this.txtAdminGPU.Location = new System.Drawing.Point(17, 202);
            this.txtAdminGPU.MaxLength = 50;
            this.txtAdminGPU.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminGPU.Multiline = false;
            this.txtAdminGPU.Name = "txtAdminGPU";
            this.txtAdminGPU.Size = new System.Drawing.Size(240, 50);
            this.txtAdminGPU.TabIndex = 5;
            this.txtAdminGPU.Text = "NVIDIA RTX 4070";
            this.txtAdminGPU.TrailingIcon = null;
            // 
            // txtAdminRAM
            // 
            this.txtAdminRAM.AnimateReadOnly = false;
            this.txtAdminRAM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdminRAM.Depth = 0;
            this.txtAdminRAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAdminRAM.Hint = "RAM";
            this.txtAdminRAM.LeadingIcon = null;
            this.txtAdminRAM.Location = new System.Drawing.Point(277, 202);
            this.txtAdminRAM.MaxLength = 50;
            this.txtAdminRAM.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminRAM.Multiline = false;
            this.txtAdminRAM.Name = "txtAdminRAM";
            this.txtAdminRAM.Size = new System.Drawing.Size(240, 50);
            this.txtAdminRAM.TabIndex = 6;
            this.txtAdminRAM.Text = "32GB DDR5";
            this.txtAdminRAM.TrailingIcon = null;
            // 
            // txtAdminDisk
            // 
            this.txtAdminDisk.AnimateReadOnly = false;
            this.txtAdminDisk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdminDisk.Depth = 0;
            this.txtAdminDisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAdminDisk.Hint = "Ổ cứng";
            this.txtAdminDisk.LeadingIcon = null;
            this.txtAdminDisk.Location = new System.Drawing.Point(17, 256);
            this.txtAdminDisk.MaxLength = 50;
            this.txtAdminDisk.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminDisk.Multiline = false;
            this.txtAdminDisk.Name = "txtAdminDisk";
            this.txtAdminDisk.Size = new System.Drawing.Size(240, 50);
            this.txtAdminDisk.TabIndex = 7;
            this.txtAdminDisk.Text = "1TB NVMe SSD";
            this.txtAdminDisk.TrailingIcon = null;
            // 
            // cboAdminStatusEdit
            // 
            this.cboAdminStatusEdit.AutoResize = false;
            this.cboAdminStatusEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAdminStatusEdit.Depth = 0;
            this.cboAdminStatusEdit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboAdminStatusEdit.DropDownHeight = 174;
            this.cboAdminStatusEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdminStatusEdit.DropDownWidth = 121;
            this.cboAdminStatusEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdminStatusEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboAdminStatusEdit.FormattingEnabled = true;
            this.cboAdminStatusEdit.Hint = "Tình trạng";
            this.cboAdminStatusEdit.IntegralHeight = false;
            this.cboAdminStatusEdit.ItemHeight = 43;
            this.cboAdminStatusEdit.Items.AddRange(new object[] {
            "Tốt",
            "Hỏng",
            "Bảo trì"});
            this.cboAdminStatusEdit.Location = new System.Drawing.Point(277, 256);
            this.cboAdminStatusEdit.MaxDropDownItems = 4;
            this.cboAdminStatusEdit.MouseState = MaterialSkin.MouseState.OUT;
            this.cboAdminStatusEdit.Name = "cboAdminStatusEdit";
            this.cboAdminStatusEdit.Size = new System.Drawing.Size(240, 49);
            this.cboAdminStatusEdit.StartIndex = 0;
            this.cboAdminStatusEdit.TabIndex = 8;
            // 
            // grpAdminPrice
            // 
            this.grpAdminPrice.Controls.Add(this.txtAdminPrice);
            this.grpAdminPrice.Controls.Add(this.lblAdminPriceDate);
            this.grpAdminPrice.Controls.Add(this.dtpAdminPriceDate);
            this.grpAdminPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAdminPrice.ForeColor = System.Drawing.Color.Gray;
            this.grpAdminPrice.Location = new System.Drawing.Point(17, 310);
            this.grpAdminPrice.Name = "grpAdminPrice";
            this.grpAdminPrice.Size = new System.Drawing.Size(506, 90);
            this.grpAdminPrice.TabIndex = 9;
            this.grpAdminPrice.TabStop = false;
            this.grpAdminPrice.Text = "Cập nhật giá thuê (ComputerPrices)";
            // 
            // txtAdminPrice
            // 
            this.txtAdminPrice.AnimateReadOnly = false;
            this.txtAdminPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdminPrice.Depth = 0;
            this.txtAdminPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAdminPrice.Hint = "Giá mới (đ/giờ)";
            this.txtAdminPrice.LeadingIcon = null;
            this.txtAdminPrice.Location = new System.Drawing.Point(20, 30);
            this.txtAdminPrice.MaxLength = 50;
            this.txtAdminPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminPrice.Multiline = false;
            this.txtAdminPrice.Name = "txtAdminPrice";
            this.txtAdminPrice.Size = new System.Drawing.Size(200, 50);
            this.txtAdminPrice.TabIndex = 0;
            this.txtAdminPrice.Text = "30000";
            this.txtAdminPrice.TrailingIcon = null;
            // 
            // lblAdminPriceDate
            // 
            this.lblAdminPriceDate.AutoSize = true;
            this.lblAdminPriceDate.Depth = 0;
            this.lblAdminPriceDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAdminPriceDate.Location = new System.Drawing.Point(260, 30);
            this.lblAdminPriceDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAdminPriceDate.Name = "lblAdminPriceDate";
            this.lblAdminPriceDate.Size = new System.Drawing.Size(118, 19);
            this.lblAdminPriceDate.TabIndex = 1;
            this.lblAdminPriceDate.Text = "Áp dụng từ ngày";
            // 
            // dtpAdminPriceDate
            // 
            this.dtpAdminPriceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdminPriceDate.Location = new System.Drawing.Point(260, 50);
            this.dtpAdminPriceDate.Name = "dtpAdminPriceDate";
            this.dtpAdminPriceDate.Size = new System.Drawing.Size(250, 25);
            this.dtpAdminPriceDate.TabIndex = 2;
            // 
            // btnAdminSave
            // 
            this.btnAdminSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdminSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdminSave.Depth = 0;
            this.btnAdminSave.HighEmphasis = true;
            this.btnAdminSave.Icon = null;
            this.btnAdminSave.Location = new System.Drawing.Point(17, 410);
            this.btnAdminSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdminSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdminSave.Name = "btnAdminSave";
            this.btnAdminSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdminSave.Size = new System.Drawing.Size(64, 36);
            this.btnAdminSave.TabIndex = 10;
            this.btnAdminSave.Text = "LƯU";
            this.btnAdminSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdminSave.UseAccentColor = false;
            this.btnAdminSave.UseVisualStyleBackColor = true;
            // 
            // btnAdminCancel
            // 
            this.btnAdminCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdminCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdminCancel.Depth = 0;
            this.btnAdminCancel.HighEmphasis = true;
            this.btnAdminCancel.Icon = null;
            this.btnAdminCancel.Location = new System.Drawing.Point(280, 410);
            this.btnAdminCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdminCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdminCancel.Name = "btnAdminCancel";
            this.btnAdminCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdminCancel.Size = new System.Drawing.Size(64, 36);
            this.btnAdminCancel.TabIndex = 11;
            this.btnAdminCancel.Text = "HỦY";
            this.btnAdminCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnAdminCancel.UseAccentColor = false;
            this.btnAdminCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdminDeleteMachine
            // 
            this.btnAdminDeleteMachine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnAdminDeleteMachine.FlatAppearance.BorderSize = 0;
            this.btnAdminDeleteMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminDeleteMachine.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminDeleteMachine.ForeColor = System.Drawing.Color.White;
            this.btnAdminDeleteMachine.Location = new System.Drawing.Point(403, 410);
            this.btnAdminDeleteMachine.Name = "btnAdminDeleteMachine";
            this.btnAdminDeleteMachine.Size = new System.Drawing.Size(120, 36);
            this.btnAdminDeleteMachine.TabIndex = 12;
            this.btnAdminDeleteMachine.Text = "XÓA MÁY";
            this.btnAdminDeleteMachine.UseVisualStyleBackColor = false;
            // 
            // pnlAdminToolbar
            // 
            this.pnlAdminToolbar.BackColor = System.Drawing.Color.White;
            this.pnlAdminToolbar.Controls.Add(this.btnAdminAdd);
            this.pnlAdminToolbar.Controls.Add(this.btnAdminEditAll);
            this.pnlAdminToolbar.Controls.Add(this.btnAdminDelete);
            this.pnlAdminToolbar.Controls.Add(this.btnAdminManageRoom);
            this.pnlAdminToolbar.Controls.Add(this.btnAdminUpdatePrice);
            this.pnlAdminToolbar.Controls.Add(this.lblAdminStatus);
            this.pnlAdminToolbar.Controls.Add(this.cboAdminStatus);
            this.pnlAdminToolbar.Controls.Add(this.lblAdminClass);
            this.pnlAdminToolbar.Controls.Add(this.cboAdminType);
            this.pnlAdminToolbar.Controls.Add(this.txtAdminSearch);
            this.pnlAdminToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAdminToolbar.Location = new System.Drawing.Point(3, 3);
            this.pnlAdminToolbar.Name = "pnlAdminToolbar";
            this.pnlAdminToolbar.Size = new System.Drawing.Size(1072, 50);
            this.pnlAdminToolbar.TabIndex = 0;
            // 
            // btnAdminAdd
            // 
            this.btnAdminAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdminAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdminAdd.Depth = 0;
            this.btnAdminAdd.HighEmphasis = true;
            this.btnAdminAdd.Icon = null;
            this.btnAdminAdd.Location = new System.Drawing.Point(10, 7);
            this.btnAdminAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdminAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdminAdd.Name = "btnAdminAdd";
            this.btnAdminAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdminAdd.Size = new System.Drawing.Size(109, 36);
            this.btnAdminAdd.TabIndex = 0;
            this.btnAdminAdd.Text = "+ Thêm máy";
            this.btnAdminAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnAdminAdd.UseAccentColor = false;
            this.btnAdminAdd.UseVisualStyleBackColor = true;
            // 
            // btnAdminEditAll
            // 
            this.btnAdminEditAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdminEditAll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdminEditAll.Depth = 0;
            this.btnAdminEditAll.HighEmphasis = true;
            this.btnAdminEditAll.Icon = null;
            this.btnAdminEditAll.Location = new System.Drawing.Point(123, 7);
            this.btnAdminEditAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdminEditAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdminEditAll.Name = "btnAdminEditAll";
            this.btnAdminEditAll.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdminEditAll.Size = new System.Drawing.Size(116, 36);
            this.btnAdminEditAll.TabIndex = 1;
            this.btnAdminEditAll.Text = "Sửa toàn bộ";
            this.btnAdminEditAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnAdminEditAll.UseAccentColor = false;
            this.btnAdminEditAll.UseVisualStyleBackColor = true;
            // 
            // btnAdminDelete
            // 
            this.btnAdminDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdminDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdminDelete.Depth = 0;
            this.btnAdminDelete.HighEmphasis = true;
            this.btnAdminDelete.Icon = null;
            this.btnAdminDelete.Location = new System.Drawing.Point(243, 7);
            this.btnAdminDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdminDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdminDelete.Name = "btnAdminDelete";
            this.btnAdminDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdminDelete.Size = new System.Drawing.Size(64, 36);
            this.btnAdminDelete.TabIndex = 2;
            this.btnAdminDelete.Text = "Xóa";
            this.btnAdminDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnAdminDelete.UseAccentColor = false;
            this.btnAdminDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdminManageRoom
            // 
            this.btnAdminManageRoom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdminManageRoom.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdminManageRoom.Depth = 0;
            this.btnAdminManageRoom.HighEmphasis = true;
            this.btnAdminManageRoom.Icon = null;
            this.btnAdminManageRoom.Location = new System.Drawing.Point(311, 7);
            this.btnAdminManageRoom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdminManageRoom.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdminManageRoom.Name = "btnAdminManageRoom";
            this.btnAdminManageRoom.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdminManageRoom.Size = new System.Drawing.Size(136, 36);
            this.btnAdminManageRoom.TabIndex = 3;
            this.btnAdminManageRoom.Text = "Quản lý phòng";
            this.btnAdminManageRoom.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnAdminManageRoom.UseAccentColor = false;
            this.btnAdminManageRoom.UseVisualStyleBackColor = true;
            this.btnAdminManageRoom.Click += new System.EventHandler(this.btnAdminManageRoom_Click);
            // 
            // btnAdminUpdatePrice
            // 
            this.btnAdminUpdatePrice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdminUpdatePrice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdminUpdatePrice.Depth = 0;
            this.btnAdminUpdatePrice.HighEmphasis = true;
            this.btnAdminUpdatePrice.Icon = null;
            this.btnAdminUpdatePrice.Location = new System.Drawing.Point(451, 7);
            this.btnAdminUpdatePrice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdminUpdatePrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdminUpdatePrice.Name = "btnAdminUpdatePrice";
            this.btnAdminUpdatePrice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdminUpdatePrice.Size = new System.Drawing.Size(121, 36);
            this.btnAdminUpdatePrice.TabIndex = 4;
            this.btnAdminUpdatePrice.Text = "Cập nhật giá";
            this.btnAdminUpdatePrice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnAdminUpdatePrice.UseAccentColor = false;
            this.btnAdminUpdatePrice.UseVisualStyleBackColor = true;
            // 
            // lblAdminStatus
            // 
            this.lblAdminStatus.AutoSize = true;
            this.lblAdminStatus.Depth = 0;
            this.lblAdminStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAdminStatus.Location = new System.Drawing.Point(585, 16);
            this.lblAdminStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAdminStatus.Name = "lblAdminStatus";
            this.lblAdminStatus.Size = new System.Drawing.Size(78, 19);
            this.lblAdminStatus.TabIndex = 5;
            this.lblAdminStatus.Text = "Tình trạng:";
            // 
            // cboAdminStatus
            // 
            this.cboAdminStatus.AutoResize = false;
            this.cboAdminStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAdminStatus.Depth = 0;
            this.cboAdminStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboAdminStatus.DropDownHeight = 118;
            this.cboAdminStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdminStatus.DropDownWidth = 121;
            this.cboAdminStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdminStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboAdminStatus.FormattingEnabled = true;
            this.cboAdminStatus.IntegralHeight = false;
            this.cboAdminStatus.ItemHeight = 29;
            this.cboAdminStatus.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboAdminStatus.Location = new System.Drawing.Point(660, 7);
            this.cboAdminStatus.MaxDropDownItems = 4;
            this.cboAdminStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cboAdminStatus.Name = "cboAdminStatus";
            this.cboAdminStatus.Size = new System.Drawing.Size(90, 35);
            this.cboAdminStatus.StartIndex = 0;
            this.cboAdminStatus.TabIndex = 6;
            this.cboAdminStatus.UseTallSize = false;
            // 
            // lblAdminClass
            // 
            this.lblAdminClass.AutoSize = true;
            this.lblAdminClass.Depth = 0;
            this.lblAdminClass.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAdminClass.Location = new System.Drawing.Point(760, 16);
            this.lblAdminClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAdminClass.Name = "lblAdminClass";
            this.lblAdminClass.Size = new System.Drawing.Size(43, 19);
            this.lblAdminClass.TabIndex = 7;
            this.lblAdminClass.Text = "Hạng:";
            // 
            // cboAdminType
            // 
            this.cboAdminType.AutoResize = false;
            this.cboAdminType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAdminType.Depth = 0;
            this.cboAdminType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboAdminType.DropDownHeight = 118;
            this.cboAdminType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdminType.DropDownWidth = 121;
            this.cboAdminType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAdminType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboAdminType.FormattingEnabled = true;
            this.cboAdminType.IntegralHeight = false;
            this.cboAdminType.ItemHeight = 29;
            this.cboAdminType.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboAdminType.Location = new System.Drawing.Point(805, 7);
            this.cboAdminType.MaxDropDownItems = 4;
            this.cboAdminType.MouseState = MaterialSkin.MouseState.OUT;
            this.cboAdminType.Name = "cboAdminType";
            this.cboAdminType.Size = new System.Drawing.Size(90, 35);
            this.cboAdminType.StartIndex = 0;
            this.cboAdminType.TabIndex = 8;
            this.cboAdminType.UseTallSize = false;
            // 
            // txtAdminSearch
            // 
            this.txtAdminSearch.AnimateReadOnly = false;
            this.txtAdminSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdminSearch.Depth = 0;
            this.txtAdminSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAdminSearch.Hint = "Tìm mã máy, cấu hình...";
            this.txtAdminSearch.LeadingIcon = null;
            this.txtAdminSearch.Location = new System.Drawing.Point(905, 7);
            this.txtAdminSearch.MaxLength = 50;
            this.txtAdminSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAdminSearch.Multiline = false;
            this.txtAdminSearch.Name = "txtAdminSearch";
            this.txtAdminSearch.Size = new System.Drawing.Size(165, 36);
            this.txtAdminSearch.TabIndex = 9;
            this.txtAdminSearch.Text = "";
            this.txtAdminSearch.TrailingIcon = null;
            this.txtAdminSearch.UseTallSize = false;
            // 
            // tabStaff
            // 
            this.tabStaff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabStaff.Controls.Add(this.lvStaff);
            this.tabStaff.Controls.Add(this.cardStaffDetails);
            this.tabStaff.Controls.Add(this.pnlStaffNotice);
            this.tabStaff.Controls.Add(this.pnlStaffToolbar);
            this.tabStaff.Location = new System.Drawing.Point(4, 22);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Padding = new System.Windows.Forms.Padding(3);
            this.tabStaff.Size = new System.Drawing.Size(1192, 673);
            this.tabStaff.TabIndex = 1;
            this.tabStaff.Text = "Staff";
            // 
            // lvStaff
            // 
            this.lvStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvStaff.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStaffCode,
            this.colStaffRoom,
            this.colStaffClass,
            this.colStaffStatus,
            this.colStaffState});
            this.lvStaff.FullRowSelect = true;
            this.lvStaff.HideSelection = false;
            this.lvStaff.Location = new System.Drawing.Point(10, 120);
            this.lvStaff.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvStaff.Name = "lvStaff";
            this.lvStaff.OwnerDraw = true;
            this.lvStaff.Size = new System.Drawing.Size(500, 520);
            this.lvStaff.TabIndex = 3;
            this.lvStaff.UseCompatibleStateImageBehavior = false;
            this.lvStaff.View = System.Windows.Forms.View.Details;
            this.lvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // colStaffCode
            // 
            this.colStaffCode.Text = "Mã máy";
            this.colStaffCode.Width = 80;
            // 
            // colStaffRoom
            // 
            this.colStaffRoom.Text = "Phòng";
            this.colStaffRoom.Width = 80;
            // 
            // colStaffClass
            // 
            this.colStaffClass.Text = "Loại máy";
            this.colStaffClass.Width = 100;
            // 
            // colStaffStatus
            // 
            this.colStaffStatus.Text = "Tình trạng";
            this.colStaffStatus.Width = 120;
            // 
            // colStaffState
            // 
            this.colStaffState.Text = "Trạng thái";
            this.colStaffState.Width = 110;
            // 
            // cardStaffDetails
            // 
            this.cardStaffDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardStaffDetails.Controls.Add(this.lblStaffDetailsTitle);
            this.cardStaffDetails.Controls.Add(this.lblStaffMachineInfo);
            this.cardStaffDetails.Controls.Add(this.lblStaffRoomInfo);
            this.cardStaffDetails.Controls.Add(this.lblStaffConfigInfo);
            this.cardStaffDetails.Controls.Add(this.cboStaffStatusEdit);
            this.cardStaffDetails.Controls.Add(this.txtStaffNotes);
            this.cardStaffDetails.Controls.Add(this.btnStaffSaveStatus);
            this.cardStaffDetails.Controls.Add(this.btnStaffCancel);
            this.cardStaffDetails.Controls.Add(this.lblStaffRestrictions);
            this.cardStaffDetails.Depth = 0;
            this.cardStaffDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardStaffDetails.Location = new System.Drawing.Point(520, 120);
            this.cardStaffDetails.Margin = new System.Windows.Forms.Padding(14);
            this.cardStaffDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardStaffDetails.Name = "cardStaffDetails";
            this.cardStaffDetails.Padding = new System.Windows.Forms.Padding(14);
            this.cardStaffDetails.Size = new System.Drawing.Size(540, 395);
            this.cardStaffDetails.TabIndex = 4;
            this.cardStaffDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // lblStaffDetailsTitle
            // 
            this.lblStaffDetailsTitle.AutoSize = true;
            this.lblStaffDetailsTitle.Depth = 0;
            this.lblStaffDetailsTitle.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblStaffDetailsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblStaffDetailsTitle.Location = new System.Drawing.Point(17, 10);
            this.lblStaffDetailsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStaffDetailsTitle.Name = "lblStaffDetailsTitle";
            this.lblStaffDetailsTitle.Size = new System.Drawing.Size(279, 29);
            this.lblStaffDetailsTitle.TabIndex = 0;
            this.lblStaffDetailsTitle.Text = "Cập nhật tình trạng - PC07";
            // 
            // lblStaffMachineInfo
            // 
            this.lblStaffMachineInfo.AutoSize = true;
            this.lblStaffMachineInfo.Depth = 0;
            this.lblStaffMachineInfo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStaffMachineInfo.Location = new System.Drawing.Point(17, 42);
            this.lblStaffMachineInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStaffMachineInfo.Name = "lblStaffMachineInfo";
            this.lblStaffMachineInfo.Size = new System.Drawing.Size(155, 19);
            this.lblStaffMachineInfo.TabIndex = 1;
            this.lblStaffMachineInfo.Text = "Máy: PC07 - Standard";
            // 
            // lblStaffRoomInfo
            // 
            this.lblStaffRoomInfo.AutoSize = true;
            this.lblStaffRoomInfo.Depth = 0;
            this.lblStaffRoomInfo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStaffRoomInfo.Location = new System.Drawing.Point(17, 62);
            this.lblStaffRoomInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStaffRoomInfo.Name = "lblStaffRoomInfo";
            this.lblStaffRoomInfo.Size = new System.Drawing.Size(115, 19);
            this.lblStaffRoomInfo.TabIndex = 2;
            this.lblStaffRoomInfo.Text = "Phòng: Phòng A";
            // 
            // lblStaffConfigInfo
            // 
            this.lblStaffConfigInfo.AutoSize = true;
            this.lblStaffConfigInfo.Depth = 0;
            this.lblStaffConfigInfo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStaffConfigInfo.Location = new System.Drawing.Point(17, 82);
            this.lblStaffConfigInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStaffConfigInfo.Name = "lblStaffConfigInfo";
            this.lblStaffConfigInfo.Size = new System.Drawing.Size(224, 19);
            this.lblStaffConfigInfo.TabIndex = 3;
            this.lblStaffConfigInfo.Text = "Intel Core i5 / GTX 1660 / 16GB";
            // 
            // cboStaffStatusEdit
            // 
            this.cboStaffStatusEdit.AutoResize = false;
            this.cboStaffStatusEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboStaffStatusEdit.Depth = 0;
            this.cboStaffStatusEdit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStaffStatusEdit.DropDownHeight = 174;
            this.cboStaffStatusEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStaffStatusEdit.DropDownWidth = 121;
            this.cboStaffStatusEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboStaffStatusEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboStaffStatusEdit.FormattingEnabled = true;
            this.cboStaffStatusEdit.Hint = "Cập nhật tình trạng";
            this.cboStaffStatusEdit.IntegralHeight = false;
            this.cboStaffStatusEdit.ItemHeight = 43;
            this.cboStaffStatusEdit.Items.AddRange(new object[] {
            "Hỏng",
            "Đã sửa",
            "Tốt"});
            this.cboStaffStatusEdit.Location = new System.Drawing.Point(17, 106);
            this.cboStaffStatusEdit.MaxDropDownItems = 4;
            this.cboStaffStatusEdit.MouseState = MaterialSkin.MouseState.OUT;
            this.cboStaffStatusEdit.Name = "cboStaffStatusEdit";
            this.cboStaffStatusEdit.Size = new System.Drawing.Size(506, 49);
            this.cboStaffStatusEdit.StartIndex = 0;
            this.cboStaffStatusEdit.TabIndex = 4;
            // 
            // txtStaffNotes
            // 
            this.txtStaffNotes.AnimateReadOnly = false;
            this.txtStaffNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStaffNotes.Depth = 0;
            this.txtStaffNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtStaffNotes.Hint = "Ghi chú tình trạng";
            this.txtStaffNotes.LeadingIcon = null;
            this.txtStaffNotes.Location = new System.Drawing.Point(17, 160);
            this.txtStaffNotes.MaxLength = 500;
            this.txtStaffNotes.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStaffNotes.Multiline = false;
            this.txtStaffNotes.Name = "txtStaffNotes";
            this.txtStaffNotes.Size = new System.Drawing.Size(506, 50);
            this.txtStaffNotes.TabIndex = 5;
            this.txtStaffNotes.Text = "Màn hình bị sọc, cần thay";
            this.txtStaffNotes.TrailingIcon = null;
            // 
            // btnStaffSaveStatus
            // 
            this.btnStaffSaveStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnStaffSaveStatus.FlatAppearance.BorderSize = 0;
            this.btnStaffSaveStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffSaveStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffSaveStatus.ForeColor = System.Drawing.Color.White;
            this.btnStaffSaveStatus.Location = new System.Drawing.Point(17, 218);
            this.btnStaffSaveStatus.Name = "btnStaffSaveStatus";
            this.btnStaffSaveStatus.Size = new System.Drawing.Size(250, 40);
            this.btnStaffSaveStatus.TabIndex = 6;
            this.btnStaffSaveStatus.Text = "CẬP NHẬT TÌNH TRẠNG";
            this.btnStaffSaveStatus.UseVisualStyleBackColor = false;
            // 
            // btnStaffCancel
            // 
            this.btnStaffCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStaffCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStaffCancel.Depth = 0;
            this.btnStaffCancel.HighEmphasis = true;
            this.btnStaffCancel.Icon = null;
            this.btnStaffCancel.Location = new System.Drawing.Point(280, 218);
            this.btnStaffCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStaffCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStaffCancel.Name = "btnStaffCancel";
            this.btnStaffCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStaffCancel.Size = new System.Drawing.Size(64, 36);
            this.btnStaffCancel.TabIndex = 7;
            this.btnStaffCancel.Text = "HỦY";
            this.btnStaffCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnStaffCancel.UseAccentColor = false;
            this.btnStaffCancel.UseVisualStyleBackColor = true;
            // 
            // lblStaffRestrictions
            // 
            this.lblStaffRestrictions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffRestrictions.ForeColor = System.Drawing.Color.DimGray;
            this.lblStaffRestrictions.Location = new System.Drawing.Point(17, 264);
            this.lblStaffRestrictions.Name = "lblStaffRestrictions";
            this.lblStaffRestrictions.Size = new System.Drawing.Size(506, 105);
            this.lblStaffRestrictions.TabIndex = 8;
            this.lblStaffRestrictions.Text = "CÁC THAO TÁC BỊ GIỚI HẠN VỚI STAFF:\n- Sửa cấu hình CPU / GPU / RAM\n- Thay đổi hạn" +
    "g máy (VIP / Standard)\n- Cập nhật giá thuê\n- Thêm / Xóa phòng máy";
            // 
            // pnlStaffNotice
            // 
            this.pnlStaffNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlStaffNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStaffNotice.Controls.Add(this.lblStaffNotice);
            this.pnlStaffNotice.Location = new System.Drawing.Point(10, 65);
            this.pnlStaffNotice.Name = "pnlStaffNotice";
            this.pnlStaffNotice.Size = new System.Drawing.Size(1050, 40);
            this.pnlStaffNotice.TabIndex = 2;
            // 
            // lblStaffNotice
            // 
            this.lblStaffNotice.AutoSize = true;
            this.lblStaffNotice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffNotice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStaffNotice.Location = new System.Drawing.Point(10, 10);
            this.lblStaffNotice.Name = "lblStaffNotice";
            this.lblStaffNotice.Size = new System.Drawing.Size(759, 17);
            this.lblStaffNotice.TabIndex = 0;
            this.lblStaffNotice.Text = "Nhân viên có thể thêm, sửa, xoá, tìm kiếm máy theo tình trạng và loại phòng. Khôn" +
    "g được sửa cấu hình, hạng máy hoặc giá thuê.";
            // 
            // pnlStaffToolbar
            // 
            this.pnlStaffToolbar.BackColor = System.Drawing.Color.White;
            this.pnlStaffToolbar.Controls.Add(this.btnStaffUpdateStatus);
            this.pnlStaffToolbar.Controls.Add(this.lblStaffStatus);
            this.pnlStaffToolbar.Controls.Add(this.cboStaffStatus);
            this.pnlStaffToolbar.Controls.Add(this.lblStaffRoom);
            this.pnlStaffToolbar.Controls.Add(this.cboStaffRoom);
            this.pnlStaffToolbar.Controls.Add(this.txtStaffSearch);
            this.pnlStaffToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStaffToolbar.Location = new System.Drawing.Point(3, 3);
            this.pnlStaffToolbar.Name = "pnlStaffToolbar";
            this.pnlStaffToolbar.Size = new System.Drawing.Size(1186, 50);
            this.pnlStaffToolbar.TabIndex = 1;
            // 
            // btnStaffUpdateStatus
            // 
            this.btnStaffUpdateStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStaffUpdateStatus.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStaffUpdateStatus.Depth = 0;
            this.btnStaffUpdateStatus.HighEmphasis = true;
            this.btnStaffUpdateStatus.Icon = null;
            this.btnStaffUpdateStatus.Location = new System.Drawing.Point(10, 7);
            this.btnStaffUpdateStatus.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStaffUpdateStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStaffUpdateStatus.Name = "btnStaffUpdateStatus";
            this.btnStaffUpdateStatus.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStaffUpdateStatus.Size = new System.Drawing.Size(183, 36);
            this.btnStaffUpdateStatus.TabIndex = 0;
            this.btnStaffUpdateStatus.Text = "Cập nhật tình trạng";
            this.btnStaffUpdateStatus.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnStaffUpdateStatus.UseAccentColor = false;
            this.btnStaffUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // lblStaffStatus
            // 
            this.lblStaffStatus.AutoSize = true;
            this.lblStaffStatus.Depth = 0;
            this.lblStaffStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStaffStatus.Location = new System.Drawing.Point(200, 16);
            this.lblStaffStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStaffStatus.Name = "lblStaffStatus";
            this.lblStaffStatus.Size = new System.Drawing.Size(78, 19);
            this.lblStaffStatus.TabIndex = 5;
            this.lblStaffStatus.Text = "Tình trạng:";
            // 
            // cboStaffStatus
            // 
            this.cboStaffStatus.AutoResize = false;
            this.cboStaffStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboStaffStatus.Depth = 0;
            this.cboStaffStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStaffStatus.DropDownHeight = 118;
            this.cboStaffStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStaffStatus.DropDownWidth = 121;
            this.cboStaffStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboStaffStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboStaffStatus.FormattingEnabled = true;
            this.cboStaffStatus.IntegralHeight = false;
            this.cboStaffStatus.ItemHeight = 29;
            this.cboStaffStatus.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboStaffStatus.Location = new System.Drawing.Point(280, 7);
            this.cboStaffStatus.MaxDropDownItems = 4;
            this.cboStaffStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cboStaffStatus.Name = "cboStaffStatus";
            this.cboStaffStatus.Size = new System.Drawing.Size(120, 35);
            this.cboStaffStatus.StartIndex = 0;
            this.cboStaffStatus.TabIndex = 6;
            this.cboStaffStatus.UseTallSize = false;
            // 
            // lblStaffRoom
            // 
            this.lblStaffRoom.AutoSize = true;
            this.lblStaffRoom.Depth = 0;
            this.lblStaffRoom.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStaffRoom.Location = new System.Drawing.Point(420, 16);
            this.lblStaffRoom.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStaffRoom.Name = "lblStaffRoom";
            this.lblStaffRoom.Size = new System.Drawing.Size(51, 19);
            this.lblStaffRoom.TabIndex = 7;
            this.lblStaffRoom.Text = "Phòng:";
            // 
            // cboStaffRoom
            // 
            this.cboStaffRoom.AutoResize = false;
            this.cboStaffRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboStaffRoom.Depth = 0;
            this.cboStaffRoom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboStaffRoom.DropDownHeight = 118;
            this.cboStaffRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStaffRoom.DropDownWidth = 121;
            this.cboStaffRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboStaffRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboStaffRoom.FormattingEnabled = true;
            this.cboStaffRoom.IntegralHeight = false;
            this.cboStaffRoom.ItemHeight = 29;
            this.cboStaffRoom.Items.AddRange(new object[] {
            "Tất cả phòng"});
            this.cboStaffRoom.Location = new System.Drawing.Point(480, 7);
            this.cboStaffRoom.MaxDropDownItems = 4;
            this.cboStaffRoom.MouseState = MaterialSkin.MouseState.OUT;
            this.cboStaffRoom.Name = "cboStaffRoom";
            this.cboStaffRoom.Size = new System.Drawing.Size(140, 35);
            this.cboStaffRoom.StartIndex = 0;
            this.cboStaffRoom.TabIndex = 8;
            this.cboStaffRoom.UseTallSize = false;
            // 
            // txtStaffSearch
            // 
            this.txtStaffSearch.AnimateReadOnly = false;
            this.txtStaffSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStaffSearch.Depth = 0;
            this.txtStaffSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtStaffSearch.Hint = "Tìm mã máy, loại máy...";
            this.txtStaffSearch.LeadingIcon = null;
            this.txtStaffSearch.Location = new System.Drawing.Point(860, 7);
            this.txtStaffSearch.MaxLength = 50;
            this.txtStaffSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStaffSearch.Multiline = false;
            this.txtStaffSearch.Name = "txtStaffSearch";
            this.txtStaffSearch.Size = new System.Drawing.Size(200, 36);
            this.txtStaffSearch.TabIndex = 9;
            this.txtStaffSearch.Text = "";
            this.txtStaffSearch.TrailingIcon = null;
            this.txtStaffSearch.UseTallSize = false;
            // 
            // frmComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1086, 749);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.pnlRoleToggle);
            this.Name = "frmComputer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý máy tính — Chế độ: Admin";
            this.pnlRoleToggle.ResumeLayout(false);
            this.pnlRoleToggle.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            this.cardAdminDetails.ResumeLayout(false);
            this.cardAdminDetails.PerformLayout();
            this.grpAdminPrice.ResumeLayout(false);
            this.grpAdminPrice.PerformLayout();
            this.pnlAdminToolbar.ResumeLayout(false);
            this.pnlAdminToolbar.PerformLayout();
            this.tabStaff.ResumeLayout(false);
            this.cardStaffDetails.ResumeLayout(false);
            this.cardStaffDetails.PerformLayout();
            this.pnlStaffNotice.ResumeLayout(false);
            this.pnlStaffNotice.PerformLayout();
            this.pnlStaffToolbar.ResumeLayout(false);
            this.pnlStaffToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRoleToggle;
        private System.Windows.Forms.Label lblRoleToggle;
        private MaterialSkin.Controls.MaterialButton btnRoleAdmin;
        private MaterialSkin.Controls.MaterialButton btnRoleStaff;
        private MaterialSkin.Controls.MaterialTabControl mainTabControl;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.TabPage tabStaff;

        // Admin Controls
        private System.Windows.Forms.Panel pnlAdminToolbar;
        private MaterialSkin.Controls.MaterialButton btnAdminAdd;
        private MaterialSkin.Controls.MaterialButton btnAdminEditAll;
        private MaterialSkin.Controls.MaterialButton btnAdminDelete;
        private MaterialSkin.Controls.MaterialButton btnAdminManageRoom;
        private MaterialSkin.Controls.MaterialButton btnAdminUpdatePrice;
        private MaterialSkin.Controls.MaterialLabel lblAdminStatus;
        private MaterialSkin.Controls.MaterialComboBox cboAdminStatus;
        private MaterialSkin.Controls.MaterialLabel lblAdminClass;
        private MaterialSkin.Controls.MaterialComboBox cboAdminType;
        private MaterialSkin.Controls.MaterialTextBox txtAdminSearch;
        private System.Windows.Forms.ListView lvAdmin;
        private System.Windows.Forms.ColumnHeader colAdminCode;
        private System.Windows.Forms.ColumnHeader colAdminRoom;
        private System.Windows.Forms.ColumnHeader colAdminClass;
        private System.Windows.Forms.ColumnHeader colAdminConfig;
        private System.Windows.Forms.ColumnHeader colAdminStatus;
        private System.Windows.Forms.ColumnHeader colAdminPrice;
        private MaterialSkin.Controls.MaterialCard cardAdminDetails;
        private MaterialSkin.Controls.MaterialLabel lblAdminDetailsTitle;
        private MaterialSkin.Controls.MaterialTextBox txtAdminCode;
        private MaterialSkin.Controls.MaterialComboBox cboAdminRoom;
        private MaterialSkin.Controls.MaterialComboBox cboAdminTypeClass;
        private MaterialSkin.Controls.MaterialTextBox txtAdminCPU;
        private MaterialSkin.Controls.MaterialTextBox txtAdminGPU;
        private MaterialSkin.Controls.MaterialTextBox txtAdminRAM;
        private MaterialSkin.Controls.MaterialTextBox txtAdminDisk;
        private MaterialSkin.Controls.MaterialComboBox cboAdminStatusEdit;
        private System.Windows.Forms.GroupBox grpAdminPrice;
        private MaterialSkin.Controls.MaterialTextBox txtAdminPrice;
        private System.Windows.Forms.DateTimePicker dtpAdminPriceDate;
        private MaterialSkin.Controls.MaterialLabel lblAdminPriceDate;
        private MaterialSkin.Controls.MaterialButton btnAdminSave;
        private MaterialSkin.Controls.MaterialButton btnAdminCancel;
        private System.Windows.Forms.Button btnAdminDeleteMachine;

        // Staff Controls
        private System.Windows.Forms.Panel pnlStaffToolbar;
        private MaterialSkin.Controls.MaterialButton btnStaffUpdateStatus;
        private MaterialSkin.Controls.MaterialLabel lblStaffStatus;
        private MaterialSkin.Controls.MaterialComboBox cboStaffStatus;
        private MaterialSkin.Controls.MaterialLabel lblStaffRoom;
        private MaterialSkin.Controls.MaterialComboBox cboStaffRoom;
        private MaterialSkin.Controls.MaterialTextBox txtStaffSearch;
        private System.Windows.Forms.Panel pnlStaffNotice;
        private System.Windows.Forms.Label lblStaffNotice;
        private System.Windows.Forms.ListView lvStaff;
        private System.Windows.Forms.ColumnHeader colStaffCode;
        private System.Windows.Forms.ColumnHeader colStaffRoom;
        private System.Windows.Forms.ColumnHeader colStaffClass;
        private System.Windows.Forms.ColumnHeader colStaffStatus;
        private System.Windows.Forms.ColumnHeader colStaffState;
        private MaterialSkin.Controls.MaterialCard cardStaffDetails;
        private MaterialSkin.Controls.MaterialLabel lblStaffDetailsTitle;
        private MaterialSkin.Controls.MaterialLabel lblStaffMachineInfo;
        private MaterialSkin.Controls.MaterialLabel lblStaffRoomInfo;
        private MaterialSkin.Controls.MaterialLabel lblStaffConfigInfo;
        private MaterialSkin.Controls.MaterialComboBox cboStaffStatusEdit;
        private MaterialSkin.Controls.MaterialTextBox txtStaffNotes;
        private System.Windows.Forms.Button btnStaffSaveStatus;
        private MaterialSkin.Controls.MaterialButton btnStaffCancel;
        private System.Windows.Forms.Label lblStaffRestrictions;
    }
}
