using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Customer
{
    public partial class frmDatTruoc : Form
    {
        BusinessDatTruoc business = new BusinessDatTruoc();
        public frmDatTruoc()
        {
            InitializeComponent();

            string curDir = Directory.GetCurrentDirectory();
            //browser.Url = new Uri(String.Format("file:///{0}/map.html", curDir));
            //browser.ScriptErrorsSuppressed = false;

            dtNgayCheckIn.MinDate = DateTime.Now;
            dtNgayCheckIn.MaxDate = DateTime.Now.Date + (new TimeSpan(24,0,0));
            dtThoiGianCheckIn.MinDate = DateTime.Parse("7:30:00");
            dtThoiGianCheckIn.MaxDate = DateTime.Parse("22:00:00");
            dtNgaySinh.MaxDate = DateTime.Now.Date;
            LoadBan();
        }

        private void btnDatTruoc_Click(object sender, EventArgs e)
        {
            string error = "";
            string hoTen = txtHoTen.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            DateTime ngaySinh = dtNgaySinh.Value.Date;

            DateTime thoiGianCheckIn = dtNgayCheckIn.Value.Date;
            TimeSpan timeSpan = new TimeSpan(dtThoiGianCheckIn.Value.Hour,
                                            dtThoiGianCheckIn.Value.Minute,
                                            0);
            thoiGianCheckIn = thoiGianCheckIn + timeSpan;

            DateTime thoiGianDatTruoc = DateTime.Now;
            int soLuongNguoi = (int)numSoLuongNguoi.Value;
            string maBan = cbBan.Text.Trim();
            bool gioiTinh = false;
            if (rdbNu.Checked)
                gioiTinh = true;

            bool khachHangMoi = false;
            string maKhachHang = business.GetMaKhachHang(soDienThoai, ref khachHangMoi, ref error);

            if (maKhachHang == null)
                return;

            if (khachHangMoi)
                business.InsertKhachHangDatTruoc(maKhachHang, hoTen, soDienThoai, ngaySinh, gioiTinh, ref error);
            business.DatTruoc(thoiGianCheckIn, thoiGianDatTruoc, soLuongNguoi, maKhachHang, maBan, ref error);

        }

        private void dtNgayCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtNgayCheckIn.Value.Date == DateTime.Now.Date)
            {
                DateTime now = DateTime.Now;
                dtThoiGianCheckIn.MinDate = now;
            }
            else
                dtThoiGianCheckIn.MinDate = DateTime.Parse("7:30:00");
        }

        private void numSoLuongNguoi_ValueChanged(object sender, EventArgs e)
        {
            LoadBan();
        }

        private void LoadBan()
        {
            string error = "";
            cbBan.DataSource = business.GetBan((int)numSoLuongNguoi.Value, ref error);
            cbBan.DisplayMember = "maBan";
            if (cbBan.Items.Count == 0)
            {
                cbBan.DataSource = null;
                cbBan.Text = "";
            }
        }
    }
}
