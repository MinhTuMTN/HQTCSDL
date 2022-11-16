using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class Ban
    {
        private String maBan;
        private String trangThaiBan;
        private int soLuongGheToiDa;
        private String loaiBan;

        public Ban()
        {

        }
        public Ban(string maBan)
        {
            this.maBan = maBan;
        }
        public Ban(string maBan, string trangThaiBan, int soLuongGheToiDa, string loaiBan)
        {
            this.maBan = maBan;
            this.trangThaiBan = trangThaiBan;
            this.soLuongGheToiDa = soLuongGheToiDa;
            this.loaiBan = loaiBan;
        }

        public string MaBan { get => maBan; set => maBan = value; }
        public string TrangThaiBan { get => trangThaiBan; set => trangThaiBan = value; }
        public int SoLuongGheToiDa { get => soLuongGheToiDa; set => soLuongGheToiDa = value; }
        public string LoaiBan { get => loaiBan; set => loaiBan = value; }
    }
}
