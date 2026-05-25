-- ============================================================
--  GameZone Pro — SQL Server Script
--  Tạo toàn bộ bảng + Dữ liệu mẫu
--  Ngôn ngữ: T-SQL (SQL Server 2019+)
--  Tác giả: Nhóm .NET — Năm học 2024-2025
-- ============================================================

USE master;
GO

-- Tạo database nếu chưa có
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GameZoneProDB')
BEGIN
    CREATE DATABASE GameZoneProDB
    COLLATE Vietnamese_CI_AS;
END
GO

USE GameZoneProDB;
GO

-- ============================================================
-- XÓA BẢNG CŨ (theo thứ tự FK)
-- ============================================================
IF OBJECT_ID('SpendTransactions', 'U') IS NOT NULL DROP TABLE SpendTransactions;
IF OBJECT_ID('Invoices',          'U') IS NOT NULL DROP TABLE Invoices;
IF OBJECT_ID('SessionServices',   'U') IS NOT NULL DROP TABLE SessionServices;
IF OBJECT_ID('Sessions',          'U') IS NOT NULL DROP TABLE Sessions;
IF OBJECT_ID('TopUpTransactions', 'U') IS NOT NULL DROP TABLE TopUpTransactions;
IF OBJECT_ID('ComputerPrices',    'U') IS NOT NULL DROP TABLE ComputerPrices;
IF OBJECT_ID('Computers',         'U') IS NOT NULL DROP TABLE Computers;
IF OBJECT_ID('ServiceItems',      'U') IS NOT NULL DROP TABLE ServiceItems;
IF OBJECT_ID('Customers',         'U') IS NOT NULL DROP TABLE Customers;
IF OBJECT_ID('Rooms',             'U') IS NOT NULL DROP TABLE Rooms;
IF OBJECT_ID('Users',             'U') IS NOT NULL DROP TABLE Users;
GO

-- ============================================================
-- 1. BẢNG Users — Tài khoản nội bộ (Admin & Staff)
-- ============================================================
CREATE TABLE Users (
    Id           INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FullName     NVARCHAR(100)  NOT NULL,
    Username     NVARCHAR(50)   NOT NULL,
    PasswordHash NVARCHAR(255)  NOT NULL,   -- BCrypt hash
    Role         NVARCHAR(20)   NOT NULL    -- 'Admin' | 'Staff'
                 CONSTRAINT CHK_Users_Role CHECK (Role IN ('Admin','Staff')),
    IsActive     BIT            NOT NULL DEFAULT 1,
    CreatedAt    DATETIME2(0)   NOT NULL DEFAULT GETDATE(),

    CONSTRAINT UQ_Users_Username UNIQUE (Username)
);
GO
PRINT 'Tạo bảng Users';

-- ============================================================
-- 2. BẢNG Customers — Tài khoản hội viên
-- ============================================================
CREATE TABLE Customers (
    Id           INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FullName     NVARCHAR(100)  NOT NULL,
    Phone        NVARCHAR(15)   NOT NULL,
    Username     NVARCHAR(50)   NOT NULL,
    PasswordHash NVARCHAR(255)  NOT NULL,   -- BCrypt hash
    PinCode      NVARCHAR(100)  NOT NULL,   -- SHA-256 hash của PIN 4 số
    Balance      DECIMAL(12,0)  NOT NULL DEFAULT 0,
    IsActive     BIT            NOT NULL DEFAULT 1,
    CreatedAt    DATETIME2(0)   NOT NULL DEFAULT GETDATE(),
    LastVisitAt  DATETIME2(0)   NULL,

    CONSTRAINT UQ_Customers_Phone    UNIQUE (Phone),
    CONSTRAINT UQ_Customers_Username UNIQUE (Username),
    CONSTRAINT CHK_Customers_Balance CHECK (Balance >= 0)
);
GO
PRINT 'Tạo bảng Customers';

-- ============================================================
-- 3. BẢNG Rooms — Phòng máy
-- ============================================================
CREATE TABLE Rooms (
    Id          INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(50)  NOT NULL,
    Floor       INT           NULL DEFAULT 1,
    Description NVARCHAR(200) NULL,
    IsActive    BIT           NOT NULL DEFAULT 1,

    CONSTRAINT UQ_Rooms_Name UNIQUE (Name)
);
GO
PRINT 'Tạo bảng Rooms';

