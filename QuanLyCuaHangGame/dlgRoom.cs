using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.Data;
using QuanLyCuaHangGame.UIHelper;

namespace QuanLyCuaHangGame
{
    public partial class dlgRoom : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int _selectedIndex = -1; // index đang chọn trong lvRooms

        public dlgRoom()
        {
            InitializeComponent();

            // DO NOT call AddFormToManage(this) because it triggers a global UpdateRendering
            // which recursively finds standard ListViews in frmComputer and overrides their OwnerDraw hooks.
            materialSkinManager = MaterialSkinManager.Instance;


            // Load phòng từ RoomStore (nguồn chung)
            LoadRooms();

            // Apply premium styles to match the Dashboard theme
            ApplyPremiumStyles();

            // Bind SizeChanged event to auto-resize columns
            lvRooms.SizeChanged += LvRooms_SizeChanged;
            LvRooms_SizeChanged(this, EventArgs.Empty);

            // Bind list selection
            lvRooms.SelectedIndexChanged += LvRooms_SelectedIndexChanged;

            // Mặc định ẩn card chi tiết, hiện khi chọn dòng
            ClearForm();
        }

        // ─── Load ────────────────────────────────────────────────────────────

        private void LoadRooms()
        {
            lvRooms.Items.Clear();
            foreach (var r in RoomStore.Rooms)
                lvRooms.Items.Add(new ListViewItem(r));
        }

        // ─── Chọn dòng → điền vào form chi tiết ────────────────────────────

