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
        public frmQuanLyBanHang()
        {
            InitializeComponent();
            rdbThuong.Checked = true;
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
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

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs ev)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                string text = txtTimKiem.Text.Trim();
                dgvDonHang.DataSource = businessDonHang.FindHoaDon(ref error, text);

                /*if (dgvDonHang.RowCount > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvDonHang_CellClick(sender, ev);
                }*/

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

                //string maNhanVienThuNgan = null;
                //string maCoupon = null;
                //string trangThaiDonHang = "Đang chuẩn bị";
                string maNhanVienPhucVu = "NV330103";
                string maBan = cbMaBan.Text.Trim();
                //float thue = 10000;
                //float soTienThanhToan = 0;
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
                HoaDon hoaDon = new HoaDon(maDonHang, thoiGianCheckIn, phuThu, maBan, maNhanVienPhucVu, maDauBep, maKhachHang);
                return hoaDon;

            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
            return null;
        }

        private void cbMaBan_Click(object sender, EventArgs e)
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
                        list.Add(dr[0].ToString());
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
                        list.Add(dr[0].ToString());
                    }
                    cbMaBan.DataSource = list;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", error);
            }
        }
        private void SuaTrangThaiBan(string maBan)
        {
            string error = "";
            Ban ban = new Ban(maBan);
            if (businessBan.UpdateTrangThaiBan(ban, ref error))
                MessageBox.Show("Cập nhật trạng thái bàn thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
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
                SuaTrangThaiBan(hoaDon.MaBan);
            }
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
 
            QuanLyBanHang_Load(null, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
