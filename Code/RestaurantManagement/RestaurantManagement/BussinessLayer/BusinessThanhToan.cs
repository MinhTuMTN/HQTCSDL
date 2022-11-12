using RestaurantManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BussinessLayer
{
    internal class BusinessThanhToan
    {
        DatabaseConnection conn = new DatabaseConnection();
        public DataTable GetChiTietHoaDon(int id, ref string error)
        {
            DataTable dt = new DataTable();
            try
            {
                
            }
            catch(SqlExcetion)
        }
    }
}
