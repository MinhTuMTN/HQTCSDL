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

namespace RestaurantManagement.PresentationLayer.ThuNganView
{
    public partial class frmMainThuNgan : Form
    {
        BusinessThanhToan thanhToan = new BusinessThanhToan();
        private string maBan;
        private string maNhanVienThuNgan;

        public frmMainThuNgan()
        {
            InitializeComponent();
            txtPhuThuError.Visible = false;
            lblSuccess.Visible = false;
            lblTongTienThanhToan.Text = "0đ";
            maNhanVienThuNgan = "NV440123";
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
    }
}
