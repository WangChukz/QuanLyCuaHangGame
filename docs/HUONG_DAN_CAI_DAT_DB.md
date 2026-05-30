# HƯỚNG DẪN CÀI ĐẶT VÀ KẾT NỐI DATABASE (DÀNH CHO TEAM)

Tài liệu này hướng dẫn cách setup môi trường cơ sở dữ liệu để chạy dự án **QuanLyCuaHangGame** sau khi clone từ repository về máy.

---

## 1. Yêu cầu trước khi cài đặt
- Đã cài đặt **SQL Server** (phiên bản Developer, Enterprise hoặc Express).
- Đã cài đặt **SQL Server Management Studio (SSMS)**.

---

## 2. Bước 1: Tạo Database bằng Script
Thay vì phải tạo từng bảng bằng tay, dự án đã có sẵn file script tự động tạo cấu trúc và chèn dữ liệu mẫu.

1. Mở thư mục gốc của dự án, tìm file: `GameZone_Database_Script.sql`.
2. Click đúp vào file để mở bằng **SSMS**, hoặc kéo thả file này vào cửa sổ SSMS.
3. Đăng nhập vào Server của bạn (Localhost).
4. Nhấn phím **F5** (hoặc nút **Execute**) để chạy lệnh.
5. Kiểm tra cửa sổ Messages ở dưới, nếu hiện `HOÀN TẤT! Database GameZoneProDB sẵn sàng.` (hoặc không có lỗi màu đỏ) là đã tạo thành công cơ sở dữ liệu tên `GameZoneProDB`.

---

## 3. Bước 2: Chạy dự án (Smart Connection)
Dự án đã được tích hợp tính năng **Tự động nhận diện Database (Smart Connection)**. 

Bạn **KHÔNG CẦN PHẢI CẤU HÌNH GÌ THÊM**. Hệ thống sẽ tự động dò tìm:
1. Thử kết nối với **SQL Server Express** (`.\SQLEXPRESS`).
2. Nếu không có bản Express, tự động chuyển sang **SQL Server mặc định** (`.`).

👉 **Chỉ cần bạn đã chạy Script ở Bước 1 thành công, bạn có thể ấn Start chạy dự án ngay lập tức!** Bất kỳ thành viên nào trong team clone code về cũng không cần phải vào sửa cấu hình.

---

## 4. Thông tin Đăng nhập Mẫu (Test Data)
Sau khi setup thành công và chạy ứng dụng, bạn có thể dùng các tài khoản dưới đây để test chức năng:

**Tài khoản Quản lý / Nhân viên (Sử dụng đăng nhập vào phần mềm):**
- Admin: Username: `admin` | Password: `Admin@123456`
- Staff: Username: `nvnam` hoặc `tthg` | Password: `Staff@123456`

**Tài khoản Khách hàng (Hội viên):**
- `pqhuy` (Mã PIN: 1234) - Số dư: 150.000đ
- `nvana` (Mã PIN: 5678) - Số dư: 85.000đ
- `vtmai` (Mã PIN: 6789) - Số dư: 200.000đ

---

## 5. Khắc phục lỗi thường gặp (Troubleshooting)
**Lỗi: _"A network-related or instance-specific error occurred while establishing a connection to SQL Server..."_**
👉 **Nguyên nhân:** C# không tìm thấy cơ sở dữ liệu trong SQL Server của bạn.
👉 **Cách sửa:** 
- Đảm bảo Service SQL Server đang chạy trong `services.msc`.
- Đảm bảo bạn đã chạy file script ở Bước 1 thành công trên máy của bạn.
- Đảm bảo server SQL của bạn mang tên mặc định (`.`) hoặc (`.\SQLEXPRESS`). Nếu tên server của bạn là một cái tên tuỳ chỉnh hoàn toàn khác (ví dụ `MAY-CUA-TOI\SQL2022`), hãy liên hệ team để điều chỉnh `GameZoneDbContext.cs`.
