IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TiemTapHoa')
BEGIN
    CREATE DATABASE TiemTapHoa;
END
GO

USE TiemTapHoa;
GO

IF OBJECT_ID(N'dbo.HangHoa', N'U') IS NOT NULL DROP TABLE dbo.HangHoa;
GO

CREATE TABLE HangHoa (
    MaHang INT IDENTITY(1,1) PRIMARY KEY,
    TenHang NVARCHAR(100) NOT NULL,
    LoaiHang NVARCHAR(50) NULL,
    DonVi NVARCHAR(20) NULL,
    GiaBan DECIMAL(18,0) NULL,
    SoLuongTon INT NULL,
    NgayNhap DATETIME NULL,
    ConKinhDoanh BIT NULL
);
GO

SET IDENTITY_INSERT HangHoa ON;
INSERT INTO HangHoa (MaHang, TenHang, LoaiHang, DonVi, GiaBan, SoLuongTon, NgayNhap, ConKinhDoanh) VALUES
(1, N'Nước suối Aquafina 500ml', N'Đồ uống', N'Chai', 6000, 120, '2026-10-02', 1),
(2, N'Mì Hảo Hảo tôm chua cay', N'Thực phẩm khô', N'Gói', 4500, 200, '2026-10-02', 1),
(3, N'Dầu ăn Tường An 1L', N'Gia vị', N'Chai', 48000, 35, '2026-10-05', 1),
(4, N'Bột giặt OMO 800g', N'Đồ gia dụng', N'Túi', 52000, 40, '2026-10-05', 1),
(5, N'Sữa tươi Vinamilk 1L', N'Đồ uống', N'Hộp', 32000, 60, '2026-10-08', 1),
(6, N'Nước mắm Nam Ngư 500ml', N'Gia vị', N'Chai', 38000, 25, '2026-10-01', 0);
SET IDENTITY_INSERT HangHoa OFF;
GO