        private void LvRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRooms.SelectedItems.Count == 0)
            {
                _selectedIndex = -1;
                ClearForm();
                return;
            }

            _selectedIndex = lvRooms.SelectedIndices[0];
            var row = RoomStore.Rooms[_selectedIndex];

            txtName.Text        = row[0];
            txtFloor.Text       = row[1];
            // row[2] là số máy (chỉ đọc)
            chkActive.Checked   = row[3] == "Hoạt động";
            txtDescription.Text = string.Empty; // chưa có field description trong store

            lblDetailsTitle.Text = $"Chi tiết: {row[0]}";
        }

        private void ClearForm()
        {
            txtName.Text        = string.Empty;
            txtFloor.Text       = string.Empty;
            txtDescription.Text = string.Empty;
            chkActive.Checked   = true;
            lblDetailsTitle.Text = "Thêm / Chỉnh sửa phòng";
            _selectedIndex = -1;
        }

        // ─── Nút THÊM ────────────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lvRooms.SelectedItems.Clear();
            ClearForm();
            txtName.Focus();
        }

        // ─── Nút XÓA ────────────────────────────────────────────────────────

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedIndex < 0)
            {
                ShowMsg("Vui lòng chọn phòng cần xóa.");
                return;
            }

            var name = RoomStore.Rooms[_selectedIndex][0];
            var confirm = QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show(
                $"Bạn có chắc muốn xóa \"{name}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            RoomStore.Rooms.RemoveAt(_selectedIndex);
            LoadRooms();
            ClearForm();
            ShowMsg($"Đã xóa phòng \"{name}\".");
        }

        // ─── Nút SỬA (chọn dòng để sửa) ─────────────────────────────────────

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedIndex < 0)
            {
                ShowMsg("Vui lòng chọn phòng cần sửa.");
                return;
            }
            txtName.Focus();
        }

        // ─── Nút LƯU ────────────────────────────────────────────────────────

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name  = txtName.Text.Trim();
            string floor = txtFloor.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                ShowMsg("Vui lòng nhập tên phòng.");
                txtName.Focus();
                return;
            }

            string status = chkActive.Checked ? "Hoạt động" : "Chưa kích hoạt";

            if (_selectedIndex >= 0)
            {
                // Cập nhật phòng đang chọn
                RoomStore.Rooms[_selectedIndex][0] = name;
                RoomStore.Rooms[_selectedIndex][1] = floor;
                RoomStore.Rooms[_selectedIndex][3] = status;
                ShowMsg($"Đã cập nhật phòng \"{name}\".");
            }
            else
            {
                // Thêm phòng mới
                RoomStore.Rooms.Add(new[] { name, floor, "0 máy", status });
                ShowMsg($"Đã thêm phòng \"{name}\".");
            }

            LoadRooms();
            ClearForm();
        }

        // ─── Nút HỦY ────────────────────────────────────────────────────────

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ─── Nút ĐÓNG (đóng dialog, báo OK để frmComputer refresh) ──────────

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ─── Helpers ─────────────────────────────────────────────────────────

        private void ShowMsg(string msg)
        {
            MaterialSnackBar snack = new MaterialSnackBar(msg, 2500);
            snack.Show(this);
        }

        private void ApplyPremiumStyles()
        {
            pnlToolbar.BackColor = Color.White;
            pnlFooter.BackColor  = Color.White;

            pnlWarning.BackColor = Color.FromArgb(254, 242, 242);
            lblWarning.ForeColor  = Color.FromArgb(220, 38, 38);
            lblWarning.Font       = new Font("Inter", 9.5F, FontStyle.Regular);

            grpStats.BackColor = Color.FromArgb(248, 249, 250);

            lblListTitle.ForeColor = DashboardUIHelper.ThemeColor;
            lblListTitle.Font      = new Font("Inter", 10F, FontStyle.Bold);

            // Row height 40px cho lvRooms giống dashboard
            var il = new System.Windows.Forms.ImageList { ImageSize = new System.Drawing.Size(1, 40), ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit };
            var bmp = new System.Drawing.Bitmap(1, 40);
            using (var g = System.Drawing.Graphics.FromImage(bmp)) g.Clear(System.Drawing.Color.Transparent);
            il.Images.Add(bmp);
            lvRooms.SmallImageList = il;

            DashboardUIHelper.ApplyGlobalModernStyle(this);
        }

        // ─── OwnerDraw handlers cho lvRooms (giống dashboard) ────────────────
        private void LvRooms_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
            => DashboardUIHelper.DrawColumnHeader(sender, e);

        private void LvRooms_DrawItem(object sender, DrawListViewItemEventArgs e)
            => e.DrawDefault = false;

        private void LvRooms_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Zebra + selected
            Color rowBg = e.Item.Selected ? DashboardUIHelper.ThemeColorLight
                        : (e.ItemIndex % 2 == 0 ? DashboardUIHelper.ThemeColorAlternating : Color.White);

            using (var brush = new System.Drawing.SolidBrush(rowBg))
                e.Graphics.FillRectangle(brush, e.Bounds);

            var textBounds = e.Bounds;
            textBounds.Inflate(-8, 0);
            var flags = System.Windows.Forms.TextFormatFlags.VerticalCenter
                      | System.Windows.Forms.TextFormatFlags.Left
                      | System.Windows.Forms.TextFormatFlags.EndEllipsis;

            // Cột Tên phòng: tím đậm bold
            if (e.ColumnIndex == 0)
            {
                System.Windows.Forms.TextRenderer.DrawText(e.Graphics, e.SubItem.Text,
                    new Font("Inter", 9.5F, FontStyle.Bold), textBounds, DashboardUIHelper.ThemeColor, flags);
            }
            // Cột Trạng thái: badge màu
            else if (e.ColumnIndex == 3)
            {
                string val = e.SubItem.Text;
                Color bgBadge   = val == "Hoạt động" ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242);
                Color fgBadge   = val == "Hoạt động" ? Color.FromArgb(22, 163, 74)   : Color.FromArgb(220, 38, 38);
                int bW = Math.Min(e.Bounds.Width - 16, 100), bH = 22;
                var br = new System.Drawing.Rectangle(e.Bounds.X + 8, e.Bounds.Y + (e.Bounds.Height - bH) / 2, bW, bH);
                using (var path = UICommon.GetRoundedRectPath(br, 11))
                using (var bb = new System.Drawing.SolidBrush(bgBadge))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(bb, path);
                }
                System.Windows.Forms.TextRenderer.DrawText(e.Graphics, val,
                    new Font("Inter", 9F, FontStyle.Bold), br, fgBadge,
                    System.Windows.Forms.TextFormatFlags.VerticalCenter | System.Windows.Forms.TextFormatFlags.HorizontalCenter);
            }
            else
            {
                System.Windows.Forms.TextRenderer.DrawText(e.Graphics, e.SubItem.Text,
                    new Font("Inter", 9.5F, FontStyle.Regular), textBounds, Color.FromArgb(55, 65, 81), flags);
            }

            // Đường kẻ ngang nhạt cuối dòng
            using (var pen = new System.Drawing.Pen(Color.FromArgb(243, 244, 246), 1))
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }


        private void LvRooms_SizeChanged(object sender, EventArgs e)
        {
            UICommon.AutoResizeListViewColumns(lvRooms, new double[] { 0.35, 0.15, 0.20, 0.30 });
        }
    }
}
