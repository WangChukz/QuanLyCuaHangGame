using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using QuanLyCuaHangGame.DAL.Repositories;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class ComputerService
    {
        private UnitOfWork unitOfWork;

        public ComputerService()
        {
            unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Computer> GetAllComputers()
        {
            return unitOfWork.Context.Computers.AsNoTracking().Include("Room").ToList();
        }

        public void AddComputer(Computer computer, decimal initialPrice)
        {
            computer.CreatedAt = DateTime.Now;
            computer.Status = "Trống";
            unitOfWork.ComputerRepository.Insert(computer);
            unitOfWork.Save(); // Save to generate ID

            var price = new ComputerPrice
            {
                ComputerId = computer.Id,
                PricePerHour = initialPrice,
                EffectiveFrom = DateTime.Now,
                IsCurrent = true
            };
            unitOfWork.ComputerPriceRepository.Insert(price);
            unitOfWork.Save();
        }

        public void UpdateCondition(int computerId, string condition)
        {
            var comp = unitOfWork.ComputerRepository.GetById(computerId);
            if (comp != null)
            {
                comp.Condition = condition;
                if (condition == "Hỏng") comp.Status = "Dừng";
                unitOfWork.Save();
            }
        }

        public void UpdatePrice(int computerId, decimal newPrice, DateTime effectiveFrom)
        {
            var currentPrices = unitOfWork.ComputerPriceRepository.GetAll()
                .Where(p => p.ComputerId == computerId && p.IsCurrent);
                
            foreach (var p in currentPrices)
            {
                p.IsCurrent = false;
            }

            var newPriceRecord = new ComputerPrice
            {
                ComputerId = computerId,
                PricePerHour = newPrice,
                EffectiveFrom = effectiveFrom,
                IsCurrent = true
            };
            
            unitOfWork.ComputerPriceRepository.Insert(newPriceRecord);
            unitOfWork.Save();
        }
        
        public decimal GetCurrentPrice(int computerId)
        {
            var price = unitOfWork.ComputerPriceRepository.GetAll()
                .FirstOrDefault(p => p.ComputerId == computerId && p.IsCurrent);
            return price?.PricePerHour ?? 0;
        }
        
        public IEnumerable<Room> GetAllRooms()
        {
            return unitOfWork.RoomRepository.GetAll();
        }
        
        public void AddRoom(Room room)
        {
            unitOfWork.RoomRepository.Insert(room);
            unitOfWork.Save();
        }
    }
}
