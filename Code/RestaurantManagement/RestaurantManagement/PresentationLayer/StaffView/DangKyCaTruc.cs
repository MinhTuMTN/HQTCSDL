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

namespace RestaurantManagement.PresentationLayer.StaffView
{
    public partial class DangKyCaTruc : Form
    {
        BusinessDangKyCaTruc business = new BusinessDangKyCaTruc();
        private string _maCaTruc;
        private string maNhanVien;
        public DangKyCaTruc(string maNhanVien)
        {
            InitializeComponent();
            this.maNhanVien = maNhanVien;
            LoadCaTruc();
        }

        private void LoadCaTruc()
        {
            string error = "";
            dgvCaTruc.DataSource = business.GetCaTrucDangKy(maNhanVien, ref error);

            if (dgvCaTruc.Rows.Count > 0)
                dgvCaTruc_CellClick(null, new DataGridViewCellEventArgs(0,0));

            dgvCaTrucDaDangKy.DataSource = business.GetCaTrucDaDangKySapDen(maNhanVien, ref error);
        }

        private void dgvCaTruc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null || e.RowIndex < 0)
                return;

            string maCaTrucText = dgvCaTruc.Rows[e.RowIndex].Cells["maCaTruc"].Value.ToString().Trim();
            this._maCaTruc = maCaTrucText;

            lblMaCaTruc.Text = maCaTrucText;
            lblNgayBatDau.Text = dgvCaTruc.Rows[e.RowIndex].Cells["ngayBatDau"].Value.ToString();
            lblNgayKetThuc.Text = dgvCaTruc.Rows[e.RowIndex].Cells["ngayKetThuc"].Value.ToString();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string error = "";
            if(business.DangKyCaTruc(maNhanVien, _maCaTruc, ref error))
                MessageBox.Show("Đăng ký ca trực thành công!", "Thành công",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Đã xảy ra lỗi. Vui lòng thử lại!", "Lỗi",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
