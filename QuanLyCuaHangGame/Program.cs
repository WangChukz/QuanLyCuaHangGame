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
            try
            {
                var seeder = new QuanLyCuaHangGame.BLL.Services.DatabaseSeeder();
                seeder.SeedData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new frmComputerMap());
            // Application.Run(new frmCustomer()); // Khoa đang test dở form này
        }
    }
}
