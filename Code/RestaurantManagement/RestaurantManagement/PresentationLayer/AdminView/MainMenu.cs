using RestaurantManagement.AdminController;
using RestaurantManagement.PresentationLayer.AdminView;
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
            btnQuanLyNhanVien_Click(sender, e);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            lblChucNang.Text = "Quản lý tài khoản";
            QuanLyTaiKhoan taiKhoan = new QuanLyTaiKhoan();
            taiKhoan.FormBorderStyle = FormBorderStyle.None;
            taiKhoan.TopLevel = false;


            pnMain.Controls.Clear();
            pnMain.Controls.Add(taiKhoan);

            taiKhoan.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            lblChucNang.Text = "Quản lý nhân viên";
            QuanLyNhanVien nhanVien = new QuanLyNhanVien();
            nhanVien.FormBorderStyle = FormBorderStyle.None;
            nhanVien.TopLevel = false;


            pnMain.Controls.Clear();
            pnMain.Controls.Add(nhanVien);

            nhanVien.Show();
        }
    }
}
