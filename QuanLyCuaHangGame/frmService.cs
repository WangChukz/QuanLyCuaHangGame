using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.BLL.Services;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.GUI
{
    public partial class frmService : MaterialForm
    {
        private ServiceItemService serviceItemService;
        private List<ServiceItem> allServices;
        private int currentServiceId = 0;
        private bool isEditing = false;

        public frmService()
        {
            InitializeComponent();

            // Gắn các event handler
            this.Load += frmService_Load;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            lvServices.SelectedIndexChanged += lvServices_SelectedIndexChanged;
            cboCategoryFilter.SelectedIndexChanged += cboCategoryFilter_SelectedIndexChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // DrawSubItem được gắn trong SetupListView() bằng DashboardUIHelper.StyleListView
            UIHelper.UICommon.ApplyTheme(this, true);

            serviceItemService = new ServiceItemService();
            allServices = new System.Collections.Generic.List<ServiceItem>();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            try
            {
                // Thêm thanh Header giống ảnh mockup
                Panel pnlHeader = new Panel();
                pnlHeader.Height = 55;
                pnlHeader.Dock = DockStyle.Top;
                pnlHeader.BackColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
                
                Label lblHeaderTitle = new Label();
                lblHeaderTitle.Text = "Quản lý dịch vụ (Đồ ăn, nước uống)";
                lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
                lblHeaderTitle.ForeColor = System.Drawing.Color.White;
                lblHeaderTitle.AutoSize = true;
                lblHeaderTitle.Location = new System.Drawing.Point(15, 15);
                pnlHeader.Controls.Add(lblHeaderTitle);

                this.Controls.Add(pnlHeader);
                pnlHeader.SendToBack(); // Đẩy lên đỉnh trên cùng

                // Xoá MinimumSize khi nhúc vào tab để form tự resize
                if (this.Parent != null)
                    this.MinimumSize = new System.Drawing.Size(0, 0);

                SetupListView();
                LoadCategoriesToFilter();
                LoadServices();
                UpdateStatusBar();

                // Căn lại cột ngay sau khi load
                UIHelper.UICommon.AutoResizeListViewColumns(lvServices, new double[] { 0.40, 0.25, 0.20, 0.15 });
                this.SizeChanged += (s, ev) =>
                    UIHelper.UICommon.AutoResizeListViewColumns(lvServices, new double[] { 0.40, 0.25, 0.20, 0.15 });
            }
            catch (Exception ex)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi tải form: " + ex.Message, "Lỗi");
            }
        }

        /// <summary>
        /// Cấu hình ListView
        /// </summary>
        private void SetupListView()
        {
            lvServices.View = View.Details;
            lvServices.FullRowSelect = true;
            lvServices.MultiSelect = false;
            // Cấu hình các cột
            if (lvServices.Columns.Count == 0)
            {
                lvServices.Columns.Add("Tên Dịch Vụ", 200);
                lvServices.Columns.Add("Danh Mục", 120);
                lvServices.Columns.Add("Giá (₫)", 100);
                lvServices.Columns.Add("Có Sẵn", 80);
            }

            // Áp dụng style bảng đồng bộ Dashboard với badge cột "Có Sẵn" và "Danh Mục"
            UIHelper.DashboardUIHelper.StyleListView(lvServices, lvServices_DrawSubItem);

            // Tự căn lại độ rộng cột khi form thay đổi kích thước
            lvServices.Resize += (s, e) =>
                UIHelper.UICommon.AutoResizeListViewColumns(lvServices, new double[] { 0.40, 0.25, 0.20, 0.15 });
        }

        /// <summary>
        /// Cấu hình Combobox Danh Mục
        /// </summary>
        private void LoadCategoriesToFilter()
        {
            cboCategoryFilter.Items.Clear();
            cboCategoryFilter.Items.Add("Tất cả");
            cboCategoryFilter.Items.Add("Đồ uống");
            cboCategoryFilter.Items.Add("Đồ ăn");
            cboCategoryFilter.Items.Add("Game");
            cboCategoryFilter.Items.Add("Khác");
            cboCategoryFilter.SelectedIndex = 0;

            cboCategory.Items.Clear();
            cboCategory.Items.Add("Đồ uống");
            cboCategory.Items.Add("Đồ ăn");
            cboCategory.Items.Add("Game");
            cboCategory.Items.Add("Khác");
            cboCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Tải danh sách dịch vụ từ CSDL
        /// </summary>
        private void LoadServices()
        {
            try
            {
                allServices = serviceItemService.GetAllServices().ToList();
                DisplayServices(allServices);
            }
            catch (Exception ex)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        /// <summary>
        /// Hiển thị danh sách dịch vụ lên ListView
        /// </summary>
        private void DisplayServices(List<ServiceItem> services)
        {
            lvServices.Items.Clear();

            foreach (var service in services)
            {
                var item = new ListViewItem(service.Name);
                item.SubItems.Add(service.Category);
                item.SubItems.Add(service.Price.ToString("N0"));
                item.SubItems.Add(service.IsAvailable ? "✅ Có" : "❌ Hết");
                item.Tag = service.Id;
                lvServices.Items.Add(item);
            }
        }

        /// <summary>
        /// Cập nhật Status Bar
        /// </summary>
        private void UpdateStatusBar()
        {
            try
            {
                int total = allServices.Count;
                int drinks = allServices.Count(s => s.Category == "Đồ uống");
                int food = allServices.Count(s => s.Category == "Đồ ăn");
                int games = allServices.Count(s => s.Category == "Game");
                int outOfStock = allServices.Count(s => !s.IsAvailable);

                lblStatusTotal.Text = $"Tổng: {total}";
                lblStatusDrink.Text = $"Nước: {drinks}";
                lblStatusFood.Text = $"Ăn: {food}";
                lblStatusGame.Text = $"Game: {games}";
                lblStatusOut.Text = $"Hết hàng: {outOfStock}";

                pnlStatus.BackColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
                lblStatusTotal.ForeColor = System.Drawing.Color.White;
                lblStatusDrink.ForeColor = System.Drawing.Color.White;
                lblStatusFood.ForeColor = System.Drawing.Color.White;
                lblStatusGame.ForeColor = System.Drawing.Color.White;
                lblStatusOut.ForeColor = System.Drawing.Color.White;
            }
            catch { }
        }

        /// <summary>
        /// Nút Thêm
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditing = false;
            currentServiceId = 0;
            lblFormTitle.Text = "Thêm Dịch Vụ Mới";
            btnSave.Text = "Thêm";
        }

        /// <summary>
        /// Nút Sửa
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvServices.SelectedItems.Count == 0)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Thông báo");
                return;
            }

            int serviceId = (int)lvServices.SelectedItems[0].Tag;
            var service = serviceItemService.GetServiceById(serviceId);

            if (service != null)
            {
                isEditing = true;
                currentServiceId = serviceId;
                lblFormTitle.Text = "Sửa Dịch Vụ";
                btnSave.Text = "Cập Nhật";

                txtName.Text = service.Name;
                cboCategory.SelectedItem = service.Category;
                txtPrice.Text = service.Price.ToString();
                chkAvailable.Checked = service.IsAvailable;

                txtName.Focus();
            }
        }

        /// <summary>
        /// Nút Xóa
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvServices.SelectedItems.Count == 0)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Thông báo");
                return;
            }

            if (QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int serviceId = (int)lvServices.SelectedItems[0].Tag;
                    serviceItemService.DeleteService(serviceId);

                    QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Xóa thành công!", "Thành công");
                    LoadServices();
                    ClearForm();
                    UpdateStatusBar();
                }
                catch (Exception ex)
                {
                    QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                }
            }
        }

        /// <summary>
        /// Nút Lưu (Thêm hoặc Cập nhật)
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Vui lòng nhập tên dịch vụ!", "Lỗi");
                    txtName.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Vui lòng nhập giá hợp lệ (> 0)!", "Lỗi");
                    txtPrice.Focus();
                    return;
                }

                if (cboCategory.SelectedItem == null)
                {
                    QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Vui lòng chọn danh mục!", "Lỗi");
                    return;
                }

                if (!isEditing)
                {
                    // Thêm mới
                    var newService = new ServiceItem
                    {
                        Name = txtName.Text.Trim(),
                        Category = cboCategory.SelectedItem.ToString(),
                        Price = price,
                        IsAvailable = chkAvailable.Checked
                    };

                    serviceItemService.AddService(newService);
                    QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Thêm dịch vụ thành công!", "Thành công");
                }
                else
                {
                    // Cập nhật
                    var service = serviceItemService.GetServiceById(currentServiceId);
                    if (service != null)
                    {
                        service.Name = txtName.Text.Trim();
                        service.Category = cboCategory.SelectedItem.ToString();
                        service.Price = price;
                        service.IsAvailable = chkAvailable.Checked;

                        serviceItemService.UpdateService(service);
                        QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Cập nhật dịch vụ thành công!", "Thành công");
                    }
                }

                LoadServices();
                ClearForm();
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        /// <summary>
        /// Nút Hủy
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            lvServices.SelectedItems.Clear();
        }

        /// <summary>
        /// Xóa dữ liệu trong form
        /// </summary>
        private void ClearForm()
        {
            txtName.Clear();
            txtPrice.Clear();
            cboCategory.SelectedIndex = 0;
            chkAvailable.Checked = true;
            isEditing = false;
            currentServiceId = 0;
            lblFormTitle.Text = "Thêm Dịch Vụ Mới";
            btnSave.Text = "Thêm";
        }

        /// <summary>
        /// Sự kiện chọn item trong ListView
        /// </summary>
        private void lvServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvServices.SelectedItems.Count > 0)
            {
                // Không tự động load lên form, chỉ khi nhấn "Sửa"
            }
        }

        /// <summary>
        /// Lọc theo danh mục
        /// </summary>
        private void cboCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedCategory = cboCategoryFilter.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedCategory) || selectedCategory == "Tất cả")
                {
                    DisplayServices(allServices);
                }
                else
                {
                    var filtered = allServices.Where(s => s.Category == selectedCategory).ToList();
                    DisplayServices(filtered);
                }
            }
            catch (Exception ex)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        /// <summary>
        /// Tìm kiếm theo tên
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    cboCategoryFilter_SelectedIndexChanged(null, null);
                }
                else
                {
                    var filtered = allServices
                        .Where(s => s.Name.ToLower().Contains(searchText))
                        .ToList();

                    DisplayServices(filtered);
                }
            }
            catch { }
        }

        /// <summary>
        /// Chỉ cho phép nhập số vào ô giá bán
        /// </summary>
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lvServices_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var lv = (System.Windows.Forms.ListView)sender;
            Color rowBg = UIHelper.DashboardUIHelper.GetRowBackColor(lv, e.ItemIndex, e.Item.Selected);
            using (var br = new SolidBrush(rowBg)) e.Graphics.FillRectangle(br, e.Bounds);

            string val = e.SubItem.Text;
            Rectangle textRect = e.Bounds;
            textRect.Inflate(-10, 0);
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis;

            if (e.ColumnIndex == 3) // Có Sẵn — badge xanh/đỏ
            {
                Color bg = val.Contains("Có") ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
                Color fg = val.Contains("Có") ? Color.FromArgb(22, 163, 74)   : Color.FromArgb(220, 38, 38);
                UIHelper.DashboardUIHelper.DrawBadgePill(e.Graphics, val, e.Bounds, bg, fg);
            }
            else if (e.ColumnIndex == 1) // Danh Mục — badge tím nhạt
            {
                UIHelper.DashboardUIHelper.DrawBadgePill(e.Graphics, val, e.Bounds,
                    UIHelper.DashboardUIHelper.ThemeColorLight,
                    UIHelper.DashboardUIHelper.ThemeColor);
            }
            else if (e.ColumnIndex == 0) // Tên — bold
            {
                TextRenderer.DrawText(e.Graphics, val, new Font("Inter", 9.5F, FontStyle.Bold), textRect, Color.FromArgb(17, 24, 39), flags);
            }
            else // Giá
            {
                TextRenderer.DrawText(e.Graphics, val, new Font("Inter", 9.5F), textRect, Color.FromArgb(55, 65, 81), flags);
            }
            using (var pen = new Pen(Color.FromArgb(243, 244, 246), 1))
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }
    }
}
