using System;
using System.Linq;
using QuanLyCuaHangGame.DAL;
using QuanLyCuaHangGame.Model;

namespace QuanLyCuaHangGame.BLL.Services
{
    public class DatabaseSeeder
    {
        public void SeedData()
        {
            using (var db = new GameZoneDbContext())
            {
                // Ensure Database is Created
                db.Database.CreateIfNotExists();

                bool hasChanges = false;

                // 1. Seed Users
                if (!db.Users.Any())
                {
                    db.Users.Add(new User
                    {
                        FullName = "Quản trị viên",
                        Username = "admin",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456789a"),
                        Role = "Admin",
                        IsActive = true
                    });
                    db.Users.Add(new User
                    {
                        FullName = "Nhân viên 1",
                        Username = "staff1",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456789a"),
                        Role = "Staff",
                        IsActive = true
                    });
                    hasChanges = true;
                }

                // 2. Seed Customers
                if (!db.Customers.Any())
                {
                    db.Customers.Add(new Customer { Username = "khach1", PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"), FullName = "Nguyễn Văn A", Phone = "0901234567", PinCode = "1111", Balance = 100000, IsActive = true });
                    db.Customers.Add(new Customer { Username = "khach2", PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"), FullName = "Trần Thị B", Phone = "0987654321", PinCode = "2222", Balance = 500000, IsActive = true });
                    hasChanges = true;
                }

                // 3. Seed Rooms
                if (!db.Rooms.Any())
                {
                    var roomThuong = new Room { Name = "Phòng Thường", Description = "Khu vực chơi game chung", Floor = 1, IsActive = true };
                    var roomVip = new Room { Name = "Phòng VIP", Description = "Máy lạnh, ghế sofa, phím cơ cao cấp", Floor = 2, IsActive = true };
                    db.Rooms.Add(roomThuong);
                    db.Rooms.Add(roomVip);
                    db.SaveChanges(); // Need IDs for Computers
                }

                // 5. Seed Services
                if (!db.ServiceItems.Any())
                {
                    db.ServiceItems.Add(new ServiceItem { Name = "Mì xào bò", Category = "Đồ ăn", Price = 35000, IsAvailable = true });
                    db.ServiceItems.Add(new ServiceItem { Name = "Nước ngọt Coca", Category = "Đồ uống", Price = 15000, IsAvailable = true });
                    db.ServiceItems.Add(new ServiceItem { Name = "Bò húc", Category = "Đồ uống", Price = 15000, IsAvailable = true });
                    db.ServiceItems.Add(new ServiceItem { Name = "Sting dâu", Category = "Đồ uống", Price = 12000, IsAvailable = true });
                    db.ServiceItems.Add(new ServiceItem { Name = "Trà đá", Category = "Đồ uống", Price = 5000, IsAvailable = true });
                    hasChanges = true;
                }

                // Đảm bảo có tối thiểu 20 máy (12 máy thường, 8 máy VIP)
                var countComps = db.Computers.Count();
                if (countComps < 20)
                {
                    var roomThuong = db.Rooms.FirstOrDefault(r => r.Name == "Phòng Thường");
                    var roomVip = db.Rooms.FirstOrDefault(r => r.Name == "Phòng VIP");
                    if (roomThuong != null && roomVip != null)
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            string code = "MAY-" + i.ToString("D2");
                            if (!db.Computers.Any(c => c.Code == code))
                            {
                                string condition = (i == 3) ? "Hỏng" : "Tốt";
                                string status = (i == 4) ? "Đang dùng" : "Trống";
                                db.Computers.Add(new Computer { Code = code, RoomId = roomThuong.Id, Tier = "Thường", Cpu = "Core i5", Ram = "16GB", Gpu = "GTX 1650", Storage = "SSD 256GB", Condition = condition, Status = status });
                            }
                        }
                        for (int i = 1; i <= 8; i++)
                        {
                            string code = "VIP-" + i.ToString("D2");
                            if (!db.Computers.Any(c => c.Code == code))
                            {
                                db.Computers.Add(new Computer { Code = code, RoomId = roomVip.Id, Tier = "VIP", Cpu = "Core i7", Ram = "32GB", Gpu = "RTX 3060", Storage = "SSD 512GB", Condition = "Tốt", Status = "Trống" });
                            }
                        }
                        hasChanges = true;
                    }
                }

                // Đảm bảo dữ liệu máy Hỏng và máy Đang dùng luôn tồn tại để test (trong trường hợp DB đã được tạo từ trước)
                var existingMay03 = db.Computers.FirstOrDefault(c => c.Code == "MAY-03");
                if (existingMay03 != null && existingMay03.Condition != "Hỏng")
                {
                    existingMay03.Condition = "Hỏng";
                    hasChanges = true;
                }

                var existingMay04 = db.Computers.FirstOrDefault(c => c.Code == "MAY-04");
                if (existingMay04 != null && existingMay04.Status != "Đang dùng")
                {
                    existingMay04.Status = "Đang dùng";
                    hasChanges = true;
                }

                if (existingMay04 != null && existingMay04.Status == "Đang dùng")
                {
                    var activeSession = db.Sessions.FirstOrDefault(s => s.ComputerId == existingMay04.Id && s.EndTime == null);
                    if (activeSession == null)
                    {
                        var customer = db.Customers.FirstOrDefault();
                        var adminUser = db.Users.FirstOrDefault(u => u.Role == "Admin");
                        if (customer != null && adminUser != null)
                        {
                            db.Sessions.Add(new Session
                            {
                                ComputerId = existingMay04.Id,
                                OpenedByUserId = adminUser.Id,
                                CustomerId = customer.Id,
                                PricePerHour = 10000,
                                StartTime = DateTime.Now.AddHours(-1.5),
                                Status = "Active"
                            });
                            hasChanges = true;
                        }
                    }
                }
                if (hasChanges)
                {
                    db.SaveChanges();
                    hasChanges = false;
                }

                // Tự động thêm dữ liệu giá máy cho bất kỳ máy nào chưa có để tránh lỗi 0đ/h
                var allComputers = db.Computers.ToList();
                foreach (var c in allComputers)
                {
                    if (!db.ComputerPrices.Any(p => p.ComputerId == c.Id))
                    {
                        decimal price = c.Tier == "VIP" ? 15000 : 10000;
                        db.ComputerPrices.Add(new ComputerPrice
                        {
                            ComputerId = c.Id,
                            PricePerHour = price,
                            EffectiveFrom = DateTime.Now.AddDays(-10),
                            IsCurrent = true
                        });
                        hasChanges = true;
                    }
                }

                if (hasChanges)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}
