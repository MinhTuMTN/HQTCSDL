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

namespace RestaurantManagement.PresentationLayer.ThuNganView
{
    public partial class frmMainThuNgan : Form
    {
        BusinessThanhToan thanhToan = new BusinessThanhToan();
        public frmMainThuNgan()
        {
            InitializeComponent();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiemThanhToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string error = "";
                string maBan = txtTimKiemThanhToan.Text;
                dtgChiTietDonHang.DataSource = thanhToan.GetChiTietHoaDon(maBan, ref error);
                float phuThu = thanhToan.GetPhuThu(maBan, ref error);
                txtPhuThu.Text = phuThu.ToString();
            }
            catch
            {

            }
            

        }
    }
}
