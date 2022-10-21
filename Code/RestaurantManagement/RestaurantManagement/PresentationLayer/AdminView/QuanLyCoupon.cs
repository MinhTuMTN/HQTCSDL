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
    public partial class QuanLyCoupon : Form
    {
        BussinessCoupon bussinessCoupon = new BussinessCoupon();
        public QuanLyCoupon()
        {
            InitializeComponent();
        }

        private void QuanLyCoupon_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dtgCoupon.DataSource = bussinessCoupon.GetAllCoupon(ref error);
                if(dtgCoupon.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dtgCoupon_CellClick (sender, ev); 
                }    
                dtgCoupon.Refresh();
            }
            catch
            {
                MessageBox.Show(error);
            }

        }

        private void dtgCoupon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
                return;
            txtMaCoupon.Text = dtgCoupon.Rows[row].Cells["maCoupon"].Value.ToString();
            txtPhanTramGiam.Text = dtgCoupon.Rows[row].Cells["phanTramGiam"].Value.ToString();
            txtDonToiThieu.Text = dtgCoupon.Rows[row].Cells["donToiThieu"].Value.ToString();
            txtGiamToiDa.Text = dtgCoupon.Rows[row].Cells["giamToiDa"].Value.ToString();
            dtpNgayBatDau.Value = (DateTime)dtgCoupon.Rows[row].Cells["ngayBatDau"].Value;
            dtpNgayKetThuc.Value = (DateTime)dtgCoupon.Rows[row].Cells["ngayKetThuc"].Value;
        }
    }
}
