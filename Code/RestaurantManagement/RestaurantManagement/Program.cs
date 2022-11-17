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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmDangNhap());
            Application.Run(new frmQuanLyBanHang("NV330103"));
            //Application.Run(new frmThucHienDonHang("NV220333"));

            /*string error = "";
            //DataTable tabel = new BussinessNhanVien().FindNhanVien("NV", ref error);

            BussinessKhachHang donHang = new BussinessKhachHang();
            donHang.CreateMaKhachHang(ref error);

            new BusinessDonHang().CreateMaDonHang(ref error);*/
        }
    }
}
