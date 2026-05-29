using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using QuanLyCuaHangGame.DAL.Repositories;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class SessionService
    {
        private UnitOfWork unitOfWork;

        public SessionService()
        {
            unitOfWork = new UnitOfWork();
        }

        public Session OpenSession(int computerId, int userId, int? customerId, string guestName, decimal pricePerHour)
        {
            var comp = unitOfWork.ComputerRepository.GetById(computerId);
            if (comp == null || comp.Status != "Trống") return null;

            // Fallback nếu chạy trực tiếp form Map không qua Login để tránh lỗi FK
            if (userId == 0)
            {
                var defaultUser = unitOfWork.UserRepository.GetAll().FirstOrDefault();
                if (defaultUser != null)
                {
                    userId = defaultUser.Id;
                }
            }

            var session = new Session
            {
                ComputerId = computerId,
                OpenedByUserId = userId,
                CustomerId = customerId,
                GuestName = guestName,
                PricePerHour = pricePerHour,
                StartTime = DateTime.Now,
                Status = "Active"
            };

            comp.Status = "Đang dùng";
            
            unitOfWork.SessionRepository.Insert(session);
            unitOfWork.Save();
            return session;
        }

        public void CloseSession(int computerId)
        {
            var comp = unitOfWork.ComputerRepository.GetById(computerId);
            if (comp == null) return;

            var session = unitOfWork.Context.Sessions
                .FirstOrDefault(s => s.ComputerId == computerId && s.Status == "Active");

            if (session != null)
            {
                session.EndTime = DateTime.Now;
                session.Status = "Completed";
                if (session.StartTime < session.EndTime.Value)
                {
                    session.HoursUsed = (decimal)(session.EndTime.Value - session.StartTime).TotalHours;
                }
                else
                {
                    session.HoursUsed = 0;
                }
            }

            comp.Status = "Trống";
            unitOfWork.Save();
        }

        public void AddServiceToSession(int sessionId, int serviceItemId, int quantity, decimal unitPrice)
        {
            var sessionService = new QuanLyCuaHangGame.Model.SessionService
            {
                SessionId = sessionId,
                ServiceItemId = serviceItemId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                OrderedAt = DateTime.Now
            };
            unitOfWork.SessionServiceRepository.Insert(sessionService);
            unitOfWork.Save();
        }
        
        public IEnumerable<Session> GetActiveSessions()
        {
            return unitOfWork.Context.Sessions.AsNoTracking().Include("Computer").Include("Customer").Where(s => s.Status == "Active").ToList();
        }
        
        public IEnumerable<QuanLyCuaHangGame.Model.SessionService> GetServicesForSession(int sessionId)
        {
            return unitOfWork.Context.SessionServices.AsNoTracking().Include("ServiceItem").Where(ss => ss.SessionId == sessionId).ToList();
        }
    }
}
