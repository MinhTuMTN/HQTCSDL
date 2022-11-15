using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class DonHang
    {
        private string tenDangNhap;
        private string matKhau;
        private string trangThaiTaiKhoan;
        private string maNhanVien;

        public DonHang()
        {
        }

        public DonHang(string tenDangNhap, string matKhau, string trangThaiTaiKhoan, string maNhanVien)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.trangThaiTaiKhoan = trangThaiTaiKhoan;
            this.maNhanVien = maNhanVien;
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string TrangThaiTaiKhoan { get => trangThaiTaiKhoan; set => trangThaiTaiKhoan = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
    }
}
