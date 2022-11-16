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

namespace RestaurantManagement.PresentationLayer.DauBepView
{
    public partial class frmThucHienDonHang : Form
    {
        BusinessDonHang businessDonHang = new BusinessDonHang();

        private string maDauBepThucHien;
        public frmThucHienDonHang(string maDauBepThucHien)
        {
            InitializeComponent();
            this.maDauBepThucHien = maDauBepThucHien;
        }

        private void frmThucHienDonHang_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvDonHangDauBep.DataSource = businessDonHang.GetHoaDonDauBep(maDauBepThucHien, ref error);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private void dgvDonHangDauBep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maDonHang;
            maDonHang = dgvDonHangDauBep.CurrentRow.Cells["maDonHang"].Value.ToString();

            frmThucHienChiTietDonHang newForm = new frmThucHienChiTietDonHang(maDonHang, this);

            newForm.Show(this);
        }

        public void RefeshDgvDonHangDauBep()
        {
            string error = "";
            try
            {
                dgvDonHangDauBep.DataSource = businessDonHang.GetHoaDonDauBep(maDauBepThucHien, ref error);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string text = txtTimKiem.Text.Trim();
                dgvDonHangDauBep.DataSource = businessDonHang.FindHoaDonDauBep(ref error, text, maDauBepThucHien);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }
    }
}
