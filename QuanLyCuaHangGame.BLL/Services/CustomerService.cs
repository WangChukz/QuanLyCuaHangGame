using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangGame.DAL.Repositories;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class CustomerService
    {
        private UnitOfWork unitOfWork;

        public CustomerService()
        {
            unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return unitOfWork.CustomerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return unitOfWork.CustomerRepository.GetById(id);
        }

        public Customer Register(Customer customer, string plainPassword)
        {
            customer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            customer.Balance = 0;
            customer.CreatedAt = DateTime.Now;
            
            unitOfWork.CustomerRepository.Insert(customer);
            unitOfWork.Save();
            
            return customer;
        }

        public void TopUp(int customerId, decimal amount, string note, int processedByUserId)
        {
            var customer = unitOfWork.CustomerRepository.GetById(customerId);
            if (customer != null && amount > 0)
            {
                customer.Balance += amount;

                var transaction = new TopUpTransaction
                {
                    CustomerId = customerId,
                    ProcessedByUserId = processedByUserId,
                    Amount = amount,
                    Note = note,
                    CreatedAt = DateTime.Now
                };

                unitOfWork.TopUpTransactionRepository.Insert(transaction);
                unitOfWork.Save();
            }
        }

        public void UpdateStatus(int customerId, bool isActive)
        {
            var customer = unitOfWork.CustomerRepository.GetById(customerId);
            if (customer != null)
            {
                customer.IsActive = isActive;
                unitOfWork.Save();
            }
        }
        
        public IEnumerable<object> GetTransactionHistory(int customerId)
        {
            var topUps = unitOfWork.TopUpTransactionRepository.GetAll()
                .Where(t => t.CustomerId == customerId)
                .Select(t => new { Type = "Nạp tiền", t.Amount, Date = t.CreatedAt, Note = t.Note });
                
            var spends = unitOfWork.SpendTransactionRepository.GetAll()
                .Where(t => t.CustomerId == customerId)
                .Select(t => new { Type = "Chi tiêu", Amount = -t.Amount, Date = t.CreatedAt, Note = t.Description });
                
            return topUps.Union(spends).OrderByDescending(t => t.Date).ToList();
        }
    }
}
