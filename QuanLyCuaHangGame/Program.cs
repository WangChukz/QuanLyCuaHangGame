using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangGame.GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Seed initial database and admin user
            try
            {
                var userService = new QuanLyCuaHangGame.BLL.Services.UserService();
                if (!userService.GetAllUsers().Any())
                {
                    var adminUser = new QuanLyCuaHangGame.Model.User
                    {
                        Username = "admin",
                        FullName = "Quản trị viên",
                        Role = "Admin",
                        IsActive = true
                    };
                    userService.AddUser(adminUser, "123456");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new dlgTopUp());
        }
    }
}
