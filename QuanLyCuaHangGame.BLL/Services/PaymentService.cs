using System;
using System.Linq;
using QuanLyCuaHangGame.DAL.Repositories;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class PaymentService
    {
        private UnitOfWork unitOfWork;

        public PaymentService()
        {
            unitOfWork = new UnitOfWork();
        }

        public Invoice ProcessPayment(int sessionId, int closedByUserId, decimal cashReceived)
        {
            var session = unitOfWork.SessionRepository.GetById(sessionId);
            if (session == null || session.Status != "Active") return null;

            session.EndTime = DateTime.Now;
            session.HoursUsed = (decimal)(session.EndTime.Value - session.StartTime).TotalHours;
            
            decimal sessionAmount = session.HoursUsed.Value * session.PricePerHour;
            
            var services = unitOfWork.SessionServiceRepository.GetAll().Where(s => s.SessionId == sessionId);
            decimal serviceAmount = services.Sum(s => s.Quantity * s.UnitPrice);
            
            decimal totalAmount = sessionAmount + serviceAmount;
            
            decimal paidByBalance = 0;
            decimal paidByCash = 0;
            decimal changeGiven = 0;

            if (session.CustomerId.HasValue)
            {
                var customer = unitOfWork.CustomerRepository.GetById(session.CustomerId.Value);
                if (customer.Balance >= totalAmount)
                {
                    paidByBalance = totalAmount;
                    customer.Balance -= totalAmount;
                }
                else
                {
                    paidByBalance = customer.Balance;
                    paidByCash = totalAmount - customer.Balance;
                    customer.Balance = 0;
                    changeGiven = cashReceived - paidByCash;
                }
                customer.LastVisitAt = DateTime.Now;
                
                if (paidByBalance > 0)
                {
                    var spend = new SpendTransaction
                    {
                        CustomerId = session.CustomerId.Value,
                        Amount = paidByBalance,
                        Description = $"Thanh toán phiên {session.ComputerId}",
                        CreatedAt = DateTime.Now
                    };
                    unitOfWork.SpendTransactionRepository.Insert(spend);
                }
            }
            else
            {
                paidByCash = totalAmount;
                changeGiven = cashReceived - totalAmount;
            }

            var invoice = new Invoice
            {
                SessionId = sessionId,
                ClosedByUserId = closedByUserId,
                SessionAmount = sessionAmount,
                ServiceAmount = serviceAmount,
                TotalAmount = totalAmount,
                PaidByBalance = paidByBalance,
                PaidByCash = paidByCash,
                ChangeGiven = changeGiven,
                PaidAt = DateTime.Now
            };

            session.Status = "Closed";
            var comp = unitOfWork.ComputerRepository.GetById(session.ComputerId);
            comp.Status = "Trống";

            unitOfWork.InvoiceRepository.Insert(invoice);
            unitOfWork.Save(); 
            
            if (paidByBalance > 0 && session.CustomerId.HasValue)
            {
                var spend = unitOfWork.SpendTransactionRepository.GetAll().OrderByDescending(s => s.Id).FirstOrDefault(s => s.CustomerId == session.CustomerId.Value);
                if (spend != null && spend.InvoiceId == 0)
                {
                    spend.InvoiceId = invoice.Id;
                    unitOfWork.Save();
                }
            }

            return invoice;
        }
    }
}