-- ============================================================
-- 4. BẢNG Computers — Máy tính
-- ============================================================
CREATE TABLE Computers (
    Id        INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RoomId    INT           NOT NULL,
    Code      NVARCHAR(10)  NOT NULL,       -- 'PC01', 'VIP03'
    Tier      NVARCHAR(20)  NOT NULL        -- 'VIP' | 'Standard'
              CONSTRAINT CHK_Computers_Tier CHECK (Tier IN ('VIP','Standard')),
    Cpu       NVARCHAR(100) NULL,
    Gpu       NVARCHAR(100) NULL,
    Ram       NVARCHAR(50)  NULL,
    Storage   NVARCHAR(100) NULL,
    Condition NVARCHAR(20)  NOT NULL DEFAULT 'Tốt'
              CONSTRAINT CHK_Computers_Condition CHECK (Condition IN (N'Tốt',N'Hỏng',N'Đã sửa',N'Huỷ')),
    Status    NVARCHAR(20)  NOT NULL DEFAULT N'Trống'
              CONSTRAINT CHK_Computers_Status CHECK (Status IN (N'Trống',N'Đang dùng',N'Dừng')),
    CreatedAt DATETIME2(0)  NOT NULL DEFAULT GETDATE(),

    CONSTRAINT UQ_Computers_Code UNIQUE (Code),
    CONSTRAINT FK_Computers_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);
GO
PRINT 'Tạo bảng Computers';

-- ============================================================
-- 5. BẢNG ComputerPrices — Lịch sử giá thuê theo máy
-- ============================================================
CREATE TABLE ComputerPrices (
    Id            INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ComputerId    INT           NOT NULL,
    PricePerHour  DECIMAL(10,0) NOT NULL,
    EffectiveFrom DATETIME2(0)  NOT NULL DEFAULT GETDATE(),
    IsCurrent     BIT           NOT NULL DEFAULT 1,

    CONSTRAINT FK_ComputerPrices_Computers FOREIGN KEY (ComputerId)
        REFERENCES Computers(Id),
    CONSTRAINT CHK_ComputerPrices_Price CHECK (PricePerHour > 0)
);
GO
PRINT 'Tạo bảng ComputerPrices';

-- ============================================================
-- 6. BẢNG ServiceItems — Danh mục dịch vụ
-- ============================================================
CREATE TABLE ServiceItems (
    Id          INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL,
    Category    NVARCHAR(50)  NOT NULL,    -- 'Đồ uống' | 'Đồ ăn' | 'Game'
    Price       DECIMAL(10,0) NOT NULL,
    IsAvailable BIT           NOT NULL DEFAULT 1,

    CONSTRAINT CHK_ServiceItems_Price CHECK (Price > 0)
);
GO
PRINT 'Tạo bảng ServiceItems';

-- ============================================================
-- 7. BẢNG Sessions — Phiên thuê máy
-- ============================================================
CREATE TABLE Sessions (
    Id               INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ComputerId       INT           NOT NULL,
    OpenedByUserId   INT           NOT NULL,
    CustomerId       INT           NULL,          -- NULL = khách vãng lai
    GuestName        NVARCHAR(100) NULL,          -- Tên nếu vãng lai
    PricePerHour     DECIMAL(10,0) NOT NULL,      -- Snapshot giá khi mở
    StartTime        DATETIME2(0)  NOT NULL DEFAULT GETDATE(),
    EndTime          DATETIME2(0)  NULL,
    HoursUsed        DECIMAL(6,2)  NULL,
    Status           NVARCHAR(20)  NOT NULL DEFAULT 'Active'
                     CONSTRAINT CHK_Sessions_Status CHECK (Status IN ('Active','Closed','Cancelled')),

    CONSTRAINT FK_Sessions_Computers  FOREIGN KEY (ComputerId)     REFERENCES Computers(Id),
    CONSTRAINT FK_Sessions_Users      FOREIGN KEY (OpenedByUserId) REFERENCES Users(Id),
    CONSTRAINT FK_Sessions_Customers  FOREIGN KEY (CustomerId)     REFERENCES Customers(Id),
    CONSTRAINT CHK_Sessions_Guest     CHECK (
        (CustomerId IS NOT NULL) OR (GuestName IS NOT NULL)
    )
);
GO
PRINT 'Tạo bảng Sessions';

-- ============================================================
-- 8. BẢNG SessionServices — Dịch vụ phát sinh trong phiên
-- ============================================================
CREATE TABLE SessionServices (
    Id            INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SessionId     INT           NOT NULL,
    ServiceItemId INT           NOT NULL,
    Quantity      INT           NOT NULL DEFAULT 1,
    UnitPrice     DECIMAL(10,0) NOT NULL,     -- Snapshot giá khi gọi
    OrderedAt     DATETIME2(0)  NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_SessionServices_Sessions     FOREIGN KEY (SessionId)     REFERENCES Sessions(Id),
    CONSTRAINT FK_SessionServices_ServiceItems FOREIGN KEY (ServiceItemId) REFERENCES ServiceItems(Id),
    CONSTRAINT CHK_SessionServices_Qty         CHECK (Quantity > 0)
);
GO
PRINT 'Tạo bảng SessionServices';

