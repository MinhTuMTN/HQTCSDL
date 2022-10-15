using RestaurantManagement.AdminController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement.AsminController
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan taiKhoan = new QuanLyTaiKhoan();
            taiKhoan.FormBorderStyle = FormBorderStyle.None;
            taiKhoan.TopLevel = false;

            this.gunaGradientPanel1.Controls.Clear();
            this.gunaGradientPanel1.Controls.Add(taiKhoan);
        }
    }
}
