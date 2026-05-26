using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.UIHelper;
using QuanLyCuaHangGame.BLL;

namespace QuanLyCuaHangGame
{
    public partial class frmComputer : Form
    {
        public frmComputer()
        {
            InitializeComponent();
            
            // Hide tabs header if possible, we switch programmatically
            mainTabControl.SelectedIndex = 0;
            UpdateRoleUI(SessionContext.IsAdmin); 
            pnlRoleToggle.Visible = false;
            
            // Add dummy data for Admin
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC01", "Phòng A", "VIP", "i9/RTX4070", "Tốt", "30,000đ" }));
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC02", "Phòng A", "VIP", "i9/RTX4070", "Tốt", "30,000đ" }));
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC07", "Phòng A", "Standard", "i5/GTX1660", "Hỏng", "20,000đ" }));
            lvAdmin.Items.Add(new ListViewItem(new[] { "PC11", "Phòng B", "Standard", "i7/RTX3060", "Đã sửa", "20,000đ" }));
            
            // Add dummy data for Staff
            lvStaff.Items.Add(new ListViewItem(new[] { "PC01", "Phòng A", "VIP", "Tốt", "Đang dùng" }));
            lvStaff.Items.Add(new ListViewItem(new[] { "PC02", "Phòng A", "VIP", "Tốt", "Trống" }));
            lvStaff.Items.Add(new ListViewItem(new[] { "PC07", "Phòng A", "Standard", "Hỏng", "Dừng" }));
            lvStaff.Items.Add(new ListViewItem(new[] { "PC11", "Phòng B", "Standard", "Đã sửa", "Trống" }));

            // Apply premium styles to match the Dashboard theme
            ApplyPremiumStyles();

            // Gọi layout 1 lần duy nhất sau khi form đã nhận được kích thước thực từ parent
            this.Load += (s, e) => BeginInvoke(new Action(LayoutFormControls));

            // Register custom draw handlers to synchronize styling with premium theme
            lvAdmin.DrawColumnHeader += Lv_DrawColumnHeader;
            lvAdmin.DrawItem += Lv_DrawItem;
            lvAdmin.DrawSubItem += Lv_DrawSubItem;
            lvStaff.DrawColumnHeader += Lv_DrawColumnHeader;
            lvStaff.DrawItem += Lv_DrawItem;
            lvStaff.DrawSubItem += Lv_DrawSubItem;

            // Bind SizeChanged events to auto-resize columns
            lvAdmin.SizeChanged += LvAdmin_SizeChanged;
            LvAdmin_SizeChanged(this, EventArgs.Empty);

            lvStaff.SizeChanged += LvStaff_SizeChanged;
            LvStaff_SizeChanged(this, EventArgs.Empty);
        }

        // ─── Chặn WM_SIZE trong lúc dialog con đang mở ─────────────────────
        private bool _dialogOpen = false;
        private const int WM_SIZE             = 0x0005;
        private const int WM_WINDOWPOSCHANGED = 0x0047;

        protected override void WndProc(ref Message m)
        {
            // Khi dialog đang mở, bỏ qua mọi message thay đổi kích thước
            // (do MaterialSkinManager.UpdateRendering trigger từ dlgRoom constructor)
            if (_dialogOpen &&
                (m.Msg == WM_SIZE || m.Msg == WM_WINDOWPOSCHANGED))
                return;
            base.WndProc(ref m);
        }

