USE QuanLyNhaHang
GO

-- Search procedure: tìm kiếm một đối tượng dựa theo khóa chính
CREATE PROCEDURE spSearchNhanVien(@maNhanVien CHAR(10))
AS BEGIN
    SELECT *
	FROM dbo.NhanVien
	WHERE @maNhanVien = maNhanVien
END
GO

CREATE PROCEDURE spSearchBan(@maBan CHAR(10))
AS BEGIN
    SELECT *
	FROM dbo.Ban
	WHERE maBan = @maBan
END
GO

CREATE PROCEDURE spSearchHoaDon(@maHoaDon CHAR(10))
AS BEGIN
    SELECT *
	FROM dbo.HoaDon
	WHERE maHoaDon = @maHoaDon
END
GO

CREATE PROCEDURE spSearchMonAn(@maMonAn CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.MonAn
	   WHERE maMonAn = @maMonAn
   END
GO

CREATE PROCEDURE spSearchCoupon(@maCoupon CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.Coupon
	   WHERE maCoupon = @maCoupon
   END
GO

CREATE PROCEDURE spSearchKhachHang(@maKhachHang CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.KhachHang
	   WHERE maKhachHang = @maKhachHang
   END
GO

CREATE PROCEDURE spSearchDatTruoc(@maDatTruoc CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.DatTruoc
	   WHERE maDatTruoc = @maDatTruoc
   END
GO

CREATE PROCEDURE spSearchCaTruc(@maCaTruc CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.CaTruc
	   WHERE maCaTruc = @maCaTruc
   END
GO

CREATE PROCEDURE spSearchTaiKhoan(@tenDangNhap VARCHAR(50))
AS BEGIN
       SELECT *
	   FROM dbo.TaiKhoan
	   WHERE tenDangNhap = @tenDangNhap
   END
GO

CREATE PROCEDURE spSearchDangKyCaTruc(@maNhanVien CHAR(10), @maCatruc CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.DangKyCaTruc
	   WHERE maNhanVien = @maNhanVien AND maCaTruc = @maCatruc
   END
GO

CREATE PROCEDURE spSearchLuong(@maNhanVien CHAR(10), @maCaTruc CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.Luong
	   WHERE maNhanVien = @maNhanVien AND maCaTruc = @maCaTruc
   END
GO

CREATE PROCEDURE spSearchChiTietHoaDon(@maHoaDon CHAR(10), @maMonAn CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.ChiTietHoaDon
	   WHERE maHoaDon = @maHoaDon AND maMonAn = @maMonAn
   END
GO

-- Test search procedure
EXEC dbo.spSearchNhanVien @maNhanVien = 'NV110001' -- char(10)
EXEC dbo.spSearchBan @maBan = 'BT201' -- char(10)
EXEC dbo.spSearchCaTruc @maCaTruc = 'CT1002' -- char(10)
EXEC dbo.spSearchChiTietHoaDon @maHoaDon = 'HD0001', -- char(10)
                               @maMonAn = '10007'   -- char(10)
EXEC dbo.spSearchCoupon @maCoupon = 'CP20' -- char(10)
EXEC dbo.spSearchDangKyCaTruc @maNhanVien = 'NV220111', -- char(10)
                              @maCatruc = 'CT1003'    -- char(10)
EXEC dbo.spSearchDatTruoc @maDatTruoc = 'DT01' -- char(10)
EXEC dbo.spSearchHoaDon @maHoaDon = 'HD0001' -- char(10)
EXEC dbo.spSearchKhachHang @maKhachHang = 'KH03' -- char(10)
EXEC dbo.spSearchLuong @maNhanVien = 'NV220111', -- char(10)
                       @maCaTruc = 'CT1001'    -- char(10)
EXEC dbo.spSearchMonAn @maMonAn = '10007' -- char(10)
EXEC dbo.spSearchTaiKhoan @tenDangNhap = 'anhtranthienpv102' -- char(10)