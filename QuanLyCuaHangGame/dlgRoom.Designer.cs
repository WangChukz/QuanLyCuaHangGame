namespace QuanLyCuaHangGame
{
    partial class dlgRoom
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnEdit = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lvRooms = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFloor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();

            this.cardDetails = new MaterialSkin.Controls.MaterialCard();
            this.lblDetailsTitle = new MaterialSkin.Controls.MaterialLabel();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFloor = new MaterialSkin.Controls.MaterialTextBox();
            this.lblFloorHint = new System.Windows.Forms.Label();
            this.txtDescription = new MaterialSkin.Controls.MaterialTextBox();
            this.chkActive = new MaterialSkin.Controls.MaterialCheckbox();
            
            this.grpStats = new System.Windows.Forms.Panel();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.lblTotalMachines = new System.Windows.Forms.Label();
            this.lblTotalMachinesValue = new System.Windows.Forms.Label();
            this.lblActiveMachines = new System.Windows.Forms.Label();
            this.lblActiveMachinesValue = new System.Windows.Forms.Label();
            this.lblBrokenMachines = new System.Windows.Forms.Label();
            this.lblBrokenMachinesValue = new System.Windows.Forms.Label();
            
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();

            this.pnlToolbar.SuspendLayout();
            this.pnlWarning.SuspendLayout();
            this.cardDetails.SuspendLayout();
            this.grpStats.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Controls.Add(this.btnEdit);
            this.pnlToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Location = new System.Drawing.Point(0, 64);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(900, 50);
            this.pnlToolbar.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdd.Depth = 0;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(10, 7);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdd.Size = new System.Drawing.Size(107, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+ Thêm phòng";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnAdd.UseAccentColor = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEdit.Depth = 0;
            this.btnEdit.HighEmphasis = true;
            this.btnEdit.Icon = null;
            this.btnEdit.Location = new System.Drawing.Point(125, 7);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEdit.Size = new System.Drawing.Size(64, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnEdit.UseAccentColor = false;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDelete.Depth = 0;
            this.btnDelete.HighEmphasis = true;
            this.btnDelete.Icon = null;
            this.btnDelete.Location = new System.Drawing.Point(197, 7);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(64, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnDelete.UseAccentColor = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblListTitle.Location = new System.Drawing.Point(17, 130);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(155, 17);
            this.lblListTitle.TabIndex = 1;
            this.lblListTitle.Text = "Danh sách phòng hiện có";
            // 
            // lvRooms
            // 
            this.lvRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvRooms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colFloor,
            this.colCount,
            this.colStatus});
            this.lvRooms.FullRowSelect = true;
            this.lvRooms.HideSelection = false;
            this.lvRooms.Location = new System.Drawing.Point(17, 155);
            this.lvRooms.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.OwnerDraw = true;
            this.lvRooms.Size = new System.Drawing.Size(430, 345);
            this.lvRooms.TabIndex = 2;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            this.lvRooms.View = System.Windows.Forms.View.Details;
            this.lvRooms.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.LvRooms_DrawColumnHeader);
            this.lvRooms.DrawItem        += new System.Windows.Forms.DrawListViewItemEventHandler(this.LvRooms_DrawItem);
            this.lvRooms.DrawSubItem     += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.LvRooms_DrawSubItem);
            // 
            // colName
            // 
            this.colName.Text = "Tên phòng";
            this.colName.Width = 120;
            // 
            // colFloor
            // 
            this.colFloor.Text = "Tầng";
            this.colFloor.Width = 80;
            // 
            // colCount
            // 
            this.colCount.Text = "Số máy";
            this.colCount.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Trạng thái";
            this.colStatus.Width = 130;
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.pnlWarning.Controls.Add(this.lblWarning);
            this.pnlWarning.Location = new System.Drawing.Point(17, 510);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(430, 50);
            this.pnlWarning.TabIndex = 3;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblWarning.Location = new System.Drawing.Point(10, 10);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(395, 30);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "Không thể xóa phòng còn chứa máy tính. Phải\r\nchuyển hoặc xóa máy trước.";
            // 
            // cardDetails
            // 
            this.cardDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardDetails.Controls.Add(this.lblDetailsTitle);
            this.cardDetails.Controls.Add(this.txtName);
            this.cardDetails.Controls.Add(this.txtFloor);
            this.cardDetails.Controls.Add(this.lblFloorHint);
            this.cardDetails.Controls.Add(this.txtDescription);
            this.cardDetails.Controls.Add(this.chkActive);
            this.cardDetails.Controls.Add(this.grpStats);
            this.cardDetails.Controls.Add(this.btnSave);
            this.cardDetails.Controls.Add(this.btnCancel);
            this.cardDetails.Depth = 0;
            this.cardDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardDetails.Location = new System.Drawing.Point(470, 130);
            this.cardDetails.Margin = new System.Windows.Forms.Padding(14);
            this.cardDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardDetails.Name = "cardDetails";
            this.cardDetails.Padding = new System.Windows.Forms.Padding(14);
            this.cardDetails.Size = new System.Drawing.Size(410, 430);
            this.cardDetails.TabIndex = 4;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Depth = 0;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDetailsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblDetailsTitle.Location = new System.Drawing.Point(17, 14);
            this.lblDetailsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(126, 19);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Chi tiết - Phòng A";
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Hint = "Tên phòng *";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(17, 45);
            this.txtName.MaxLength = 50;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(376, 50);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Phòng A";
            this.txtName.TrailingIcon = null;
            // 
            // txtFloor
            // 
            this.txtFloor.AnimateReadOnly = false;
            this.txtFloor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFloor.Depth = 0;
            this.txtFloor.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFloor.Hint = "Số tầng";
            this.txtFloor.LeadingIcon = null;
            this.txtFloor.Location = new System.Drawing.Point(17, 105);
            this.txtFloor.MaxLength = 50;
            this.txtFloor.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFloor.Multiline = false;
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(376, 50);
            this.txtFloor.TabIndex = 2;
            this.txtFloor.Text = "1";
            this.txtFloor.TrailingIcon = null;
            // 
            // lblFloorHint
            // 
            this.lblFloorHint.AutoSize = true;
            this.lblFloorHint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorHint.ForeColor = System.Drawing.Color.Gray;
            this.lblFloorHint.Location = new System.Drawing.Point(17, 160);
            this.lblFloorHint.Name = "lblFloorHint";
            this.lblFloorHint.Size = new System.Drawing.Size(149, 13);
            this.lblFloorHint.TabIndex = 3;
            this.lblFloorHint.Text = "Hỗ trợ quản lý nhiều tầng";
            // 
            // txtDescription
            // 
            this.txtDescription.AnimateReadOnly = false;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Depth = 0;
            this.txtDescription.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDescription.Hint = "Mô tả";
            this.txtDescription.LeadingIcon = null;
            this.txtDescription.Location = new System.Drawing.Point(17, 185);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDescription.Multiline = false;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(376, 50);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Text = "Phòng chính tầng 1, 12 máy Standard";
            this.txtDescription.TrailingIcon = null;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Depth = 0;
            this.chkActive.Location = new System.Drawing.Point(17, 245);
            this.chkActive.Margin = new System.Windows.Forms.Padding(0);
            this.chkActive.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkActive.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkActive.Name = "chkActive";
            this.chkActive.ReadOnly = false;
            this.chkActive.Ripple = true;
            this.chkActive.Size = new System.Drawing.Size(193, 37);
            this.chkActive.TabIndex = 5;
            this.chkActive.Text = "Phòng đang hoạt động";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // grpStats
            // 
            this.grpStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.grpStats.Controls.Add(this.lblStatsTitle);
            this.grpStats.Controls.Add(this.lblTotalMachines);
            this.grpStats.Controls.Add(this.lblTotalMachinesValue);
            this.grpStats.Controls.Add(this.lblActiveMachines);
            this.grpStats.Controls.Add(this.lblActiveMachinesValue);
            this.grpStats.Controls.Add(this.lblBrokenMachines);
            this.grpStats.Controls.Add(this.lblBrokenMachinesValue);
            this.grpStats.Location = new System.Drawing.Point(17, 285);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(376, 85);
            this.grpStats.TabIndex = 6;
            // 
            // lblStatsTitle
            // 
            this.lblStatsTitle.AutoSize = true;
            this.lblStatsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblStatsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblStatsTitle.Name = "lblStatsTitle";
            this.lblStatsTitle.Size = new System.Drawing.Size(117, 15);
            this.lblStatsTitle.TabIndex = 0;
            this.lblStatsTitle.Text = "THỐNG KÊ HIỆN TẠI";
            // 
            // lblTotalMachines
            // 
            this.lblTotalMachines.AutoSize = true;
            this.lblTotalMachines.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMachines.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalMachines.Location = new System.Drawing.Point(10, 30);
            this.lblTotalMachines.Name = "lblTotalMachines";
            this.lblTotalMachines.Size = new System.Drawing.Size(130, 15);
            this.lblTotalMachines.TabIndex = 1;
            this.lblTotalMachines.Text = "Tổng máy trong phòng:";
            // 
            // lblTotalMachinesValue
            // 
            this.lblTotalMachinesValue.AutoSize = true;
            this.lblTotalMachinesValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMachinesValue.ForeColor = System.Drawing.Color.Black;
            this.lblTotalMachinesValue.Location = new System.Drawing.Point(260, 30);
            this.lblTotalMachinesValue.Name = "lblTotalMachinesValue";
            this.lblTotalMachinesValue.Size = new System.Drawing.Size(46, 15);
            this.lblTotalMachinesValue.TabIndex = 2;
            this.lblTotalMachinesValue.Text = "12 máy";
            // 
            // lblActiveMachines
            // 
            this.lblActiveMachines.AutoSize = true;
            this.lblActiveMachines.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveMachines.ForeColor = System.Drawing.Color.DimGray;
            this.lblActiveMachines.Location = new System.Drawing.Point(10, 48);
            this.lblActiveMachines.Name = "lblActiveMachines";
            this.lblActiveMachines.Size = new System.Drawing.Size(95, 15);
            this.lblActiveMachines.TabIndex = 3;
            this.lblActiveMachines.Text = "Đang hoạt động:";
            // 
            // lblActiveMachinesValue
            // 
            this.lblActiveMachinesValue.AutoSize = true;
            this.lblActiveMachinesValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveMachinesValue.ForeColor = System.Drawing.Color.Green;
            this.lblActiveMachinesValue.Location = new System.Drawing.Point(260, 48);
            this.lblActiveMachinesValue.Name = "lblActiveMachinesValue";
            this.lblActiveMachinesValue.Size = new System.Drawing.Size(46, 15);
            this.lblActiveMachinesValue.TabIndex = 4;
            this.lblActiveMachinesValue.Text = "10 máy";
            // 
            // lblBrokenMachines
            // 
            this.lblBrokenMachines.AutoSize = true;
            this.lblBrokenMachines.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrokenMachines.ForeColor = System.Drawing.Color.DimGray;
            this.lblBrokenMachines.Location = new System.Drawing.Point(10, 66);
            this.lblBrokenMachines.Name = "lblBrokenMachines";
            this.lblBrokenMachines.Size = new System.Drawing.Size(76, 15);
            this.lblBrokenMachines.TabIndex = 5;
            this.lblBrokenMachines.Text = "Hỏng / Dừng:";
            // 
            // lblBrokenMachinesValue
            // 
            this.lblBrokenMachinesValue.AutoSize = true;
            this.lblBrokenMachinesValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrokenMachinesValue.ForeColor = System.Drawing.Color.Red;
            this.lblBrokenMachinesValue.Location = new System.Drawing.Point(260, 66);
            this.lblBrokenMachinesValue.Name = "lblBrokenMachinesValue";
            this.lblBrokenMachinesValue.Size = new System.Drawing.Size(39, 15);
            this.lblBrokenMachinesValue.TabIndex = 6;
            this.lblBrokenMachinesValue.Text = "2 máy";
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(254, 380);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(139, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "LƯU PHÒNG";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(180, 380);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(64, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 580);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(900, 50);
            this.pnlFooter.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(800, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClose.Size = new System.Drawing.Size(73, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "ĐÓNG";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click  += new System.EventHandler(this.btnClose_Click);
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);
            this.btnEdit.Click   += new System.EventHandler(this.btnEdit_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // dlgRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 630);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.lblListTitle);
            this.Controls.Add(this.lvRooms);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.cardDetails);
            this.Controls.Add(this.pnlFooter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý phòng máy";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlWarning.ResumeLayout(false);
            this.pnlWarning.PerformLayout();
            this.cardDetails.ResumeLayout(false);
            this.cardDetails.PerformLayout();
            this.grpStats.ResumeLayout(false);
            this.grpStats.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnEdit;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.ListView lvRooms;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colFloor;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.ColumnHeader colStatus;
        
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblWarning;

        private MaterialSkin.Controls.MaterialCard cardDetails;
        private MaterialSkin.Controls.MaterialLabel lblDetailsTitle;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialTextBox txtFloor;
        private System.Windows.Forms.Label lblFloorHint;
        private MaterialSkin.Controls.MaterialTextBox txtDescription;
        private MaterialSkin.Controls.MaterialCheckbox chkActive;
        
        private System.Windows.Forms.Panel grpStats;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label lblTotalMachines;
        private System.Windows.Forms.Label lblTotalMachinesValue;
        private System.Windows.Forms.Label lblActiveMachines;
        private System.Windows.Forms.Label lblActiveMachinesValue;
        private System.Windows.Forms.Label lblBrokenMachines;
        private System.Windows.Forms.Label lblBrokenMachinesValue;
        
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        
        private System.Windows.Forms.Panel pnlFooter;
        private MaterialSkin.Controls.MaterialButton btnClose;
    }
}
