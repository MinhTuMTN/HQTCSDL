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
    public class BussinessKhachHang
    {
        DatabaseConnection connection = new DatabaseConnection();

        public string CreateMaKhachHang(ref string error)
        {
            string cmd = "SELECT TOP(1) maKhachHang FROM dbo.KhachHang ORDER BY SUBSTRING(maKhachHang, 3, LEN(maKhachHang) - 2) DESC";
            string maKhachHangMoiNhat = (string)connection.MyExecuteScalar(cmd, System.Data.CommandType.Text, ref error, null);

            int number = int.Parse(maKhachHangMoiNhat.Substring(2, maKhachHangMoiNhat.Length - 2)) + 1;

            string result = "KH" + number.ToString();
            return result;
        }

        public DataTable GetAllKhachHang(ref string error)
        {
            DataTable results = new DataTable();
            results = connection.MyExecuteQueryDataTable("SELECT * FROM KhachHang", CommandType.Text, ref error);
            return results;
        }
        public string GetMaKhachHangDatTruoc(string maBan, ref string error)
        {
            string cmd = "SELECT maKhachHang FROM dbo.DatTruoc WHERE maBan = @maBan";
            SqlParameter parameter = new SqlParameter("@maBan", maBan);
            string result = (string)connection.MyExecuteScalar(cmd, CommandType.Text, ref error, parameter);
            return result;
        }

        public DataTable FindKhachHang(string text, ref string error)
        {
            DataTable results = new DataTable();
            string cmd = "SELECT * FROM dbo.fnSearchKhachHang(@text)";
            SqlParameter parameter = new SqlParameter("@text", text);
            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
            return results;
        }
        public bool AddKhachHang(KhachHang khachHang, ref string error)
        {
            string cmd = "dbo.spInsertKhachHang";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maKhachHang", khachHang.MaKhachHang)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }
        public bool UpdateKhachHang(KhachHang khachHang, ref string error)
        {
            string cmd = "dbo.spUpdateKhachHang";
            SqlParameter[] parameters = {
                new SqlParameter("@maKhachHang", khachHang.MaKhachHang),
                new SqlParameter("@hoTen", khachHang.HoTen),
                new SqlParameter("@ngaySinh", khachHang.NgaySinh),
                new SqlParameter("@gioiTinh", khachHang.GioiTinh),
                new SqlParameter("@soDienThoai", khachHang.SoDienThoai)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool DeleteKhachHang(string maKhachHang, ref string error)
        {
            string cmd = "DELETE FROM KhachHang WHERE maKhachHang = @maKhachHang";
            SqlParameter parameter = new SqlParameter("@maKhachHang", maKhachHang);
            return connection.MyExecuteNonQuery(cmd, CommandType.Text, ref error, parameter);
        }
    }
}
