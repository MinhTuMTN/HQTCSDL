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

namespace RestaurantManagement.PresentationLayer.AdminView
{
    public partial class TraLuong : Form
    {
        BussinessTraLuong bussiness = new BussinessTraLuong();
        public TraLuong()
        {
            InitializeComponent();
            dtgLuong.AutoGenerateColumns = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

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
            txtHoTen.Text = dtgLuong.Rows[row].Cells["hoTen"].Value.ToString();
            txtMaCaTruc.Text = dtgLuong.Rows[row].Cells["maCaTruc"].Value.ToString();
            txtSoNgayNghi.Text = dtgLuong.Rows[row].Cells["soNgayNghi"].Value.ToString();
        }
    }
}
