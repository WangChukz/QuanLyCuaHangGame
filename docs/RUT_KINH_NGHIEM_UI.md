# BẢNG TỔNG HỢP VÀ RÚT KINH NGHIỆM THIẾT KẾ UI/UX WINFORMS

Tài liệu này tổng hợp các lỗi sai thường gặp trong quá trình thiết kế và phát triển giao diện (GUI) cho dự án, nhằm ghi nhớ và tránh lặp lại trong các Form khác.

## 1. Lỗi Chọn Sai Phiên Bản Control (MaterialSkin)
- **Vấn đề:** Sử dụng lẫn lộn giữa `MaterialTextBox` (v1) và `MaterialTextBox2` (v2) trên cùng một giao diện. Việc này dẫn đến việc chiều cao (Height) của các ô nhập liệu không đồng nhất, chữ bị lệch hoặc lẹm viền dưới, mất cân đối với thiết kế tổng thể.
- **Cách khắc phục:** 
  - Luôn đồng bộ hóa phiên bản các component (Ví dụ: Dùng thống nhất `MaterialTextBox` cao 50px cho tất cả các Form).
  - Kiểm tra kỹ `frmLogin` hoặc các form chuẩn mực đã có để clone đúng cấu hình.

## 2. Lỗi Vỡ Bố Cục và Chồng Lấn (Overlap) Phần Tử
- **Vấn đề:** Khi thêm, xóa hoặc thay đổi kích thước của một Control (như TextBox, Label), quên không cập nhật lại tọa độ `Location.Y` cho các phần tử bên dưới nó. Kết quả là các thành phần đè lên nhau, hoặc khoảng cách (padding/margin) chỗ quá rộng, chỗ quá hẹp.
- **Cách khắc phục:** 
  - Luôn tính toán tọa độ theo công thức: `Y_mới = Y_cũ + Chiều_cao_phần_tử_cũ + Khoảng_cách_chuẩn (Gap)`.
  - Đối với WinForms kéo thả, đảm bảo kiểm tra lại bằng giao diện thiết kế (Designer) hoặc đối chiếu code `frm.Designer.cs`.

## 3. Lỗi Tràn Viền, Mất Nút Bấm
- **Vấn đề:** Nút `Lưu` và `Hủy` bị che khuất, biến mất khỏi màn hình khi các ô nhập liệu phía trên phình to ra. Nguyên nhân do không tăng chiều cao tổng thể của Form (`ClientSize`) và các Panel chứa nó (`pnlRight`, `cardDetails`).
- **Cách khắc phục:**
  - Khi nội dung Card dài ra, phải tăng `Height` của thẻ Card đó, đồng thời tăng `Height` của các vùng chứa cấp cao hơn (Panel, ClientSize của Form) một khoảng tương ứng để chứa đủ nội dung.
  - Áp dụng các thuộc tính `Anchor` (Bottom | Right) đúng cách để nút luôn bám lề dưới.

## 4. Lạm Dụng Text Gợi Ý Cố Định (Cluttered UI)
- **Vấn đề:** Đặt quá nhiều dòng chữ mô tả dài dòng tĩnh trên giao diện (Ví dụ: "Mật khẩu mã hóa BCrypt...", "Duy nhất trong hệ thống...", "Tối thiểu 8 ký tự..."). Điều này làm rác giao diện, tốn không gian và mất đi vẻ chuyên nghiệp, hiện đại.
- **Cách khắc phục:**
  - Sử dụng thuộc tính `Hint` (Placeholder text) trên Textbox để gợi ý.
  - Sử dụng `ToolTip` hiển thị dưới dạng cảnh báo (bóng bay) khi người dùng nhập sai, vừa trực quan vừa tiết kiệm diện tích.

## 5. Vi Phạm Kiến Trúc 3 Lớp (GUI - BLL - DAL)
- **Vấn đề:** Xử lý trực tiếp kết nối Database (DbSet, EntityFramework) hoặc viết logic phức tạp trực tiếp bên trong Form (`frmUser.cs`). Điều này vi phạm nghiêm ngặt kiến trúc 3 lớp.
- **Cách khắc phục:** 
  - Giao diện (GUI) chỉ làm nhiệm vụ hiển thị và bắt sự kiện.
  - Mọi thao tác truy xuất dữ liệu, lưu trữ, kiểm tra logic nghiệp vụ phải gọi qua tầng `BLL` (Business Logic Layer), và BLL sẽ giao tiếp với `DAL`.
  - Tuyệt đối tuân thủ `Service` pattern (như `UserService`).

## 6. Lỗi Nút Bấm Bị Che/Kéo Sát Viền Dưới (Lỗi Anchor & Padding)
- **Vấn đề:** Khi neo (Anchor) 2 nút Lưu/Hủy ở `Bottom | Right`, nếu cửa sổ thu nhỏ kích thước, nút sẽ bị kéo ngược lên trên và chạm/đè vào các phần tử phía trên. Ngược lại, nếu thẻ nền (CardDetails) bị giới hạn, vùng viền Footer đổ bóng của Form (chẳng hạn của `MaterialForm`) sẽ lấn lên và che khuất mất lề dưới cùng, làm cho nút bấm bị dính sát vào viền tím trông rất lỗi.
- **Cách khắc phục:**
  - Chuyển `Anchor` của các nút bấm về `Top | Right` để chúng giữ khoảng cách cố định an toàn với các phần tử phía trên, thay vì đu bám theo lề dưới (tránh bị kéo giãn).
  - Phải tăng khoảng đệm dưới `Padding.Bottom` cho `Panel` chứa thẻ nền (Ví dụ tăng từ `16px` lên `60px`) để đẩy toàn bộ nội dung lên cao, chừa khoảng trống an toàn để không bao giờ bị Footer che lấp nữa.

## 7. Lỗi Nhảy Bố Cục Khi Mở Hộp Thoại (WM_SIZE Bug)
- **Vấn đề:** Trong MaterialSkin2, khi mở một hộp thoại (ví dụ: `MaterialMessageBox.Show` hoặc `form.ShowDialog()`), form cha bị mất focus và kích hoạt sự kiện cập nhật giao diện (`WM_SIZE` hoặc `WM_WINDOWPOSCHANGED`). Điều này khiến form cha tự động co giãn, làm vỡ khung thiết kế (kích thước Panel, lộn xộn các phần tử).
- **Cách khắc phục:**
  - Viết đè hàm `WndProc` để chặn các thông điệp thay đổi kích thước trong thời gian mở hộp thoại.
  - Sử dụng cơ chế lưu lại toạ độ (Bounds) của các Control chính trước khi mở hộp thoại, và khôi phục (Restore) lại toạ độ sau khi đóng hộp thoại.
  - Cụ thể: Khai báo cờ `_dialogOpen = true`, gọi hộp thoại trong khối `try`, và khôi phục Bounds trong khối `finally`.

---
*Lưu ý: Tài liệu này được tạo ra để tự động rà soát khi thiết kế các Form mới (như frmComputer, frmCustomer, v.v.).*
