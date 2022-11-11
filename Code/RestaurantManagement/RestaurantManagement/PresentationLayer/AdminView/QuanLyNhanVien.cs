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
            if (row < 0)
                return;

            txtMaNhanVien.Text = dgvNhanVien.Rows[row].Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
            dtNgaySinh.Value = (DateTime)dgvNhanVien.Rows[row].Cells[2].Value;

            if ((bool)(dgvNhanVien.Rows[row].Cells[3].Value))
                rdbNu.Checked = true;
            else
                rdbNam.Checked = true;

            txtDiaChi.Text = dgvNhanVien.Rows[row].Cells[4].Value.ToString();
            txtSoDienThoai.Text = dgvNhanVien.Rows[row].Cells[5].Value.ToString();
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

        private NhanVien GetNhanVienFromControls()
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
                return null;
            }

            if (rdbNu.Checked)
                gioiTinh = true;
            NhanVien nhanVien = new NhanVien(txtMaNhanVien.Text.Trim(),
                                           txtHoTen.Text.Trim(),
                                           txtSoDienThoai.Text.Trim(),
                                           dtNgaySinh.Value,
                                           gioiTinh,
                                           txtDiaChi.Text.Trim(),
                                           heSoLuong,
                                           cbLoaiNhanVien.Text.Trim());
            return nhanVien;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error = "";
            NhanVien nhanVien = GetNhanVienFromControls();
            if (nhanVien == null)
                return;

            if (bussiness.AddNhanVien(nhanVien, ref error))
                MessageBox.Show("Thêm nhân viên thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyNhanVien_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            NhanVien nhanVien = GetNhanVienFromControls();
            if (nhanVien == null)
                return;

            if (bussiness.UpdateNhanVien(nhanVien, ref error))
                MessageBox.Show("Chỉnh sửa thông tin nhân viên thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyNhanVien_Load(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =  MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel)
                return;
            
            string error = "";
            string maNhanVien = txtMaNhanVien.Text.Trim();
            if (maNhanVien == null)
                return;

            if(bussiness.DeleteNhanVien(maNhanVien, ref error))
                MessageBox.Show("Xóa nhân viên thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyNhanVien_Load(null, null);

        }
    }
}
