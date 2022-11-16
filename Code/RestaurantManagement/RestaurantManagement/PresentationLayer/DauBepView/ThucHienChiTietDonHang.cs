using RestaurantManagement.BussinessLayer;
using RestaurantManagement.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement.PresentationLayer.DauBepView
{
    public partial class frmThucHienChiTietDonHang : Form
    {
        BusinessChiTietDonHang businessChiTietDonHang = new BusinessChiTietDonHang();

        string imagesFolderPath = Path.GetDirectoryName(Application.ExecutablePath).Replace("bin\\Debug", "") + @"FoodImages\";
        
        private string maDonHang;
        private frmThucHienDonHang owner;
        public frmThucHienChiTietDonHang(string maDonHang, frmThucHienDonHang owner)
        {
            InitializeComponent();
            this.maDonHang = maDonHang;
            this.owner = owner;
        }

        private void frmThucHienChiTietDonHang_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvChiTietDonHang.DataSource = businessChiTietDonHang.GetAllMonAnTrongDonHang(maDonHang, ref error);

                if (dgvChiTietDonHang.Rows.Count <= 0)
                    return;

                int row = 0;
                string image = imagesFolderPath + dgvChiTietDonHang.Rows[row].Cells["hinhAnh"].Value.ToString().Trim();
                try
                {
                    picMonAn.Load(image);
                }
                catch
                {
                    picMonAn.Load(imagesFolderPath + "food.png");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private void dgvChiTietDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
                return;

            string image = imagesFolderPath + dgvChiTietDonHang.Rows[row].Cells["hinhAnh"].Value.ToString().Trim();
            try
            {
                picMonAn.Load(image);
            }
            catch
            {
                picMonAn.Load(imagesFolderPath + "food.png");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string error = "";

            if (businessChiTietDonHang.UpdateTrangThaiDonHang(maDonHang, ref error))
            {
                MessageBox.Show("Cập nhật trạng thái hóa đơn thành công");
            }
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));

            this.Close();
        }

        private void frmThucHienChiTietDonHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            string error = "";
            try
            {
                owner.RefeshDgvDonHangDauBep();
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
                dgvChiTietDonHang.DataSource = businessChiTietDonHang.FindMonAnTrongDonHang(text, maDonHang, ref error);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }
    }
}
