using RestaurantManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
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
            string cmd = "SELECT TOP(1) maDonHang FROM dbo.DonHang ORDER BY maDonHang DESC";
            string maDonHangMoiNhat = (string)connection.MyExecuteScalar(cmd, System.Data.CommandType.Text, ref error, null);

            int number = int.Parse(maDonHangMoiNhat.Substring(2, maDonHangMoiNhat.Length - 2)) + 1;

            string result = "HD" + number.ToString();
            return result;
        }
    }
}
