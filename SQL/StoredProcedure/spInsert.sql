use QuanLyNhaHang

CREATE PROCEDURE spInsertBan @maBan char(10), @trangThaiBan nvarchar(50), @loaiBan nvarchar(20), @soLuongGheToiDa int
AS BEGIN
		INSERT INTO dbo.Ban
		VALUES (@maBan, @trangThaiBan, @loaiBan, @soLuongGheToiDa)
	END
GO

CREATE PROCEDURE spInsertCaTruc @maCaTruc char(10), @ngayBatDau date, @ngayKetThuc date
AS BEGIN
		INSERT INTO dbo.CaTruc
		VALUES (@maCaTruc, @ngayBatDau, @ngayKetThuc)
	END
GO

CREATE PROCEDURE spInsertChiTietDonHang @maDonHang char(10), @maMonAn char(10), @soLuong int
AS BEGIN
		INSERT INTO dbo.ChiTietDonHang 
		VALUES (@maDonHang, @maMonAn, @soLuong)
	END
GO

CREATE PROCEDURE spInsertCoupon @maCoupon char(10), @ngayBatDau date, @ngayKetThuc date, @phanTramGiam float, @giamToiDa float, @donToiThieu float
AS BEGIN
		INSERT INTO dbo.Coupon 
		VALUES (@maCoupon, @ngayBatDau, @ngayKetThuc, @phanTramGiam, @giamToiDa, @donToiThieu)
	END
GO

CREATE PROCEDURE spInsertDangKyCaTruc @maNhanVien char(10), @maCaTruc char(10)
AS BEGIN
		INSERT INTO dbo.DangKyCaTruc
		VALUES (@maNhanVien , @maCaTruc)
	END
GO

CREATE PROCEDURE spInsertDatTruoc @maDatTruoc char(10), @trangThaiDatTruoc nvarchar(20), @thoiGianCheckIn datetime, @thoiGianDatTruoc datetime, @soLuongNguoi int, @maKhachHang char(10), @maBan char(10), @maNhanVienTiepNhan char(10)
AS BEGIN
		INSERT INTO dbo.DatTruoc
		VALUES (@maDatTruoc, @trangThaiDatTruoc, @thoiGianCheckIn, @thoiGianDatTruoc, @soLuongNguoi, @maKhachHang, @maBan, @maNhanVienTiepNhan)
	END
GO
CREATE PROCEDURE spInsertDonHang @maDonHang char(10), @thoiGianCheckIn datetime, @thue float, @phuThu float, @maCoupon char(10), @soTienThanhToan float, @maBan char(10), @maKhachHang char(10), @maDauBep char(10), @maNhanVienPhucVu char(10), @maNhanVienThuNgan char(10)
AS BEGIN
		INSERT INTO dbo.DonHang
		VALUES (@maDonHang, @thoiGianCheckIn, @thue, @phuThu, @maCoupon, @soTienThanhToan, @maBan, @maKhachHang, @maDauBep, @maNhanVienPhucVu, @maNhanVienThuNgan)
	END
GO

CREATE PROCEDURE spInsertKhachHang @maKhachHang char(10), @hoTen nvarchar(150), @soDienThoai char(10), @ngaySinh date, @gioiTinh bit
AS BEGIN
		INSERT INTO dbo.KhachHang
		VALUES (@maKhachHang, @hoTen, @soDienThoai, @ngaySinh, @gioiTinh)
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

CREATE PROCEDURE spInsertNhanVien @ma char(10), @ten nvarchar(100), @ngaysinh date, @gioitinh bit, @diachi nvarchar(100), @SDT int, @heSoLuong float, @loaiNhanVien nvarchar(20)
AS BEGIN
		INSERT INTO dbo.NhanVien
		VALUES (@ma,@ten,@ngaysinh,@gioitinh,@diachi,@SDT,@heSoLuong,@loaiNhanVien)
	END
GO

CREATE PROCEDURE spInsertTaiKhoan @tenDangNhap varchar(50), @matKhau varchar(50), @trangThaiTaiKhoan nvarchar(20), @maNhanVien char(10)
AS BEGIN
		INSERT INTO dbo.TaiKhoan
		VALUES (@tenDangNhap, @matKhau, @trangThaiTaiKhoan, @maNhanVien)
	END
GO