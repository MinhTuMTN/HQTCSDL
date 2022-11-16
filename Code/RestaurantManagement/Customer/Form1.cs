using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Customer
{
    public partial class frmDatTruoc : Form
    {
        BusinessDatTruoc business = new BusinessDatTruoc();
        public frmDatTruoc()
        {
            InitializeComponent();

            string curDir = Directory.GetCurrentDirectory();
            //browser.Url = new Uri(String.Format("file:///{0}/map.html", curDir));
            //browser.ScriptErrorsSuppressed = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maKhachHang = business.GetMaKhachHang(ref error);
            if(maKhachHang == null)
            {
                
            }
        }
    }
}
