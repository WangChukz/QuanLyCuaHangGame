using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.DAL
{
    public class PaymentDAL
    {
        /// <summary>
        /// Lấy thông tin chi tiết để hiển thị màn hình thanh toán.
        /// Trả về Session (bao gồm Computer và Customer) và danh sách SessionService.
        /// </summary>
        public Tuple<Session, List<SessionService>> GetPaymentDetails(int sessionId)
        {
            using (var context = new GameZoneDbContext())
            {
                var session = context.Sessions
                    .Include(s => s.Computer)
                    .Include(s => s.Customer)
                    .Include(s => s.OpenedByUser)
                    .FirstOrDefault(s => s.Id == sessionId);

                if (session == null)
                    return null;

                var services = context.SessionServices
                    .Include(ss => ss.ServiceItem)
                    .Where(ss => ss.SessionId == sessionId)
                    .ToList();

                return Tuple.Create(session, services);
            }
        }

        /// <summary>
        /// Thực hiện quy trình thanh toán và đóng máy theo nghiệp vụ 2.7:
        /// 1. Ghi EndTime, HoursUsed vào Session, đổi Status -> "Closed".
        /// 2. Đổi trạng thái Computer -> "Trống".
        /// 3. Tạo bản ghi Invoice.
        /// 4. Nếu có trừ ví hội viên: cập nhật Customer.Balance và tạo SpendTransaction.
        /// Toàn bộ thực hiện trong 1 transaction DB để đảm bảo toàn vẹn.
        /// </summary>
        /// <param name="sessionId">Id phiên cần đóng</param>
        /// <param name="closedByUserId">Id nhân viên thực hiện thanh toán</param>
        /// <param name="endTime">Thời điểm kết thúc (= DateTime.Now)</param>
        /// <param name="hoursUsed">Số giờ sử dụng (tính theo phút, làm tròn lên)</param>
        /// <param name="sessionAmount">Tiền giờ chơi</param>
        /// <param name="serviceAmount">Tiền dịch vụ</param>
        /// <param name="totalAmount">Tổng tiền</param>
        /// <param name="paidByBalance">Số tiền trừ từ ví hội viên</param>
        /// <param name="paidByCash">Số tiền thanh toán tiền mặt</param>
        /// <returns>Invoice vừa được tạo</returns>
        public Invoice ProcessPayment(
            int sessionId,
            int closedByUserId,
            DateTime endTime,
            decimal hoursUsed,
            decimal sessionAmount,
            decimal serviceAmount,
            decimal totalAmount,
            decimal paidByBalance,
            decimal paidByCash)
        {
            using (var context = new GameZoneDbContext())
            using (var dbTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    // --- Bước 1: Cập nhật Session ---
                    var session = context.Sessions
                        .Include(s => s.Computer)
                        .Include(s => s.Customer)
                        .FirstOrDefault(s => s.Id == sessionId);

                    if (session == null)
                        throw new Exception($"Không tìm thấy phiên với Id = {sessionId}.");

                    session.EndTime = endTime;
                    session.HoursUsed = hoursUsed;
                    session.Status = "Closed";

                    // --- Bước 2: Đổi trạng thái máy về "Trống" ---
                    var computer = context.Computers.Find(session.ComputerId);
                    if (computer != null)
                        computer.Status = "Trống";

                    // --- Bước 3: Tạo Invoice ---
                    var invoice = new Invoice
                    {
                        SessionId = sessionId,
                        ClosedByUserId = closedByUserId,
                        SessionAmount = sessionAmount,
                        ServiceAmount = serviceAmount,
                        TotalAmount = totalAmount,
                        PaidByBalance = paidByBalance,
                        PaidByCash = paidByCash,
                        ChangeGiven = 0,
                        PaidAt = endTime
                    };
                    context.Invoices.Add(invoice);
                    context.SaveChanges(); // SaveChanges để có invoice.Id cho SpendTransaction

                    // --- Bước 4: Nếu có trừ ví hội viên ---
                    if (paidByBalance > 0 && session.CustomerId.HasValue)
                    {
                        var customer = context.Customers.Find(session.CustomerId.Value);
                        if (customer != null)
                        {
                            customer.Balance -= paidByBalance;
                            customer.LastVisitAt = endTime;

                            // Ghi giao dịch chi tiêu vào SpendTransactions
                            var spend = new SpendTransaction
                            {
                                CustomerId = customer.Id,
                                InvoiceId = invoice.Id,
                                Amount = paidByBalance,
                                Description = $"Thanh toán phiên máy {computer?.Code} – {endTime:dd/MM/yyyy HH:mm}",
                                CreatedAt = endTime
                            };
                            context.SpendTransactions.Add(spend);
                        }
                    }

                    context.SaveChanges();
                    dbTransaction.Commit();
                    return invoice;
                }
                catch
                {
                    dbTransaction.Rollback();
                    throw;
                }
            }
        }
    }
}
