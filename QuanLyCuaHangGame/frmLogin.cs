using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using QuanLyCuaHangGame.BLL.Services;
using QuanLyCuaHangGame.BLL;

namespace QuanLyCuaHangGame.GUI
{
    public partial class frmLogin : MaterialForm
    {
        private int failedAttempts = 0;
        private int lockLevel = 0;
        private DateTime lockoutEnd = DateTime.MinValue;
        private Timer lockTimer;

        private UserService userService;

        public frmLogin()
        {
            InitializeComponent();
            
            // Initialize MaterialSkin colors without AddFormToManage to preserve custom Designer colors
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Color.FromArgb(25, 118, 210), // Primary
                Color.FromArgb(13, 71, 161),  // DarkPrimary
                Color.FromArgb(33, 150, 243), // LightPrimary
                Color.FromArgb(25, 118, 210), // Accent
                TextShade.WHITE
            );

            userService = new UserService();
            LoadLoginInfo();
            LoadLockoutInfo();
        }

        private string GetConfigPath() => System.IO.Path.Combine(Application.StartupPath, "login_cfg.dat");
        private string GetLockoutPath() => System.IO.Path.Combine(Application.StartupPath, "lockout.dat");

        private void SaveLockoutInfo()
        {
            try
            {
                if (lockoutEnd <= DateTime.Now)
                {
                    if (System.IO.File.Exists(GetLockoutPath()))
                        System.IO.File.Delete(GetLockoutPath());
                }
                else
                {
                    System.IO.File.WriteAllText(GetLockoutPath(), $"{lockoutEnd.Ticks}\n{lockLevel}");
                }
            }
            catch { }
        }

        private void LoadLockoutInfo()
        {
            try
            {
                string path = GetLockoutPath();
                if (System.IO.File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    if (lines.Length >= 2)
                    {
                        if (long.TryParse(lines[0], out long ticks))
                        {
                            DateTime end = new DateTime(ticks);
                            if (end > DateTime.Now)
                            {
                                lockoutEnd = end;
                                lockLevel = int.Parse(lines[1]);
                                ApplyLockout(lockoutEnd);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void ApplyLockout(DateTime end)
        {
            lockoutEnd = end;
            SaveLockoutInfo();

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            btnLogin.Cursor = Cursors.No;

            if (lockTimer == null)
            {
                lockTimer = new Timer();
                lockTimer.Interval = 1000;
                lockTimer.Tick += LockTimer_Tick;
            }
            lockTimer.Start();
            UpdateLockoutUI();
        }

        private void LockTimer_Tick(object sender, EventArgs e)
        {
            UpdateLockoutUI();
        }

        private void UpdateLockoutUI()
        {
            if (DateTime.Now >= lockoutEnd)
            {
                lockTimer?.Stop();
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                btnLogin.Cursor = Cursors.Hand;
                btnLogin.Text = "ĐĂNG NHẬP";
                failedAttempts = 0;
                SaveLockoutInfo();
            }
            else
            {
                TimeSpan remaining = lockoutEnd - DateTime.Now;
                string timeStr = remaining.TotalMinutes >= 1 
                    ? $"{(int)remaining.TotalMinutes:D2}:{remaining.Seconds:D2}" 
                    : $"{remaining.Seconds:D2}";
                btnLogin.Text = timeStr;
            }
        }

        private void LoadLoginInfo()
        {
            try
            {
                string path = GetConfigPath();
                if (System.IO.File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    if (lines.Length >= 2)
                    {
                        txtUsername.Text = lines[0];
                        txtPassword.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(lines[1]));
                        chkRemember.Checked = true;
                    }
                }
                else
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    chkRemember.Checked = false;
                }
            }
            catch { }
        }

        private void SaveLoginInfo(string username, string password)
        {
            try
            {
                string path = GetConfigPath();
                if (chkRemember.Checked)
                {
                    string b64pwd = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
                    System.IO.File.WriteAllLines(path, new string[] { username, b64pwd });
                    System.IO.File.SetAttributes(path, System.IO.FileAttributes.Hidden);
                }
                else
                {
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                }
            }
            catch { }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (DateTime.Now < lockoutEnd)
            {
                return; // Ignored because button is disabled anyway
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (userService.Authenticate(username, password))
                {
                    failedAttempts = 0; // Reset attempts on successful login
                    lockLevel = 0;
                    SaveLoginInfo(username, password);
                    frmDashboard dashboard = new frmDashboard();
                    dashboard.FormClosed += (s, args) => this.Close();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    failedAttempts++;
                    int allowedAttempts = (lockLevel == 0) ? 5 : 1;

                    if (failedAttempts >= allowedAttempts)
                    {
                        lockLevel++;
                        int lockMinutes = 5 * lockLevel; // 1st: 5m, 2nd: 10m, 3rd: 15m...
                        ApplyLockout(DateTime.Now.AddMinutes(lockMinutes));
                    }
                    else
                    {
                        QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show($"Tên đăng nhập hoặc mật khẩu không chính xác!\n(Nhập sai {failedAttempts}/{allowedAttempts} lần)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Lỗi kết nối cơ sở dữ liệu:\n" + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            using (var confirm = new frmConfirmExit())
            {
                if (confirm.ShowDialog() == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
