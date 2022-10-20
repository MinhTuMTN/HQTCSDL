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
    public partial class QuanLyNhanVien : Form
    {
        BussinessNhanVien bussiness = new BussinessNhanVien();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvNhanVien.DataSource = bussiness.GetAllNhanVien(ref error);
                dgvNhanVien.Refresh();

                if (dgvNhanVien.RowCount > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvNhanVien_CellClick(sender, ev);    
                }
                    
            }
            catch
            {
            }
            
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaNhanVien.Text = dgvNhanVien.Rows[row].Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
            dtNgaySinh.Value = (DateTime)dgvNhanVien.Rows[row].Cells[2].Value;

            if ((bool)(dgvNhanVien.Rows[row].Cells[3].Value))
                rdbNu.Checked = true;
            else
                rdbNam.Checked = true;

            txtDiaChi.Text = dgvNhanVien.Rows[row].Cells[4].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[row].Cells[5].Value.ToString();
            txtHeSoLuong.Text = dgvNhanVien.Rows[row].Cells[6].Value.ToString();
            cbLoaiNhanVien.Text = (string)dgvNhanVien.Rows[row].Cells[7].Value;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string text = txtSearch.Text.Trim();
                dgvNhanVien.DataSource = bussiness.FindNhanVien(text, ref error);

                if (dgvNhanVien.RowCount > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvNhanVien_CellClick(sender, ev);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool gioiTinh = false;
            float heSoLuong;
            try
            {
                heSoLuong = float.Parse(txtHeSoLuong.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập hệ số lương phù hợp");
                return;
            }

            if (rdbNu.Checked)
                gioiTinh = true;
            string error = "";
            NhanVien nhanVien = new NhanVien(txtMaNhanVien.Text.Trim(),
                                            txtHoTen.Text.Trim(),
                                            txtSoDienThoai.Text.Trim(),
                                            dtNgaySinh.Value,
                                            gioiTinh,
                                            txtDiaChi.Text.Trim(),
                                            heSoLuong,
                                            cbLoaiNhanVien.Text.Trim());
            if (bussiness.AddNhanVien(nhanVien, ref error))
                MessageBox.Show("Thêm nhân viên thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyNhanVien_Load(null, null);
        }
    }
}
