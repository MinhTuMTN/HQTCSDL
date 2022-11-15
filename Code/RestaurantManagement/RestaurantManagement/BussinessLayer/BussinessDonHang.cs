using RestaurantManagement.DataAccessLayer;
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
    internal class BussinessDonHang
    {
        DatabaseConnection conn = new DatabaseConnection();
        public DataTable GetAllDonHang(ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT* FROM dbo.DonHang";
            result = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return result;
        }

        public DataTable FindDonHang(ref string error, string text)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.fnSearchDonHang(@text)";
            SqlParameter sqlParameter = new SqlParameter("@text", text);
            result = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public bool AddDonHang(DonHang donHang, ref string error)
        {
            string cmd = "dbo.spInsertDonHang";
            SqlParameter[] parameters =
            {
                
            };
            return conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }
    }
}
