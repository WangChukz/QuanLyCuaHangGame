using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.BLL;
using QuanLyCuaHangGame.BLL.Services;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame
{
    public partial class dlgOpenSession : MaterialForm
    {
        private int _computerId;
        private ComputerService _computerService;
        private CustomerService _customerService;
        private QuanLyCuaHangGame.BLL.Services.SessionService _sessionService;
        private Customer _selectedCustomer;
        private Computer _computer;

        public dlgOpenSession(int computerId)
        {
            InitializeComponent();

            this._computerId = computerId;
            _computerService = new ComputerService();
            _customerService = new CustomerService();
            _sessionService = new QuanLyCuaHangGame.BLL.Services.SessionService();

            // Áp dụng theme chuẩn của nhóm
            UIHelper.UICommon.ApplyTheme(this);
            UIHelper.DashboardUIHelper.ApplyGlobalModernStyle(this);

            WireUpEvents();
        }

        private void dlgOpenSession_Load(object sender, EventArgs e)
        {
            // Tải thông tin máy tính
            LoadComputerDetails();
            // Reset panel thông tin hội viên
            ResetMemberDetails();
            // Ẩn danh sách tìm kiếm khi mới mở form
            lstCustomers.Visible = false;
        }

        private void LoadComputerDetails()
        {
            try
            {
                _computer = _computerService.GetAllComputers().FirstOrDefault(c => c.Id == _computerId);
                if (_computer != null)
                {
                    lblCodeValue.Text = _computer.Code;
                    lblTierValue.Text = _computer.Tier;
                    
                    decimal price = _computerService.GetCurrentPrice(_computerId);
                    lblPriceValue.Text = $"{price:N0}đ/h";

                    lblCpuValue.Text = $"{_computer.Cpu} / {_computer.Gpu} / {_computer.Ram}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin máy tính: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetMemberDetails()
        {
            _selectedCustomer = null;
            lblMemberName.Text = "Họ tên: -";
            lblMemberPhone.Text = "SĐT: -";
            lblMemberBalanceValue.Text = "0đ";
            lblMemberBalanceValue.ForeColor = Color.Gray;
        }

        private void WireUpEvents()
        {
            // Lọc hội viên thời gian thực
            txtSearchMember.TextChanged += TxtSearchMember_TextChanged;

            // Sự kiện chọn hội viên trên ListBox
            lstCustomers.Click += LstCustomers_Click;
            lstCustomers.SelectedIndexChanged += LstCustomers_SelectedIndexChanged;

            // Xử lý nút bấm
            btnConfirm.Click += BtnConfirm_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void LstCustomers_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItem != null)
            {
                // Ẩn danh sách tìm kiếm khi người dùng nhấp chuột chọn 1 kết quả
                lstCustomers.Visible = false;
            }
        }

        private void TxtSearchMember_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchKey = txtSearchMember.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchKey))
                {
                    lstCustomers.DataSource = null;
                    lstCustomers.Visible = false;
                    ResetMemberDetails();
                    txtPin.Clear();
                    return;
                }

                // Tìm kiếm hội viên hoạt động trùng với keyword (null-safe)
                var listCustomers = _customerService.GetAllCustomers()
                    .Where(c => c.IsActive && 
                               ((c.FullName != null && c.FullName.ToLower().Contains(searchKey)) || 
                                (c.Phone != null && c.Phone.Contains(searchKey)) || 
                                (c.Username != null && c.Username.ToLower().Contains(searchKey))))
                    .ToList();

                if (listCustomers.Count > 0)
                {
                    lstCustomers.DataSource = listCustomers;
                    lstCustomers.DisplayMember = "FullName";
                    lstCustomers.Visible = true;
                }
                else
                {
                    lstCustomers.DataSource = null;
                    lstCustomers.Visible = false;
                    ResetMemberDetails();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm: " + ex.Message);
                lstCustomers.Visible = false;
            }
        }

        private void LstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCustomer = lstCustomers.SelectedItem as Customer;
            if (_selectedCustomer != null)
            {
                lblMemberName.Text = $"Họ tên: {_selectedCustomer.FullName}";
                lblMemberPhone.Text = $"SĐT: {_selectedCustomer.Phone}";
                lblMemberBalanceValue.Text = $"{_selectedCustomer.Balance:N0}đ";
                lblMemberBalanceValue.ForeColor = _selectedCustomer.Balance > 0 
                    ? Color.FromArgb(46, 125, 50) 
                    : Color.FromArgb(198, 40, 40);
            }
            else
            {
                ResetMemberDetails();
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                decimal pricePerHour = _computerService.GetCurrentPrice(_computerId);

                // TAB HỘI VIÊN
                if (tabOpenMode.SelectedIndex == 0)
                {
                    if (_selectedCustomer == null)
                    {
                        MessageBox.Show("Vui lòng chọn một hội viên trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrEmpty(txtPin.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã PIN xác nhận của hội viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xác thực mã PIN
                    if (txtPin.Text != _selectedCustomer.PinCode)
                    {
                        MessageBox.Show("Mã PIN xác nhận không đúng! Vui lòng kiểm tra lại.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra số dư tài khoản chơi game
                    if (_selectedCustomer.Balance <= 0)
                    {
                        MessageBox.Show(this, "Tài khoản hội viên không đủ số dư để mở máy! Vui lòng nạp tiền trước.", "Tài khoản hết tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra hội viên đang chơi máy khác
                    var activeSessions = _sessionService.GetActiveSessions();
                    if (activeSessions.Any(s => s.CustomerId == _selectedCustomer.Id))
                    {
                        MessageBox.Show(this, $"Hội viên {_selectedCustomer.FullName} đang sử dụng một máy khác trong hệ thống! Không thể mở nhiều máy cùng lúc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tiến hành mở máy
                    var session = _sessionService.OpenSession(_computerId, SessionContext.CurrentUserId, _selectedCustomer.Id, null, pricePerHour);
                    if (session != null)
                    {
                        MessageBox.Show(this, $"✓ Đã mở máy {_computer.Code} thành công cho hội viên {_selectedCustomer.FullName}!", "Mở máy thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Lỗi: Máy tính hiện tại không ở trạng thái Trống để mở!", "Mở máy thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // TAB KHÁCH VÃNG LAI
                else
                {
                    string guestName = txtGuestName.Text.Trim();
                    if (string.IsNullOrEmpty(guestName))
                    {
                        guestName = "Khách vãng lai";
                    }

                    var session = _sessionService.OpenSession(_computerId, SessionContext.CurrentUserId, null, guestName, pricePerHour);
                    if (session != null)
                    {
                        MessageBox.Show($"✓ Đã mở máy {_computer.Code} thành công cho Khách vãng lai!", "Mở máy thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Máy tính hiện tại không ở trạng thái Trống để mở!", "Mở máy thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                {
                    msg += "\nChi tiết: " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        msg += "\nChi tiết thêm: " + ex.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show("Lỗi hệ thống khi mở máy: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
