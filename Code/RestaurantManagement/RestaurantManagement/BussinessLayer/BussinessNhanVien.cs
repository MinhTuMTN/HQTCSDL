﻿using RestaurantManagement.DataAccessLayer;
using RestaurantManagement.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BussinessLayer
{
    public class BussinessNhanVien
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetAllNhanVien(ref string error)
        {
            DataTable results = new DataTable();
            results = connection.MyExecuteQueryDataTable("SELECT * FROM NhanVien", CommandType.Text, ref error);
            return results;
        }
        public DataTable GetMaDauBep(ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT maNhanVien FROM dbo.NhanVien WHERE loaiNhanVien = N'Đầu Bếp'";
            table = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return table;
        }

        public DataTable FindNhanVien(string text, ref string error)
        {
            DataTable results = new DataTable();
            string cmd = "SELECT * FROM dbo.fnSearchNhanVien(@text)";
            SqlParameter parameter = new SqlParameter("@text", text);
            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
            return results;
        }

        

        public bool AddNhanVien(NhanVien nhanVien, ref string error)
        {
            string cmd = "dbo.spInsertNhanVien";
            SqlParameter[] parameters = {
                new SqlParameter("@ma", nhanVien.MaNhanVien),
                new SqlParameter("@ten", nhanVien.HoTen),
                new SqlParameter("@ngaySinh", nhanVien.NgaySinh),
                new SqlParameter("@gioiTinh", nhanVien.GioiTinh),
                new SqlParameter("@diaChi", nhanVien.DiaChi),
                new SqlParameter("@SDT", nhanVien.SoDienThoai),
                new SqlParameter("@heSoLuong", nhanVien.HeSoLuong),
                new SqlParameter("@loaiNhanVien", nhanVien.LoaiNhanVien)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool UpdateNhanVien(NhanVien nhanVien, ref string error)
        {
            string cmd = "dbo.spUpdateNhanVien";
            SqlParameter[] parameters = {
                new SqlParameter("@maNhanVien", nhanVien.MaNhanVien),
                new SqlParameter("@hoTen", nhanVien.HoTen),
                new SqlParameter("@ngaySinh", nhanVien.NgaySinh),
                new SqlParameter("@gioiTinh", nhanVien.GioiTinh),
                new SqlParameter("@diaChi", nhanVien.DiaChi),
                new SqlParameter("@soDienThoai", nhanVien.SoDienThoai),
                new SqlParameter("@heSoLuong", nhanVien.HeSoLuong),
                new SqlParameter("@loaiNhanVien", nhanVien.LoaiNhanVien)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool DeleteNhanVien(string maNhanVien, ref string error)
        {
            string cmd = "DELETE FROM NhanVien WHERE maNhanVien = @maNhanVien";
            SqlParameter parameter = new SqlParameter("@maNhanVien", maNhanVien);
            return connection.MyExecuteNonQuery(cmd, CommandType.Text, ref error, parameter);
        }
    }
}
