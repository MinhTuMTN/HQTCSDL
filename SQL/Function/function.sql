USE QuanLyNhaHang
GO

CREATE FUNCTION fnTinhLuong(@maNhanVien CHAR(10), @maCaTruc CHAR(10))
RETURNS FLOAT AS
BEGIN
    DECLARE @soNgayCuaCaTruc INT
	DECLARE @soNgayNghi INT
	DECLARE @heSoLuong FLOAT

	SELECT @soNgayCuaCaTruc = DATEDIFF(day,ngayBatDau,ngayKetThuc) + 1 
	FROM dbo.CaTruc 
	WHERE maCaTruc = @maCaTruc

	SELECT @soNgayNghi = soNgayNghi FROM dbo.Luong
	WHERE maNhanVien = @maNhanVien AND maCaTruc = @maCaTruc

	SELECT @heSoLuong = heSoLuong FROM dbo.NhanVien
	WHERE maNhanVien = @maNhanVien

	RETURN (@soNgayCuaCaTruc - @soNgayNghi)*@heSoLuong
END
GO

CREATE TRIGGER triggerUpdateLuong ON dbo.Luong
FOR INSERT, UPDATE AS
BEGIN
    DECLARE @maNhanVien CHAR(10)
	DECLARE @maCaTruc CHAR(10)

	SELECT @maNhanVien = ins.maNhanVien, @maCaTruc = ins.maCaTruc FROM Inserted ins

	UPDATE dbo.Luong 
	SET tongLuong = dbo.fnTinhLuong(@maNhanVien, @maCaTruc)
	WHERE maNhanVien = @maNhanVien AND maCaTruc = @maCaTruc
END


CREATE FUNCTION fnGiaTienMonAn(@maMonAn CHAR(10))
RETURNS FLOAT AS
BEGIN
    DECLARE @result FLOAT
	SELECT @result = giaTien FROM dbo.MonAn
	WHERE maMonAn = @maMonAn

	RETURN @result
END
GO


--Bao gồm món ăn + phụ thu
CREATE FUNCTION fnTinhTamThu(@maDonHang CHAR(10))
RETURNS FLOAT AS
BEGIN
    DECLARE @tong FLOAT
	SET @tong = 0

	SELECT @tong = @tong + dbo.fnGiaTienMonAn(CT.maMonAn) * CT.soLuong 
	FROM dbo.ChiTietDonHang CT
	WHERE maDonHang = @maDonHang

	SELECT @tong = @tong + phuThu
	FROM dbo.DonHang
	WHERE maDonHang = @maDonHang

	RETURN @tong
END
GO


CREATE TRIGGER triggerApDungCoupon ON dbo.DonHang
FOR INSERT, UPDATE AS
BEGIN
    DECLARE @maDonHang CHAR(10)
	DECLARE @maCoupon CHAR(10)

	SELECT @maDonHang=maDonHang, @maCoupon=maCoupon FROM Inserted
	IF(@maCoupon IS NULL)
		RETURN

	DECLARE @donToiThieu FLOAT
	SELECT @donToiThieu = donToiThieu FROM dbo.Coupon
	WHERE maCoupon = @maCoupon

	DECLARE @giaTriDon FLOAT
	SELECT @giaTriDon = dbo.fnTinhTamThu(@maDonHang)

	IF (@giaTriDon >= @donToiThieu)
		RETURN
	ELSE
		UPDATE dbo.DonHang SET maCoupon = NULL WHERE maDonHang = @maDonHang
END
GO

CREATE FUNCTION fnTinhTienGiam(@maDonHang CHAR(10))
RETURNS FLOAT AS
BEGIN
	DECLARE @maCoupon CHAR(10)
	DECLARE @donToiThieu FLOAT 
	DECLARE @giamToiDa FLOAT
	DECLARE @phanTramGiam FLOAT
	DECLARE @tienTamTinh FLOAT

	SELECT @maCoupon = maCoupon FROM dbo.DonHang
	WHERE maDonHang = @maDonHang

	IF(@maCoupon IS NULL)
		RETURN 0

	SELECT @donToiThieu = donToiThieu, @giamToiDa = giamToiDa, @phanTramGiam = phanTramGiam 
	FROM dbo.Coupon
	WHERE maCoupon = @maCoupon

	SELECT @tienTamTinh = dbo.fnTinhTamThu(@maDonHang)

	IF(@tienTamTinh < @donToiThieu)
		RETURN 0

	IF(@giamToiDa < (@tienTamTinh * @phanTramGiam))
		RETURN @giamToiDa
	RETURN @tienTamTinh * @phanTramGiam
END
GO

CREATE FUNCTION fnTinhTienDonHang(@maDonHang CHAR(10))
RETURNS FLOAT AS
BEGIN
    RETURN dbo.fnTinhTamThu(@maDonHang) - dbo.fnTinhTienGiam(@maDonHang)
END
GO
