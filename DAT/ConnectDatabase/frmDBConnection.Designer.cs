namespace DAT.ConnectDatabase
{
    partial class frmDBConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBConnection));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimServer = new System.Windows.Forms.Button();
            this.cbTenServer = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.txbTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbChungThucServer = new System.Windows.Forms.RadioButton();
            this.rdbChungThucWindows = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTaoDuLieuMau = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbTenCSDL = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txbTenCSDLMoi = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimServer);
            this.groupBox1.Controls.Add(this.cbTenServer);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn cơ SQL Server";
            // 
            // btnTimServer
            // 
            this.btnTimServer.ForeColor = System.Drawing.Color.Black;
            this.btnTimServer.Location = new System.Drawing.Point(370, 36);
            this.btnTimServer.Name = "btnTimServer";
            this.btnTimServer.Size = new System.Drawing.Size(103, 23);
            this.btnTimServer.TabIndex = 2;
            this.btnTimServer.Text = "Tìm Server";
            this.btnTimServer.UseVisualStyleBackColor = true;
            this.btnTimServer.Click += new System.EventHandler(this.btnTimServer_Click);
            // 
            // cbTenServer
            // 
            this.cbTenServer.FormattingEnabled = true;
            this.cbTenServer.Location = new System.Drawing.Point(15, 35);
            this.cbTenServer.Name = "cbTenServer";
            this.cbTenServer.Size = new System.Drawing.Size(335, 24);
            this.cbTenServer.TabIndex = 0;
            this.cbTenServer.SelectedIndexChanged += new System.EventHandler(this.cbTenServer_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKetNoi);
            this.groupBox2.Controls.Add(this.txbMatKhau);
            this.groupBox2.Controls.Add(this.txbTenTaiKhoan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rdbChungThucServer);
            this.groupBox2.Controls.Add(this.rdbChungThucWindows);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đăng nhập vào SQL  Server";
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.ForeColor = System.Drawing.Color.Black;
            this.btnKetNoi.Location = new System.Drawing.Point(398, 132);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(81, 27);
            this.btnKetNoi.TabIndex = 6;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Location = new System.Drawing.Point(123, 108);
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.Size = new System.Drawing.Size(227, 23);
            this.txbMatKhau.TabIndex = 5;
            // 
            // txbTenTaiKhoan
            // 
            this.txbTenTaiKhoan.Location = new System.Drawing.Point(123, 78);
            this.txbTenTaiKhoan.Name = "txbTenTaiKhoan";
            this.txbTenTaiKhoan.Size = new System.Drawing.Size(227, 23);
            this.txbTenTaiKhoan.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài khoản";
            // 
            // rdbChungThucServer
            // 
            this.rdbChungThucServer.AutoSize = true;
            this.rdbChungThucServer.Location = new System.Drawing.Point(15, 49);
            this.rdbChungThucServer.Name = "rdbChungThucServer";
            this.rdbChungThucServer.Size = new System.Drawing.Size(224, 21);
            this.rdbChungThucServer.TabIndex = 1;
            this.rdbChungThucServer.TabStop = true;
            this.rdbChungThucServer.Text = "Sử dụng chứng thực Server";
            this.rdbChungThucServer.UseVisualStyleBackColor = true;
            this.rdbChungThucServer.CheckedChanged += new System.EventHandler(this.rdbChungthucServer_CheckedChanged);
            // 
            // rdbChungThucWindows
            // 
            this.rdbChungThucWindows.AutoSize = true;
            this.rdbChungThucWindows.Location = new System.Drawing.Point(15, 22);
            this.rdbChungThucWindows.Name = "rdbChungThucWindows";
            this.rdbChungThucWindows.Size = new System.Drawing.Size(239, 21);
            this.rdbChungThucWindows.TabIndex = 0;
            this.rdbChungThucWindows.TabStop = true;
            this.rdbChungThucWindows.Text = "Sử dụng chứng thực Windows";
            this.rdbChungThucWindows.UseVisualStyleBackColor = true;
            this.rdbChungThucWindows.CheckedChanged += new System.EventHandler(this.rdbChungThucWindows_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTaoDuLieuMau);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 179);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn cơ sở dữ liệu";
            // 
            // btnTaoDuLieuMau
            // 
            this.btnTaoDuLieuMau.ForeColor = System.Drawing.Color.Black;
            this.btnTaoDuLieuMau.Location = new System.Drawing.Point(312, 130);
            this.btnTaoDuLieuMau.Name = "btnTaoDuLieuMau";
            this.btnTaoDuLieuMau.Size = new System.Drawing.Size(161, 37);
            this.btnTaoDuLieuMau.TabIndex = 7;
            this.btnTaoDuLieuMau.Text = "Tạo dữ liệu mẫu";
            this.btnTaoDuLieuMau.UseVisualStyleBackColor = true;
            this.btnTaoDuLieuMau.Click += new System.EventHandler(this.btnTaoDuLieuMau_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tạo dữ liệu mẫu cho CSDL";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txbTenCSDLMoi);
            this.groupBox5.Controls.Add(this.btnTaoMoi);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(245, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(234, 100);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.ForeColor = System.Drawing.Color.Black;
            this.btnTaoMoi.Location = new System.Drawing.Point(153, 65);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(75, 29);
            this.btnTaoMoi.TabIndex = 6;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tạo cơ sở dữ liệu mới";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbTenCSDL);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(6, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 100);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // cbTenCSDL
            // 
            this.cbTenCSDL.FormattingEnabled = true;
            this.cbTenCSDL.Location = new System.Drawing.Point(6, 49);
            this.cbTenCSDL.Name = "cbTenCSDL";
            this.cbTenCSDL.Size = new System.Drawing.Size(193, 24);
            this.cbTenCSDL.TabIndex = 1;
            this.cbTenCSDL.SelectedIndexChanged += new System.EventHandler(this.cbTenCSDL_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chọn cơ sở dữ liệu có sẵn";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(416, 537);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 24);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(328, 537);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 24);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txbTenCSDLMoi
            // 
            this.txbTenCSDLMoi.Location = new System.Drawing.Point(9, 36);
            this.txbTenCSDLMoi.Name = "txbTenCSDLMoi";
            this.txbTenCSDLMoi.Size = new System.Drawing.Size(219, 23);
            this.txbTenCSDLMoi.TabIndex = 8;
            // 
            // frmDBConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(505, 573);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDBConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Nối Cơ Sở Dữ Liệu";
            this.Load += new System.EventHandler(this.frmDBConnection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.TextBox txbTenTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbChungThucServer;
        private System.Windows.Forms.RadioButton rdbChungThucWindows;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbTenCSDL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnTaoDuLieuMau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTenServer;
        private System.Windows.Forms.Button btnTimServer;
        private System.Windows.Forms.TextBox txbTenCSDLMoi;
    }
}