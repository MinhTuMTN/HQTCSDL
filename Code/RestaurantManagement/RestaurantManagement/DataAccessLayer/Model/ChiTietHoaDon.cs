using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class ChiTietHoaDon
    {
        private HoaDon hoaDon;
        private MonAn monAn;
        private int soLuong;

        public ChiTietHoaDon()
        {

        }

        public ChiTietHoaDon(HoaDon hoaDon, MonAn monAn, int soLuong)
        {
            this.hoaDon = hoaDon;
            this.monAn = monAn;
            this.soLuong = soLuong;
        }

        public MonAn MonAn { get => monAn; set => monAn = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        internal HoaDon HoaDon { get => hoaDon; set => hoaDon = value; }
    }
}
