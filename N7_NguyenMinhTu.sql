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
	donViTinh NVARCHAR(15),
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
GO


-- Thêm Constraint
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

-- Tạo View
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


-- Tạo trigger
CREATE TRIGGER trigger_giaTien ON dbo.MonAn
INSTEAD OF INSERT
AS
DECLARE @new FLOAT
SELECT @new=ne.giaTien FROM Inserted ne
IF (@new<0)
BEGIN
	PRINT(N'Giá tiền phải lớn hơn 0')
	ROLLBACK;
END
GO

CREATE TRIGGER trigger_soLuongChiTietHoaDon ON dbo.ChiTietHoaDon
INSTEAD OF INSERT
AS
DECLARE @new FLOAT
SELECT @new=ne.soLuong FROM Inserted ne
IF (@new<0)
BEGIN
	PRINT(N'Số lượng phải lớn hơn 0')
	ROLLBACK;
END
GO

CREATE TRIGGER trigger_soLuongCongThucMonAn ON dbo.CongThucMonAn
INSTEAD OF INSERT
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
insert into NhanVien(maNhanVien, hoTen, ngaySinh, gioiTinh, diaChi, soDienThoai, heSoLuong, loaiNhanVien)
values ('NV110001', N'Trần Ngọc Tâm', '1990-01-01', 1, N'3 Phố Phúc, Xã Vương, Huyện 60 Ninh Thuận','0199178481', 400000, N'Quản Lý')
	, ('NV110002', N'Phạm Phúc Hậu', '1991-03-30', 1, N'161, Thôn Liễu Thái, Phường 8, Quận Hạnh Quảng Bình', '0121585907', 400000, N'Quản Lý')
	, ('NV110003', N'Nguyễn Phương Nga', '1990-07-25', 0, N'8, Ấp Bình Văn, Phường 50, Huyện Nhữ Vỹ Châu Vĩnh Phúc', '0199322097', 400000, N'Quản Lý')
	, ('NV220111', N'Trương Quang Định', '1993-08-24', 1, N'1456 Phố Nhạn, Ấp Phong Đàn, Quận Mai Mộc Quảng Ngãi', '0685598384', 380000, N'Đầu Bếp')
	, ('NV220222', N'Đỗ Tố Hoa', '1996-12-01', 0, N'371, Ấp Trưng, Xã Bắc Đôn, Quận Giang Lô Phú Yên', '0467206578', 380000, N'Đầu Bếp')
	, ('NV220333', N'Bùi Công Minh', '1994-05-09', 1, N'45 Võ Thị Sáu, P.Đa Kao. Trung tâm Quận 1, TP HCM','0671543545',380000, N'Đầu Bếp')
	, ('NV220444', N'Đào Văn Mác', '1994-06-17', 1, N'98 Phố Tăng Dân Giao, Ấp Nghị Thiên, Quận Khoát Từ Đồng Tháp','0581080331', 380000, N'Đầu Bếp')
	, ('NV220555', N'Nguyễn Thị Ngọc Lan', '1997-10-28', 0, N'14, Thôn Thủy Trạch, Xã 9, Quận Đàn Tiền Giang','0281160318', 380000, N'Đầu Bếp')
	, ('NV330101', N'Ngô Cẩm Huệ', '1999-02-21', 0, N'512 Phố Phạm Thục Thông, Thôn Cát Đàn, Quận Âu Cà Mau','0186388645', 380000, N'Phục Vụ')
	, ('NV330102', N'Trần Thiên Anh','2000-10-13', 1, N'7881 Phố Chung, Xã Chiến, Quận Cát Thái Nguyên','0984950567', 330000, N'Phục Vụ')
	, ('NV330103', N'Đinh Quang Vinh', '2000-11-09', 1, N'840, Thôn Thập Xuân Khoát, Ấp Chiểu Anh, Quận Đình Khánh Hòa','0979873572', 330000, N'Phục Vụ')
	, ('NV330104', N'Nguyễn Trường Hải', '2001-07-16', 1, N'5259 Phố Nhiên, Xã Kha, Huyện 16 Bình Phước','0682122957', 330000, N'Phục Vụ')
	, ('NV330105', N'Đặng Thị Cẩm Tiên', '2002-08-15', 0, N'3 Phố Âu Phương Trực, Phường Bắc Thịnh, Quận Đăng Đà Nẵng','0351091857', 330000, N'Phục Vụ')
	, ('NV330106', N'Phạm Hùng Thủy', '2001-04-25', 1, N'7933 Phố Lê Lập Đoan, Thôn Chương Cảnh, Quận Thục Lào Cai','0741419362', 330000, N'Phục Vụ')
	, ('NV330107', N'Lý Bắc Nam', '2001-09-10', 1, N'554, Thôn Thôi Linh, Phường Định Lam, Quận Bồ Diệp Cà Mau','0713923079', 330000, N'Phục Vụ')
	, ('NV330108', N'Trịnh Hoàng Yến Nhi', '2002-06-29', 0, N'3 Phố Đan Dao Khuyên, Phường Hoàn Hiển, Huyện Khánh Ý Vĩnh Phúc','0158769212', 330000, N'Phục Vụ')
	, ('NV330109', N'Phan Hoàng Châu', '1999-03-08', 0, N'7704, Thôn Ái Đôn, Phường 64, Quận Hoan Ngô Thừa Thiên Huế','0851882959', 330000, N'Phục Vụ')
	, ('NV330110', N'Lại Văn Phú','2001-07-14', 1, N'20 Phố Diệp Lực Liên, Phường Nhân Lạc, Huyện Kha Điện Biên','0126892148', 330000, N'Phục Vụ')
	, ('NV440123', N'Trần Trường Thi', '2000-08-22', 1, N'2 Phố Nhiên, Phường Thu Kiều, Huyện 6 Cao Bằng','0775783212', 270000, N'Thu Ngân')
	, ('NV440456', N'Mai Bảo Ngọc','1998-04-12', 0, N'20 Phố Đàm Trung Sơn, Thôn Đăng Hạ, Quận Phương Trác Tuyên Quang','0874588175', 270000, N'Thu Ngân')
	, ('NV440789', N'Đỗ Hồng Thái Ngân', '1999-01-30', 0, N'5 Phố Hồng Yên Kiên, Phường Sinh Tiến, Huyện Bồ Diệp Quân Khánh Hòa','0679242119', 270000, N'Thu Ngân')

