using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class Coupon
    {
        private string maCoupon;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private float phanTramGiam;
        private float giamToiDa;
        private float donToiThieu;

        public Coupon()
        {
        }

        public Coupon(string maCoupon, DateTime ngayBatDau, DateTime ngayKetThuc, float phanTramGiam, float giamToiDa, float donToiThieu)
        {
            this.maCoupon = maCoupon;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.phanTramGiam = phanTramGiam;
            this.giamToiDa = giamToiDa;
            this.donToiThieu = donToiThieu;
        }

        public string MaCoupon { get => maCoupon; set => maCoupon = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public float PhanTramGiam { get => phanTramGiam; set => phanTramGiam = value; }
        public float GiamToiDa { get => giamToiDa; set => giamToiDa = value; }
        public float DonToiThieu { get => donToiThieu; set => donToiThieu = value; }
    }
}
