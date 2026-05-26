using System.Collections.Generic;
using System.Linq;
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

        // Lấy tất cả dịch vụ
        public IEnumerable<ServiceItem> GetAllServices()
        {
            return unitOfWork.ServiceItemRepository.GetAll();
        }

        // Lấy dịch vụ theo ID
        public ServiceItem GetServiceById(int id)
        {
            return unitOfWork.ServiceItemRepository.GetById(id);
        }

        // Thêm dịch vụ mới
        public void AddService(ServiceItem service)
        {
            unitOfWork.ServiceItemRepository.Insert(service);
            unitOfWork.Save();
        }

        // Cập nhật dịch vụ
        public void UpdateService(ServiceItem service)
        {
            unitOfWork.ServiceItemRepository.Update(service);
            unitOfWork.Save();
        }

        // Xóa dịch vụ theo ID
        public void DeleteService(int id)
        {
            unitOfWork.ServiceItemRepository.Delete(id);
            unitOfWork.Save();
        }

        // Lấy tất cả dịch vụ còn có sẵn
        public IEnumerable<ServiceItem> GetAvailableServices()
        {
            return unitOfWork.ServiceItemRepository.GetAll()
                .Where(s => s.IsAvailable);
        }

        // Lấy dịch vụ theo category
        public IEnumerable<ServiceItem> GetServicesByCategory(string category)
        {
            return unitOfWork.ServiceItemRepository.GetAll()
                .Where(s => s.Category == category);
        }
    }
}