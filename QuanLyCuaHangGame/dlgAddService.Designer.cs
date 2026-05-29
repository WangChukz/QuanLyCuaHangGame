namespace QuanLyCuaHangGame.GUI
{
    partial class dlgAddService
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

        private void InitializeComponent()
        {
            this.cardSessionInfo = new MaterialSkin.Controls.MaterialCard();
            this.lblSessionRunning = new MaterialSkin.Controls.MaterialLabel();
            this.lblSessionDetails = new MaterialSkin.Controls.MaterialLabel();
            this.lblTimePlayedTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblTimePlayed = new MaterialSkin.Controls.MaterialLabel();
            
            this.lblChooseService = new MaterialSkin.Controls.MaterialLabel();
            this.lvServices = new MaterialSkin.Controls.MaterialListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colCat = new System.Windows.Forms.ColumnHeader();
            this.colPrice = new System.Windows.Forms.ColumnHeader();
            this.colQuantity = new System.Windows.Forms.ColumnHeader();
            this.colTotal = new System.Windows.Forms.ColumnHeader();
            
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalTypesTitle = new System.Windows.Forms.Label();
            this.lblTotalTypes = new System.Windows.Forms.Label();
            this.lblTotalPriceTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalPrice = new MaterialSkin.Controls.MaterialLabel();
            
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();

            this.cardSessionInfo.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // cardSessionInfo
            // 
            this.cardSessionInfo.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.cardSessionInfo.Controls.Add(this.lblSessionRunning);
            this.cardSessionInfo.Controls.Add(this.lblSessionDetails);
            this.cardSessionInfo.Controls.Add(this.lblTimePlayedTitle);
            this.cardSessionInfo.Controls.Add(this.lblTimePlayed);
            this.cardSessionInfo.Depth = 0;
            this.cardSessionInfo.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            this.cardSessionInfo.Location = new System.Drawing.Point(14, 76);
            this.cardSessionInfo.Margin = new System.Windows.Forms.Padding(14);
            this.cardSessionInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardSessionInfo.Name = "cardSessionInfo";
            this.cardSessionInfo.Padding = new System.Windows.Forms.Padding(14);
            this.cardSessionInfo.Size = new System.Drawing.Size(492, 70);
            this.cardSessionInfo.TabIndex = 0;
            
            // 
            // lblSessionRunning
            // 
            this.lblSessionRunning.AutoSize = true;
            this.lblSessionRunning.Depth = 0;
            this.lblSessionRunning.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSessionRunning.Location = new System.Drawing.Point(14, 14);
            this.lblSessionRunning.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSessionRunning.Name = "lblSessionRunning";
            this.lblSessionRunning.Size = new System.Drawing.Size(120, 19);
            this.lblSessionRunning.TabIndex = 0;
            this.lblSessionRunning.Text = "Phiên đang chạy";
            
            // 
            // lblSessionDetails
            // 
            this.lblSessionDetails.AutoSize = true;
            this.lblSessionDetails.Depth = 0;
            this.lblSessionDetails.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSessionDetails.Location = new System.Drawing.Point(14, 38);
            this.lblSessionDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSessionDetails.Name = "lblSessionDetails";
            this.lblSessionDetails.Size = new System.Drawing.Size(201, 19);
            this.lblSessionDetails.TabIndex = 1;
            this.lblSessionDetails.Text = "PC05 · VIP · Phạm Quốc Huy";
            
            // 
            // lblTimePlayedTitle
            // 
            this.lblTimePlayedTitle.AutoSize = true;
            this.lblTimePlayedTitle.Depth = 0;
            this.lblTimePlayedTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimePlayedTitle.Location = new System.Drawing.Point(415, 14);
            this.lblTimePlayedTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTimePlayedTitle.Name = "lblTimePlayedTitle";
            this.lblTimePlayedTitle.Size = new System.Drawing.Size(55, 19);
            this.lblTimePlayedTitle.TabIndex = 2;
            this.lblTimePlayedTitle.Text = "Đã chơi";
            this.lblTimePlayedTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            
            // 
            // lblTimePlayed
            // 
            this.lblTimePlayedTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTimePlayed.AutoSize = true;
            this.lblTimePlayed.Depth = 0;
            this.lblTimePlayed.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimePlayed.Location = new System.Drawing.Point(420, 38);
            this.lblTimePlayed.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTimePlayed.Name = "lblTimePlayed";
            this.lblTimePlayed.Size = new System.Drawing.Size(50, 19);
            this.lblTimePlayed.TabIndex = 3;
            this.lblTimePlayed.Text = "1g 23p";
            this.lblTimePlayed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            
            // 
            // lblChooseService
            // 
            this.lblChooseService.AutoSize = true;
            this.lblChooseService.Depth = 0;
            this.lblChooseService.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblChooseService.Location = new System.Drawing.Point(14, 155);
            this.lblChooseService.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblChooseService.Name = "lblChooseService";
            this.lblChooseService.Size = new System.Drawing.Size(95, 19);
            this.lblChooseService.TabIndex = 1;
            this.lblChooseService.Text = "Chọn dịch vụ:";
            
            // 
            // lvServices
            // 
            this.lvServices.AutoSizeTable = false;
            this.lvServices.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lvServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colCat,
            this.colPrice,
            this.colQuantity,
            this.colTotal});
            this.lvServices.Depth = 0;
            this.lvServices.FullRowSelect = true;
            this.lvServices.HideSelection = false;
            this.lvServices.Location = new System.Drawing.Point(14, 180);
            this.lvServices.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvServices.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvServices.MouseState = MaterialSkin.MouseState.OUT;
            this.lvServices.Name = "lvServices";
            this.lvServices.OwnerDraw = true;
            this.lvServices.Size = new System.Drawing.Size(492, 230);
            this.lvServices.TabIndex = 2;
            this.lvServices.UseCompatibleStateImageBehavior = false;
            this.lvServices.View = System.Windows.Forms.View.Details;
            
            // 
            // colName
            // 
            this.colName.Text = "Dịch vụ";
            this.colName.Width = 120;
            
            // 
            // colCat
            // 
            this.colCat.Text = "Danh mục";
            this.colCat.Width = 90;
            
            // 
            // colPrice
            // 
            this.colPrice.Text = "Đơn giá";
            this.colPrice.Width = 80;
            
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Số lượng";
            this.colQuantity.Width = 100;
            
            // 
            // colTotal
            // 
            this.colTotal.Text = "Thành tiền";
            this.colTotal.Width = 100;
            
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.lblTotalTypesTitle);
            this.pnlSummary.Controls.Add(this.lblTotalTypes);
            this.pnlSummary.Controls.Add(this.lblTotalPriceTitle);
            this.pnlSummary.Controls.Add(this.lblTotalPrice);
            this.pnlSummary.Location = new System.Drawing.Point(14, 420);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(492, 50);
            this.pnlSummary.TabIndex = 3;
            
            // 
            // lblTotalTypesTitle
            // 
            this.lblTotalTypesTitle.AutoSize = true;
            this.lblTotalTypesTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalTypesTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalTypesTitle.Location = new System.Drawing.Point(5, 5);
            this.lblTotalTypesTitle.Name = "lblTotalTypesTitle";
            this.lblTotalTypesTitle.Size = new System.Drawing.Size(149, 19);
            this.lblTotalTypesTitle.TabIndex = 0;
            this.lblTotalTypesTitle.Text = "Số loại dịch vụ đã chọn:";
            
            // 
            // lblTotalTypes
            // 
            this.lblTotalTypes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalTypes.AutoSize = true;
            this.lblTotalTypes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalTypes.Location = new System.Drawing.Point(375, 5);
            this.lblTotalTypes.Name = "lblTotalTypes";
            this.lblTotalTypes.Size = new System.Drawing.Size(100, 19);
            this.lblTotalTypes.TabIndex = 1;
            this.lblTotalTypes.Text = "2 loại (3 món)";
            this.lblTotalTypes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            
            // 
            // lblTotalPriceTitle
            // 
            this.lblTotalPriceTitle.AutoSize = true;
            this.lblTotalPriceTitle.Depth = 0;
            this.lblTotalPriceTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalPriceTitle.Location = new System.Drawing.Point(5, 27);
            this.lblTotalPriceTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalPriceTitle.Name = "lblTotalPriceTitle";
            this.lblTotalPriceTitle.Size = new System.Drawing.Size(183, 19);
            this.lblTotalPriceTitle.TabIndex = 2;
            this.lblTotalPriceTitle.Text = "Tổng tiền dịch vụ lần này:";
            
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Depth = 0;
            this.lblTotalPrice.Font = new System.Drawing.Font("Roboto Medium", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalPrice.Location = new System.Drawing.Point(405, 27);
            this.lblTotalPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(65, 19);
            this.lblTotalPrice.TabIndex = 3;
            this.lblTotalPrice.Text = "35,000đ";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(232, 485);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(85, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "HỦY BỎ";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = null;
            this.btnConfirm.Location = new System.Drawing.Point(325, 485);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirm.Size = new System.Drawing.Size(180, 36);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "XÁC NHẬN GỌI MÓN";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = true;
            this.btnConfirm.UseVisualStyleBackColor = true;
            
            // 
            // dlgAddService
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(520, 540);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.lvServices);
            this.Controls.Add(this.lblChooseService);
            this.Controls.Add(this.cardSessionInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddService";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gọi dịch vụ – PC05 - Phạm Quốc Huy";
            this.cardSessionInfo.ResumeLayout(false);
            this.cardSessionInfo.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MaterialSkin.Controls.MaterialCard cardSessionInfo;
        private MaterialSkin.Controls.MaterialLabel lblSessionRunning;
        private MaterialSkin.Controls.MaterialLabel lblSessionDetails;
        private MaterialSkin.Controls.MaterialLabel lblTimePlayedTitle;
        private MaterialSkin.Controls.MaterialLabel lblTimePlayed;
        private MaterialSkin.Controls.MaterialLabel lblChooseService;
        private MaterialSkin.Controls.MaterialListView lvServices;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colCat;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalTypesTitle;
        private System.Windows.Forms.Label lblTotalTypes;
        private MaterialSkin.Controls.MaterialLabel lblTotalPriceTitle;
        private MaterialSkin.Controls.MaterialLabel lblTotalPrice;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
    }
}
