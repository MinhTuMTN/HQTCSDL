using RestaurantManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BussinessLayer
{
    public class BussinessMonAn
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetAllMonAn(ref string error)
        {
            DataTable results = new DataTable();
            results = connection.MyExecuteQueryDataTable("SELECT * FROM MonAn", CommandType.Text, ref error);
            return results;
        }
    }
}
