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
    public class BussinessBan
    {
        DatabaseConnection conn = new DatabaseConnection();

        public DataTable GetAllTable (ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT * FROM Ban";
            table = conn.MyExecuteQueryDataTable(cmd, CommandType.Text,ref error);
            return table;
        }

        public DataTable FindBan (string text, ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT * FROM fnSearchBan('@maBan')";
            SqlParameter parameter = new SqlParameter("@maBan", text);
            table = conn.MyExecuteQueryDataTable(cmd, CommandType.Text,ref error, parameter);
            return table;
        }
    }
}
