namespace QuanLyCuaHangGame.GUI
{
    partial class dlgTopUp
    {
        private System.ComponentModel.IContainer components = null;

        private MaterialSkin.Controls.MaterialLabel lblCustomerName;
        private MaterialSkin.Controls.MaterialLabel lblCustomerPhone;
        private MaterialSkin.Controls.MaterialLabel lblCurrentBalance;
        private MaterialSkin.Controls.MaterialLabel lblAfterBalance;
        private MaterialSkin.Controls.MaterialTextBox txtAmount;
        private MaterialSkin.Controls.MaterialTextBox txtNote;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnOK;
        private MaterialSkin.Controls.MaterialCard cardMember;
        private MaterialSkin.Controls.MaterialLabel lblBalTitle;
        private MaterialSkin.Controls.MaterialLabel lblAfterTitle;
        private System.Windows.Forms.Label lblQuick;
        private System.Windows.Forms.Button btn50;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Button btn200;
        private System.Windows.Forms.Button btn500;

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
            this.lblCustomerName = new MaterialSkin.Controls.MaterialLabel();
            this.lblCustomerPhone = new MaterialSkin.Controls.MaterialLabel();
            this.lblCurrentBalance = new MaterialSkin.Controls.MaterialLabel();
            this.lblAfterBalance = new MaterialSkin.Controls.MaterialLabel();
            this.txtAmount = new MaterialSkin.Controls.MaterialTextBox();
            this.txtNote = new MaterialSkin.Controls.MaterialTextBox();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnOK = new MaterialSkin.Controls.MaterialButton();
            this.cardMember = new MaterialSkin.Controls.MaterialCard();
            this.lblBalTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblAfterTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblQuick = new System.Windows.Forms.Label();
            this.btn50 = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.btn200 = new System.Windows.Forms.Button();
            this.btn500 = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Member Card UI
            this.cardMember.Location = new System.Drawing.Point(16, 70);
            this.cardMember.Size = new System.Drawing.Size(388, 120);
            this.cardMember.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.cardMember.ForeColor = System.Drawing.Color.White;

            this.lblCustomerName.Text = "Họ Tên Hội Viên";
            this.lblCustomerName.Location = new System.Drawing.Point(10, 10);
            this.lblCustomerName.AutoSize = true;

            this.lblCustomerPhone.Text = "SĐT: ...";
            this.lblCustomerPhone.Location = new System.Drawing.Point(10, 40);
            this.lblCustomerPhone.AutoSize = true;

            this.lblBalTitle.Text = "Số dư hiện tại";
            this.lblBalTitle.Location = new System.Drawing.Point(10, 70);
            this.lblBalTitle.AutoSize = true;

            this.lblCurrentBalance.Text = "0đ";
            this.lblCurrentBalance.Location = new System.Drawing.Point(10, 90);
            this.lblCurrentBalance.AutoSize = true;

            this.lblAfterTitle.Text = "Sau khi nạp";
            this.lblAfterTitle.Location = new System.Drawing.Point(220, 70);
            this.lblAfterTitle.AutoSize = true;

            this.lblAfterBalance.Text = "0đ";
            this.lblAfterBalance.Location = new System.Drawing.Point(220, 90);
            this.lblAfterBalance.AutoSize = true;

            this.cardMember.Controls.Add(this.lblCustomerName);
            this.cardMember.Controls.Add(this.lblCustomerPhone);
            this.cardMember.Controls.Add(this.lblBalTitle);
            this.cardMember.Controls.Add(this.lblCurrentBalance);
            this.cardMember.Controls.Add(this.lblAfterTitle);
            this.cardMember.Controls.Add(this.lblAfterBalance);

            // Quick Topup Label
            this.lblQuick.Text = "Chọn mệnh giá nhanh:";
            this.lblQuick.Location = new System.Drawing.Point(16, 200);
            this.lblQuick.AutoSize = true;
            this.lblQuick.ForeColor = System.Drawing.Color.Gray;

            // Quick Buttons
            this.btn50.Text = "50k";
            this.btn50.Location = new System.Drawing.Point(16, 220);
            this.btn50.Size = new System.Drawing.Size(80, 30);
            this.btn50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn50.BackColor = System.Drawing.Color.White;


            this.btn100.Text = "100k";
            this.btn100.Location = new System.Drawing.Point(110, 220);
            this.btn100.Size = new System.Drawing.Size(80, 30);
            this.btn100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn100.BackColor = System.Drawing.Color.White;


            this.btn200.Text = "200k";
            this.btn200.Location = new System.Drawing.Point(204, 220);
            this.btn200.Size = new System.Drawing.Size(80, 30);
            this.btn200.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn200.BackColor = System.Drawing.Color.White;


            this.btn500.Text = "500k";
            this.btn500.Location = new System.Drawing.Point(298, 220);
            this.btn500.Size = new System.Drawing.Size(80, 30);
            this.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn500.BackColor = System.Drawing.Color.White;


            // Inputs
            this.txtAmount.Hint = "Số tiền nạp (VNĐ)";
            this.txtAmount.Location = new System.Drawing.Point(16, 260);
            this.txtAmount.Width = 388;

            this.txtNote.Hint = "Ghi chú (không bắt buộc)";
            this.txtNote.Location = new System.Drawing.Point(16, 330);
            this.txtNote.Width = 388;

            // Action Buttons
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new System.Drawing.Point(180, 420);
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;

            this.btnOK.Text = "Xác nhận nạp tiền";
            this.btnOK.Location = new System.Drawing.Point(250, 420);

            // Add controls to form
            this.Controls.Add(this.cardMember);
            this.Controls.Add(this.lblQuick);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn200);
            this.Controls.Add(this.btn500);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);

            // 
            // dlgTopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 480);
            this.Name = "dlgTopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nạp tiền vào ví hội viên";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ResumeLayout(false);
        }
    }
}
