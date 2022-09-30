CREATE DATABASE QuanLyNhaHang
GO

USE QuanLyNhaHang
GO

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
	maDatTruoc CHAR(10),
	trangThaiDatTruoc NVARCHAR(20),
	thoiGianCheckIn DATETIME,
	thoiGianDatTruoc DATETIME,
	soLuongNguoi INT,
	maKhachHang CHAR(10) REFERENCES dbo.KhachHang(maKhachHang),
	maBan CHAR(10) REFERENCES dbo.Ban(maBan),
	maNhanVienTiepNhan CHAR(10) REFERENCES dbo.NhanVien(maNhanVien)
)
GO
CREATE TABLE DonHang
(
	maDonHang CHAR(10) PRIMARY KEY,
	thoiGianCheckIn DATETIME,
	maBan CHAR(10) REFERENCES dbo.Ban(maBan),
	maKhachHang CHAR(10) REFERENCES dbo.KhachHang(maKhachHang),
	maDauBep CHAR(10) REFERENCES dbo.NhanVien(maNhanVien),
	maNhanVienPhucVu CHAR(10) REFERENCES dbo.NhanVien(maNhanVien),
	maNhanVienThuNgan CHAR(10) REFERENCES dbo.NhanVien(maNhanVien)
)
GO
CREATE TABLE Coupon
(
	maCoupon CHAR(10) PRIMARY KEY,
	ngayBatDau DATE,
	ngayKetThuc DATE,
	phanTramGiam FLOAT,
	soTienGiamToiDa FLOAT,
	soTienToiThieu FLOAT
)
GO
CREATE TABLE SuDungCoupon
(
	maKhachHang CHAR(10) REFERENCES dbo.KhachHang(maKhachHang),
	maCoupon CHAR(10) REFERENCES dbo.Coupon(maCoupon),
	ngaySuDung DATE,
	PRIMARY KEY(maKhachHang,maCoupon)
)
GO
CREATE TABLE HoaDon
(
	maHoaDon CHAR(10) PRIMARY KEY,
	phuThu FLOAT,
	maDonHang CHAR(10) REFERENCES dbo.DonHang(maDonHang),
	soTienTamTinh FLOAT,
	thue FLOAT,
	maCoupon CHAR(10) REFERENCES dbo.Coupon(maCoupon),
	tongTienPhaiThanhToan FLOAT
)
GO
CREATE TABLE MonAn
(
	maMonAn CHAR(10) PRIMARY KEY,
	tenMonAn NVARCHAR(150),
	giaTien FLOAT
)
GO
CREATE TABLE ChiTietHoaDon
(
	maHoaDon CHAR(10) REFERENCES dbo.HoaDon(maHoaDon),
	maMonAn CHAR(10) REFERENCES dbo.MonAn(maMonAn),
	soLuong INT,
	PRIMARY KEY(maHoaDon,maMonAn)
)
GO
CREATE TABLE NguyenLieu
(
	maNguyenLieu CHAR(10) PRIMARY KEY,
	tenNguyenLieu NVARCHAR(150),
	donViTinh CHAR(10),
	donGia FLOAT,
	soLuongTon FLOAT
)
GO
CREATE TABLE CongThucMonAn
(
	maMonAn CHAR(10) REFERENCES dbo.MonAn(maMonAn),
	maNguyenLieu CHAR(10) REFERENCES dbo.NguyenLieu(maNguyenLieu),
	soLuong FLOAT
)
GO
CREATE TABLE NhaCungCap
(
	maNhaCungCap CHAR(10) PRIMARY KEY,
	tenNhaCungCap NVARCHAR(150),
	diaChi NVARCHAR(250),
	email VARCHAR(150),
	soDienThoai CHAR(10)
)
GO
CREATE TABLE ChiTieuNguyenLieu
(
	maChiTieuNguyenLieu CHAR(10) PRIMARY KEY,
	ngayNhap DATE,
	soLuongNhap FLOAT,
	tongTien FLOAT,
	maNhaCungCap CHAR(10) REFERENCES dbo.NhaCungCap(maNhaCungCap),
	maNguyenLieu CHAR(10) REFERENCES dbo.NguyenLieu(maNguyenLieu),
	maNguoiQuanLy CHAR(10) REFERENCES dbo.NhanVien(maNhanVien)
)
