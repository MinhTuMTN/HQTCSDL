using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagement.AsminController;
using RestaurantManagement.BussinessLayer;
using RestaurantManagement.DataAccessLayer;
using RestaurantManagement.DataAccessLayer.Model;
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

            DatabaseConnection connection = new DatabaseConnection();
            bool correct = connection.TestConnection();

            if (correct)
            {
                string error = "";

                dynamic nhanVien = new BusinessTaiKhoan().GetNhanVienByTaiKhoan(userName, userPass, ref error);
                if(nhanVien == null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                string maNhanVien = nhanVien.maNhanVien;
                string loaiNhanVien = nhanVien.loaiNhanVien;

                this.Hide();
                if (loaiNhanVien == "Thu Ngân")
                {
                    frmMainThuNgan mainMenu = new frmMainThuNgan(maNhanVien);
                    mainMenu.Show();
                }else if(loaiNhanVien == "Quản Lý")
                {
                    frmMainMenu mainMenu = new frmMainMenu(maNhanVien);
                    mainMenu.Show();
                }else if (loaiNhanVien == "Phục Vụ")
                {
                    
                }else
                {

                }
            }
            else
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
