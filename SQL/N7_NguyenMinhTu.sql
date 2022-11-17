CREATE DATABASE QuanLyNhaHang
GO

USE QuanLyNhaHang
GO

-- Tạo bảng NhanVien chứa thông tin của các nhân viên làm việc ở nhà hàng
CREATE TABLE NhanVien
(
	maNhanVien CHAR(10) PRIMARY KEY,
	hoTen NVARCHAR(100),
	ngaySinh DATE,
	gioiTinh BIT,
	diaChi NVARCHAR(150),
	soDienThoai CHAR(10),
	heSoLuong FLOAT,
	loaiNhanVien NVARCHAR(20) 
)
GO
CREATE TABLE CaTruc
(
	maCaTruc CHAR(10) PRIMARY KEY,
	ngayBatDau DATE,
	ngayKetThuc DATE
)
GO
CREATE TABLE DangKyCaTruc 
(
	maNhanVien CHAR(10) FOREIGN KEY REFERENCES dbo.NhanVien(maNhanVien),
	maCaTruc CHAR(10) FOREIGN KEY REFERENCES dbo.CaTruc(maCaTruc),
	PRIMARY KEY (maNhanVien,maCaTruc)
)
CREATE TABLE TaiKhoan
(
	tenDangNhap VARCHAR(50) PRIMARY KEY,
	matKhau VARCHAR(50),
	trangThaiTaiKhoan NVARCHAR(20),
	maNhanVien CHAR(10) FOREIGN KEY REFERENCES dbo.NhanVien(maNhanVien)
)
GO
CREATE TABLE Luong 
(
	maNhanVien CHAR(10) REFERENCES dbo.NhanVien(maNhanVien),
	maCaTruc CHAR(10) REFERENCES dbo.CaTruc(maCaTruc),
	soNgayNghi INT,
	tongLuong FLOAT,
	PRIMARY KEY(maNhanVien,maCaTruc)
)
GO
CREATE TABLE KhachHang 
(
	maKhachHang CHAR(10) PRIMARY KEY,
	hoTen NVARCHAR(150),
	soDienThoai CHAR(10),
	ngaySinh DATE,
	gioiTinh BIT
)
GO
CREATE TABLE Ban
(
	maBan CHAR(10) PRIMARY KEY,
	trangThaiBan NVARCHAR(50),
	loaiBan NVARCHAR(20),
	soLuongGheToiDa INT
)
GO
CREATE TABLE DatTruoc
(
	maDatTruoc CHAR(10) PRIMARY KEY,
	trangThaiDatTruoc NVARCHAR(20),
	thoiGianCheckIn DATETIME,
	thoiGianDatTruoc DATETIME,
	soLuongNguoi INT,
	maKhachHang CHAR(10) REFERENCES dbo.KhachHang(maKhachHang),
	maBan CHAR(10) REFERENCES dbo.Ban(maBan),
	maNhanVienTiepNhan CHAR(10) REFERENCES dbo.NhanVien(maNhanVien)
)
GO
CREATE TABLE Coupon
(
	maCoupon CHAR(10) PRIMARY KEY,
	ngayBatDau DATE,
	ngayKetThuc DATE,
	phanTramGiam FLOAT,
	giamToiDa FLOAT,
	donToiThieu FLOAT
)
GO
CREATE TABLE DonHang
(
	maDonHang CHAR(10) PRIMARY KEY,
	thoiGianCheckIn DATETIME,
	phuThu FLOAT,
	maCoupon CHAR(10) REFERENCES dbo.Coupon(maCoupon),
	soTienThanhToan FLOAT,
	trangThaiDonHang NVARCHAR(50),
	maBan CHAR(10) REFERENCES dbo.Ban(maBan),
	maKhachHang CHAR(10) REFERENCES dbo.KhachHang(maKhachHang),
	maDauBep CHAR(10) REFERENCES dbo.NhanVien(maNhanVien),
	maNhanVienPhucVu CHAR(10) REFERENCES dbo.NhanVien(maNhanVien),
	maNhanVienThuNgan CHAR(10) REFERENCES dbo.NhanVien(maNhanVien)
)
GO
CREATE TABLE MonAn
(
	maMonAn CHAR(10) PRIMARY KEY,
	tenMonAn NVARCHAR(150),
	giaTien FLOAT,
	hinhAnh VARCHAR(150)
)
GO
CREATE TABLE ChiTietDonHang
(
	maDonHang CHAR(10) REFERENCES dbo.DonHang(maDonHang),
	maMonAn CHAR(10) REFERENCES dbo.MonAn(maMonAn),
	soLuong INT,
	PRIMARY KEY(maDonHang,maMonAn)
)
GO


-- Thêm Constraint
ALTER TABLE	dbo.Coupon ADD CONSTRAINT check_phanTramGiam CHECK (phanTramGiam >= 0 AND phanTramGiam <= 1);
ALTER TABLE dbo.Coupon ADD CONSTRAINT check_soTienGiamToiDa CHECK (giamToiDa >= 0)
ALTER TABLE dbo.Coupon ADD CONSTRAINT check_soTienToiThieu CHECK (donToiThieu >= 0)
ALTER TABLE dbo.Coupon ADD CONSTRAINT check_ngayBatDauKetThuc CHECK (ngayBatDau <= ngayKetThuc)
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

ALTER TABLE dbo.DonHang ADD CONSTRAINT check_phuThu CHECK (phuThu >= 0)
ALTER TABLE dbo.DonHang ADD CONSTRAINT check_soTienThanhToan CHECK (soTienThanhToan >= 0)
GO

ALTER TABLE dbo.ChiTietDonHang ADD CONSTRAINT check_soLuong CHECK (soLuong > 0)
GO

ALTER TABLE dbo.MonAn ADD CONSTRAINT check_giaTien CHECK (giaTien > 0)
GO

ALTER TABLE dbo.CaTruc ADD CONSTRAINT check_thoiGianCaTruc CHECK (ngayBatDau <= ngayKetThuc)
GO

-- Tạo trigger
CREATE TRIGGER trigger_giaTien ON dbo.MonAn
FOR INSERT, UPDATE
AS
DECLARE @new FLOAT
SELECT @new=ne.giaTien FROM Inserted ne
IF (@new<0)
BEGIN
	PRINT(N'Giá tiền phải lớn hơn 0')
	ROLLBACK;
END
GO

CREATE TRIGGER trigger_soLuongChiTietDonHang ON dbo.ChiTietDonHang
FOR INSERT, UPDATE
AS
DECLARE @new FLOAT
SELECT @new=ne.soLuong FROM Inserted ne
IF (@new<0)
BEGIN
	PRINT(N'Số lượng phải lớn hơn 0')
	ROLLBACK;
END
GO

-- Chèn dữ liệu mẫu

use QuanLyNhaHang
go

-- Store Procedure insert dữ liệu
CREATE PROCEDURE spInsertBan(@maBan char(10), @trangThaiBan nvarchar(50), @loaiBan nvarchar(20), @soLuongGheToiDa int)
AS BEGIN
		INSERT INTO dbo.Ban
		VALUES (@maBan, @trangThaiBan, @loaiBan, @soLuongGheToiDa)
	END
GO

CREATE PROCEDURE spInsertCaTruc(@maCaTruc char(10), @ngayBatDau date, @ngayKetThuc date)
AS BEGIN
		INSERT INTO dbo.CaTruc
		VALUES (@maCaTruc, @ngayBatDau, @ngayKetThuc)
	END
GO

CREATE PROCEDURE spInsertChiTietDonHang(@maDonHang char(10), @maMonAn char(10), @soLuong int)
AS BEGIN
		INSERT INTO dbo.ChiTietDonHang 
		VALUES (@maDonHang, @maMonAn, @soLuong)
	END
GO

CREATE PROCEDURE spInsertCoupon(@maCoupon char(10), @ngayBatDau date, @ngayKetThuc date, @phanTramGiam float, @giamToiDa float, @donToiThieu float)
AS BEGIN
		INSERT INTO dbo.Coupon 
		VALUES (@maCoupon, @ngayBatDau, @ngayKetThuc, @phanTramGiam, @giamToiDa, @donToiThieu)
	END
GO

CREATE PROCEDURE spInsertDangKyCaTruc(@maNhanVien char(10), @maCaTruc char(10))
AS BEGIN
		INSERT INTO dbo.DangKyCaTruc
		VALUES (@maNhanVien , @maCaTruc)
	END
GO

CREATE PROCEDURE spInsertDatTruoc(@maDatTruoc char(10), @trangThaiDatTruoc nvarchar(20), @thoiGianCheckIn datetime, @thoiGianDatTruoc datetime, @soLuongNguoi int, @maKhachHang char(10), @maBan char(10), @maNhanVienTiepNhan char(10))
AS BEGIN
		INSERT INTO dbo.DatTruoc
		VALUES (@maDatTruoc, @trangThaiDatTruoc, @thoiGianCheckIn, @thoiGianDatTruoc, @soLuongNguoi, @maKhachHang, @maBan, @maNhanVienTiepNhan)
	END
