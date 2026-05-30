using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace QuanLyCuaHangGame.UIHelper
{
    public class GameZoneMessageBox : Form
    {
        private Label lblMessage;
        private Label lblIcon;
        private MaterialButton btn1;
        private MaterialButton btn2;
        private Panel panelTop;
        private Label lblTitle;

        private GameZoneMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            this.Size = new Size(380, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Padding = new Padding(2);

            panelTop = new Panel { Dock = DockStyle.Top, Height = 45, BackColor = Color.FromArgb(25, 118, 210) };
            lblTitle = new Label { Text = string.IsNullOrEmpty(caption) ? "THÔNG BÁO" : caption.ToUpper(), ForeColor = Color.White, Font = new Font("Segoe UI", 12F, FontStyle.Bold), AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
            panelTop.Controls.Add(lblTitle);

            string iconStr = "❕";
            Color iconColor = Color.FromArgb(25, 118, 210);
            switch (icon)
            {
                case MessageBoxIcon.Warning:
                    iconStr = "⚠️";
                    iconColor = Color.Orange;
                    break;
                case MessageBoxIcon.Error:
                    iconStr = "❌";
                    iconColor = Color.Red;
                    break;
                case MessageBoxIcon.Information:
                    iconStr = "ℹ️";
                    iconColor = Color.FromArgb(25, 118, 210);
                    break;
                case MessageBoxIcon.Question:
                    iconStr = "❓";
                    iconColor = Color.FromArgb(25, 118, 210);
                    break;
            }

            lblIcon = new Label { Text = iconStr, Font = new Font("Segoe UI Emoji", 28F), ForeColor = iconColor, AutoSize = true, Location = new Point(25, 65) };
            lblMessage = new Label { Text = text, Font = new Font("Segoe UI", 11F), AutoSize = false, Size = new Size(250, 50), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(100, 70) };

            btn1 = new MaterialButton { Type = MaterialButton.MaterialButtonType.Outlined, AutoSize = false, Size = new Size(100, 36), Cursor = Cursors.Hand };
            btn2 = new MaterialButton { Type = MaterialButton.MaterialButtonType.Contained, AutoSize = false, Size = new Size(100, 36), Cursor = Cursors.Hand };

            SetupButtons(buttons);

            this.Controls.Add(panelTop);
            this.Controls.Add(lblIcon);
            this.Controls.Add(lblMessage);
            this.Controls.Add(btn1);
            if (btn2.Visible) this.Controls.Add(btn2);

            // Allow dragging from top panel
            bool dragging = false;
            Point dragCursorPoint = Point.Empty;
            Point dragFormPoint = Point.Empty;
            panelTop.MouseDown += (s, e) => { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; };
            panelTop.MouseMove += (s, e) => { if (dragging) { Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); this.Location = Point.Add(dragFormPoint, new Size(dif)); } };
            panelTop.MouseUp += (s, e) => { dragging = false; };
            lblTitle.MouseDown += (s, e) => { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; };
            lblTitle.MouseMove += (s, e) => { if (dragging) { Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); this.Location = Point.Add(dragFormPoint, new Size(dif)); } };
            lblTitle.MouseUp += (s, e) => { dragging = false; };
        }

        private void SetupButtons(MessageBoxButtons buttons)
        {
            if (buttons == MessageBoxButtons.OK)
            {
                btn2.Visible = false;
                btn1.Text = "OK";
                btn1.Type = MaterialButton.MaterialButtonType.Contained;
                
                int startX = (this.Width - btn1.Width) / 2;
                btn1.Location = new Point(startX, 145);
                
                btn1.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                btn1.Text = "CÓ";
                btn1.Type = MaterialButton.MaterialButtonType.Outlined;
                
                btn2.Visible = true;
                btn2.Text = "KHÔNG";
                btn2.Type = MaterialButton.MaterialButtonType.Contained;
                
                int totalBtnWidth = btn1.Width + 20 + btn2.Width;
                int startX = (this.Width - totalBtnWidth) / 2;
                btn1.Location = new Point(startX, 145);
                btn2.Location = new Point(startX + btn1.Width + 20, 145);
                
                btn1.Click += (s, e) => { this.DialogResult = DialogResult.Yes; this.Close(); };
                btn2.Click += (s, e) => { this.DialogResult = DialogResult.No; this.Close(); };
            }
            else
            {
                btn2.Visible = false;
                btn1.Text = "OK";
                btn1.Type = MaterialButton.MaterialButtonType.Contained;
                
                int startX = (this.Width - btn1.Width) / 2;
                btn1.Location = new Point(startX, 145);
                btn1.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption = "THÔNG BÁO", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            using (var msgBox = new GameZoneMessageBox(text, caption, buttons, icon))
            {
                if (owner != null)
                {
                    msgBox.StartPosition = FormStartPosition.CenterParent;
                    return msgBox.ShowDialog(owner);
                }
                else
                {
                    msgBox.StartPosition = FormStartPosition.CenterScreen;
                    return msgBox.ShowDialog();
                }
            }
        }

        public static DialogResult Show(string text, string caption = "THÔNG BÁO", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return Show(Form.ActiveForm, text, caption, buttons, icon);
        }
    }
}
