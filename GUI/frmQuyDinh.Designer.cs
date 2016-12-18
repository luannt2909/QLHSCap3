namespace GUI
{
    partial class frmQuyDinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuyDinh));
            this.labQuyDinh = new System.Windows.Forms.Label();
            this.grbThongTinQuyDinh = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txbDiemDatMon = new System.Windows.Forms.TextBox();
            this.txbDiemDat = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txbDiemToiDa = new System.Windows.Forms.TextBox();
            this.labTuoiToiThieu = new System.Windows.Forms.Label();
            this.txbDiemToiThieu = new System.Windows.Forms.TextBox();
            this.labTuoiToiDa = new System.Windows.Forms.Label();
            this.txbSiSoToiDa = new System.Windows.Forms.TextBox();
            this.labDiemDatMon = new System.Windows.Forms.Label();
            this.txbTuoiToiDa = new System.Windows.Forms.TextBox();
            this.labSiSoToiDa = new System.Windows.Forms.Label();
            this.txbTuoiToiThieu = new System.Windows.Forms.TextBox();
            this.labDiemToiThieu = new System.Windows.Forms.Label();
            this.labDiemToiDa = new System.Windows.Forms.Label();
            this.labDiemDat = new System.Windows.Forms.Label();
            this.grbThongTinQuyDinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // labQuyDinh
            // 
            this.labQuyDinh.AutoSize = true;
            this.labQuyDinh.BackColor = System.Drawing.Color.MidnightBlue;
            this.labQuyDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labQuyDinh.ForeColor = System.Drawing.Color.Beige;
            this.labQuyDinh.Location = new System.Drawing.Point(78, 22);
            this.labQuyDinh.Name = "labQuyDinh";
            this.labQuyDinh.Size = new System.Drawing.Size(647, 46);
            this.labQuyDinh.TabIndex = 0;
            this.labQuyDinh.Text = "Các Quy Định Chung Của Trường";
            // 
            // grbThongTinQuyDinh
            // 
            this.grbThongTinQuyDinh.Controls.Add(this.button2);
            this.grbThongTinQuyDinh.Controls.Add(this.txbDiemDatMon);
            this.grbThongTinQuyDinh.Controls.Add(this.txbDiemDat);
            this.grbThongTinQuyDinh.Controls.Add(this.btnLuu);
            this.grbThongTinQuyDinh.Controls.Add(this.txbDiemToiDa);
            this.grbThongTinQuyDinh.Controls.Add(this.labTuoiToiThieu);
            this.grbThongTinQuyDinh.Controls.Add(this.txbDiemToiThieu);
            this.grbThongTinQuyDinh.Controls.Add(this.labTuoiToiDa);
            this.grbThongTinQuyDinh.Controls.Add(this.txbSiSoToiDa);
            this.grbThongTinQuyDinh.Controls.Add(this.labDiemDatMon);
            this.grbThongTinQuyDinh.Controls.Add(this.txbTuoiToiDa);
            this.grbThongTinQuyDinh.Controls.Add(this.labSiSoToiDa);
            this.grbThongTinQuyDinh.Controls.Add(this.txbTuoiToiThieu);
            this.grbThongTinQuyDinh.Controls.Add(this.labDiemToiThieu);
            this.grbThongTinQuyDinh.Controls.Add(this.labDiemToiDa);
            this.grbThongTinQuyDinh.Controls.Add(this.labDiemDat);
            this.grbThongTinQuyDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTinQuyDinh.ForeColor = System.Drawing.Color.White;
            this.grbThongTinQuyDinh.Location = new System.Drawing.Point(12, 101);
            this.grbThongTinQuyDinh.Name = "grbThongTinQuyDinh";
            this.grbThongTinQuyDinh.Size = new System.Drawing.Size(770, 480);
            this.grbThongTinQuyDinh.TabIndex = 1;
            this.grbThongTinQuyDinh.TabStop = false;
            this.grbThongTinQuyDinh.Text = "Thông tin quy định";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.BackgroundImage = global::GUI.Properties.Resources.Thoat1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(677, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 80);
            this.button2.TabIndex = 15;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txbDiemDatMon
            // 
            this.txbDiemDatMon.Location = new System.Drawing.Point(205, 380);
            this.txbDiemDatMon.Name = "txbDiemDatMon";
            this.txbDiemDatMon.Size = new System.Drawing.Size(100, 23);
            this.txbDiemDatMon.TabIndex = 7;
            this.txbDiemDatMon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.float_KeyPress);
            // 
            // txbDiemDat
            // 
            this.txbDiemDat.Location = new System.Drawing.Point(205, 326);
            this.txbDiemDat.Name = "txbDiemDat";
            this.txbDiemDat.Size = new System.Drawing.Size(100, 23);
            this.txbDiemDat.TabIndex = 12;
            this.txbDiemDat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.float_KeyPress);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Purple;
            this.btnLuu.BackgroundImage = global::GUI.Properties.Resources.Luu;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(559, 394);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(87, 80);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txbDiemToiDa
            // 
            this.txbDiemToiDa.Location = new System.Drawing.Point(205, 266);
            this.txbDiemToiDa.Name = "txbDiemToiDa";
            this.txbDiemToiDa.Size = new System.Drawing.Size(100, 23);
            this.txbDiemToiDa.TabIndex = 8;
            this.txbDiemToiDa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.float_KeyPress);
            // 
            // labTuoiToiThieu
            // 
            this.labTuoiToiThieu.AutoSize = true;
            this.labTuoiToiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTuoiToiThieu.ForeColor = System.Drawing.Color.White;
            this.labTuoiToiThieu.Location = new System.Drawing.Point(17, 49);
            this.labTuoiToiThieu.Name = "labTuoiToiThieu";
            this.labTuoiToiThieu.Size = new System.Drawing.Size(137, 25);
            this.labTuoiToiThieu.TabIndex = 1;
            this.labTuoiToiThieu.Text = "Tuổi tối thiểu";
            // 
            // txbDiemToiThieu
            // 
            this.txbDiemToiThieu.Location = new System.Drawing.Point(205, 206);
            this.txbDiemToiThieu.Name = "txbDiemToiThieu";
            this.txbDiemToiThieu.Size = new System.Drawing.Size(100, 23);
            this.txbDiemToiThieu.TabIndex = 9;
            this.txbDiemToiThieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.float_KeyPress);
            // 
            // labTuoiToiDa
            // 
            this.labTuoiToiDa.AutoSize = true;
            this.labTuoiToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTuoiToiDa.ForeColor = System.Drawing.Color.White;
            this.labTuoiToiDa.Location = new System.Drawing.Point(17, 98);
            this.labTuoiToiDa.Name = "labTuoiToiDa";
            this.labTuoiToiDa.Size = new System.Drawing.Size(114, 25);
            this.labTuoiToiDa.TabIndex = 2;
            this.labTuoiToiDa.Text = "Tuổi tối đa";
            // 
            // txbSiSoToiDa
            // 
            this.txbSiSoToiDa.Location = new System.Drawing.Point(205, 148);
            this.txbSiSoToiDa.Name = "txbSiSoToiDa";
            this.txbSiSoToiDa.Size = new System.Drawing.Size(100, 23);
            this.txbSiSoToiDa.TabIndex = 10;
            this.txbSiSoToiDa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.int_KeyPress);
            // 
            // labDiemDatMon
            // 
            this.labDiemDatMon.AutoSize = true;
            this.labDiemDatMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDiemDatMon.ForeColor = System.Drawing.Color.White;
            this.labDiemDatMon.Location = new System.Drawing.Point(17, 380);
            this.labDiemDatMon.Name = "labDiemDatMon";
            this.labDiemDatMon.Size = new System.Drawing.Size(144, 25);
            this.labDiemDatMon.TabIndex = 5;
            this.labDiemDatMon.Text = "Điểm đạt môn";
            // 
            // txbTuoiToiDa
            // 
            this.txbTuoiToiDa.Location = new System.Drawing.Point(205, 98);
            this.txbTuoiToiDa.Name = "txbTuoiToiDa";
            this.txbTuoiToiDa.Size = new System.Drawing.Size(100, 23);
            this.txbTuoiToiDa.TabIndex = 11;
            this.txbTuoiToiDa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.int_KeyPress);
            // 
            // labSiSoToiDa
            // 
            this.labSiSoToiDa.AutoSize = true;
            this.labSiSoToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSiSoToiDa.ForeColor = System.Drawing.Color.White;
            this.labSiSoToiDa.Location = new System.Drawing.Point(17, 148);
            this.labSiSoToiDa.Name = "labSiSoToiDa";
            this.labSiSoToiDa.Size = new System.Drawing.Size(120, 25);
            this.labSiSoToiDa.TabIndex = 0;
            this.labSiSoToiDa.Text = "Sĩ số tối đa";
            // 
            // txbTuoiToiThieu
            // 
            this.txbTuoiToiThieu.Location = new System.Drawing.Point(205, 49);
            this.txbTuoiToiThieu.Name = "txbTuoiToiThieu";
            this.txbTuoiToiThieu.Size = new System.Drawing.Size(100, 23);
            this.txbTuoiToiThieu.TabIndex = 13;
            this.txbTuoiToiThieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.int_KeyPress);
            // 
            // labDiemToiThieu
            // 
            this.labDiemToiThieu.AutoSize = true;
            this.labDiemToiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDiemToiThieu.ForeColor = System.Drawing.Color.White;
            this.labDiemToiThieu.Location = new System.Drawing.Point(17, 206);
            this.labDiemToiThieu.Name = "labDiemToiThieu";
            this.labDiemToiThieu.Size = new System.Drawing.Size(143, 25);
            this.labDiemToiThieu.TabIndex = 3;
            this.labDiemToiThieu.Text = "Điểm tối thiểu";
            // 
            // labDiemToiDa
            // 
            this.labDiemToiDa.AutoSize = true;
            this.labDiemToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDiemToiDa.ForeColor = System.Drawing.Color.White;
            this.labDiemToiDa.Location = new System.Drawing.Point(17, 266);
            this.labDiemToiDa.Name = "labDiemToiDa";
            this.labDiemToiDa.Size = new System.Drawing.Size(120, 25);
            this.labDiemToiDa.TabIndex = 4;
            this.labDiemToiDa.Text = "Điểm tối đa";
            // 
            // labDiemDat
            // 
            this.labDiemDat.AutoSize = true;
            this.labDiemDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDiemDat.ForeColor = System.Drawing.Color.White;
            this.labDiemDat.Location = new System.Drawing.Point(17, 321);
            this.labDiemDat.Name = "labDiemDat";
            this.labDiemDat.Size = new System.Drawing.Size(97, 25);
            this.labDiemDat.TabIndex = 6;
            this.labDiemDat.Text = "Điểm đạt";
            // 
            // frmQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(791, 602);
            this.Controls.Add(this.grbThongTinQuyDinh);
            this.Controls.Add(this.labQuyDinh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmQuyDinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quy Định";
            this.Load += new System.EventHandler(this.frmQuyDinh_Load);
            this.grbThongTinQuyDinh.ResumeLayout(false);
            this.grbThongTinQuyDinh.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labQuyDinh;
        private System.Windows.Forms.GroupBox grbThongTinQuyDinh;
        private System.Windows.Forms.Label labSiSoToiDa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txbTuoiToiThieu;
        private System.Windows.Forms.TextBox txbDiemDat;
        private System.Windows.Forms.TextBox txbTuoiToiDa;
        private System.Windows.Forms.TextBox txbSiSoToiDa;
        private System.Windows.Forms.TextBox txbDiemToiThieu;
        private System.Windows.Forms.TextBox txbDiemToiDa;
        private System.Windows.Forms.TextBox txbDiemDatMon;
        private System.Windows.Forms.Label labDiemDat;
        private System.Windows.Forms.Label labDiemDatMon;
        private System.Windows.Forms.Label labDiemToiDa;
        private System.Windows.Forms.Label labDiemToiThieu;
        private System.Windows.Forms.Label labTuoiToiDa;
        private System.Windows.Forms.Label labTuoiToiThieu;
    }
}