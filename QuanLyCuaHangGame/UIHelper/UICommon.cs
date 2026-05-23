using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCuaHangGame.UIHelper
{
    public static class UICommon
    {
        // Hàm tự động căn đều cột ListView theo tỷ lệ phần trăm
        public static void AutoResizeListViewColumns(ListView lv, double[] percentages)
        {
            if (lv.Columns.Count == 0 || percentages == null || percentages.Length == 0) return;

            int totalWidth = lv.ClientSize.Width;
            int colCount = Math.Min(lv.Columns.Count, percentages.Length);

            int allocatedWidth = 0;
            for (int i = 0; i < colCount - 1; i++)
            {
                int colWidth = (int)(totalWidth * percentages[i]);
                lv.Columns[i].Width = colWidth;
                allocatedWidth += colWidth;
            }

            // Cột cuối cùng lấy toàn bộ phần còn lại để không bị thừa khoảng trắng
            if (colCount <= lv.Columns.Count)
            {
                lv.Columns[colCount - 1].Width = Math.Max(totalWidth - allocatedWidth, 80);
            }
        }

        // Hàm tạo hình chữ nhật bo góc dùng cho GDI+
        public static System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            // top left arc
            path.AddArc(arc, 180, 90);

            // top right arc
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
