USE QuanLyNhaHang
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
AS SELECT CaTruc.maCaTruc, hoTen, heSoLuong, loaiNhanVien, soNgayNghi, ngayBatDau, ngayKetThuc, tongLuong
FROM dbo.Luong, dbo.CaTruc, dbo.NhanVien
WHERE Luong.maCaTruc=CaTruc.maCaTruc AND NhanVien.maNhanVien = Luong.maNhanVien
GO

-- Test views
SELECT * FROM dbo.viewNhanVienDangKyCaTruc
SELECT * FROM dbo.viewMonAnDuocPhucVu
SELECT * FROM dbo.viewLuongNhanVien