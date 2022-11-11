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


            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "../../PresentationLayer/AdminView/ReportThongKe.rdlc";


            //float tamTinh = bussiness.TamTinhLuong(maCaTruc, maNhanVien, ref error);
            //ReportParameter[] parameters =
            //{
            //    new ReportParameter("pTamTinh",tamTinh.ToString())
            //};
            //reportViewer1.LocalReport.SetParameters(parameters);

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
