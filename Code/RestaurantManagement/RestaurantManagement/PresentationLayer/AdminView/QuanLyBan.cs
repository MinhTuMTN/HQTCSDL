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
    public partial class QuanLyBan : Form
    {
        public QuanLyBan()
        {
            InitializeComponent();
        }

        private void cbLoaiBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLyBan_Load(object sender, EventArgs e)
        {
            cbLoaiBanTao.SelectedIndex = 0;
            cbTrangThaiBanTao.SelectedIndex = 0;
        }
    }
}
