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
    internal class BusinessChiTietDonHang
    {
        DatabaseConnection connection = new DatabaseConnection();
        public DataTable GetAllMonAnTrongDonHang(string maDonHang, ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT ChiTietDonHang.maMonAn, tenMonAn, soLuong, giaTien, hinhAnh FROM dbo.ChiTietDonHang, dbo.MonAn WHERE maDonHang = @maDonHang AND ChiTietDonHang.maMonAn = MonAn.maMonAn";
            SqlParameter sqlParameter = new SqlParameter("@maDonHang", maDonHang);
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public DataTable FindMonAnTrongDonHang(string text, string maDonHang, ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * FROM dbo.fnSearchMonAnTrongDonHang(@text, @maDonHang)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@text", text),
                new SqlParameter("@maDonHang", maDonHang)
            };
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameters);
            return result;
        }

        public DataTable GetMonAnChuaCo(string maDonHang, ref string error)
        {
            DataTable result = new DataTable();
            string cmd = "SELECT * from dbo.fnLayDanhSachMonAnChuaCo(@maDonHang)";
            SqlParameter sqlParameter = new SqlParameter("@maDonHang", maDonHang);
            result = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, sqlParameter);
            return result;
        }

        public bool AddChiTietHoaDon(ChiTietHoaDon chiTietHoaDon, ref string error)
        {
            string cmd = "dbo.spInsertChiTietDonHang";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maDonHang", chiTietHoaDon.MaHoaDon),
                new SqlParameter("@maMonAn", chiTietHoaDon.MaMonAn),
                new SqlParameter("@soLuong", chiTietHoaDon.SoLuong),
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool UpdateChiTietHoaDon(ChiTietHoaDon chiTietHoaDon, ref string error)
        {
            string cmd = "dbo.spUpdateChiTietDonHang";
            SqlParameter[] parameters = {
                new SqlParameter("@maDonHang", chiTietHoaDon.MaHoaDon),
                new SqlParameter("@maMonAn", chiTietHoaDon.MaMonAn),
                new SqlParameter("@soLuong", chiTietHoaDon.SoLuong),
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }
    }
}
