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

namespace RestaurantManagement.AdminController
{
    public partial class QuanLyTaiKhoan : Form
    {
        BusinessTaiKhoan businessTaiKhoan = new BusinessTaiKhoan();
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            dgvTaiKhoan.AutoGenerateColumns = false;
        }

        public void HandleDelete (string maNhanVien)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel)
                return;
            string error = "";
            if (businessTaiKhoan.DeleteTaiKhoan(ref error, maNhanVien))
                MessageBox.Show("Xoá tài khoản thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyTaiKhoan_Load(null, null);
        }
        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            string error = "";
            dgvTaiKhoan.DataSource = businessTaiKhoan.GetAllTaiKhoan(ref error);
            if (dgvTaiKhoan.Rows.Count > 0)
            {
                DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                dgvTaiKhoan_CellClick(sender, ev); 
            }
            dgvTaiKhoan.Refresh();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (e.ColumnIndex == dgvTaiKhoan.Columns["xoa"].Index && row >= 0)
            {
                string maNhanVien = dgvTaiKhoan.Rows[row].Cells["maNhanVien"].Value.ToString();
                HandleDelete(maNhanVien);
                return;
            }
            
            txtMaNhanVienSua.Text = dgvTaiKhoan.Rows[row].Cells["maNhanVien"].Value.ToString();
            txtHoTen.Text = dgvTaiKhoan.Rows[row].Cells["hoTen"].Value.ToString();
            txtTaiKhoanSua.Text = dgvTaiKhoan.Rows[row].Cells["tenDangNhap"].Value.ToString();
            cbTinhTrangSua.Text = dgvTaiKhoan.Rows[row].Cells["trangThaiTaiKhoan"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error = "";
            TaiKhoan taiKhoan = new TaiKhoan(txtTaiKhoanTao.Text.Trim(),
                                             txtMatKhauTao.Text.Trim(),
                                             cbTinhTrangTao.Text,
                                             txtMaNhanVienTao.Text.Trim());
            if (businessTaiKhoan.AddTaiKhoan(taiKhoan, ref error))
                MessageBox.Show("Thêm tài khoản thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyTaiKhoan_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            TaiKhoan taiKhoan = new TaiKhoan(txtTaiKhoanSua.Text.Trim(),
                                             txtMatKhauSua.Text.Trim(),
                                             cbTinhTrangSua.Text,
                                             txtMaNhanVienSua.Text.Trim());
            if (businessTaiKhoan.UpdateTaiKhoan(taiKhoan, ref error))
                MessageBox.Show("Cập nhật khoản thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyTaiKhoan_Load(null, null);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string text = txtTimKiem.Text;
            string error = "";
            dgvTaiKhoan.DataSource = businessTaiKhoan.FindTaiKhoan(ref error, text);
            if (dgvTaiKhoan.Rows.Count > 0)
            {
                DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                dgvTaiKhoan_CellClick(sender, ev);
            }
        }
    }
}
