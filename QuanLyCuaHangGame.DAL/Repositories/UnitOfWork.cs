using System;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private GameZoneDbContext context = new GameZoneDbContext();

        private Repository<User> userRepository;
        private Repository<Customer> customerRepository;
        private Repository<Room> roomRepository;
        private Repository<Computer> computerRepository;
        private Repository<ComputerPrice> computerPriceRepository;
        private Repository<ServiceItem> serviceItemRepository;
        private Repository<Session> sessionRepository;
        private Repository<SessionService> sessionServiceRepository;
        private Repository<Invoice> invoiceRepository;
        private Repository<TopUpTransaction> topUpTransactionRepository;
        private Repository<SpendTransaction> spendTransactionRepository;

        public Repository<User> UserRepository => userRepository ?? (userRepository = new Repository<User>(context));
        public Repository<Customer> CustomerRepository => customerRepository ?? (customerRepository = new Repository<Customer>(context));
        public Repository<Room> RoomRepository => roomRepository ?? (roomRepository = new Repository<Room>(context));
        public Repository<Computer> ComputerRepository => computerRepository ?? (computerRepository = new Repository<Computer>(context));
        public Repository<ComputerPrice> ComputerPriceRepository => computerPriceRepository ?? (computerPriceRepository = new Repository<ComputerPrice>(context));
        public Repository<ServiceItem> ServiceItemRepository => serviceItemRepository ?? (serviceItemRepository = new Repository<ServiceItem>(context));
        public Repository<Session> SessionRepository => sessionRepository ?? (sessionRepository = new Repository<Session>(context));
        public Repository<SessionService> SessionServiceRepository => sessionServiceRepository ?? (sessionServiceRepository = new Repository<SessionService>(context));
        public Repository<Invoice> InvoiceRepository => invoiceRepository ?? (invoiceRepository = new Repository<Invoice>(context));
        public Repository<TopUpTransaction> TopUpTransactionRepository => topUpTransactionRepository ?? (topUpTransactionRepository = new Repository<TopUpTransaction>(context));
        public Repository<SpendTransaction> SpendTransactionRepository => spendTransactionRepository ?? (spendTransactionRepository = new Repository<SpendTransaction>(context));

        public GameZoneDbContext Context => context;

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
