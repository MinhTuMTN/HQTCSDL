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
    public class BussinessMonAn
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetAllMonAn(ref string error)
        {
            DataTable results = new DataTable();
            results = connection.MyExecuteQueryDataTable("SELECT * FROM MonAn", CommandType.Text, ref error);
            return results;
        }

        public bool AddMonAn(MonAn monAn, ref string error)
        {
            string cmd = "dbo.spInsertMonAn";
            SqlParameter[] parameters = {
                new SqlParameter("@maMonAn", monAn.MaMonAn),
                new SqlParameter("@tenMonAn", monAn.TenMonAn),
                new SqlParameter("@giaTien", monAn.GiaTien),
                new SqlParameter("@hinhAnh", monAn.HinhAnh)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }
    }
}
