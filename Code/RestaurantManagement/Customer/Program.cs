using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string error = "";
            //bool khachHangMoi = false;
            //BusinessDatTruoc business = new BusinessDatTruoc();
            //business.GetMaKhachHang("0743563672", ref khachHangMoi, ref error);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDatTruoc());


        }
    }
}
