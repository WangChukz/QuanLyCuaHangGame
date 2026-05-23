using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;

namespace QuanLyCuaHangGame.UIHelper
{
    public static class DashboardUIHelper
    {
        // --- HỆ THỐNG MÀU CHỦ ĐẠO (THEME COLOR) ---
        // Sửa duy nhất mã màu dưới đây để thay đổi toàn bộ hệ thống (Header, Grid, Chart, Pills, Footer, v.v.)
        public static Color ThemeColor = Color.FromArgb(108, 76, 241); // Màu tím đậm thương hiệu (#6C4CF1)
        public static Color ThemeColorLight = Color.FromArgb(243, 239, 255); // Màu tím nhạt mờ cho Selection/Hover
        public static Color ThemeColorAlternating = Color.FromArgb(250, 248, 255); // Màu tím cực nhạt cho Zebra rows

        public static void ApplyKPICardStyles(
            Label lblDoanhThuValue, Label lblDoanhThuSub,
            Label lblMayValue, Label lblMaySub,
            Label lblHoiVienValue, Label lblHoiVienSub,
            Label lblXuLyValue, Label lblXuLySub)
        {
            // Doanh thu
            lblDoanhThuValue.Font = new Font("Inter", 26F, FontStyle.Bold);
            lblDoanhThuValue.ForeColor = Color.FromArgb(31, 41, 55); 
            lblDoanhThuSub.Font = new Font("Inter", 9.75F, FontStyle.Bold);
            lblDoanhThuSub.ForeColor = Color.FromArgb(34, 197, 94);

            // Máy đang chạy
            lblMayValue.Font = new Font("Inter", 26F, FontStyle.Bold);
            lblMayValue.ForeColor = Color.FromArgb(33, 150, 243);
            lblMaySub.Font = new Font("Inter", 9.75F, FontStyle.Regular);
            lblMaySub.ForeColor = Color.DimGray;

            // Hội viên
            lblHoiVienValue.Font = new Font("Inter", 26F, FontStyle.Bold);
            lblHoiVienValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblHoiVienSub.Font = new Font("Inter", 9.75F, FontStyle.Regular);
            lblHoiVienSub.ForeColor = Color.DimGray;

            // Cần xử lý
            lblXuLyValue.Font = new Font("Inter", 26F, FontStyle.Bold);
            lblXuLyValue.ForeColor = Color.FromArgb(239, 68, 68);
            lblXuLySub.Font = new Font("Inter", 9.75F, FontStyle.Bold);
            lblXuLySub.ForeColor = Color.FromArgb(239, 68, 68);
        }

