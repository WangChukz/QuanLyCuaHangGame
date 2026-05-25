using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangGame.UIHelper
{
    public static class UserUIHelper
    {
        public static void StyleUserListView(ListView lv)
        {
            // Thiết lập các thuộc tính cơ bản để ListView trông hiện đại hơn
            lv.BackColor = Color.White;
            lv.BorderStyle = BorderStyle.None;
            lv.FullRowSelect = true;
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.View = View.Details;
            lv.OwnerDraw = true; // Kích hoạt vẽ thủ công để UI đẹp hơn

            lv.DrawColumnHeader -= Lv_DrawColumnHeader;
            lv.DrawColumnHeader += Lv_DrawColumnHeader;

            lv.DrawItem -= Lv_DrawItem;
            lv.DrawItem += Lv_DrawItem;

            lv.DrawSubItem -= Lv_DrawSubItem;
            lv.DrawSubItem += Lv_DrawSubItem;
        }

        private static void Lv_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerBg = DashboardUIHelper.ThemeColor;
            using (SolidBrush brush = new SolidBrush(headerBg))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            string text = e.Header.Text;
            Font font = new Font("Inter", 9.5F, FontStyle.Bold);
            Color textColor = Color.White;

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            if (e.Header.TextAlign == HorizontalAlignment.Center)
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;

            Rectangle textRect = e.Bounds;
            textRect.Offset(8, 0);
            textRect.Width -= 16;

            TextRenderer.DrawText(e.Graphics, text, font, textRect, textColor, flags);
        }

        private static void Lv_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;
        }

        private static void Lv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color rowBg = (e.ItemIndex % 2 == 0) ? DashboardUIHelper.ThemeColorAlternating : Color.White; 
            
            if (e.Item.Selected)
            {
                rowBg = DashboardUIHelper.ThemeColorLight;
            }

            using (SolidBrush bgBrush = new SolidBrush(rowBg))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            string val = e.SubItem.Text;
            Rectangle textBounds = e.Bounds;
            textBounds.Offset(8, 0);
            textBounds.Width -= 16;

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font fontRegular = new Font("Inter", 9.5F, FontStyle.Regular);
            Color textColor = Color.FromArgb(55, 65, 81);

            // Xử lý cột Vai trò / Trạng thái nếu cần vẽ Badge
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // Vai trò hoặc Trạng thái
            {
                Color badgeBg = Color.FromArgb(243, 244, 246);
                Color badgeText = Color.FromArgb(55, 65, 81);

                if (val == "Admin")
                {
                    badgeBg = DashboardUIHelper.ThemeColor;
                    badgeText = Color.White;
                }
                else if (val == "Staff")
                {
                    badgeBg = Color.FromArgb(220, 252, 231); // Xanh lá nhạt
                    badgeText = Color.FromArgb(22, 163, 74);
                }
                else if (val == "Hoạt động")
                {
                    badgeBg = Color.FromArgb(76, 175, 80); // Xanh lá đậm
                    badgeText = Color.White;
                }
                else if (val == "Nghỉ phép")
                {
                    badgeBg = Color.FromArgb(255, 152, 0); // Cam đậm
                    badgeText = Color.White;
                }
                else if (val == "Khóa")
                {
                    badgeBg = Color.FromArgb(254, 226, 226); // Đỏ nhạt
                    badgeText = Color.FromArgb(220, 38, 38);
                }

                int badgeW = 80;
                int badgeH = 24;
                int badgeX = e.Bounds.X + 8; // Căn trái giống header
                int badgeY = e.Bounds.Y + (e.Bounds.Height - badgeH) / 2;
                Rectangle badgeBounds = new Rectangle(badgeX, badgeY, badgeW, badgeH);

                using (var path = UICommon.GetRoundedRectPath(badgeBounds, 12))
                using (var brush = new SolidBrush(badgeBg))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }

                Font badgeFont = new Font("Inter", 9F, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, val, badgeFont, badgeBounds, badgeText, 
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else
            {
                if (e.ColumnIndex == 0) // Họ tên (Cột 0) in đậm
                {
                    fontRegular = new Font("Inter", 9.5F, FontStyle.Bold);
                    textColor = Color.FromArgb(17, 24, 39);
                }
                TextRenderer.DrawText(e.Graphics, val, fontRegular, textBounds, textColor, flags);
            }

            // Vẽ viền ngang
            using (Pen borderPen = new Pen(Color.FromArgb(243, 244, 246), 1))
            {
                e.Graphics.DrawLine(borderPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }
        }

        public static void StylePermissionMatrix(ListView lv)
        {
            lv.BackColor = Color.White;
            lv.BorderStyle = BorderStyle.None;
            lv.FullRowSelect = true;
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.View = View.Details;
            lv.OwnerDraw = true;

            lv.DrawColumnHeader += Lv_DrawColumnHeader;
            lv.DrawItem += Lv_DrawItem;
            lv.DrawSubItem += Matrix_DrawSubItem;
        }

        private static void Matrix_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color rowBg = (e.ItemIndex % 2 == 0) ? DashboardUIHelper.ThemeColorAlternating : Color.White; 
            
            if (e.Item.Selected) rowBg = DashboardUIHelper.ThemeColorLight;
            using (SolidBrush bgBrush = new SolidBrush(rowBg)) e.Graphics.FillRectangle(bgBrush, e.Bounds);

            string val = e.SubItem.Text;
            Rectangle textBounds = e.Bounds;
            textBounds.Offset(8, 0); textBounds.Width -= 16;
            
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font fontRegular = new Font("Inter", 9.5F, FontStyle.Regular);
            Color textColor = Color.FromArgb(55, 65, 81);

            if (e.ColumnIndex == 0) 
            {
                fontRegular = new Font("Inter", 9.5F, FontStyle.Bold);
                textColor = Color.FromArgb(17, 24, 39);
            }
            else
            {
                if (val.Contains("✅")) textColor = Color.FromArgb(22, 163, 74);
                else if (val.Contains("❌")) textColor = Color.FromArgb(220, 38, 38);
                else if (val.Contains("⚠️")) textColor = Color.FromArgb(234, 179, 8);
                
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;
            }

            TextRenderer.DrawText(e.Graphics, val, fontRegular, textBounds, textColor, flags);
            using (Pen borderPen = new Pen(Color.FromArgb(243, 244, 246), 1)) e.Graphics.DrawLine(borderPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
