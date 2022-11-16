using RestaurantManagement.BussinessLayer;
using RestaurantManagement.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement.PresentationLayer.StaffView
{
    public partial class frmChiTietDonHang : Form
    {
        BusinessChiTietDonHang businessChiTietDonHang = new BusinessChiTietDonHang();
        BusinessDonHang businessDonHang = new BusinessDonHang();
        string imagesFolderPath = Path.GetDirectoryName(Application.ExecutablePath).Replace("bin\\Debug", "") + @"FoodImages\";
        
        private string maDonHang = "";
        private frmQuanLyBanHang owner;

        public frmChiTietDonHang(string maDonHang, frmQuanLyBanHang owner)
        {
            InitializeComponent();
            this.maDonHang = maDonHang;
            this.owner = owner;
        }

        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvChiTietDonHang.DataSource = businessChiTietDonHang.GetAllMonAnTrongDonHang(maDonHang, ref error);


                DataTable dt = businessChiTietDonHang.GetMonAnChuaCo(maDonHang, ref error);
                List<MonAn> listMonAnChuaCo = new List<MonAn>();
                foreach (DataRow dr in dt.Rows)
                {
                    MonAn monAn = new MonAn();
                    monAn.MaMonAn = dr["maMonAn"].ToString();
                    monAn.TenMonAn = dr["tenMonAn"].ToString();
                    listMonAnChuaCo.Add(monAn);
                }
                cbTenMonAn.DataSource = listMonAnChuaCo;

                cbTenMonAn.DisplayMember = "tenMonAn";
                cbTenMonAn.ValueMember = "maMonAn";

                if (dgvChiTietDonHang.Rows.Count <= 0)
                    return;

                int row = 0;
                string image = imagesFolderPath + dgvChiTietDonHang.Rows[row].Cells["hinhAnh"].Value.ToString().Trim();
                try
                {
                    picMonAn.Load(image);
                }
                catch
                {
                    picMonAn.Load(imagesFolderPath + "food.png");
                }

                numSoLuongMonAnCapNhat.Value = (int)dgvChiTietDonHang.Rows[row].Cells["soLuong"].Value;

            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private void dgvChiTietDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
                return;

            string image = imagesFolderPath + dgvChiTietDonHang.Rows[row].Cells["hinhAnh"].Value.ToString().Trim();
            try
            {
                picMonAn.Load(image);
            }
            catch
            {
                picMonAn.Load(imagesFolderPath + "food.png");
            }

            numSoLuongMonAnCapNhat.Minimum = (int)dgvChiTietDonHang.CurrentRow.Cells["soLuong"].Value;
            numSoLuongMonAnCapNhat.Value = (int)dgvChiTietDonHang.CurrentRow.Cells["soLuong"].Value;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string text = txtTimKiem.Text.Trim();
                dgvChiTietDonHang.DataSource = businessChiTietDonHang.FindMonAnTrongDonHang(text, maDonHang, ref error);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private ChiTietHoaDon GetMonAnTaoFromControls()
        {
            string error = "";
            try
            {
                string maMonAn = cbTenMonAn.SelectedValue.ToString();
                int soLuong = (int)numSoLuongMonAnTao.Value;
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon(maDonHang, maMonAn, soLuong);
                return chiTietHoaDon;

            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
            return null;
        }

        private ChiTietHoaDon GetMonAnCapNhatFromControls()
        {
            string error = "";
            try
            {
                string maMonAn;
                maMonAn = dgvChiTietDonHang.CurrentRow.Cells["maMonAn"].Value.ToString();
                int soLuong = (int)numSoLuongMonAnCapNhat.Value;
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon(maDonHang, maMonAn, soLuong);
                return chiTietHoaDon;

            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
            return null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error = "";
            ChiTietHoaDon chiTietHoaDon = GetMonAnTaoFromControls();
            if (chiTietHoaDon == null)
                return;
            if (businessChiTietDonHang.AddChiTietHoaDon(chiTietHoaDon, ref error))
            {
                MessageBox.Show("Thêm chi tiết hóa đơn thành công");
            }
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));

            numSoLuongMonAnTao.Value = 1;

            frmChiTietDonHang_Load(null, null);
        }


        private void frmChiTietDonHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            string error = "";
            try
            {
                owner.RefeshDgv();
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private void btnResetThem_Click(object sender, EventArgs e)
        {
            numSoLuongMonAnTao.Value = 1;
        }

        private void btnResetTao_Click(object sender, EventArgs e)
        {
            numSoLuongMonAnCapNhat.Value = 1;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string error = "";
            ChiTietHoaDon chiTietHoaDon = GetMonAnCapNhatFromControls();
            if (chiTietHoaDon == null)
                return;
            if (businessChiTietDonHang.UpdateChiTietHoaDon(chiTietHoaDon, ref error))
            {
                MessageBox.Show("Cập nhật chi tiết hóa đơn thành công");
            }
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));

            frmChiTietDonHang_Load(null, null);
        }
    }
}
