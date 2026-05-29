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
        public static Color ThemeColor = Color.FromArgb(25, 118, 210); // Màu xanh dương đậm (#1976D2)
        public static Color ThemeColorLight = Color.FromArgb(235, 244, 255); // Màu xanh nhạt mờ cho Selection/Hover (#EBF4FF)
        public static Color ThemeColorAlternating = Color.FromArgb(248, 251, 255); // Màu xanh cực nhạt cho Zebra rows (#F8FBFF)

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
                // Thay đổi font cho các nhãn và control cơ bản (Bỏ qua các control phức tạp của MaterialSkin như ComboBox, TextBox, Button)
                string typeName = ctrl.GetType().Name;
                bool isComplexMaterialControl = typeName.StartsWith("Material") && 
                    (typeName.Contains("ComboBox") || typeName.Contains("TextBox") || typeName.Contains("Button") || typeName.Contains("Tab") || typeName.Contains("Card"));

                if ((ctrl is Label || ctrl is Button || ctrl is TextBox || ctrl is ComboBox || ctrl is ListView || ctrl is TreeView)
                    && !isComplexMaterialControl)
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

        // ── Unified ListView Styling — đồng bộ Dashboard ─────────────────────────

        /// <summary>Vẽ badge pill bo góc lên Graphics (dùng chung cho tất cả ListView OwnerDraw).</summary>
        public static void DrawBadgePill(Graphics g, string text, Rectangle cellBounds, Color bg, Color fg)
        {
            int w = Math.Min(cellBounds.Width - 16, 92);
            int h = 22;
            int x = cellBounds.X + (cellBounds.Width - w) / 2;
            int y = cellBounds.Y + (cellBounds.Height - h) / 2;
            Rectangle r = new Rectangle(x, y, w, h);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var path = UICommon.GetRoundedRectPath(r, 11))
            using (var brush = new SolidBrush(bg))
                g.FillPath(brush, path);
            TextRenderer.DrawText(g, text, new Font("Inter", 9F, FontStyle.Bold), r, fg,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        /// <summary>Trả về màu nền dòng chuẩn (zebra + hover + selected) cho DrawSubItem.</summary>
        public static Color GetRowBackColor(ListView lv, int rowIndex, bool isSelected)
        {
            int hovered = lv.Tag is int t ? t : -1;
            if (isSelected || rowIndex == hovered) return ThemeColorLight;
            return (rowIndex % 2 == 0) ? ThemeColorAlternating : Color.White;
        }

        /// <summary>
        /// Áp dụng style bảng đồng bộ Dashboard cho bất kỳ ListView nào.
        /// • Header màu chủ đạo, chữ trắng, cao 45 px.
        /// • Dòng: zebra + hover + selected, không gridlines.
        /// • customSubItemDraw = null → dùng renderer mặc định (text thuần).
        /// </summary>
        public static void StyleListView(
            ListView lv,
            DrawListViewSubItemEventHandler customSubItemDraw = null,
            int rowHeight = 45)
        {
            lv.View          = View.Details;
            lv.FullRowSelect = true;
            lv.MultiSelect   = false;
            lv.GridLines     = false;
            lv.BorderStyle   = BorderStyle.None;
            lv.BackColor     = Color.White;
            lv.OwnerDraw     = true;
            lv.HeaderStyle   = ColumnHeaderStyle.Nonclickable;

            // Row height: SmallImageList trick (không cần P/Invoke)
            var bmp = new Bitmap(1, rowHeight);
            using (var gfx = Graphics.FromImage(bmp)) gfx.Clear(Color.Transparent);
            var il = new ImageList { ImageSize = new Size(1, rowHeight), ColorDepth = ColorDepth.Depth32Bit };
            il.Images.Add(bmp);
            lv.SmallImageList = il;

            // Header draw (đồng bộ DrawColumnHeader của Dashboard)
            lv.DrawColumnHeader -= DrawColumnHeader;
            lv.DrawColumnHeader += DrawColumnHeader;

            // Item — tắt default draw
            lv.DrawItem += (s, e) => e.DrawDefault = false;

            // SubItem — caller's handler hoặc built-in default
            if (customSubItemDraw != null)
                lv.DrawSubItem += customSubItemDraw;
            else
                lv.DrawSubItem += Lv_DefaultSubItem;

            // Hover tracking — lưu index dòng hover vào lv.Tag
            lv.Tag = -1;
            lv.MouseMove += (s, e) => {
                var l = (ListView)s;
                int newRow = l.HitTest(e.Location).Item?.Index ?? -1;
                if (!(l.Tag is int cur) || cur != newRow) { l.Tag = newRow; l.Invalidate(); }
            };
            lv.MouseLeave += (s, e) => {
                var l = (ListView)s;
                if (l.Tag is int cur && cur != -1) { l.Tag = -1; l.Invalidate(); }
            };
        }

        private static void Lv_DefaultSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var lv = (ListView)sender;
            Color rowBg = GetRowBackColor(lv, e.ItemIndex, e.Item.Selected);
            using (var br = new SolidBrush(rowBg)) e.Graphics.FillRectangle(br, e.Bounds);

            Rectangle textRect = e.Bounds;
            textRect.Inflate(-10, 0);
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font f   = new Font("Inter", 9.5F, e.ColumnIndex == 0 ? FontStyle.Bold : FontStyle.Regular);
            Color fg = e.ColumnIndex == 0 ? Color.FromArgb(17, 24, 39) : Color.FromArgb(55, 65, 81);
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, f, textRect, fg, flags);

            using (var pen = new Pen(Color.FromArgb(243, 244, 246), 1))
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
