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
        BussinessDonHang bussiness = new BussinessDonHang();
        public frmQuanLyBanHang()
        {
            InitializeComponent();
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvDonHang.DataSource = bussiness.GetAllDonHang(ref error);

            }
            catch
            {
            }
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs ev)
        {

        }
    }
}
