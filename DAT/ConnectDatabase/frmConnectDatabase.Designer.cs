namespace DAT.ConnectDatabase
{
    partial class frmConnectDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnectDatabase));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txbThongTinKetNoiServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.chbHienThiMatKhau = new System.Windows.Forms.CheckBox();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.txbTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.cbKieuXacThuc = new System.Windows.Forms.ComboBox();
            this.cbTenServer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnKetNoiCSDL = new System.Windows.Forms.Panel();
            this.txbTaoCSDLMoi = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTaoDuLieuMau = new System.Windows.Forms.Button();
            this.cbTenCSDL = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txbThongTinKetNoiCSDL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.pnKetNoiServer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnKetNoiCSDL.SuspendLayout();
            this.pnKetNoiServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DAT.Properties.Resources.logo_msSQL2005;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(519, 71);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // txbThongTinKetNoiServer
            // 
            this.txbThongTinKetNoiServer.Enabled = false;
            this.txbThongTinKetNoiServer.Location = new System.Drawing.Point(6, 273);
            this.txbThongTinKetNoiServer.Multiline = true;
            this.txbThongTinKetNoiServer.Name = "txbThongTinKetNoiServer";
            this.txbThongTinKetNoiServer.Size = new System.Drawing.Size(504, 47);
            this.txbThongTinKetNoiServer.TabIndex = 12;
            this.txbThongTinKetNoiServer.TextChanged += new System.EventHandler(this.txbThongTinKetNoiServer_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(10, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Thông tin kết nối";
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetNoi.ForeColor = System.Drawing.Color.White;
            this.btnKetNoi.Location = new System.Drawing.Point(407, 237);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(103, 30);
            this.btnKetNoi.TabIndex = 6;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.UseVisualStyleBackColor = false;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // chbHienThiMatKhau
            // 
            this.chbHienThiMatKhau.AutoSize = true;
            this.chbHienThiMatKhau.ForeColor = System.Drawing.Color.White;
            this.chbHienThiMatKhau.Location = new System.Drawing.Point(168, 199);
            this.chbHienThiMatKhau.Name = "chbHienThiMatKhau";
            this.chbHienThiMatKhau.Size = new System.Drawing.Size(154, 21);
            this.chbHienThiMatKhau.TabIndex = 5;
            this.chbHienThiMatKhau.Text = "Hiển thị mật khẩu";
            this.chbHienThiMatKhau.UseVisualStyleBackColor = true;
            this.chbHienThiMatKhau.CheckedChanged += new System.EventHandler(this.chbHienThiMatKhau_CheckedChanged);
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Location = new System.Drawing.Point(168, 170);
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.Size = new System.Drawing.Size(206, 23);
            this.txbMatKhau.TabIndex = 4;
            this.txbMatKhau.TextChanged += new System.EventHandler(this.txbMatKhau_TextChanged);
            // 
            // txbTenTaiKhoan
            // 
            this.txbTenTaiKhoan.Location = new System.Drawing.Point(168, 136);
            this.txbTenTaiKhoan.Name = "txbTenTaiKhoan";
            this.txbTenTaiKhoan.Size = new System.Drawing.Size(206, 23);
            this.txbTenTaiKhoan.TabIndex = 3;
            this.txbTenTaiKhoan.TextChanged += new System.EventHandler(this.txbTenTaiKhoan_TextChanged);
            // 
            // cbKieuXacThuc
            // 
            this.cbKieuXacThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKieuXacThuc.FormattingEnabled = true;
            this.cbKieuXacThuc.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbKieuXacThuc.Location = new System.Drawing.Point(141, 106);
            this.cbKieuXacThuc.Name = "cbKieuXacThuc";
            this.cbKieuXacThuc.Size = new System.Drawing.Size(233, 24);
            this.cbKieuXacThuc.TabIndex = 2;
            this.cbKieuXacThuc.SelectedIndexChanged += new System.EventHandler(this.cbKieuXacThuc_SelectedIndexChanged);
            // 
            // cbTenServer
            // 
            this.cbTenServer.FormattingEnabled = true;
            this.cbTenServer.Location = new System.Drawing.Point(141, 76);
            this.cbTenServer.Name = "cbTenServer";
            this.cbTenServer.Size = new System.Drawing.Size(233, 24);
            this.cbTenServer.TabIndex = 1;
            this.cbTenServer.SelectedIndexChanged += new System.EventHandler(this.cbTenServer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kiểu xác thực";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnKetNoiCSDL);
            this.groupBox2.Controls.Add(this.pnKetNoiServer);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 643);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // pnKetNoiCSDL
            // 
            this.pnKetNoiCSDL.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnKetNoiCSDL.Controls.Add(this.txbTaoCSDLMoi);
            this.pnKetNoiCSDL.Controls.Add(this.btnThoat);
            this.pnKetNoiCSDL.Controls.Add(this.btnTaoDuLieuMau);
            this.pnKetNoiCSDL.Controls.Add(this.cbTenCSDL);
            this.pnKetNoiCSDL.Controls.Add(this.label8);
            this.pnKetNoiCSDL.Controls.Add(this.btnLuu);
            this.pnKetNoiCSDL.Controls.Add(this.txbThongTinKetNoiCSDL);
            this.pnKetNoiCSDL.Controls.Add(this.label7);
            this.pnKetNoiCSDL.Controls.Add(this.btnXoa);
            this.pnKetNoiCSDL.Controls.Add(this.btnKiemTra);
            this.pnKetNoiCSDL.Controls.Add(this.btnTaoMoi);
            this.pnKetNoiCSDL.Location = new System.Drawing.Point(6, 367);
            this.pnKetNoiCSDL.Name = "pnKetNoiCSDL";
            this.pnKetNoiCSDL.Size = new System.Drawing.Size(519, 266);
            this.pnKetNoiCSDL.TabIndex = 5;
            // 
            // txbTaoCSDLMoi
            // 
            this.txbTaoCSDLMoi.Location = new System.Drawing.Point(9, 110);
            this.txbTaoCSDLMoi.Name = "txbTaoCSDLMoi";
            this.txbTaoCSDLMoi.Size = new System.Drawing.Size(176, 23);
            this.txbTaoCSDLMoi.TabIndex = 21;
            this.txbTaoCSDLMoi.TextChanged += new System.EventHandler(this.txbTaoCSDLMoi_TextChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(407, 224);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(103, 30);
            this.btnThoat.TabIndex = 20;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTaoDuLieuMau
            // 
            this.btnTaoDuLieuMau.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTaoDuLieuMau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoDuLieuMau.ForeColor = System.Drawing.Color.White;
            this.btnTaoDuLieuMau.Location = new System.Drawing.Point(407, 75);
            this.btnTaoDuLieuMau.Name = "btnTaoDuLieuMau";
            this.btnTaoDuLieuMau.Size = new System.Drawing.Size(103, 58);
            this.btnTaoDuLieuMau.TabIndex = 19;
            this.btnTaoDuLieuMau.Text = "Tạo dữ liệu mẫu";
            this.btnTaoDuLieuMau.UseVisualStyleBackColor = false;
            this.btnTaoDuLieuMau.Click += new System.EventHandler(this.btnTaoDuLieuMau_Click);
            // 
            // cbTenCSDL
            // 
            this.cbTenCSDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenCSDL.FormattingEnabled = true;
            this.cbTenCSDL.Location = new System.Drawing.Point(6, 45);
            this.cbTenCSDL.Name = "cbTenCSDL";
            this.cbTenCSDL.Size = new System.Drawing.Size(179, 24);
            this.cbTenCSDL.TabIndex = 18;
            this.cbTenCSDL.SelectedIndexChanged += new System.EventHandler(this.cbTenCSDL_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(9, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(366, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Chọn hoặc nhập tên cơ sở dữ liệu để tạo mới";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(271, 224);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(103, 30);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txbThongTinKetNoiCSDL
            // 
            this.txbThongTinKetNoiCSDL.Enabled = false;
            this.txbThongTinKetNoiCSDL.Location = new System.Drawing.Point(6, 171);
            this.txbThongTinKetNoiCSDL.Multiline = true;
            this.txbThongTinKetNoiCSDL.Name = "txbThongTinKetNoiCSDL";
            this.txbThongTinKetNoiCSDL.Size = new System.Drawing.Size(504, 47);
            this.txbThongTinKetNoiCSDL.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(10, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Thông tin kết nối";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(407, 39);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(103, 30);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnKiemTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTra.ForeColor = System.Drawing.Color.White;
            this.btnKiemTra.Location = new System.Drawing.Point(202, 39);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(103, 30);
            this.btnKiemTra.TabIndex = 7;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTaoMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoMoi.Location = new System.Drawing.Point(202, 103);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(103, 30);
            this.btnTaoMoi.TabIndex = 8;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = false;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // pnKetNoiServer
            // 
            this.pnKetNoiServer.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnKetNoiServer.Controls.Add(this.pictureBox2);
            this.pnKetNoiServer.Controls.Add(this.txbThongTinKetNoiServer);
            this.pnKetNoiServer.Controls.Add(this.label6);
            this.pnKetNoiServer.Controls.Add(this.label1);
            this.pnKetNoiServer.Controls.Add(this.label2);
            this.pnKetNoiServer.Controls.Add(this.btnKetNoi);
            this.pnKetNoiServer.Controls.Add(this.label3);
            this.pnKetNoiServer.Controls.Add(this.chbHienThiMatKhau);
            this.pnKetNoiServer.Controls.Add(this.cbKieuXacThuc);
            this.pnKetNoiServer.Controls.Add(this.txbMatKhau);
            this.pnKetNoiServer.Controls.Add(this.txbTenTaiKhoan);
            this.pnKetNoiServer.Controls.Add(this.cbTenServer);
            this.pnKetNoiServer.Controls.Add(this.label4);
            this.pnKetNoiServer.ForeColor = System.Drawing.Color.White;
            this.pnKetNoiServer.Location = new System.Drawing.Point(6, 22);
            this.pnKetNoiServer.Name = "pnKetNoiServer";
            this.pnKetNoiServer.Size = new System.Drawing.Size(519, 328);
            this.pnKetNoiServer.TabIndex = 4;
            // 
            // frmConnectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(541, 659);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(557, 698);
            this.Name = "frmConnectDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Nối Cơ Sở Sữ Liệu";
            this.Load += new System.EventHandler(this.frmConnectDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pnKetNoiCSDL.ResumeLayout(false);
            this.pnKetNoiCSDL.PerformLayout();
            this.pnKetNoiServer.ResumeLayout(false);
            this.pnKetNoiServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.CheckBox chbHienThiMatKhau;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.TextBox txbTenTaiKhoan;
        private System.Windows.Forms.ComboBox cbKieuXacThuc;
        private System.Windows.Forms.ComboBox cbTenServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbThongTinKetNoiServer;
        private System.Windows.Forms.TextBox txbThongTinKetNoiCSDL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnKetNoiCSDL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnKetNoiServer;
        private System.Windows.Forms.ComboBox cbTenCSDL;
        private System.Windows.Forms.Button btnTaoDuLieuMau;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txbTaoCSDLMoi;
    }
}