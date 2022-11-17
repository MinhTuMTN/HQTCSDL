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
    public partial class QuanLyCaTruc : Form
    {
        BussinessCaTruc bussinessCaTruc = new BussinessCaTruc();
        public QuanLyCaTruc()
        {
            InitializeComponent();
        }

        private void QuanLyCaTruc_Load(object sender, EventArgs e)
        {
            string error = "";
            dgvCaTruc.DataSource = bussinessCaTruc.GetAllCaTruc(ref error);
            dgvCaTruc.Refresh();
        }

        private void dgvCaTruc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            txtMaCaTrucSua.Text = dgvCaTruc.Rows[row].Cells["maCaTruc"].Value.ToString();
            dtpNgayBatDauSua.Value = (DateTime)dgvCaTruc.Rows[row].Cells["ngayBatDau"].Value;
            dtpNgayKetThucSua.Value = (DateTime)dgvCaTruc.Rows[row].Cells["ngayKetThuc"].Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error = "";
            CaTruc caTruc = new CaTruc(txtMaCaTrucTao.Text.Trim(), (DateTime)dtpNgayBatDauTao.Value, (DateTime)dtpNgayKetThucTao.Value);
            if (bussinessCaTruc.AddCaTruc(caTruc, ref error))
                MessageBox.Show("Thêm ca trực thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));

            QuanLyCaTruc_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            CaTruc caTruc = new CaTruc(txtMaCaTrucSua.Text.Trim(), (DateTime)dtpNgayBatDauSua.Value, (DateTime)dtpNgayKetThucSua.Value);
            if (bussinessCaTruc.UpdateCaTruc(caTruc, ref error))
                MessageBox.Show("Sửa ca trực thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));

            QuanLyCaTruc_Load(null, null);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string text = txtTimKiem.Text.Trim();
                dgvCaTruc.DataSource = bussinessCaTruc.FindCaTruc(text, ref error);

                if (dgvCaTruc.RowCount > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvCaTruc_CellClick(sender, ev);
                }

            }
            catch
            {
            }
        }
    }
}
