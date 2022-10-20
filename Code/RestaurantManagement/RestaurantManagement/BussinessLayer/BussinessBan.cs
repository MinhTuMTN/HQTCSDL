using RestaurantManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
            table = conn.MyExecuteQueryDataTable("SELECT * FROM Ban", CommandType.Text,ref error);
            return table;
        }

        public DataTable FindBan (ref string error)
        {
            DataTable table = new DataTable();
            return table;
        }
    }
}
