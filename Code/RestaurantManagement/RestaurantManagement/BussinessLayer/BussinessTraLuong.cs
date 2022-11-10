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

        public bool AddLuong(Luong luong, ref string error)
        {
            string cmd = "dbo.spInsertLuong";
            SqlParameter[] parameters = {
                new SqlParameter("@maNhanVien", luong.MaNhanVien),
                new SqlParameter("@maCaTruc", luong.MaCaTruc),
                new SqlParameter("@soNgayNghi", luong.SoNgayNghi),
                new SqlParameter("@tongLuong", luong.TongLuong)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
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

        public bool DeleteLuong(string maNhanVien, string maCaTruc, ref string error)
        {
            string cmd = "DELETE FROM Luong WHERE maNhanVien = @maNhanVien AND maCaTruc = @maCaTruc";
            SqlParameter[] parameters = {
                new SqlParameter("@maNhanVien", maNhanVien),
                new SqlParameter("@maCaTruc", maCaTruc)
            };
            return connection.MyExecuteNonQuery(cmd, CommandType.Text, ref error, parameters);
        }
    }
}
