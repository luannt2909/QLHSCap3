namespace GUI
{
    partial class frmQuanTri
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanTri));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labReMatKhauErr = new System.Windows.Forms.Label();
            this.labMatKhauErr = new System.Windows.Forms.Label();
            this.labLoaiNguoiDungErr = new System.Windows.Forms.Label();
            this.labTaiKhoanErr = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLoaiNguoiDung = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.chbHienThi = new System.Windows.Forms.CheckBox();
            this.txbReMatKhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.txbTaiKhoan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnThoat2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvNamHoc = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labNamErr = new System.Windows.Forms.Label();
            this.btnThemNam = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txbNamKetThuc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbNamBatDau = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamHoc)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1002, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.Control;
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 47);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(994, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Người dùng";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Maroon;
            this.btnThoat.BackgroundImage = global::GUI.Properties.Resources.Thoat;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat.Location = new System.Drawing.Point(528, 302);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 71);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoa.BackgroundImage = global::GUI.Properties.Resources.Xoa;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXoa.Location = new System.Drawing.Point(528, 60);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 72);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Người Dùng";
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.AllowUserToResizeColumns = false;
            this.dgvNguoiDung.AllowUserToResizeRows = false;
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiDung.Location = new System.Drawing.Point(6, 60);
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.Size = new System.Drawing.Size(522, 313);
            this.dgvNguoiDung.TabIndex = 2;
            this.dgvNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiDung_CellClick);
            this.dgvNguoiDung.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiDung_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Controls.Add(this.labReMatKhauErr);
            this.groupBox1.Controls.Add(this.labMatKhauErr);
            this.groupBox1.Controls.Add(this.labLoaiNguoiDungErr);
            this.groupBox1.Controls.Add(this.labTaiKhoanErr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbLoaiNguoiDung);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.chbHienThi);
            this.groupBox1.Controls.Add(this.txbReMatKhau);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbMatKhau);
            this.groupBox1.Controls.Add(this.txbTaiKhoan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 379);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // labReMatKhauErr
            // 
            this.labReMatKhauErr.AutoSize = true;
            this.labReMatKhauErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labReMatKhauErr.Location = new System.Drawing.Point(131, 231);
            this.labReMatKhauErr.Name = "labReMatKhauErr";
            this.labReMatKhauErr.Size = new System.Drawing.Size(0, 15);
            this.labReMatKhauErr.TabIndex = 13;
            // 
            // labMatKhauErr
            // 
            this.labMatKhauErr.AutoSize = true;
            this.labMatKhauErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMatKhauErr.Location = new System.Drawing.Point(131, 173);
            this.labMatKhauErr.Name = "labMatKhauErr";
            this.labMatKhauErr.Size = new System.Drawing.Size(0, 15);
            this.labMatKhauErr.TabIndex = 12;
            // 
            // labLoaiNguoiDungErr
            // 
            this.labLoaiNguoiDungErr.AutoSize = true;
            this.labLoaiNguoiDungErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLoaiNguoiDungErr.Location = new System.Drawing.Point(131, 115);
            this.labLoaiNguoiDungErr.Name = "labLoaiNguoiDungErr";
            this.labLoaiNguoiDungErr.Size = new System.Drawing.Size(0, 15);
            this.labLoaiNguoiDungErr.TabIndex = 11;
            // 
            // labTaiKhoanErr
            // 
            this.labTaiKhoanErr.AutoSize = true;
            this.labTaiKhoanErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTaiKhoanErr.Location = new System.Drawing.Point(131, 55);
            this.labTaiKhoanErr.Name = "labTaiKhoanErr";
            this.labTaiKhoanErr.Size = new System.Drawing.Size(0, 15);
            this.labTaiKhoanErr.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loại người dùng";
            // 
            // cbLoaiNguoiDung
            // 
            this.cbLoaiNguoiDung.FormattingEnabled = true;
            this.cbLoaiNguoiDung.Location = new System.Drawing.Point(147, 86);
            this.cbLoaiNguoiDung.Name = "cbLoaiNguoiDung";
            this.cbLoaiNguoiDung.Size = new System.Drawing.Size(205, 24);
            this.cbLoaiNguoiDung.TabIndex = 8;
            this.cbLoaiNguoiDung.DropDownClosed += new System.EventHandler(this.cbLoaiNguoiDung_DropDownClosed);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThem.BackgroundImage = global::GUI.Properties.Resources.Them;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThem.Location = new System.Drawing.Point(277, 301);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(79, 72);
            this.btnThem.TabIndex = 7;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // chbHienThi
            // 
            this.chbHienThi.AutoSize = true;
            this.chbHienThi.Location = new System.Drawing.Point(147, 262);
            this.chbHienThi.Name = "chbHienThi";
            this.chbHienThi.Size = new System.Drawing.Size(154, 21);
            this.chbHienThi.TabIndex = 6;
            this.chbHienThi.Text = "Hiển thị mật khẩu";
            this.chbHienThi.UseVisualStyleBackColor = true;
            this.chbHienThi.CheckStateChanged += new System.EventHandler(this.chbHienThi_CheckStateChanged);
            // 
            // txbReMatKhau
            // 
            this.txbReMatKhau.Location = new System.Drawing.Point(147, 203);
            this.txbReMatKhau.MaxLength = 16;
            this.txbReMatKhau.Name = "txbReMatKhau";
            this.txbReMatKhau.PasswordChar = '*';
            this.txbReMatKhau.Size = new System.Drawing.Size(205, 23);
            this.txbReMatKhau.TabIndex = 5;
            this.txbReMatKhau.TextChanged += new System.EventHandler(this.txbReMatKhau_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhập lại mật khẩu";
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Location = new System.Drawing.Point(147, 145);
            this.txbMatKhau.MaxLength = 16;
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.PasswordChar = '*';
            this.txbMatKhau.Size = new System.Drawing.Size(205, 23);
            this.txbMatKhau.TabIndex = 3;
            this.txbMatKhau.TextChanged += new System.EventHandler(this.txbMatKhau_TextChanged);
            // 
            // txbTaiKhoan
            // 
            this.txbTaiKhoan.Location = new System.Drawing.Point(147, 27);
            this.txbTaiKhoan.MaxLength = 10;
            this.txbTaiKhoan.Name = "txbTaiKhoan";
            this.txbTaiKhoan.Size = new System.Drawing.Size(205, 23);
            this.txbTaiKhoan.TabIndex = 2;
            this.txbTaiKhoan.TextChanged += new System.EventHandler(this.txbTaiKhoan_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tài khoản";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage2.Controls.Add(this.btnThoat2);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.Control;
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 47);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(994, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Khóa học";
            // 
            // btnThoat2
            // 
            this.btnThoat2.BackColor = System.Drawing.Color.Maroon;
            this.btnThoat2.BackgroundImage = global::GUI.Properties.Resources.Thoat;
            this.btnThoat2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat2.Location = new System.Drawing.Point(898, 386);
            this.btnThoat2.Name = "btnThoat2";
            this.btnThoat2.Size = new System.Drawing.Size(87, 82);
            this.btnThoat2.TabIndex = 8;
            this.btnThoat2.UseVisualStyleBackColor = false;
            this.btnThoat2.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvNamHoc);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(429, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(556, 265);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Khóa học hiện có";
            // 
            // dgvNamHoc
            // 
            this.dgvNamHoc.AllowUserToAddRows = false;
            this.dgvNamHoc.AllowUserToDeleteRows = false;
            this.dgvNamHoc.AllowUserToResizeColumns = false;
            this.dgvNamHoc.AllowUserToResizeRows = false;
            this.dgvNamHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNamHoc.Location = new System.Drawing.Point(6, 36);
            this.dgvNamHoc.Name = "dgvNamHoc";
            this.dgvNamHoc.ReadOnly = true;
            this.dgvNamHoc.Size = new System.Drawing.Size(544, 223);
            this.dgvNamHoc.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labNamErr);
            this.groupBox3.Controls.Add(this.btnThemNam);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txbNamKetThuc);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txbNamBatDau);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(8, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 265);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Khóa học mới";
            // 
            // labNamErr
            // 
            this.labNamErr.AutoSize = true;
            this.labNamErr.Location = new System.Drawing.Point(106, 129);
            this.labNamErr.Name = "labNamErr";
            this.labNamErr.Size = new System.Drawing.Size(0, 17);
            this.labNamErr.TabIndex = 6;
            // 
            // btnThemNam
            // 
            this.btnThemNam.BackColor = System.Drawing.Color.Gray;
            this.btnThemNam.BackgroundImage = global::GUI.Properties.Resources.Them;
            this.btnThemNam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThemNam.Enabled = false;
            this.btnThemNam.Location = new System.Drawing.Point(323, 189);
            this.btnThemNam.Name = "btnThemNam";
            this.btnThemNam.Size = new System.Drawing.Size(76, 70);
            this.btnThemNam.TabIndex = 5;
            this.btnThemNam.UseVisualStyleBackColor = false;
            this.btnThemNam.Click += new System.EventHandler(this.btnThemNam_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Năm bắt đầu";
            // 
            // txbNamKetThuc
            // 
            this.txbNamKetThuc.Location = new System.Drawing.Point(140, 89);
            this.txbNamKetThuc.MaxLength = 4;
            this.txbNamKetThuc.Name = "txbNamKetThuc";
            this.txbNamKetThuc.Size = new System.Drawing.Size(146, 23);
            this.txbNamKetThuc.TabIndex = 4;
            this.txbNamKetThuc.TextChanged += new System.EventHandler(this.txbNam_TextChanged);
            this.txbNamKetThuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.int_KeyPress);
            this.txbNamKetThuc.Validated += new System.EventHandler(this.txbNam_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Năm kết thúc";
            // 
            // txbNamBatDau
            // 
            this.txbNamBatDau.Location = new System.Drawing.Point(140, 30);
            this.txbNamBatDau.MaxLength = 4;
            this.txbNamBatDau.Name = "txbNamBatDau";
            this.txbNamBatDau.Size = new System.Drawing.Size(146, 23);
            this.txbNamBatDau.TabIndex = 3;
            this.txbNamBatDau.TextChanged += new System.EventHandler(this.txbNam_TextChanged);
            this.txbNamBatDau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.int_KeyPress);
            this.txbNamBatDau.Validated += new System.EventHandler(this.txbNam_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(358, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(289, 46);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tạo Khóa Học";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "User.png");
            this.imageList1.Images.SetKeyName(1, "Create.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.dgvNguoiDung);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(376, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 379);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách tài khoản hiện có";
            // 
            // frmQuanTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1001, 526);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmQuanTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Trị";
            this.Load += new System.EventHandler(this.frmQuanTri_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNamHoc)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbHienThi;
        private System.Windows.Forms.TextBox txbReMatKhau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.TextBox txbTaiKhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbLoaiNguoiDung;
        private System.Windows.Forms.DataGridView dgvNguoiDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txbNamKetThuc;
        private System.Windows.Forms.TextBox txbNamBatDau;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvNamHoc;
        private System.Windows.Forms.Button btnThoat2;
        private System.Windows.Forms.Button btnThemNam;
        private System.Windows.Forms.Label labReMatKhauErr;
        private System.Windows.Forms.Label labMatKhauErr;
        private System.Windows.Forms.Label labLoaiNguoiDungErr;
        private System.Windows.Forms.Label labTaiKhoanErr;
        private System.Windows.Forms.Label labNamErr;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}