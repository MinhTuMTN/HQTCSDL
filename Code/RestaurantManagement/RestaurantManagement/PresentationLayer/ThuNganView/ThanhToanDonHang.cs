using RestaurantManagement.BussinessLayer;
using RestaurantManagement.PresentationLayer.StaffView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement.PresentationLayer.ThuNganView
{
    public partial class frmMainThuNgan : Form
    {
        BusinessThanhToan thanhToan = new BusinessThanhToan();
        BusinessTiepNhan tiepNhan = new BusinessTiepNhan();
        private string maBan;
        private string maNhanVienThuNgan;

        public frmMainThuNgan(string maNhanVienThuNgan)
        {
            InitializeComponent();
            txtPhuThuError.Visible = false;
            lblSuccess.Visible = false;
            lblMaDatTruoc.Visible = false;
            lblTongTienThanhToan.Text = "0đ";
            this.maNhanVienThuNgan = maNhanVienThuNgan;
        }

        private void txtTimKiemThanhToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string error = "";
                maBan = txtTimKiemThanhToan.Text;
                dtgChiTietDonHang.DataSource = thanhToan.GetChiTietHoaDon(maBan, ref error);
                float phuThu = thanhToan.GetPhuThu(maBan, ref error);
                txtPhuThu.Text = phuThu.ToString();
                lblTongTienThanhToan.Text = lblTongTamTinh.Text;
            }
            catch
            {

            }  

        }
        /// <summary>
        /// Tính tạm thu chưa bao gồm phụ thu
        /// </summary>
        private float tinhTamThu()
        {
            float tamThu = 0;

            DataTable table = (DataTable)dtgChiTietDonHang.DataSource;

            if (table.Rows.Count == 0)
                return tamThu;

            foreach(DataRow dr in table.Rows)           
                tamThu = tamThu + float.Parse(dr["soTien"].ToString());

            return tamThu;
        }

        private void txtPhuThu_TextChanged(object sender, EventArgs e)
        {
            txtPhuThuError.Visible = false;
            float tamThu = tinhTamThu();
            float phuThu = 0;
            try
            {
                phuThu = float.Parse(txtPhuThu.Text.Trim());
            }
            catch
            {
                txtPhuThuError.Visible = true;
                if (txtPhuThu.Text.Trim() == "")
                    txtPhuThuError.Visible = false;
            }
            lblTongTamTinh.Text = (tamThu + phuThu).ToString();
            lblTongTienThanhToan.Text = lblTongTamTinh.Text;
        }


        private bool CheckCoupon(DataTable dataTable)
        {
            DateTime today = DateTime.Today.Date;
            if (float.Parse(dataTable.Rows[0]["donToiThieu"].ToString()) > tinhTamThu())
                return false;
            else if (DateTime.Parse(dataTable.Rows[0]["ngayBatDau"].ToString()).Date > today ||
                DateTime.Parse(dataTable.Rows[0]["ngayKetThuc"].ToString()).Date < today)
                return false;
            return true;
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            string maCoupon = txtMaCoupon.Text.Trim();
            string error = "";
            DataTable dt = new DataTable();
            dt = thanhToan.GetCouponById(maCoupon, ref error);
            if (dt.Rows.Count > 0 && CheckCoupon(dt))
            {
                thanhToan.ApDungCoupon(maBan, maCoupon, ref error);
                lblSuccess.Text = "*Áp dụng mã coupon thành công.";
                lblSuccess.Visible = true;
                lblTongTienThanhToan.Text = thanhToan.TongTienThanhToan(maBan, ref error).ToString();
            }    
            else
            {
                lblSuccess.Text = "*Áp dụng mã coupon thất bại.";
                lblSuccess.Visible = true;
            }

            
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float tienThoi = float.Parse(txtTienKhachDua.Text) - float.Parse(lblTongTienThanhToan.Text);
                if (tienThoi <= 0)
                    lblTienThoi.Text = "0";
                else
                    lblTienThoi.Text = tienThoi.ToString();
            }
            catch
            {

            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string error = "";
            if (thanhToan.ThucHienThanhToan(maBan, maNhanVienThuNgan, ref error))
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Thanh toán thất bại! Mời thanh toán lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmMainThuNgan_Load(object sender, EventArgs e)
        {
            string error = "";
            dgvTiepNhan.DataSource = tiepNhan.GetAllTiepNhan(ref error);
            if (dgvTiepNhan.Rows.Count>0)
            {
                DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                dgvTiepNhan_CellClick(sender, ev);
            }    
        }

        private void dgvTiepNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
                return;
            lblHoTen.Text = dgvTiepNhan.Rows[row].Cells["hoTen"].Value.ToString();
            lblNgaySinh.Text = ((DateTime)(dgvTiepNhan.Rows[row].Cells["ngaySinh"].Value)).ToString("dd/MM/yyyy");
            lblSDT.Text = dgvTiepNhan.Rows[row].Cells["soDienThoai"].Value.ToString();
            lblSoBan.Text = dgvTiepNhan.Rows[row].Cells["soBan"].Value.ToString();
            lblSoLuongNguoi.Text = dgvTiepNhan.Rows[row].Cells["soLuongNguoi"].Value.ToString();
            lblThoiGianDatTruoc.Text = dgvTiepNhan.Rows[row].Cells["thoiGianDatTruoc"].Value.ToString();
            lblMaDatTruoc.Text = dgvTiepNhan.Rows[row].Cells["maDatTruoc"].Value.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string error = "";
            string maDatTruoc = lblMaDatTruoc.Text;
            tiepNhan.ChapNhanDatTruoc(maDatTruoc, maNhanVienThuNgan, ref error);
            MessageBox.Show("Tiếp nhận thành công đơn đặt trước.","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmMainThuNgan_Load(null, null);
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            string error = "";
            string maDatTruoc = lblMaDatTruoc.Text;
            tiepNhan.TuChoiDatTruoc(maDatTruoc, maNhanVienThuNgan, ref error);
            MessageBox.Show("Từ chối thành công đơn đặt trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmMainThuNgan_Load(null, null);
        }

        private void frmMainThuNgan_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                return;

            e.Cancel = true;
        }

        private void frmMainThuNgan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcMain.SelectedIndex == 2)
            {
                DangKyCaTruc target = new DangKyCaTruc(maNhanVienThuNgan);
                target.FormBorderStyle = FormBorderStyle.None;
                target.TopLevel = false;
                target.Parent = tpDangKyCaTruc;

                tpDangKyCaTruc.Controls.Clear();
                tpDangKyCaTruc.Controls.Add(target);
                target.Dock = DockStyle.Fill;
                //target.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);

                target.Show();
            }
        }
    }
}
