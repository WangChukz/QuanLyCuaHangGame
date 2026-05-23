using System;
using System.Collections.Generic;
using System.Linq;
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
            return unitOfWork.Context.Sessions.Include("Computer").Include("Customer").Where(s => s.Status == "Active").ToList();
        }
        
        public IEnumerable<QuanLyCuaHangGame.Model.SessionService> GetServicesForSession(int sessionId)
        {
            return unitOfWork.Context.SessionServices.Include("ServiceItem").Where(ss => ss.SessionId == sessionId).ToList();
        }
    }
}
