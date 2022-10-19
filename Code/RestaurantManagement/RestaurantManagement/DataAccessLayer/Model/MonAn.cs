using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class MonAn
    {
        private string maMonAn;
        private string tenMonAn;
        private float giaTien;
        private string hinhAnh;

        public MonAn()
        {
        }

        public MonAn(string maMonAn, string tenMonAn, float giaTien, string hinhAnh)
        {
            this.maMonAn = maMonAn;
            this.tenMonAn = tenMonAn;
            this.giaTien = giaTien;
            this.hinhAnh = hinhAnh;
        }

        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string MaMonAn { get => maMonAn; set => maMonAn = value; }
        public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }
        public float GiaTien { get => giaTien; set => giaTien = value; }
    }
}