GO

insert into TaiKhoan(tenDangNhap, matKhau, trangThaiTaiKhoan, maNhanVien)
values ('tamtranngocql001','110001qltam', N'đang hoạt động', 'NV110001')
	, ('hauphamphucql002', '110002qlhau', N'đang hoạt động', 'NV110002')
	, ('nganguyenphuongql003', '110003qlngan', N'đang hoạt động', 'NV110003')
	, ('dinhtruongquangdb111', '220111dbdinh', N'đang hoạt động', 'NV220111')
	, ('hoadotodb222', '220222dbhoa', N'đang hoạt động', 'NV220222')
	, ('minhbuicongdb333', '220333dbminh', N'đang hoạt động', 'NV220333')
	, ('macdaovandb444', '220444dbmac', N'đang hoạt động', 'NV220444')
	, ('lannguyenthingocdb555', '220555dbmac', N'đang hoạt động', 'NV220555')
	, ('huengocampv101', '330101pvhue', N'đang hoạt động', 'NV330101')
	, ('anhtranthienpv102', '330102pvanh', N'đang hoạt động', 'NV330102')
	, ('vinhdinhquangpv103', '330103pvvinh', N'đang hoạt động', 'NV330103')
	, ('hainguyentruongpv104', '330104pvhai', N'đang hoạt động', 'NV330104')
	, ('tiendangthicampv105', '330105pvtien', N'đang hoạt động', 'NV330105')
	, ('thuyphamhungpv106', '330106pvthuy', N'đang hoạt động', 'NV330106')
	, ('namlybacpv107', '330107pvnam', N'đang hoạt động', 'NV330107')
	, ('nhitrinhhoangyenpv108', '330108pvnhi', N'đang hoạt động', 'NV330108')
	, ('chauphanhoangpv109', '330109pvchau', N'đang hoạt động', 'NV330109')
	, ('phulaivanpv110', '330110pvphu', N'đang hoạt động', 'NV330110')
	, ('thitrantruongtn123', '440123tnthi', N'đang hoạt động', 'NV440123')
	, ('ngocmaibaotn456', '440456tnngoc', N'đang hoạt động', 'NV440456')
	, ('ngandohongthaitn789', '440789tnngan', N'đang hoạt động', 'NV440789')
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
values ('KH01', N'Trịnh Đình Trọng', '0760153349', '1988-03-24', 1)
	, ('KH02', N'Nguyễn Xuân Lan', '0510502106', '1992-05-17', 0)
	, ('KH03', N'Bùi Ngọc Ánh', '0513341746', '1998-12-12', 0)
	, ('KH04', N'Võ Xuân Hiển', '0759614456', '2002-02-19', 1)
	, ('KH05', N'Trần Đình Nam', '0743563676', '1985-04-20', 1)
	, ('KH06', N'Phan Mạnh Quỳnh', '0753120822', '2000-07-22', 1)

