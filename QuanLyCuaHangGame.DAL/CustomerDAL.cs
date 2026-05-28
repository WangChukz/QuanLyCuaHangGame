using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.DAL
{
    public class CustomerTransactionDTO
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class CustomerDAL
    {
        public List<Customer> GetAllCustomers()
        {
            using (var context = new GameZoneDbContext())
            {
                return context.Customers.ToList();
            }
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            using (var context = new GameZoneDbContext())
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return context.Customers.ToList();

                keyword = keyword.ToLower();
                return context.Customers.Where(c => 
                    c.FullName.ToLower().Contains(keyword) || 
                    c.Phone.Contains(keyword) || 
                    c.Username.ToLower().Contains(keyword)
                ).ToList();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            using (var context = new GameZoneDbContext())
            {
                return context.Customers.FirstOrDefault(c => c.Id == customerId);
            }
        }

        public void TopUp(int customerId, decimal amount, string note, int processedByUserId)
        {
            using (var context = new GameZoneDbContext())
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
                if (customer != null)
                {
                    customer.Balance += amount;

                    var transaction = new TopUpTransaction
                    {
                        CustomerId = customerId,
                        Amount = amount,
                        Note = note,
                        ProcessedByUserId = processedByUserId,
                        CreatedAt = DateTime.Now
                    };
                    context.TopUpTransactions.Add(transaction);

                    context.SaveChanges();
                }
            }
        }

        public Tuple<List<TopUpTransaction>, List<SpendTransaction>> GetTransactionHistory(int customerId)
        {
            using (var context = new GameZoneDbContext())
            {
                var topUps = context.TopUpTransactions
                    .Where(t => t.CustomerId == customerId)
                    .OrderByDescending(t => t.CreatedAt)
                    .ToList();

                var spends = context.SpendTransactions
                    .Where(t => t.CustomerId == customerId)
                    .OrderByDescending(t => t.CreatedAt)
                    .ToList();

                return new Tuple<List<TopUpTransaction>, List<SpendTransaction>>(topUps, spends);
            }
        }
    }
}
