# QuanLyCuaHangGame (Quản Lý Cửa Hàng Game)

Dự án phần mềm quản lý cửa hàng game (quán Net/Cyber) được xây dựng trên nền tảng **C# WinForms**, áp dụng mô hình kiến trúc **3 Lớp (3-Tier Architecture)** và **Entity Framework**.

## 📌 Công nghệ sử dụng
- **Ngôn ngữ:** C# (.NET Framework 4.7.2)
- **Giao diện:** Windows Forms (có tích hợp MaterialSkin / LiveCharts)
- **Cơ sở dữ liệu:** SQL Server (LocalDB) qua Entity Framework 6
- **Mô hình kiến trúc:** 3-Tier (GUI, BLL, DAL, kết hợp Model)

## 📁 Cấu trúc dự án
Dự án được chia thành 4 Project chính để đảm bảo tính đóng gói và dễ bảo trì:
1. **QuanLyCuaHangGame.Model:** Chứa các Class/Entity đại diện cho các bảng trong CSDL.
2. **QuanLyCuaHangGame.DAL (Data Access Layer):** Chuyên giao tiếp với CSDL (Thêm, sửa, xóa, lấy dữ liệu).
3. **QuanLyCuaHangGame.BLL (Business Logic Layer):** Chứa các quy tắc nghiệp vụ, kiểm tra tính hợp lệ của dữ liệu trước khi gọi DAL.
4. **QuanLyCuaHangGame (GUI):** Giao diện phần mềm, chỉ gọi hàm từ BLL, không bao giờ kết nối thẳng CSDL.

## 🚀 Hướng dẫn cài đặt và chạy thử
Nhờ việc sử dụng **LocalDB**, bạn không cần cấu hình SQL Server phức tạp. Chỉ cần làm theo các bước sau:

1. **Clone dự án về máy:**
   ```bash
   git clone <link_repo_cua_ban>
   ```
2. Mở file `QuanLyCuaHangGame.sln` bằng **Visual Studio**.
3. Nhấn chuột phải vào Solution -> Chọn **Restore NuGet Packages** (nếu cần) để tải các thư viện.
4. Mở *Package Manager Console* (Tools > NuGet Package Manager), chọn *Default project* là `QuanLyCuaHangGame.Model` và chạy lệnh sau để tạo Database:
   ```bash
   Update-Database
   ```
5. Nhấn **F5** hoặc **Start** để chạy phần mềm.

## 👥 Dành cho lập trình viên (Thành viên nhóm)
Hãy đọc kỹ file [HUONG_DAN_CODE.md](HUONG_DAN_CODE.md) trước khi code để nắm rõ quy tắc làm việc nhóm và cách luân chuyển dữ liệu qua mô hình 3 lớp.
