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
        private float thue;
        private float phuThu;
        private float soTienThanhToan;
        private string trangThaiHoaDon;
        private Ban ban;
        private NhanVien phucVu;
        private NhanVien thuNgan;
        private NhanVien dauBep;
        private KhachHang khachHang;
        private List<ChiTietHoaDon> dsChiTietHD;

        public HoaDon()
        {
        }

        public HoaDon(string maHoaDon, DateTime thoiGianCheckIn, float thue, float phuThu, float soTienThanhToan, string trangThaiHoaDon, Ban ban, NhanVien phucVu, NhanVien thuNgan, NhanVien dauBep, KhachHang khachHang)
        {
            this.maHoaDon = maHoaDon;
            this.thoiGianCheckIn = thoiGianCheckIn;
            this.thue = thue;
            this.phuThu = phuThu;
            this.soTienThanhToan = soTienThanhToan;
            this.trangThaiHoaDon = trangThaiHoaDon;
            this.ban = ban;
            this.phucVu = phucVu;
            this.thuNgan = thuNgan;
            this.dauBep = dauBep;
            this.khachHang = khachHang;
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime ThoiGianCheckIn { get => thoiGianCheckIn; set => thoiGianCheckIn = value; }
        public float Thue { get => thue; set => thue = value; }
        public float PhuThu { get => phuThu; set => phuThu = value; }
        public float SoTienThanhToan { get => soTienThanhToan; set => soTienThanhToan = value; }
        public string TrangThaiHoaDon { get => trangThaiHoaDon; set => trangThaiHoaDon = value; }
        public Ban Ban { get => ban; set => ban = value; }
        public NhanVien PhucVu { get => phucVu; set => phucVu = value; }
        public NhanVien ThuNgan { get => thuNgan; set => thuNgan = value; }
        public NhanVien DauBep { get => dauBep; set => dauBep = value; }
        public KhachHang KhachHang { get => khachHang; set => khachHang = value; }
        public List<ChiTietHoaDon> DsChiTietHD { get => dsChiTietHD; set => dsChiTietHD = value; }
    }
}
