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

namespace RestaurantManagement.PresentationLayer.StaffView
{
    public partial class frmQuanLyBanHang : Form
    {
        BusinessDonHang businessDonHang = new BusinessDonHang();
        BussinessBan businessBan = new BussinessBan();
        BussinessKhachHang businessKhachHang = new BussinessKhachHang();
        BussinessNhanVien businessNhanVien = new BussinessNhanVien();

        private string maPhucVu;
        public frmQuanLyBanHang(string maPhucVu)
        {
            InitializeComponent();
            rdbThuong.Checked = true;
            this.maPhucVu = maPhucVu;
        }

        public void RefeshDgvDonHang()
        {
            string error = "";
            try
            {
                dgvDonHang.DataSource = businessDonHang.GetAllHoaDon(ref error);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }
        private void frmQuanLyBanHang_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvDonHang.DataSource = businessDonHang.GetAllHoaDon(ref error);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string text = txtTimKiem.Text.Trim();
                dgvDonHang.DataSource = businessDonHang.FindHoaDon(ref error, text);
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }
        private void ThemKhachHangThuong(string maKhachHang)
        {
            string error = "";
            KhachHang khachHang = new KhachHang(maKhachHang);
            if (khachHang == null)
                return;

            if (businessKhachHang.AddKhachHang(khachHang, ref error))
                MessageBox.Show("Thêm khách hàng thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
        }
        private HoaDon GetHoaDonFromControls()
        {
            string error = "";
            try
            {
                DateTime thoiGianCheckIn = DateTime.Now;

                float phuThu = 0;
                if (cbMaBan.Text.Trim()[1] == 'V')
                    phuThu = 50000;

                Random random = new Random();
                string maDauBep = "";
                DataTable dtDauBep;
                dtDauBep = businessNhanVien.GetMaDauBep(ref error);
                List<string> listDauBep = new List<string>();
                foreach (DataRow dr in dtDauBep.Rows)
                {
                    listDauBep.Add(dr[0].ToString());
                }
                int indexDauBep = random.Next(listDauBep.Count);
                maDauBep = listDauBep[indexDauBep];

                string maBan = cbMaBan.Text.Trim();
                string maDonHang = businessDonHang.CreateMaDonHang(ref error);
                string maKhachHang = "";
                if (rdbDatTruoc.Checked)
                {
                    maKhachHang = businessKhachHang.GetMaKhachHangDatTruoc(maBan, ref error);
                }
                else
                {
                    maKhachHang = businessKhachHang.CreateMaKhachHang(ref error);
                    ThemKhachHangThuong(maKhachHang);
                }
                HoaDon hoaDon = new HoaDon(maDonHang, thoiGianCheckIn, phuThu, maBan, maPhucVu, maDauBep, maKhachHang);
                return hoaDon;

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
            HoaDon hoaDon = GetHoaDonFromControls();
            if (hoaDon == null)
                return;
            if (businessDonHang.AddHoaDon(hoaDon, ref error))
            {
                MessageBox.Show("Thêm hóa đơn thành công");
            }
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));

            rdbThuong_CheckedChanged(null, null);

            frmQuanLyBanHang_Load(null, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rdbThuong.Checked = true;
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maDonHang;
            maDonHang = dgvDonHang.CurrentRow.Cells["maDonHang"].Value.ToString();

            frmChiTietDonHang newForm = new frmChiTietDonHang(maDonHang, this);

            newForm.Show(this);
        }

        private void rdbThuong_CheckedChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                if (rdbThuong.Checked)
                {
                    DataTable dt;
                    dt = businessBan.GetMaBanThuong(ref error);
                    List<string> list = new List<string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(dr["maBan"].ToString());
                    }
                    cbMaBan.DataSource = list;
                }
                else
                {
                    DataTable dt;
                    dt = businessBan.GetMaBanDatTruoc(ref error);
                    List<string> list = new List<string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(dr["maBan"].ToString());
                    }
                    cbMaBan.DataSource = list;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }
    }
}