GO

insert into Ban(maBan, trangThaiBan, loaiBan, soLuongGheToiDa)
values ('BV101', N'đã đặt trước', N'VIP', 20)
	, ('BV102', N'đang phục vụ', N'VIP', 20)
	, ('BV103', N'đang có sẵn', N'VIP', 10)
	, ('BV104', N'đang có sẵn', N'VIP', 10)
	, ('BV105', N'đang có sẵn', N'VIP', 5)
	, ('BV106', N'đang có sẵn', N'VIP', 5)
	, ('BT201', N'đang phục vụ', N'Thường', 10)
	, ('BT202', N'đang phục vụ', N'Thường', 10)
	, ('BT203', N'đã đặt trước', N'Thường', 10)
	, ('BT204', N'đang phục vụ', N'Thường', 5)
	, ('BT205', N'đang có sẵn', N'Thường', 5)
	, ('BT206', N'đang có sẵn', N'Thường', 5)
GO

insert into DatTruoc(maDatTruoc, trangThaiDatTruoc, thoiGianCheckIn, thoiGianDatTruoc, soLuongNguoi, maKhachHang, maBan, maNhanVienTiepNhan)
values ('DT01', N'đã check-in', '2022-10-02', '2022-09-29', 9, 'KH01', 'BV103', 'NV440456')
	, ('DT02', N'đã xác nhận', '2022-10-02', '2022-09-30', 5, 'KH02', 'BT205', 'NV440456')
	, ('DT03', N'đã yêu cầu', '2022-10-07', '2022-10-01', 10, 'KH03', 'BV104', 'NV440789')
	, ('DT04', N'hủy bỏ', '2022-10-08', '2022-10-01', 4, 'KH04', 'BT206', 'NV440789')
	, ('DT05', N'đã xác nhận', '2022-10-08', '2022-10-01', 10 , 'KH05', 'BV104', 'NV440789')
	, ('DT06', N'bị từ chối', '2022-10-08', '2022-10-01',10 , 'KH06', 'BV104', 'NV440789')
GO

insert into DonHang(maDonHang, thoiGianCheckIn, maBan, maKhachHang, maDauBep, maNhanVienPhucVu, maNhanVienThuNgan)
values ('DH001', '2022-10-05', 'BV103', 'KH01', 'NV220333', 'NV330103', 'NV440789')
GO

insert into Coupon(maCoupon, ngayBatDau, ngayKetThuc, phanTramGiam, soTienGiamToiDa, soTienToiThieu)
values ('CP10', '2022-10-01', '2022-10-07' , 0.1 , 200000 , 50000)
	, ('CP20', '2022-10-08', '2022-10-15', 0.2 , 300000 , 100000)
GO

insert into HoaDon(maHoaDon, phuThu, maDonHang, soTienTamTinh, thue, maCoupon, tongTienPhaiThanhToan)
values ('HD0001', 20000, 'DH001', 1018000, 10000, 'CP10', 926200 )
GO

insert into NhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, email, soDienThoai)
values ('CC0001', N'Thực Phẩm Tấn Tài', N'1517 Phạm Thế Hiển F6 Q.8', 'kinhdoanh@thucphamtantai.com', '0706675696')
	, ('NCC0002', N'Thực Phẩm La Sicilia', N'Tầng 10, Tòa nhà Miss Áo Dài, 21 Nguyễn Trung Ngạn, P. Bến Nghé, Q. 1, TP. HCM', 'info@lasicilia.com.vn', '0989170531')
	, ('NCC0003', N'Thực Phẩm Hải Triều', N'3/12F ấp Tiền Lân, Xã Bà Điểm, Huyện Hóc Môn, TP Hồ Chí Minh', 'thucphamhaitrieu@gmail.com', '0902322124')
	, ('NCC0004', N'Thực Phẩm Quốc Tuấn', N'8 Trần Văn Quang, Phường 10, Tân Bình, TP Hồ Chí Minh', 'tmquoctuan@yahoo.com', '0908777650')
	, ('NCC0005', N'Thực Phẩm Nhanh', N'204/16/5 Quốc Lộ 13, P.26, Q.Bình Thạnh, Tp.HCM', 'Sales@thucphamnhanh.com', '0311941289')
GO

