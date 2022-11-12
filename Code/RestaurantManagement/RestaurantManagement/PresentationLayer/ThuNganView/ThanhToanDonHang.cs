﻿using RestaurantManagement.BussinessLayer;
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
        public frmMainThuNgan()
        {
            InitializeComponent();
            txtPhuThuError.Visible = false;
        }

        private void txtTimKiemThanhToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string error = "";
                string maBan = txtTimKiemThanhToan.Text;
                dtgChiTietDonHang.DataSource = thanhToan.GetChiTietHoaDon(maBan, ref error);
                float phuThu = thanhToan.GetPhuThu(maBan, ref error);
                txtPhuThu.Text = phuThu.ToString();

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
        }
    }
}
