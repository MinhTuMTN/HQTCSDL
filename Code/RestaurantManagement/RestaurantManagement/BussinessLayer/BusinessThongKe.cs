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
    public class BusinessThongKe
    {
        DatabaseConnection connection = new DatabaseConnection();

        SqlParameter parmNgayBD = new SqlParameter();
        SqlParameter parmNgayKT = new SqlParameter();

        private void InitParameter(DateTime ngayBD, DateTime ngayKT)
        {
            parmNgayBD.SqlDbType = SqlDbType.Date;
            parmNgayBD.ParameterName = "@ngayBD";
            parmNgayBD.Value = ngayBD.ToString("yyyy-MM-dd");

            parmNgayKT.SqlDbType = SqlDbType.Date;
            parmNgayKT.ParameterName = "@ngayKT";
            parmNgayKT.Value = ngayKT.ToString("yyyy-MM-dd");
        }

        public DataTable GetThongKeLuong(DateTime ngayBD, DateTime ngayKT, ref string error)
        {
            DataTable results = new DataTable();

            string cmd = "SELECT * FROM fnThongKeLuong(@ngayBD, @ngayKT)";

            InitParameter(ngayBD, ngayKT);
       
            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parmNgayBD, parmNgayKT);
            return results;
        }

        public float GetTongLuong(DateTime ngayBD, DateTime ngayKT, ref string error)
        {
            string cmd = "SELECT SUM(tongLuong) FROM fnThongKeLuong(@ngayBD, @ngayKT)";

            InitParameter(ngayBD, ngayKT);

            float result = (float)(double)connection.MyExecuteScalar(cmd, CommandType.Text, ref error, parmNgayBD, parmNgayKT);
            return result;
        }

        public DataTable GetThongKeDoanhThuTheoBan(DateTime ngayBD, DateTime ngayKT, ref string error)
        {
            DataTable results = new DataTable();

            string cmd = "SELECT * FROM fnThongKeDoanhThuTheoBan(@ngayBD, @ngayKT)";

            InitParameter(ngayBD, ngayKT);

            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parmNgayBD, parmNgayKT);
            return results;
        }

        public float GetTongDoanhThu(DateTime ngayBD, DateTime ngayKT, ref string error)
        {
            string cmd = "SELECT SUM(soTien) FROM fnThongKeDoanhThuTheoBan(@ngayBD, @ngayKT)";

            InitParameter(ngayBD, ngayKT);

            float result = (float)(double)connection.MyExecuteScalar(cmd, CommandType.Text, ref error, parmNgayBD, parmNgayKT);
            return result;
        }
    }
}
