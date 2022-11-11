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
    public class BusinessThongKe
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetThongKeLuong(DateTime ngayBD, DateTime ngayKT, ref string error)
        {
            DataTable results = new DataTable();

            string cmd = "SELECT * FROM spThongKeLuong(@ngayBD, @ngayKT)";

            SqlParameter parmNgayBD = new SqlParameter();
            parmNgayBD.SqlDbType = SqlDbType.Date;
            parmNgayBD.ParameterName = "@ngayBD";
            parmNgayBD.Value = ngayBD.ToString("yyyy-MM-dd");

            SqlParameter parmNgayKT = new SqlParameter();
            parmNgayKT.SqlDbType = SqlDbType.Date;
            parmNgayKT.ParameterName = "@ngayKT";
            parmNgayKT.Value = ngayKT.ToString("yyyy-MM-dd");

            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parmNgayBD, parmNgayKT);
            return results;
        }
    }
}
