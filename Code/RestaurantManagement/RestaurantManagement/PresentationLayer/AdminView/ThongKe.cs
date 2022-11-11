using Microsoft.Reporting.WinForms;
using RestaurantManagement.BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "../../PresentationLayer/AdminView/ReportThongKe.rdlc";


            float tongLuong = business.GetTongLuong(ngayBD, ngayKT, ref error);
            ReportParameter[] parameters =
            {
                new ReportParameter("pTongLuong",tongLuong.ToString()),
                new ReportParameter("pNgayBD",ngayBD.Date.ToString()),
                new ReportParameter("pNgayKT",ngayKT.Date.ToString()),
                new ReportParameter("pTongDoanhThu",tongDoanhThu.ToString())
            };
            reportViewer1.LocalReport.SetParameters(parameters);


            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = table;
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportDataSource rds2 = new ReportDataSource();
            rds2.Name = "DoanhThuTheoBan";
            rds2.Value = doanhThuTheoBan;
            reportViewer1.LocalReport.DataSources.Add(rds2);

            this.reportViewer1.RefreshReport();
        }
    }
}
