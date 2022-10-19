using System.Drawing;
using System.Windows.Forms;

namespace RestaurantManagement.AdminController
{
    partial class QuanLyTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyTaiKhoan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.myPanel1 = new RestaurantManagement.PresentationLayer.Control.MyPanel();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCaiDat = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblChucNang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnMain = new Guna.UI2.WinForms.Guna2Panel();
            this.gbCapNhat = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnResetSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.cbTinhTrangSua = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMaNhanVienSua = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMatKhauSua = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTaiKhoanSua = new Guna.UI2.WinForms.Guna2TextBox();
            this.gbThem = new Guna.UI2.WinForms.Guna2GroupBox();
            this.bntResetTao = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.cbTinhTrangTao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMaNhanVienTao = new Guna.UI2.WinForms.Guna2TextBox();
            this.bntMatKhauThem = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTaiKhoanTao = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvTaiKhoan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.myPanel1.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.pnMain.SuspendLayout();
            this.gbCapNhat.SuspendLayout();
            this.gbThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BackColor = System.Drawing.Color.White;
            this.myPanel1.Controls.Add(this.guna2CustomGradientPanel1);
            this.myPanel1.Controls.Add(this.pnMain);
            this.myPanel1.Location = new System.Drawing.Point(-3, -3);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(1128, 985);
            this.myPanel1.TabIndex = 0;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.BorderThickness = 3;
            this.guna2CustomGradientPanel1.Controls.Add(this.txtTimKiem);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnCaiDat);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2GradientPanel1);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblChucNang);
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(6, 18);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.Parent = this.guna2CustomGradientPanel1;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1118, 85);
            this.guna2CustomGradientPanel1.TabIndex = 17;
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
            this.txtTimKiem.Location = new System.Drawing.Point(341, 20);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.PlaceholderText = "Tìm kiếm";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.ShadowDecoration.Parent = this.txtTimKiem;
            this.txtTimKiem.Size = new System.Drawing.Size(502, 44);
            this.txtTimKiem.TabIndex = 13;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCaiDat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCaiDat.CheckedState.Parent = this.btnCaiDat;
            this.btnCaiDat.CustomImages.Parent = this.btnCaiDat;
            this.btnCaiDat.FillColor = System.Drawing.Color.Transparent;
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.HoverState.Parent = this.btnCaiDat;
            this.btnCaiDat.Image = ((System.Drawing.Image)(resources.GetObject("btnCaiDat.Image")));
            this.btnCaiDat.ImageSize = new System.Drawing.Size(45, 45);
            this.btnCaiDat.Location = new System.Drawing.Point(1065, 22);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.PressedColor = System.Drawing.Color.Transparent;
            this.btnCaiDat.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnCaiDat.ShadowDecoration.Parent = this.btnCaiDat;
            this.btnCaiDat.Size = new System.Drawing.Size(43, 41);
            this.btnCaiDat.TabIndex = 12;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel1.BorderRadius = 15;
            this.guna2GradientPanel1.Controls.Add(this.label12);
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(903, 12);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.Parent = this.guna2GradientPanel1;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(159, 60);
            this.guna2GradientPanel1.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(62, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 23);
            this.label12.TabIndex = 1;
            this.label12.Text = "Quản lý";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(-1, -2);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(63, 63);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // lblChucNang
            // 
            this.lblChucNang.AutoSize = true;
            this.lblChucNang.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucNang.Location = new System.Drawing.Point(30, 42);
            this.lblChucNang.Name = "lblChucNang";
            this.lblChucNang.Size = new System.Drawing.Size(167, 22);
            this.lblChucNang.TabIndex = 10;
            this.lblChucNang.Text = "Quản lý nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "The Moon Restaurant";
            // 
            // pnMain
            // 
            this.pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(25)))));
            this.pnMain.Controls.Add(this.gbCapNhat);
            this.pnMain.Controls.Add(this.gbThem);
            this.pnMain.Controls.Add(this.dgvTaiKhoan);
            this.pnMain.Location = new System.Drawing.Point(6, 130);
            this.pnMain.Name = "pnMain";
            this.pnMain.ShadowDecoration.Parent = this.pnMain;
            this.pnMain.Size = new System.Drawing.Size(1125, 847);
            this.pnMain.TabIndex = 16;
            // 
            // gbCapNhat
            // 
            this.gbCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCapNhat.BackColor = System.Drawing.Color.Transparent;
            this.gbCapNhat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(86)))));
            this.gbCapNhat.BorderRadius = 15;
            this.gbCapNhat.BorderThickness = 5;
            this.gbCapNhat.Controls.Add(this.guna2GroupBox1);
            this.gbCapNhat.Controls.Add(this.btnResetSua);
            this.gbCapNhat.Controls.Add(this.btnSua);
            this.gbCapNhat.Controls.Add(this.cbTinhTrangSua);
            this.gbCapNhat.Controls.Add(this.txtMaNhanVienSua);
            this.gbCapNhat.Controls.Add(this.txtMatKhauSua);
            this.gbCapNhat.Controls.Add(this.txtTaiKhoanSua);
            this.gbCapNhat.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(86)))));
            this.gbCapNhat.FillColor = System.Drawing.Color.Black;
            this.gbCapNhat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCapNhat.ForeColor = System.Drawing.Color.White;
            this.gbCapNhat.Location = new System.Drawing.Point(778, 445);
            this.gbCapNhat.Name = "gbCapNhat";
            this.gbCapNhat.ShadowDecoration.Parent = this.gbCapNhat;
            this.gbCapNhat.Size = new System.Drawing.Size(334, 386);
            this.gbCapNhat.TabIndex = 13;
            this.gbCapNhat.Text = "Cập nhật tài khoản";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(86)))));
            this.guna2GroupBox1.BorderRadius = 15;
            this.guna2GroupBox1.BorderThickness = 5;
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(86)))));
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(763, 433);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(334, 386);
            this.guna2GroupBox1.TabIndex = 26;
            this.guna2GroupBox1.Text = "Cập nhật tài khoản";
            // 
            // btnResetSua
            // 
            this.btnResetSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetSua.BackColor = System.Drawing.Color.Transparent;
            this.btnResetSua.BorderRadius = 15;
            this.btnResetSua.CheckedState.Parent = this.btnResetSua;
            this.btnResetSua.CustomImages.Parent = this.btnResetSua;
            this.btnResetSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.btnResetSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnResetSua.ForeColor = System.Drawing.Color.White;
            this.btnResetSua.HoverState.Parent = this.btnResetSua;
            this.btnResetSua.Image = ((System.Drawing.Image)(resources.GetObject("btnResetSua.Image")));
            this.btnResetSua.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnResetSua.ImageSize = new System.Drawing.Size(30, 30);
            this.btnResetSua.Location = new System.Drawing.Point(89, 324);
            this.btnResetSua.Name = "btnResetSua";
            this.btnResetSua.ShadowDecoration.Parent = this.btnResetSua;
            this.btnResetSua.Size = new System.Drawing.Size(111, 37);
            this.btnResetSua.TabIndex = 32;
            this.btnResetSua.Text = "     Reset";
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BackColor = System.Drawing.Color.Transparent;
            this.btnSua.BorderRadius = 15;
            this.btnSua.CheckedState.Parent = this.btnSua;
            this.btnSua.CustomImages.Parent = this.btnSua;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.HoverState.Parent = this.btnSua;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSua.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSua.Location = new System.Drawing.Point(207, 324);
            this.btnSua.Name = "btnSua";
            this.btnSua.ShadowDecoration.Parent = this.btnSua;
            this.btnSua.Size = new System.Drawing.Size(111, 37);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "     Sửa";
            // 
            // cbTinhTrangSua
            // 
            this.cbTinhTrangSua.BackColor = System.Drawing.Color.Transparent;
            this.cbTinhTrangSua.BorderRadius = 15;
            this.cbTinhTrangSua.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTinhTrangSua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTinhTrangSua.FocusedColor = System.Drawing.Color.Empty;
            this.cbTinhTrangSua.FocusedState.Parent = this.cbTinhTrangSua;
            this.cbTinhTrangSua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTinhTrangSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTinhTrangSua.FormattingEnabled = true;
            this.cbTinhTrangSua.HoverState.Parent = this.cbTinhTrangSua;
            this.cbTinhTrangSua.ItemHeight = 30;
            this.cbTinhTrangSua.Items.AddRange(new object[] {
            "Đang hoạt động",
            "Bị chặn"});
            this.cbTinhTrangSua.ItemsAppearance.Parent = this.cbTinhTrangSua;
            this.cbTinhTrangSua.Location = new System.Drawing.Point(18, 267);
            this.cbTinhTrangSua.Name = "cbTinhTrangSua";
            this.cbTinhTrangSua.ShadowDecoration.Parent = this.cbTinhTrangSua;
            this.cbTinhTrangSua.Size = new System.Drawing.Size(300, 36);
            this.cbTinhTrangSua.TabIndex = 30;
            // 
            // txtMaNhanVienSua
            // 
            this.txtMaNhanVienSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNhanVienSua.BackColor = System.Drawing.Color.Transparent;
            this.txtMaNhanVienSua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.txtMaNhanVienSua.BorderRadius = 15;
            this.txtMaNhanVienSua.BorderThickness = 2;
            this.txtMaNhanVienSua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaNhanVienSua.DefaultText = "";
            this.txtMaNhanVienSua.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaNhanVienSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaNhanVienSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVienSua.DisabledState.Parent = this.txtMaNhanVienSua;
            this.txtMaNhanVienSua.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVienSua.FillColor = System.Drawing.SystemColors.Desktop;
            this.txtMaNhanVienSua.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVienSua.FocusedState.Parent = this.txtMaNhanVienSua;
            this.txtMaNhanVienSua.ForeColor = System.Drawing.Color.LightGray;
            this.txtMaNhanVienSua.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVienSua.HoverState.Parent = this.txtMaNhanVienSua;
            this.txtMaNhanVienSua.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtMaNhanVienSua.IconLeft")));
            this.txtMaNhanVienSua.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtMaNhanVienSua.IconRightSize = new System.Drawing.Size(30, 30);
            this.txtMaNhanVienSua.Location = new System.Drawing.Point(18, 205);
            this.txtMaNhanVienSua.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.txtMaNhanVienSua.Name = "txtMaNhanVienSua";
            this.txtMaNhanVienSua.PasswordChar = '\0';
            this.txtMaNhanVienSua.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtMaNhanVienSua.PlaceholderText = "Mã nhân viên";
            this.txtMaNhanVienSua.ReadOnly = true;
            this.txtMaNhanVienSua.SelectedText = "";
            this.txtMaNhanVienSua.ShadowDecoration.Parent = this.txtMaNhanVienSua;
            this.txtMaNhanVienSua.Size = new System.Drawing.Size(300, 40);
            this.txtMaNhanVienSua.TabIndex = 29;
            // 
            // txtMatKhauSua
            // 
            this.txtMatKhauSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhauSua.BackColor = System.Drawing.Color.Transparent;
            this.txtMatKhauSua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.txtMatKhauSua.BorderRadius = 15;
            this.txtMatKhauSua.BorderThickness = 2;
            this.txtMatKhauSua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatKhauSua.DefaultText = "";
            this.txtMatKhauSua.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMatKhauSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMatKhauSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhauSua.DisabledState.Parent = this.txtMatKhauSua;
            this.txtMatKhauSua.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMatKhauSua.FillColor = System.Drawing.SystemColors.Desktop;
            this.txtMatKhauSua.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhauSua.FocusedState.Parent = this.txtMatKhauSua;
            this.txtMatKhauSua.ForeColor = System.Drawing.Color.LightGray;
            this.txtMatKhauSua.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMatKhauSua.HoverState.Parent = this.txtMatKhauSua;
            this.txtMatKhauSua.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtMatKhauSua.IconLeft")));
            this.txtMatKhauSua.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtMatKhauSua.IconRightSize = new System.Drawing.Size(30, 30);
            this.txtMatKhauSua.Location = new System.Drawing.Point(18, 137);
            this.txtMatKhauSua.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtMatKhauSua.Name = "txtMatKhauSua";
            this.txtMatKhauSua.PasswordChar = '\0';
            this.txtMatKhauSua.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtMatKhauSua.PlaceholderText = "Mật khẩu";
            this.txtMatKhauSua.SelectedText = "";
            this.txtMatKhauSua.ShadowDecoration.Parent = this.txtMatKhauSua;
            this.txtMatKhauSua.Size = new System.Drawing.Size(300, 40);
            this.txtMatKhauSua.TabIndex = 28;
            // 
            // txtTaiKhoanSua
            // 
            this.txtTaiKhoanSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaiKhoanSua.BackColor = System.Drawing.Color.Transparent;
            this.txtTaiKhoanSua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.txtTaiKhoanSua.BorderRadius = 15;
            this.txtTaiKhoanSua.BorderThickness = 2;
            this.txtTaiKhoanSua.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaiKhoanSua.DefaultText = "";
            this.txtTaiKhoanSua.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTaiKhoanSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTaiKhoanSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoanSua.DisabledState.Parent = this.txtTaiKhoanSua;
            this.txtTaiKhoanSua.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoanSua.FillColor = System.Drawing.SystemColors.Desktop;
            this.txtTaiKhoanSua.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaiKhoanSua.FocusedState.Parent = this.txtTaiKhoanSua;
            this.txtTaiKhoanSua.ForeColor = System.Drawing.Color.LightGray;
            this.txtTaiKhoanSua.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaiKhoanSua.HoverState.Parent = this.txtTaiKhoanSua;
            this.txtTaiKhoanSua.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTaiKhoanSua.IconLeft")));
            this.txtTaiKhoanSua.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtTaiKhoanSua.Location = new System.Drawing.Point(18, 74);
            this.txtTaiKhoanSua.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTaiKhoanSua.Name = "txtTaiKhoanSua";
            this.txtTaiKhoanSua.PasswordChar = '\0';
            this.txtTaiKhoanSua.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtTaiKhoanSua.PlaceholderText = "Tài khoản";
            this.txtTaiKhoanSua.SelectedText = "";
            this.txtTaiKhoanSua.ShadowDecoration.Parent = this.txtTaiKhoanSua;
            this.txtTaiKhoanSua.Size = new System.Drawing.Size(300, 40);
            this.txtTaiKhoanSua.TabIndex = 27;
            // 
            // gbThem
            // 
            this.gbThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThem.BackColor = System.Drawing.Color.Transparent;
            this.gbThem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(86)))));
            this.gbThem.BorderRadius = 15;
            this.gbThem.BorderThickness = 5;
            this.gbThem.Controls.Add(this.bntResetTao);
            this.gbThem.Controls.Add(this.btnThem);
            this.gbThem.Controls.Add(this.cbTinhTrangTao);
            this.gbThem.Controls.Add(this.txtMaNhanVienTao);
            this.gbThem.Controls.Add(this.bntMatKhauThem);
            this.gbThem.Controls.Add(this.txtTaiKhoanTao);
            this.gbThem.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(86)))));
            this.gbThem.FillColor = System.Drawing.Color.Black;
            this.gbThem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThem.ForeColor = System.Drawing.Color.White;
            this.gbThem.Location = new System.Drawing.Point(778, 16);
            this.gbThem.Name = "gbThem";
            this.gbThem.ShadowDecoration.Parent = this.gbThem;
            this.gbThem.Size = new System.Drawing.Size(334, 396);
            this.gbThem.TabIndex = 12;
            this.gbThem.Text = "Thêm tài khoản";
            // 
            // bntResetTao
            // 
            this.bntResetTao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntResetTao.BackColor = System.Drawing.Color.Transparent;
            this.bntResetTao.BorderRadius = 15;
            this.bntResetTao.CheckedState.Parent = this.bntResetTao;
            this.bntResetTao.CustomImages.Parent = this.bntResetTao;
            this.bntResetTao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.bntResetTao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bntResetTao.ForeColor = System.Drawing.Color.White;
            this.bntResetTao.HoverState.Parent = this.bntResetTao;
            this.bntResetTao.Image = ((System.Drawing.Image)(resources.GetObject("bntResetTao.Image")));
            this.bntResetTao.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bntResetTao.ImageSize = new System.Drawing.Size(30, 30);
            this.bntResetTao.Location = new System.Drawing.Point(89, 310);
            this.bntResetTao.Name = "bntResetTao";
            this.bntResetTao.ShadowDecoration.Parent = this.bntResetTao;
            this.bntResetTao.Size = new System.Drawing.Size(111, 37);
            this.bntResetTao.TabIndex = 25;
            this.bntResetTao.Text = "     Reset";
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BorderRadius = 15;
            this.btnThem.CheckedState.Parent = this.btnThem;
            this.btnThem.CustomImages.Parent = this.btnThem;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.HoverState.Parent = this.btnThem;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThem.ImageSize = new System.Drawing.Size(30, 30);
            this.btnThem.Location = new System.Drawing.Point(206, 310);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShadowDecoration.Parent = this.btnThem;
            this.btnThem.Size = new System.Drawing.Size(111, 37);
            this.btnThem.TabIndex = 24;
            this.btnThem.Text = "     Thêm";
            // 
            // cbTinhTrangTao
            // 
            this.cbTinhTrangTao.BackColor = System.Drawing.Color.Transparent;
            this.cbTinhTrangTao.BorderRadius = 15;
            this.cbTinhTrangTao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTinhTrangTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTinhTrangTao.FocusedColor = System.Drawing.Color.Empty;
            this.cbTinhTrangTao.FocusedState.Parent = this.cbTinhTrangTao;
            this.cbTinhTrangTao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTinhTrangTao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTinhTrangTao.FormattingEnabled = true;
            this.cbTinhTrangTao.HoverState.Parent = this.cbTinhTrangTao;
            this.cbTinhTrangTao.ItemHeight = 30;
            this.cbTinhTrangTao.Items.AddRange(new object[] {
            "Đang hoạt động",
            "Bị chặn"});
            this.cbTinhTrangTao.ItemsAppearance.Parent = this.cbTinhTrangTao;
            this.cbTinhTrangTao.Location = new System.Drawing.Point(18, 254);
            this.cbTinhTrangTao.Name = "cbTinhTrangTao";
            this.cbTinhTrangTao.ShadowDecoration.Parent = this.cbTinhTrangTao;
            this.cbTinhTrangTao.Size = new System.Drawing.Size(299, 36);
            this.cbTinhTrangTao.TabIndex = 20;
            // 
            // txtMaNhanVienTao
            // 
            this.txtMaNhanVienTao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNhanVienTao.BackColor = System.Drawing.Color.Transparent;
            this.txtMaNhanVienTao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.txtMaNhanVienTao.BorderRadius = 15;
            this.txtMaNhanVienTao.BorderThickness = 2;
            this.txtMaNhanVienTao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaNhanVienTao.DefaultText = "";
            this.txtMaNhanVienTao.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaNhanVienTao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaNhanVienTao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVienTao.DisabledState.Parent = this.txtMaNhanVienTao;
            this.txtMaNhanVienTao.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaNhanVienTao.FillColor = System.Drawing.SystemColors.Desktop;
            this.txtMaNhanVienTao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVienTao.FocusedState.Parent = this.txtMaNhanVienTao;
            this.txtMaNhanVienTao.ForeColor = System.Drawing.Color.LightGray;
            this.txtMaNhanVienTao.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaNhanVienTao.HoverState.Parent = this.txtMaNhanVienTao;
            this.txtMaNhanVienTao.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtMaNhanVienTao.IconLeft")));
            this.txtMaNhanVienTao.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtMaNhanVienTao.IconRightSize = new System.Drawing.Size(30, 30);
            this.txtMaNhanVienTao.Location = new System.Drawing.Point(17, 193);
            this.txtMaNhanVienTao.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.txtMaNhanVienTao.Name = "txtMaNhanVienTao";
            this.txtMaNhanVienTao.PasswordChar = '\0';
            this.txtMaNhanVienTao.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtMaNhanVienTao.PlaceholderText = "Mã nhân viên";
            this.txtMaNhanVienTao.SelectedText = "";
            this.txtMaNhanVienTao.ShadowDecoration.Parent = this.txtMaNhanVienTao;
            this.txtMaNhanVienTao.Size = new System.Drawing.Size(300, 40);
            this.txtMaNhanVienTao.TabIndex = 19;
            // 
            // bntMatKhauThem
            // 
            this.bntMatKhauThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntMatKhauThem.BackColor = System.Drawing.Color.Transparent;
            this.bntMatKhauThem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.bntMatKhauThem.BorderRadius = 15;
            this.bntMatKhauThem.BorderThickness = 2;
            this.bntMatKhauThem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bntMatKhauThem.DefaultText = "";
            this.bntMatKhauThem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.bntMatKhauThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.bntMatKhauThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bntMatKhauThem.DisabledState.Parent = this.bntMatKhauThem;
            this.bntMatKhauThem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bntMatKhauThem.FillColor = System.Drawing.SystemColors.Desktop;
            this.bntMatKhauThem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bntMatKhauThem.FocusedState.Parent = this.bntMatKhauThem;
            this.bntMatKhauThem.ForeColor = System.Drawing.Color.LightGray;
            this.bntMatKhauThem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bntMatKhauThem.HoverState.Parent = this.bntMatKhauThem;
            this.bntMatKhauThem.IconLeft = ((System.Drawing.Image)(resources.GetObject("bntMatKhauThem.IconLeft")));
            this.bntMatKhauThem.IconLeftSize = new System.Drawing.Size(30, 30);
            this.bntMatKhauThem.IconRightSize = new System.Drawing.Size(30, 30);
            this.bntMatKhauThem.Location = new System.Drawing.Point(17, 129);
            this.bntMatKhauThem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.bntMatKhauThem.Name = "bntMatKhauThem";
            this.bntMatKhauThem.PasswordChar = '\0';
            this.bntMatKhauThem.PlaceholderForeColor = System.Drawing.Color.Black;
            this.bntMatKhauThem.PlaceholderText = "Mật khẩu";
            this.bntMatKhauThem.SelectedText = "";
            this.bntMatKhauThem.ShadowDecoration.Parent = this.bntMatKhauThem;
            this.bntMatKhauThem.Size = new System.Drawing.Size(300, 40);
            this.bntMatKhauThem.TabIndex = 18;
            // 
            // txtTaiKhoanTao
            // 
            this.txtTaiKhoanTao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaiKhoanTao.BackColor = System.Drawing.Color.Transparent;
            this.txtTaiKhoanTao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.txtTaiKhoanTao.BorderRadius = 15;
            this.txtTaiKhoanTao.BorderThickness = 2;
            this.txtTaiKhoanTao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaiKhoanTao.DefaultText = "";
            this.txtTaiKhoanTao.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTaiKhoanTao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTaiKhoanTao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoanTao.DisabledState.Parent = this.txtTaiKhoanTao;
            this.txtTaiKhoanTao.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaiKhoanTao.FillColor = System.Drawing.SystemColors.Desktop;
            this.txtTaiKhoanTao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaiKhoanTao.FocusedState.Parent = this.txtTaiKhoanTao;
            this.txtTaiKhoanTao.ForeColor = System.Drawing.Color.LightGray;
            this.txtTaiKhoanTao.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaiKhoanTao.HoverState.Parent = this.txtTaiKhoanTao;
            this.txtTaiKhoanTao.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTaiKhoanTao.IconLeft")));
            this.txtTaiKhoanTao.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtTaiKhoanTao.Location = new System.Drawing.Point(17, 67);
            this.txtTaiKhoanTao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTaiKhoanTao.Name = "txtTaiKhoanTao";
            this.txtTaiKhoanTao.PasswordChar = '\0';
            this.txtTaiKhoanTao.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtTaiKhoanTao.PlaceholderText = "Tài khoản";
            this.txtTaiKhoanTao.SelectedText = "";
            this.txtTaiKhoanTao.ShadowDecoration.Parent = this.txtTaiKhoanTao;
            this.txtTaiKhoanTao.Size = new System.Drawing.Size(300, 40);
            this.txtTaiKhoanTao.TabIndex = 17;
            // 
            // dgvTaiKhoan
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaiKhoan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaiKhoan.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTaiKhoan.EnableHeadersVisualStyles = false;
            this.dgvTaiKhoan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.Location = new System.Drawing.Point(9, 16);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(756, 815);
            this.dgvTaiKhoan.TabIndex = 14;
            this.dgvTaiKhoan.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvTaiKhoan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTaiKhoan.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTaiKhoan.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTaiKhoan.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTaiKhoan.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvTaiKhoan.ThemeStyle.ReadOnly = false;
            this.dgvTaiKhoan.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaiKhoan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTaiKhoan.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvTaiKhoan.ThemeStyle.RowsStyle.Height = 24;
            this.dgvTaiKhoan.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // QuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 975);
            this.Controls.Add(this.myPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Lucida Fax", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyTaiKhoan";
            this.Text = "QuanLyTaiKhoan";
            this.myPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.pnMain.ResumeLayout(false);
            this.gbCapNhat.ResumeLayout(false);
            this.gbThem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox gbCapNhat;
        private Guna.UI2.WinForms.Guna2GroupBox gbThem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTaiKhoan;
        private Guna.UI2.WinForms.Guna2Panel pnMain;
        private Guna.UI2.WinForms.Guna2ComboBox cbTinhTrangTao;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNhanVienTao;
        private Guna.UI2.WinForms.Guna2TextBox bntMatKhauThem;
        private Guna.UI2.WinForms.Guna2TextBox txtTaiKhoanTao;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button bntResetTao;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button btnResetSua;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2ComboBox cbTinhTrangSua;
        private Guna.UI2.WinForms.Guna2TextBox txtMaNhanVienSua;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhauSua;
        private Guna.UI2.WinForms.Guna2TextBox txtTaiKhoanSua;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2CircleButton btnCaiDat;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Label label12;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Label lblChucNang;
        private Label label1;
        private PresentationLayer.Control.MyPanel myPanel1;
    }
}