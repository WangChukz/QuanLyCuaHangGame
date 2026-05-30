using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.BLL.Services;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.GUI
{
    public partial class dlgAddService : MaterialForm
    {
        private ServiceItemService _serviceItemService;
        private QuanLyCuaHangGame.BLL.Services.SessionService _sessionService;
        private List<ServiceItem> _allServices;
        private Dictionary<int, int> _selectedQuantities; // Key: ServiceId, Value: Quantity
        private int _sessionId;

        public dlgAddService(int sessionId)
        {
            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            // Thừa kế màu sắc MaterialSkin hiện tại (Màu Tím như yêu cầu)

            _serviceItemService = new ServiceItemService();
            _sessionService = new QuanLyCuaHangGame.BLL.Services.SessionService();
            _selectedQuantities = new Dictionary<int, int>();
            _sessionId = sessionId;

            this.Load += DlgAddService_Load;
            btnCancel.Click += BtnCancel_Click;
            btnConfirm.Click += BtnConfirm_Click;
            lvServices.DrawSubItem += LvServices_DrawSubItem;
            lvServices.DrawColumnHeader += LvServices_DrawColumnHeader;
            lvServices.MouseClick += LvServices_MouseClick;
        }

        private void DlgAddService_Load(object sender, EventArgs e)
        {
            // Set style for panel according to design
            pnlSummary.BackColor = Color.White;
            
            LoadServices();
            UpdateTotal();
        }

        private void LoadServices()
        {
            try
            {
                _allServices = _serviceItemService.GetAllServices().Where(s => s.IsAvailable).ToList();
                lvServices.Items.Clear();

                foreach (var service in _allServices)
                {
                    _selectedQuantities[service.Id] = 0; // Khởi tạo số lượng = 0
                    
                    var item = new ListViewItem(service.Name);
                    item.SubItems.Add(service.Category);
                    item.SubItems.Add(service.Price.ToString("N0") + "đ");
                    item.SubItems.Add("0"); // Cột Số lượng (sẽ vẽ nút + - đè lên)
                    item.SubItems.Add("–"); // Thành tiền
                    item.Tag = service;
                    
                    lvServices.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message);
            }
        }

        // Custom draw cho ListView để hiển thị nút + và -
        private void LvServices_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true; // Header vẽ bình thường
        }

        private void LvServices_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var service = (ServiceItem)e.Item.Tag;
            int qty = _selectedQuantities[service.Id];
            
            if (e.ColumnIndex == 3) // Cột Số lượng
            {
                e.DrawBackground();
                
                // Vẽ nút -
                Rectangle rectMinus = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 4, 24, 24);
                // Vẽ số lượng
                Rectangle rectText = new Rectangle(rectMinus.Right, e.Bounds.Top, 30, e.Bounds.Height);
                // Vẽ nút +
                Rectangle rectPlus = new Rectangle(rectText.Right, e.Bounds.Top + 4, 24, 24);

                Color themeColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
                
                // Nút -
                if (qty > 0)
                {
                    using (var b = new SolidBrush(Color.White))
                    using (var p = new Pen(themeColor, 1))
                    {
                        e.Graphics.FillRectangle(b, rectMinus);
                        e.Graphics.DrawRectangle(p, rectMinus);
                        TextRenderer.DrawText(e.Graphics, "-", new Font("Arial", 12, FontStyle.Bold), rectMinus, themeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
                else
                {
                    using (var b = new SolidBrush(Color.FromArgb(240, 240, 240)))
                    using (var p = new Pen(Color.LightGray, 1))
                    {
                        e.Graphics.FillRectangle(b, rectMinus);
                        e.Graphics.DrawRectangle(p, rectMinus);
                        TextRenderer.DrawText(e.Graphics, "-", new Font("Arial", 12, FontStyle.Bold), rectMinus, Color.Gray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
                
                // Số lượng
                TextRenderer.DrawText(e.Graphics, qty.ToString(), e.Item.Font, rectText, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                
                // Nút +
                using (var b = new SolidBrush(themeColor))
                {
                    e.Graphics.FillRectangle(b, rectPlus);
                    TextRenderer.DrawText(e.Graphics, "+", new Font("Arial", 12, FontStyle.Bold), rectPlus, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
            }
            else if (e.ColumnIndex == 4) // Thành tiền
            {
                e.DrawBackground();
                if (qty > 0)
                {
                    decimal total = qty * service.Price;
                    TextRenderer.DrawText(e.Graphics, total.ToString("N0") + "đ", e.Item.Font, e.Bounds, MaterialSkinManager.Instance.ColorScheme.PrimaryColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    TextRenderer.DrawText(e.Graphics, "–", e.Item.Font, e.Bounds, Color.LightGray, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void LvServices_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitInfo = lvServices.HitTest(e.Location);
            if (hitInfo.Item != null && hitInfo.SubItem != null)
            {
                int colIndex = hitInfo.Item.SubItems.IndexOf(hitInfo.SubItem);
                if (colIndex == 3) // Cột Số lượng
                {
                    var service = (ServiceItem)hitInfo.Item.Tag;
                    int qty = _selectedQuantities[service.Id];
                    
                    Rectangle bounds = hitInfo.SubItem.Bounds;
                    Rectangle rectMinus = new Rectangle(bounds.Left + 5, bounds.Top + 4, 24, 24);
                    Rectangle rectText = new Rectangle(rectMinus.Right, bounds.Top, 30, bounds.Height);
                    Rectangle rectPlus = new Rectangle(rectText.Right, bounds.Top + 4, 24, 24);
                    
                    if (rectMinus.Contains(e.Location) && qty > 0)
                    {
                        _selectedQuantities[service.Id]--;
                        lvServices.Invalidate(bounds);
                        lvServices.Invalidate(hitInfo.Item.SubItems[4].Bounds);
                        UpdateTotal();
                    }
                    else if (rectPlus.Contains(e.Location))
                    {
                        _selectedQuantities[service.Id]++;
                        lvServices.Invalidate(bounds);
                        lvServices.Invalidate(hitInfo.Item.SubItems[4].Bounds);
                        UpdateTotal();
                    }
                }
            }
        }

        private void UpdateTotal()
        {
            int typesCount = 0;
            int itemsCount = 0;
            decimal totalPrice = 0;

            foreach (var kvp in _selectedQuantities)
            {
                if (kvp.Value > 0)
                {
                    typesCount++;
                    itemsCount += kvp.Value;
                    var service = _allServices.First(s => s.Id == kvp.Key);
                    totalPrice += kvp.Value * service.Price;
                }
            }

            lblTotalTypes.Text = $"{typesCount} loại ({itemsCount} món)";
            lblTotalPrice.Text = totalPrice.ToString("N0") + "đ";
            lblTotalPrice.ForeColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            int itemsCount = _selectedQuantities.Sum(q => q.Value);
            if (itemsCount == 0)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Vui lòng chọn ít nhất một dịch vụ!", "Thông báo");
                return;
            }

            try
            {
                foreach (var kvp in _selectedQuantities)
                {
                    if (kvp.Value > 0)
                    {
                        var service = _allServices.First(s => s.Id == kvp.Key);
                        _sessionService.AddServiceToSession(_sessionId, service.Id, kvp.Value, service.Price);
                    }
                }
                
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Đã gọi dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