        private void ApplyPremiumStyles()
        {
            // 1. Set clean pure white background for tabs and parent form
            this.BackColor = Color.White;
            tabAdmin.BackColor = Color.White;
            tabStaff.BackColor = Color.White;
            pnlAdminToolbar.BackColor = Color.White;
            pnlStaffToolbar.BackColor = Color.White;

            // 1b. Row height 45px (dùng ImageList trick) + hover effect sạch
            SetListViewHeaderHeight(lvAdmin, 45);
            SetListViewHeaderHeight(lvStaff, 45);

            // Hover: chỉ track index dòng đang hover, invalidate đúng 1 lần
            lvAdmin.MouseMove  += (s, ev) => UpdateHover(lvAdmin, ev, ref _hoveredAdminRow);
            lvAdmin.MouseLeave += (s, ev) => ClearHover(lvAdmin, ref _hoveredAdminRow);
            lvStaff.MouseMove  += (s, ev) => UpdateHover(lvStaff, ev, ref _hoveredStaffRow);
            lvStaff.MouseLeave += (s, ev) => ClearHover(lvStaff, ref _hoveredStaffRow);

            // 3. Make the basic WinForms "XÓA MÁY" button ultra-clean, modern and rounded with solid red background
            btnAdminDeleteMachine.FlatStyle = FlatStyle.Flat;
            btnAdminDeleteMachine.FlatAppearance.BorderSize = 0;
            btnAdminDeleteMachine.BackColor = Color.FromArgb(239, 68, 68); // Vivid premium red
            btnAdminDeleteMachine.ForeColor = Color.White; // High contrast white text
            btnAdminDeleteMachine.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
            btnAdminDeleteMachine.FlatAppearance.MouseDownBackColor = Color.FromArgb(185, 28, 28);
            btnAdminDeleteMachine.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnAdminDeleteMachine.SizeChanged += (s, e) => {
                btnAdminDeleteMachine.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, btnAdminDeleteMachine.Width, btnAdminDeleteMachine.Height), 8));
            };
            btnAdminDeleteMachine.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, btnAdminDeleteMachine.Width, btnAdminDeleteMachine.Height), 8));

            // 4. Make the basic WinForms "LƯU TRẠNG THÁI" (btnStaffSaveStatus) button ultra-clean, modern and rounded with solid green background
            btnStaffSaveStatus.FlatStyle = FlatStyle.Flat;
            btnStaffSaveStatus.FlatAppearance.BorderSize = 0;
            btnStaffSaveStatus.BackColor = Color.FromArgb(34, 197, 94); // Vivid green
            btnStaffSaveStatus.ForeColor = Color.White; // High contrast white text
            btnStaffSaveStatus.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
            btnStaffSaveStatus.FlatAppearance.MouseDownBackColor = Color.FromArgb(21, 128, 61);
            btnStaffSaveStatus.Font = new Font("Inter", 9.5F, FontStyle.Bold);
            btnStaffSaveStatus.SizeChanged += (s, e) => {
                btnStaffSaveStatus.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, btnStaffSaveStatus.Width, btnStaffSaveStatus.Height), 8));
            };
            btnStaffSaveStatus.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, btnStaffSaveStatus.Width, btnStaffSaveStatus.Height), 8));

            // 5. Stylize notice panel in Staff mode (pnlStaffNotice) to be clean and soft
            pnlStaffNotice.BackColor = Color.FromArgb(239, 246, 255); // Soft blue background for friendly alert
            lblStaffNotice.ForeColor = Color.FromArgb(29, 78, 216); // Dark blue text
            lblStaffNotice.Font = new Font("Inter", 9.5F, FontStyle.Regular);

            // 6. Modernize headers and fonts globally on this form
            DashboardUIHelper.ApplyGlobalModernStyle(this);
        }

        private void Lv_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Dùng đúng y chang style của dashboard
            DashboardUIHelper.DrawColumnHeader(sender, e);
        }

        private void Lv_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;
        }

        private void Lv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv == null) return;

            int colIndex = e.ColumnIndex;
            string val   = e.SubItem.Text;

            // --- Màu nền dòng: zebra + hover + selected ---
            int hoveredRow = (lv == lvAdmin) ? _hoveredAdminRow : _hoveredStaffRow;
            Color rowBg;
            if (e.Item.Selected)
                rowBg = DashboardUIHelper.ThemeColorLight;
            else if (e.ItemIndex == hoveredRow)
                rowBg = DashboardUIHelper.ThemeColorLight;
            else
                rowBg = (e.ItemIndex % 2 == 0) ? DashboardUIHelper.ThemeColorAlternating : Color.White;

            using (var bgBrush = new SolidBrush(rowBg))
                e.Graphics.FillRectangle(bgBrush, e.Bounds);

            Rectangle textBounds = e.Bounds;
            textBounds.Inflate(-10, 0);
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            if (e.Header != null && e.Header.TextAlign == HorizontalAlignment.Center)
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;

            bool isBadge = false;

            if (colIndex == 0) // Mã máy — tím đậm bold như dashboard
            {
                Font f = new Font("Inter", 9.5F, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, val, f, textBounds, DashboardUIHelper.ThemeColor, flags);
            }
            else if (lv.Name == "lvAdmin")
            {
                if (colIndex == 2) // Hạng
                {
                    isBadge = true;
                    DrawBadge(e.Graphics, val, e.Bounds,
                        val == "VIP" ? Color.FromArgb(243, 239, 255) : Color.FromArgb(243, 244, 246),
                        val == "VIP" ? DashboardUIHelper.ThemeColor : Color.FromArgb(75, 85, 99));
                }
                else if (colIndex == 4) // Tình trạng
                {
                    isBadge = true;
                    if (val == "Tốt" || val == "Đã sửa")
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(240, 253, 244), Color.FromArgb(22, 163, 74));
                    else if (val == "Hỏng")
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(254, 242, 242), Color.FromArgb(220, 38, 38));
                    else
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(255, 247, 237), Color.FromArgb(234, 88, 12));
                }
                else if (!isBadge && colIndex > 0)
                {
                    Font f = new Font("Inter", 9.5F, FontStyle.Regular);
                    TextRenderer.DrawText(e.Graphics, val, f, textBounds, Color.FromArgb(55, 65, 81), flags);
                }
            }
            else if (lv.Name == "lvStaff")
            {
                if (colIndex == 2) // Hạng
                {
                    isBadge = true;
                    DrawBadge(e.Graphics, val, e.Bounds,
                        val == "VIP" ? Color.FromArgb(243, 239, 255) : Color.FromArgb(243, 244, 246),
                        val == "VIP" ? DashboardUIHelper.ThemeColor : Color.FromArgb(75, 85, 99));
                }
                else if (colIndex == 3) // Tình trạng
                {
                    isBadge = true;
                    if (val == "Tốt" || val == "Đã sửa")
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(240, 253, 244), Color.FromArgb(22, 163, 74));
                    else if (val == "Hỏng")
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(254, 242, 242), Color.FromArgb(220, 38, 38));
                    else
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(255, 247, 237), Color.FromArgb(234, 88, 12));
                }
                else if (colIndex == 4) // Trạng thái
                {
                    isBadge = true;
                    if (val == "Trống")
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(240, 253, 244), Color.FromArgb(22, 163, 74));
                    else if (val == "Đang dùng")
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(239, 246, 255), Color.FromArgb(37, 99, 235));
                    else
                        DrawBadge(e.Graphics, val, e.Bounds, Color.FromArgb(254, 242, 242), Color.FromArgb(220, 38, 38));
                }
                else if (!isBadge && colIndex > 0)
                {
                    Font f = new Font("Inter", 9.5F, FontStyle.Regular);
                    TextRenderer.DrawText(e.Graphics, val, f, textBounds, Color.FromArgb(55, 65, 81), flags);
                }
            }

            // Đường kẻ ngang nhạt cuối mỗi dòng (giống dashboard)
            using (Pen pen = new Pen(Color.FromArgb(243, 244, 246), 1))
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        // Badge helper — đúng theo style dashboard
        private void DrawBadge(Graphics g, string text, Rectangle cellBounds, Color bg, Color fg)
        {
            int w = Math.Min(cellBounds.Width - 16, 85);
            int h = 22;
            int x = cellBounds.X + (cellBounds.Width - w) / 2;
            int y = cellBounds.Y + (cellBounds.Height - h) / 2;
            Rectangle r = new Rectangle(x, y, w, h);
            using (var path = UICommon.GetRoundedRectPath(r, 11))
            using (var brush = new SolidBrush(bg))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillPath(brush, path);
            }
            TextRenderer.DrawText(g, text, new Font("Inter", 9F, FontStyle.Bold), r, fg,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        // --- Hover tracking (sạch, không gây redraw vòng lặp) ---
        private int _hoveredAdminRow = -1;
        private int _hoveredStaffRow = -1;

        private void UpdateHover(ListView lv, MouseEventArgs e, ref int hoveredRow)
        {
            var hit = lv.HitTest(e.Location);
            int newRow = hit.Item != null ? hit.Item.Index : -1;
            if (newRow != hoveredRow)
            {
                hoveredRow = newRow;
                lv.Invalidate(); // chỉ redraw 1 lần khi dòng hover thay đổi
            }
        }

        private void ClearHover(ListView lv, ref int hoveredRow)
        {
            if (hoveredRow != -1)
            {
                hoveredRow = -1;
                lv.Invalidate();
            }
        }

        private void LvAdmin_SizeChanged(object sender, EventArgs e)
        {
            UICommon.AutoResizeListViewColumns(lvAdmin, new double[] { 0.15, 0.15, 0.15, 0.25, 0.15, 0.15 });
        }

        private void LvStaff_SizeChanged(object sender, EventArgs e)
        {
            UICommon.AutoResizeListViewColumns(lvStaff, new double[] { 0.2, 0.2, 0.2, 0.2, 0.2 });
        }

        private void UpdateRoleUI(bool isAdmin)
        {
            string newTitle = isAdmin ? "Quản lý máy tính — Chế độ: Admin" : "Quản lý máy tính — Chế độ: Staff (Nhân viên phòng máy)";
            
            if (this.ParentForm != null)
            {
                this.ParentForm.Text = newTitle;
            }
            else
            {
                this.Text = newTitle;
            }

            if (isAdmin)
            {
                mainTabControl.SelectedIndex = 0;
            }
            else
            {
                mainTabControl.SelectedIndex = 1;
            }
        }

        private void btnAdminManageRoom_Click(object sender, EventArgs e)
        {
            // Chụp snapshot layout trước khi mở
            var snapLvAdmin     = lvAdmin.Bounds;
            var snapCardAdmin   = cardAdminDetails.Bounds;
            var snapLvStaff     = lvStaff.Bounds;
            var snapCardStaff   = cardStaffDetails.Bounds;
            var snapPnlAdminBar = pnlAdminToolbar.Bounds;
            var snapPnlStaffBar = pnlStaffToolbar.Bounds;
            var snapPnlNotice   = pnlStaffNotice.Bounds;

            // Bật cờ block WM_SIZE — không cho resize trong lúc dialog mở
            _dialogOpen = true;
            try
            {
                dlgRoom frm = new dlgRoom();
                frm.ShowDialog();
            }
            finally
            {
                _dialogOpen = false;
            }

            // Restore lại vị trí/kích thước chính xác sau khi dialog đóng
            this.SuspendLayout();
            lvAdmin.Bounds          = snapLvAdmin;
            cardAdminDetails.Bounds = snapCardAdmin;
            lvStaff.Bounds          = snapLvStaff;
            cardStaffDetails.Bounds = snapCardStaff;
            pnlAdminToolbar.Bounds  = snapPnlAdminBar;
            pnlStaffToolbar.Bounds  = snapPnlStaffBar;
            pnlStaffNotice.Bounds   = snapPnlNotice;
            this.ResumeLayout(false);

            // Vẽ lại bảng để phục hồi màu sắc OwnerDraw
            lvAdmin.Invalidate();
            lvStaff.Invalidate();

            RefreshRoomComboBox();
        }

        private void RefreshRoomComboBox()
        {
            // Lấy danh sách phòng từ RoomStore (nguồn chung với dlgRoom)
            string[] roomNames = Data.RoomStore.GetRoomNames();

            cboAdminRoom.Items.Clear();
            cboAdminRoom.Items.AddRange(roomNames);
            if (cboAdminRoom.Items.Count > 0)
                cboAdminRoom.SelectedIndex = 0;

            MaterialSnackBar snack = new MaterialSnackBar("Đã cập nhật danh sách phòng!", 2000);
            snack.Show(this);
        }


        private void LayoutFormControls()
        {
            // Fixed inner content heights - these match the fixed positions of inner controls
            // Admin card: grpAdminPrice at Y=310+H90=400, buttons at Y=410+H36=446, bottom pad 14 → need 460px
            const int ADMIN_CARD_FIXED_HEIGHT = 460;
            // Staff card: restriction label at Y=264+H105=369, bottom pad 14 → need 395px
            const int STAFF_CARD_FIXED_HEIGHT = 395;

            // --- Tab Admin Layout ---
            int wAdmin = tabAdmin.ClientSize.Width;
            int hAdmin = tabAdmin.ClientSize.Height;

            if (wAdmin > 0 && hAdmin > 0)
            {
                int topMargin = 65;
                int bottomMargin = 20; // safe margin so card bottom never touches footer
                int availableHeight = hAdmin - topMargin - bottomMargin;
                // Cap: never let card taller than its fixed inner content; never shorter than usable
                int cardHeight = Math.Min(ADMIN_CARD_FIXED_HEIGHT, Math.Max(400, availableHeight));
                int cardWidth = 540;
                int gap = 10;
                int sideMargin = 10;

                int lvWidth = Math.Max(200, wAdmin - cardWidth - gap - (sideMargin * 2));

                // Position lvAdmin - always same height as card for visual alignment
                lvAdmin.SetBounds(sideMargin, topMargin, lvWidth, cardHeight);

                // Position cardAdminDetails
                cardAdminDetails.SetBounds(lvAdmin.Right + gap, topMargin, cardWidth, cardHeight);

                // Buttons: always pinned at fixed Y=410 inside the card (within the 460px height)
                int buttonY = 410;
                btnAdminSave.AutoSize = false;
                btnAdminSave.SetBounds(17, buttonY, 240, 36);

                btnAdminCancel.AutoSize = false;
                btnAdminCancel.SetBounds(280, buttonY, 100, 36);

                btnAdminDeleteMachine.SetBounds(403, buttonY, 120, 36);
            }

            // --- Tab Staff Layout ---
            int wStaff = tabStaff.ClientSize.Width;
            int hStaff = tabStaff.ClientSize.Height;

            if (wStaff > 0 && hStaff > 0)
            {
                // Position pnlStaffNotice banner
                pnlStaffNotice.SetBounds(10, 65, Math.Max(200, wStaff - 20), 40);

                int topMargin = 120;
                int bottomMargin = 20; // safe margin from footer
                int availableHeight = hStaff - topMargin - bottomMargin;
                int cardHeight = Math.Min(STAFF_CARD_FIXED_HEIGHT, Math.Max(300, availableHeight));
                int cardWidth = 540;
                int gap = 10;
                int sideMargin = 10;

                int lvWidth = Math.Max(200, wStaff - cardWidth - gap - (sideMargin * 2));

                // Position lvStaff
                lvStaff.SetBounds(sideMargin, topMargin, lvWidth, cardHeight);

                // Position cardStaffDetails
                cardStaffDetails.SetBounds(lvStaff.Right + gap, topMargin, cardWidth, cardHeight);

                // Fixed positions inside staff card
                int staffButtonY = 218;
                btnStaffSaveStatus.AutoSize = false;
                btnStaffSaveStatus.SetBounds(17, staffButtonY, 240, 36);

                btnStaffCancel.AutoSize = false;
                btnStaffCancel.SetBounds(280, staffButtonY, 100, 36);

                // Restrictions label below buttons
                lblStaffRestrictions.SetBounds(17, 264, 506, 105);
            }
        }

        // --- Win32 P/Invoke to set ListView header height ---
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const uint LVM_GETHEADER = 0x101F;
        private const uint HDM_LAYOUT    = 0x1205;

        private void SetListViewHeaderHeight(ListView lv, int height)
        {
            try
            {
                IntPtr hHeader = SendMessage(lv.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
                if (hHeader == IntPtr.Zero) return;

                // We use a small ImageList trick: set SmallImageList with a 1×height image
                // This forces the header to respect the height via the image list metrics.
                var il = new ImageList { ImageSize = new Size(1, height), ColorDepth = ColorDepth.Depth32Bit };
                Bitmap bmp = new Bitmap(1, height);
                using (Graphics g = Graphics.FromImage(bmp))
                    g.Clear(Color.Transparent);
                il.Images.Add(bmp);
                lv.SmallImageList = il;
            }
            catch { /* non-critical, ignore */ }
        }
    }
}
