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
            dgvBan.Refresh();

            if (dgvBan.Rows.Count > 0)
                dgvBan_CellClick(null, new DataGridViewCellEventArgs(0, 0));
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            string text = txtTimKiem.Text.Trim();
            try
            {
                dgvBan.DataSource = bussiness.FindBan(text, ref error);
                if (dgvBan.RowCount > 0 )
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvBan_CellClick(sender, ev);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private void HandleDelete(string maBan)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel)
                return;

            string error = "";
            if (bussiness.DeleteBan(maBan, ref error))
                MessageBox.Show("Xóa bàn thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyBan_Load(null, null);
        }

        private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBan.Columns["xoa"].Index && e.RowIndex >= 0)
            {
                string maBan = dgvBan.Rows[e.RowIndex].Cells["maBan"].Value.ToString();
                HandleDelete(maBan);
                return;
            }

            int row = e.RowIndex;
            txtMaBanSua.Text = dgvBan.Rows[row].Cells["maBan"].Value.ToString();
            cbLoaiBanSua.Text = dgvBan.Rows[row].Cells["loaiBan"].Value.ToString();
            cbTrangThaiBanSua.Text = dgvBan.Rows[row].Cells["trangThaiBan"].Value.ToString();
            numSLGheSua.Text = dgvBan.Rows[row].Cells["soLuongGheToiDa"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error = "";
            Ban ban = new Ban(txtMaBanTao.Text.Trim(),cbTrangThaiBanTao.Text,int.Parse(numSLGheTao.Text),cbLoaiBanTao.Text);

            if (bussiness.AddBan(ban, ref error))
                MessageBox.Show("Thêm bàn thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyBan_Load(null, null);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            Ban ban = new Ban(txtMaBanSua.Text.Trim(), cbTrangThaiBanSua.Text, int.Parse(numSLGheSua.Text), cbLoaiBanSua.Text);
            if(bussiness.UpdateBan(ban, ref error))
                 MessageBox.Show("Cập nhật bàn thành công");
            else
                 MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyBan_Load(null, null);
        }
    }
}
