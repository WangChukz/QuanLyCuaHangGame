using System.Data.Entity;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.DAL
{
    public class GameZoneDbContext : DbContext
    {
        public GameZoneDbContext() : base("name=GameStoreContext")
        {
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
