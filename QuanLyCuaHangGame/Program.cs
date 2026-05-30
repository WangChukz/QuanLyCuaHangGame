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
                string msg = ex.Message;
                if (ex.InnerException != null) msg += "\nInner: " + ex.InnerException.Message;
                if (ex.InnerException?.InnerException != null) msg += "\nInner2: " + ex.InnerException.InnerException.Message;
                System.IO.File.WriteAllText("error.txt", msg);
                QuanLyCuaHangGame.UIHelper.GameZoneMessageBox.Show("Không thể khởi tạo CSDL: " + msg, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new frmLogin());
            // Application.Run(new frmComputerMap()); // Lưu lại tham chiếu phòng khi cần test riêng lẻ
        }
    }
}
