using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class DatTruoc
    {
        private string maDatTruoc;
        private string trangThaiDatTruoc;
        private DateTime thoiGianDatTruoc;
        private DateTime thoiGianCheckIn;
        private int soLuongNguoi;
        private NhanVien nhanVienTiepNhan;
        private Ban ban;
        private KhachHang khachHang;

        public DatTruoc()
        {
        }

        public DatTruoc(string maDatTruoc, string trangThaiDatTruoc, DateTime thoiGianDatTruoc, DateTime thoiGianCheckIn, int soLuongNguoi, NhanVien nhanVienTiepNhan, Ban ban, KhachHang khachHang)
        {
            this.maDatTruoc = maDatTruoc;
            this.trangThaiDatTruoc = trangThaiDatTruoc;
            this.thoiGianDatTruoc = thoiGianDatTruoc;
            this.thoiGianCheckIn = thoiGianCheckIn;
            this.soLuongNguoi = soLuongNguoi;
            this.nhanVienTiepNhan = nhanVienTiepNhan;
            this.ban = ban;
            this.khachHang = khachHang;
        }

        public string MaDatTruoc { get => maDatTruoc; set => maDatTruoc = value; }
        public string TrangThaiDatTruoc { get => trangThaiDatTruoc; set => trangThaiDatTruoc = value; }
        public DateTime ThoiGianDatTruoc { get => thoiGianDatTruoc; set => thoiGianDatTruoc = value; }
        public DateTime ThoiGianCheckIn { get => thoiGianCheckIn; set => thoiGianCheckIn = value; }
        public int SoLuongNguoi { get => soLuongNguoi; set => soLuongNguoi = value; }
        public NhanVien NhanVienTiepNhan { get => nhanVienTiepNhan; set => nhanVienTiepNhan = value; }
        public Ban Ban { get => ban; set => ban = value; }
        public KhachHang KhachHang { get => khachHang; set => khachHang = value; }
    }
}
