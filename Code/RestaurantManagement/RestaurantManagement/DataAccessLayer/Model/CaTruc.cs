using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class CaTruc
    {
        private String maCaTruc;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;

        public CaTruc()
        {

        }

        public CaTruc(string maCaTruc, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.maCaTruc = maCaTruc;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }

        public string MaCaTruc { get => maCaTruc; set => maCaTruc = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
    }
}
