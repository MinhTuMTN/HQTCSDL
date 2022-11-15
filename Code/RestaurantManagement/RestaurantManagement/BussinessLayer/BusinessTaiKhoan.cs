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
    public class BusinessTaiKhoan
    {
        DatabaseConnection conn = new DatabaseConnection();
        public DataTable GetAllTaiKhoan (ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT* FROM dbo.viewTaiKhoanNhanVien";
            result = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return result;
        }

        public bool AddTaiKhoan (TaiKhoan taiKhoan, ref string error)
        {
            string cmd = "dbo.spInsertTaiKhoan";
            SqlParameter[] parameters =
            {
                new SqlParameter("@tenDangNhap", taiKhoan.TenDangNhap),
                new SqlParameter("@matKhau", taiKhoan.MatKhau),
                new SqlParameter("@trangThaiTaiKhoan", taiKhoan.TrangThaiTaiKhoan),
                new SqlParameter("@maNhanVien", taiKhoan.MaNhanVien)
            };
            return conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool UpdateTaiKhoan (TaiKhoan taiKhoan, ref string error)
        {
            string cmd = "dbo.spUpdateTaiKhoan";
            SqlParameter[] parameters =
            {
                new SqlParameter("@tenDangNhap", taiKhoan.TenDangNhap),
                new SqlParameter("@matKhau", taiKhoan.MatKhau),
                new SqlParameter("@trangThaiTaiKhoan", taiKhoan.TrangThaiTaiKhoan)
            };
            return conn.MyExecuteNonQuery(cmd,CommandType.StoredProcedure, ref error, parameters);
        }

        public DataTable FindTaiKhoan (ref string error, string text)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.fnSearchTaiKhoan(@text)";
            SqlParameter sqlParameter = new SqlParameter("@text", text);
            result = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public bool DeleteTaiKhoan (ref string error, string maNhanVien)
        {
            string cmd = "DELETE FROM dbo.TaiKhoan WHERE maNhanVien = @maNhanVien";
            SqlParameter parameter = new SqlParameter("@maNhanVien", maNhanVien);
            return conn.MyExecuteNonQuery(cmd,CommandType.Text, ref error, parameter);
        }
    }
}
