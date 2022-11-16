using RestaurantManagement.AdminController;
using RestaurantManagement.AsminController;
using RestaurantManagement.BussinessLayer;
using RestaurantManagement.DataAccessLayer;
using RestaurantManagement.PresentationLayer.AdminView;
using RestaurantManagement.PresentationLayer.StaffView;
using RestaurantManagement.PresentationLayer.ThuNganView;
using RestaurantManagement.PresentationLayer.DauBepView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagement.PresentationLayer.NhanVienView;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangKyCaTruc());

           
        }
    }
}
