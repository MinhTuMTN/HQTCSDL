﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DataAccessLayer.Model
{
    public class TaiKhoan
    {
        private string tenDangNhap;
        private string matKhau;
        private string trangThaiTaiKhoan;
        private NhanVien nhanVien;

        public TaiKhoan()
        {
        }

        public TaiKhoan(string tenDangNhap, string matKhau, string trangThaiTaiKhoan, NhanVien nhanVien)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.trangThaiTaiKhoan = trangThaiTaiKhoan;
            this.nhanVien = nhanVien;
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string TrangThaiTaiKhoan { get => trangThaiTaiKhoan; set => trangThaiTaiKhoan = value; }
        public NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }
    }
}