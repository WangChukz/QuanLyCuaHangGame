namespace QuanLyCuaHangGame
{
    partial class frmComputerMap
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
            this.components = new System.ComponentModel.Container();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.tlpToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.lblFilterRoom = new System.Windows.Forms.Label();
            this.cboRooms = new MaterialSkin.Controls.MaterialComboBox();
            this.lblLegendIdle = new System.Windows.Forms.Label();
            this.lblLegendBusy = new System.Windows.Forms.Label();
            this.lblLegendBroken = new System.Windows.Forms.Label();
            this.flpComputers = new System.Windows.Forms.FlowLayoutPanel();
            this.cardComputerDetails = new MaterialSkin.Controls.MaterialCard();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPayment = new MaterialSkin.Controls.MaterialButton();
            this.btnOrderService = new MaterialSkin.Controls.MaterialButton();
            this.btnOpenSession = new MaterialSkin.Controls.MaterialButton();
            this.lblServiceInfo = new System.Windows.Forms.Label();
            this.lblTierInfo = new System.Windows.Forms.Label();
            this.lblHardwareInfo = new System.Windows.Forms.Label();
            this.lblPriceInfo = new System.Windows.Forms.Label();
            this.lblTimeInfo = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlToolbar.SuspendLayout();
            this.tlpToolbar.SuspendLayout();
            this.cardComputerDetails.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlToolbar.Controls.Add(this.tlpToolbar);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(6, 123);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(6);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1988, 96);
            this.pnlToolbar.TabIndex = 0;
            // 
            // tlpToolbar
            // 
            this.tlpToolbar.ColumnCount = 7;
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpToolbar.Controls.Add(this.btnRefresh, 0, 0);
            this.tlpToolbar.Controls.Add(this.lblFilterRoom, 1, 0);
            this.tlpToolbar.Controls.Add(this.cboRooms, 2, 0);
            this.tlpToolbar.Controls.Add(this.lblLegendIdle, 4, 0);
            this.tlpToolbar.Controls.Add(this.lblLegendBusy, 5, 0);
            this.tlpToolbar.Controls.Add(this.lblLegendBroken, 6, 0);
            this.tlpToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpToolbar.Location = new System.Drawing.Point(0, 0);
            this.tlpToolbar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpToolbar.Name = "tlpToolbar";
            this.tlpToolbar.RowCount = 1;
            this.tlpToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToolbar.Size = new System.Drawing.Size(1988, 96);
            this.tlpToolbar.TabIndex = 0;
            this.tlpToolbar.BackColor = System.Drawing.Color.Transparent;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefresh.Depth = 0;
            this.btnRefresh.HighEmphasis = true;
            this.btnRefresh.Icon = null;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(12, 0, 6, 0);
            this.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRefresh.Size = new System.Drawing.Size(83, 36);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "LÀM MỚI";
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRefresh.UseAccentColor = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblFilterRoom
            // 
            this.lblFilterRoom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilterRoom.AutoSize = true;
            this.lblFilterRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFilterRoom.Margin = new System.Windows.Forms.Padding(12, 0, 6, 0);
            this.lblFilterRoom.Name = "lblFilterRoom";
            this.lblFilterRoom.Size = new System.Drawing.Size(150, 36);
            this.lblFilterRoom.TabIndex = 1;
            this.lblFilterRoom.Text = "Lọc phòng:";
            // 
            // cboRooms
            // 
            this.cboRooms.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboRooms.AutoResize = false;
            this.cboRooms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboRooms.Depth = 0;
            this.cboRooms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboRooms.DropDownHeight = 118;
            this.cboRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRooms.DropDownWidth = 121;
            this.cboRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboRooms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboRooms.FormattingEnabled = true;
            this.cboRooms.IntegralHeight = false;
            this.cboRooms.ItemHeight = 29;
            this.cboRooms.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cboRooms.MaxDropDownItems = 4;
            this.cboRooms.MouseState = MaterialSkin.MouseState.OUT;
            this.cboRooms.Name = "cboRooms";
            this.cboRooms.Size = new System.Drawing.Size(316, 35);
            this.cboRooms.StartIndex = 0;
            this.cboRooms.TabIndex = 2;
            this.cboRooms.UseTallSize = false;
            // 
            // lblLegendIdle
            // 
            this.lblLegendIdle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLegendIdle.AutoSize = true;
            this.lblLegendIdle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegendIdle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblLegendIdle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLegendIdle.Name = "lblLegendIdle";
            this.lblLegendIdle.Size = new System.Drawing.Size(103, 32);
            this.lblLegendIdle.TabIndex = 3;
            this.lblLegendIdle.Text = "● Trống";
            // 
            // lblLegendBusy
            // 
            this.lblLegendBusy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLegendBusy.AutoSize = true;
            this.lblLegendBusy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegendBusy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblLegendBusy.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLegendBusy.Name = "lblLegendBusy";
            this.lblLegendBusy.Size = new System.Drawing.Size(164, 32);
            this.lblLegendBusy.TabIndex = 4;
            this.lblLegendBusy.Text = "● Đang dùng";
            // 
            // lblLegendBroken
            // 
            this.lblLegendBroken.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLegendBroken.AutoSize = true;
            this.lblLegendBroken.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegendBroken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblLegendBroken.Margin = new System.Windows.Forms.Padding(6, 0, 24, 0);
            this.lblLegendBroken.Name = "lblLegendBroken";
            this.lblLegendBroken.Size = new System.Drawing.Size(99, 32);
            this.lblLegendBroken.TabIndex = 5;
            this.lblLegendBroken.Text = "● Hỏng";
            // 
            // flpComputers
            // 
            this.flpComputers.AutoScroll = true;
            this.flpComputers.BackColor = System.Drawing.Color.White;
            this.flpComputers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpComputers.Location = new System.Drawing.Point(6, 219);
            this.flpComputers.Margin = new System.Windows.Forms.Padding(6);
            this.flpComputers.Name = "flpComputers";
            this.flpComputers.Padding = new System.Windows.Forms.Padding(24, 23, 24, 23);
            this.flpComputers.Size = new System.Drawing.Size(1988, 679);
            this.flpComputers.TabIndex = 1;
            // 
            // cardComputerDetails
            // 
            this.cardComputerDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardComputerDetails.Controls.Add(this.flowButtons);
            this.cardComputerDetails.Controls.Add(this.lblServiceInfo);
            this.cardComputerDetails.Controls.Add(this.lblTierInfo);
            this.cardComputerDetails.Controls.Add(this.lblHardwareInfo);
            this.cardComputerDetails.Controls.Add(this.lblPriceInfo);
            this.cardComputerDetails.Controls.Add(this.lblTimeInfo);
            this.cardComputerDetails.Controls.Add(this.lblCustomerInfo);
            this.cardComputerDetails.Controls.Add(this.lblDetailsTitle);
            this.cardComputerDetails.Depth = 0;
            this.cardComputerDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cardComputerDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardComputerDetails.Location = new System.Drawing.Point(6, 898);
            this.cardComputerDetails.Margin = new System.Windows.Forms.Padding(28, 27, 28, 27);
            this.cardComputerDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardComputerDetails.Name = "cardComputerDetails";
            this.cardComputerDetails.Padding = new System.Windows.Forms.Padding(28, 27, 28, 27);
            this.cardComputerDetails.Size = new System.Drawing.Size(1988, 346);
            this.cardComputerDetails.TabIndex = 2;
            // 
            // flowButtons
            // 
            this.flowButtons.Controls.Add(this.btnOpenSession);
            this.flowButtons.Controls.Add(this.btnOrderService);
            this.flowButtons.Controls.Add(this.btnPayment);
            this.flowButtons.Location = new System.Drawing.Point(30, 250);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(1800, 60);
            this.flowButtons.TabIndex = 7;
            this.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowButtons.BackColor = System.Drawing.Color.Transparent;
            // 
            // btnOpenSession
            // 
            this.btnOpenSession.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenSession.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOpenSession.Depth = 0;
            this.btnOpenSession.HighEmphasis = true;
            this.btnOpenSession.Icon = null;
            this.btnOpenSession.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.btnOpenSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenSession.Name = "btnOpenSession";
            this.btnOpenSession.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOpenSession.Size = new System.Drawing.Size(167, 36);
            this.btnOpenSession.TabIndex = 0;
            this.btnOpenSession.Text = "MỞ MÁY CHO KHÁCH";
            this.btnOpenSession.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOpenSession.UseAccentColor = false;
            this.btnOpenSession.UseVisualStyleBackColor = true;
            // 
            // btnOrderService
            // 
            this.btnOrderService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOrderService.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOrderService.Depth = 0;
            this.btnOrderService.HighEmphasis = true;
            this.btnOrderService.Icon = null;
            this.btnOrderService.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.btnOrderService.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOrderService.Name = "btnOrderService";
            this.btnOrderService.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOrderService.Size = new System.Drawing.Size(122, 36);
            this.btnOrderService.TabIndex = 1;
            this.btnOrderService.Text = "THÊM DỊCH VỤ";
            this.btnOrderService.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOrderService.UseAccentColor = false;
            this.btnOrderService.UseVisualStyleBackColor = true;
            // 
            // btnPayment
            // 
            this.btnPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPayment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPayment.Depth = 0;
            this.btnPayment.HighEmphasis = true;
            this.btnPayment.Icon = null;
            this.btnPayment.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.btnPayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPayment.Size = new System.Drawing.Size(207, 36);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "ĐÓNG MÁY & THANH TOÁN";
            this.btnPayment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPayment.UseAccentColor = true;
            this.btnPayment.UseVisualStyleBackColor = true;

            // 
            // lblServiceInfo
            // 
            this.lblServiceInfo.AutoSize = true;
            this.lblServiceInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblServiceInfo.Location = new System.Drawing.Point(800, 183);
            this.lblServiceInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblServiceInfo.Name = "lblServiceInfo";
            this.lblServiceInfo.Size = new System.Drawing.Size(123, 36);
            this.lblServiceInfo.TabIndex = 6;
            this.lblServiceInfo.Text = "Dịch vụ: -";
            // 
            // lblTierInfo
            // 
            this.lblTierInfo.AutoSize = true;
            this.lblTierInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTierInfo.Location = new System.Drawing.Point(800, 135);
            this.lblTierInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTierInfo.Name = "lblTierInfo";
            this.lblTierInfo.Size = new System.Drawing.Size(154, 36);
            this.lblTierInfo.TabIndex = 5;
            this.lblTierInfo.Text = "Hạng máy: -";
            // 
            // lblHardwareInfo
            // 
            this.lblHardwareInfo.AutoSize = true;
            this.lblHardwareInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHardwareInfo.Location = new System.Drawing.Point(800, 87);
            this.lblHardwareInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHardwareInfo.Name = "lblHardwareInfo";
            this.lblHardwareInfo.Size = new System.Drawing.Size(140, 36);
            this.lblHardwareInfo.TabIndex = 4;
            this.lblHardwareInfo.Text = "Cấu hình: -";
            // 
            // lblPriceInfo
            // 
            this.lblPriceInfo.AutoSize = true;
            this.lblPriceInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPriceInfo.Location = new System.Drawing.Point(30, 183);
            this.lblPriceInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPriceInfo.Name = "lblPriceInfo";
            this.lblPriceInfo.Size = new System.Drawing.Size(119, 36);
            this.lblPriceInfo.TabIndex = 3;
            this.lblPriceInfo.Text = "Giá giờ: -";
            // 
            // lblTimeInfo
            // 
            this.lblTimeInfo.AutoSize = true;
            this.lblTimeInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTimeInfo.Location = new System.Drawing.Point(30, 135);
            this.lblTimeInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimeInfo.Name = "lblTimeInfo";
            this.lblTimeInfo.Size = new System.Drawing.Size(145, 36);
            this.lblTimeInfo.TabIndex = 2;
            this.lblTimeInfo.Text = "Thời gian: -";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCustomerInfo.Location = new System.Drawing.Point(30, 87);
            this.lblCustomerInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(131, 36);
            this.lblCustomerInfo.TabIndex = 1;
            this.lblCustomerInfo.Text = "Hội viên: -";
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.Location = new System.Drawing.Point(30, 19);
            this.lblDetailsTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(435, 51);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Chi tiết máy đang chọn";
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 15000;
            // 
            // frmComputerMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.flpComputers);
            this.Controls.Add(this.cardComputerDetails);
            this.Controls.Add(this.pnlToolbar);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmComputerMap";
            this.Padding = new System.Windows.Forms.Padding(6, 123, 6, 6);
            this.Text = "Sơ đồ phòng máy";
            this.Load += new System.EventHandler(this.frmComputerMap_Load);
            this.pnlToolbar.ResumeLayout(false);
            this.tlpToolbar.ResumeLayout(false);
            this.tlpToolbar.PerformLayout();
            this.cardComputerDetails.ResumeLayout(false);
            this.cardComputerDetails.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            this.flowButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.TableLayoutPanel tlpToolbar;
        private System.Windows.Forms.Label lblLegendBroken;
        private System.Windows.Forms.Label lblLegendBusy;
        private System.Windows.Forms.Label lblLegendIdle;
        private MaterialSkin.Controls.MaterialComboBox cboRooms;
        private System.Windows.Forms.Label lblFilterRoom;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flpComputers;
        private MaterialSkin.Controls.MaterialCard cardComputerDetails;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblTimeInfo;
        private System.Windows.Forms.Label lblPriceInfo;
        private System.Windows.Forms.Label lblHardwareInfo;
        private System.Windows.Forms.Label lblTierInfo;
        private System.Windows.Forms.Label lblServiceInfo;
        private MaterialSkin.Controls.MaterialButton btnOpenSession;
        private MaterialSkin.Controls.MaterialButton btnOrderService;
            private MaterialSkin.Controls.MaterialButton btnPayment;
        private System.Windows.Forms.Timer tmrRefresh;
    }
}
