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

        public void GenerateInvoicePdf(
            string filePath, 
            Session session, 
            List<SessionService> services, 
            DateTime endTime, 
            decimal sessionAmount, 
            decimal totalAmount, 
            decimal extraCash)
        {
            try
            {
                // ── Font: dùng Tahoma (hỗ trợ tiếng Việt, cho phép embedding)
                // Arial bị giới hạn embedding (fsType=4) → iText 7 ném PdfException khi FORCE_EMBEDDED.
                string fontsDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

                string fontPath       = System.IO.Path.Combine(fontsDir, "tahoma.ttf");
                string boldFontPath   = System.IO.Path.Combine(fontsDir, "tahomabd.ttf");
                string italicFontPath = System.IO.Path.Combine(fontsDir, "tahoma.ttf"); // Tahoma không có file italic riêng

                // Kiểm tra font tồn tại; nếu thiếu tahomabd thì dùng tahoma thường
                if (!System.IO.File.Exists(boldFontPath))
                    boldFontPath = fontPath;

                if (!System.IO.File.Exists(fontPath))
                    throw new System.IO.FileNotFoundException(
                        "Không tìm thấy font Tahoma trên hệ thống. Đảm bảo file tahoma.ttf tồn tại trong " + fontsDir);

                // PREFER_EMBEDDED: embed nếu font cho phép, không throw nếu bị restricted
                var embeddingStrategy = iText.Kernel.Font.PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED;

                using (var document = new iText.Layout.Document(
                    new iText.Kernel.Pdf.PdfDocument(
                        new iText.Kernel.Pdf.PdfWriter(filePath))))
                {
                        iText.Kernel.Font.PdfFont font = iText.Kernel.Font.PdfFontFactory.CreateFont(
                            fontPath, iText.IO.Font.PdfEncodings.IDENTITY_H, embeddingStrategy);
                        iText.Kernel.Font.PdfFont boldFont = iText.Kernel.Font.PdfFontFactory.CreateFont(
                            boldFontPath, iText.IO.Font.PdfEncodings.IDENTITY_H, embeddingStrategy);
                        iText.Kernel.Font.PdfFont italicFont = iText.Kernel.Font.PdfFontFactory.CreateFont(
                            italicFontPath, iText.IO.Font.PdfEncodings.IDENTITY_H, embeddingStrategy);
                        
                        document.SetFont(font);

                        // Header
                        var header = new iText.Layout.Element.Paragraph("HÓA ĐƠN THANH TOÁN")
                            .SetFont(boldFont)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFontSize(20);
                        document.Add(header);

                        document.Add(new iText.Layout.Element.Paragraph("GAMEZONE - ĐẲNG CẤP GAMER")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                            .SetFontSize(14));
                        document.Add(new iText.Layout.Element.Paragraph("--------------------------------------------------")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        // Thông tin phiên chơi
                        string tenKhach = session.Customer?.FullName ?? session.GuestName ?? "Khách vãng lai";
                        document.Add(new iText.Layout.Element.Paragraph($"Khách hàng: {tenKhach}"));
                        document.Add(new iText.Layout.Element.Paragraph($"Máy: {session.Computer?.Code ?? "Không rõ"}"));
                        document.Add(new iText.Layout.Element.Paragraph($"Bắt đầu: {session.StartTime:dd/MM/yyyy HH:mm:ss}"));
                        document.Add(new iText.Layout.Element.Paragraph($"Kết thúc: {endTime:dd/MM/yyyy HH:mm:ss}"));
                        
                        int totalMinutes = (int)Math.Ceiling((endTime - session.StartTime).TotalMinutes);
                        int h = totalMinutes / 60;
                        int m = totalMinutes % 60;
                        string timeUsed = h > 0 ? $"{h} giờ {m} phút" : $"{m} phút";
                        document.Add(new iText.Layout.Element.Paragraph($"Thời gian chơi: {timeUsed}"));

                        document.Add(new iText.Layout.Element.Paragraph("--------------------------------------------------")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        // Bảng chi tiết dịch vụ
                        var table = new iText.Layout.Element.Table(new float[] { 4, 1, 2, 2 }).UseAllAvailableWidth();
                        table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Diễn giải").SetFont(boldFont)));
                        table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("SL").SetFont(boldFont)));
                        table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Đơn giá").SetFont(boldFont)));
                        table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Thành tiền").SetFont(boldFont)));

                        // Dòng tiền giờ
                        table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("Tiền giờ chơi")));
                        table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph("-")));
                        table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph($"{session.PricePerHour:N0}")));
                        table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph($"{sessionAmount:N0}")));

                        // Dòng dịch vụ
                        if (services != null)
                        {
                            foreach (var svc in services)
                            {
                                string tenDV = svc.ServiceItem?.Name ?? $"Dịch vụ #{svc.ServiceItemId}";
                                table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(tenDV)));
                                table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph(svc.Quantity.ToString())));
                                table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph($"{svc.UnitPrice:N0}")));
                                table.AddCell(new iText.Layout.Element.Cell().Add(new iText.Layout.Element.Paragraph($"{(svc.Quantity * svc.UnitPrice):N0}")));
                            }
                        }

                        document.Add(table);
                        document.Add(new iText.Layout.Element.Paragraph("--------------------------------------------------")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        // Tổng cộng
                        document.Add(new iText.Layout.Element.Paragraph($"Tổng cộng: {totalAmount:N0} đ")
                            .SetFont(boldFont)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                            .SetFontSize(14));

                        // Phân bổ
                        var split = CalculatePaymentSplit(totalAmount, session.Customer?.Balance);
                        
                        document.Add(new iText.Layout.Element.Paragraph($"Trừ ví hội viên: {split.Item1:N0} đ")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));
                        document.Add(new iText.Layout.Element.Paragraph($"Tiền mặt thu thêm: {extraCash:N0} đ")
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));

                        document.Add(new iText.Layout.Element.Paragraph("\nCảm ơn quý khách và hẹn gặp lại!")
                            .SetFont(italicFont)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        // KHÔNG gọi document.Close() thủ công – using block tự xử lý Dispose()
                }
            }
            catch (Exception ex)
            {
                // Hiển thị cả inner exception để dễ chẩn đoán lỗi iText
                string detail = ex.InnerException != null
                    ? $"{ex.Message}\n→ Chi tiết: {ex.InnerException.Message}"
                    : ex.Message;
                throw new Exception("Lỗi tạo PDF: " + detail, ex);
            }
        }
    }
}
