using Guna.UI2.WinForms;
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
    public partial class FilterLuong : Form
    {
        public string maCaTruc;
        public string maNhanVien;
        public string hoTen;
        public DateTime date;

        public FilterLuong()
        {
            InitializeComponent();
        }

        private void FilterLuong_Load(object sender, EventArgs e)
        {
            txtMaCaTruc.PlaceholderForeColor = Color.Black;
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            Guna2CustomCheckBox checkBox = (Guna2CustomCheckBox)sender;
            string name = checkBox.Name;

            bool isChecked = checkBox.Checked;
            if (name == chkMaCaTruc.Name)
                txtMaCaTruc.Enabled = isChecked;
            else if (name == chkDate.Name)
                dtDate.Enabled = isChecked;
            else if (name == chkMaNhanVien.Name)
                txtMaNhanVien.Enabled = isChecked;
            else if (name == chkHoTen.Name)
                txtHoTen.Enabled = isChecked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.maCaTruc =  chkMaCaTruc.Checked ? txtMaCaTruc.Text.Trim() : null;
            this.maNhanVien = chkMaNhanVien.Checked ? txtMaNhanVien.Text.Trim() : null;
            this.hoTen = chkHoTen.Checked ? txtHoTen.Text.Trim() : null;
            this.date = chkDate.Checked ? dtDate.Value : DateTime.MaxValue;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
