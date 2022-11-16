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
    internal class BusinessThanhToan
    {
        DatabaseConnection conn = new DatabaseConnection();
        public DataTable GetChiTietHoaDon(string maBan, ref string error)
        {
            DataTable dt = new DataTable();
            string cmd = "SELECT * FROM fnSearchChiTietHoaDonById(@maBan)";
            SqlParameter parameter = new SqlParameter("@maBan", maBan);
            dt = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
            return dt;
        }

        public float GetPhuThu(string maBan, ref string error)
        {
            float result = 0;
            string cmd = "SELECT dbo.fnGetPhuThu(@maBan)";
            SqlParameter sqlParameter = new SqlParameter("@maBan", maBan);
            result = (float)(double) conn.MyExecuteScalar(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public DataTable GetCouponById (string maCoupon, ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT * FROM dbo.Coupon WHERE maCoupon = @maCoupon";
            SqlParameter sqlParameter = new SqlParameter("@maCoupon", maCoupon);
            table = conn.MyExecuteQueryDataTable (cmd, CommandType.Text, ref error, sqlParameter);
            return table;
        }

        public bool ApDungCoupon(string maBan, string maCoupon, ref string error)
        {
            string cmd = "dbo.spApDungCoupon";
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@maBan",maBan),
                new SqlParameter("@maCoupon",maCoupon) };
            return conn.MyExecuteNonQuery(cmd,CommandType.StoredProcedure,ref error, sqlParameters);
        }

        public bool ThucHienThanhToan(string maBan, string maNhanVienThuNgan, ref string error)
        {
            string cmd = "dbo.spThanhToan";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@maBan",maBan),
                new SqlParameter("@maNhanVienThuNgan", maNhanVienThuNgan)
            };
            if (conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, sqlParameters))
                return true;
            return false;
        }

        public float TongTienThanhToan (string maBan, ref string error)
        {
            float result = 0;
            string cmd = "SELECT dbo.fnTinhTienDonHangTheoMaBan(@maBan)";
            SqlParameter sqlParameter = new SqlParameter("@maBan",maBan);
            result = (float)(double)conn.MyExecuteScalar(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }
    }
}