-- ============================================================
-- 9. BẢNG Invoices — Hóa đơn thanh toán
-- ============================================================
CREATE TABLE Invoices (
    Id              INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SessionId       INT           NOT NULL,
    ClosedByUserId  INT           NOT NULL,
    SessionAmount   DECIMAL(12,0) NOT NULL DEFAULT 0,
    ServiceAmount   DECIMAL(12,0) NOT NULL DEFAULT 0,
    TotalAmount     DECIMAL(12,0) NOT NULL DEFAULT 0,
    PaidByBalance   DECIMAL(12,0) NOT NULL DEFAULT 0,
    PaidByCash      DECIMAL(12,0) NOT NULL DEFAULT 0,
    ChangeGiven     DECIMAL(12,0) NOT NULL DEFAULT 0,
    PaidAt          DATETIME2(0)  NOT NULL DEFAULT GETDATE(),

    CONSTRAINT UQ_Invoices_SessionId    UNIQUE (SessionId),
    CONSTRAINT FK_Invoices_Sessions     FOREIGN KEY (SessionId)      REFERENCES Sessions(Id),
    CONSTRAINT FK_Invoices_Users        FOREIGN KEY (ClosedByUserId) REFERENCES Users(Id),
    CONSTRAINT CHK_Invoices_PaidSum     CHECK (PaidByBalance + PaidByCash >= TotalAmount - 1) -- dung sai 1đ
);
GO
PRINT 'Tạo bảng Invoices';

-- ============================================================
-- 10. BẢNG TopUpTransactions — Lịch sử nạp tiền
-- ============================================================
CREATE TABLE TopUpTransactions (
    Id                INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CustomerId        INT           NOT NULL,
    ProcessedByUserId INT           NOT NULL,
    Amount            DECIMAL(12,0) NOT NULL,
    Note              NVARCHAR(200) NULL,
    CreatedAt         DATETIME2(0)  NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_TopUp_Customers FOREIGN KEY (CustomerId)        REFERENCES Customers(Id),
    CONSTRAINT FK_TopUp_Users     FOREIGN KEY (ProcessedByUserId) REFERENCES Users(Id),
    CONSTRAINT CHK_TopUp_Amount   CHECK (Amount > 0)
);
GO
PRINT 'Tạo bảng TopUpTransactions';

-- ============================================================
-- 11. BẢNG SpendTransactions — Lịch sử chi tiêu từ ví
-- ============================================================
CREATE TABLE SpendTransactions (
    Id          INT           NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CustomerId  INT           NOT NULL,
    InvoiceId   INT           NOT NULL,
    Amount      DECIMAL(12,0) NOT NULL,
    Description NVARCHAR(200) NULL,
    CreatedAt   DATETIME2(0)  NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Spend_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    CONSTRAINT FK_Spend_Invoices  FOREIGN KEY (InvoiceId)  REFERENCES Invoices(Id),
    CONSTRAINT CHK_Spend_Amount   CHECK (Amount > 0)
);
GO
PRINT 'Tạo bảng SpendTransactions';

-- ============================================================
-- INDEX — Tăng tốc các truy vấn thường xuyên
-- ============================================================
CREATE INDEX IX_Customers_Phone       ON Customers(Phone);
CREATE INDEX IX_Customers_Username    ON Customers(Username);
CREATE INDEX IX_Sessions_ComputerId   ON Sessions(ComputerId, Status);
CREATE INDEX IX_Sessions_CustomerId   ON Sessions(CustomerId);
CREATE INDEX IX_Sessions_StartTime    ON Sessions(StartTime);
CREATE INDEX IX_Invoices_PaidAt       ON Invoices(PaidAt);
CREATE INDEX IX_TopUp_CustomerId      ON TopUpTransactions(CustomerId);
CREATE INDEX IX_Spend_CustomerId      ON SpendTransactions(CustomerId);
CREATE INDEX IX_ComputerPrices_Curr   ON ComputerPrices(ComputerId, IsCurrent);
GO
PRINT 'Tạo xong tất cả INDEX';

-- ============================================================
-- ============================================================
-- SEED DATA — DỮ LIỆU MẪU
-- ============================================================
-- ============================================================
PRINT '';
PRINT '========================================';
PRINT 'BẮT ĐẦU CHÈN DỮ LIỆU MẪU...';
PRINT '========================================';

