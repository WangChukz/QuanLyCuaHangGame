using System.Data.Entity;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.DAL
{
    public class GameZoneDbContext : DbContext
    {
        public GameZoneDbContext() : base(GetSmartConnectionString())
        {
        }

        /// <summary>
        /// Tự động dò tìm SQL Server phù hợp.
        /// Thử kết nối với .\SQLEXPRESS trước, nếu lỗi sẽ tự động chuyển sang Server=. (localhost mặc định).
        /// Tính năng này giúp team clone về là chạy được luôn.
        /// </summary>
        private static string GetSmartConnectionString()
        {
            string dbName = "GameZoneProDB";
            string expressConn = $"Server=.\\SQLEXPRESS01;Database={dbName};Integrated Security=True;TrustServerCertificate=True";
            string defaultConn = $"Server=.;Database={dbName};Integrated Security=True;TrustServerCertificate=True";

            try
            {
                // Thử kết nối tới SQLEXPRESS trước với timeout 2 giây để tránh treo máy lâu
                using (var conn = new System.Data.SqlClient.SqlConnection(expressConn + ";Connection Timeout=2"))
                {
                    conn.Open();
                    return expressConn; // Thành công thì trả về chuỗi của SQLEXPRESS
                }
            }
            catch
            {
                // Nếu lỗi thì dùng server mặc định
                return defaultConn;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerPrice> ComputerPrices { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionService> SessionServices { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<TopUpTransaction> TopUpTransactions { get; set; }
        public DbSet<SpendTransaction> SpendTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Session>()
                .HasRequired(s => s.Computer)
                .WithMany()
                .HasForeignKey(s => s.ComputerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .HasRequired(s => s.OpenedByUser)
                .WithMany()
                .HasForeignKey(s => s.OpenedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasRequired(i => i.ClosedByUser)
                .WithMany()
                .HasForeignKey(i => i.ClosedByUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpendTransaction>()
                .HasRequired(st => st.Customer)
                .WithMany()
                .HasForeignKey(st => st.CustomerId)
                .WillCascadeOnDelete(false);
                
            modelBuilder.Entity<SessionService>()
                .HasRequired(ss => ss.Session)
                .WithMany()
                .HasForeignKey(ss => ss.SessionId)
                .WillCascadeOnDelete(false);
                
            modelBuilder.Entity<TopUpTransaction>()
                .HasRequired(t => t.ProcessedByUser)
                .WithMany()
                .HasForeignKey(t => t.ProcessedByUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
