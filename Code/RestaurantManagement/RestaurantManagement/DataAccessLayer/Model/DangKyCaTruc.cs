using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class DangKyCaTruc
    {
        private NhanVien nhanVien;
        private CaTruc caTruc;

        public DangKyCaTruc()
        {
        }

        public DangKyCaTruc(NhanVien nhanVien, CaTruc caTruc)
        {
            this.nhanVien = nhanVien;
            this.caTruc = caTruc;
        }

        public NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }
        public CaTruc CaTruc { get => caTruc; set => caTruc = value; }
    }
}
