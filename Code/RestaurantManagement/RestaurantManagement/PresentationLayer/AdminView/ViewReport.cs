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
    public partial class ViewReport : Form
    {
        private string maNhanVien;
        private string maCaTruc;
        public ViewReport(string maNhanVien, string maCaTruc)
        {
            InitializeComponent();

            this.maNhanVien = maNhanVien;
            this.maCaTruc = maCaTruc;  
        }

        private void ViewReport_Load(object sender, EventArgs e)
        {
            BussinessTraLuong bussiness = new BussinessTraLuong();
            string error = "";
            DataTable table = bussiness.GetDetailLuong(maCaTruc, maNhanVien, ref error);


            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "../../PresentationLayer/AdminView/ReportLuong.rdlc";


            float tamTinh = bussiness.TamTinhLuong(maCaTruc, maNhanVien, ref error);
            ReportParameter[] parameters =
            {
                new ReportParameter("pTamTinh",tamTinh.ToString())
            };
            reportViewer1.LocalReport.SetParameters(parameters);

            //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = table;
            //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
            reportViewer1.LocalReport.DataSources.Clear();
            //Add dữ liệu vào báo cáo
            reportViewer1.LocalReport.DataSources.Add(rds);
           
           

            this.reportViewer1.RefreshReport();
        }
    }
}
