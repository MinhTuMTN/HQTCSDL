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
    public class BussinessBan
    {
        DatabaseConnection conn = new DatabaseConnection();

        public DataTable GetAllTable (ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT * FROM Ban";
            table = conn.MyExecuteQueryDataTable(cmd, CommandType.Text,ref error);
            return table;
        }

        public DataTable GetMaBanThuong(ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT maBan FROM dbo.Ban WHERE trangThaiBan = N'Đang có sẵn'";
            table = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return table;
        }

        public DataTable GetMaBanDatTruoc(ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT maBan FROM dbo.Ban WHERE trangThaiBan = N'Đã đặt trước'";
            table = conn.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error);
            return table;
        }

        public DataTable FindBan (string text, ref string error)
        {
            DataTable table = new DataTable();
            string cmd = "SELECT * FROM fnSearchBan('@maBan')";
            SqlParameter parameter = new SqlParameter("@maBan", text);
            table = conn.MyExecuteQueryDataTable(cmd, CommandType.Text,ref error, parameter);
            return table;
        }

        public bool AddBan(Ban ban, ref string error)
        {
            string cmd = "dbo.spInsertBan";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maBan", ban.MaBan),
                new SqlParameter("@trangThaiBan", ban.TrangThaiBan),
                new SqlParameter("@loaiBan", ban.LoaiBan),
                new SqlParameter("@soLuongGheToiDa", ban.SoLuongGheToiDa)
            };
            return conn.MyExecuteNonQuery(cmd, CommandType.StoredProcedure, ref error, parameters);
        }

        public bool UpdateBan(Ban ban, ref string error)
        {
            string cmd = "dbo.spUpdateBan";
            SqlParameter[] parameters =
            {
                new SqlParameter("@maBan", ban.MaBan),
                new SqlParameter("@trangThaiBan", ban.TrangThaiBan),
                new SqlParameter("@loaiBan", ban.LoaiBan),
                new SqlParameter("@soLuongGheToiDa", ban.SoLuongGheToiDa)
            };
            return conn.MyExecuteNonQuery(cmd,CommandType.StoredProcedure, ref error, parameters);
        }

        public bool DeleteBan(string maBan, ref string error)
        {
            string cmd = "DELETE FROM Ban WHERE maBan = @maBan";
            SqlParameter parameter = new SqlParameter("@maBan", maBan);
            return conn.MyExecuteNonQuery(cmd, CommandType.Text, ref error, parameter);
        }
    }
}
