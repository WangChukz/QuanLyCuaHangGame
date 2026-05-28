using MaterialSkin.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangGame
{
    partial class frmPayment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gbPhien = new System.Windows.Forms.GroupBox();
            this.lblMayLabel = new System.Windows.Forms.Label();
            this.lblMayValue = new System.Windows.Forms.Label();
            this.lblBatDauLabel = new System.Windows.Forms.Label();
            this.lblBatDauValue = new System.Windows.Forms.Label();
            this.lblKetThucLabel = new System.Windows.Forms.Label();
            this.lblKetThucValue = new System.Windows.Forms.Label();
            this.lblThoiGianLabel = new System.Windows.Forms.Label();
            this.lblThoiGianValue = new System.Windows.Forms.Label();
            this.gbHoiVien = new System.Windows.Forms.GroupBox();
            this.lblTenLabel = new System.Windows.Forms.Label();
            this.lblTenValue = new System.Windows.Forms.Label();
            this.lblSDTLabel = new System.Windows.Forms.Label();
            this.lblSDTValue = new System.Windows.Forms.Label();
            this.lblSoDuLabel = new System.Windows.Forms.Label();
            this.lblSoDuValue = new System.Windows.Forms.Label();
            this.lblSoDuSauLabel = new System.Windows.Forms.Label();
            this.lblSoDuSauValue = new System.Windows.Forms.Label();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.lvHoaDon = new MaterialSkin.Controls.MaterialListView();
            this.colKhoan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTongTienLabel = new MaterialSkin.Controls.MaterialLabel();
            this.lblTongTienValue = new MaterialSkin.Controls.MaterialLabel();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.lblTruViLabel = new System.Windows.Forms.Label();
            this.txtViHoiVien = new MaterialSkin.Controls.MaterialTextBox();
            this.lblTienMatLabel = new System.Windows.Forms.Label();
            this.txtTienMat = new MaterialSkin.Controls.MaterialTextBox();
            this.cardStatus = new MaterialSkin.Controls.MaterialCard();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnXacNhan = new MaterialSkin.Controls.MaterialButton();
            this.btnInHoaDon = new MaterialSkin.Controls.MaterialButton();
            this.btnHuy = new MaterialSkin.Controls.MaterialButton();
            this.gbPhien.SuspendLayout();
            this.gbHoiVien.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            this.gbThanhToan.SuspendLayout();
            this.cardStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPhien
            // 
            this.gbPhien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPhien.Controls.Add(this.lblMayLabel);
            this.gbPhien.Controls.Add(this.lblMayValue);
            this.gbPhien.Controls.Add(this.lblBatDauLabel);
            this.gbPhien.Controls.Add(this.lblBatDauValue);
            this.gbPhien.Controls.Add(this.lblKetThucLabel);
            this.gbPhien.Controls.Add(this.lblKetThucValue);
            this.gbPhien.Controls.Add(this.lblThoiGianLabel);
            this.gbPhien.Controls.Add(this.lblThoiGianValue);
            this.gbPhien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gbPhien.ForeColor = System.Drawing.Color.Gray;
            this.gbPhien.Location = new System.Drawing.Point(18, 76);
            this.gbPhien.Name = "gbPhien";
            this.gbPhien.Size = new System.Drawing.Size(444, 160);
            this.gbPhien.TabIndex = 0;
            this.gbPhien.TabStop = false;
            this.gbPhien.Text = "Thông tin phiên";
            // 
            // lblMayLabel
            // 
            this.lblMayLabel.AutoSize = true;
            this.lblMayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblMayLabel.Location = new System.Drawing.Point(20, 35);
            this.lblMayLabel.Name = "lblMayLabel";
            this.lblMayLabel.Size = new System.Drawing.Size(69, 21);
            this.lblMayLabel.TabIndex = 0;
            this.lblMayLabel.Text = "💻 Máy:";
            // 
            // lblMayValue
            // 
            this.lblMayValue.AutoSize = true;
            this.lblMayValue.ForeColor = System.Drawing.Color.Black;
            this.lblMayValue.Location = new System.Drawing.Point(95, 35);
            this.lblMayValue.Name = "lblMayValue";
            this.lblMayValue.Size = new System.Drawing.Size(172, 21);
            this.lblMayValue.TabIndex = 1;
            this.lblMayValue.Text = "PC05 – VIP (30,000đ/h)";
            // 
            // lblBatDauLabel
            // 
            this.lblBatDauLabel.AutoSize = true;
            this.lblBatDauLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblBatDauLabel.Location = new System.Drawing.Point(20, 65);
            this.lblBatDauLabel.Name = "lblBatDauLabel";
            this.lblBatDauLabel.Size = new System.Drawing.Size(83, 21);
            this.lblBatDauLabel.TabIndex = 2;
            this.lblBatDauLabel.Text = "▶ Bắt đầu:";
            // 
            // lblBatDauValue
            // 
            this.lblBatDauValue.AutoSize = true;
            this.lblBatDauValue.ForeColor = System.Drawing.Color.Black;
            this.lblBatDauValue.Location = new System.Drawing.Point(109, 65);
            this.lblBatDauValue.Name = "lblBatDauValue";
            this.lblBatDauValue.Size = new System.Drawing.Size(70, 21);
            this.lblBatDauValue.TabIndex = 3;
            this.lblBatDauValue.Text = "14:30:00";
            // 
            // lblKetThucLabel
            // 
            this.lblKetThucLabel.AutoSize = true;
            this.lblKetThucLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblKetThucLabel.Location = new System.Drawing.Point(20, 95);
            this.lblKetThucLabel.Name = "lblKetThucLabel";
            this.lblKetThucLabel.Size = new System.Drawing.Size(87, 21);
            this.lblKetThucLabel.TabIndex = 4;
            this.lblKetThucLabel.Text = "■ Kết thúc:";
            // 
            // lblKetThucValue
            // 
            this.lblKetThucValue.AutoSize = true;
            this.lblKetThucValue.ForeColor = System.Drawing.Color.Black;
            this.lblKetThucValue.Location = new System.Drawing.Point(113, 95);
            this.lblKetThucValue.Name = "lblKetThucValue";
            this.lblKetThucValue.Size = new System.Drawing.Size(174, 21);
            this.lblKetThucValue.TabIndex = 5;
            this.lblKetThucValue.Text = "16:15:00 (ngay bây giờ)";
            // 
            // lblThoiGianLabel
            // 
            this.lblThoiGianLabel.AutoSize = true;
            this.lblThoiGianLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblThoiGianLabel.Location = new System.Drawing.Point(20, 125);
            this.lblThoiGianLabel.Name = "lblThoiGianLabel";
            this.lblThoiGianLabel.Size = new System.Drawing.Size(104, 21);
            this.lblThoiGianLabel.TabIndex = 6;
            this.lblThoiGianLabel.Text = "⏱ Thời gian:";
            // 
            // lblThoiGianValue
            // 
            this.lblThoiGianValue.AutoSize = true;
            this.lblThoiGianValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblThoiGianValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblThoiGianValue.Location = new System.Drawing.Point(130, 125);
            this.lblThoiGianValue.Name = "lblThoiGianValue";
            this.lblThoiGianValue.Size = new System.Drawing.Size(110, 21);
            this.lblThoiGianValue.TabIndex = 7;
            this.lblThoiGianValue.Text = "1 giờ 45 phút";
            // 
            // gbHoiVien
            // 
            this.gbHoiVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHoiVien.Controls.Add(this.lblTenLabel);
            this.gbHoiVien.Controls.Add(this.lblTenValue);
            this.gbHoiVien.Controls.Add(this.lblSDTLabel);
            this.gbHoiVien.Controls.Add(this.lblSDTValue);
            this.gbHoiVien.Controls.Add(this.lblSoDuLabel);
            this.gbHoiVien.Controls.Add(this.lblSoDuValue);
            this.gbHoiVien.Controls.Add(this.lblSoDuSauLabel);
            this.gbHoiVien.Controls.Add(this.lblSoDuSauValue);
            this.gbHoiVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gbHoiVien.ForeColor = System.Drawing.Color.Gray;
            this.gbHoiVien.Location = new System.Drawing.Point(479, 76);
            this.gbHoiVien.Name = "gbHoiVien";
            this.gbHoiVien.Size = new System.Drawing.Size(350, 160);
            this.gbHoiVien.TabIndex = 1;
            this.gbHoiVien.TabStop = false;
            this.gbHoiVien.Text = "Hội viên";
            // 
            // lblTenLabel
            // 
            this.lblTenLabel.AutoSize = true;
            this.lblTenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTenLabel.Location = new System.Drawing.Point(20, 35);
            this.lblTenLabel.Name = "lblTenLabel";
            this.lblTenLabel.Size = new System.Drawing.Size(32, 21);
            this.lblTenLabel.TabIndex = 0;
            this.lblTenLabel.Text = "👤";
            // 
            // lblTenValue
            // 
            this.lblTenValue.AutoSize = true;
            this.lblTenValue.ForeColor = System.Drawing.Color.Black;
            this.lblTenValue.Location = new System.Drawing.Point(55, 35);
            this.lblTenValue.Name = "lblTenValue";
            this.lblTenValue.Size = new System.Drawing.Size(123, 21);
            this.lblTenValue.TabIndex = 1;
            this.lblTenValue.Text = "Phạm Quốc Huy";
            // 
            // lblSDTLabel
            // 
            this.lblSDTLabel.AutoSize = true;
            this.lblSDTLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblSDTLabel.Location = new System.Drawing.Point(20, 65);
            this.lblSDTLabel.Name = "lblSDTLabel";
            this.lblSDTLabel.Size = new System.Drawing.Size(32, 21);
            this.lblSDTLabel.TabIndex = 2;
            this.lblSDTLabel.Text = "📞";
            // 
            // lblSDTValue
            // 
            this.lblSDTValue.AutoSize = true;
            this.lblSDTValue.ForeColor = System.Drawing.Color.Black;
            this.lblSDTValue.Location = new System.Drawing.Point(55, 65);
            this.lblSDTValue.Name = "lblSDTValue";
            this.lblSDTValue.Size = new System.Drawing.Size(108, 21);
            this.lblSDTValue.TabIndex = 3;
            this.lblSDTValue.Text = "0912 345 678";
            // 
            // lblSoDuLabel
            // 
            this.lblSoDuLabel.AutoSize = true;
            this.lblSoDuLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblSoDuLabel.Location = new System.Drawing.Point(20, 95);
            this.lblSoDuLabel.Name = "lblSoDuLabel";
            this.lblSoDuLabel.Size = new System.Drawing.Size(32, 21);
            this.lblSoDuLabel.TabIndex = 4;
            this.lblSoDuLabel.Text = "💳";
            // 
            // lblSoDuValue
            // 
            this.lblSoDuValue.AutoSize = true;
            this.lblSoDuValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoDuValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblSoDuValue.Location = new System.Drawing.Point(55, 95);
            this.lblSoDuValue.Name = "lblSoDuValue";
            this.lblSoDuValue.Size = new System.Drawing.Size(192, 21);
            this.lblSoDuValue.TabIndex = 5;
            this.lblSoDuValue.Text = "Số dư hiện tại: 150,000đ";
            // 
            // lblSoDuSauLabel
            // 
            this.lblSoDuSauLabel.AutoSize = true;
            this.lblSoDuSauLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblSoDuSauLabel.Location = new System.Drawing.Point(20, 125);
            this.lblSoDuSauLabel.Name = "lblSoDuSauLabel";
            this.lblSoDuSauLabel.Size = new System.Drawing.Size(32, 21);
            this.lblSoDuSauLabel.TabIndex = 6;
            this.lblSoDuSauLabel.Text = "💳";
            // 
            // lblSoDuSauValue
            // 
            this.lblSoDuSauValue.AutoSize = true;
            this.lblSoDuSauValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoDuSauValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblSoDuSauValue.Location = new System.Drawing.Point(55, 125);
            this.lblSoDuSauValue.Name = "lblSoDuSauValue";
            this.lblSoDuSauValue.Size = new System.Drawing.Size(173, 21);
            this.lblSoDuSauValue.TabIndex = 7;
            this.lblSoDuSauValue.Text = "Số dư sau TT: 62,500đ";
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChiTiet.Controls.Add(this.lvHoaDon);
            this.gbChiTiet.Controls.Add(this.lblTongTienLabel);
            this.gbChiTiet.Controls.Add(this.lblTongTienValue);
            this.gbChiTiet.Controls.Add(this.pnlDivider);
            this.gbChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gbChiTiet.ForeColor = System.Drawing.Color.Gray;
            this.gbChiTiet.Location = new System.Drawing.Point(18, 250);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(811, 240);
            this.gbChiTiet.TabIndex = 2;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Chi tiết hóa đơn";
            // 
            // lvHoaDon
            // 
            this.lvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHoaDon.AutoSizeTable = false;
            this.lvHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKhoan,
            this.colThanhTien});
            this.lvHoaDon.Depth = 0;
            this.lvHoaDon.FullRowSelect = true;
            this.lvHoaDon.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvHoaDon.HideSelection = false;
            this.lvHoaDon.Location = new System.Drawing.Point(10, 25);
            this.lvHoaDon.MinimumSize = new System.Drawing.Size(200, 100);
            this.lvHoaDon.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvHoaDon.MouseState = MaterialSkin.MouseState.OUT;
            this.lvHoaDon.Name = "lvHoaDon";
            this.lvHoaDon.OwnerDraw = true;
            this.lvHoaDon.Size = new System.Drawing.Size(791, 150);
            this.lvHoaDon.TabIndex = 0;
            this.lvHoaDon.UseCompatibleStateImageBehavior = false;
            this.lvHoaDon.View = System.Windows.Forms.View.Details;
            // 
            // colKhoan
            // 
            this.colKhoan.Text = "Khoản";
            this.colKhoan.Width = 550;
            // 
            // colThanhTien
            // 
            this.colThanhTien.Text = "Thành tiền";
            this.colThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colThanhTien.Width = 140;
            // 
            // lblTongTienLabel
            // 
            this.lblTongTienLabel.AutoSize = true;
            this.lblTongTienLabel.Depth = 0;
            this.lblTongTienLabel.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTongTienLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTongTienLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTongTienLabel.Location = new System.Drawing.Point(15, 195);
            this.lblTongTienLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTongTienLabel.Name = "lblTongTienLabel";
            this.lblTongTienLabel.Size = new System.Drawing.Size(137, 29);
            this.lblTongTienLabel.TabIndex = 1;
            this.lblTongTienLabel.Text = "TỔNG CỘNG";
            // 
            // lblTongTienValue
            // 
            this.lblTongTienValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienValue.AutoSize = true;
            this.lblTongTienValue.Depth = 0;
            this.lblTongTienValue.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTongTienValue.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTongTienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTongTienValue.Location = new System.Drawing.Point(714, 195);
            this.lblTongTienValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTongTienValue.Name = "lblTongTienValue";
            this.lblTongTienValue.Size = new System.Drawing.Size(85, 29);
            this.lblTongTienValue.TabIndex = 2;
            this.lblTongTienValue.Text = "87,500đ";
            this.lblTongTienValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlDivider
            // 
            this.pnlDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.pnlDivider.Location = new System.Drawing.Point(10, 185);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(791, 2);
            this.pnlDivider.TabIndex = 3;
            // 
            // gbThanhToan
            // 
            this.gbThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThanhToan.Controls.Add(this.lblTruViLabel);
            this.gbThanhToan.Controls.Add(this.txtViHoiVien);
            this.gbThanhToan.Controls.Add(this.lblTienMatLabel);
            this.gbThanhToan.Controls.Add(this.txtTienMat);
            this.gbThanhToan.Controls.Add(this.cardStatus);
            this.gbThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.gbThanhToan.ForeColor = System.Drawing.Color.Gray;
            this.gbThanhToan.Location = new System.Drawing.Point(18, 500);
            this.gbThanhToan.Name = "gbThanhToan";
            this.gbThanhToan.Size = new System.Drawing.Size(811, 190);
            this.gbThanhToan.TabIndex = 3;
            this.gbThanhToan.TabStop = false;
            this.gbThanhToan.Text = "Phương thức thanh toán";
            // 
            // lblTruViLabel
            // 
            this.lblTruViLabel.AutoSize = true;
            this.lblTruViLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTruViLabel.Location = new System.Drawing.Point(15, 30);
            this.lblTruViLabel.Name = "lblTruViLabel";
            this.lblTruViLabel.Size = new System.Drawing.Size(125, 21);
            this.lblTruViLabel.TabIndex = 0;
            this.lblTruViLabel.Text = "Trừ từ ví hội viên";
            // 
            // txtViHoiVien
            // 
            this.txtViHoiVien.AnimateReadOnly = false;
            this.txtViHoiVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtViHoiVien.Depth = 0;
            this.txtViHoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtViHoiVien.ForeColor = System.Drawing.Color.Green;
            this.txtViHoiVien.LeadingIcon = null;
            this.txtViHoiVien.Location = new System.Drawing.Point(18, 55);
            this.txtViHoiVien.MaxLength = 50;
            this.txtViHoiVien.MouseState = MaterialSkin.MouseState.OUT;
            this.txtViHoiVien.Multiline = false;
            this.txtViHoiVien.Name = "txtViHoiVien";
            this.txtViHoiVien.ReadOnly = true;
            this.txtViHoiVien.Size = new System.Drawing.Size(320, 50);
            this.txtViHoiVien.TabIndex = 0;
            this.txtViHoiVien.Text = "87,500";
            this.txtViHoiVien.TrailingIcon = null;
            // 
            // lblTienMatLabel
            // 
            this.lblTienMatLabel.AutoSize = true;
            this.lblTienMatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblTienMatLabel.Location = new System.Drawing.Point(15, 115);
            this.lblTienMatLabel.Name = "lblTienMatLabel";
            this.lblTienMatLabel.Size = new System.Drawing.Size(189, 21);
            this.lblTienMatLabel.TabIndex = 1;
            this.lblTienMatLabel.Text = "Thanh toán tiền mặt thêm";
            // 
            // txtTienMat
            // 
            this.txtTienMat.AnimateReadOnly = false;
            this.txtTienMat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTienMat.Depth = 0;
            this.txtTienMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.6F);
            this.txtTienMat.LeadingIcon = null;
            this.txtTienMat.Location = new System.Drawing.Point(18, 135);
            this.txtTienMat.MaxLength = 50;
            this.txtTienMat.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTienMat.Multiline = false;
            this.txtTienMat.Name = "txtTienMat";
            this.txtTienMat.Size = new System.Drawing.Size(320, 50);
            this.txtTienMat.TabIndex = 1;
            this.txtTienMat.Text = "0";
            this.txtTienMat.TrailingIcon = null;
            this.txtTienMat.TextChanged += new System.EventHandler(this.txtTienMat_TextChanged);
            // 
            // cardStatus
            // 
            this.cardStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardStatus.Controls.Add(this.lblStatus);
            this.cardStatus.Depth = 0;
            this.cardStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardStatus.Location = new System.Drawing.Point(365, 30);
            this.cardStatus.Margin = new System.Windows.Forms.Padding(14);
            this.cardStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardStatus.Name = "cardStatus";
            this.cardStatus.Padding = new System.Windows.Forms.Padding(14);
            this.cardStatus.Size = new System.Drawing.Size(429, 140);
            this.cardStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblStatus.Location = new System.Drawing.Point(15, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(305, 80);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "✔ Đủ số dư thanh toán\r\nSố dư 150,000đ >= Tổng 87,500đ\r\nSố dư còn lại: 62,500đ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.AutoSize = false;
            this.btnXacNhan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXacNhan.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnXacNhan.Depth = 0;
            this.btnXacNhan.HighEmphasis = true;
            this.btnXacNhan.Icon = null;
            this.btnXacNhan.Location = new System.Drawing.Point(629, 710);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnXacNhan.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnXacNhan.Size = new System.Drawing.Size(200, 36);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "XÁC NHẬN THANH TOÁN";
            this.btnXacNhan.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnXacNhan.UseAccentColor = false;
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInHoaDon.AutoSize = false;
            this.btnInHoaDon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInHoaDon.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnInHoaDon.Depth = 0;
            this.btnInHoaDon.HighEmphasis = true;
            this.btnInHoaDon.Icon = null;
            this.btnInHoaDon.Location = new System.Drawing.Point(494, 710);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnInHoaDon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnInHoaDon.Size = new System.Drawing.Size(120, 36);
            this.btnInHoaDon.TabIndex = 5;
            this.btnInHoaDon.Text = "IN HÓA ĐƠN";
            this.btnInHoaDon.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnInHoaDon.UseAccentColor = false;
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.AutoSize = false;
            this.btnHuy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHuy.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHuy.Depth = 0;
            this.btnHuy.HighEmphasis = false;
            this.btnHuy.Icon = null;
            this.btnHuy.Location = new System.Drawing.Point(404, 710);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHuy.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHuy.Size = new System.Drawing.Size(80, 36);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnHuy.UseAccentColor = false;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 770);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.gbThanhToan);
            this.Controls.Add(this.gbChiTiet);
            this.Controls.Add(this.gbHoiVien);
            this.Controls.Add(this.gbPhien);
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán – PC05 · Phạm Quốc Huy";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.gbPhien.ResumeLayout(false);
            this.gbPhien.PerformLayout();
            this.gbHoiVien.ResumeLayout(false);
            this.gbHoiVien.PerformLayout();
            this.gbChiTiet.ResumeLayout(false);
            this.gbChiTiet.PerformLayout();
            this.gbThanhToan.ResumeLayout(false);
            this.gbThanhToan.PerformLayout();
            this.cardStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPhien;
        private System.Windows.Forms.Label lblMayLabel;
        private System.Windows.Forms.Label lblMayValue;
        private System.Windows.Forms.Label lblBatDauLabel;
        private System.Windows.Forms.Label lblBatDauValue;
        private System.Windows.Forms.Label lblKetThucLabel;
        private System.Windows.Forms.Label lblKetThucValue;
        private System.Windows.Forms.Label lblThoiGianLabel;
        private System.Windows.Forms.Label lblThoiGianValue;

        private System.Windows.Forms.GroupBox gbHoiVien;
        private System.Windows.Forms.Label lblTenLabel;
        private System.Windows.Forms.Label lblTenValue;
        private System.Windows.Forms.Label lblSDTLabel;
        private System.Windows.Forms.Label lblSDTValue;
        private System.Windows.Forms.Label lblSoDuLabel;
        private System.Windows.Forms.Label lblSoDuValue;
        private System.Windows.Forms.Label lblSoDuSauLabel;
        private System.Windows.Forms.Label lblSoDuSauValue;

        private System.Windows.Forms.GroupBox gbChiTiet;
        private MaterialSkin.Controls.MaterialListView lvHoaDon;
        private System.Windows.Forms.ColumnHeader colKhoan;
        private System.Windows.Forms.ColumnHeader colThanhTien;
        private MaterialSkin.Controls.MaterialLabel lblTongTienLabel;
        private MaterialSkin.Controls.MaterialLabel lblTongTienValue;
        private System.Windows.Forms.Panel pnlDivider;

        private System.Windows.Forms.GroupBox gbThanhToan;
        private System.Windows.Forms.Label lblTruViLabel;
        private MaterialSkin.Controls.MaterialTextBox txtViHoiVien;
        private System.Windows.Forms.Label lblTienMatLabel;
        private MaterialSkin.Controls.MaterialTextBox txtTienMat;
        private MaterialSkin.Controls.MaterialCard cardStatus;
        private System.Windows.Forms.Label lblStatus;

        private MaterialSkin.Controls.MaterialButton btnXacNhan;
        private MaterialSkin.Controls.MaterialButton btnInHoaDon;
        private MaterialSkin.Controls.MaterialButton btnHuy;
    }
}
