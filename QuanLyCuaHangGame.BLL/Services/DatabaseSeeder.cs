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
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("12345678a"),
                        Role = "Admin",
                        IsActive = true
                    });
                    db.Users.Add(new User
                    {
                        FullName = "Nhân viên 1",
                        Username = "staff1",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("12345678a"),
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

                    // 4. Seed Computers
                    for (int i = 1; i <= 5; i++)
                    {
                        db.Computers.Add(new Computer { Code = "MAY-" + i.ToString("D2"), RoomId = roomThuong.Id, Tier = "Thường", Cpu = "Core i5", Ram = "16GB", Gpu = "GTX 1650", Storage = "SSD 256GB", Condition = "Tốt", Status = "Trống" });
                    }
                    for (int i = 1; i <= 3; i++)
                    {
                        db.Computers.Add(new Computer { Code = "VIP-" + i.ToString("D2"), RoomId = roomVip.Id, Tier = "VIP", Cpu = "Core i7", Ram = "32GB", Gpu = "RTX 3060", Storage = "SSD 512GB", Condition = "Tốt", Status = "Trống" });
                    }
                    hasChanges = true;
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

                if (hasChanges)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}
