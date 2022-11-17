using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class BusinessDatTruoc
    {
        DatabaseConnection connection = new DatabaseConnection();

        public string GetMaKhachHang(string soDienThoai, ref bool khachHangMoi, ref string error)
        {
            string maKhachHang = "";
            string cmd = "SELECT * FROM dbo.fnTaoMaKhachHang(@soDienThoai)";
            SqlParameter parameter = new SqlParameter("@soDienThoai", soDienThoai);
            DataTable dtMaKhachHang = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
            if (dtMaKhachHang.Rows.Count == 0)
                return null;

            maKhachHang = dtMaKhachHang.Rows[0][0].ToString().Trim();
            khachHangMoi = bool.Parse(dtMaKhachHang.Rows[0][1].ToString());
            return maKhachHang;
        }

        public DataTable GetBan(int soLuongNguoi, ref string error)
        {
            string cmd = "SELECT maBan FROM dbo.Ban WHERE trangThaiBan = N'Đang có sẵn' AND soLuongGheToiDa >= @soLuongNguoi";
            SqlParameter parameter = new SqlParameter("@soLuongNguoi", soLuongNguoi);
            return connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameter);
        }

        public void DatTruoc(DateTime thoiGianCheckIn, DateTime thoiGianDatTruoc,
                             int soLuongNguoi, string maKhachHang, string maBan, ref string error)
        {
            string cmd = "dbo.spTaoDatTruoc";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@thoiGianCheckIn", thoiGianCheckIn),
                new SqlParameter("@thoiGianDatTruoc", thoiGianDatTruoc),
                new SqlParameter("@soLuongNguoi", soLuongNguoi),
                new SqlParameter("@maKhachHang", maKhachHang),
                new SqlParameter("@maBan", maBan)
            };
            connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public void InsertKhachHangDatTruoc(string maKhachHang, string hoTen, string soDienThoai, DateTime ngaySinh, bool gioiTinh, ref string error)
        {
            string cmd = "dbo.spInsertKhachHangDatTruoc";

            SqlParameter paramMaKhachHang = new SqlParameter("@maKhachHang", maKhachHang);
            SqlParameter paramHoTen = new SqlParameter("@hoTen", hoTen);
            SqlParameter paramSoDienThoai = new SqlParameter("@soDienThoai", soDienThoai);
            SqlParameter paramGioiTinh = new SqlParameter("@gioiTinh", gioiTinh);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ngaySinh";
            parameter.SqlDbType = SqlDbType.Date;
            parameter.Value = ngaySinh.ToString("yyyy-MM-dd");

            connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, paramMaKhachHang, paramHoTen, paramSoDienThoai, paramGioiTinh, parameter);
        }
    }
}
