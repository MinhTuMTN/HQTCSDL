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

        private void LoadPanelMain(Form target)
        {
            target.FormBorderStyle = FormBorderStyle.None;
            target.TopLevel = false;
            target.Parent = pnMain;

            target.Size = pnMain.Size;

            pnMain.Controls.Clear();
            pnMain.Controls.Add(target);

            target.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadPanelMain(new QuanLyTaiKhoan());
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            LoadPanelMain(new QuanLyNhanVien());
        }

        private void pnMain_Resize(object sender, EventArgs e)
        {
            pnMain.Controls[0].Size = pnMain.Size;
        }

        private void btnCaTruc_Click(object sender, EventArgs e)
        {
            LoadPanelMain(new QuanLyCaTruc());
        }
    }
}
