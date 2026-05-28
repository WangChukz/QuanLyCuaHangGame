using System;
using System.Collections.Generic;
using QuanLyCuaHangGame.DAL;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL
{
    public class PaymentBLL
    {
        private readonly PaymentDAL _paymentDAL = new PaymentDAL();

        /// <summary>
        /// Lấy thông tin chi tiết phiên để hiển thị lên màn hình thanh toán.
        /// </summary>
        public Tuple<Session, List<SessionService>> GetPaymentDetails(int sessionId)
        {
            return _paymentDAL.GetPaymentDetails(sessionId);
        }

        /// <summary>
        /// Tính số giờ sử dụng từ StartTime đến EndTime, làm tròn lên theo phút.
        /// Ví dụ: 1h45p30s → 1.76 giờ (= 106 phút / 60).
        /// </summary>
        public decimal CalculateHoursUsed(DateTime startTime, DateTime endTime)
        {
            var totalMinutes = Math.Ceiling((endTime - startTime).TotalMinutes);
            return (decimal)totalMinutes / 60m;
        }

        /// <summary>
        /// Tính tiền giờ chơi: HoursUsed × PricePerHour.
        /// </summary>
        public decimal CalculateSessionAmount(decimal hoursUsed, decimal pricePerHour)
        {
            return Math.Round(hoursUsed * pricePerHour, 0);
        }

        /// <summary>
        /// Tính tổng tiền dịch vụ: tổng (Quantity × UnitPrice) của tất cả SessionService.
        /// </summary>
        public decimal CalculateServiceAmount(List<SessionService> services)
        {
            decimal total = 0;
            foreach (var s in services)
                total += s.Quantity * s.UnitPrice;
            return total;
        }

        /// <summary>
        /// Tính toán phân bổ tiền thanh toán theo nghiệp vụ 2.7 (mục 21):
        /// - Nếu là hội viên và Balance >= TotalAmount: PaidByBalance = TotalAmount, PaidByCash = 0.
        /// - Nếu là hội viên và Balance < TotalAmount:  PaidByBalance = Balance, PaidByCash = TotalAmount - Balance.
        /// - Nếu là khách vãng lai: PaidByBalance = 0, PaidByCash = TotalAmount.
        /// Trả về Tuple(paidByBalance, paidByCash).
        /// </summary>
        public Tuple<decimal, decimal> CalculatePaymentSplit(decimal totalAmount, decimal? customerBalance)
        {
            if (!customerBalance.HasValue)
            {
                // Khách vãng lai - toàn bộ tiền mặt
                return Tuple.Create(0m, totalAmount);
            }

            decimal balance = customerBalance.Value;
            if (balance >= totalAmount)
            {
                // Đủ số dư - trừ hết từ ví
                return Tuple.Create(totalAmount, 0m);
            }
            else
            {
                // Không đủ - trừ hết ví, phần còn lại thu tiền mặt
                return Tuple.Create(balance, totalAmount - balance);
            }
        }

        /// <summary>
        /// Thực hiện thanh toán và đóng máy:
        /// Tính EndTime = DateTime.Now, tính toán đầy đủ các khoản tiền rồi gọi DAL lưu DB.
        /// </summary>
        /// <param name="sessionId">Id phiên cần đóng</param>
        /// <param name="closedByUserId">Id nhân viên thực hiện</param>
        /// <param name="services">Danh sách dịch vụ trong phiên</param>
        /// <param name="session">Đối tượng Session (để lấy StartTime, PricePerHour, CustomerId)</param>
        /// <param name="extraCash">Tiền mặt bổ sung thêm (nhập tay khi ví không đủ)</param>
        /// <returns>Invoice vừa được tạo</returns>
        public Invoice ProcessPayment(
            int sessionId,
            int closedByUserId,
            Session session,
            List<SessionService> services,
            decimal extraCash = 0)
        {
            var endTime = DateTime.Now;
            var hoursUsed = CalculateHoursUsed(session.StartTime, endTime);
            var sessionAmount = CalculateSessionAmount(hoursUsed, session.PricePerHour);
            var serviceAmount = CalculateServiceAmount(services);
            var totalAmount = sessionAmount + serviceAmount;

            decimal? balance = session.Customer?.Balance;
            var split = CalculatePaymentSplit(totalAmount, balance);

            decimal paidByBalance = split.Item1;
            decimal paidByCash = split.Item2 + extraCash; // cộng thêm tiền mặt bổ sung

            return _paymentDAL.ProcessPayment(
                sessionId,
                closedByUserId,
                endTime,
                hoursUsed,
                sessionAmount,
                serviceAmount,
                totalAmount,
                paidByBalance,
                paidByCash);
        }
    }
}
