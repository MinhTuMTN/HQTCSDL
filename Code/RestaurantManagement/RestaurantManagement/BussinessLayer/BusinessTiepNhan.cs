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
    internal class BusinessTiepNhan
    {
        DatabaseConnection conn = new DatabaseConnection();

        public DataTable GetAllTiepNhan(ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.fnLayDanhSachTiepNhan()";
            result = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return result;
        }

        public void ChapNhanDatTruoc(string maDatTruoc, string maNhanVien, ref string error)
        {
            string cmd = "spChapNhanDatTruoc";
            SqlParameter parameter = new SqlParameter("@maDatTruoc", maDatTruoc);
            SqlParameter parameter2 = new SqlParameter("@maNhanVien", maNhanVien);
            conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameter, parameter2);  
        }

        public void TuChoiDatTruoc(string maDatTruoc, string maNhanVien, ref string error)
        {
            string cmd = "spTuChoiDatTruoc";
            SqlParameter parameter = new SqlParameter("@maDatTruoc", maDatTruoc);
            SqlParameter parameter2 = new SqlParameter("@maNhanVien", maNhanVien);
            conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameter, parameter2);
        }
    }
}
