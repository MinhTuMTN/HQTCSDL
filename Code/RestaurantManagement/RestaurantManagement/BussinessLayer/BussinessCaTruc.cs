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
            string cmd = "dbo.spInsertCaTruc";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maCaTruc", caTruc.MaCaTruc),
                new SqlParameter("@ngayBatDau", caTruc.NgayBatDau),
                new SqlParameter("@ngayKetThuc", caTruc.NgayKetThuc)
            };
            return conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool UpdateCaTruc (CaTruc caTruc, ref string error)
        {
            string cmd = "dbo.spUpdateCaTruc";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maCaTruc", caTruc.MaCaTruc),
                new SqlParameter("@ngayBatDau", caTruc.NgayBatDau),
                new SqlParameter("@ngayKetThuc", caTruc.NgayKetThuc)
            };
            return conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool Delete (String maCaTruc, ref string error)
        {
            string cmd = "DELETE FROM CaTruc WHERE maCaTruc = @maCaTruc";
            SqlParameter parameter = new SqlParameter("@maCaTruc", maCaTruc);
            return conn.MyExecuteNonQuery(cmd, CommandType.Text, ref error, parameter);
        }
        
    }
}
