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
    public partial class TraLuong : Form
    {
        private float _heSoLuong = 0;
        private float _tamTinh = 0;
        private int _soNgayNghi = 0;
        private float _biTru = 0;
        private float _thanhTien = 0;

        BussinessTraLuong bussiness = new BussinessTraLuong();
        public TraLuong()
        {
            InitializeComponent();
            dtgLuong.AutoGenerateColumns = false;
            txtWarning.Visible = false;
        }

        private void TraLuong_Load(object sender, EventArgs e)
        {
            string error = "";
            this.dtgLuong.DataSource = bussiness.GetAllLuong(ref error);

            if (dtgLuong.Rows.Count > 0)
                dtgLuong_CellClick(null, new DataGridViewCellEventArgs(0, 0));
        }

        private void dtgLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
                return;

            txtHoTen.Text = dtgLuong.Rows[row].Cells["hoTen"].Value.ToString();
            txtMaCaTruc.Text = dtgLuong.Rows[row].Cells["maCaTruc"].Value.ToString();
            txtSoNgayNghi.Text = dtgLuong.Rows[row].Cells["soNgayNghi"].Value.ToString();

            DateTime ngayBatDau = DateTime.Parse(dtgLuong.Rows[row].Cells["ngayBatDau"].Value.ToString());
            DateTime ngayKetThuc = DateTime.Parse(dtgLuong.Rows[row].Cells["ngayKetThuc"].Value.ToString());
            this._heSoLuong = float.Parse(dtgLuong.Rows[row].Cells["heSoLuong"].Value.ToString());
            this._tamTinh = (float)(((ngayKetThuc - ngayBatDau).TotalDays + 1) * this._heSoLuong);
            this._soNgayNghi = int.Parse(dtgLuong.Rows[row].Cells["soNgayNghi"].Value.ToString());
            this._biTru = _soNgayNghi * this._heSoLuong;
            this._thanhTien = _tamTinh - _biTru;

            lblTamTinh.Text = _tamTinh.ToString();

            lblBiTru.Text = _biTru.ToString();

            lblThanhTien.Text = _thanhTien.ToString();
        }

        private void txtSoNgayNghi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _soNgayNghi = int.Parse(txtSoNgayNghi.Text);
                _biTru = _soNgayNghi * _heSoLuong;
                _thanhTien = _tamTinh - _biTru;

                lblBiTru.Text = _biTru.ToString();

                lblThanhTien.Text = _thanhTien.ToString();
                txtWarning.Visible = false;
            }
            catch
            {
                txtWarning.Visible = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                bussiness.UpdateLuong(txtMaCaTruc.Text.Trim(), txtHoTen.Text.Trim(), _soNgayNghi, ref error);
                TraLuong_Load(null, null);
                MessageBox.Show(string.Format("Cập nhật lương thành công cho nhân viên {0}", txtHoTen.Text.Trim()),
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            using(FilterLuong filter = new FilterLuong())
            {
                string error = "";
                try
                {
                    if (filter.ShowDialog() == DialogResult.OK)
                        dtgLuong.DataSource = bussiness.FindLuong(filter.maCaTruc,
                                                                    filter.date,
                                                                    filter.maNhanVien,
                                                                    filter.hoTen,
                                                                    ref error);
                    if (dtgLuong.Rows.Count > 0)
                        dtgLuong_CellClick(null, new DataGridViewCellEventArgs(0, 0));
                }
                catch
                {
                    MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                    
            }
        }
    }
}
