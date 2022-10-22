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
    public class BussinessCoupon
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetAllCoupon(ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.Coupon";
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return result;
        }

        public bool AddCoupon (Coupon coupon, ref string error)
        {
            string cmd = "dbo.spInsertCoupon";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maCoupon", coupon.MaCoupon),
                new SqlParameter("@ngayBatDau", coupon.NgayBatDau),
                new SqlParameter("@ngayKetThuc", coupon.NgayKetThuc),
                new SqlParameter("@phanTramGiam", coupon.PhanTramGiam),
                new SqlParameter("@giamToiDa", coupon.GiamToiDa),
                new SqlParameter("@donToiThieu", coupon.DonToiThieu)
            };
            return connection.MyExecuteNonQuery(cmd,CommandType.StoredProcedure,ref error,parameters);
        }

        public bool UpdateCoupon (Coupon coupon, ref string error)
        {
            string cmd = "dbo.spUpdateCoupon";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maCoupon", coupon.MaCoupon),
                new SqlParameter("@ngayBatDau", coupon.NgayBatDau),
                new SqlParameter("@ngayKetThuc", coupon.NgayKetThuc),
                new SqlParameter("@phanTramGiam", coupon.PhanTramGiam),
                new SqlParameter("@giamToiDa", coupon.GiamToiDa),
                new SqlParameter("@donToiThieu", coupon.DonToiThieu)
            };
            return connection.MyExecuteNonQuery(cmd,CommandType.StoredProcedure, ref error, parameters);
        }

        public bool DeleteCoupon (string maCoupon, ref string error)
        {
            string cmd = "DELETE FROM dbo.Coupon WHERE maCoupon = @maCoupon";
            SqlParameter sqlParameter = new SqlParameter("@maCoupon", maCoupon);
            return connection.MyExecuteNonQuery(cmd, CommandType.Text, ref error, sqlParameter);
        }

        public DataTable FindCoupon(string text, ref string error)
        {
            DateTime dateTime = new DateTime();
            DataTable results = new DataTable();
            SqlParameter parameter;
            string cmd;
            try
            {
                dateTime = DateTime.Parse(text.Trim());
                                
                cmd = "SELECT * FROM dbo.fnSearchCouponByDate(@date)";
                parameter = new SqlParameter("@date", dateTime);           
            }
            catch
            {
                cmd = "SELECT * FROM dbo.fnSearchCouponByID(@maCoupon)";
                parameter = new SqlParameter("@maCoupon", text.Trim());
            }

            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
            return results;
        }
    }
}
