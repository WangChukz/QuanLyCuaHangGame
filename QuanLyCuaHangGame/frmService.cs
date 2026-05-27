using System;
using System.Collections.Generic;
using System.Linq;
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
            lvServices.DrawSubItem += lvServices_DrawSubItem;

            UIHelper.UICommon.ApplyTheme(this, true);

            serviceItemService = new ServiceItemService();
            allServices = new List<ServiceItem>();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            try
            {
                SetupListView();
                LoadCategoriesToFilter();
                LoadServices();
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải form: " + ex.Message, "Lỗi");
            }
        }

        /// <summary>
        /// Cấu hình ListView
        /// </summary>
        private void SetupListView()
        {
            lvServices.View = View.Details;
            lvServices.FullRowSelect = true;
            lvServices.GridLines = true;
            lvServices.MultiSelect = false;

            // Cấu hình các cột
            if (lvServices.Columns.Count == 0)
            {
                lvServices.Columns.Add("Tên Dịch Vụ", 200);
                lvServices.Columns.Add("Danh Mục", 120);
                lvServices.Columns.Add("Giá (₫)", 100);
                lvServices.Columns.Add("Có Sẵn", 80);
            }
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
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi");
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
                item.SubItems.Add(service.IsAvailable ? "Có" : "Hết");
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
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Thông báo");
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
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int serviceId = (int)lvServices.SelectedItems[0].Tag;
                    serviceItemService.DeleteService(serviceId);

                    MessageBox.Show("Xóa thành công!", "Thành công");
                    LoadServices();
                    ClearForm();
                    UpdateStatusBar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
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
                    MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Lỗi");
                    txtName.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show("Vui lòng nhập giá hợp lệ (> 0)!", "Lỗi");
                    txtPrice.Focus();
                    return;
                }

                if (cboCategory.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục!", "Lỗi");
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
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thành công");
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
                        MessageBox.Show("Cập nhật dịch vụ thành công!", "Thành công");
                    }
                }

                LoadServices();
                ClearForm();
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
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
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
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
        /// Vẽ màu cho cột "Có sẵn" (Xanh = Có, Đỏ = Hết)
        /// </summary>
        private void lvServices_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Vẽ background
            e.DrawBackground();

            // Cột 3 (Index=3): "Có sẵn"
            if (e.ColumnIndex == 3)
            {
                // Xác định màu dựa vào nội dung
                System.Drawing.Color textColor = e.SubItem.Text == "Có" 
                    ? System.Drawing.Color.Green 
                    : System.Drawing.Color.Red;

                // Vẽ chữ với màu tương ứng
                var brush = new System.Drawing.SolidBrush(textColor);
                var stringFormat = new System.Drawing.StringFormat
                {
                    Alignment = System.Drawing.StringAlignment.Center,
                    LineAlignment = System.Drawing.StringAlignment.Center
                };
                
                e.Graphics.DrawString(
                    e.SubItem.Text,
                    lvServices.Font,
                    brush,
                    e.Bounds,
                    stringFormat);

                brush.Dispose();
            }
            else
            {
                // Các cột khác vẽ bình thường
                e.DrawText();
            }
        }
    }
}