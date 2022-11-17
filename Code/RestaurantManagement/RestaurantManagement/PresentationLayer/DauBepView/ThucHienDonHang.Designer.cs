namespace RestaurantManagement.PresentationLayer.DauBepView
{
    partial class frmThucHienDonHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThucHienDonHang));
            this.pnQuanLyNhaHang = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDonHangDauBep = new Guna.UI2.WinForms.Guna2DataGridView();
            this.maDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGianCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maCoupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTienThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThaiDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDauBep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNhanVienPhucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNhanVienThuNgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblChucNang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDangKyCaTruc = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnQuanLyNhaHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHangDauBep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.txtSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnQuanLyNhaHang
            // 
            this.pnQuanLyNhaHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnQuanLyNhaHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(25)))));
            this.pnQuanLyNhaHang.Controls.Add(this.dgvDonHangDauBep);
            this.pnQuanLyNhaHang.Location = new System.Drawing.Point(5, 94);
            this.pnQuanLyNhaHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnQuanLyNhaHang.Name = "pnQuanLyNhaHang";
            this.pnQuanLyNhaHang.ShadowDecoration.Parent = this.pnQuanLyNhaHang;
            this.pnQuanLyNhaHang.Size = new System.Drawing.Size(1531, 748);
            this.pnQuanLyNhaHang.TabIndex = 22;
            // 
            // dgvDonHangDauBep
            // 
            this.dgvDonHangDauBep.AllowUserToAddRows = false;
            this.dgvDonHangDauBep.AllowUserToDeleteRows = false;
            this.dgvDonHangDauBep.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHangDauBep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDonHangDauBep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDonHangDauBep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonHangDauBep.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonHangDauBep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonHangDauBep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonHangDauBep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDonHangDauBep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDonHangDauBep.ColumnHeadersHeight = 75;
            this.dgvDonHangDauBep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDonHang,
            this.thoiGianCheckIn,
            this.phuThu,
            this.maCoupon,
            this.soTienThanhToan,
            this.trangThaiDonHang,
            this.maBan,
            this.maKhachHang,
            this.maDauBep,
            this.maNhanVienPhucVu,
            this.maNhanVienThuNgan});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDonHangDauBep.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDonHangDauBep.EnableHeadersVisualStyles = false;
            this.dgvDonHangDauBep.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDonHangDauBep.Location = new System.Drawing.Point(11, 16);
            this.dgvDonHangDauBep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDonHangDauBep.MultiSelect = false;
            this.dgvDonHangDauBep.Name = "dgvDonHangDauBep";
            this.dgvDonHangDauBep.ReadOnly = true;
            this.dgvDonHangDauBep.RowHeadersVisible = false;
            this.dgvDonHangDauBep.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHangDauBep.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDonHangDauBep.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHangDauBep.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHangDauBep.RowTemplate.Height = 40;
            this.dgvDonHangDauBep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonHangDauBep.Size = new System.Drawing.Size(1504, 725);
            this.dgvDonHangDauBep.TabIndex = 14;
            this.dgvDonHangDauBep.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvDonHangDauBep.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHangDauBep.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHangDauBep.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDonHangDauBep.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDonHangDauBep.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDonHangDauBep.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHangDauBep.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDonHangDauBep.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDonHangDauBep.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDonHangDauBep.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDonHangDauBep.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDonHangDauBep.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDonHangDauBep.ThemeStyle.HeaderStyle.Height = 75;
            this.dgvDonHangDauBep.ThemeStyle.ReadOnly = true;
            this.dgvDonHangDauBep.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHangDauBep.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonHangDauBep.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvDonHangDauBep.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvDonHangDauBep.ThemeStyle.RowsStyle.Height = 40;
            this.dgvDonHangDauBep.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDonHangDauBep.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDonHangDauBep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHangDauBep_CellClick);
            // 
            // maDonHang
            // 
            this.maDonHang.DataPropertyName = "maDonHang";
            this.maDonHang.HeaderText = "Mã đơn hàng";
            this.maDonHang.MinimumWidth = 6;
            this.maDonHang.Name = "maDonHang";
            this.maDonHang.ReadOnly = true;
            // 
            // thoiGianCheckIn
            // 
            this.thoiGianCheckIn.DataPropertyName = "thoiGianCheckIn";
            this.thoiGianCheckIn.HeaderText = "Thời gian check-in";
            this.thoiGianCheckIn.MinimumWidth = 6;
            this.thoiGianCheckIn.Name = "thoiGianCheckIn";
            this.thoiGianCheckIn.ReadOnly = true;
            // 
            // phuThu
            // 
            this.phuThu.DataPropertyName = "phuThu";
            this.phuThu.HeaderText = "Phụ thu";
            this.phuThu.MinimumWidth = 6;
            this.phuThu.Name = "phuThu";
            this.phuThu.ReadOnly = true;
            // 
            // maCoupon
            // 
            this.maCoupon.DataPropertyName = "maCoupon";
            this.maCoupon.HeaderText = "Mã coupon";
            this.maCoupon.MinimumWidth = 6;
            this.maCoupon.Name = "maCoupon";
            this.maCoupon.ReadOnly = true;
            // 
            // soTienThanhToan
            // 
            this.soTienThanhToan.DataPropertyName = "soTienThanhToan";
            this.soTienThanhToan.HeaderText = "Số tiền thanh toán";
            this.soTienThanhToan.MinimumWidth = 6;
            this.soTienThanhToan.Name = "soTienThanhToan";
            this.soTienThanhToan.ReadOnly = true;
            // 
            // trangThaiDonHang
            // 
            this.trangThaiDonHang.DataPropertyName = "trangThaiDonHang";
            this.trangThaiDonHang.HeaderText = "Trạng thái đơn hàng";
            this.trangThaiDonHang.MinimumWidth = 6;
            this.trangThaiDonHang.Name = "trangThaiDonHang";
            this.trangThaiDonHang.ReadOnly = true;
            // 
            // maBan
            // 
            this.maBan.DataPropertyName = "maBan";
            this.maBan.HeaderText = "Mã bàn";
            this.maBan.MinimumWidth = 6;
            this.maBan.Name = "maBan";
            this.maBan.ReadOnly = true;
            // 
            // maKhachHang
            // 
            this.maKhachHang.DataPropertyName = "maKhachHang";
            this.maKhachHang.HeaderText = "Mã khách hàng";
            this.maKhachHang.MinimumWidth = 6;
            this.maKhachHang.Name = "maKhachHang";
            this.maKhachHang.ReadOnly = true;
            // 
            // maDauBep
            // 
            this.maDauBep.DataPropertyName = "maDauBep";
            this.maDauBep.HeaderText = "Mã đầu bếp";
            this.maDauBep.MinimumWidth = 6;
            this.maDauBep.Name = "maDauBep";
            this.maDauBep.ReadOnly = true;
            // 
            // maNhanVienPhucVu
            // 
            this.maNhanVienPhucVu.DataPropertyName = "maNhanVienPhucVu";
            this.maNhanVienPhucVu.HeaderText = "Mã nhân viên phục vụ";
            this.maNhanVienPhucVu.MinimumWidth = 6;
            this.maNhanVienPhucVu.Name = "maNhanVienPhucVu";
            this.maNhanVienPhucVu.ReadOnly = true;
            // 
            // maNhanVienThuNgan
            // 
            this.maNhanVienThuNgan.DataPropertyName = "maNhanVienThuNgan";
            this.maNhanVienThuNgan.HeaderText = "Mã nhân viên thu ngân";
            this.maNhanVienThuNgan.MinimumWidth = 6;
            this.maNhanVienThuNgan.Name = "maNhanVienThuNgan";
            this.maNhanVienThuNgan.ReadOnly = true;
            // 
            // lblChucNang
            // 
            this.lblChucNang.AutoSize = true;
            this.lblChucNang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucNang.Location = new System.Drawing.Point(31, 54);
            this.lblChucNang.Name = "lblChucNang";
            this.lblChucNang.Size = new System.Drawing.Size(155, 20);
            this.lblChucNang.TabIndex = 10;
            this.lblChucNang.Text = "Thực hiện đơn hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "The Moon Restaurant";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(63, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 22);
            this.label12.TabIndex = 1;
            this.label12.Text = "Đầu bếp";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2CirclePictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(63, 63);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel1.BorderRadius = 15;
            this.guna2GradientPanel1.Controls.Add(this.label12);
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(1260, 14);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(159, 60);
            this.guna2GradientPanel1.TabIndex = 13;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSearch.BorderRadius = 20;
            this.txtSearch.BorderThickness = 3;
            this.txtSearch.Controls.Add(this.btnDangKyCaTruc);
            this.txtSearch.Controls.Add(this.guna2GradientPanel1);
            this.txtSearch.Controls.Add(this.lblChucNang);
            this.txtSearch.Controls.Add(this.label1);
            this.txtSearch.Controls.Add(this.txtTimKiem);
            this.txtSearch.Location = new System.Drawing.Point(5, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(1515, 85);
            this.txtSearch.TabIndex = 21;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(59)))), ((int)(((byte)(75)))));
            this.txtTimKiem.BorderRadius = 15;
            this.txtTimKiem.BorderThickness = 3;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.Parent = this.txtTimKiem;
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.FocusedState.Parent = this.txtTimKiem;
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.HoverState.Parent = this.txtTimKiem;
            this.txtTimKiem.IconRight = ((System.Drawing.Image)(resources.GetObject("txtTimKiem.IconRight")));
            this.txtTimKiem.Location = new System.Drawing.Point(343, 32);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PlaceholderText = "Tìm kiếm";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.ShadowDecoration.Parent = this.txtTimKiem;
            this.txtTimKiem.Size = new System.Drawing.Size(899, 44);
            this.txtTimKiem.TabIndex = 8;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnDangKyCaTruc
            // 
            this.btnDangKyCaTruc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDangKyCaTruc.BackColor = System.Drawing.Color.Transparent;
            this.btnDangKyCaTruc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDangKyCaTruc.CheckedState.Parent = this.btnDangKyCaTruc;
            this.btnDangKyCaTruc.CustomImages.Parent = this.btnDangKyCaTruc;
            this.btnDangKyCaTruc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(147)))), ((int)(((byte)(128)))));
            this.btnDangKyCaTruc.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnDangKyCaTruc.ForeColor = System.Drawing.Color.White;
            this.btnDangKyCaTruc.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangKyCaTruc.HoverState.Parent = this.btnDangKyCaTruc;
            this.btnDangKyCaTruc.ImageSize = new System.Drawing.Size(75, 75);
            this.btnDangKyCaTruc.Location = new System.Drawing.Point(1425, 6);
            this.btnDangKyCaTruc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangKyCaTruc.Name = "btnDangKyCaTruc";
            this.btnDangKyCaTruc.PressedColor = System.Drawing.Color.Salmon;
            this.btnDangKyCaTruc.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDangKyCaTruc.ShadowDecoration.Parent = this.btnDangKyCaTruc;
            this.btnDangKyCaTruc.Size = new System.Drawing.Size(70, 71);
            this.btnDangKyCaTruc.TabIndex = 15;
            this.btnDangKyCaTruc.Text = "Đăng ký ca trực";
            this.btnDangKyCaTruc.Click += new System.EventHandler(this.btnDangKyCaTruc_Click);
            // 
            // frmThucHienDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1540, 846);
            this.Controls.Add(this.pnQuanLyNhaHang);
            this.Controls.Add(this.txtSearch);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThucHienDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Moon Restaurant - Quản lý nhà hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainMenu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmThucHienDonHang_Load);
            this.pnQuanLyNhaHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHangDauBep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.txtSearch.ResumeLayout(false);
            this.txtSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnQuanLyNhaHang;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHangDauBep;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoiGianCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn maCoupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTienThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThaiDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn maBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDauBep;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVienPhucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVienThuNgan;
        private System.Windows.Forms.Label lblChucNang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel txtSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2CircleButton btnDangKyCaTruc;
    }
}