using RestaurantManagement.DataAccessLayer;
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

        public float GetPhuThu(string maBan, ref string error)
        {
            float result = 0;
            string cmd = "SELECT dbo.fnGetPhuThu(@maBan)";
            SqlParameter sqlParameter = new SqlParameter("@maBan", maBan);
            result = (float)(double) conn.MyExecuteScalar(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public float TienTamTinh (string maBan, ref string error)
        {
            float result = 0;
            string cmd = "";
            return result;
        }
    }
}
