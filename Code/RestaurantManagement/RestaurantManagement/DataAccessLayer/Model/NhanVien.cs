using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class NhanVien
    {
        private string maNhanVien;
        private string hoTen;
        private string soDienThoai;
        private string ngaySinh;
        private bool gioiTinh;

        public NhanVien()
        {
        }

        public NhanVien(string maNhanVien, string hoTen, string soDienThoai, string ngaySinh, bool gioiTinh)
        {
            this.maNhanVien = maNhanVien;
            this.hoTen = hoTen;
            this.soDienThoai = soDienThoai;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
