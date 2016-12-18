using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BUS;

namespace GUI
{
    public partial class frmTraCuu : Form
    {
        NamHocBUS nh_objdm = new NamHocBUS();
        HocSinhBUS hs_objdm = new HocSinhBUS();
        LopBUS lh_objdm = new LopBUS();

        StringFormat strFormat; // Sử dụng để định dang chuỗi trong các dòng của DataGridView
        ArrayList arrColumnCoor = new ArrayList(); // Sử dụng để lưu tọa độ của các cột
        ArrayList arrColumnWidths = new ArrayList(); // Sử dụng để lưu độ rộng của các cột
        int iCellHeight = 0; // Sử dụng thể thiết lập giá trị độ cao của các cell
        int iTotalWidth = 0; // Tính tổng độ rộng cần để in
        int iCount = 0; // Đếm số row
        int iHeaderHeight = 0; // Độ cao của header
        bool bFirstPage = false;
        bool bNewPage = false;

        #region Sự kiện form
        public frmTraCuu()
        {
            InitializeComponent();
        }
        private void frmTraCuu_Load(object sender, EventArgs e)
        {
            loadNamHoc(cbNamHoc);
            txbTenHocSinh.ForeColor = Color.Gray;
        }
        #endregion

        #region Sự kiện chính
        private void cbNamHoc_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc.SelectedItem != null)
            {
                loadLop();
                loadDanhSachHocSinh();
            }
        }

        // Tìm kiếm theo lớp
        private void cbLop_DropDownClosed(object sender, EventArgs e)
        {
            if (cbLop.SelectedItem != null)
            {
                foreach (DataGridViewRow row in dgvHocSinh.Rows)
                {
                    if (row.Cells[2].Value.ToString() == cbLop.SelectedValue.ToString())
                    {
                        CurrencyManager cM = (CurrencyManager)BindingContext[dgvHocSinh.DataSource];
                        cM.SuspendBinding();
                        row.Visible = true;
                        cM.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager cM = (CurrencyManager)BindingContext[dgvHocSinh.DataSource];
                        cM.SuspendBinding();
                        row.Visible = false;
                        cM.ResumeBinding();
                    }
                }
            }
        }

        private void txbTenHocSinh_Enter(object sender, EventArgs e)
        {
            if (txbTenHocSinh.Text == "Nhập tên học sinh cần tìm...")
            {
                txbTenHocSinh.Text = string.Empty;
                txbTenHocSinh.ForeColor = Color.Black;
            }
        }

        // Tìm kiếm theo tên học sinh (và lớp)
        private void txbTenHocSinh_TextChanged(object sender, EventArgs e)
        {
            if (cbLop.SelectedItem != null) // Có tìm theo lớp
            {
                foreach (DataGridViewRow row in dgvHocSinh.Rows)
                {
                    if (row.Cells[2].Value.ToString() == cbLop.SelectedValue.ToString() && row.Cells[1].Value.ToString().Contains(txbTenHocSinh.Text))
                    {
                        CurrencyManager cM = (CurrencyManager)BindingContext[dgvHocSinh.DataSource];
                        cM.SuspendBinding();
                        row.Visible = true;
                        cM.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager cM = (CurrencyManager)BindingContext[dgvHocSinh.DataSource];
                        cM.SuspendBinding();
                        row.Visible = false;
                        cM.ResumeBinding();
                    }
                }
            }
            else // Không tìm theo lớp
            {
                foreach (DataGridViewRow row in dgvHocSinh.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(txbTenHocSinh.Text))
                    {
                        CurrencyManager cM = (CurrencyManager)BindingContext[dgvHocSinh.DataSource];
                        cM.SuspendBinding();
                        row.Visible = true;
                        cM.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager cM = (CurrencyManager)BindingContext[dgvHocSinh.DataSource];
                        cM.SuspendBinding();
                        row.Visible = false;
                        cM.ResumeBinding();
                    }
                }
            }
        }
        private void txbTenHocSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"^[\p{L} ]+$"))
            {
                e.Handled = true;
            }
        }

        private void txbTenHocSinh_Leave(object sender, EventArgs e)
        {
            if (txbTenHocSinh.Text == string.Empty)
            {
                txbTenHocSinh.Text = "Nhập tên học sinh cần tìm...";
                txbTenHocSinh.ForeColor = Color.Gray;
            }
        }
        // Sự kiện của button In
        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocumentTraCuu;
            printDialog.UseEXDialog = true;

            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocumentTraCuu.DocumentName = "Danh sách học sinh - tra cứu";
                printDocumentTraCuu.Print();
            }
        }

        private void printDocumentTraCuu_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnCoor.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iCount = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dgvHocSinh.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocumentTraCuu_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                // Đặt lề trái
                int iLeftMargin = e.MarginBounds.Left;
                //Đặt lề trên
                int iTopMargin = e.MarginBounds.Top;
                // Thiết lập có cần nhiều trang để in hay không
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                // Thiết lập độ dộng của các cell và độ cao của header để in trang đầu tiên
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgvHocSinh.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width / (double)iTotalWidth * (double)iTotalWidth * ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Lưu độ rộng và độ cao của các header
                        arrColumnCoor.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                // Vòng lặp cho đến tất cả những trang chưa được in
                while (iCount <= dgvHocSinh.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvHocSinh.Rows[iCount];
                    // Đặt độ cao của cell
                    iCellHeight = GridRow.Height + 8;
                    int i = 0;

                    // Kiểm tra thiết lập trang xem còn nhiều dòng để in sang trang mới
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            // Vẽ các header
                            e.Graphics.DrawString("TRA CỨU HỌC SINH", new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, new Point(250, 20));
                            e.Graphics.DrawString("Năm học: " + cbNamHoc.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(330, 80));
                            e.Graphics.DrawString("Danh sách học sinh", new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(330, 150));

                            // Vẽ cột              
                            iTopMargin = e.MarginBounds.Top + 80;
                            foreach (DataGridViewColumn GridCol in dgvHocSinh.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle((int)arrColumnCoor[i], iTopMargin, (int)arrColumnWidths[i], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnCoor[i], iTopMargin, (int)arrColumnWidths[i], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, new SolidBrush(GridCol.InheritedStyle.ForeColor), new RectangleF((int)arrColumnCoor[i], iTopMargin,
                                    (int)arrColumnWidths[i], iHeaderHeight), strFormat);
                                i++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        i = 0;
                        // Vẽ nội dung của các cột          
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor), new RectangleF((int)arrColumnCoor[i], (float)iTopMargin,
                                            (int)arrColumnWidths[i], (float)iCellHeight), strFormat);
                            }
                            // Vẽ đường viền 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnCoor[i],
                                    iTopMargin, (int)arrColumnWidths[i], iCellHeight));

                            i++;
                        }
                    }
                    iCount++;
                    iTopMargin += iCellHeight;
                }

                // Nếu không đủ để in các dòng trên 1 trang, thì in sang trang khác
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Sự kiện của button Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Hàm chức năng
        // Tạo DataTable với một cột STT
        private DataTable taoCotSTT()
        {
            DataColumn sttCol = new DataColumn();
            DataTable temp = new DataTable();
            sttCol.DataType = typeof(int);
            sttCol.ColumnName = "STT";
            sttCol.AutoIncrement = true;
            sttCol.AutoIncrementSeed = 1;
            sttCol.AutoIncrementStep = 1;
            temp.Columns.Add(sttCol);
            return temp;
        }
        // Load dữ liệu cho combobox Năm Học
        private void loadNamHoc(ComboBox cb)
        {
            ComboBox temp = cb;
            DataTable namHoc = nh_objdm.DanhSachNamHoc();
            temp.DataSource = namHoc;
            temp.DisplayMember = "MaNam";
            temp.ValueMember = "MaNam";
            temp.SelectedItem = null;
        }
        // Load dữ liệu cho comobobox Lớp
        private void loadLop()
        {
            DataTable lop = lh_objdm.DanhSachLop(cbNamHoc.SelectedValue.ToString());
            cbLop.DataSource = lop;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "TenLop";
            cbLop.SelectedItem = null;
        }
        // Load dữ liệu cho DataGridView Học Sinh
        private void loadDanhSachHocSinh()
        {
            DataTable hocSinh = hs_objdm.DanhSachHocSinh(cbNamHoc.SelectedValue.ToString());
            DataTable hocSinh1 = new DataTable();
            DataTable hocSinh2 = new DataTable();
            hocSinh1.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn() });
            hocSinh2.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn() });
            foreach (DataRow row in hocSinh.Rows)
            {
                if (row[3].ToString() == "1")
                {
                    hocSinh1.Rows.Add(row.ItemArray);
                }
                if (row[3].ToString() == "2")
                {
                    hocSinh2.Rows.Add(row.ItemArray);
                }
            }
            for (int i = 0; i < hocSinh1.Rows.Count; i++)
            {
                hocSinh1.Rows[i][3] = hocSinh2.Rows[i][2];
            }
            DataTable stt = taoCotSTT();
            stt.Merge(hocSinh1);
            dgvHocSinh.ForeColor = Color.Black;
            dgvHocSinh.DataSource = stt;
            dgvHocSinh.Columns[0].Width = 50;
            dgvHocSinh.Columns[1].HeaderText = "Tên";
            dgvHocSinh.Columns[1].Width = 200;
            dgvHocSinh.Columns[2].HeaderText = "Lớp";
            dgvHocSinh.Columns[2].Width = 200;
            dgvHocSinh.Columns[3].HeaderText = "Điểm TBHK 1";
            dgvHocSinh.Columns[3].Width = 180;
            dgvHocSinh.Columns[4].HeaderText = "Điểm TBHK 2";
            dgvHocSinh.Columns[4].Width = 180;
        }
        #endregion

        

        
    }
}
