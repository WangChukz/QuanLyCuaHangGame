using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyCuaHangGame.UIHelper
{
    /// <summary>
    /// Hộp thoại thông báo tùy chỉnh theo chủ đề GameZone (tím).
    /// Không kế thừa MaterialForm → không gây lỗi re-render layout form cha.
    /// </summary>
    public class GameZoneDialog : Form
    {
        // ── Màu sắc hệ thống ─────────────────────────────────────────────────
        private static readonly Color ThemePurple     = Color.FromArgb(108, 76, 241);
        private static readonly Color ThemePurpleDark = Color.FromArgb(88,  56, 221);
        private static readonly Color ThemePurpleLight= Color.FromArgb(243, 239, 255);
        private static readonly Color TextDark        = Color.FromArgb(30,  27,  75);
        private static readonly Color TextGray        = Color.FromArgb(107, 114, 128);
        private static readonly Color BgColor         = Color.White;
        private static readonly Color SuccessGreen    = Color.FromArgb(16, 185, 129);
        private static readonly Color WarningAmber    = Color.FromArgb(245, 158, 11);
        private static readonly Color ErrorRed        = Color.FromArgb(239, 68,  68);
        private static readonly Color InfoBlue        = Color.FromArgb(59,  130, 246);

        // ── Controls ──────────────────────────────────────────────────────────
        private Panel  _pnlHeader;
        private Label  _lblTitle;
        private Label  _lblMessage;
        private Button _btnOk;
        private Button _btnCancel;
        private Label  _lblIcon;
        private Panel  _pnlContent;

        private MessageBoxIcon _icon;
        private bool           _hasCancel;
        private Point          _dragOffset;   // cho tính năng kéo thả cửa sổ

        // ── Constructor ───────────────────────────────────────────────────────
        private GameZoneDialog(string message, string title, MessageBoxIcon icon, bool hasCancel)
        {
            _icon      = icon;
            _hasCancel = hasCancel;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.Size            = new Size(440, 280);
            this.BackColor       = BgColor;
            this.Font            = new Font("Segoe UI", 9.5F);
            this.ShowInTaskbar   = false;

            // Bo góc bằng Region
            this.Load += (s, e) => ApplyRoundedCorners(this, 14);

            BuildUI(title, message);
        }

        // ── Xây dựng giao diện ────────────────────────────────────────────────
        private void BuildUI(string title, string message)
        {
            // --- Header dải màu ---
            _pnlHeader = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 60,
                BackColor = ThemePurple
            };

            // Icon vòng tròn trên header
            _lblIcon = new Label
            {
                AutoSize  = false,
                Size      = new Size(36, 36),
                Location  = new Point(16, 12),
                BackColor = Color.FromArgb(255, 255, 255, 40),
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 15F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Text      = GetIconChar(icon: _icon)
            };
            ApplyRoundedCorners(_lblIcon, 18);

            // Tiêu đề trên header
            _lblTitle = new Label
            {
                AutoSize  = false,
                Location  = new Point(62, 0),
                Size      = new Size(360, 60),
                Text      = title,
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _pnlHeader.Controls.Add(_lblIcon);
            _pnlHeader.Controls.Add(_lblTitle);

            // --- Vùng nội dung ---
            _pnlContent = new Panel
            {
                Dock      = DockStyle.Fill,
                BackColor = BgColor,
                Padding   = new Padding(24, 16, 24, 16)
            };

            _lblMessage = new Label
            {
                AutoSize  = false,
                Location  = new Point(24, 20),
                Size      = new Size(392, 70),
                Text      = message,
                ForeColor = TextDark,
                Font      = new Font("Segoe UI", 10.5F),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // --- Nút OK ---
            _btnOk = CreateButton("OK", true);
            _btnOk.Location = _hasCancel
                ? new Point(230, 178)
                : new Point(318, 178);
            _btnOk.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };

            // --- Nút Hủy (tuỳ chọn) ---
            if (_hasCancel)
            {
                _btnCancel = CreateButton("Hủy", false);
                _btnCancel.Location = new Point(330, 178);
                _btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
                _pnlContent.Controls.Add(_btnCancel);
            }

            _pnlContent.Controls.Add(_lblMessage);
            _pnlContent.Controls.Add(_btnOk);

            // Đường kẻ accent màu theo loại icon ở đáy header
            _pnlHeader.Paint += (s, e) =>
            {
                using (var pen = new Pen(GetAccentColor(), 3))
                    e.Graphics.DrawLine(pen, 0, _pnlHeader.Height - 1, _pnlHeader.Width, _pnlHeader.Height - 1);
            };

            this.Controls.Add(_pnlContent);
            this.Controls.Add(_pnlHeader);

            // Hover nút
            ApplyButtonHover(_btnOk);
            if (_hasCancel) ApplyButtonHover(_btnCancel);

            // Phím ESC = Hủy
            this.KeyPreview = true;
            this.KeyDown   += (s, e) => { if (e.KeyCode == Keys.Escape) { this.DialogResult = DialogResult.Cancel; this.Close(); } };
            this.KeyDown   += (s, e) => { if (e.KeyCode == Keys.Enter)  { this.DialogResult = DialogResult.OK;     this.Close(); } };

            // Kéo thả cửa sổ qua header
            EnableDrag(_pnlHeader);
            EnableDrag(_lblTitle);
            EnableDrag(_lblIcon);
        }

        // ── Helper: Cho phép kéo cửa sổ qua control bất kỳ ──────────────────
        private void EnableDrag(Control ctrl)
        {
            ctrl.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    _dragOffset = e.Location;
            };
            ctrl.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    var screenPos = ctrl.PointToScreen(e.Location);
                    this.Location = new Point(
                        screenPos.X - _dragOffset.X,
                        screenPos.Y - _dragOffset.Y);
                }
            };
            ctrl.Cursor = Cursors.SizeAll;
        }

        // ── Helper: Tạo nút ───────────────────────────────────────────────────
        private Button CreateButton(string text, bool isPrimary)
        {
            return new Button
            {
                Text      = text,
                Size      = new Size(92, 36),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor    = Cursors.Hand,
                BackColor = isPrimary ? ThemePurple : Color.White,
                ForeColor = isPrimary ? Color.White  : TextGray,
                FlatAppearance =
                {
                    BorderColor = isPrimary ? ThemePurple : Color.FromArgb(209, 213, 219),
                    BorderSize  = 1
                }
            };
        }

        // ── Helper: Hover effect ──────────────────────────────────────────────
        private void ApplyButtonHover(Button btn)
        {
            bool isPrimary = (btn == _btnOk);
            btn.MouseEnter += (s, e) => btn.BackColor = isPrimary ? ThemePurpleDark : ThemePurpleLight;
            btn.MouseLeave += (s, e) => btn.BackColor = isPrimary ? ThemePurple     : Color.White;
        }

        // ── Helper: Bo góc ────────────────────────────────────────────────────
        private static void ApplyRoundedCorners(Control ctrl, int radius)
        {
            int w = ctrl.Width, h = ctrl.Height;
            if (w <= 0 || h <= 0) return;
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(w - d, 0, d, d, 270, 90);
            path.AddArc(w - d, h - d, d, d, 0, 90);
            path.AddArc(0, h - d, d, d, 90, 90);
            path.CloseFigure();
            ctrl.Region = new Region(path);
        }

        // ── Helper: Ký tự icon theo loại thông báo ───────────────────────────
        private string GetIconChar(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:       return "✕";
                case MessageBoxIcon.Warning:     return "!";
                case MessageBoxIcon.Question:    return "?";
                case MessageBoxIcon.Information:
                default:                         return "i";
            }
        }

        private Color GetAccentColor()
        {
            switch (_icon)
            {
                case MessageBoxIcon.Error:       return ErrorRed;
                case MessageBoxIcon.Warning:     return WarningAmber;
                case MessageBoxIcon.Question:    return InfoBlue;
                case MessageBoxIcon.Information:
                default:                         return SuccessGreen;
            }
        }

        // ── Vẽ shadow giả bằng Form.Paint ────────────────────────────────────
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Color.FromArgb(229, 231, 235), 1))
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }

        // ─────────────────────────────────────────────────────────────────────
        // API tĩnh — dùng thay cho MessageBox.Show / MaterialMessageBox.Show
        // ─────────────────────────────────────────────────────────────────────

        public static DialogResult Show(
            string message,
            string title          = "Thông báo",
            MessageBoxButtons btns= MessageBoxButtons.OK,
            MessageBoxIcon icon   = MessageBoxIcon.Information,
            Form owner            = null)
        {
            bool hasCancel = (btns == MessageBoxButtons.OKCancel ||
                              btns == MessageBoxButtons.YesNo    ||
                              btns == MessageBoxButtons.RetryCancel);

            using (var dlg = new GameZoneDialog(message, title, icon, hasCancel))
            {
                if (owner != null)
                    return dlg.ShowDialog(owner);
                return dlg.ShowDialog();
            }
        }
    }
}
