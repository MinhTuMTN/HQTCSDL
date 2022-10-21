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
        private DateTime ngaySinh;
        private bool gioiTinh;
        private string diaChi;
        private float heSoLuong;
        private string loaiNhanVien;

        public NhanVien()
        {
        }

        public NhanVien(string maNhanVien, string hoTen, string soDienThoai, DateTime ngaySinh, bool gioiTinh, string diaChi, float heSoLuong, string loaiNhanVien)
        {
            this.maNhanVien = maNhanVien;
            this.hoTen = hoTen;
            this.soDienThoai = soDienThoai;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.heSoLuong = heSoLuong;
            this.loaiNhanVien = loaiNhanVien;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public float HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
        public string LoaiNhanVien { get => loaiNhanVien; set => loaiNhanVien = value; }
    }
}
