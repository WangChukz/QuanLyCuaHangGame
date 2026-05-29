namespace QuanLyCuaHangGame
{
    partial class frmReport
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblKyBaoCao = new System.Windows.Forms.Label();
            this.cboKyBaoCao = new MaterialSkin.Controls.MaterialComboBox();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new MaterialSkin.Controls.MaterialButton();
            this.btnXuatExcel = new MaterialSkin.Controls.MaterialButton();
            this.btnIn = new MaterialSkin.Controls.MaterialButton();
            
            this.cardDoanhThu = new MaterialSkin.Controls.MaterialCard();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.lblDoanhThuValue = new System.Windows.Forms.Label();
            this.lblDoanhThuSub = new System.Windows.Forms.Label();
            
            this.cardGioMay = new MaterialSkin.Controls.MaterialCard();
            this.lblGioMayTitle = new System.Windows.Forms.Label();
            this.lblGioMayValue = new System.Windows.Forms.Label();
            this.lblGioMaySub = new System.Windows.Forms.Label();
            
            this.cardMayHoatDong = new MaterialSkin.Controls.MaterialCard();
            this.lblMayHoatDongTitle = new System.Windows.Forms.Label();
            this.lblMayHoatDongValue = new System.Windows.Forms.Label();
            this.lblMayHoatDongSub = new System.Windows.Forms.Label();
            
            this.cardHoiVienMoi = new MaterialSkin.Controls.MaterialCard();
            this.lblHoiVienMoiTitle = new System.Windows.Forms.Label();
            this.lblHoiVienMoiValue = new System.Windows.Forms.Label();
            this.lblHoiVienMoiSub = new System.Windows.Forms.Label();
            
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.mainTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.tabMayTinh = new System.Windows.Forms.TabPage();
            this.tabHoiVien = new System.Windows.Forms.TabPage();
            
            this.cardChartDoanhThu = new MaterialSkin.Controls.MaterialCard();
            this.lblChartDoanhThuTitle = new System.Windows.Forms.Label();
            this.chartDoanhThu = new LiveCharts.WinForms.CartesianChart();
            
            this.cardChartCoCau = new MaterialSkin.Controls.MaterialCard();
            this.lblChartCoCauTitle = new System.Windows.Forms.Label();
            this.chartCoCau = new LiveCharts.WinForms.PieChart();
            
            this.cardTot = new MaterialSkin.Controls.MaterialCard();
            this.lblTot = new System.Windows.Forms.Label();
            this.cardDaSua = new MaterialSkin.Controls.MaterialCard();
            this.lblDaSua = new System.Windows.Forms.Label();
            this.cardHong = new MaterialSkin.Controls.MaterialCard();
            this.lblHong = new System.Windows.Forms.Label();
            
            this.cardChartGioMay = new MaterialSkin.Controls.MaterialCard();
            this.lblChartGioMayTitle = new System.Windows.Forms.Label();
            this.chartGioMay = new LiveCharts.WinForms.CartesianChart();
            
            this.cardHoiVien = new MaterialSkin.Controls.MaterialCard();
            this.lvHoiVien = new MaterialSkin.Controls.MaterialListView();
            this.colStt = new System.Windows.Forms.ColumnHeader();
            this.colTen = new System.Windows.Forms.ColumnHeader();
            this.colChiTieu = new System.Windows.Forms.ColumnHeader();
            this.colGio = new System.Windows.Forms.ColumnHeader();
            this.colNap = new System.Windows.Forms.ColumnHeader();

            this.pnlFilter.SuspendLayout();
            this.cardDoanhThu.SuspendLayout();
            this.cardGioMay.SuspendLayout();
            this.cardMayHoatDong.SuspendLayout();
            this.cardHoiVienMoi.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            this.tabMayTinh.SuspendLayout();
            this.tabHoiVien.SuspendLayout();
            this.cardChartDoanhThu.SuspendLayout();
            this.cardChartCoCau.SuspendLayout();
            this.cardTot.SuspendLayout();
            this.cardDaSua.SuspendLayout();
            this.cardHong.SuspendLayout();
            this.cardChartGioMay.SuspendLayout();
            this.cardHoiVien.SuspendLayout();
            this.SuspendLayout();

            // pnlFilter
            this.pnlFilter.Controls.Add(this.lblKyBaoCao);
            this.pnlFilter.Controls.Add(this.cboKyBaoCao);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.btnXem);
            this.pnlFilter.Controls.Add(this.btnXuatExcel);
            this.pnlFilter.Controls.Add(this.btnIn);
            this.pnlFilter.Location = new System.Drawing.Point(24, 24);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(952, 60);
            this.pnlFilter.TabIndex = 0;

            // lblKyBaoCao
            this.lblKyBaoCao.AutoSize = true;
            this.lblKyBaoCao.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKyBaoCao.Location = new System.Drawing.Point(15, 20);
            this.lblKyBaoCao.Name = "lblKyBaoCao";
            this.lblKyBaoCao.Size = new System.Drawing.Size(84, 19);
            this.lblKyBaoCao.TabIndex = 0;
            this.lblKyBaoCao.Text = "Kỳ báo cáo:";

            // cboKyBaoCao
            this.cboKyBaoCao.AutoResize = false;
            this.cboKyBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboKyBaoCao.Depth = 0;
            this.cboKyBaoCao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboKyBaoCao.DropDownHeight = 174;
            this.cboKyBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKyBaoCao.DropDownWidth = 121;
            this.cboKyBaoCao.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboKyBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboKyBaoCao.FormattingEnabled = true;
            this.cboKyBaoCao.IntegralHeight = false;
            this.cboKyBaoCao.ItemHeight = 43;
            this.cboKyBaoCao.Items.AddRange(new object[] { "Hôm nay", "Tuần này", "Tháng này", "Quý này", "Năm nay", "Tùy chỉnh" });
            this.cboKyBaoCao.Location = new System.Drawing.Point(105, 5);
            this.cboKyBaoCao.MaxDropDownItems = 4;
            this.cboKyBaoCao.MouseState = MaterialSkin.MouseState.OUT;
            this.cboKyBaoCao.Name = "cboKyBaoCao";
            this.cboKyBaoCao.Size = new System.Drawing.Size(160, 49);
            this.cboKyBaoCao.StartIndex = 2;
            this.cboKyBaoCao.TabIndex = 1;
            this.cboKyBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboKyBaoCao_SelectedIndexChanged);

            // dtpTuNgay
            this.dtpTuNgay.Font = new System.Drawing.Font("Inter", 11F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(280, 16);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 25);
            this.dtpTuNgay.TabIndex = 2;

            // dtpDenNgay
            this.dtpDenNgay.Font = new System.Drawing.Font("Inter", 11F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(410, 16);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 25);
            this.dtpDenNgay.TabIndex = 3;

            // btnXem
            this.btnXem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnXem.Depth = 0;
            this.btnXem.HighEmphasis = true;
            this.btnXem.Icon = null;
            this.btnXem.Location = new System.Drawing.Point(545, 12);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnXem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnXem.Name = "btnXem";
            this.btnXem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnXem.Size = new System.Drawing.Size(125, 36);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "XEM BÁO CÁO";
            this.btnXem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnXem.UseAccentColor = false;
            this.btnXem.UseVisualStyleBackColor = true;

            // btnXuatExcel
            this.btnXuatExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXuatExcel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnXuatExcel.Depth = 0;
            this.btnXuatExcel.HighEmphasis = true;
            this.btnXuatExcel.Icon = null;
            this.btnXuatExcel.Location = new System.Drawing.Point(680, 12);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnXuatExcel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnXuatExcel.Size = new System.Drawing.Size(107, 36);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "XUẤT EXCEL";
            this.btnXuatExcel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnXuatExcel.UseAccentColor = false;
            this.btnXuatExcel.UseVisualStyleBackColor = true;

            // btnIn
            this.btnIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnIn.Depth = 0;
            this.btnIn.HighEmphasis = true;
            this.btnIn.Icon = null;
            this.btnIn.Location = new System.Drawing.Point(795, 12);
            this.btnIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnIn.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnIn.Name = "btnIn";
            this.btnIn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnIn.Size = new System.Drawing.Size(103, 36);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "IN BÁO CÁO";
            this.btnIn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnIn.UseAccentColor = false;
            this.btnIn.UseVisualStyleBackColor = true;

            // KPI Cards Configuration 
            // cardDoanhThu
            this.cardDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardDoanhThu.Controls.Add(this.lblDoanhThuTitle);
            this.cardDoanhThu.Controls.Add(this.lblDoanhThuValue);
            this.cardDoanhThu.Controls.Add(this.lblDoanhThuSub);
            this.cardDoanhThu.Depth = 0;
            this.cardDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardDoanhThu.Location = new System.Drawing.Point(24, 100);
            this.cardDoanhThu.Margin = new System.Windows.Forms.Padding(14);
            this.cardDoanhThu.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardDoanhThu.Name = "cardDoanhThu";
            this.cardDoanhThu.Padding = new System.Windows.Forms.Padding(14);
            this.cardDoanhThu.Size = new System.Drawing.Size(220, 110);
            this.cardDoanhThu.TabIndex = 1;

            this.lblDoanhThuTitle.AutoSize = true;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Inter", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(14, 14);
            this.lblDoanhThuTitle.Name = "lblDoanhThuTitle";
            this.lblDoanhThuTitle.Size = new System.Drawing.Size(117, 19);
            this.lblDoanhThuTitle.TabIndex = 0;
            this.lblDoanhThuTitle.Text = "Doanh thu tháng";

            this.lblDoanhThuValue.AutoSize = true;
            this.lblDoanhThuValue.Font = new System.Drawing.Font("Inter", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuValue.Location = new System.Drawing.Point(14, 40);
            this.lblDoanhThuValue.Name = "lblDoanhThuValue";
            this.lblDoanhThuValue.Size = new System.Drawing.Size(32, 33);
            this.lblDoanhThuValue.TabIndex = 1;
            this.lblDoanhThuValue.Text = "0";

            this.lblDoanhThuSub.AutoSize = true;
            this.lblDoanhThuSub.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuSub.Location = new System.Drawing.Point(14, 80);
            this.lblDoanhThuSub.Name = "lblDoanhThuSub";
            this.lblDoanhThuSub.Size = new System.Drawing.Size(16, 15);
            this.lblDoanhThuSub.TabIndex = 2;
            this.lblDoanhThuSub.Text = "...";

            // cardGioMay
            this.cardGioMay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardGioMay.Controls.Add(this.lblGioMayTitle);
            this.cardGioMay.Controls.Add(this.lblGioMayValue);
            this.cardGioMay.Controls.Add(this.lblGioMaySub);
            this.cardGioMay.Depth = 0;
            this.cardGioMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardGioMay.Location = new System.Drawing.Point(268, 100);
            this.cardGioMay.Margin = new System.Windows.Forms.Padding(14);
            this.cardGioMay.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardGioMay.Name = "cardGioMay";
            this.cardGioMay.Padding = new System.Windows.Forms.Padding(14);
            this.cardGioMay.Size = new System.Drawing.Size(220, 110);
            this.cardGioMay.TabIndex = 2;

            this.lblGioMayTitle.AutoSize = true;
            this.lblGioMayTitle.Font = new System.Drawing.Font("Inter", 10F);
            this.lblGioMayTitle.Location = new System.Drawing.Point(14, 14);
            this.lblGioMayTitle.Name = "lblGioMayTitle";
            this.lblGioMayTitle.Size = new System.Drawing.Size(95, 19);
            this.lblGioMayTitle.TabIndex = 0;
            this.lblGioMayTitle.Text = "Tổng giờ máy";

            this.lblGioMayValue.AutoSize = true;
            this.lblGioMayValue.Font = new System.Drawing.Font("Inter", 20F, System.Drawing.FontStyle.Bold);
            this.lblGioMayValue.Location = new System.Drawing.Point(14, 40);
            this.lblGioMayValue.Name = "lblGioMayValue";
            this.lblGioMayValue.Size = new System.Drawing.Size(32, 33);
            this.lblGioMayValue.TabIndex = 1;
            this.lblGioMayValue.Text = "0";

            this.lblGioMaySub.AutoSize = true;
            this.lblGioMaySub.Font = new System.Drawing.Font("Inter", 9F);
            this.lblGioMaySub.Location = new System.Drawing.Point(14, 80);
            this.lblGioMaySub.Name = "lblGioMaySub";
            this.lblGioMaySub.Size = new System.Drawing.Size(16, 15);
            this.lblGioMaySub.TabIndex = 2;
            this.lblGioMaySub.Text = "...";

            // cardMayHoatDong
            this.cardMayHoatDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardMayHoatDong.Controls.Add(this.lblMayHoatDongTitle);
            this.cardMayHoatDong.Controls.Add(this.lblMayHoatDongValue);
            this.cardMayHoatDong.Controls.Add(this.lblMayHoatDongSub);
            this.cardMayHoatDong.Depth = 0;
            this.cardMayHoatDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardMayHoatDong.Location = new System.Drawing.Point(512, 100);
            this.cardMayHoatDong.Margin = new System.Windows.Forms.Padding(14);
            this.cardMayHoatDong.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardMayHoatDong.Name = "cardMayHoatDong";
            this.cardMayHoatDong.Padding = new System.Windows.Forms.Padding(14);
            this.cardMayHoatDong.Size = new System.Drawing.Size(220, 110);
            this.cardMayHoatDong.TabIndex = 3;

            this.lblMayHoatDongTitle.AutoSize = true;
            this.lblMayHoatDongTitle.Font = new System.Drawing.Font("Inter", 10F);
            this.lblMayHoatDongTitle.Location = new System.Drawing.Point(14, 14);
            this.lblMayHoatDongTitle.Name = "lblMayHoatDongTitle";
            this.lblMayHoatDongTitle.Size = new System.Drawing.Size(107, 19);
            this.lblMayHoatDongTitle.TabIndex = 0;
            this.lblMayHoatDongTitle.Text = "Máy hoạt động";

            this.lblMayHoatDongValue.AutoSize = true;
            this.lblMayHoatDongValue.Font = new System.Drawing.Font("Inter", 20F, System.Drawing.FontStyle.Bold);
            this.lblMayHoatDongValue.Location = new System.Drawing.Point(14, 40);
            this.lblMayHoatDongValue.Name = "lblMayHoatDongValue";
            this.lblMayHoatDongValue.Size = new System.Drawing.Size(32, 33);
            this.lblMayHoatDongValue.TabIndex = 1;
            this.lblMayHoatDongValue.Text = "0";

            this.lblMayHoatDongSub.AutoSize = true;
            this.lblMayHoatDongSub.Font = new System.Drawing.Font("Inter", 9F);
            this.lblMayHoatDongSub.Location = new System.Drawing.Point(14, 80);
            this.lblMayHoatDongSub.Name = "lblMayHoatDongSub";
            this.lblMayHoatDongSub.Size = new System.Drawing.Size(16, 15);
            this.lblMayHoatDongSub.TabIndex = 2;
            this.lblMayHoatDongSub.Text = "...";

            // cardHoiVienMoi
            this.cardHoiVienMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardHoiVienMoi.Controls.Add(this.lblHoiVienMoiTitle);
            this.cardHoiVienMoi.Controls.Add(this.lblHoiVienMoiValue);
            this.cardHoiVienMoi.Controls.Add(this.lblHoiVienMoiSub);
            this.cardHoiVienMoi.Depth = 0;
            this.cardHoiVienMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardHoiVienMoi.Location = new System.Drawing.Point(756, 100);
            this.cardHoiVienMoi.Margin = new System.Windows.Forms.Padding(14);
            this.cardHoiVienMoi.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardHoiVienMoi.Name = "cardHoiVienMoi";
            this.cardHoiVienMoi.Padding = new System.Windows.Forms.Padding(14);
            this.cardHoiVienMoi.Size = new System.Drawing.Size(220, 110);
            this.cardHoiVienMoi.TabIndex = 4;

            this.lblHoiVienMoiTitle.AutoSize = true;
            this.lblHoiVienMoiTitle.Font = new System.Drawing.Font("Inter", 10F);
            this.lblHoiVienMoiTitle.Location = new System.Drawing.Point(14, 14);
            this.lblHoiVienMoiTitle.Name = "lblHoiVienMoiTitle";
            this.lblHoiVienMoiTitle.Size = new System.Drawing.Size(89, 19);
            this.lblHoiVienMoiTitle.TabIndex = 0;
            this.lblHoiVienMoiTitle.Text = "Hội viên mới";

            this.lblHoiVienMoiValue.AutoSize = true;
            this.lblHoiVienMoiValue.Font = new System.Drawing.Font("Inter", 20F, System.Drawing.FontStyle.Bold);
            this.lblHoiVienMoiValue.Location = new System.Drawing.Point(14, 40);
            this.lblHoiVienMoiValue.Name = "lblHoiVienMoiValue";
            this.lblHoiVienMoiValue.Size = new System.Drawing.Size(32, 33);
            this.lblHoiVienMoiValue.TabIndex = 1;
            this.lblHoiVienMoiValue.Text = "0";

            this.lblHoiVienMoiSub.AutoSize = true;
            this.lblHoiVienMoiSub.Font = new System.Drawing.Font("Inter", 9F);
            this.lblHoiVienMoiSub.Location = new System.Drawing.Point(14, 80);
            this.lblHoiVienMoiSub.Name = "lblHoiVienMoiSub";
            this.lblHoiVienMoiSub.Size = new System.Drawing.Size(16, 15);
            this.lblHoiVienMoiSub.TabIndex = 2;
            this.lblHoiVienMoiSub.Text = "...";

            // tabSelector
            this.tabSelector.BaseTabControl = this.mainTabControl;
            this.tabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.tabSelector.Depth = 0;
            this.tabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSelector.Location = new System.Drawing.Point(24, 230);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(952, 48);
            this.tabSelector.TabIndex = 5;

            // mainTabControl
            this.mainTabControl.Controls.Add(this.tabDoanhThu);
            this.mainTabControl.Controls.Add(this.tabMayTinh);
            this.mainTabControl.Controls.Add(this.tabHoiVien);
            this.mainTabControl.Depth = 0;
            this.mainTabControl.Location = new System.Drawing.Point(24, 286);
            this.mainTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(952, 450);
            this.mainTabControl.TabIndex = 6;

            // tabDoanhThu
            this.tabDoanhThu.BackColor = System.Drawing.Color.White;
            this.tabDoanhThu.Controls.Add(this.cardChartDoanhThu);
            this.tabDoanhThu.Controls.Add(this.cardChartCoCau);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 22);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThu.Size = new System.Drawing.Size(944, 424);
            this.tabDoanhThu.TabIndex = 0;
            this.tabDoanhThu.Text = "Doanh thu";

            // cardChartDoanhThu
            this.cardChartDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardChartDoanhThu.Controls.Add(this.lblChartDoanhThuTitle);
            this.cardChartDoanhThu.Controls.Add(this.chartDoanhThu);
            this.cardChartDoanhThu.Depth = 0;
            this.cardChartDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardChartDoanhThu.Location = new System.Drawing.Point(14, 14);
            this.cardChartDoanhThu.Margin = new System.Windows.Forms.Padding(14);
            this.cardChartDoanhThu.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardChartDoanhThu.Name = "cardChartDoanhThu";
            this.cardChartDoanhThu.Padding = new System.Windows.Forms.Padding(14);
            this.cardChartDoanhThu.Size = new System.Drawing.Size(450, 396);
            this.cardChartDoanhThu.TabIndex = 0;

            this.lblChartDoanhThuTitle.AutoSize = true;
            this.lblChartDoanhThuTitle.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartDoanhThuTitle.Location = new System.Drawing.Point(14, 14);
            this.lblChartDoanhThuTitle.Name = "lblChartDoanhThuTitle";
            this.lblChartDoanhThuTitle.Size = new System.Drawing.Size(341, 19);
            this.lblChartDoanhThuTitle.TabIndex = 0;
            this.lblChartDoanhThuTitle.Text = "Doanh thu theo ngày (LiveCharts - ColumnSeries)";

            this.chartDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartDoanhThu.Location = new System.Drawing.Point(14, 40);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(422, 342);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "cartesianChart1";

            // cardChartCoCau
            this.cardChartCoCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardChartCoCau.Controls.Add(this.lblChartCoCauTitle);
            this.cardChartCoCau.Controls.Add(this.chartCoCau);
            this.cardChartCoCau.Depth = 0;
            this.cardChartCoCau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardChartCoCau.Location = new System.Drawing.Point(480, 14);
            this.cardChartCoCau.Margin = new System.Windows.Forms.Padding(14);
            this.cardChartCoCau.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardChartCoCau.Name = "cardChartCoCau";
            this.cardChartCoCau.Padding = new System.Windows.Forms.Padding(14);
            this.cardChartCoCau.Size = new System.Drawing.Size(450, 396);
            this.cardChartCoCau.TabIndex = 1;

            this.lblChartCoCauTitle.AutoSize = true;
            this.lblChartCoCauTitle.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartCoCauTitle.Location = new System.Drawing.Point(14, 14);
            this.lblChartCoCauTitle.Name = "lblChartCoCauTitle";
            this.lblChartCoCauTitle.Size = new System.Drawing.Size(315, 19);
            this.lblChartCoCauTitle.TabIndex = 0;
            this.lblChartCoCauTitle.Text = "Cơ cấu doanh thu (LiveCharts - PieSeries)";

            this.chartCoCau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartCoCau.Location = new System.Drawing.Point(14, 40);
            this.chartCoCau.Name = "chartCoCau";
            this.chartCoCau.Size = new System.Drawing.Size(422, 342);
            this.chartCoCau.TabIndex = 1;
            this.chartCoCau.Text = "pieChart1";

            // tabMayTinh
            this.tabMayTinh.BackColor = System.Drawing.Color.White;
            this.tabMayTinh.Controls.Add(this.cardTot);
            this.tabMayTinh.Controls.Add(this.cardDaSua);
            this.tabMayTinh.Controls.Add(this.cardHong);
            this.tabMayTinh.Controls.Add(this.cardChartGioMay);
            this.tabMayTinh.Location = new System.Drawing.Point(4, 22);
            this.tabMayTinh.Name = "tabMayTinh";
            this.tabMayTinh.Padding = new System.Windows.Forms.Padding(3);
            this.tabMayTinh.Size = new System.Drawing.Size(944, 424);
            this.tabMayTinh.TabIndex = 1;
            this.tabMayTinh.Text = "Máy tính";

            // cardTot
            this.cardTot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardTot.Controls.Add(this.lblTot);
            this.cardTot.Depth = 0;
            this.cardTot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardTot.Location = new System.Drawing.Point(14, 14);
            this.cardTot.Margin = new System.Windows.Forms.Padding(14);
            this.cardTot.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardTot.Name = "cardTot";
            this.cardTot.Padding = new System.Windows.Forms.Padding(14);
            this.cardTot.Size = new System.Drawing.Size(200, 80);
            this.cardTot.TabIndex = 0;

            this.lblTot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTot.Font = new System.Drawing.Font("Inter", 14F, System.Drawing.FontStyle.Bold);
            this.lblTot.Location = new System.Drawing.Point(14, 14);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(172, 52);
            this.lblTot.TabIndex = 0;
            this.lblTot.Text = "Tốt";
            this.lblTot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // cardDaSua
            this.cardDaSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardDaSua.Controls.Add(this.lblDaSua);
            this.cardDaSua.Depth = 0;
            this.cardDaSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardDaSua.Location = new System.Drawing.Point(230, 14);
            this.cardDaSua.Margin = new System.Windows.Forms.Padding(14);
            this.cardDaSua.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardDaSua.Name = "cardDaSua";
            this.cardDaSua.Padding = new System.Windows.Forms.Padding(14);
            this.cardDaSua.Size = new System.Drawing.Size(200, 80);
            this.cardDaSua.TabIndex = 1;

            this.lblDaSua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDaSua.Font = new System.Drawing.Font("Inter", 14F, System.Drawing.FontStyle.Bold);
            this.lblDaSua.Location = new System.Drawing.Point(14, 14);
            this.lblDaSua.Name = "lblDaSua";
            this.lblDaSua.Size = new System.Drawing.Size(172, 52);
            this.lblDaSua.TabIndex = 0;
            this.lblDaSua.Text = "Đã sửa";
            this.lblDaSua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // cardHong
            this.cardHong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardHong.Controls.Add(this.lblHong);
            this.cardHong.Depth = 0;
            this.cardHong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardHong.Location = new System.Drawing.Point(446, 14);
            this.cardHong.Margin = new System.Windows.Forms.Padding(14);
            this.cardHong.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardHong.Name = "cardHong";
            this.cardHong.Padding = new System.Windows.Forms.Padding(14);
            this.cardHong.Size = new System.Drawing.Size(200, 80);
            this.cardHong.TabIndex = 2;

            this.lblHong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHong.Font = new System.Drawing.Font("Inter", 14F, System.Drawing.FontStyle.Bold);
            this.lblHong.Location = new System.Drawing.Point(14, 14);
            this.lblHong.Name = "lblHong";
            this.lblHong.Size = new System.Drawing.Size(172, 52);
            this.lblHong.TabIndex = 0;
            this.lblHong.Text = "Hỏng";
            this.lblHong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // cardChartGioMay
            this.cardChartGioMay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardChartGioMay.Controls.Add(this.lblChartGioMayTitle);
            this.cardChartGioMay.Controls.Add(this.chartGioMay);
            this.cardChartGioMay.Depth = 0;
            this.cardChartGioMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardChartGioMay.Location = new System.Drawing.Point(14, 108);
            this.cardChartGioMay.Margin = new System.Windows.Forms.Padding(14);
            this.cardChartGioMay.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardChartGioMay.Name = "cardChartGioMay";
            this.cardChartGioMay.Padding = new System.Windows.Forms.Padding(14);
            this.cardChartGioMay.Size = new System.Drawing.Size(916, 302);
            this.cardChartGioMay.TabIndex = 3;

            this.lblChartGioMayTitle.AutoSize = true;
            this.lblChartGioMayTitle.Font = new System.Drawing.Font("Inter", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartGioMayTitle.Location = new System.Drawing.Point(14, 14);
            this.lblChartGioMayTitle.Name = "lblChartGioMayTitle";
            this.lblChartGioMayTitle.Size = new System.Drawing.Size(262, 19);
            this.lblChartGioMayTitle.TabIndex = 0;
            this.lblChartGioMayTitle.Text = "Biểu đồ giờ máy (LiveCharts - RowSeries)";

            this.chartGioMay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartGioMay.Location = new System.Drawing.Point(14, 40);
            this.chartGioMay.Name = "chartGioMay";
            this.chartGioMay.Size = new System.Drawing.Size(888, 248);
            this.chartGioMay.TabIndex = 1;
            this.chartGioMay.Text = "cartesianChart2";

            // tabHoiVien
            this.tabHoiVien.BackColor = System.Drawing.Color.White;
            this.tabHoiVien.Controls.Add(this.cardHoiVien);
            this.tabHoiVien.Location = new System.Drawing.Point(4, 22);
            this.tabHoiVien.Name = "tabHoiVien";
            this.tabHoiVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabHoiVien.Size = new System.Drawing.Size(944, 424);
            this.tabHoiVien.TabIndex = 2;
            this.tabHoiVien.Text = "Hội viên";

            // cardHoiVien
            this.cardHoiVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardHoiVien.Controls.Add(this.lvHoiVien);
            this.cardHoiVien.Depth = 0;
            this.cardHoiVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardHoiVien.Location = new System.Drawing.Point(14, 14);
            this.cardHoiVien.Margin = new System.Windows.Forms.Padding(14);
            this.cardHoiVien.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardHoiVien.Name = "cardHoiVien";
            this.cardHoiVien.Padding = new System.Windows.Forms.Padding(14);
            this.cardHoiVien.Size = new System.Drawing.Size(916, 396);
            this.cardHoiVien.TabIndex = 0;

            // lvHoiVien
            this.lvHoiVien.AutoSizeTable = false;
            this.lvHoiVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvHoiVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvHoiVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStt,
            this.colTen,
            this.colChiTieu,
            this.colGio,
            this.colNap});
            this.lvHoiVien.Depth = 0;
            this.lvHoiVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHoiVien.Font = new System.Drawing.Font("Inter", 11F);
            this.lvHoiVien.FullRowSelect = true;
            this.lvHoiVien.HideSelection = false;
            this.lvHoiVien.Location = new System.Drawing.Point(14, 14);
            this.lvHoiVien.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvHoiVien.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvHoiVien.MouseState = MaterialSkin.MouseState.OUT;
            this.lvHoiVien.Name = "lvHoiVien";
            this.lvHoiVien.OwnerDraw = true;
            this.lvHoiVien.Size = new System.Drawing.Size(888, 368);
            this.lvHoiVien.TabIndex = 0;
            this.lvHoiVien.UseCompatibleStateImageBehavior = false;
            this.lvHoiVien.View = System.Windows.Forms.View.Details;

            // colStt
            this.colStt.Text = "#";
            this.colStt.Width = 50;

            // colTen
            this.colTen.Text = "Tên";
            this.colTen.Width = 200;

            // colChiTieu
            this.colChiTieu.Text = "Chi tiêu";
            this.colChiTieu.Width = 150;

            // colGio
            this.colGio.Text = "Giờ";
            this.colGio.Width = 100;

            // colNap
            this.colNap.Text = "Nạp";
            this.colNap.Width = 150;

            // frmReport
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.cardHoiVienMoi);
            this.Controls.Add(this.cardMayHoatDong);
            this.Controls.Add(this.cardGioMay);
            this.Controls.Add(this.cardDoanhThu);
            this.Controls.Add(this.pnlFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReport";
            this.Text = "Báo cáo & Thống kê";
            
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.cardDoanhThu.ResumeLayout(false);
            this.cardDoanhThu.PerformLayout();
            this.cardGioMay.ResumeLayout(false);
            this.cardGioMay.PerformLayout();
            this.cardMayHoatDong.ResumeLayout(false);
            this.cardMayHoatDong.PerformLayout();
            this.cardHoiVienMoi.ResumeLayout(false);
            this.cardHoiVienMoi.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            this.tabMayTinh.ResumeLayout(false);
            this.tabHoiVien.ResumeLayout(false);
            this.cardChartDoanhThu.ResumeLayout(false);
            this.cardChartDoanhThu.PerformLayout();
            this.cardChartCoCau.ResumeLayout(false);
            this.cardChartCoCau.PerformLayout();
            this.cardTot.ResumeLayout(false);
            this.cardDaSua.ResumeLayout(false);
            this.cardHong.ResumeLayout(false);
            this.cardChartGioMay.ResumeLayout(false);
            this.cardChartGioMay.PerformLayout();
            this.cardHoiVien.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblKyBaoCao;
        private MaterialSkin.Controls.MaterialComboBox cboKyBaoCao;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private MaterialSkin.Controls.MaterialButton btnXem;
        private MaterialSkin.Controls.MaterialButton btnXuatExcel;
        private MaterialSkin.Controls.MaterialButton btnIn;
        
        private MaterialSkin.Controls.MaterialCard cardDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private System.Windows.Forms.Label lblDoanhThuSub;
        
        private MaterialSkin.Controls.MaterialCard cardGioMay;
        private System.Windows.Forms.Label lblGioMayTitle;
        private System.Windows.Forms.Label lblGioMayValue;
        private System.Windows.Forms.Label lblGioMaySub;
        
        private MaterialSkin.Controls.MaterialCard cardMayHoatDong;
        private System.Windows.Forms.Label lblMayHoatDongTitle;
        private System.Windows.Forms.Label lblMayHoatDongValue;
        private System.Windows.Forms.Label lblMayHoatDongSub;
        
        private MaterialSkin.Controls.MaterialCard cardHoiVienMoi;
        private System.Windows.Forms.Label lblHoiVienMoiTitle;
        private System.Windows.Forms.Label lblHoiVienMoiValue;
        private System.Windows.Forms.Label lblHoiVienMoiSub;
        
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private MaterialSkin.Controls.MaterialTabControl mainTabControl;
        
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.TabPage tabMayTinh;
        private System.Windows.Forms.TabPage tabHoiVien;
        
        private MaterialSkin.Controls.MaterialCard cardChartDoanhThu;
        private System.Windows.Forms.Label lblChartDoanhThuTitle;
        private LiveCharts.WinForms.CartesianChart chartDoanhThu;
        
        private MaterialSkin.Controls.MaterialCard cardChartCoCau;
        private System.Windows.Forms.Label lblChartCoCauTitle;
        private LiveCharts.WinForms.PieChart chartCoCau;
        
        private MaterialSkin.Controls.MaterialCard cardTot;
        private System.Windows.Forms.Label lblTot;
        private MaterialSkin.Controls.MaterialCard cardDaSua;
        private System.Windows.Forms.Label lblDaSua;
        private MaterialSkin.Controls.MaterialCard cardHong;
        private System.Windows.Forms.Label lblHong;
        private MaterialSkin.Controls.MaterialCard cardChartGioMay;
        private System.Windows.Forms.Label lblChartGioMayTitle;
        private LiveCharts.WinForms.CartesianChart chartGioMay;
        
        private MaterialSkin.Controls.MaterialCard cardHoiVien;
        private MaterialSkin.Controls.MaterialListView lvHoiVien;
        private System.Windows.Forms.ColumnHeader colStt;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colChiTieu;
        private System.Windows.Forms.ColumnHeader colGio;
        private System.Windows.Forms.ColumnHeader colNap;
    }
}
