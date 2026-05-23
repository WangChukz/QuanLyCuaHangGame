using System.Collections.Generic;
using QuanLyCuaHangGame.DAL.Repositories;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class ServiceItemService
    {
        private UnitOfWork unitOfWork;

        public ServiceItemService()
        {
            unitOfWork = new UnitOfWork();
        }

        public IEnumerable<ServiceItem> GetAllServices()
        {
            return unitOfWork.ServiceItemRepository.GetAll();
        }

        public void AddService(ServiceItem service)
        {
            unitOfWork.ServiceItemRepository.Insert(service);
            unitOfWork.Save();
        }
    }
}
