using Microsoft.Reporting.WinForms;
using RestaurantManagement.BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement.PresentationLayer.AdminView
{
    public partial class ThongKe : Form
    {
        BusinessThongKe business = new BusinessThongKe();
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime ngayBD = dtNgayBD.Value;
            DateTime ngayKT = dtNgayKT.Value;

            string error = "";
            DataTable table = business.GetThongKeLuong(ngayBD, ngayKT, ref error);


            DataTable doanhThuTheoBan = business.GetThongKeDoanhThuTheoBan(ngayBD, ngayKT, ref error);
            float tongDoanhThu = business.GetTongDoanhThu(ngayBD, ngayKT, ref error);

            DataTable monAnBanChay = business.GetMonAnBanChay(ngayBD, ngayKT, ref error);
            float tongLuong = business.GetTongLuong(ngayBD, ngayKT, ref error);


            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "../../PresentationLayer/AdminView/ReportThongKe.rdlc";


            string foodImage = Path.GetDirectoryName(Application.ExecutablePath).Replace("bin\\Debug", "")
                + @"FoodImages\" + monAnBanChay.Rows[0][2];

            reportViewer1.LocalReport.EnableExternalImages = true;
            var setup = reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(4, 4, 4, 4);
            reportViewer1.SetPageSettings(setup);

            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = table;
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportDataSource rds2 = new ReportDataSource();
            rds2.Name = "DoanhThuTheoBan";
            rds2.Value = doanhThuTheoBan;
            reportViewer1.LocalReport.DataSources.Add(rds2);

            ReportDataSource rds3 = new ReportDataSource();
            rds3.Name = "MonAn";
            rds3.Value = monAnBanChay;
            reportViewer1.LocalReport.DataSources.Add(rds3);

            
            ReportParameter[] parameters =
            {
                new ReportParameter("pTongLuong",tongLuong.ToString()),
                new ReportParameter("pNgayBD",ngayBD.Date.ToString()),
                new ReportParameter("pNgayKT",ngayKT.Date.ToString()),
                new ReportParameter("pTongDoanhThu",tongDoanhThu.ToString()),
                new ReportParameter("pFoodImage", foodImage)
            };
            reportViewer1.LocalReport.SetParameters(parameters);

            

            this.reportViewer1.RefreshReport();
        }
    }
}
