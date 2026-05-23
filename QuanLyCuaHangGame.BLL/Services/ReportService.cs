using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangGame.DAL.Repositories;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class ReportService
    {
        private UnitOfWork unitOfWork;

        public ReportService()
        {
            unitOfWork = new UnitOfWork();
        }

        public decimal GetTotalRevenue(DateTime from, DateTime to)
        {
            return unitOfWork.InvoiceRepository.GetAll()
                .Where(i => i.PaidAt >= from && i.PaidAt <= to)
                .Sum(i => (decimal?)i.TotalAmount) ?? 0;
        }
    }
}
