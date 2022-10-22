using RestaurantManagement.BussinessLayer;
using RestaurantManagement.DataAccessLayer.Model;
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
        BussinessMonAn bussiness = new BussinessMonAn();
        string imagesPath = Path.GetDirectoryName(Application.ExecutablePath).Replace("bin\\Debug","")  + @"FoodImages\";

        public QuanLyMonAn()
        {
            InitializeComponent();
            openImage.Title = "Select a Image";
            openImage.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            if (Directory.Exists(imagesPath) == false)                                          
                Directory.CreateDirectory(imagesPath);

            MessageBox.Show(DateTime.Now.Ticks.ToString());
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string newImageName = DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "") + DateTime.Now.Ticks.ToString() + Path.GetExtension(openImage.SafeFileName);
            try
            {
                string filepath = openImage.FileName;
                File.Copy(filepath, imagesPath + newImageName); 
            }
            catch (Exception exp)
            {
                MessageBox.Show("Unable to open file " + exp.Message);
            }

            string error = "";
            MonAn monAn = new MonAn(txtMaMonAn.Text.Trim(),
                                    txtTenMonAn.Text.Trim(),
                                    float.Parse(txtGiaTien.Text.Trim()),
                                    newImageName);
            if (monAn == null)
                return;

            if (bussiness.AddMonAn(monAn, ref error))
                MessageBox.Show("Thêm món ăn thành công");
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyMonAn_Load(null, null);
        }

        private void QuanLyMonAn_Load(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dgvMonAn.DataSource = bussiness.GetAllMonAn(ref error);
                dgvMonAn.Refresh();

                if (dgvMonAn.RowCount > 0)
                {
                    DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0, 0);
                    dgvMonAn_CellClick(sender, ev);
                }

            }
            catch
            {
            }
        }

        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
                return;

            string image = imagesPath + dgvMonAn.Rows[row].Cells["hinhAnh"].Value.ToString().Trim();
            picMonAn.Load(image);

            txtMaMonAn.Text = dgvMonAn.Rows[row].Cells["maMonAn"].Value.ToString().Trim();
            txtTenMonAn.Text = dgvMonAn.Rows[row].Cells["tenMonAn"].Value.ToString().Trim();
            txtGiaTien.Text = dgvMonAn.Rows[row].Cells["giaTien"].Value.ToString().Trim();
        }
    }
}
