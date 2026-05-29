using System.Data.Entity;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.DAL
{
    public class GameZoneDbContext : DbContext
    {
        public GameZoneDbContext() : base(GetSmartConnectionString())
        {
        }

        private static string _cachedConnectionString = null;

        /// <summary>
        /// Tự động dò tìm SQL Server phù hợp.
        /// Thử kết nối với .\SQLEXPRESS trước, nếu lỗi sẽ tự động chuyển sang Server=. (localhost mặc định).
        /// Tính năng này giúp team clone về là chạy được luôn.
        /// </summary>
        private static string GetSmartConnectionString()
        {
            if (_cachedConnectionString != null)
            {
                return _cachedConnectionString;
            }

            string dbName = "GameZoneProDB";
            string expressConn = $"Server=.\\SQLEXPRESS;Database={dbName};Integrated Security=True;TrustServerCertificate=True";
            string express01Conn = $"Server=.\\SQLEXPRESS01;Database={dbName};Integrated Security=True;TrustServerCertificate=True";

            // Helper to test if a server is reachable (using master db)
            bool IsServerReachable(string serverName)
            {
                try
                {
                    string testConn = $"Server={serverName};Database=master;Integrated Security=True;TrustServerCertificate=True;Connection Timeout=2";
                    using (var conn = new System.Data.SqlClient.SqlConnection(testConn))
                    {
                        conn.Open();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            if (IsServerReachable(".\\SQLEXPRESS"))
            {
                _cachedConnectionString = expressConn;
                return expressConn;
            }

            if (IsServerReachable(".\\SQLEXPRESS01"))
            {
                _cachedConnectionString = express01Conn;
                return express01Conn;
            }

            // Fallback
            string defaultConn = $"Server=.;Database={dbName};Integrated Security=True;TrustServerCertificate=True";
            _cachedConnectionString = defaultConn;
            return defaultConn;
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