        public static void FormatRoomMapButton(Button btn, string status)
        {
            Color bgEmpty = Color.FromArgb(240, 253, 244); // #F0FDF4
            Color textEmpty = Color.FromArgb(22, 163, 74); // #16A34A
            Color borderEmpty = Color.FromArgb(74, 222, 128); // #4ADE80

            Color bgInUse = Color.FromArgb(239, 246, 255); // #EFF6FF
            Color textInUse = Color.FromArgb(37, 99, 235); // #2563EB
            Color borderInUse = Color.FromArgb(96, 165, 250); // #60A5FA

            Color bgError = Color.FromArgb(254, 242, 242); // #FEF2F2
            Color textError = Color.FromArgb(220, 38, 38); // #DC2626
            Color borderError = Color.FromArgb(248, 113, 113); // #F87171

            Color bgGuest = Color.FromArgb(255, 247, 237); // #FFF7ED
            Color textGuest = Color.FromArgb(234, 88, 12); // #EA580C
            Color borderGuest = Color.FromArgb(251, 146, 60); // #FB923C

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Inter", 9F, FontStyle.Bold);
            btn.Margin = new Padding(6);

            Color borderColor = borderEmpty;

            if (status == "Trống")
            {
                btn.BackColor = bgEmpty;
                btn.ForeColor = textEmpty;
                borderColor = borderEmpty;
            }
            else if (status == "Hỏng")
            {
                btn.BackColor = bgError;
                btn.ForeColor = textError;
                borderColor = borderError;
            }
            else if (status == "Vãng lai")
            {
                btn.BackColor = bgGuest;
                btn.ForeColor = textGuest;
                borderColor = borderGuest;
            }
            else
            {
                btn.BackColor = bgInUse;
                btn.ForeColor = textInUse;
                borderColor = borderInUse;
            }

            btn.Tag = borderColor;

            // Bo góc mượt mà cho các nút
            btn.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, btn.Width, btn.Height), 10));
            
            btn.Paint -= BtnRoom_Paint;
            btn.Paint += BtnRoom_Paint;

            btn.SizeChanged += (s, e) => {
                btn.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, btn.Width, btn.Height), 10));
                btn.Invalidate();
            };
        }

        private static void BtnRoom_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Color borderColor)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var pen = new Pen(borderColor, 2f)) // Viền dày 2px rõ nét giống ảnh
                {
                    var rect = new Rectangle(1, 1, btn.Width - 3, btn.Height - 3);
                    using (var path = UICommon.GetRoundedRectPath(rect, 8))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        public static void StyleFooter(Panel pnlFooter, Label lblFooter)
        {
            Color footerBg = ThemeColor; 
            pnlFooter.BackColor = footerBg; 
            
            lblFooter.BackColor = Color.Transparent; // Đảm bảo nền nhãn trong suốt
            lblFooter.ForeColor = Color.White;
            lblFooter.Font = new Font("Inter", 9.75F, FontStyle.Regular);
        }

        public static void StyleModernDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;

            // Màu Header đồng bộ với màu chủ đạo
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor; 
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.ColumnHeadersHeight = 45;

            // Dòng dữ liệu
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            dgv.DefaultCellStyle.Font = new Font("Inter", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = ThemeColorLight; 
            dgv.DefaultCellStyle.SelectionForeColor = ThemeColor;
            dgv.RowTemplate.Height = 45;
            dgv.GridColor = Color.FromArgb(240, 240, 240); // Đường kẻ ngang mờ

            // Zebra Rows (Chẵn lẻ)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ThemeColorAlternating;

            // Hiệu ứng Hover
            dgv.CellMouseEnter += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = ThemeColorLight;
                }
            };
            dgv.CellMouseLeave += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    // Trả lại màu cũ (phụ thuộc vào Zebra row)
                    if (e.RowIndex % 2 == 0)
                        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    else
                        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = ThemeColorAlternating;
                }
            };
        }

        public static void DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color headerBg = ThemeColor; 
            
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
            else if (e.Header.TextAlign == HorizontalAlignment.Right)
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Right | TextFormatFlags.EndEllipsis;

            Rectangle textRect = e.Bounds;
            textRect.Offset(8, 0);
            textRect.Width -= 16;

            TextRenderer.DrawText(e.Graphics, text, font, textRect, textColor, flags);

            // Vẽ viền phân tách các cột dọc màu sáng tinh tế
            using (Pen pen = new Pen(Color.FromArgb(50, ThemeColor.R, ThemeColor.G, ThemeColor.B), 1))
            {
                e.Graphics.DrawLine(pen, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom);
            }
        }

        public static void DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;
        }

        public static void DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Xen kẽ màu nền dòng: Dòng lẻ tím mờ mềm mại, dòng chẵn màu trắng
            Color rowBg = (e.ItemIndex % 2 == 0) ? ThemeColorAlternating : Color.White; 
            
            if (e.Item.Selected)
            {
                rowBg = ThemeColorLight; // Màu khi hover/click chọn dòng
            }

            using (SolidBrush bgBrush = new SolidBrush(rowBg))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            int colIndex = e.ColumnIndex;
            string val = e.SubItem.Text;

            Rectangle textBounds = e.Bounds;
            textBounds.Offset(8, 0);
            textBounds.Width -= 16;

            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            if (e.Header.TextAlign == HorizontalAlignment.Center)
                flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;

            if (colIndex == 0) // Cột Máy: Chữ đen bold nổi bật
            {
                Font fontBold = new Font("Inter", 9.5F, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, val, fontBold, textBounds, Color.FromArgb(17, 24, 39), flags);
            }
            else if (colIndex == 2) // Cột Loại: Vẽ Badge (Hội viên / Vãng lai) bo góc siêu đẹp
            {
                Color badgeBg = Color.FromArgb(243, 244, 246);
                Color badgeText = Color.FromArgb(55, 65, 81);

                if (val == "Hội viên")
                {
                    badgeBg = Color.FromArgb(224, 242, 254); // Xanh nhạt
                    badgeText = Color.FromArgb(2, 132, 199);  // Xanh sẫm
                }
                else if (val == "Vãng lai")
                {
                    badgeBg = Color.FromArgb(243, 244, 246); // Xám nhạt
                    badgeText = Color.FromArgb(75, 85, 99);   // Xám sẫm
                }

                int badgeW = 75;
                int badgeH = 22;
                int badgeX = e.Bounds.X + (e.Bounds.Width - badgeW) / 2;
                int badgeY = e.Bounds.Y + (e.Bounds.Height - badgeH) / 2;
                Rectangle badgeBounds = new Rectangle(badgeX, badgeY, badgeW, badgeH);

                using (var path = UICommon.GetRoundedRectPath(badgeBounds, 11))
                using (var brush = new SolidBrush(badgeBg))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }

                Font badgeFont = new Font("Inter", 9F, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, val, badgeFont, badgeBounds, badgeText, 
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else if (colIndex == 7) // Cột Thao tác: "ĐÓNG" màu tím đậm chủ đạo
            {
                Font fontAction = new Font("Inter", 9.5F, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, "ĐÓNG", fontAction, textBounds, ThemeColor, flags);
            }
            else // Các cột thông tin số liệu thông thường
            {
                Font fontRegular = new Font("Inter", 9.5F, FontStyle.Regular);
                TextRenderer.DrawText(e.Graphics, val, fontRegular, textBounds, Color.FromArgb(55, 65, 81), flags);
            }

            // Vẽ viền gạch dưới mờ cho mỗi hàng
            using (Pen borderPen = new Pen(Color.FromArgb(243, 244, 246), 1))
            {
                e.Graphics.DrawLine(borderPen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }
        }

        public static void ApplyGlobalModernStyle(Control parent)
        {
            FontFamily family;
            try
            {
                family = new FontFamily("Inter");
            }
            catch
            {
                family = new FontFamily("Segoe UI"); // Fallback an toàn nếu máy không có Inter
            }

            foreach (Control ctrl in parent.Controls)
            {
                // Thay đổi font cho các nhãn và control cơ bản (Bỏ qua MaterialSkin Controls vì nó tự quản lý font riêng)
                if (ctrl is Label || ctrl is Button || ctrl is TextBox || ctrl is ComboBox || ctrl is ListView || ctrl is TreeView)
                {
                    if (ctrl.Font.Bold)
                        ctrl.Font = new Font(family, ctrl.Font.Size, FontStyle.Bold);
                    else
                        ctrl.Font = new Font(family, ctrl.Font.Size, ctrl.Font.Style);
                }

                // Bo góc cho các panel đặc biệt (như Header/Footer) nếu muốn
                // if (ctrl is Panel pnl && ctrl.Name != "pnlFooter") 
                //    pnl.Region = new Region(UICommon.GetRoundedRectPath(new Rectangle(0, 0, pnl.Width, pnl.Height), 8));

                if (ctrl.HasChildren)
                {
                    ApplyGlobalModernStyle(ctrl);
                }
            }
        }
    }
}