GO

CREATE PROCEDURE spInsertDonHang(@maDonHang char(10), @thoiGianCheckIn datetime, @phuThu float, @maBan char(10), @maKhachHang char(10), @maDauBep char(10), @maNhanVienPhucVu char(10))
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		IF(@maDonHang is NULL OR @maBan is NULL OR @maKhachHang is NULL OR @maDauBep is NULL OR @maNhanVienPhucVu is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		INSERT INTO dbo.DonHang
		(
			maDonHang,
			thoiGianCheckIn,
			phuThu,
			maCoupon,
			soTienThanhToan,
			trangThaiDonHang,
			maBan,
			maKhachHang,
			maDauBep,
			maNhanVienPhucVu,
			maNhanVienThuNgan
		)
		VALUES
		(   @maDonHang,        -- maDonHang - char(10)
			@thoiGianCheckIn, -- thoiGianCheckIn - datetime
			@phuThu,       -- phuThu - float
			NULL,        -- maCoupon - char(10)
			0.0,       -- soTienThanhToan - float
			N'Đang chuẩn bị',       -- trangThaiDonHang - nvarchar(50)
			@maBan,        -- maBan - char(10)
			@maKhachHang,        -- maKhachHang - char(10)
			@maDauBep,        -- maDauBep - char(10)
			@maNhanVienPhucVu,        -- maNhanVienPhucVu - char(10)
			NULL         -- maNhanVienThuNgan - char(10)
			)

		UPDATE dbo.Ban SET trangThaiBan=N'đang phục vụ'
		WHERE maBan=@maBan

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK;
		THROW
	END CATCH
END
GO

CREATE PROCEDURE spInsertKhachHang(@maKhachHang char(10))
AS BEGIN
		INSERT INTO dbo.KhachHang
		VALUES (@maKhachHang, null, null, null, null)
	END
GO

CREATE PROCEDURE spInsertLuong @maNhanVien char(10), @maCaTruc char(10), @soNgayNghi int, @tongLuong float
AS BEGIN
		INSERT INTO dbo.Luong
		VALUES (@maNhanVien, @maCaTruc, @soNgayNghi, @tongLuong)
	END
GO

CREATE PROCEDURE spInsertMonAn @maMonAn char(10), @tenMonAn nvarchar(150), @giaTien float, @hinhAnh varchar(150)
AS BEGIN
		INSERT INTO dbo.MonAn
		VALUES (@maMonAn, @tenMonAn, @giaTien, @hinhAnh)
	END
GO

CREATE PROCEDURE spInsertNhanVien(@ma char(10), @ten nvarchar(100), @ngaysinh date, @gioitinh bit, @diachi nvarchar(100), @SDT CHAR(10), @heSoLuong float, @loaiNhanVien nvarchar(20))
AS BEGIN
		INSERT INTO dbo.NhanVien
		VALUES (@ma,@ten,@ngaysinh,@gioitinh,@diachi,@SDT,@heSoLuong,@loaiNhanVien)
	END
GO

CREATE PROCEDURE spInsertTaiKhoan(@tenDangNhap varchar(50), @matKhau varchar(50), @trangThaiTaiKhoan nvarchar(20), @maNhanVien char(10))
AS BEGIN
		INSERT INTO dbo.TaiKhoan
		VALUES (@tenDangNhap, @matKhau, @trangThaiTaiKhoan, @maNhanVien)


	END
GO

-- Stored Procedure tìm kiếm
-- Search procedure: tìm kiếm một đối tượng dựa theo khóa chính
CREATE PROCEDURE spSearchNhanVien(@text CHAR(10))
AS BEGIN
    SELECT *
	FROM dbo.NhanVien
	WHERE hoTen LIKE @text OR maNhanVien LIKE @text
END
GO

CREATE PROCEDURE spSearchBan(@maBan CHAR(10))
AS BEGIN
    SELECT *
	FROM dbo.Ban
	WHERE maBan = @maBan
END
GO

CREATE PROCEDURE spSearchDonHang(@maDonHang CHAR(10))
AS BEGIN
    SELECT *
	FROM dbo.DonHang
	WHERE maDonHang = @maDonHang
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

CREATE PROCEDURE spSearchChiTietDonHang(@maDonHang CHAR(10), @maMonAn CHAR(10))
AS BEGIN
       SELECT *
	   FROM dbo.ChiTietDonHang
	   WHERE maDonHang = @maDonHang AND maMonAn = @maMonAn
   END
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

-- Store Procedure Update
CREATE PROC spUpdateNhanVien (
	@maNhanVien CHAR(10),
    @hoTen NVARCHAR(100),
    @ngaySinh DATE,
    @gioiTinh BIT,
    @diaChi NVARCHAR(150),
    @soDienThoai CHAR(10),
    @heSoLuong FLOAT,
    @loaiNhanVien NVARCHAR(20)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		IF(@hoTen is NULL OR @ngaySinh is NULL OR @gioiTinh is NULL OR @diaChi is NULL OR @soDienThoai is NULL OR @heSoLuong is NULL OR @loaiNhanVien is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		UPDATE dbo.NhanVien SET hoTen=@hoTen, ngaySinh=@ngaySinh, gioiTinh=@gioiTinh, diaChi=@diaChi,soDienThoai=@soDienThoai, heSoLuong=@heSoLuong, loaiNhanVien=@loaiNhanVien
		WHERE maNhanVien=@maNhanVien

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK;
		THROW
	END CATCH
END
GO

CREATE PROC spUpdateCaTruc (
	@maCaTruc CHAR(10),
	@ngayBatDau DATE,
	@ngayKetThuc DATE
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		IF(@ngayBatDau is NULL OR @ngayKetThuc is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		UPDATE dbo.CaTruc SET ngayBatDau=@ngayBatDau, ngayKetThuc=@ngayKetThuc 
		WHERE maCaTruc=@maCaTruc

		 COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK;
		THROW
	 END CATCH
END
GO

CREATE PROC spUpdateTaiKhoan(
	@tenDangNhap VARCHAR(50),
	@matKhau VARCHAR(50),
	@trangThaiTaiKhoan NVARCHAR(20)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		IF(@matKhau is NULL OR @trangThaiTaiKhoan is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		UPDATE dbo.TaiKhoan SET matKhau=@matKhau, trangThaiTaiKhoan=@trangThaiTaiKhoan 
		WHERE tenDangNhap=@tenDangNhap

		 COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK;
		THROW
	 END CATCH
END
GO


CREATE PROC spUpdateKhachHang (
	@maKhachHang CHAR(10),
	@hoTen NVARCHAR(150),
	@soDienThoai CHAR(10),
	@ngaySinh DATE,
	@gioiTinh BIT
)
AS
BEGIN
    UPDATE dbo.KhachHang SET hoTen=@hoTen, soDienThoai=@soDienThoai, ngaySinh=@ngaySinh, gioiTinh=@gioiTinh
	WHERE maKhachHang=@maKhachHang

END
GO

CREATE PROC spUpdateBan (
	@maBan CHAR(10),
	@trangThaiBan NVARCHAR(50),
	@loaiBan NVARCHAR(20),
	@soLuongGheToiDa INT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		IF(@trangThaiBan is NULL OR @loaiBan is NULL OR @soLuongGheToiDa is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		UPDATE dbo.Ban SET trangThaiBan=@trangThaiBan, loaiBan=@loaiBan, soLuongGheToiDa=@soLuongGheToiDa
		WHERE maBan=@maBan

		COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK;
		THROW
	 END CATCH
END
GO

CREATE PROC spUpdateDatTruoc(
	@maDatTruoc CHAR(10),
	@trangThaiDatTruoc NVARCHAR(20),
	@thoiGianCheckIn DATETIME,
	@thoiGianDatTruoc DATETIME,
	@soLuongNguoi INT,
	@maKhachHang CHAR(10),
	@maBan CHAR(10),
	@maNhanVienTiepNhan CHAR(10)
)
AS
BEGIN
    UPDATE dbo.DatTruoc SET trangThaiDatTruoc=@trangThaiDatTruoc, thoiGianCheckIn=@thoiGianCheckIn, thoiGianDatTruoc=@thoiGianDatTruoc, soLuongNguoi=@soLuongNguoi, maKhachHang=@maKhachHang, maBan=@maBan, maNhanVienTiepNhan=@maNhanVienTiepNhan
	WHERE maDatTruoc=@maDatTruoc
END
GO

CREATE PROC spUpdateCoupon(
	@maCoupon CHAR(10),
	@ngayBatDau DATE,
	@ngayKetThuc DATE,
	@phanTramGiam FLOAT,
	@giamToiDa FLOAT,
	@donToiThieu FLOAT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		IF(@ngayBatDau is NULL OR @ngayKetThuc is NULL OR @phanTramGiam is NULL OR @giamToiDa is NULL OR @donToiThieu is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		UPDATE dbo.Coupon SET ngayBatDau=@ngayBatDau, ngayKetThuc=@ngayKetThuc, phanTramGiam=@phanTramGiam, giamToiDa=@giamToiDa, donToiThieu=@donToiThieu
		WHERE maCoupon=@maCoupon

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK
		THROW
	END CATCH
END
GO

CREATE PROC spUpdateDonHang(
	@maDonHang CHAR(10),
	@thoiGianCheckIn DATETIME,
	@phuThu FLOAT,
	@maCoupon CHAR(10),
	@maBan CHAR(10),
	@maKhachHang CHAR(10),
	@maDauBep CHAR(10),
	@maNhanVienPhucVu CHAR(10),
	@maNhanVienThuNgan CHAR(10)
)
AS
BEGIN
    UPDATE dbo.DonHang SET thoiGianCheckIn=@thoiGianCheckIn, phuThu=@phuThu, maCoupon=@maCoupon, maBan=@maBan, maKhachHang=@maKhachHang, maNhanVienPhucVu=@maNhanVienPhucVu, maDauBep=@maDauBep, maNhanVienThuNgan=@maNhanVienThuNgan
	WHERE maDonHang=@maDonHang

END
GO

CREATE PROC spUpdateMonAn(
	@maMonAn CHAR(10),
	@tenMonAn NVARCHAR(150),
	@giaTien FLOAT,
	@hinhAnh VARCHAR(150)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		IF(@tenMonAn is NULL OR @giaTien is NULL OR @hinhAnh is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		UPDATE dbo.MonAn SET tenMonAn=@tenMonAn, giaTien=@giaTien, hinhAnh=@hinhAnh
		WHERE maMonAn=@maMonAn

		 COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK;
		THROW
	 END CATCH
END
GO

CREATE PROC spUpdateChiTietDonHang(
	@maDonHang CHAR(10),
	@maMonAn CHAR(10),
	@soLuong INT
)
AS
BEGIN
    UPDATE dbo.ChiTietDonHang SET soLuong=@soLuong
	WHERE maDonHang=@maDonHang AND maMonAn=@maMonAn
END
GO

CREATE PROCEDURE spUpdateTrangThaiDonHang (@maDonHang CHAR(10))
AS
BEGIN
	UPDATE dbo.DonHang SET trangThaiDonHang = N'Chưa thanh toán'
	WHERE maDonHang = @maDonHang
END
GO

-- Tạo views
CREATE VIEW viewNhanVienDangKyCaTruc -- Thông tin các nhân viên đăng ký các ca trực
AS SELECT NhanVien.maNhanVien, CaTruc.maCaTruc, hoTen, ngaySinh, gioiTinh, diaChi, soDienThoai, heSoLuong, loaiNhanVien
FROM dbo.NhanVien, dbo.DangKyCaTruc, dbo.CaTruc
WHERE DangKyCaTruc.maNhanVien = NhanVien.maNhanVien AND CaTruc.maCaTruc = DangKyCaTruc.maCaTruc
GO

CREATE VIEW viewMonAnDuocPhucVu -- Thông tin các món ăn được phục vụ
AS SELECT maKhachHang, hinhAnh, tenMonAn, soLuong, maCoupon, maBan, maDauBep, maNhanVienPhucVu, maNhanVienThuNgan, thoiGianCheckIn
FROM dbo.MonAn, dbo.ChiTietDonHang, dbo.DonHang
WHERE ChiTietDonHang.maDonHang = DonHang.maDonHang AND ChiTietDonHang.maMonAn = MonAn.maMonAn
GO

CREATE VIEW viewLuongNhanVien -- Thông tin về lương của các nhân viên
AS SELECT CaTruc.maCaTruc, Luong.maNhanVien , hoTen, heSoLuong, loaiNhanVien, soNgayNghi, ngayBatDau, ngayKetThuc, tongLuong
FROM dbo.Luong, dbo.CaTruc, dbo.NhanVien
WHERE Luong.maCaTruc=CaTruc.maCaTruc AND NhanVien.maNhanVien = Luong.maNhanVien
GO

CREATE VIEW viewTaiKhoanNhanVien
AS SELECT TK.maNhanVien, NV.hoTen, TK.tenDangNhap, TK.trangThaiTaiKhoan FROM dbo.NhanVien NV, dbo.TaiKhoan TK
WHERE NV.maNhanVien = TK.maNhanVien
GO


-- Tạo các Function
CREATE FUNCTION fnSearchNhanVien(@text NVARCHAR(150))
RETURNS TABLE AS
RETURN(
	SELECT *
	FROM dbo.NhanVien
	WHERE maNhanVien LIKE  '%' + @text + '%' OR hoTen LIKE '%' + @text + '%'
)
GO

CREATE FUNCTION fnSearchKhachHang(@text NVARCHAR(150))
RETURNS TABLE AS
RETURN(
	SELECT * FROM dbo.KhachHang
	WHERE maKhachHang LIKE  '%' + @text + '%' OR hoTen LIKE '%' + @text + '%'
)
GO

CREATE FUNCTION fnSearchBan(@maBan NVARCHAR(10))
RETURNS TABLE AS
RETURN(
	SELECT * FROM dbo.Ban
	WHERE maBan LIKE '%' + @maBan + '%'
)
GO

CREATE FUNCTION fnSearchDonHangDauBep (@text NVARCHAR(150), @maDauBep CHAR(10))
RETURNS TABLE AS
RETURN (
	SELECT * FROM dbo.DonHang
	WHERE maDonHang LIKE  '%' + @text + '%' AND maDauBep = @maDauBep AND trangThaiDonHang = N'Đang chuẩn bị'
)
GO

CREATE FUNCTION fnSearchCouponByID(@maCoupon NVARCHAR(10))
RETURNS TABLE AS
RETURN(
	SELECT * FROM dbo.Coupon
	WHERE maCoupon LIKE '%' + @maCoupon + '%'
)
GO

CREATE FUNCTION fnSearchDonHang (@text NVARCHAR(150))
RETURNS TABLE AS
RETURN (
	SELECT * FROM dbo.DonHang
	WHERE maDonHang LIKE  '%' + @text + '%'
)
GO

CREATE FUNCTION fnSearchMonAnTrongDonHang (@text NVARCHAR(150), @maDonHang CHAR(10))
RETURNS TABLE AS
RETURN (
	SELECT ChiTietDonHang.maMonAn, tenMonAn, soLuong, giaTien, hinhAnh FROM dbo.ChiTietDonHang INNER JOIN dbo.MonAn ON maDonHang = @maDonHang AND ChiTietDonHang.maMonAn = MonAn.maMonAn
	WHERE ChiTietDonHang.maMonAn LIKE  '%' + @text + '%' OR tenMonAn LIKE '%' + @text + '%'
)
GO

CREATE FUNCTION fnSearchCouponByDate(@date DATE)
RETURNS TABLE AS
RETURN(
	SELECT * FROM dbo.Coupon
	WHERE @date >= ngayBatDau AND @date <= ngayKetThuc
)
GO

CREATE FUNCTION fnSearchTaiKhoan (@text NVARCHAR(150))
RETURNS TABLE AS
RETURN(
	SELECT * FROM dbo.viewTaiKhoanNhanVien
	WHERE maNhanVien LIKE  '%' + @text + '%' OR hoTen LIKE  '%' + @text + '%' OR tenDangNhap LIKE  '%' + @text + '%'
)
GO

CREATE FUNCTION fnSearchLuong(@maCaTruc CHAR(10), @date DATE, @hoTen NVARCHAR(100), @maNhanVien CHAR(10))
RETURNS TABLE AS
RETURN (
	SELECT * FROM dbo.viewLuongNhanVien
	WHERE (maCaTruc=@maCaTruc OR @maCaTruc IS NULL)
		AND ((@date >= ngayBatDau AND @date <= ngayKetThuc) OR @date IS NULL)
		AND (hoTen LIKE  '%' + @hoTen + '%' OR @hoTen IS NULL)
		AND (maNhanVien=@maNhanVien OR @maNhanVien IS NULL)
)
GO

CREATE FUNCTION fnLayDanhSachDonHangDauBep (@maDauBep CHAR(10))
RETURNS TABLE AS
RETURN (
	SELECT * FROM dbo.DonHang WHERE maDauBep = @maDauBep AND trangThaiDonHang = N'Đang chuẩn bị'
)
GO

CREATE FUNCTION fnTinhLuongTamTinh(@maNhanVien CHAR(10), @maCaTruc CHAR(10))
RETURNS FLOAT AS
BEGIN
    DECLARE @soNgayCuaCaTruc INT
	SELECT @soNgayCuaCaTruc = DATEDIFF(day,ngayBatDau,ngayKetThuc) + 1 
	FROM dbo.CaTruc 
	WHERE maCaTruc = @maCaTruc

	DECLARE @heSoLuong FLOAT
	SELECT @heSoLuong = heSoLuong FROM dbo.NhanVien
	WHERE maNhanVien = @maNhanVien

	RETURN @heSoLuong * @soNgayCuaCaTruc
END
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

	DECLARE @result FLOAT
	SET @result = (@soNgayCuaCaTruc - @soNgayNghi)*@heSoLuong
	RETURN @result
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
GO

-- Lấy giá tiền của một món ăn từ mã món ăn
CREATE FUNCTION fnGiaTienMonAn(@maMonAn CHAR(10))
RETURNS FLOAT AS
BEGIN
    DECLARE @result FLOAT
	SELECT @result = giaTien FROM dbo.MonAn
	WHERE maMonAn = @maMonAn

	RETURN @result
END
GO


--Bao gồm món ăn
CREATE FUNCTION fnTinhTamThu(@maDonHang CHAR(10))
RETURNS FLOAT AS
BEGIN
    DECLARE @tong FLOAT
	SET @tong = 0

	SELECT @tong = @tong + dbo.fnGiaTienMonAn(CT.maMonAn) * CT.soLuong 
	FROM dbo.ChiTietDonHang CT
	WHERE maDonHang = @maDonHang

	RETURN @tong
END
GO

-- Thực hiện tính toán tiền giảm khi mã coupon được cập nhật
CREATE FUNCTION fnTinhTienGiam(@maDonHang CHAR(10))
RETURNS FLOAT AS
BEGIN
	DECLARE @maCoupon CHAR(10)
	DECLARE @donToiThieu FLOAT 
	DECLARE @giamToiDa FLOAT
	DECLARE @phanTramGiam FLOAT
	DECLARE @tienTamTinh FLOAT

	--Lấy mã coupon đã cập nhật
	SELECT @maCoupon = maCoupon FROM dbo.DonHang
	WHERE maDonHang = @maDonHang

	-- Nếu là NULL thì trả về 0 và kết thúc
	IF(@maCoupon IS NULL)
		RETURN 0

	-- Lấy các chi tiết của Coupon để kiểm tra
	SELECT @donToiThieu = donToiThieu, @giamToiDa = giamToiDa, @phanTramGiam = phanTramGiam 
	FROM dbo.Coupon
	WHERE maCoupon = @maCoupon

	-- Lấy số tiền món ăn mà khách đã dùng
	SELECT @tienTamTinh = dbo.fnTinhTamThu(@maDonHang)

	-- Nếu số tiền đó không đáp ứng số tiền tối thiểu thì đơn không được giảm
	IF(@tienTamTinh < @donToiThieu)
		RETURN 0

	-- Nếu số tiền giảm vượt quá số tiền giảm tối đa thì trả về số tiền giảm tối đa
	IF(@giamToiDa < (@tienTamTinh * @phanTramGiam))
		RETURN @giamToiDa

	-- Ngược lại, trả về số tiền được giảm
	RETURN @tienTamTinh * @phanTramGiam
END
GO

-- Hàm thực hiện tính tổng của một đơn hàng
CREATE FUNCTION fnTinhTienDonHang(@maDonHang CHAR(10))
RETURNS FLOAT AS
BEGIN
	-- Lấy số tiền phụ thu của đơn hàng
	DECLARE @phuThu FLOAT
	SELECT @phuThu = phuThu FROM dbo.DonHang
	WHERE maDonHang = @maDonHang

	-- Tổng số tiền của một đơn hàng = Số tiền món ăn + Phụ thu - Số tiền đã được giảm
    RETURN dbo.fnTinhTamThu(@maDonHang) + @phuThu - dbo.fnTinhTienGiam(@maDonHang)
END
GO

-- Hàm thực hiện lấy giá tiền của một đơn hàng theo mã bàn
-- Tại một thời điểm một bàn chỉ có 1 hóa đơn chưa được thanh toán (nếu có)
CREATE FUNCTION fnTinhTienDonHangTheoMaBan(@maBan CHAR(10))
RETURNS FLOAT AS
BEGIN
    DECLARE @maDonHang CHAR(10)
	SELECT @maDonHang=maDonHang FROM dbo.DonHang
	WHERE maBan=@maBan AND trangThaiDonHang = N'Chưa thanh toán'

	RETURN dbo.fnTinhTienDonHang(@maDonHang)
END
GO


CREATE TRIGGER triggerApDungCoupon ON dbo.DonHang
FOR INSERT, UPDATE AS
BEGIN
    DECLARE @maDonHang CHAR(10)
	DECLARE @maCoupon CHAR(10)

	SELECT @maDonHang=maDonHang, @maCoupon=maCoupon FROM Inserted
	IF(@maCoupon IS NULL)
		UPDATE dbo.DonHang SET soTienThanhToan = dbo.fnTinhTienDonHang(@maDonHang) WHERE maDonHang = @maDonHang

	DECLARE @donToiThieu FLOAT
	DECLARE @ngayBatDau DATE
	DECLARE @ngayKetThuc DATE

	SELECT @donToiThieu = donToiThieu, @ngayBatDau = ngayBatDau, @ngayKetThuc = ngayKetThuc FROM dbo.Coupon
	WHERE maCoupon = @maCoupon

	DECLARE @giaTriDon FLOAT
	SELECT @giaTriDon = dbo.fnTinhTamThu(@maDonHang)

	IF (@giaTriDon >= @donToiThieu)
		    IF (CONVERT(DATE, GETDATE()) BETWEEN @ngayBatDau AND @ngayKetThuc)
				UPDATE dbo.DonHang SET soTienThanhToan = dbo.fnTinhTienDonHang(@maDonHang) WHERE maDonHang = @maDonHang
	ELSE
		UPDATE dbo.DonHang SET maCoupon = NULL WHERE maDonHang = @maDonHang
END
GO

CREATE TRIGGER triggerUpdateTongDonHang ON dbo.ChiTietDonHang
FOR INSERT, UPDATE AS
BEGIN
    DECLARE @maDonHang CHAR(10)

	SELECT @maDonHang = Ins.maDonHang FROM Inserted Ins

	UPDATE dbo.DonHang SET soTienThanhToan = dbo.fnTinhTienDonHang(@maDonHang) WHERE maDonHang = @maDonHang
END
GO

CREATE FUNCTION fnDetailLuong(@maNhanVien CHAR(10), @maCaTruc CHAR(10))
RETURNS TABLE AS
RETURN(
	SELECT v.*, (v.soNgayNghi * v.heSoLuong) biTru FROM dbo.viewLuongNhanVien v
	WHERE v.maNhanVien = @maNhanVien AND v.maCaTruc = @maCaTruc
)
GO 

CREATE FUNCTION fnThongKeLuong (@ngayBD DATE, @ngayKT DATE)
RETURNS TABLE AS
RETURN(
	SELECT * FROM dbo.viewLuongNhanVien
	WHERE ngayKetThuc BETWEEN @ngayBD AND @ngayKT
)
GO

CREATE FUNCTION fnThongKeDoanhThuTheoBan(@ngayBD DATE, @ngayKT DATE)
RETURNS TABLE AS
RETURN(
	SELECT maBan, SUM(soTienThanhToan) soTien FROM dbo.DonHang
	WHERE CONVERT(DATE, thoiGianCheckIn) BETWEEN @ngayBD AND @ngayKT
	GROUP BY maBan
)
GO

CREATE FUNCTION fnThongKeMonAnBanChay(@ngayBD DATE, @ngayKT DATE)
RETURNS TABLE AS
RETURN (
	SELECT TOP(1) MonAn.maMonAn, tenMonAn, hinhAnh, giaTien FROM dbo.MonAn, dbo.DonHang, dbo.ChiTietDonHang
	WHERE dbo.MonAn.maMonAn = dbo.ChiTietDonHang.maMonAn AND dbo.DonHang.maDonHang = dbo.ChiTietDonHang.maDonHang
		AND CONVERT(DATE, thoiGianCheckIn) BETWEEN  @ngayBD AND @ngayKT
	GROUP BY MonAn.maMonAn, tenMonAn, hinhAnh, MonAn.giaTien
	ORDER BY SUM(soLuong) DESC
)
GO

-- Hàm lấy tất cả các chi tiết hóa đơn dựa trên mã bàn
CREATE FUNCTION fnSearchChiTietHoaDonById(@maBan CHAR(10))
RETURNS TABLE AS
RETURN(
	SELECT MA.tenMonAn, CT.soLuong, MA.giaTien, CT.soLuong*MA.giaTien soTien FROM dbo.ChiTietDonHang CT, dbo.MonAn MA, dbo.DonHang DH
	WHERE CT.maDonHang = DH.maDonHang AND MA.maMonAn = CT.maMonAn
		AND DH.trangThaiDonHang = N'Chưa thanh toán' AND DH.maBan = @maBan
)
GO

-- Hàm lấy phụ thu từ đơn hàng dựa trên mã bàn
CREATE FUNCTION fnGetPhuThu(@maBan CHAR(10))
RETURNS FLOAT AS
BEGIN
	DECLARE @phuThu FLOAT

    SELECT @phuThu = phuThu FROM dbo.DonHang
	WHERE trangThaiDonHang = N'Chưa thanh toán' AND maBan = @maBan

	RETURN @phuThu
END
GO

-- SP thực hiện khi nhân viên thu ngân thực hiện ấn nút Thanh toán hóa đơn cho khách
CREATE PROCEDURE spThanhToan(@maBan CHAR(10), @maNhanVienThuNgan CHAR(10))
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		IF(@maBan is NULL OR @maNhanVienThuNgan is NULL)
		BEGIN
			ROLLBACK
			RAISERROR(N'Thông tin chứa giá trị NULL', 16, 1)
		END

		-- Tìm mã đơn hàng từ mã bàn
		 DECLARE @maDonHang CHAR(10)	 
		 SELECT @maDonHang = maDonHang FROM dbo.DonHang
		 WHERE maBan = @maBan AND trangThaiDonHang = N'Chưa thanh toán'

		 -- Cập nhật trạng thái đơn hàng thành Đã thanh toán
		 UPDATE dbo.DonHang SET maNhanVienThuNgan = @maNhanVienThuNgan, trangThaiDonHang = N'Đã thanh toán'
		 WHERE maDonHang = @maDonHang

		 -- Cập nhật trạng thái bàn từ Đang phục vụ chuyển sang Đang có sẵn
		 UPDATE dbo.Ban SET trangThaiBan = N'Đang có sẵn' WHERE maBan = @maBan

		 -- Nếu đó là khách đặt trước thì tìm và chuyển sang trạng thái Đã phục vụ
		 UPDATE dbo.DatTruoc SET trangThaiDatTruoc = N'Đã phục vụ'
		 WHERE maDatTruoc IN (SELECT maDatTruoc FROM dbo.DatTruoc
								WHERE maBan = @maBan AND trangThaiDatTruoc = N'Đã check-in')

		 COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH
		IF(@@TRANCOUNT > 0)
			ROLLBACK;
		THROW
	 END CATCH
   END
GO

-- SP áp dụng Coupon cho một bàn đang phục vụ
CREATE PROCEDURE spApDungCoupon(@maBan CHAR(10), @maCoupon CHAR(10))
AS BEGIN
	   -- Thưc hiện tìm mã đơn hàng từ mã bàn
       DECLARE @maDonHang CHAR(10)
	   SELECT @maDonHang = maDonHang FROM dbo.DonHang
	   WHERE maBan = @maBan AND trangThaiDonHang = N'Chưa thanh toán'

	   -- Cập nhật mã coupon cho đơn hàng đó
	   UPDATE dbo.DonHang SET maCoupon = @maCoupon WHERE maDonHang = @maDonHang
   END
GO

CREATE FUNCTION fnLayDanhSachTiepNhan()
RETURNS TABLE AS
RETURN(
	SELECT hoTen, soDienThoai, ngaySinh, thoiGianDatTruoc, soLuongNguoi, maBan, maDatTruoc FROM dbo.DatTruoc, dbo.KhachHang
	WHERE DatTruoc.maKhachHang = KhachHang.maKhachHang AND trangThaiDatTruoc = N'Chờ xác nhận'
	)
GO

CREATE FUNCTION fnLayDanhSachMonAnChuaCo (@maDonHang CHAR(10))
RETURNS TABLE AS
RETURN (
	SELECT maMonAn, tenMonAn FROM dbo.MonAn
	EXCEPT
	SELECT MonAn.maMonAn, tenMonAn FROM dbo.ChiTietDonHang INNER JOIN dbo.MonAn ON maDonHang = @maDonHang AND ChiTietDonHang.maMonAn = MonAn.maMonAn
)
GO

CREATE PROCEDURE spChapNhanDatTruoc(@maDatTruoc CHAR(10), @maNhanVien CHAR(10))
 AS BEGIN
        UPDATE dbo.DatTruoc SET trangThaiDatTruoc = N'Đã xác nhận', maNhanVienTiepNhan=@maNhanVien
		WHERE maDatTruoc = @maDatTruoc
    END
GO

CREATE PROCEDURE spTuChoiDatTruoc(@maDatTruoc CHAR(10), @maNhanVien CHAR(10))
AS
	BEGIN
		DECLARE @maBan CHAR(10)
		SELECT @maBan = maBan FROM dbo.DatTruoc 
		WHERE maDatTruoc = @maDatTruoc AND trangThaiDatTruoc = N'Chờ xác nhận'

		UPDATE dbo.DatTruoc SET trangThaiDatTruoc = N'Từ chối', maNhanVienTiepNhan=@maNhanVien
		WHERE maDatTruoc = @maDatTruoc

		UPDATE dbo.Ban SET trangThaiBan = N'Đang có sẵn'
		WHERE maBan=@maBan
	END
GO

CREATE PROCEDURE spGetNhanVienByTaiKhoan(@tenDangNhap varchar(50), @matKhau varchar(50))
AS
BEGIN
    SELECT N.maNhanVien, N.loaiNhanVien FROM dbo.NhanVien N, dbo.TaiKhoan T
	WHERE N.maNhanVien = T.maNhanVien AND T.tenDangNhap = @tenDangNhap AND T.matKhau = @matKhau
END
GO

CREATE FUNCTION fnTaoMaKhachHang(@soDienThoai CHAR(10))
RETURNS @result TABLE(maKhachHang CHAR(10), khachHangMoi BIT) AS
BEGIN
    DECLARE @maKhachHang CHAR(10)
	DECLARE @khachHangMoi BIT

	SET @khachHangMoi = 0
	SELECT @maKhachHang=maKhachHang FROM dbo.KhachHang WHERE soDienThoai=@soDienThoai

	IF(@maKhachHang IS NULL)
		BEGIN
			SET @khachHangMoi = 1

			DECLARE @maKHMoiNhat CHAR(10)
			SELECT TOP(1) @maKHMoiNhat=maKhachHang
			FROM dbo.KhachHang
			ORDER BY CONVERT(INT, SUBSTRING(maKhachHang, 3, LEN(maKhachHang) - 2)) DESC

			SELECT @maKhachHang='KH' + CONVERT(CHAR(8), (CONVERT(INT, SUBSTRING(@maKHMoiNhat, 3, LEN(@maKHMoiNhat) - 2)) + 1))
		END

	INSERT INTO @result
	(
	    maKhachHang,
	    khachHangMoi
	)
	VALUES
	(   @maKhachHang,  -- maKhachHang - char(10)
	    @khachHangMoi -- khachHangMoi - bit
	    )
	RETURN 
END
GO

CREATE PROCEDURE spTaoDatTruoc(@trangThaiDatTruoc nvarchar(20),
								@thoiGianCheckIn DATETIME,
								@thoiGianDatTruoc DATETIME,
								@soLuongNguoi INT,
								@maKhachHang  char(10),
								@maBan char(10),
								@maNhanVienTiepNhan char(10))
AS
BEGIN
    DECLARE @maDatTruocTao CHAR(10)
	DECLARE @maDatTruocMoiNhat CHAR(10)
	SELECT TOP(1) @maDatTruocMoiNhat=maDatTruoc
	FROM dbo.DatTruoc
	ORDER BY CONVERT(INT, SUBSTRING(maDatTruoc, 3, LEN(maDatTruoc) - 2)) DESC

	--DT11
	SET @maDatTruocTao='DT' + CONVERT(CHAR(8), (CONVERT(INT, SUBSTRING(@maDatTruocMoiNhat, 3, LEN(@maDatTruocMoiNhat) - 2)) + 1))

	EXEC dbo.spInsertDatTruoc @maDatTruoc = @maDatTruocTao,                          -- char(10)
	                          @trangThaiDatTruoc = @trangThaiDatTruoc,                  -- nvarchar(20)
	                          @thoiGianCheckIn = @thoiGianCheckIn,  -- datetime
	                          @thoiGianDatTruoc = @trangThaiDatTruoc, -- datetime
	                          @soLuongNguoi = @soLuongNguoi,                         -- int
	                          @maKhachHang = @maKhachHang,                         -- char(10)
	                          @maBan = @maBan,                               -- char(10)
	                          @maNhanVienTiepNhan = @maNhanVienTiepNhan                   -- char(10)
	
	UPDATE dbo.Ban SET trangThaiBan=N'Đang chờ' WHERE maBan=@maBan	
END
GO

--- Thực hiện phân quyền
EXEC sys.sp_addrole @rolename = 'QuanLyRole'
EXEC sys.sp_addrole @rolename = 'NhanVienRole'
EXEC sys.sp_addrole @rolename = 'ThuNganRole'
EXEC sys.sp_addrole @rolename = 'PhucVuRole'
EXEC sys.sp_addrole @rolename = 'KhachHangRole'
GO

-- Khách hàng chỉ có thể tạo các đơn đặt trước
GRANT EXECUTE ON dbo.spTaoDatTruoc TO KhachHangRole
GO

-- Quản lý có toàn quyền(truy vấn) tất cả đối tượng trong CSDL
GRANT EXECUTE, INSERT, SELECT, UPDATE, DELETE ON Database::QuanLyNhaHang TO QuanLyRole
GO

-- Cấp các quyền truy cập cần thiết cho Thu Ngân
GRANT SELECT ON dbo.fnSearchChiTietHoaDonById TO ThuNganRole
GRANT EXECUTE ON dbo.fnGetPhuThu TO ThuNganRole
GRANT SELECT ON dbo.Coupon TO ThuNganRole
GRANT EXECUTE ON dbo.spApDungCoupon TO ThuNganRole
GRANT EXECUTE ON dbo.spThanhToan TO ThuNganRole
GRANT EXECUTE ON dbo.fnTinhTienDonHangTheoMaBan TO ThuNganRole
GRANT SELECT ON dbo.fnLayDanhSachTiepNhan TO ThuNganRole
GRANT EXECUTE ON dbo.spChapNhanDatTruoc TO ThuNganRole
GRANT EXECUTE ON dbo.spTuChoiDatTruoc TO ThuNganRole
GO

-- Quyền của toàn bộ nhân viên
GRANT EXECUTE ON dbo.spGetNhanVienByTaiKhoan TO NhanVienRole
GO

CREATE TRIGGER trigger_CreateUserDb ON dbo.TaiKhoan
FOR INSERT AS
BEGIN
    DECLARE @tenDangNhap VARCHAR(50)
	DECLARE @matKhau VARCHAR(50)
	DECLARE @maNhanVien CHAR(10)
	DECLARE @loaiNhanVien NVARCHAR(20)

	SELECT @tenDangNhap=Ins.tenDangNhap, @matKhau=Ins.matKhau, @maNhanVien=Ins.maNhanVien FROM Inserted Ins

	SELECT @loaiNhanVien=N.loaiNhanVien FROM dbo.NhanVien N, dbo.TaiKhoan T
	WHERE N.maNhanVien = T.maNhanVien AND T.maNhanVien = @maNhanVien

	DECLARE @t nvarchar(4000)
	IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = @tenDangNhap)
	SET @t = N'CREATE LOGIN ' + QUOTENAME(@tenDangNhap) + ' WITH PASSWORD = ' + QUOTENAME(@matKhau, '''') + ', default_database = QuanLyNhaHang'
	EXEC(@t)

	SET @t = N'CREATE USER ' + QUOTENAME(@tenDangNhap) + ' FOR LOGIN ' + QUOTENAME(@tenDangNhap)
	EXEC(@t)

	IF (@loaiNhanVien = N'Quản Lý')
	    EXEC sys.sp_addrolemember @rolename = QuanLyRole,  -- sysname
                          @membername = @tenDangNhap -- sysname
    ELSE IF (@loaiNhanVien = N'Thu Ngân')
		EXEC sys.sp_addrolemember @rolename = ThuNganRole,  -- sysname
                          @membername = @tenDangNhap -- sysname
	ELSE IF (@loaiNhanVien = N'Phục Vụ')
		EXEC sys.sp_addrolemember @rolename = PhucVuRole,  -- sysname
                          @membername = @tenDangNhap -- sysname
	EXEC sys.sp_addrolemember @rolename = NhanVienRole,  -- sysname
	                     @membername = @tenDangNhap -- sysname		
END
GO

CREATE TRIGGER trigger_DropUserDb ON dbo.TaiKhoan
FOR DELETE AS
BEGIN
    DECLARE @tenDangNhap VARCHAR(20)
	SELECT @tenDangNhap =  D.tenDangNhap FROM Deleted D

	DECLARE @T VARCHAR(400)
	IF (select COUNT(*) from sys.database_principals 
				WHERE name = @tenDangNhap AND type='S') > 0
	BEGIN
		SET @t = N'DROP USER ' + QUOTENAME(@tenDangNhap)
		EXEC(@t)	    
	END

	IF (select COUNT(*) FROM master.dbo.syslogins
				WHERE name = @tenDangNhap ) > 0
	BEGIN
		SET @t = N'DROP LOGIN ' + QUOTENAME(@tenDangNhap)
		EXEC(@t)	    
	END
END
GO


CREATE TRIGGER trigger_UpdatePasswordUserDb ON dbo.TaiKhoan
FOR UPDATE AS
BEGIN
    DECLARE @tenDangNhap VARCHAR(20)
	DECLARE @oldPass NVARCHAR(20)
	DECLARE @newPass NVARCHAR(20)

	SELECT @tenDangNhap=D.tenDangNhap, @oldPass=D.matKhau, @newPass=I.matKhau FROM Deleted D, Inserted I

	DECLARE @T VARCHAR(400)
	IF (@oldPass != @newPass)
	BEGIN
		SET @t = N'ALTER LOGIN ' + QUOTENAME(@tenDangNhap) + ' WITH PASSWORD = ' + QUOTENAME(@newPass, '''')
		EXEC(@t)	    
	END
END
GO

CREATE TRIGGER trigger_UpdateRoleUserDb ON dbo.NhanVien
FOR UPDATE AS
BEGIN
    DECLARE @tenDangNhap VARCHAR(20)
	DECLARE @maNhanVien CHAR(10)
	DECLARE @oldPosition NVARCHAR(20)
	DECLARE @newPosition NVARCHAR(20)

	SELECT @maNhanVien=I.maNhanVien, @oldPosition=D.loaiNhanVien, @newPosition=I.loaiNhanVien FROM Inserted I, Deleted D

	IF(@newPosition = @oldPosition)
		RETURN

	SELECT @tenDangNhap=TK.tenDangNhap FROM dbo.NhanVien NV, dbo.TaiKhoan TK
	WHERE NV.maNhanVien = TK.maNhanVien AND NV.maNhanVien = @maNhanVien

	DECLARE @myrolename VARCHAR(20)
	IF (@oldPosition = N'Quản Lý')
		SET @myrolename='QuanLyRole'
    ELSE IF (@oldPosition = N'Thu Ngân')
		SET @myrolename='ThuNganRole'
	ELSE IF (@oldPosition = N'Phục Vụ')
		SET @myrolename='PhucVuRole'
	EXEC sys.sp_droprolemember @rolename = @myrolename,  -- sysname
	                           @membername = @tenDangNhap -- sysname

	IF (@newPosition = N'Quản Lý')
		SET @myrolename='QuanLyRole'
    ELSE IF (@newPosition = N'Thu Ngân')
		SET @myrolename='ThuNganRole'
	ELSE IF (@newPosition = N'Phục Vụ')
		SET @myrolename='PhucVuRole'
	EXEC sys.sp_addrolemember @rolename = @myrolename,  -- sysname
	                     @membername = @tenDangNhap -- sysname	
END
GO


------Insert
-- Chèn dữ liệu mẫu
INSERT INTO dbo.NhanVien
(
    maNhanVien,
    hoTen,
    ngaySinh,
    gioiTinh,
    diaChi,
    soDienThoai,
    heSoLuong,
    loaiNhanVien
)
VALUES
(   'NV110004',        -- maNhanVien - char(10)
    N'Quản lý',       -- hoTen - nvarchar(100)
    '20001212', -- ngaySinh - date
    1,      -- gioiTinh - bit
    N'abc',       -- diaChi - nvarchar(150)
    '0987223761',        -- soDienThoai - char(10)
    500000,       -- heSoLuong - float
    N'Quản Lý'        -- loaiNhanVien - nvarchar(20)
    )
GO
INSERT INTO dbo.TaiKhoan
(
    tenDangNhap,
    matKhau,
    trangThaiTaiKhoan,
    maNhanVien
)
VALUES
(   'QuanLy',  -- tenDangNhap - varchar(50)
    '123',  -- matKhau - varchar(50)
    N'Đang hoạt động', -- trangThaiTaiKhoan - nvarchar(20)
    'NV110004'   -- maNhanVien - char(10)
    )
GO

insert into NhanVien(maNhanVien, hoTen, ngaySinh, gioiTinh, diaChi, soDienThoai, heSoLuong, loaiNhanVien)
values ('NV110001', N'Trần Ngọc Tâm', '1990-01-01', 0, N'3 Phố Phúc, Xã Vương, Huyện 60 Ninh Thuận','0199178481', 400000, N'Quản Lý')
	, ('NV110002', N'Phạm Phúc Hậu', '1991-03-30', 0, N'161, Thôn Liễu Thái, Phường 8, Quận Hạnh Quảng Bình', '0121585907', 400000, N'Quản Lý')
	, ('NV110003', N'Nguyễn Phương Nga', '1990-07-25', 1, N'8, Ấp Bình Văn, Phường 50, Huyện Nhữ Vỹ Châu Vĩnh Phúc', '0199322097', 400000, N'Quản Lý')
	, ('NV220111', N'Trương Quang Định', '1993-08-24', 0, N'1456 Phố Nhạn, Ấp Phong Đàn, Quận Mai Mộc Quảng Ngãi', '0685598384', 380000, N'Đầu Bếp')
	, ('NV220222', N'Đỗ Tố Hoa', '1996-12-01', 1, N'371, Ấp Trưng, Xã Bắc Đôn, Quận Giang Lô Phú Yên', '0467206578', 380000, N'Đầu Bếp')
	, ('NV220333', N'Bùi Công Minh', '1994-05-09', 0, N'45 Võ Thị Sáu, P.Đa Kao. Trung tâm Quận 1, TP HCM','0671543545',380000, N'Đầu Bếp')
	, ('NV220444', N'Đào Văn Mác', '1994-06-17', 0, N'98 Phố Tăng Dân Giao, Ấp Nghị Thiên, Quận Khoát Từ Đồng Tháp','0581080331', 380000, N'Đầu Bếp')
	, ('NV220555', N'Nguyễn Thị Ngọc Lan', '1997-10-28', 1, N'14, Thôn Thủy Trạch, Xã 9, Quận Đàn Tiền Giang','0281160318', 380000, N'Đầu Bếp')
	, ('NV330101', N'Ngô Cẩm Huệ', '1999-02-21', 1, N'512 Phố Phạm Thục Thông, Thôn Cát Đàn, Quận Âu Cà Mau','0186388645', 380000, N'Phục Vụ')
	, ('NV330102', N'Trần Thiên Anh','2000-10-13', 0, N'7881 Phố Chung, Xã Chiến, Quận Cát Thái Nguyên','0984950567', 330000, N'Phục Vụ')
	, ('NV330103', N'Đinh Quang Vinh', '2000-11-09', 0, N'840, Thôn Thập Xuân Khoát, Ấp Chiểu Anh, Quận Đình Khánh Hòa','0979873572', 330000, N'Phục Vụ')
	, ('NV330104', N'Nguyễn Trường Hải', '2001-07-16', 0, N'5259 Phố Nhiên, Xã Kha, Huyện 16 Bình Phước','0682122957', 330000, N'Phục Vụ')
	, ('NV330105', N'Đặng Thị Cẩm Tiên', '2002-08-15', 1, N'3 Phố Âu Phương Trực, Phường Bắc Thịnh, Quận Đăng Đà Nẵng','0351091857', 330000, N'Phục Vụ')
	, ('NV330106', N'Phạm Hùng Thủy', '2001-04-25', 0, N'7933 Phố Lê Lập Đoan, Thôn Chương Cảnh, Quận Thục Lào Cai','0741419362', 330000, N'Phục Vụ')
	, ('NV330107', N'Lý Bắc Nam', '2001-09-10', 0, N'554, Thôn Thôi Linh, Phường Định Lam, Quận Bồ Diệp Cà Mau','0713923079', 330000, N'Phục Vụ')
	, ('NV330108', N'Trịnh Hoàng Yến Nhi', '2002-06-29', 1, N'3 Phố Đan Dao Khuyên, Phường Hoàn Hiển, Huyện Khánh Ý Vĩnh Phúc','0158769212', 330000, N'Phục Vụ')
	, ('NV330109', N'Phan Hoàng Châu', '1999-03-08', 1, N'7704, Thôn Ái Đôn, Phường 64, Quận Hoan Ngô Thừa Thiên Huế','0851882959', 330000, N'Phục Vụ')
	, ('NV330110', N'Lại Văn Phú','2001-07-14', 0, N'20 Phố Diệp Lực Liên, Phường Nhân Lạc, Huyện Kha Điện Biên','0126892148', 330000, N'Phục Vụ')
	, ('NV440123', N'Trần Trường Thi', '2000-08-22', 0, N'2 Phố Nhiên, Phường Thu Kiều, Huyện 6 Cao Bằng','0775783212', 270000, N'Thu Ngân')
	, ('NV440456', N'Mai Bảo Ngọc','1998-04-12', 1, N'20 Phố Đàm Trung Sơn, Thôn Đăng Hạ, Quận Phương Trác Tuyên Quang','0874588175', 270000, N'Thu Ngân')
	, ('NV440789', N'Đỗ Hồng Thái Ngân', '1999-01-30', 1, N'5 Phố Hồng Yên Kiên, Phường Sinh Tiến, Huyện Bồ Diệp Quân Khánh Hòa','0679242119', 270000, N'Thu Ngân')

GO

insert into TaiKhoan(tenDangNhap, matKhau, trangThaiTaiKhoan, maNhanVien)
values ('tamtranngocql001','110001qltam', N'Đang hoạt động', 'NV110001')
insert into TaiKhoan VALUES('hauphamphucql002', '110002qlhau', N'Đang hoạt động', 'NV110002')
insert into TaiKhoan VALUES('nganguyenphuongql003', '110003qlngan', N'Đang hoạt động', 'NV110003')
insert into TaiKhoan VALUES('dinhtruongquangdb111', '220111dbdinh', N'Đang hoạt động', 'NV220111')
insert into TaiKhoan VALUES('hoadotodb222', '220222dbhoa', N'Đang hoạt động', 'NV220222')
insert into TaiKhoan VALUES('minhbuicongdb333', '220333dbminh', N'Đang hoạt động', 'NV220333')
insert into TaiKhoan VALUES('macdaovandb444', '220444dbmac', N'Đang hoạt động', 'NV220444')
insert into TaiKhoan VALUES('lannguyenthingocdb555', '220555dbmac', N'Đang hoạt động', 'NV220555')
insert into TaiKhoan VALUES('huengocampv101', '330101pvhue', N'Đang hoạt động', 'NV330101')
insert into TaiKhoan VALUES('anhtranthienpv102', '330102pvanh', N'Đang hoạt động', 'NV330102')
insert into TaiKhoan VALUES('vinhdinhquangpv103', '330103pvvinh', N'Đang hoạt động', 'NV330103')
insert into TaiKhoan VALUES('hainguyentruongpv104', '330104pvhai', N'Đang hoạt động', 'NV330104')
insert into TaiKhoan VALUES('tiendangthicampv105', '330105pvtien', N'Đang hoạt động', 'NV330105')
insert into TaiKhoan VALUES('thuyphamhungpv106', '330106pvthuy', N'Đang hoạt động', 'NV330106')
insert into TaiKhoan VALUES('namlybacpv107', '330107pvnam', N'Đang hoạt động', 'NV330107')
insert into TaiKhoan VALUES('nhitrinhhoangyenpv108', '330108pvnhi', N'Đang hoạt động', 'NV330108')
insert into TaiKhoan VALUES('chauphanhoangpv109', '330109pvchau', N'Đang hoạt động', 'NV330109')
insert into TaiKhoan VALUES('phulaivanpv110', '330110pvphu', N'Đang hoạt động', 'NV330110')
insert into TaiKhoan VALUES('thitrantruongtn123', '440123tnthi', N'Đang hoạt động', 'NV440123')
insert into TaiKhoan VALUES('ngocmaibaotn456', '440456tnngoc', N'Đang hoạt động', 'NV440456')
insert into TaiKhoan VALUES('ngandohongthaitn789', '440789tnngan', N'Đang hoạt động', 'NV440789')
GO

insert into CaTruc(maCaTruc, ngayBatDau, ngayKetThuc)
values ('CT1001', '2022-09-26', '2022-09-28')
	, ('CT1002', '2022-09-29', '2022-09-30')
	, ('CT1003', '2022-10-01', '2022-10-02')
GO
insert into DangKyCaTruc(maNhanVien, maCaTruc)
values ('NV220111', 'CT1001')
	, ('NV220222', 'CT1002')
	, ('NV220333', 'CT1003')
	, ('NV220444', 'CT1001')
	, ('NV220555', 'CT1002')
	, ('NV220111', 'CT1003')
	, ('NV220222', 'CT1001')
	, ('NV220333', 'CT1002')
	, ('NV220444', 'CT1003')

	, ('NV330101', 'CT1001')
	, ('NV330102', 'CT1002')
	, ('NV330103', 'CT1003')
	, ('NV330104', 'CT1001')
	, ('NV330105', 'CT1002')
	, ('NV330106', 'CT1003')
	, ('NV330107', 'CT1001')
	, ('NV330108', 'CT1002')
	, ('NV330109', 'CT1003')
	, ('NV330110', 'CT1001')
	, ('NV330101', 'CT1002')
	, ('NV330102', 'CT1003')
	, ('NV330103', 'CT1001')
	, ('NV330104', 'CT1002')
	, ('NV330105', 'CT1003')
	, ('NV330106', 'CT1001')
	, ('NV330107', 'CT1002')
	, ('NV330108', 'CT1003')
	, ('NV330109', 'CT1001')
	, ('NV330110', 'CT1002')
	, ('NV330101', 'CT1003')
	
	, ('NV440123', 'CT1001')
	, ('NV440789', 'CT1003')
	, ('NV440123', 'CT1003')
	, ('NV440456', 'CT1002')
	, ('NV440789', 'CT1001')	
GO

insert into KhachHang(maKhachHang, hoTen, soDienThoai, ngaySinh, gioiTinh)
values ('KH1', N'Trịnh Đình Trọng', '0760153349', '1988-03-24', 0)
	, ('KH2', N'Nguyễn Xuân Lan', '0510502106', '1992-05-17', 1)
	, ('KH3', N'Bùi Ngọc Ánh', '0513341746', '1998-12-12', 1)
	, ('KH4', N'Võ Xuân Hiển', '0759614456', '2002-02-19', 0)
	, ('KH5', N'Trần Đình Nam', '0743563676', '1985-04-20', 0)
	, ('KH6', N'Phan Mạnh Quỳnh', '0753120822', '2000-07-22', 0)

GO

insert into Ban(maBan, trangThaiBan, loaiBan, soLuongGheToiDa)
values ('BV101', N'Đã đặt trước', N'VIP', 20)
	, ('BV102', N'Đang phục vụ', N'VIP', 20)
	, ('BV103', N'Đang có sẵn', N'VIP', 10)
	, ('BV104', N'Đang có sẵn', N'VIP', 10)
	, ('BV105', N'Đang có sẵn', N'VIP', 5)
	, ('BV106', N'Đang có sẵn', N'VIP', 5)
	, ('BT201', N'Đang phục vụ', N'Thường', 10)
	, ('BT202', N'Đang phục vụ', N'Thường', 10)
	, ('BT203', N'Đã đặt trước', N'Thường', 10)
	, ('BT204', N'Đang phục vụ', N'Thường', 5)
	, ('BT205', N'Đang có sẵn', N'Thường', 5)
	, ('BT206', N'Đang có sẵn', N'Thường', 5)
GO

insert into DatTruoc(maDatTruoc, trangThaiDatTruoc, thoiGianCheckIn, thoiGianDatTruoc, soLuongNguoi, maKhachHang, maBan, maNhanVienTiepNhan)
values ('DT1', N'Đã check-in', '2022-10-02', '2022-09-29', 9, 'KH1', 'BV103', 'NV440456')
	, ('DT2', N'Đã xác nhận', '2022-10-02', '2022-09-30', 5, 'KH2', 'BT203', 'NV440456')
	, ('DT3', N'Chờ xác nhận', '2022-10-07', '2022-10-01', 10, 'KH3', 'BV104', 'NV440789')
	, ('DT4', N'Từ chối', '2022-10-08', '2022-10-01', 4, 'KH4', 'BT206', 'NV440789')
	, ('DT5', N'Đã xác nhận', '2022-10-08', '2022-10-01', 10 , 'KH5', 'BV101', 'NV440789')
	, ('DT6', N'Chờ xác nhận', '2022-10-08', '2022-10-01',10 , 'KH6', 'BV104', 'NV440789')
GO

INSERT into Coupon(maCoupon, ngayBatDau, ngayKetThuc, phanTramGiam, giamToiDa, donToiThieu)
values ('CP10', '2022-10-01', '2022-10-07' , 0.1 , 200000 , 50000)
	, ('CP20', '2022-10-08', '2022-10-15', 0.2 , 300000 , 100000)
	, ('CP30', '2022-11-15', '2022-12-15', 0.15 , 200000 , 100000)
	, ('CP40', '2022-11-11', '2022-11-30', 0.1 , 100000 , 0)
GO

INSERT INTO dbo.DonHang
(
    maDonHang,
    thoiGianCheckIn,
    phuThu,
    maCoupon,
    soTienThanhToan,
    maBan,
    maKhachHang,
    maDauBep,
    maNhanVienPhucVu,
    maNhanVienThuNgan,
	trangThaiDonHang
)
VALUES ('HD1','20220709', 50000, 'CP10', 1100000, 'BV103', 'KH1', 'NV220333', 'NV330103', 'NV440789', N'Đã thanh toán')
, ('HD2', GETDATE(), 50000.0, NULL, 1469000.0, 'BV102','KH4','NV220111', 'NV330101','NV440456', N'Chưa thanh toán')
, ('HD3', GETDATE(), 0.0, NULL, 924000.0, 'BT201','KH2','NV220333', 'NV330107','NV440789', N'Đang chuẩn bị')
, ('HD4', GETDATE(), 0.0, NULL, 482000.0, 'BT202','KH3','NV220555', 'NV330104','NV440789', N'Chưa thanh toán')
, ('HD5', GETDATE(), 20000.0, NULL, 961000.0, 'BT204','KH5','NV220333', 'NV330101','NV440456', N'Đang chuẩn bị')

INSERT INTO dbo.MonAn
VALUES ('10001', N'Cảo Tôm Phúc Lục', 72000, 'cao-tom-phuc-luc.png')
, ('10002', N'Phùng Trảo Thủ', 62000, 'phung-trao-thu.png')
, ('10003', N'Há Cảo Sò Điệp', 72000, 'ha-cao-so-diep.png')
, ('10004', N'Bánh Bao Thượng Hải', 65000, 'banh-bao-thuong-hai.png')
, ('10005', N'Xíu Mại Trứng Tôm', 70000, 'xiu-mai-trung-tom.png')
, ('10006', N'Bánh Bao Than Trúc Kim Sa', 65000, 'banh-bao-than-truc-kim-sa.png')
, ('10007', N'Bánh Sầu Riêng Ngàn Lớp', 72000, 'banh-sau-rieng-ngan-lop.png')
, ('10008', N'Hoành Thánh Tôm Chiên', 72000, 'hoanh-thanh-tom-chien.png')
, ('10009', N'Cảo Bò Nấm Truffle', 80000, 'cao-bo-nam-truffle.png')
, ('10010', N'Thanh Cua Cuộn Rong Biển', 75000, 'thanh-cua-cuon-rong-bien.png')
, ('10011', N'Canh Sen Đen', 92000, 'canh-sen-den.png')
, ('10012', N'Canh Bào Ngư Thượng Hạng', 498000, 'canh-bao-ngu-thuong-hang.png')
, ('10013', N'Heo Quay Da Giòn', 178000, 'heo-quay-da-gion.png')
, ('10014', N'Hải Sản Đậu Hủ Tay Cầm', 238000, 'hai-san-dau-hu-tay-cam.png')
, ('10015', N'Sò Điệp Xào Măng Tây', 298000, 'so-diep-xao-mang-tay.png')
GO

insert into ChiTietDonHang(maDonHang, maMonAn, soLuong )
VALUES
('HD1', '10003', 2), ('HD1', '10005', 2), ('HD1', '10007', 2), ('HD1', '10012', 1), ('HD1', '10013', 2),
('HD2', '10014', 1), ('HD2', '10006', 1), ('HD2', '10012', 1), ('HD2', '10007', 1), ('HD2', '10011', 4), ('HD2', '10013', 1),
('HD3', '10003', 1), ('HD3', '10011', 2), ('HD3', '10015', 2), ('HD3', '10001', 1),
('HD4', '10013', 1), ('HD4', '10009', 2), ('HD4', '10007', 2),
('HD5', '10006', 1), ('HD5', '10004', 1), ('HD5', '10014', 1), ('HD5', '10012', 1), ('HD5', '10010', 1)
GO

insert into Luong(maNhanVien, maCaTruc, soNgayNghi, tongLuong)
values ('NV110001', 'CT1001', 0, 1200000 )
	, ('NV220111', 'CT1001', 1, 760000)
	, ('NV220111', 'CT1003', 0, 760000)
	, ('NV330101', 'CT1001', 2, 330000)
	, ('NV330101', 'CT1002', 0, 660000)
	, ('NV330101', 'CT1003', 0, 660000)
	, ('NV440123', 'CT1001', 0, 810000)
	, ('NV440123', 'CT1003', 1, 270000)
