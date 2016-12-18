namespace GUI
{
    partial class frmBaoCao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaoCaoMon = new System.Windows.Forms.Button();
            this.btnInBaoCaoMon = new System.Windows.Forms.Button();
            this.btnThoat1 = new System.Windows.Forms.Button();
            this.dgvBaoCaoMon = new System.Windows.Forms.DataGridView();
            this.cbMonHoc = new System.Windows.Forms.ComboBox();
            this.cbHocKy1 = new System.Windows.Forms.ComboBox();
            this.cbNamHoc1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBaoCaoHocKy = new System.Windows.Forms.Button();
            this.btnInBaoCaoHocKy = new System.Windows.Forms.Button();
            this.btnThoat2 = new System.Windows.Forms.Button();
            this.dgvBaoCaoHocKy = new System.Windows.Forms.DataGridView();
            this.cbHocKy2 = new System.Windows.Forms.ComboBox();
            this.cbNamHoc2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.printDocumentBaoCaoMon = new System.Drawing.Printing.PrintDocument();
            this.printDocumentBaoCaoHocKy = new System.Drawing.Printing.PrintDocument();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoMon)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoHocKy)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 630);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 47);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1109, 579);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tổng Kết Môn Học";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaoCaoMon);
            this.groupBox1.Controls.Add(this.btnInBaoCaoMon);
            this.groupBox1.Controls.Add(this.btnThoat1);
            this.groupBox1.Controls.Add(this.dgvBaoCaoMon);
            this.groupBox1.Controls.Add(this.cbMonHoc);
            this.groupBox1.Controls.Add(this.cbHocKy1);
            this.groupBox1.Controls.Add(this.cbNamHoc1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(9, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1093, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lập báo cáo tổng kết môn";
            // 
            // btnBaoCaoMon
            // 
            this.btnBaoCaoMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBaoCaoMon.BackgroundImage = global::GUI.Properties.Resources.ThongKe;
            this.btnBaoCaoMon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBaoCaoMon.Location = new System.Drawing.Point(990, 94);
            this.btnBaoCaoMon.Name = "btnBaoCaoMon";
            this.btnBaoCaoMon.Size = new System.Drawing.Size(97, 76);
            this.btnBaoCaoMon.TabIndex = 11;
            this.btnBaoCaoMon.Text = "\r\n\rBáo cáo";
            this.btnBaoCaoMon.UseVisualStyleBackColor = false;
            this.btnBaoCaoMon.Click += new System.EventHandler(this.btnBaoCaoMon_Click);
            // 
            // btnInBaoCaoMon
            // 
            this.btnInBaoCaoMon.BackColor = System.Drawing.Color.Blue;
            this.btnInBaoCaoMon.BackgroundImage = global::GUI.Properties.Resources.NhapDiem11;
            this.btnInBaoCaoMon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInBaoCaoMon.Location = new System.Drawing.Point(990, 185);
            this.btnInBaoCaoMon.Name = "btnInBaoCaoMon";
            this.btnInBaoCaoMon.Size = new System.Drawing.Size(97, 76);
            this.btnInBaoCaoMon.TabIndex = 10;
            this.btnInBaoCaoMon.Text = "\r\n\r\n\r\nIn";
            this.btnInBaoCaoMon.UseVisualStyleBackColor = false;
            this.btnInBaoCaoMon.Click += new System.EventHandler(this.btnInBaoCaoMon_Click);
            // 
            // btnThoat1
            // 
            this.btnThoat1.BackColor = System.Drawing.Color.Maroon;
            this.btnThoat1.BackgroundImage = global::GUI.Properties.Resources.Thoat;
            this.btnThoat1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat1.Location = new System.Drawing.Point(990, 364);
            this.btnThoat1.Name = "btnThoat1";
            this.btnThoat1.Size = new System.Drawing.Size(97, 76);
            this.btnThoat1.TabIndex = 9;
            this.btnThoat1.UseVisualStyleBackColor = false;
            this.btnThoat1.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvBaoCaoMon
            // 
            this.dgvBaoCaoMon.AllowUserToAddRows = false;
            this.dgvBaoCaoMon.AllowUserToDeleteRows = false;
            this.dgvBaoCaoMon.AllowUserToResizeColumns = false;
            this.dgvBaoCaoMon.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoMon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBaoCaoMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCaoMon.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvBaoCaoMon.Location = new System.Drawing.Point(9, 94);
            this.dgvBaoCaoMon.Name = "dgvBaoCaoMon";
            this.dgvBaoCaoMon.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoMon.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBaoCaoMon.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvBaoCaoMon.Size = new System.Drawing.Size(975, 346);
            this.dgvBaoCaoMon.TabIndex = 6;
            // 
            // cbMonHoc
            // 
            this.cbMonHoc.FormattingEnabled = true;
            this.cbMonHoc.Location = new System.Drawing.Point(832, 30);
            this.cbMonHoc.Name = "cbMonHoc";
            this.cbMonHoc.Size = new System.Drawing.Size(152, 24);
            this.cbMonHoc.TabIndex = 5;
            this.cbMonHoc.DropDownClosed += new System.EventHandler(this.cbMonHoc_DropDownClosed);
            // 
            // cbHocKy1
            // 
            this.cbHocKy1.FormattingEnabled = true;
            this.cbHocKy1.Location = new System.Drawing.Point(427, 30);
            this.cbHocKy1.Name = "cbHocKy1";
            this.cbHocKy1.Size = new System.Drawing.Size(140, 24);
            this.cbHocKy1.TabIndex = 4;
            this.cbHocKy1.DropDownClosed += new System.EventHandler(this.cbHocKy1_DropDownClosed);
            // 
            // cbNamHoc1
            // 
            this.cbNamHoc1.FormattingEnabled = true;
            this.cbNamHoc1.Location = new System.Drawing.Point(83, 30);
            this.cbNamHoc1.Name = "cbNamHoc1";
            this.cbNamHoc1.Size = new System.Drawing.Size(136, 24);
            this.cbNamHoc1.TabIndex = 3;
            this.cbNamHoc1.DropDownClosed += new System.EventHandler(this.cbNamHoc1_DropDownClosed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(755, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Môn học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Học kỳ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Năm học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(287, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo Cáo Tổng Kết Môn Học";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 47);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1109, 579);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tổng Kết Học Kỳ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBaoCaoHocKy);
            this.groupBox2.Controls.Add(this.btnInBaoCaoHocKy);
            this.groupBox2.Controls.Add(this.btnThoat2);
            this.groupBox2.Controls.Add(this.dgvBaoCaoHocKy);
            this.groupBox2.Controls.Add(this.cbHocKy2);
            this.groupBox2.Controls.Add(this.cbNamHoc2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(8, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1093, 474);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lập báo cáo tổng kết học kỳ";
            // 
            // btnBaoCaoHocKy
            // 
            this.btnBaoCaoHocKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBaoCaoHocKy.BackgroundImage = global::GUI.Properties.Resources.ThongKe;
            this.btnBaoCaoHocKy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBaoCaoHocKy.Location = new System.Drawing.Point(990, 94);
            this.btnBaoCaoHocKy.Name = "btnBaoCaoHocKy";
            this.btnBaoCaoHocKy.Size = new System.Drawing.Size(97, 76);
            this.btnBaoCaoHocKy.TabIndex = 11;
            this.btnBaoCaoHocKy.Text = "\r\n\rBáo cáo";
            this.btnBaoCaoHocKy.UseVisualStyleBackColor = false;
            this.btnBaoCaoHocKy.Click += new System.EventHandler(this.btnBaoCaoHocKy_Click);
            // 
            // btnInBaoCaoHocKy
            // 
            this.btnInBaoCaoHocKy.BackColor = System.Drawing.Color.Blue;
            this.btnInBaoCaoHocKy.BackgroundImage = global::GUI.Properties.Resources.NhapDiem11;
            this.btnInBaoCaoHocKy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInBaoCaoHocKy.Location = new System.Drawing.Point(990, 190);
            this.btnInBaoCaoHocKy.Name = "btnInBaoCaoHocKy";
            this.btnInBaoCaoHocKy.Size = new System.Drawing.Size(97, 76);
            this.btnInBaoCaoHocKy.TabIndex = 10;
            this.btnInBaoCaoHocKy.Text = "\r\n\r\n\r\nIn";
            this.btnInBaoCaoHocKy.UseVisualStyleBackColor = false;
            this.btnInBaoCaoHocKy.Click += new System.EventHandler(this.btnInBaoCaoHocKy_Click);
            // 
            // btnThoat2
            // 
            this.btnThoat2.BackColor = System.Drawing.Color.Maroon;
            this.btnThoat2.BackgroundImage = global::GUI.Properties.Resources.Thoat;
            this.btnThoat2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat2.Location = new System.Drawing.Point(990, 392);
            this.btnThoat2.Name = "btnThoat2";
            this.btnThoat2.Size = new System.Drawing.Size(97, 76);
            this.btnThoat2.TabIndex = 9;
            this.btnThoat2.UseVisualStyleBackColor = false;
            this.btnThoat2.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvBaoCaoHocKy
            // 
            this.dgvBaoCaoHocKy.AllowUserToAddRows = false;
            this.dgvBaoCaoHocKy.AllowUserToDeleteRows = false;
            this.dgvBaoCaoHocKy.AllowUserToResizeColumns = false;
            this.dgvBaoCaoHocKy.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoHocKy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvBaoCaoHocKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCaoHocKy.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvBaoCaoHocKy.Location = new System.Drawing.Point(9, 94);
            this.dgvBaoCaoHocKy.Name = "dgvBaoCaoHocKy";
            this.dgvBaoCaoHocKy.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoHocKy.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvBaoCaoHocKy.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvBaoCaoHocKy.Size = new System.Drawing.Size(975, 374);
            this.dgvBaoCaoHocKy.TabIndex = 6;
            // 
            // cbHocKy2
            // 
            this.cbHocKy2.FormattingEnabled = true;
            this.cbHocKy2.Location = new System.Drawing.Point(418, 30);
            this.cbHocKy2.Name = "cbHocKy2";
            this.cbHocKy2.Size = new System.Drawing.Size(142, 24);
            this.cbHocKy2.TabIndex = 4;
            this.cbHocKy2.DropDownClosed += new System.EventHandler(this.cbHocKy2_DropDownClosed);
            // 
            // cbNamHoc2
            // 
            this.cbNamHoc2.FormattingEnabled = true;
            this.cbNamHoc2.Location = new System.Drawing.Point(98, 30);
            this.cbNamHoc2.Name = "cbNamHoc2";
            this.cbNamHoc2.Size = new System.Drawing.Size(143, 24);
            this.cbNamHoc2.TabIndex = 3;
            this.cbNamHoc2.DropDownClosed += new System.EventHandler(this.cbNamHoc2_DropDownClosed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(325, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Học kỳ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Năm học";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(292, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(513, 46);
            this.label5.TabIndex = 0;
            this.label5.Text = "Báo Cáo Tổng Kết Học Kỳ";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Stats.png");
            this.imageList1.Images.SetKeyName(1, "OpenProj_App_Icon_by_marc2o.png");
            // 
            // printDocumentBaoCaoMon
            // 
            this.printDocumentBaoCaoMon.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocumentBaoCaoMon_BeginPrint);
            this.printDocumentBaoCaoMon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentBaoCao_PrintPage);
            // 
            // printDocumentBaoCaoHocKy
            // 
            this.printDocumentBaoCaoHocKy.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocumentBaoCaoHocKy_BeginPrint);
            this.printDocumentBaoCaoHocKy.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentBaoCaoHocKy_PrintPage);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1117, 601);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoMon)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoHocKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbMonHoc;
        private System.Windows.Forms.ComboBox cbHocKy1;
        private System.Windows.Forms.ComboBox cbNamHoc1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBaoCaoMon;
        private System.Windows.Forms.Button btnThoat1;
        private System.Windows.Forms.Button btnInBaoCaoMon;
        private System.Windows.Forms.Button btnBaoCaoMon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBaoCaoHocKy;
        private System.Windows.Forms.Button btnInBaoCaoHocKy;
        private System.Windows.Forms.Button btnThoat2;
        private System.Windows.Forms.DataGridView dgvBaoCaoHocKy;
        private System.Windows.Forms.ComboBox cbHocKy2;
        private System.Windows.Forms.ComboBox cbNamHoc2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Drawing.Printing.PrintDocument printDocumentBaoCaoMon;
        private System.Drawing.Printing.PrintDocument printDocumentBaoCaoHocKy;
    }
}