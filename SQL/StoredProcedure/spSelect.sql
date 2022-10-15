USE QuanLyNhaHang
GO

-- Select procedure: in ra toàn bộ bảng
CREATE PROCEDURE spSelectNhanVien
AS BEGIN
    SELECT *
	FROM dbo.NhanVien
END
GO

CREATE PROCEDURE spSelectBan
AS BEGIN
    SELECT *
	FROM dbo.Ban
END
GO

CREATE PROCEDURE spSelectDonHang
AS BEGIN
    SELECT *
	FROM dbo.DonHang
END
GO

CREATE PROCEDURE spSelectMonAn
AS BEGIN
       SELECT *
	   FROM dbo.MonAn
   END
GO

CREATE PROCEDURE spSelectCoupon
AS BEGIN
       SELECT *
	   FROM dbo.Coupon
   END
GO

CREATE PROCEDURE spSelectKhachHang
AS BEGIN
       SELECT *
	   FROM dbo.KhachHang
   END
GO

CREATE PROCEDURE spSelectDatTruoc
AS BEGIN
       SELECT *
	   FROM dbo.DatTruoc
   END
GO

CREATE PROCEDURE spSelectCaTruc
AS BEGIN
       SELECT *
	   FROM dbo.CaTruc
   END
GO

CREATE PROCEDURE spSelectTaiKhoan
AS BEGIN
       SELECT *
	   FROM dbo.TaiKhoan
   END
GO

CREATE PROCEDURE spSelectDangKyCaTruc
AS BEGIN
       SELECT *
	   FROM dbo.DangKyCaTruc
   END
GO

CREATE PROCEDURE spSelectLuong
AS BEGIN
       SELECT *
	   FROM dbo.Luong
   END
GO

CREATE PROCEDURE spSelectChiTietDonHang
AS BEGIN
       SELECT *
	   FROM dbo.ChiTietDonHang
   END
GO

-- Test select procedure
EXEC dbo.spSelectNhanVien
EXEC dbo.spSelectBan
EXEC dbo.spSelectCaTruc
EXEC dbo.spSelectChiTietDonHang
EXEC dbo.spSelectCoupon
EXEC dbo.spSelectDangKyCaTruc
EXEC dbo.spSelectDatTruoc
EXEC dbo.spSelectDonHang
EXEC dbo.spSelectKhachHang
EXEC dbo.spSelectLuong
EXEC dbo.spSelectMonAn
EXEC dbo.spSelectTaiKhoan