using RestaurantManagement.AdminController;
using RestaurantManagement.AsminController;
using RestaurantManagement.BussinessLayer;
using RestaurantManagement.DataAccessLayer;
using RestaurantManagement.PresentationLayer.AdminView;
using RestaurantManagement.PresentationLayer.ThuNganView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmDangNhap());

            string error = "";
            DatabaseConnection connection = new DatabaseConnection();
            string cmd = "SELECT * FROM dbo.fnSearchMonAnTrongDonHang(@text, @maDonHang)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@text", "Há Cảo"),
                new SqlParameter("@maDonHang", "HD0001")
            };
            DataTable table = connection.MyExecuteQueryDataTable(cmd, CommandType.Text, ref error,parameters);
            table.Reset();
        }
    }
}
