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
    public class BusinessDangKyCaTruc
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetCaTrucDangKy(string maNhanVien, ref string error)
        {
            string cmd = "SELECT * FROM fnGetCaTrucDK(@maNhanVien)";
            SqlParameter parameter = new SqlParameter("@maNhanVien", maNhanVien);

            return connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
        }

        public DataTable GetCaTrucDaDangKySapDen(string maNhanVien, ref string error)
        {
            string cmd = "SELECT * FROM fnGetCaTrucDaDK(@maNhanVien)";
            SqlParameter parameter = new SqlParameter("@maNhanVien", maNhanVien);

            return connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
        }

        public bool DangKyCaTruc(string maNhanVien, string maCaTruc, ref string error)
        {
            string cmd = "dbo.spInsertDangKyCaTruc";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@maNhanVien", maNhanVien),
                new SqlParameter("@maCaTruc", maCaTruc)
            };

            connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);

            return error != "" ? false : true;
        }
    }
}
