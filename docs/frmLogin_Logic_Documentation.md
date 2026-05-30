# Tài liệu Logic Nghiệp vụ - Form Đăng nhập (frmLogin)

Tài liệu này mô tả chi tiết về logic cấu trúc, cơ chế bảo mật chống brute-force và các biến hệ thống được sử dụng bên trong `frmLogin.cs`. Nó cũng cung cấp hướng dẫn cách sửa đổi các tham số này nếu cần.

---

## 1. Logic Cấu trúc (Structural Logic)

Form Đăng nhập (`frmLogin`) hoạt động theo luồng cơ bản sau:
1. **Khởi tạo (Constructor):** 
   - Khởi tạo giao diện (MaterialSkin) và áp dụng màu chủ đạo.
   - Khởi tạo `UserService` để giao tiếp với tầng cơ sở dữ liệu (BLL/DAL).
   - Tự động gọi hàm `LoadLoginInfo()` để kiểm tra xem có tài khoản nào được lưu trước đó hay không.
   - Tự động gọi hàm `LoadLockoutInfo()` để kiểm tra xem hệ thống có đang bị khóa (bởi nhập sai quá nhiều lần trước đó) hay không.
2. **Sự kiện Click Đăng nhập (`btnLogin_Click`):**
   - Xác thực người dùng thông qua `userService.Authenticate(username, password)`.
   - Nếu **thành công**: Gọi hàm `SaveLoginInfo` (nếu ô "Ghi nhớ" được tích), mở cửa sổ `frmDashboard`, và ẩn form đăng nhập. Reset lại các biến đếm số lần sai.
   - Nếu **thất bại**: Tăng biến đếm số lần sai (`failedAttempts`). Nếu vượt qua giới hạn cho phép, gọi hàm `ApplyLockout()` để khóa giao diện tạm thời.

---

## 2. Logic Bảo mật (Security Logic)

### 2.1. Cơ chế chống Brute-Force (Nhập sai nhiều lần)
Hệ thống sử dụng cơ chế khóa tạm thời (Lockout) có cấp độ tăng dần:
- **Ngưỡng khóa lần đầu:** Cho phép nhập sai tối đa **5 lần**.
- **Ngưỡng khóa các lần sau:** Nếu tài khoản vừa hết hạn khóa, người dùng chỉ có **1 lần** để nhập đúng. Nếu tiếp tục sai, cấp độ khóa (`lockLevel`) sẽ tự động tăng lên.
- **Thời gian khóa (Phút):** Được tính bằng công thức: `5 * lockLevel`. 
   - Lần 1: Khóa 5 phút.
   - Lần 2: Khóa 10 phút.
   - Lần 3: Khóa 15 phút.

> [!IMPORTANT]
> **Khóa cố định chống Restart:**
> Trạng thái khóa (bao gồm mốc thời gian mở khóa `lockoutEnd.Ticks` và cấp độ `lockLevel`) được tự động lưu vào một file vật lý tên là `lockout.dat`. 
> Điều này có nghĩa là **nếu người dùng cố tình tắt ứng dụng (hoặc tắt máy tính) trong thời gian bị khóa và mở lại, ứng dụng vẫn sẽ tiếp tục trạng thái khóa**. Đồng hồ tính giờ vẫn sẽ đối chiếu chính xác với thời gian thực của máy tính để ngăn chặn mọi hành vi gian lận.

### 2.2. Cơ chế Ghi nhớ Đăng nhập (Remember Me)
- Nếu người dùng chọn "Nhớ mật khẩu", thông tin sẽ được lưu vào file `login_cfg.dat` nằm trong thư mục gốc.
- **Bảo vệ dữ liệu:** 
  - Mật khẩu trước khi ghi ra file sẽ được mã hóa đơn giản bằng chuẩn **Base64** (`Convert.ToBase64String`) để tránh bị lộ nếu có người mở file bằng Notepad.
  - File `login_cfg.dat` được gán thuộc tính `Hidden` (Ẩn) để tránh bị người dùng vô tình xóa mất trong thư mục cài đặt.

---

## 3. Các Biến Hệ thống Quan trọng

Dưới đây là các biến toàn cục tham gia vào quá trình bảo mật và cấu trúc:

| Tên biến | Kiểu dữ liệu | Ý nghĩa / Chức năng |
|---|---|---|
| `failedAttempts` | `int` | Đếm số lần nhập sai mật khẩu liên tiếp. |
| `lockLevel` | `int` | Cấp độ khóa hiện tại. Cấp độ càng cao, thời gian phạt khóa càng lâu. |
| `lockoutEnd` | `DateTime` | Thời điểm chính xác (theo đồng hồ máy tính) mà lệnh khóa đăng nhập sẽ kết thúc. |
| `lockTimer` | `Timer` | Component đếm ngược theo từng giây (Interval = 1000) để cập nhật thời gian còn lại lên nút Đăng nhập. |
| `userService` | `UserService` | Service tầng BLL chịu trách nhiệm gọi hàm SQL kiểm tra Username/Password dưới DB. |

---

## 4. Hướng dẫn Chỉnh sửa (Modification Guide)

Nếu bạn cần tinh chỉnh lại các tham số cấu hình hoặc logic, hãy tìm đến các đoạn code sau trong file `frmLogin.cs`:

### Sửa số lần cho phép nhập sai
Tìm dòng code sau trong phương thức `btnLogin_Click`:
```csharp
int allowedAttempts = (lockLevel == 0) ? 5 : 1;
```
> [!TIP]
> - Đổi `5` thành số lần bạn muốn cho phép sai ở lần đầu tiên (Ví dụ: `3`).
> - Đổi `1` thành số cơ hội bạn muốn cho người dùng sau khi họ vừa được mở khóa (Ví dụ: `2`).

### Sửa thời gian phạt (Phút)
Tìm dòng code sau trong phương thức `btnLogin_Click`:
```csharp
int lockMinutes = 5 * lockLevel; // 1st: 5m, 2nd: 10m, 3rd: 15m...
```
> [!TIP]
> - Đổi `5` thành số phút phạt cho mỗi cấp độ. Nếu bạn để là `1`, thời gian khóa sẽ là 1 phút, 2 phút, 3 phút.

### Đổi thuật toán mã hóa file Remember Me
Tìm hàm `SaveLoginInfo` và `LoadLoginInfo`:
```csharp
// Đang sử dụng mã hóa Base64 đơn giản:
string b64pwd = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
```
> [!WARNING]
> Base64 có thể dễ dàng được giải mã (decode) bởi những ai am hiểu công nghệ. Nếu bạn muốn ứng dụng an toàn hơn, hãy thay đổi phương thức `GetBytes` thành các thuật toán mã hóa băm như **AES-256** kết hợp với một Secret Key cố định trong BLL.

### Đổi tên file lưu trữ cấu hình
Tìm các phương thức `GetConfigPath()` và `GetLockoutPath()` ở dòng ~41:
```csharp
private string GetConfigPath() => System.IO.Path.Combine(Application.StartupPath, "login_cfg.dat");
private string GetLockoutPath() => System.IO.Path.Combine(Application.StartupPath, "lockout.dat");
```
> [!NOTE]
> Bạn có thể đổi tên `.dat` thành `.txt`, `.bin` hoặc bất kỳ đuôi nào để làm khó những người muốn can thiệp trực tiếp vào file hệ thống.
