namespace QuanLyCuaHangGame.GUI
{
    partial class frmService
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvServices;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialComboBox cboCategory;
        private MaterialSkin.Controls.MaterialTextBox txtPrice;
        private MaterialSkin.Controls.MaterialCheckbox chkAvailable;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnEdit;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private MaterialSkin.Controls.MaterialCard cardDetails;
        private MaterialSkin.Controls.MaterialLabel lblTitle;

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
            this.lvServices = new System.Windows.Forms.ListView();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.cboCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.txtPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.chkAvailable = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnEdit = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.cardDetails = new MaterialSkin.Controls.MaterialCard();
            this.lblTitle = new MaterialSkin.Controls.MaterialLabel();

            this.SuspendLayout();

            // ToolBar Panel
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 50;
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(10);

            // Toolbar Buttons
            this.btnAdd.Text = "Thêm";
            this.btnAdd.AutoSize = true;
            
            this.btnEdit.Text = "Sửa";
            this.btnEdit.AutoSize = true;
            this.btnEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            
            this.btnDelete.Text = "Xóa";
            this.btnDelete.AutoSize = true;
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;

            // FlowLayoutPanel
            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToolbar.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpToolbar.Controls.Add(this.btnAdd);
            this.flpToolbar.Controls.Add(this.btnEdit);
            this.flpToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Controls.Add(this.flpToolbar);

            // Left Panel (ListView)
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width = 450;
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);

            this.lvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServices.FullRowSelect = true;
            this.lvServices.View = System.Windows.Forms.View.Details;
            this.lvServices.Columns.Add("Tên dịch vụ", 180);
            this.lvServices.Columns.Add("Danh mục", 100);
            this.lvServices.Columns.Add("Giá", 80);
            this.lvServices.Columns.Add("Có sẵn", 80);
            this.pnlLeft.Controls.Add(this.lvServices);

            // Right Panel (Details)
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);

            this.cardDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDetails.Padding = new System.Windows.Forms.Padding(16);

            this.lblTitle.Text = "Thêm / Sửa dịch vụ";
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.AutoSize = true;

            this.txtName.Hint = "Tên dịch vụ";
            this.txtName.Location = new System.Drawing.Point(16, 60);
            this.txtName.Width = 300;

            this.cboCategory.Hint = "Danh mục";
            this.cboCategory.Location = new System.Drawing.Point(16, 130);
            this.cboCategory.Width = 300;
            this.cboCategory.Items.AddRange(new object[] { "Đồ uống", "Đồ ăn", "Game", "Khác" });
            this.cboCategory.SelectedIndex = 0;

            this.txtPrice.Hint = "Giá bán (VNĐ)";
            this.txtPrice.Location = new System.Drawing.Point(16, 200);
            this.txtPrice.Width = 300;

            this.chkAvailable.Text = "Đang có sẵn";
            this.chkAvailable.Location = new System.Drawing.Point(16, 270);
            this.chkAvailable.Checked = true;

            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new System.Drawing.Point(140, 330);
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;

            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(220, 330);

            this.cardDetails.Controls.Add(this.lblTitle);
            this.cardDetails.Controls.Add(this.txtName);
            this.cardDetails.Controls.Add(this.cboCategory);
            this.cardDetails.Controls.Add(this.txtPrice);
            this.cardDetails.Controls.Add(this.chkAvailable);
            this.cardDetails.Controls.Add(this.btnCancel);
            this.cardDetails.Controls.Add(this.btnSave);

            this.pnlRight.Controls.Add(this.cardDetails);

            // Add panels to form
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlToolbar);

            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 540);
            this.Name = "frmService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh mục dịch vụ";
            this.ResumeLayout(false);
        }
    }
}
