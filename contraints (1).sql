USE QuanLyNhaHang
GO

ALTER TABLE	dbo.Coupon ADD CONSTRAINT check_phanTramGiam CHECK (phanTramGiam >= 0 AND phanTramGiam <= 1);
ALTER TABLE dbo.Coupon ADD CONSTRAINT check_soTienGiamToiDa CHECK (soTienGiamToiDa > 0)
ALTER TABLE dbo.Coupon ADD CONSTRAINT check_soTienToiThieu CHECK (soTienToiThieu > 0)
ALTER TABLE dbo.Coupon ADD CONSTRAINT check_ngayBatDauKetThuc CHECK (ngayBatDau < ngayKetThuc)
GO

CREATE FUNCTION dbo.checkLoaiNhanVien (@nhanVienId CHAR(10))
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @nhanVien NVARCHAR(20)
	SELECT @nhanVien = loaiNhanVien FROM dbo.NhanVien WHERE maNhanVien = @nhanVienId
	RETURN @nhanVien
END;
GO

CREATE FUNCTION dbo.tinhTuoi (@ngaySinh DATE)
RETURNS INT
AS
BEGIN
	DECLARE @tuoi INT
	SELECT @tuoi = ROUND(DATEDIFF(DAY, @ngaySinh, GETDATE())/365,0)
	RETURN @tuoi
END
GO

ALTER TABLE dbo.DonHang ADD CONSTRAINT check_nhanVienPhucVu CHECK (dbo.checkLoaiNhanVien(maNhanVienPhucVu) = N'Phục vụ');
ALTER TABLE dbo.DonHang ADD CONSTRAINT check_nhanVienThuNgan CHECK (dbo.checkLoaiNhanVien(maNhanVienThuNgan) = N'Thu ngân');
ALTER TABLE dbo.DonHang ADD CONSTRAINT check_nhanVienDauBep CHECK (dbo.checkLoaiNhanVien(maDauBep) = N'Đầu bếp');
GO

ALTER TABLE dbo.DatTruoc ADD CONSTRAINT check_nhanVienTiepNhan CHECK (dbo.checkLoaiNhanVien(maNhanVienTiepNhan) = N'Thu ngân');
ALTER TABLE dbo.DatTruoc ADD CONSTRAINT check_soLuongNguoi CHECK (soLuongNguoi > 0)
ALTER TABLE dbo.DatTruoc ADD CONSTRAINT check_thoiGianCheckinDatTruoc CHECK (thoiGianDatTruoc < thoiGianCheckIn)
GO

ALTER TABLE dbo.NhanVien ADD CONSTRAINT check_heSoLuong CHECK (heSoLuong > 0);
ALTER TABLE dbo.NhanVien ADD CONSTRAINT check_soDienThoai CHECK (soDienThoai LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');
ALTER TABLE dbo.NhanVien ADD CONSTRAINT check_tuoi CHECK (dbo.tinhTuoi(ngaySinh) >= 18)
GO

ALTER TABLE dbo.Luong ADD CONSTRAINT check_soNgayNghi CHECK (soNgayNghi >= 0);
ALTER TABLE dbo.Luong ADD CONSTRAINT check_tongLuong CHECK (tongLuong >= 0);
GO

ALTER TABLE dbo.KhachHang ADD CONSTRAINT check_soDienThoaiKH CHECK (soDienThoai LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')

GO

ALTER TABLE dbo.Ban ADD CONSTRAINT check_soLuongGheToiDa CHECK (soLuongGheToiDa > 0)
GO

ALTER TABLE dbo.HoaDon ADD CONSTRAINT check_phuThu CHECK (phuThu >= 0)
ALTER TABLE dbo.HoaDon ADD CONSTRAINT check_thue CHECK (thue > 0)
ALTER TABLE dbo.HoaDon ADD CONSTRAINT check_soTienTamTinh CHECK (soTienTamTinh > 0)
GO

ALTER TABLE dbo.ChiTietHoaDon ADD CONSTRAINT check_soLuong CHECK (soLuong > 0)
GO

ALTER TABLE dbo.CongThucMonAn ADD CONSTRAINT check_soLuongMonAn CHECK (soLuong > 0)
GO

ALTER TABLE dbo.NguyenLieu ADD CONSTRAINT check_donGia CHECK (donGia > 0)
ALTER TABLE dbo.NguyenLieu ADD CONSTRAINT check_soLuongTon CHECK (soLuongTon >= 0)
GO

ALTER TABLE dbo.MonAn ADD CONSTRAINT check_giaTien CHECK (giaTien > 0)
GO

ALTER TABLE dbo.NhaCungCap ADD CONSTRAINT check_soDienThoaiNCC CHECK (soDienThoai LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
ALTER TABLE dbo.NhaCungCap ADD CONSTRAINT check_email CHECK (email LIKE '%@%.%' AND email NOT LIKE '@%' AND email NOT LIKE '%@%@%')
GO

ALTER TABLE dbo.ChiTieuNguyenLieu ADD CONSTRAINT check_soLuongNhap CHECK (soLuongNhap > 0)
ALTER TABLE dbo.ChiTieuNguyenLieu ADD CONSTRAINT check_tongTien CHECK (tongTien > 0)
ALTER TABLE dbo.ChiTieuNguyenLieu ADD CONSTRAINT check_ngayNhap CHECK (ngayNhap <= GETDATE())
GO

ALTER TABLE dbo.CaTruc ADD CONSTRAINT check_thoiGianCaTruc CHECK (ngayBatDau < ngayKetThuc)
GO

CREATE VIEW view_LuongNhanVien AS
	SELECT maNhanVien, CaTruc.maCaTruc, soNgayNghi, ngayBatDau, ngayKetThuc, tongLuong
	FROM dbo.Luong, dbo.CaTruc
	WHERE Luong.maCaTruc=CaTruc.maCaTruc
GO

CREATE VIEW view_CongThucMonAn AS
	SELECT tenMonAn, tenNguyenLieu, soLuong, donViTinh
	FROM dbo.CongThucMonAn, dbo.MonAn, dbo.NguyenLieu
	WHERE CongThucMonAn.maMonAn=MonAn.maMonAn AND CongThucMonAn.maNguyenLieu=NguyenLieu.maNguyenLieu
GO

