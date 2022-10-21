using RestaurantManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BussinessLayer
{
    public class BussinessCoupon
    {
        DatabaseConnection conn = new DatabaseConnection();

        public DataTable GetAllCoupon(ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.Coupon";
            result = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return result;
        }
    }
}