insert into NguyenLieu(maNguyenLieu, tenNguyenLieu, donViTinh, donGia, soLuongTon)
values 	('NL101', N'Muối', N'Kilogam', 6000 , 80)
	, ('NL102', N'Đường', N'Kilogam', 8000 , 100)
	, ('NL103', N'Bột Ngọt', N'Kilogam', 60000 , 60)
	, ('NL104', N'Bột Nêm', N'Kilogam', 22000, 75)
	, ('NL105', N'Nước mắm', N'Lít', 140000 , 30)
	, ('NL106', N'Nước tương', N'Lít', 145000 , 30)
	, ('NL107', N'Tôm Sú', N'Kilogam', 190000, 70)
	, ('NL108', N'Gà', N'Kilogam', 155000, 55)
	, ('NL109', N'Vịt', N'Kilogam', 55000, 50)
	, ('NL110', N'Heo', N'Kilogam', 90000, 80)
	, ('NL111', N'Sò Điệp', N'Kilogam', 190000, 300)
	, ('NL112', N'Bò', N'Kilogam', 85000, 75)
	, ('NL113', N'Bào Ngư', N'Kilogam', 600000, 250)
	, ('NL114', N'Cua', N'Kilogam', 230000 , 150)
	, ('NL115', N'Trứng Gà', N'Trái', 2000, 270)
	, ('NL116', N'Nấm', N'Kilogam', 300000 , 60)
	, ('NL117', N'Hạt Sen', N'Kilogam', 85000, 50)
	, ('NL118', N'Măng Tây', N'Kilogam', 120000, 50)
	, ('NL119', N'Đậu Hủ', N'Kilogam', 50000 , 40)
	, ('NL120', N'Sầu Riêng', N'Trái', 90000, 30)
	, ('NL121', N'Bột Chiên', N'Gói', 15000 , 45)
	, ('NL122', N'Rong Biển', N'Kilogam', 230000 , 65)
	, ('NL123', N'Bột Thang', N'Gói', 10000 , 40)
	, ('NL124', N'Hành lá', N'Kilogam', 25000 , 30)
	, ('NL125', N'Cà Rốt', N'Kilogam', 30000 , 40)
	, ('NL126', N'Ớt', N'Kilogam', 90000, 35)
GO

insert into MonAn(maMonAn, tenMonAn, giaTien)
values ('10001', N'Cảo Tôm Phúc Lục', 72000)
, ('10002', N'Phùng Trảo Thủ', 62000)
, ('10003', N'Há Cảo Sò Điệp', 72000)
, ('10004', N'Bánh Bao Thượng Hải', 65000)
, ('10005', N'Xíu Mại Trứng Tôm', 70000)
, ('10006', N'Bánh Bao Thang Trúc Kim Sa', 65000)
, ('10007', N'Bánh Sầu Riêng Ngàn Lớp', 72000)
, ('10008', N'Hoành Thánh Tôm Chiên', 72000)
, ('10009', N'Cảo Bò Nấm Truffle', 80000)
, ('10010', N'Thanh Cua Cuộn Rong Biển', 75000)
, ('10011', N'Canh Sen Đen', 92000)
, ('10012', N'Canh Bào Ngư Thượng Hạng', 498000)
, ('10013', N'Heo Quay Da Giòn', 178000)
, ('10014', N'Hải Sản Đậu Hủ Tay Cầm', 238000)
, ('10015', N'Sò Điệp Xào Măng Tây', 298000)
GO

insert into CongThucMonAn(maMonAn, maNguyenLieu, soLuong)
values ('10003', 'NL101', 1)
	, ('10003', 'NL102', 1)
	, ('10003', 'NL103', 1)
	, ('10003', 'NL104', 1)
	, ('10003', 'NL105', 1)
	, ('10003', 'NL106', 1)
	, ('10003', 'NL111', 10)
	, ('10003', 'NL121', 1)
	, ('10003', 'NL124', 1)
	, ('10005', 'NL107', 1)
	, ('10005', 'NL115', 6)
	, ('10007', 'NL120', 1)
	, ('10012', 'NL105', 1)
	, ('10012', 'NL106', 1)
	, ('10013', 'NL113', 1)
GO

insert into ChiTieuNguyenLieu(maChiTieuNguyenLieu, ngayNhap, soLuongNhap, tongTien, maNhaCungCap, maNguyenLieu, maNguoiQuanLy)
values ('CT0001', '2022-09-15', 20, 1100000 ,'NCC0002', 'NL109', 'NV110001')
	, ('CT0002', '2022-09-22', 30, 2550000, 'NCC0004', 'NL117', 'NV110003')
GO

insert into ChiTietHoaDon(maHoaDon, maMonAn, soLuong )
values('HD0001', '10003', 2)
	, ('HD0001', '10005', 2)
	, ('HD0001', '10007', 2)
	, ('HD0001', '10012', 1)
	, ('HD0001', '10013', 2)
GO

insert into SuDungCoupon(maKhachHang, maCoupon, ngaySuDung)
values ('KH01', 'CP10', '2022-10-02')
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
