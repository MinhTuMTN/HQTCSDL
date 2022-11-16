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
    
    public class BusinessDonHang
    {
        DatabaseConnection connection = new DatabaseConnection();

        public string CreateMaDonHang(ref string error)
        {
            string cmd = "SELECT TOP(1) maDonHang FROM dbo.DonHang ORDER BY SUBSTRING(maDonHang, 3, LEN(maDonHang) - 2) DESC";
            string maDonHangMoiNhat = (string)connection.MyExecuteScalar(cmd, System.Data.CommandType.Text, ref error, null);

            int number = int.Parse(maDonHangMoiNhat.Substring(2, maDonHangMoiNhat.Length - 2)) + 1;

            string result = "HD" + number.ToString();
            return result;
        }
        public DataTable GetAllHoaDon(ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT* FROM dbo.DonHang";
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return result;
        }

        public DataTable GetHoaDonDauBep(string maDauBep, ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT* FROM dbo.fnLayDanhSachDonHangDauBep(@maDauBep)";
            SqlParameter sqlParameter = new SqlParameter("@maDauBep", maDauBep);
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public bool AddHoaDon(HoaDon hoaDon, ref string error)
        {
            string cmd = "dbo.spInsertDonHang";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maDonHang", hoaDon.MaHoaDon),
                new SqlParameter("@thoiGianCheckIn", hoaDon.ThoiGianCheckIn),
                new SqlParameter("@phuThu", hoaDon.PhuThu),
                new SqlParameter("@maBan", hoaDon.MaBan),
                new SqlParameter("@maKhachHang", hoaDon.MaKhachHang),
                new SqlParameter("@maDauBep", hoaDon.MaDauBep),
                new SqlParameter("@maNhanVienPhucVu", hoaDon.MaNhanVienPhucVu)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }
        public DataTable FindHoaDon(ref string error, string text)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.fnSearchDonHang(@text)";
            SqlParameter sqlParameter = new SqlParameter("@text", text);
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public DataTable FindHoaDonDauBep(ref string error, string text, string maDauBep)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.fnSearchDonHangDauBep(@text, @maDauBep)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@text", text),
                new SqlParameter("@maDauBep", maDauBep)
            };
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameters);
            return result;
        }
    }
}
