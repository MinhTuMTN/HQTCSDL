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
    public partial class QuanLyKhachHang : Form
    {
        BussinessKhachHang bussiness = new BussinessKhachHang();
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvKhachHang.DataSource = bussiness.GetAllKhachHang(ref error);
                dgvKhachHang.Refresh();

                if (dgvKhachHang.RowCount > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvKhachHang_CellClick(sender, ev);
                }

            }
            catch
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            bool gioiTinh = false;
            if (rdbNu.Checked)
                gioiTinh = true;

            KhachHang khachHang = new KhachHang(txtMaKhachHang.Text.Trim(),
                                                txtHoTen.Text.Trim(),
                                                txtSDT.Text.Trim(),
                                                dtpNgaySinh.Value,
                                                gioiTinh);
            if (bussiness.UpdateKhachHang(khachHang, ref error))
                MessageBox.Show("Chỉnh sửa thông tin khách hàng thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyKhachHang_Load(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel)
                return;

            string error = "";
            string maKhachHang = txtMaKhachHang.Text.Trim();
            if (maKhachHang == null)
                return;

            if (bussiness.DeleteKhachHang(maKhachHang, ref error))
                MessageBox.Show("Xóa khách hàng thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyKhachHang_Load(null, null);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
                return;

            if ((bool)(dgvKhachHang.Rows[row].Cells["gioiTinh"].Value))
                rdbNu.Checked = true;
            else
                rdbNam.Checked = true;

            txtMaKhachHang.Text = dgvKhachHang.Rows[row].Cells["maKhachHang"].Value.ToString();
            txtHoTen.Text = dgvKhachHang.Rows[row].Cells["hoTen"].Value.ToString();
            dtpNgaySinh.Value = (DateTime)(dgvKhachHang.Rows[row].Cells["ngaySinh"].Value);
            txtSDT.Text = dgvKhachHang.Rows[row].Cells["soDienThoai"].Value.ToString();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string text = txtTimKiem.Text.Trim();
                dgvKhachHang.DataSource = bussiness.FindKhachHang(text, ref error);

                if (dgvKhachHang.RowCount > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvKhachHang_CellClick(sender, ev);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }
    }
}
