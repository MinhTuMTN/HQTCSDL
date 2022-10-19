using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class KhachHang
    {
        private string maKhachHang;
        private string hoTen;
        private string soDienThoai;
        private DateTime ngaySinh;
        private bool gioiTinh;

        public KhachHang()
        {
        }

        public KhachHang(string maKhachHang, string hoTen, string soDienThoai, DateTime ngaySinh, bool gioiTinh)
        {
            this.maKhachHang = maKhachHang;
            this.hoTen = hoTen;
            this.soDienThoai = soDienThoai;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
        }

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
