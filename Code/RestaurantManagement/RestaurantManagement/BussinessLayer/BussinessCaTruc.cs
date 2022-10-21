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
    public class BussinessCaTruc
    {
        DatabaseConnection conn = new DatabaseConnection();
        public DataTable GetAllCaTruc (ref string error)
        {
            DataTable caTruc = new DataTable ();
            string cmd = "SELECT * FROM dbo.CaTruc";
            caTruc = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return caTruc;
        }

        public bool AddCaTruc (CaTruc caTruc, ref string error)
        {
            return false;
        }
    }
}
