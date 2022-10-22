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
using System.Threading;
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
            try
            {

                string newImageName = DateTime.Now.Ticks.ToString() + Path.GetExtension(openImage.SafeFileName);

                string filepath = openImage.FileName;
                File.Copy(filepath, imagesPath + newImageName);

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
            catch
            {
                MessageBox.Show("Vui lòng chọn hình ảnh của món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel)
                return;
            string imageDelPath = picMonAn.ImageLocation.ToString();
            

            string error = "";
            string maMonAn = txtMaMonAn.Text.Trim();
            if (maMonAn == null)
                return;

            if (bussiness.DeleteMonAn(maMonAn, ref error))
            {
                MessageBox.Show("Xóa món ăn thành công");
                picMonAn.Load(imagesPath + "food.png");
                File.Delete(imageDelPath);
            }               
            else
                MessageBox.Show(string.Format("Vui lòng thử lại sau\n{0}", error));
            QuanLyMonAn_Load(null, null);
            
        }
    }
}
