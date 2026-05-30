using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyCuaHangGame.DAL.Repositories;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class ReportData
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalTopUpRevenue { get; set; }
        public decimal TotalCashRevenue { get; set; }
        public decimal TotalSessionRevenue { get; set; }
        public decimal TotalServiceRevenue { get; set; }
        
        public double TotalMachineHours { get; set; }
        public int TotalActiveMachines { get; set; }
        public int TotalMachines { get; set; }
        public int BrokenMachines { get; set; }
        public int NewMembers { get; set; }
        
        public Dictionary<DateTime, decimal> RevenueByDay { get; set; }
        public List<KeyValuePair<string, double>> TopMachineHours { get; set; }
        public List<CustomerReportDto> TopMembers { get; set; }
        
        public int GoodMachines { get; set; }
        public int RepairedMachines { get; set; }
    }

    public class CustomerReportDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public double TotalHours { get; set; }
        public decimal TotalSpent { get; set; }
    }

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

        public ReportData GetReportData(DateTime from, DateTime to)
        {
            to = to.Date.AddDays(1).AddTicks(-1);
            from = from.Date;

            var invoices = unitOfWork.InvoiceRepository.GetAll()
                .Where(i => i.PaidAt >= from && i.PaidAt <= to)
                .ToList();

            var topUps = unitOfWork.TopUpTransactionRepository.GetAll()
                .Where(t => t.CreatedAt >= from && t.CreatedAt <= to)
                .ToList();

            var sessions = unitOfWork.SessionRepository.GetAll()
                .Where(s => s.StartTime >= from && s.StartTime <= to)
                .ToList();

            var newCustomers = unitOfWork.CustomerRepository.GetAll()
                .Where(c => c.CreatedAt >= from && c.CreatedAt <= to)
                .ToList();

            var allComputers = unitOfWork.ComputerRepository.GetAll().ToList();

            decimal cashRevenue = invoices.Sum(i => i.PaidByCash);
            decimal topUpRevenue = topUps.Sum(t => t.Amount);
            decimal totalRevenue = cashRevenue + topUpRevenue;

            decimal sessionRevenue = invoices.Sum(i => i.SessionAmount);
            decimal serviceRevenue = invoices.Sum(i => i.ServiceAmount);

            double totalHours = sessions.Sum(s => s.HoursUsed.HasValue ? (double)s.HoursUsed.Value : (s.EndTime.HasValue ? (s.EndTime.Value - s.StartTime).TotalHours : (DateTime.Now - s.StartTime).TotalHours));

            var data = new ReportData
            {
                TotalRevenue = totalRevenue,
                TotalTopUpRevenue = topUpRevenue,
                TotalCashRevenue = cashRevenue,
                TotalSessionRevenue = sessionRevenue,
                TotalServiceRevenue = serviceRevenue,
                TotalMachineHours = totalHours,
                TotalActiveMachines = allComputers.Count(c => c.Status == "InUse"),
                TotalMachines = allComputers.Count,
                BrokenMachines = allComputers.Count(c => c.Condition == "Hỏng"),
                GoodMachines = allComputers.Count(c => c.Condition == "Tốt"),
                RepairedMachines = allComputers.Count(c => c.Condition == "Đã sửa"),
                NewMembers = newCustomers.Count,
                RevenueByDay = new Dictionary<DateTime, decimal>(),
                TopMachineHours = new List<KeyValuePair<string, double>>(),
                TopMembers = new List<CustomerReportDto>()
            };

            for (DateTime date = from; date <= to.Date; date = date.AddDays(1))
            {
                var dailyInvoices = invoices.Where(i => i.PaidAt.Date == date).Sum(i => i.PaidByCash);
                var dailyTopUps = topUps.Where(t => t.CreatedAt.Date == date).Sum(t => t.Amount);
                data.RevenueByDay[date] = dailyInvoices + dailyTopUps;
            }

            // Include Computer eager load manually if needed
            var compLookup = allComputers.ToDictionary(c => c.Id);
            var machineStats = sessions
                .GroupBy(s => s.ComputerId)
                .Select(g => new KeyValuePair<string, double>(
                    compLookup.ContainsKey(g.Key) ? compLookup[g.Key].Code : "N/A",
                    g.Sum(s => s.HoursUsed.HasValue ? (double)s.HoursUsed.Value : (s.EndTime.HasValue ? (s.EndTime.Value - s.StartTime).TotalHours : (DateTime.Now - s.StartTime).TotalHours))
                ))
                .OrderByDescending(k => k.Value)
                .Take(5)
                .ToList();
            data.TopMachineHours = machineStats;

            var allTopUps = unitOfWork.TopUpTransactionRepository.GetAll().ToList();
            var allSessions = unitOfWork.SessionRepository.GetAll().Where(s => s.CustomerId != null).ToList();

            var topMembers = unitOfWork.CustomerRepository.GetAll().ToList()
                .Select(c => new CustomerReportDto
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Balance = c.Balance,
                    TotalSpent = allTopUps.Where(t => t.CustomerId == c.Id).Sum(t => t.Amount),
                    TotalHours = allSessions.Where(s => s.CustomerId == c.Id).Sum(s => s.HoursUsed.HasValue ? (double)s.HoursUsed.Value : (s.EndTime.HasValue ? (s.EndTime.Value - s.StartTime).TotalHours : (DateTime.Now - s.StartTime).TotalHours))
                })
                .OrderByDescending(c => c.TotalSpent)
                .Take(10)
                .ToList();
            data.TopMembers = topMembers;

            return data;
        }
    }
}
