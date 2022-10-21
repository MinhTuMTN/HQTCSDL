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
    public partial class QuanLyCaTruc : Form
    {
        BussinessCaTruc bussinessCaTruc = new BussinessCaTruc();
        public QuanLyCaTruc()
        {
            InitializeComponent();
        }

        private void QuanLyCaTruc_Load(object sender, EventArgs e)
        {
            string error = "";
            dgvCaTruc.DataSource = bussinessCaTruc.GetAllCaTruc(ref error);
            dgvCaTruc.Refresh();
        }
    }
}
