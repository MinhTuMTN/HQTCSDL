using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class HoaDon
    {
        private string maHoaDon;
        private DateTime thoiGianCheckIn;
        //private float soTienThanhToan;
        private float phuThu;
        //private string trangThaiHoaDon;
        private string maBan;
        private string maNhanVienPhucVu;
        //private string maNhanVienThuNgan;
        private string maDauBep;
        private string maKhachHang;
        private List<ChiTietHoaDon> dsChiTietHD;

        public HoaDon()
        {
        }

        public HoaDon(string maHoaDon, DateTime thoiGianCheckIn, float phuThu, string maBan, string maNhanVienPhucVu, string maDauBep, string maKhachHang)
        {
            this.maHoaDon = maHoaDon;
            this.thoiGianCheckIn = thoiGianCheckIn;
            //this.thue = thue;
            this.phuThu = phuThu;
            //this.soTienThanhToan = soTienThanhToan;
            //this.trangThaiHoaDon = trangThaiHoaDon;
            this.maBan = maBan;
            this.maNhanVienPhucVu = maNhanVienPhucVu;
            //this.thuNgan = thuNgan;
            this.maDauBep = maDauBep;
            this.maKhachHang = maKhachHang;
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime ThoiGianCheckIn { get => thoiGianCheckIn; set => thoiGianCheckIn = value; }
        //public float Thue { get => thue; set => thue = value; }
        public float PhuThu { get => phuThu; set => phuThu = value; }
        //public float SoTienThanhToan { get => soTienThanhToan; set => soTienThanhToan = value; }
        //public string TrangThaiHoaDon { get => trangThaiHoaDon; set => trangThaiHoaDon = value; }
        public string MaBan { get => maBan; set => maBan = value; }
        public string MaNhanVienPhucVu { get => maNhanVienPhucVu; set => maNhanVienPhucVu = value; }
        //public NhanVien ThuNgan { get => thuNgan; set => thuNgan = value; }
        public string MaDauBep { get => maDauBep; set => maDauBep = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public List<ChiTietHoaDon> DsChiTietHD { get => dsChiTietHD; set => dsChiTietHD = value; }
    }
}
