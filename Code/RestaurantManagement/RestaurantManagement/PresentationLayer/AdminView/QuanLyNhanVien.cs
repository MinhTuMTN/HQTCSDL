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
    public partial class QuanLyNhanVien : Form
    {
        BussinessNhanVien bussiness = new BussinessNhanVien();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("Lỗi", error);
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
    }
}
