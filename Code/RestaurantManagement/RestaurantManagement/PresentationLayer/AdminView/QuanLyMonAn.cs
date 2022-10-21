using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement.PresentationLayer.AdminView
{
    public partial class QuanLyMonAn : Form
    {
        public QuanLyMonAn()
        {
            InitializeComponent();
            openImage.Title = "Select a Image";
            openImage.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
        }

        private void btnThemHinhAnh_Click(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   picMonAn.Image = new  Bitmap(openImage.FileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
                openImage.Dispose();
            }
        }
    }
}
