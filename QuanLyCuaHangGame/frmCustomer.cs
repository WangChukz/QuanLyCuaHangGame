using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangGame.BLL;
using QuanLyCuaHangGame.UIHelper;

namespace QuanLyCuaHangGame
{
    public partial class frmCustomer : MaterialForm
    {
        private CustomerBLL _customerBLL;
        private int _selectedCustomerId = -1;

        public frmCustomer()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            UIHelper.UICommon.ApplyTheme(this);

            _customerBLL = new CustomerBLL();

            // Wire up events
            this.Load += FrmCustomer_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            mlvHoiVien.SelectedIndexChanged += MlvHoiVien_SelectedIndexChanged;
            btnNapTien.Click += BtnNapTien_Click;
            if (btnNapTienTop != null) btnNapTienTop.Click += (s, e) => { txtMoney.Focus(); };
            if (btnHistoryTop != null) btnHistoryTop.Click += (s, e) => { mlvHistory.Focus(); };

            // Áp dụng style bảng đồng bộ Dashboard cho cả 2 ListView
            UIHelper.DashboardUIHelper.StyleListView(mlvHoiVien, DrawSubItem_HoiVien);
            UIHelper.DashboardUIHelper.StyleListView(mlvHistory, DrawSubItem_History);
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (this.Parent != null)
                this.MinimumSize = new System.Drawing.Size(0, 0);

            // Thiết lập màu thẻ tài khoản
            cardUser.BackColor = Color.FromArgb(25, 118, 210);
            cardUser.ForeColor = Color.White;
            cardUser.Paint += CardUser_Paint;
            lblCardTitle.Font  = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardTitle.ForeColor = Color.WhiteSmoke;
            lblCardName.Font   = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCardName.ForeColor  = Color.White;
            lblCardInfo.Font   = new Font("Segoe UI", 10F);
            lblCardInfo.ForeColor  = Color.WhiteSmoke;
            lblCardBalanceTitle.Font = new Font("Segoe UI", 9F);
            lblCardBalanceTitle.ForeColor = Color.WhiteSmoke;
            lblCardBalance.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCardBalance.ForeColor = Color.White;
            lblCardRegDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardRegDate.ForeColor = Color.White;
            lblCardPin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardPin.ForeColor = Color.White;
            foreach (Control ctrl in cardUser.Controls)
                if (ctrl is Label lbl) lbl.BackColor = Color.Transparent;

            LoadCustomerList("");
            ClearCustomerDetails();

