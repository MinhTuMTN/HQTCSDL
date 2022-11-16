using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class ChiTietHoaDon
    {
        private string maHoaDon;
        private string maMonAn;
        private int soLuong;

        public ChiTietHoaDon()
        {

        }

        public ChiTietHoaDon(string maHoaDon, string maMonAn, int soLuong)
        {
            this.maHoaDon = maHoaDon;
            this.maMonAn = maMonAn;
            this.soLuong = soLuong;
        }

        public string MaMonAn { get => maMonAn; set => maMonAn = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
    }
}
