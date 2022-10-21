using RestaurantManagement.BussinessLayer;
using RestaurantManagement.DataAccessLayer.Model;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error = "";
            Coupon coupon = new Coupon(txtMaCoupon.Text.Trim(), (DateTime)dtpNgayBatDau.Value, (DateTime)dtpNgayKetThuc.Value, float.Parse(txtPhanTramGiam.Text), float.Parse(txtGiamToiDa.Text), float.Parse(txtDonToiThieu.Text));

            if (bussinessCoupon.AddCoupon(coupon, ref error))
                MessageBox.Show("Thêm coupon thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyCoupon_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            Coupon coupon = new Coupon(txtMaCoupon.Text.Trim(), (DateTime)dtpNgayBatDau.Value, (DateTime)dtpNgayKetThuc.Value, float.Parse(txtPhanTramGiam.Text), float.Parse(txtGiamToiDa.Text), float.Parse(txtDonToiThieu.Text));

            if (bussinessCoupon.UpdateCoupon(coupon, ref error))
                MessageBox.Show("Cập nhật coupon thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyCoupon_Load(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa coupon này không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel)
                return;
            string error = "";
            string maCoupon = txtMaCoupon.Text.Trim();
            if (bussinessCoupon.DeleteCoupon(maCoupon, ref error))
                MessageBox.Show("Xoá coupon thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyCoupon_Load(null, null);

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";

        }
    }
}
