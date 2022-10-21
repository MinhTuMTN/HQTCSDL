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
    public partial class QuanLyBan : Form
    {
        BussinessBan bussiness = new BussinessBan();

        public QuanLyBan()
        {
            InitializeComponent();
        }

        private void cbLoaiBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLyBan_Load(object sender, EventArgs e)
        {
            cbLoaiBanTao.SelectedIndex = 0;
            cbTrangThaiBanTao.SelectedIndex = 0;
            string error = "";
            dgvBan.DataSource = bussiness.GetAllTable(ref error);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            string text = txtTimKiem.Text.Trim();
            dgvBan.DataSource = bussiness.FindBan(text, ref error);
            if (dgvBan.RowCount != null)
            {
                DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0,0);
                dgvBan_CellClick(sender, ev);
            }

        }

        private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaBanSua.Text = dgvBan.Rows[row].Cells["maBan"].Value.ToString();
            cbLoaiBanSua.SelectedValue = dgvBan.Rows[row].Cells["loaiBan"].Value;
            cbTrangThaiBanSua.Text= dgvBan.Rows[row].Cells["trangThaiBan"].Value.ToString();
        }
    }
}
