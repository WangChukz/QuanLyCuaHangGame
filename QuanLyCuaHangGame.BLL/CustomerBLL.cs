using System;
using System.Collections.Generic;
using QuanLyCuaHangGame.DAL;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL
{
    public class CustomerBLL
    {
        private CustomerDAL _customerDAL;

        public CustomerBLL()
        {
            _customerDAL = new CustomerDAL();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDAL.GetAllCustomers();
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            return _customerDAL.SearchCustomers(keyword);
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerDAL.GetCustomerById(customerId);
        }

        public void TopUp(int customerId, decimal amount, string note, int processedByUserId)
        {
            if (amount <= 0)
                throw new ArgumentException("Số tiền nạp phải lớn hơn 0.");

            _customerDAL.TopUp(customerId, amount, note, processedByUserId);
        }

        public Tuple<List<TopUpTransaction>, List<SpendTransaction>> GetTransactionHistory(int customerId)
        {
            return _customerDAL.GetTransactionHistory(customerId);
        }
    }
}
