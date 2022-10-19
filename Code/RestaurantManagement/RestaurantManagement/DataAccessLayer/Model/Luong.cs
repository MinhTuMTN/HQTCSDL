using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class Luong
    {
        private NhanVien nhanVien;
        private CaTruc caTruc;
        private int soNgayNghi;
        private float tongLuong;

        public Luong()
        {
        }

        public Luong(NhanVien nhanVien, CaTruc caTruc, int soNgayNghi, float tongLuong)
        {
            this.nhanVien = nhanVien;
            this.caTruc = caTruc;
            this.soNgayNghi = soNgayNghi;
            this.tongLuong = tongLuong;
        }

        public NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }
        public CaTruc CaTruc { get => caTruc; set => caTruc = value; }
        public int SoNgayNghi { get => soNgayNghi; set => soNgayNghi = value; }
        public float TongLuong { get => tongLuong; set => tongLuong = value; }
    }
}
