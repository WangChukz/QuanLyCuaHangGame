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
            UIHelper.UICommon.ApplyTheme(this, true);

            _customerBLL = new CustomerBLL();

            // Wire up events
            this.Load += FrmCustomer_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            mlvHoiVien.SelectedIndexChanged += MlvHoiVien_SelectedIndexChanged;
            btnNapTien.Click += BtnNapTien_Click;
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (this.Parent == null)
            {
                this.FormStyle = FormStyles.ActionBar_56;
            }

            LoadCustomerList("");
            ClearCustomerDetails();

            // Auto resize columns on load
            UICommon.AutoResizeListViewColumns(mlvHoiVien, new double[] { 0.25, 0.2, 0.2, 0.2, 0.15 });
            UICommon.AutoResizeListViewColumns(mlvHistory, new double[] { 0.25, 0.35, 0.2, 0.2 });
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UICommon.AutoResizeListViewColumns(mlvHoiVien, new double[] { 0.25, 0.2, 0.2, 0.2, 0.15 });
            UICommon.AutoResizeListViewColumns(mlvHistory, new double[] { 0.25, 0.35, 0.2, 0.2 });
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
                
                // Color formatting
                item.UseItemStyleForSubItems = false;
                item.SubItems[3].ForeColor = Color.Green;
                
                var statusSubItem = item.SubItems[4];
                statusSubItem.ForeColor = Color.White;
                statusSubItem.BackColor = c.IsActive ? Color.Green : Color.Orange;

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
                MessageBox.Show("Vui lòng chọn khách hàng để nạp tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(txtMoney.Text, out decimal amount) && amount > 0)
            {
                try
                {
                    int currentUserId = SessionContext.CurrentUserId;
                    _customerBLL.TopUp(_selectedCustomerId, amount, txtNote.Text, currentUserId);
                    
                    MessageBox.Show("Nạp tiền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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
                    MessageBox.Show($"Lỗi khi nạp tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ (> 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            {
                merged.Add(new Tuple<string, string, decimal, DateTime>("+ Nạp tiền", t.Note, t.Amount, t.CreatedAt));
            }
            
            foreach (var t in spends)
            {
                merged.Add(new Tuple<string, string, decimal, DateTime>("- Thanh toán", t.Description, -t.Amount, t.CreatedAt));
            }

            var sortedHistory = merged.OrderByDescending(m => m.Item4).ToList();

            foreach (var t in sortedHistory)
            {
                var item = new ListViewItem(t.Item1);
                item.SubItems.Add(t.Item2);
                
                string amountStr = (t.Item3 > 0 ? "+" : "") + t.Item3.ToString("N0") + "đ";
                item.SubItems.Add(amountStr);
                
                item.SubItems.Add(t.Item4.ToString("dd/MM/yyyy HH:mm"));

                item.UseItemStyleForSubItems = false;
                Color amountColor = t.Item3 > 0 ? Color.Green : Color.Red;
                item.ForeColor = amountColor;
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    subItem.ForeColor = amountColor;
                }

                mlvHistory.Items.Add(item);
            }
        }
    }
}