            // Resize cột
            UICommon.AutoResizeListViewColumns(mlvHoiVien, new double[] { 0.28, 0.18, 0.18, 0.18, 0.18 });
            UICommon.AutoResizeListViewColumns(mlvHistory,  new double[] { 0.20, 0.38, 0.20, 0.22 });
            this.SizeChanged += (s, ev) => {
                UICommon.AutoResizeListViewColumns(mlvHoiVien, new double[] { 0.28, 0.18, 0.18, 0.18, 0.18 });
                UICommon.AutoResizeListViewColumns(mlvHistory,  new double[] { 0.20, 0.38, 0.20, 0.22 });
            };
        }



        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomerList(txtSearch.Text);
        }

        private void LoadCustomerList(string keyword)
        {
            mlvHoiVien.Items.Clear();
            var customers = _customerBLL.SearchCustomers(keyword);
            
            foreach (var c in customers)
            {
                var item = new ListViewItem(c.FullName);
                item.SubItems.Add(c.Phone);
                item.SubItems.Add(c.Username);
                item.SubItems.Add(c.Balance.ToString("N0") + "đ");
                item.SubItems.Add(c.IsActive ? "Hoạt động" : "Khóa");
                item.Tag = c.Id;
                mlvHoiVien.Items.Add(item);
            }
        }

        private void MlvHoiVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mlvHoiVien.SelectedItems.Count > 0)
            {
                _selectedCustomerId = (int)mlvHoiVien.SelectedItems[0].Tag;
                LoadCustomerDetails(_selectedCustomerId);
                LoadTransactionHistory(_selectedCustomerId);
            }
            else
            {
                _selectedCustomerId = -1;
                ClearCustomerDetails();
            }
        }

        private void LoadCustomerDetails(int customerId)
        {
            var c = _customerBLL.GetCustomerById(customerId);
            if (c != null)
            {
                lblCardName.Text = $"GAMEZONE · {c.Username}";
                lblCardInfo.Text = $"{c.FullName} · {c.Phone}";
                lblCardBalance.Text = c.Balance.ToString("N0") + "đ";
                lblCardRegDate.Text = $"Đăng ký: {c.CreatedAt:dd/MM/yyyy}";
                lblCardPin.Text = $"PIN: ****";
            }
        }

        private void ClearCustomerDetails()
        {
            lblCardName.Text = "GAMEZONE · (Chưa chọn)";
            lblCardInfo.Text = "-";
            lblCardBalance.Text = "0đ";
            lblCardRegDate.Text = "Đăng ký: -";
            lblCardPin.Text = "PIN: ****";
            mlvHistory.Items.Clear();
        }

        private void BtnNapTien_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId <= 0)
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Vui lòng chọn khách hàng để nạp tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(txtMoney.Text.Trim() == "")
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Vui lòng nhập số tiền cần nạp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(txtMoney.Text, out decimal amount) && amount > 0)
            {
                try
                {
                    int currentUserId = SessionContext.CurrentUserId;
                    _customerBLL.TopUp(_selectedCustomerId, amount, txtNote.Text, currentUserId);
                    
                    MaterialSkin.Controls.MaterialMessageBox.Show("Nạp tiền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh data
                    LoadCustomerDetails(_selectedCustomerId);
                    LoadTransactionHistory(_selectedCustomerId);
                    
                    // Refresh balance in list view too
                    if (mlvHoiVien.SelectedItems.Count > 0)
                    {
                        var selectedItem = mlvHoiVien.SelectedItems[0];
                        var customer = _customerBLL.GetCustomerById(_selectedCustomerId);
                        selectedItem.SubItems[3].Text = customer.Balance.ToString("N0") + "đ";
                    }

                    // Clear input
                    txtMoney.Clear();
                    txtNote.Clear();
                }
                catch (Exception ex)
                {
                    MaterialSkin.Controls.MaterialMessageBox.Show($"Lỗi khi nạp tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("Vui lòng nhập số tiền hợp lệ (> 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadTransactionHistory(int customerId)
        {
            mlvHistory.Items.Clear();
            var history = _customerBLL.GetTransactionHistory(customerId);

            var topUps = history.Item1;
            var spends = history.Item2;

            var merged = new System.Collections.Generic.List<Tuple<string, string, decimal, DateTime>>();
            
            foreach (var t in topUps)
                merged.Add(new Tuple<string, string, decimal, DateTime>("+ Nạp tiền", t.Note, t.Amount, t.CreatedAt));
            
            foreach (var t in spends)
                merged.Add(new Tuple<string, string, decimal, DateTime>("- Thanh toán", t.Description, -t.Amount, t.CreatedAt));

            foreach (var t in merged.OrderByDescending(m => m.Item4))
            {
                var item = new ListViewItem(t.Item1);
                item.SubItems.Add(t.Item2);
                item.SubItems.Add((t.Item3 > 0 ? "+" : "") + t.Item3.ToString("N0") + "đ");
                item.SubItems.Add(t.Item4.ToString("dd/MM/yyyy HH:mm"));
                mlvHistory.Items.Add(item);
            }
        }

        // ── Owner Draw handlers — đồng bộ Dashboard ─────────────────────────────

        private void DrawSubItem_HoiVien(object sender, DrawListViewSubItemEventArgs e)
        {
            var lv = (System.Windows.Forms.ListView)sender;
            Color rowBg = UIHelper.DashboardUIHelper.GetRowBackColor(lv, e.ItemIndex, e.Item.Selected);
            using (var br = new SolidBrush(rowBg)) e.Graphics.FillRectangle(br, e.Bounds);

            string val = e.SubItem.Text;
            Rectangle textRect = e.Bounds; textRect.Inflate(-10, 0);
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;

            if (e.ColumnIndex == 4) // Trạng thái — badge
            {
                Color bg = val == "Hoạt động" ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
                Color fg = val == "Hoạt động" ? Color.FromArgb(22, 163, 74)   : Color.FromArgb(220, 38, 38);
                UIHelper.DashboardUIHelper.DrawBadgePill(e.Graphics, val, e.Bounds, bg, fg);
            }
            else if (e.ColumnIndex == 3) // Số dư — xanh bold
            {
                TextRenderer.DrawText(e.Graphics, val, new Font("Inter", 9.5F, FontStyle.Bold), textRect, Color.FromArgb(22, 163, 74), flags);
            }
            else if (e.ColumnIndex == 0) // Họ tên — bold
            {
                TextRenderer.DrawText(e.Graphics, val, new Font("Inter", 9.5F, FontStyle.Bold), textRect, Color.FromArgb(17, 24, 39), flags);
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, val, new Font("Inter", 9.5F), textRect, Color.FromArgb(55, 65, 81), flags);
            }
            using (var pen = new Pen(Color.FromArgb(243, 244, 246), 1))
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        private void DrawSubItem_History(object sender, DrawListViewSubItemEventArgs e)
        {
            var lv = (System.Windows.Forms.ListView)sender;
            Color rowBg = UIHelper.DashboardUIHelper.GetRowBackColor(lv, e.ItemIndex, e.Item.Selected);
            using (var br = new SolidBrush(rowBg)) e.Graphics.FillRectangle(br, e.Bounds);

            string val = e.SubItem.Text;
            Rectangle textRect = e.Bounds; textRect.Inflate(-10, 0);
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;

            Color fg = Color.FromArgb(55, 65, 81);
            FontStyle fs = FontStyle.Regular;

            // Loại GD (col 0) và Số tiền (col 2): màu xanh/đỏ theo dấu
            if (e.ColumnIndex == 0 || e.ColumnIndex == 2)
            {
                bool isPlus = val.StartsWith("+");
                fg = isPlus ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
                fs = FontStyle.Bold;
            }

            TextRenderer.DrawText(e.Graphics, val, new Font("Inter", 9.5F, fs), textRect, fg, flags);
            using (var pen = new Pen(Color.FromArgb(243, 244, 246), 1))
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        private void CardUser_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
            {
                Rectangle r1 = lblCardRegDate.Bounds;
                r1.Inflate(8, 4);
                FillRoundRect(e.Graphics, brush, r1, 10);

                Rectangle r2 = lblCardPin.Bounds;
                r2.Inflate(8, 4);
                FillRoundRect(e.Graphics, brush, r2, 10);
            }
        }

        private void FillRoundRect(Graphics g, Brush brush, Rectangle rect, int radius)
        {
            int d = radius * 2;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }

        private void cardNapTien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không phải số và backspace
            }
        }
    }
}
