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
    public class BussinessTraLuong
    {
        DatabaseConnection connection = new DatabaseConnection();

        public DataTable GetAllLuong(ref string error)
        {
            return connection.MyExecuteQueryDataTable("SELECT * FROM viewLuongNhanVien", CommandType.Text, ref error);
        }

        public DataTable GetDetailLuong(string maCaTruc, string maNhanVien, ref string error)
        {
            DataTable results = new DataTable();

            string cmd = "SELECT * FROM dbo.fnDetailLuong(@maNhanVien, @maCaTruc)";
            SqlParameter[] parameters = { 
                new SqlParameter("@maNhanVien", maNhanVien),
                new SqlParameter("@maCaTruc", maCaTruc)
            };

            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, parameters);
            return results;
        }

        public float TamTinhLuong(string maCaTruc, string maNhanVien, ref string error)
        {
            string cmd = "SELECT dbo.fnTinhLuongTamTinh(@maNhanVien, @maCaTruc)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maNhanVien", maNhanVien),
                new SqlParameter("@maCaTruc", maCaTruc)
            };

            float result = (float)(double)connection.MyExecuteScalar(cmd, CommandType.Text, ref error, parameters);
            return result;
        }

        public bool UpdateLuong(string maCaTruc, string hoTen, int soNgayNghi, ref string error)
        {
            // Cập nhật số ngày nghỉ lên view(viewLuongNhanVien).
            // Từ đó trigger (triggerUpdateLuong) sẽ cập nhật tổng lương
            string cmd = "UPDATE dbo.viewLuongNhanVien SET soNgayNghi=@soNgayNghi WHERE maCaTruc=@maCaTruc AND hoTen=@hoTen";
            SqlParameter[] parameters = {
                new SqlParameter("@hoTen", hoTen),
                new SqlParameter("@maCaTruc", maCaTruc),
                new SqlParameter("@soNgayNghi", soNgayNghi)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.Text, ref error, parameters);
        }

        public DataTable FindLuong(string maCaTruc, DateTime date, string maNhanVien, string hoTen, ref string error)
        {
            DataTable results = new DataTable();
            //string cmd = "SELECT * FROM dbo.fnSearchLuong(@maCaTruc, @date, @hoTen, @maNhanVien)";

            string cmd = "SELECT * FROM dbo.fnSearchLuong(@maCaTruc, @date, @hoTen, @maNhanVien)";

            SqlParameter paramMaCaTruc = new SqlParameter();
            paramMaCaTruc.ParameterName = "@maCaTruc";
            paramMaCaTruc.Value = DBNull.Value;
            if (maCaTruc != null && maCaTruc.Trim() != "")
                paramMaCaTruc.Value = maCaTruc;

            SqlParameter parmDate = new SqlParameter();
            parmDate.SqlDbType = SqlDbType.Date;
            parmDate.ParameterName = "@date";
            parmDate.Value = date.ToString("yyyy-MM-dd");
            if (date == DateTime.MaxValue)
                parmDate.Value = DBNull.Value;

            SqlParameter paramHoTen = new SqlParameter();
            paramHoTen.ParameterName = "@hoTen";
            paramHoTen.Value = DBNull.Value;
            if (hoTen != null && hoTen.Trim() != "")
                paramHoTen.Value = hoTen;

            SqlParameter paramMaNhanVien = new SqlParameter();
            paramMaNhanVien.ParameterName = "@maNhanVien";
            paramMaNhanVien.Value = DBNull.Value;
            if (maNhanVien != null && maNhanVien.Trim() != "")
                paramMaNhanVien.Value = maNhanVien;

            results = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error, paramMaCaTruc, parmDate, paramHoTen, paramMaNhanVien);
            return results;
        }
    }
}
