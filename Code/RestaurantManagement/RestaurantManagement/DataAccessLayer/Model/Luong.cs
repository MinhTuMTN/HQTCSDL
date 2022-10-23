using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class Luong
    {
        private string maNhanVien;
        private string maCaTruc;
        private int soNgayNghi;
        private float tongLuong;

        public Luong()
        {
        }

        public Luong(string maNhanVien, string maCaTruc, int soNgayNghi, float tongLuong)
        {
            this.maNhanVien = maNhanVien;
            this.maCaTruc = maCaTruc;
            this.soNgayNghi = soNgayNghi;
            this.tongLuong = tongLuong;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaCaTruc { get => maCaTruc; set => maCaTruc = value; }
        public int SoNgayNghi { get => soNgayNghi; set => soNgayNghi = value; }
        public float TongLuong { get => tongLuong; set => tongLuong = value; }
    }
}
