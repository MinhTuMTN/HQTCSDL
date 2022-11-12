﻿using RestaurantManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BussinessLayer
{
    internal class BusinessThanhToan
    {
        DatabaseConnection conn = new DatabaseConnection();
        public DataTable GetChiTietHoaDon(string maBan, ref string error)
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT * FROM fnSearchChiTietHoaDonById(@maBan)";
            SqlParameter parameter = new SqlParameter("@maBan", maBan);
            dt = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
            return dt;
        }
    }
}
