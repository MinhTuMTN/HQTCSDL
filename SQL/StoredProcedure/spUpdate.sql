USE QuanLyNhaHang
GO

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
	UPDATE dbo.NhanVien SET hoTen=@hoTen, ngaySinh=@ngaySinh, gioiTinh=@gioiTinh, diaChi=@diaChi,soDienThoai=@soDienThoai, heSoLuong=@heSoLuong, loaiNhanVien=@loaiNhanVien
	WHERE maNhanVien=@maNhanVien
END
GO

CREATE PROC spUpdateCaTruc (
	@maCaTruc CHAR(10),
	@ngayBatDau DATE,
	@ngayKetThuc DATE
)
AS
BEGIN
    UPDATE dbo.CaTruc SET ngayBatDau=@ngayBatDau, ngayKetThuc=@ngayKetThuc 
	WHERE maCaTruc=@maCaTruc
END
GO

CREATE PROC spUpdateTaiKhoan(
	@tenDangNhap VARCHAR(50),
	@matKhau VARCHAR(50),
	@trangThaiTaiKhoan NVARCHAR(20)
)
AS
BEGIN
    UPDATE dbo.TaiKhoan SET matKhau=@matKhau, trangThaiTaiKhoan=@trangThaiTaiKhoan 
	WHERE tenDangNhap=@tenDangNhap
END
GO

CREATE PROC spUpdateLuong(
	@maNhanVien CHAR(10),
	@maCaTruc CHAR(10),
	@soNgayNghi INT
)
AS
BEGIN
    UPDATE dbo.Luong SET soNgayNghi=@soNgayNghi
	WHERE maNhanVien=@maNhanVien AND maCaTruc=@maCaTruc
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
    UPDATE dbo.Ban SET trangThaiBan=@trangThaiBan, loaiBan=@loaiBan, soLuongGheToiDa=@soLuongGheToiDa
	WHERE maBan=@maBan
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
	UPDATE dbo.Coupon SET ngayBatDau=@ngayBatDau, ngayKetThuc=@ngayKetThuc, phanTramGiam=@phanTramGiam, giamToiDa=@giamToiDa, donToiThieu=@donToiThieu
	WHERE maCoupon=@maCoupon
END
GO

CREATE PROC spUpdateDonHang(
	@maDonHang CHAR(10),
	@thoiGianCheckIn DATETIME,
	@thue FLOAT,
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
    UPDATE dbo.DonHang SET thoiGianCheckIn=@thoiGianCheckIn, thue=@thue, phuThu=@phuThu, maCoupon=@maCoupon, maBan=@maBan, maKhachHang=@maKhachHang, maNhanVienPhucVu=@maNhanVienPhucVu, maDauBep=@maDauBep, maNhanVienThuNgan=@maNhanVienThuNgan
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
    UPDATE dbo.MonAn SET tenMonAn=@tenMonAn, giaTien=@giaTien, hinhAnh=@hinhAnh
	WHERE maMonAn=@maMonAn
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