-- ============================================================
-- USERS (mật khẩu gốc: Admin@123456 và Staff@123456)
-- Hash BCrypt được sinh sẵn — work factor 12
-- ============================================================
INSERT INTO Users (FullName, Username, PasswordHash, Role, IsActive, CreatedAt) VALUES
(N'Admin Hệ thống',    'admin',   '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', 'Admin', 1, '2024-01-01 08:00:00'),
(N'Nguyễn Văn Nam',   'nvnam',   '$2a$12$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'Staff', 1, '2024-03-15 08:00:00'),
(N'Trần Thị Hương',   'tthg',    '$2a$12$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'Staff', 1, '2024-06-20 08:00:00'),
(N'Lê Minh Tuấn',     'lmtuan',  '$2a$12$92IXUNpkjO0rOQ5byMi.Ye4oKoEa3Ro9llC/.og/at2.uheWG/igi', 'Staff', 0, '2024-09-10 08:00:00');
GO
PRINT 'Seed Users (4 tài khoản: 1 Admin, 3 Staff, 1 bị khoá)';

-- ============================================================
-- ROOMS
-- ============================================================
INSERT INTO Rooms (Name, Floor, Description, IsActive) VALUES
(N'Phòng A',   1, N'Phòng chính tầng 1 — 12 máy Standard',     1),
(N'Phòng VIP', 1, N'Phòng VIP tầng 1 — 6 máy cấu hình cao',   1),
(N'Phòng B',   2, N'Phòng tầng 2 — 8 máy Standard',            1),
(N'Phòng Mới', 2, N'Đang trang bị — chưa đưa vào hoạt động',   0);
GO
PRINT 'Seed Rooms (4 phòng, 1 chưa hoạt động)';

-- ============================================================
-- COMPUTERS
-- Phòng A (RoomId=1): PC01–PC12 Standard
-- Phòng VIP (RoomId=2): VIP01–VIP06
-- Phòng B (RoomId=3): PC13–PC20
-- ============================================================

-- Phòng A — Standard
INSERT INTO Computers (RoomId, Code, Tier, Cpu, Gpu, Ram, Storage, Condition, Status, CreatedAt) VALUES
(1, 'PC01', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Đang dùng', '2024-01-10 09:00:00'),
(1, 'PC02', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Trống',     '2024-01-10 09:00:00'),
(1, 'PC03', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Đang dùng', '2024-01-10 09:00:00'),
(1, 'PC04', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Trống',     '2024-01-10 09:00:00'),
(1, 'PC05', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Đang dùng', '2024-01-10 09:00:00'),
(1, 'PC06', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Hỏng',    N'Dừng',      '2024-01-10 09:00:00'),
(1, 'PC07', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Đã sửa',  N'Trống',     '2024-01-10 09:00:00'),
(1, 'PC08', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Trống',     '2024-01-10 09:00:00'),
(1, 'PC09', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Đang dùng', '2024-01-10 09:00:00'),
(1, 'PC10', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Trống',     '2024-01-10 09:00:00'),
(1, 'PC11', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Tốt',     N'Trống',     '2024-01-10 09:00:00'),
(1, 'PC12', 'Standard', N'Intel Core i5-13400F', N'NVIDIA GTX 1660 Super', N'16GB DDR4', N'512GB SSD', N'Huỷ',     N'Dừng',      '2024-01-10 09:00:00');

-- Phòng VIP (RoomId=2)
INSERT INTO Computers (RoomId, Code, Tier, Cpu, Gpu, Ram, Storage, Condition, Status, CreatedAt) VALUES
(2, 'VIP01', 'VIP', N'Intel Core i9-13900K', N'NVIDIA RTX 4070',    N'32GB DDR5', N'1TB NVMe SSD', N'Tốt',   N'Đang dùng', '2024-02-01 09:00:00'),
(2, 'VIP02', 'VIP', N'Intel Core i9-13900K', N'NVIDIA RTX 4070',    N'32GB DDR5', N'1TB NVMe SSD', N'Tốt',   N'Trống',     '2024-02-01 09:00:00'),
(2, 'VIP03', 'VIP', N'Intel Core i9-13900K', N'NVIDIA RTX 4080',    N'32GB DDR5', N'2TB NVMe SSD', N'Tốt',   N'Đang dùng', '2024-02-01 09:00:00'),
(2, 'VIP04', 'VIP', N'Intel Core i9-13900K', N'NVIDIA RTX 4080',    N'32GB DDR5', N'2TB NVMe SSD', N'Tốt',   N'Trống',     '2024-02-01 09:00:00'),
(2, 'VIP05', 'VIP', N'AMD Ryzen 9 7950X',    N'NVIDIA RTX 4090',    N'64GB DDR5', N'2TB NVMe SSD', N'Tốt',   N'Trống',     '2024-02-01 09:00:00'),
(2, 'VIP06', 'VIP', N'AMD Ryzen 9 7950X',    N'NVIDIA RTX 4090',    N'64GB DDR5', N'2TB NVMe SSD', N'Hỏng',  N'Dừng',      '2024-02-01 09:00:00');

-- Phòng B (RoomId=3)
INSERT INTO Computers (RoomId, Code, Tier, Cpu, Gpu, Ram, Storage, Condition, Status, CreatedAt) VALUES
(3, 'PC13', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Tốt',   N'Trống',     '2024-04-01 09:00:00'),
(3, 'PC14', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Tốt',   N'Đang dùng', '2024-04-01 09:00:00'),
(3, 'PC15', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Tốt',   N'Trống',     '2024-04-01 09:00:00'),
(3, 'PC16', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Tốt',   N'Trống',     '2024-04-01 09:00:00'),
(3, 'PC17', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Đã sửa',N'Trống',     '2024-04-01 09:00:00'),
(3, 'PC18', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Tốt',   N'Trống',     '2024-04-01 09:00:00'),
(3, 'PC19', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Tốt',   N'Đang dùng', '2024-04-01 09:00:00'),
(3, 'PC20', 'Standard', N'Intel Core i7-13700F', N'NVIDIA RTX 3060', N'16GB DDR4', N'512GB SSD', N'Tốt',   N'Trống',     '2024-04-01 09:00:00');
GO
PRINT 'Seed Computers (20 máy: 12 Standard phòng A, 6 VIP, 8 Standard phòng B)';

-- ============================================================
-- COMPUTER PRICES
-- Standard: 20,000đ/h   VIP Basic: 30,000đ/h   VIP Pro: 40,000đ/h
-- ============================================================
-- Standard (PC01–PC12, PC13–PC20)
INSERT INTO ComputerPrices (ComputerId, PricePerHour, EffectiveFrom, IsCurrent)
SELECT Id, 20000, '2024-01-10 00:00:00', 1
FROM Computers WHERE Tier = 'Standard';

-- VIP01, VIP02: 30,000đ/h (lịch sử: từ 25,000 → 30,000)
INSERT INTO ComputerPrices (ComputerId, PricePerHour, EffectiveFrom, IsCurrent) VALUES
(13, 25000, '2024-02-01 00:00:00', 0),
(13, 30000, '2024-05-01 00:00:00', 1),
(14, 25000, '2024-02-01 00:00:00', 0),
(14, 30000, '2024-05-01 00:00:00', 1),
(15, 40000, '2024-02-01 00:00:00', 1),  -- VIP03 RTX4080
(16, 40000, '2024-02-01 00:00:00', 1),  -- VIP04 RTX4080
(17, 50000, '2024-02-01 00:00:00', 1),  -- VIP05 RTX4090
(18, 50000, '2024-02-01 00:00:00', 1);  -- VIP06 RTX4090
GO
PRINT 'Seed ComputerPrices (có lịch sử thay đổi giá VIP01/VIP02)';

-- ============================================================
-- SERVICE ITEMS
-- ============================================================
INSERT INTO ServiceItems (Name, Category, Price, IsAvailable) VALUES
(N'Nước ngọt lon (Pepsi/Coca/7Up)', N'Đồ uống', 10000, 1),
(N'Nước tăng lực (Sting/Monster)',  N'Đồ uống', 15000, 1),
(N'Cà phê đen',                     N'Đồ uống', 15000, 1),
(N'Cà phê sữa / Bạc xỉu',          N'Đồ uống', 18000, 1),
(N'Trà sữa trân châu',              N'Đồ uống', 25000, 1),
(N'Nước suối chai',                 N'Đồ uống',  8000, 1),
(N'Snack Oishi / Poca',             N'Đồ ăn',   15000, 1),
(N'Mì ly Hảo Hảo / 3 Miền',        N'Đồ ăn',   20000, 1),
(N'Bánh mì que phô mai',            N'Đồ ăn',   20000, 1),
(N'Xúc xích nướng',                 N'Đồ ăn',   25000, 1),
(N'Combo nước + snack',             N'Đồ ăn',   22000, 1),
(N'Nạp thẻ game 50k',               N'Game',    50000, 1),
(N'Nạp thẻ game 100k',              N'Game',   100000, 1),
(N'Nạp thẻ game 200k',              N'Game',   200000, 1),
(N'Cáp sạc điện thoại (thuê)',       N'Khác',    10000, 1),
(N'Tai nghe Gaming (thuê)',          N'Khác',    20000, 0);  -- hết hàng
GO
PRINT 'Seed ServiceItems (16 dịch vụ, 1 hết hàng)';

-- ============================================================
-- CUSTOMERS
-- PasswordHash: BCrypt của 'Kh@ch123'
-- PinCode: SHA-256 của PIN (1234→'...', 5678→'...' v.v)
-- Dùng giá trị placeholder — ứng dụng sẽ hash thật khi đăng ký
-- ============================================================
INSERT INTO Customers (FullName, Phone, Username, PasswordHash, PinCode, Balance, IsActive, CreatedAt, LastVisitAt) VALUES
(N'Phạm Quốc Huy',   '0912345678', 'pqhuy',   '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 150000, 1, '2024-03-01 10:00:00', '2025-05-16 14:30:00'),
(N'Nguyễn Văn An',   '0987654321', 'nvana',   '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', 'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f', 85000,  1, '2024-04-10 09:00:00', '2025-05-16 15:10:00'),
(N'Trần Thị Hoa',    '0901234567', 'tthoa',   '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 12000,  1, '2024-05-20 14:00:00', '2025-05-15 16:00:00'),
(N'Lê Minh Hoàng',   '0908765432', 'lmhoang', '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0,      1, '2024-06-01 11:00:00', '2025-05-12 13:00:00'),
(N'Võ Thị Mai',      '0935678901', 'vtmai',   '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', 'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f', 200000, 1, '2024-07-15 08:00:00', '2025-05-16 13:55:00'),
(N'Đinh Quang Sáng', '0976543210', 'dqsang',  '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 350000, 1, '2024-08-20 10:00:00', '2025-05-16 10:00:00'),
(N'Bùi Thị Lan',     '0923456789', 'btlan',   '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 50000,  1, '2024-09-05 15:00:00', '2025-05-14 17:00:00'),
(N'Hoàng Văn Đức',   '0948123456', 'hvduc',   '$2a$12$LQv3c1yqBWVHxkd0LHAkCOYz6TtxMQJqhN8/LewEPu0jnO5PBfzXO', 'ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f', 0,      0, '2024-10-01 09:00:00', '2025-04-20 11:00:00'); -- bị khoá
GO
PRINT 'Seed Customers (8 hội viên, 1 bị khoá, số dư đa dạng)';

-- ============================================================
-- TOP-UP TRANSACTIONS — Lịch sử nạp tiền
-- ============================================================
INSERT INTO TopUpTransactions (CustomerId, ProcessedByUserId, Amount, Note, CreatedAt) VALUES
-- Phạm Quốc Huy (CustomerId=1)
(1, 2, 200000, N'Nạp tiền mặt tại quầy',        '2025-04-01 10:15:00'),
(1, 2, 100000, N'Nạp thẻ ATM qua nhân viên',     '2025-04-20 14:30:00'),
(1, 3, 150000, N'Nạp tiền mặt',                  '2025-05-10 09:00:00'),
-- Nguyễn Văn An (CustomerId=2)
(2, 2, 200000, N'Nạp tiền mặt tại quầy',         '2025-03-15 11:00:00'),
(2, 3, 100000, N'Khuyến mãi khai trương',         '2025-04-01 09:00:00'),
-- Trần Thị Hoa (CustomerId=3)
(3, 2, 100000, N'Nạp tiền mặt',                  '2025-05-01 10:00:00'),
-- Võ Thị Mai (CustomerId=5)
(5, 2, 300000, N'Nạp tiền mặt tại quầy',         '2025-05-01 08:30:00'),
(5, 2, 200000, N'Nạp tiền mặt',                  '2025-05-14 09:00:00'),
-- Đinh Quang Sáng (CustomerId=6)
(6, 3, 500000, N'Nạp tiền mặt',                  '2025-05-01 10:00:00'),
(6, 3, 200000, N'Nạp thẻ ATM',                   '2025-05-15 08:00:00'),
-- Bùi Thị Lan (CustomerId=7)
(7, 2, 200000, N'Nạp tiền mặt',                  '2025-05-10 11:00:00'),
-- Lê Minh Hoàng (CustomerId=4) — đã dùng hết
(4, 2, 100000, N'Nạp tiền mặt',                  '2025-05-01 09:00:00');
GO
PRINT 'Seed TopUpTransactions (12 lần nạp)';

-- ============================================================
-- SESSIONS — Phiên thuê máy đã đóng (lịch sử)
-- ============================================================
-- Session 1: Phạm Quốc Huy - VIP01 - 16/05 sáng (đã đóng)
INSERT INTO Sessions (ComputerId, OpenedByUserId, CustomerId, GuestName, PricePerHour, StartTime, EndTime, HoursUsed, Status) VALUES
(13, 2, 1, NULL, 30000, '2025-05-16 08:30:00', '2025-05-16 11:00:00', 2.50, 'Closed'),
-- Session 2: Nguyễn Văn An - PC05 - sáng (đã đóng)
(5,  2, 2, NULL, 20000, '2025-05-16 09:00:00', '2025-05-16 11:30:00', 2.50, 'Closed'),
-- Session 3: Khách vãng lai - PC04 - sáng (đã đóng)
(4,  3, NULL, N'Khách vãng lai Minh', 20000, '2025-05-16 09:30:00', '2025-05-16 12:00:00', 2.50, 'Closed'),
-- Session 4: Võ Thị Mai - VIP03 - sáng (đã đóng)
(15, 3, 5, NULL, 40000, '2025-05-16 10:00:00', '2025-05-16 13:55:00', 3.92, 'Closed'),
-- Session 5: Đinh Quang Sáng - PC13 - sáng (đã đóng)
(21, 2, 6, NULL, 20000, '2025-05-16 10:00:00', '2025-05-16 14:30:00', 4.50, 'Closed'),
-- Session 6: Lê Minh Hoàng - PC02 (đã đóng)
(2,  2, 4, NULL, 20000, '2025-05-16 08:00:00', '2025-05-16 13:00:00', 5.00, 'Closed');

-- Sessions đang chạy (Active) — tương ứng máy đang "Đang dùng"
-- Session 7: Phạm Quốc Huy - VIP01 - chiều nay (ĐANG CHẠY)
INSERT INTO Sessions (ComputerId, OpenedByUserId, CustomerId, GuestName, PricePerHour, StartTime, EndTime, HoursUsed, Status) VALUES
(13, 2, 1, NULL, 30000, '2025-05-16 14:30:00', NULL, NULL, 'Active'),
-- Session 8: Nguyễn Văn An - PC05 (ĐANG CHẠY)
(5,  3, 2, NULL, 20000, '2025-05-16 15:10:00', NULL, NULL, 'Active'),
-- Session 9: Võ Thị Mai - VIP03 (ĐANG CHẠY)
(15, 2, 5, NULL, 40000, '2025-05-16 13:55:00', NULL, NULL, 'Active'),
-- Session 10: Vãng lai - PC03 (ĐANG CHẠY)
(3,  3, NULL, N'Trần Minh Bình', 20000, '2025-05-16 15:10:00', NULL, NULL, 'Active'),
-- Session 11: Đinh Quang Sáng - PC09 (ĐANG CHẠY)
(9,  2, 6, NULL, 20000, '2025-05-16 10:00:00', NULL, NULL, 'Active'),
-- Session 12: Vãng lai - PC14 phòng B (ĐANG CHẠY)
(22, 3, NULL, N'Lê Anh Khoa', 20000, '2025-05-16 14:00:00', NULL, NULL, 'Active');
GO
PRINT 'Seed Sessions (6 đã đóng + 6 đang chạy)';

-- ============================================================
-- SESSION SERVICES — Dịch vụ trong các phiên đã đóng
-- ============================================================
INSERT INTO SessionServices (SessionId, ServiceItemId, Quantity, UnitPrice, OrderedAt) VALUES
-- Session 1 (Huy - VIP01 sáng)
(1, 1, 2, 10000, '2025-05-16 09:30:00'),  -- 2 nước ngọt
(1, 7, 1, 15000, '2025-05-16 10:00:00'),  -- 1 snack
-- Session 2 (An - PC05 sáng)
(2, 3, 1, 15000, '2025-05-16 10:00:00'),  -- 1 cà phê đen
-- Session 4 (Mai - VIP03 sáng)
(4, 4, 2, 18000, '2025-05-16 11:00:00'),  -- 2 cà phê sữa
(4, 8, 1, 20000, '2025-05-16 12:00:00'),  -- 1 mì ly
-- Session 5 (Sáng - PC13)
(5, 2, 3, 15000, '2025-05-16 11:00:00'),  -- 3 nước tăng lực
(5, 9, 1, 20000, '2025-05-16 12:00:00'),  -- 1 bánh mì
-- Session 8 hiện tại (An - PC05 chiều)
(8, 1, 1, 10000, '2025-05-16 15:45:00'),  -- 1 nước ngọt
-- Session 9 hiện tại (Mai - VIP03)
(9, 5, 1, 25000, '2025-05-16 14:30:00'),  -- 1 trà sữa
(9, 7, 2, 15000, '2025-05-16 15:00:00');  -- 2 snack
GO
PRINT 'Seed SessionServices (10 dòng dịch vụ)';

-- ============================================================
-- INVOICES — Hóa đơn cho các Session đã đóng
-- ============================================================
INSERT INTO Invoices (SessionId, ClosedByUserId, SessionAmount, ServiceAmount, TotalAmount, PaidByBalance, PaidByCash, ChangeGiven, PaidAt) VALUES
-- Session 1: Huy, 2.5h × 30k = 75k + dịch vụ (20k+15k=35k) = 110k, trừ ví
(1, 2, 75000,  35000, 110000, 110000, 0,     0, '2025-05-16 11:00:00'),
-- Session 2: An, 2.5h × 20k = 50k + 15k = 65k, trừ ví
(2, 2, 50000,  15000, 65000,  65000,  0,     0, '2025-05-16 11:30:00'),
-- Session 3: Vãng lai, 2.5h × 20k = 50k, tiền mặt
(3, 3, 50000,  0,     50000,  0,      50000, 0, '2025-05-16 12:00:00'),
-- Session 4: Mai, 3.92h × 40k ≈ 157k + 36k+20k=56k = 213k, trừ ví
(4, 3, 157000, 56000, 213000, 213000, 0,     0, '2025-05-16 13:55:00'),
-- Session 5: Sáng, 4.5h × 20k = 90k + 65k = 155k, trừ ví
(5, 2, 90000,  65000, 155000, 155000, 0,     0, '2025-05-16 14:30:00'),
-- Session 6: Hoàng, 5h × 20k = 100k, ví 0 nên tiền mặt, khách đưa 110k
(6, 2, 100000, 0,     100000, 0,      110000, 10000, '2025-05-16 13:00:00');
GO
PRINT 'Seed Invoices (6 hóa đơn)';

-- ============================================================
-- SPEND TRANSACTIONS — Trừ ví sau thanh toán
-- ============================================================
INSERT INTO SpendTransactions (CustomerId, InvoiceId, Amount, Description, CreatedAt) VALUES
(1, 1, 110000, N'Thanh toán phiên VIP01 — 08:30→11:00',   '2025-05-16 11:00:00'),
(2, 2, 65000,  N'Thanh toán phiên PC05  — 09:00→11:30',   '2025-05-16 11:30:00'),
(5, 4, 213000, N'Thanh toán phiên VIP03 — 10:00→13:55',   '2025-05-16 13:55:00'),
(6, 5, 155000, N'Thanh toán phiên PC13  — 10:00→14:30',   '2025-05-16 14:30:00');
-- Session 3 (vãng lai) và Session 6 (Hoàng ví=0) không có SpendTransaction
GO
PRINT 'Seed SpendTransactions (4 giao dịch chi tiêu ví)';

-- ============================================================
-- KIỂM TRA DỮ LIỆU — VERIFY
-- ============================================================
PRINT '';
PRINT '========================================';
PRINT 'KIỂM TRA DỮ LIỆU SAU SEED:';
PRINT '========================================';

SELECT 'Users'              AS Bảng, COUNT(*) AS SốDòng FROM Users
UNION ALL
SELECT 'Customers',                  COUNT(*) FROM Customers
UNION ALL
SELECT 'Rooms',                      COUNT(*) FROM Rooms
UNION ALL
SELECT 'Computers',                  COUNT(*) FROM Computers
UNION ALL
SELECT 'ComputerPrices',             COUNT(*) FROM ComputerPrices
UNION ALL
SELECT 'ServiceItems',               COUNT(*) FROM ServiceItems
UNION ALL
SELECT 'Sessions',                   COUNT(*) FROM Sessions
UNION ALL
SELECT 'SessionServices',            COUNT(*) FROM SessionServices
UNION ALL
SELECT 'Invoices',                   COUNT(*) FROM Invoices
UNION ALL
SELECT 'TopUpTransactions',          COUNT(*) FROM TopUpTransactions
UNION ALL
SELECT 'SpendTransactions',          COUNT(*) FROM SpendTransactions;

-- Kiểm tra số dư hội viên (đối soát nhanh)
PRINT '';
PRINT 'Đối soát số dư hội viên:';
SELECT
    c.FullName,
    c.Balance                            AS [Balance_DB],
    ISNULL(SUM(t.Amount), 0)             AS [Tổng_Nạp],
    ISNULL(SUM(s.Amount), 0)             AS [Tổng_Chi],
    ISNULL(SUM(t.Amount),0)
        - ISNULL(SUM(s.Amount),0)        AS [Balance_Tính]
FROM Customers c
LEFT JOIN TopUpTransactions t ON t.CustomerId = c.Id
LEFT JOIN SpendTransactions s ON s.CustomerId = c.Id
GROUP BY c.Id, c.FullName, c.Balance
ORDER BY c.Id;

-- Máy đang dùng
PRINT '';
PRINT 'Máy đang chạy:';
SELECT
    co.Code      AS Máy,
    co.Tier      AS Hạng,
    ISNULL(cu.FullName, se.GuestName + N' (vãng lai)') AS Khách,
    se.StartTime AS [Giờ_Bắt_Đầu],
    cp.PricePerHour AS [Giá_H]
FROM Sessions se
JOIN Computers co     ON co.Id = se.ComputerId
JOIN ComputerPrices cp ON cp.ComputerId = co.Id AND cp.IsCurrent = 1
LEFT JOIN Customers cu ON cu.Id = se.CustomerId
WHERE se.Status = 'Active'
ORDER BY se.StartTime;

GO
PRINT '';
PRINT '========================================';
PRINT 'HOÀN TẤT! Database GameZoneProDB sẵn sàng.';
PRINT 'Tài khoản đăng nhập ứng dụng:';
PRINT '  Admin : admin   / Admin@123456';
PRINT '  Staff : nvnam   / Staff@123456';
PRINT '  Staff : tthg    / Staff@123456';
PRINT 'Hội viên mẫu:';
PRINT '  pqhuy  / PIN 1234 / Số dư: 150,000đ';
PRINT '  nvana  / PIN 5678 / Số dư:  85,000đ';
PRINT '  vtmai  / PIN 6789 / Số dư: 200,000đ';
PRINT '  dqsang / PIN 6789 / Số dư: 350,000đ';
PRINT '========================================';
GO
