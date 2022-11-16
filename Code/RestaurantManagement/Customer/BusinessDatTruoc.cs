using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class BusinessDatTruoc
    {
        DatabaseConnection connection = new DatabaseConnection();

        public string GetMaKhachHang(string soDienThoai, ref string error)
        {
            string maKhachHang = "";
            string cmd = "SELECT * FROM fnGetMaKhachHang(@soDienThoai)";
            SqlParameter parameter = new SqlParameter("@soDienThoai", soDienThoai);
            maKhachHang = (string)connection.MyExecuteScalar(cmd, System.Data.CommandType.Text, ref error, parameter);
            
            if(maKhachHang == null)
            {
                cmd = "SELECT * FROM fnGetMaKhachHangMoiNhat";
                maKhachHang = (string)connection.MyExecuteScalar(cmd, System.Data.CommandType.Text, ref error, null);
            }
        }
    }
}
