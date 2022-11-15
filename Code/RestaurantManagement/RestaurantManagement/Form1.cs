﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagement.AsminController;
using RestaurantManagement.PresentationLayer.ThuNganView;
using RestaurantManagement.Properties;

namespace RestaurantManagement
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text.Trim();
            string userPass = txtPass.Text.Trim();

            Settings.Default.userLoginDb = userName;
            Settings.Default.passLoginDb = userPass;

            this.Hide();
            frmMainThuNgan mainMenu = new frmMainThuNgan();
            mainMenu.Show();
        }
    }
}
