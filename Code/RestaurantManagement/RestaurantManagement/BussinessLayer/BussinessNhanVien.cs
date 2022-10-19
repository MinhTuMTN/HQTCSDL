using RestaurantManagement.DataAccessLayer;
using RestaurantManagement.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
