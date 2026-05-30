using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace QuanLyCuaHangGame.GUI
{
    public class frmConfirmExit : Form
    {
        private Label lblMessage;
        private Label lblIcon;
        private MaterialButton btnYes;
        private MaterialButton btnNo;
        private Panel panelTop;
        private Label lblTitle;

        public frmConfirmExit()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(380, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            
            // Allow clicking form border to drag
            this.Padding = new Padding(2);

            panelTop = new Panel { Dock = DockStyle.Top, Height = 45, BackColor = Color.FromArgb(25, 118, 210) };
            lblTitle = new Label { Text = "XÁC NHẬN", ForeColor = Color.White, Font = new Font("Segoe UI", 12F, FontStyle.Bold), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
            panelTop.Controls.Add(lblTitle);
            
            lblIcon = new Label { Text = "⚠️", Font = new Font("Segoe UI Emoji", 28F), ForeColor = Color.Orange, AutoSize = true, Location = new Point(25, 65) };
            lblMessage = new Label { Text = "Bạn có chắc chắn muốn thoát phần mềm?", Font = new Font("Segoe UI", 11F), AutoSize = false, Size = new Size(250, 50), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(100, 70) };

            btnYes = new MaterialButton { Text = "CÓ, THOÁT", Type = MaterialButton.MaterialButtonType.Outlined, AutoSize = false, Size = new Size(110, 36), Cursor = Cursors.Hand };
            btnNo = new MaterialButton { Text = "KHÔNG", Type = MaterialButton.MaterialButtonType.Contained, AutoSize = false, Size = new Size(100, 36), Cursor = Cursors.Hand };

            // Căn giữa 2 nút
            int totalBtnWidth = btnYes.Width + 20 + btnNo.Width;
            int startX = (this.Width - totalBtnWidth) / 2;
            btnYes.Location = new Point(startX, 145);
            btnNo.Location = new Point(startX + btnYes.Width + 20, 145);

            btnYes.Click += (s, e) => { this.DialogResult = DialogResult.Yes; this.Close(); };
            
            btnNo.Click += (s, e) => { this.DialogResult = DialogResult.No; this.Close(); };

            this.Controls.Add(panelTop);
            this.Controls.Add(lblIcon);
            this.Controls.Add(lblMessage);
            this.Controls.Add(btnYes);
            this.Controls.Add(btnNo);
            
            // Allow dragging from top panel
            bool dragging = false;
            Point dragCursorPoint = Point.Empty;
            Point dragFormPoint = Point.Empty;
            panelTop.MouseDown += (s, e) => { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; };
            panelTop.MouseMove += (s, e) => { if (dragging) { Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); this.Location = Point.Add(dragFormPoint, new Size(dif)); } };
            panelTop.MouseUp += (s, e) => { dragging = false; };
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
        }
    }
}
