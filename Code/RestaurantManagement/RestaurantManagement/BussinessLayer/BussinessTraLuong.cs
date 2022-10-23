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
    public class BussinessTraLuong
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetAllLuong(ref string error)
        {
            return connection.MyExecuteQueryDataTable("SELECT * FROM viewLuongNhanVien", CommandType.Text, ref error);
        }
    }
}
