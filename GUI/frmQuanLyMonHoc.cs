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
    public partial class frmQuanLyMonHoc : Form
    {
        NamHocBUS nh_objdm = new NamHocBUS();
        MonHocBUS mh_objdm = new MonHocBUS();
        LopBUS lh_objdm = new LopBUS();
        BangDiemBUS bd_objdm = new BangDiemBUS();
        HocKyBUS hk_objdm = new HocKyBUS();
        CT_BangDiemBUS ctbd_objdm = new CT_BangDiemBUS();
        ThamSoBUS ts_objdm = new ThamSoBUS();
        LoaiDiemBUS ld_objdm = new LoaiDiemBUS();
        ChuongTrinhHocBUS cth_objdm = new ChuongTrinhHocBUS();
        QuaTrinhHocBUS qth_objdm = new QuaTrinhHocBUS();
        float heSo15P; 
        float heSo1T; 
        string temp_tenMon;
        string temp_maMon;
        string temp_15P;
        string temp_1T;

        StringFormat strFormat; // Sử dụng để định dang chuỗi trong các dòng của DataGridView
        ArrayList arrColumnCoor = new ArrayList(); // Sử dụng để lưu tọa độ của các cột
        ArrayList arrColumnWidths = new ArrayList(); // Sử dụng để lưu độ rộng của các cột
        int iCellHeight = 0; // Sử dụng thể thiết lập giá trị độ cao của các cell
        int iTotalWidth = 0; // Tính tổng độ rộng cần để in
        int iCount = 0; // Đếm số row
        int iHeaderHeight = 0; // Độ cao của header
        bool bFirstPage = false;
        bool bNewPage = false;

        #region Sự kiện Form
        public frmQuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void frmQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            loadNamHoc(cbNamHoc1);
            loadNamHoc(cbNamHoc2);
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Chọn";
            checkColumn.Width = 59;
            dgvMonHoc.Columns.Add(checkColumn);
            dgvBangDiem.ForeColor = Color.Black;
            heSo15P = ld_objdm.HeSoDiem("15Phut");
            heSo1T = ld_objdm.HeSoDiem("1T");
            txb15Phut.Text = heSo15P.ToString();
            txb1T.Text = heSo1T.ToString();
            kiemTraHopLe();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Sự kiện tab Quản Lý Môn Học
        private void cbNamHoc1_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc1.SelectedValue != null)
            {
                loadDanhSachMonHoc();
            }            
        }               
        // Kiểm tra các môn học được chọn
        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvMonHoc.Rows)
                {
                    if ((bool)row.Cells[0].EditedFormattedValue)
                    {
                        row.Selected = true;
                    }
                    else
                    {
                        row.Selected = false;
                    }
                }
            }
            kiemTraHopLe();
        }
        // Kiểm tra các môn học được chọn và gán các giá trị tạm
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvMonHoc.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
                {
                    temp_tenMon = dgvMonHoc.Rows[e.RowIndex].Cells[3].Value.ToString();
                    temp_maMon = dgvMonHoc.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }
            foreach (DataGridViewRow row in dgvMonHoc.Rows)
            {
                if ((bool)row.Cells[0].EditedFormattedValue)
                {
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }
            kiemTraHopLe();
        }
        // Nhấn nút xóa để để xóa môn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa môn đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvMonHoc.SelectedRows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        if (MonHocBUS.MonTonTaiTrongChuongTrinhHoc(row.Cells[2].Value.ToString()))
                        {
                            if (MessageBox.Show(string.Format("Không thể xóa môn {0}, đã tồn tại trong ít nhất một\nchương trình học. Bạn có muốn tiếp tục", row.Cells[3].Value.ToString()), "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            mh_objdm.XoaMonHoc(row.Cells[2].Value.ToString());
                        }
                    }
                }
                loadDanhSachMonHoc();
                kiemTraHopLe();
            }
        }
        // Nhấn nút thêm để thêm môn
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!mh_objdm.MonHocTonTai(txbMaMon.Text))
            {
                mh_objdm.ThemMonHoc(txbMaMon.Text, txbTenMon.Text, cbNamHoc1.SelectedValue.ToString());
                txbMaMon.Text = string.Empty;
                txbTenMon.Text = string.Empty;
                loadDanhSachMonHoc();
                kiemTraHopLe();
            }
            else
            {
                MessageBox.Show("Mã môn đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMonHoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMonHoc.CurrentCell.ColumnIndex == 2)
            {
                if (dgvMonHoc.CurrentCell.Value.ToString() == temp_maMon)
                {

                }
                else
                {
                    if (mh_objdm.MonHocTonTai(dgvMonHoc.CurrentCell.Value.ToString()))
                    {
                        dgvMonHoc.CurrentCell.Value = temp_maMon;
                        MessageBox.Show("Mã môn đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(dgvMonHoc.CurrentCell.Value.ToString()))
                    {
                        dgvMonHoc.CurrentCell.Value = temp_maMon;
                        MessageBox.Show("Mã môn không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (maMonHopLe(dgvMonHoc.CurrentCell.Value.ToString()))
                    {
                        mh_objdm.SuaMonHoc(temp_maMon, dgvMonHoc.CurrentCell.Value.ToString(), dgvMonHoc.CurrentRow.Cells[3].Value.ToString());
                        loadDanhSachMonHoc();
                        kiemTraHopLe();
                    }
                    else
                    {
                        dgvMonHoc.CurrentCell.Value = temp_maMon;
                        MessageBox.Show("Mã môn học không được chứa ký tự đặc biệt hoặc khoảng trắng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (dgvMonHoc.CurrentCell.ColumnIndex == 3)
            {
                if (dgvMonHoc.CurrentCell.Value.ToString() == temp_tenMon)
                {

                }
                else
                {
                    if (string.IsNullOrEmpty(dgvMonHoc.CurrentCell.Value.ToString()))
                    {
                        dgvMonHoc.CurrentCell.Value = temp_tenMon;
                        MessageBox.Show("Tên môn không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (tenMonHopLe(dgvMonHoc.CurrentCell.Value.ToString()))
                    {
                        mh_objdm.SuaMonHoc(temp_maMon, temp_maMon, dgvMonHoc.CurrentCell.Value.ToString());
                        loadDanhSachMonHoc();
                        kiemTraHopLe();
                    }
                    else
                    {
                        dgvMonHoc.CurrentCell.Value = temp_tenMon;
                        MessageBox.Show("Tên môn học không được chứa ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }      
             
        private void txbMaMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !maMonHopLe(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            kiemTraHopLe();
        }

        private void txbTenMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !tenMonHopLe(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            kiemTraHopLe();
        }
        #endregion

        #region Sự kiện tab Bảng Điểm
        private void cbNamHoc2_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc2.SelectedValue != null)
            {
                loadLop();
                loadHocKy();
                dgvBangDiem.DataSource = null;
                dgvBangDiem.Rows.Clear();
            }
        }

        private void cbHocKy_DropDownClosed(object sender, EventArgs e)
        {
            if (cbHocKy.SelectedValue != null && cbMon.SelectedValue != null && cbLop.SelectedValue != null)
            {
                loadBangDiem();                
            }

        }

        private void cbLop_DropDownClosed(object sender, EventArgs e)
        {
            if (cbLop.SelectedValue != null)
            {
                loadMon();                
            }
        }

        private void cbMon_DropDownClosed(object sender, EventArgs e)
        {
            if (cbHocKy.SelectedValue != null && cbMon.SelectedValue != null && cbLop.SelectedValue != null)
            {
                loadBangDiem();
            }
        }
       
        private void dgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                temp_15P = dgvBangDiem.Rows[e.RowIndex].Cells[3].Value.ToString();
                temp_1T = dgvBangDiem.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void dgvBangDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double temp;
            if ((e.ColumnIndex == 4 || e.ColumnIndex == 5) && dgvBangDiem.CurrentCell.Value.ToString() == string.Empty)
            {
                dgvBangDiem.CurrentCell.Value = 0;
            }
            else if (double.TryParse(dgvBangDiem.CurrentCell.Value.ToString(), out temp))
            {
                float diemToiThieu = float.Parse(ts_objdm.TimGiaTriThamSo("DiemToiThieu").Rows[0][0].ToString());
                float diemToiDa = float.Parse(ts_objdm.TimGiaTriThamSo("DiemToiDa").Rows[0][0].ToString());
                if (temp < diemToiThieu || temp > diemToiDa)
                {
                    MessageBox.Show(string.Format("Điểm không được nhỏ hơn {0} hoặc lớn hơn {1}", diemToiThieu, diemToiDa), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (e.ColumnIndex == 4)
                    {
                        dgvBangDiem.CurrentCell.Value = temp_15P;
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        dgvBangDiem.CurrentCell.Value = temp_1T;
                    }
                }
                else
                {
                    double diem15P = double.Parse(dgvBangDiem.Rows[e.RowIndex].Cells[4].Value.ToString());
                    double diem1T = double.Parse(dgvBangDiem.Rows[e.RowIndex].Cells[5].Value.ToString());
                    double diemTB = bd_objdm.TinhDiemTrungBinh(diem15P, diem1T, heSo15P, heSo1T);
                    string maQTH = qth_objdm.MaQuaTrinhHoc(dgvBangDiem.CurrentRow.Cells[2].Value.ToString(), cbLop.SelectedValue.ToString(), (cbHocKy.SelectedIndex + 1).ToString());
                    ctbd_objdm.SuaCTBangDiem(dgvBangDiem.Rows[e.RowIndex].Cells[1].Value.ToString(), "15Phut", diem15P);
                    ctbd_objdm.SuaCTBangDiem(dgvBangDiem.Rows[e.RowIndex].Cells[1].Value.ToString(), "1T", diem1T);
                    bd_objdm.SuaDiemTB(dgvBangDiem.Rows[e.RowIndex].Cells[1].Value.ToString(), diemTB);
                    List<string> mon = new List<string>();
                    List<double> heSo = new List<double>();
                    List<double> diem = new List<double>();
                    DataTable monDT = mh_objdm.DanhSachMonHocTheoLop(cbLop.SelectedValue.ToString());
                    foreach (DataRow row in monDT.Rows)
                    {
                        mon.Add(row[0].ToString());
                    }
                    foreach (string maMH in mon)
                    {
                        heSo.Add(cth_objdm.HeSoMonHoc(cbLop.SelectedValue.ToString(), maMH));
                    }
                    foreach (string maMH in mon)
                    {
                        diem.Add(bd_objdm.TimDiemTrungBinhMon(maMH, maQTH));
                    }
                    double diemTBHK = qth_objdm.TinhDiemTrungBinhHocKy(diem, heSo);
                    qth_objdm.SuaDiemTBHK(maQTH, diemTBHK);
                    dgvBangDiem.BeginInvoke(new MethodInvoker(() => { loadBangDiem(); }));
                }
            }
            else
            {
                MessageBox.Show("Điểm phải là số thực", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (e.ColumnIndex == 4)
                {
                    dgvBangDiem.CurrentCell.Value = temp_15P;
                }
                else if (e.ColumnIndex == 5)
                {
                    dgvBangDiem.CurrentCell.Value = temp_1T;
                }

            }   
        }

        // Sự kiện của button In bảng điểm môn
        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            if (dgvBangDiem.Rows.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocumentQLMH;
                printDialog.UseEXDialog = true;

                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    printDocumentQLMH.DocumentName = "Bảng điểm môn học";
                    printDocumentQLMH.Print();
                }
            }
            else
                MessageBox.Show("Không có dữ liệu để in", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        private void printFormToPrinter()
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocumentQLMH;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                printDocumentQLMH.Print();
        }

        private void printDocumentQLMH_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                foreach (DataGridViewColumn dgvGridCol in dgvBangDiem.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void printDocumentQLMH_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                    dgvBangDiem.Columns.Remove("Column1");
                    dgvBangDiem.Columns.Remove("Column2");
                    foreach (DataGridViewColumn GridCol in dgvBangDiem.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width / (double)iTotalWidth * (double)iTotalWidth * ((double)e.MarginBounds.Width / (double)iTotalWidth))) + 30);

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Lưu độ rộng và độ cao của các header
                        arrColumnCoor.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                // Vòng lặp cho đến tất cả những trang chưa được in
                while (iCount <= dgvBangDiem.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvBangDiem.Rows[iCount];
                    // Đặt độ cao của cell
                    iCellHeight = GridRow.Height + 10;
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
                            e.Graphics.DrawString("BẢNG ĐIỂM MÔN HỌC", new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, new Point(250, 10));
                            e.Graphics.DrawString("Năm học: " + cbNamHoc2.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(100, 100));
                            e.Graphics.DrawString("Học kỳ: " + cbHocKy.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(500, 100));
                            e.Graphics.DrawString("Lớp: " + cbLop.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(100, 135));
                            e.Graphics.DrawString("Môn: " + cbMon.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(500, 135));

                            // Vẽ cột              
                            iTopMargin = e.MarginBounds.Top + 80;
                            foreach (DataGridViewColumn GridCol in dgvBangDiem.Columns)
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
        #endregion

        #region Sự kiện tab Hệ Số
        // Kiểm tra chỉ cho nhập float
        private void float_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            ld_objdm.SuaHeSo("15Phut", float.Parse(txb15Phut.Text));
            ld_objdm.SuaHeSo("1T", float.Parse(txb1T.Text));
            MessageBox.Show("Cập nhật thành công");
            heSo15P = ld_objdm.HeSoDiem("15Phut");
            heSo1T = ld_objdm.HeSoDiem("1T");
        }
        #endregion

        #region Hàm chức năng
        private void loadLop()
        {
            DataTable lop = lh_objdm.DanhSachLop(cbNamHoc2.SelectedValue.ToString());
            cbLop.DataSource = lop;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "MaLop";
            cbLop.SelectedItem = null;
        }
        private void loadHocKy()
        {
            DataTable hocKy = hk_objdm.TimHocKy(cbNamHoc2.SelectedValue.ToString());
            cbHocKy.DataSource = hocKy;
            cbHocKy.DisplayMember = "TenHocKy";
            cbHocKy.ValueMember = "MaHocKy";
            cbHocKy.SelectedItem = null;
        }
        private void loadNamHoc(ComboBox cb)
        {
            DataTable namHoc = nh_objdm.DanhSachNamHoc();
            cb.DataSource = namHoc;
            cb.DisplayMember = "MaNam";
            cb.ValueMember = "MaNam";
            cb.SelectedItem = null;
        }
        private void loadMon()
        {
            DataTable mon = mh_objdm.DanhSachMonHocTheoLop(cbLop.SelectedValue.ToString());
            cbMon.DataSource = mon;
            cbMon.DisplayMember = "TenMonHoc";
            cbMon.ValueMember = "MaMonHoc";
            cbMon.SelectedItem = null;
        }
        private void loadBangDiem()
        {
            DataTable bangDiem = bd_objdm.TimBangDiem(cbLop.SelectedValue.ToString(), cbMon.SelectedValue.ToString(), cbHocKy.SelectedValue.ToString());
            DataTable bangDiem1 = new DataTable();
            DataTable bangDiem2 = new DataTable();
            bangDiem1.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn() });
            bangDiem2.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn(), new DataColumn() });
            foreach (DataRow row in bangDiem.Rows)
            {
                if (row["MaLoaiDiem"].ToString() == "15Phut")
                {
                    bangDiem1.Rows.Add(row.ItemArray);
                }
                else
                {
                    bangDiem2.Rows.Add(row.ItemArray);
                }
            }
            bangDiem1.Columns.Remove("Column5");
            bangDiem1.Columns.Remove("Column6");
            bangDiem1.Columns.AddRange(new DataColumn[] { new DataColumn(), new DataColumn() });
            for (int i = 0; i < bangDiem1.Rows.Count; i++)
            {
                bangDiem1.Rows[i][4] = bangDiem2.Rows[i][3];
                bangDiem1.Rows[i][5] = bangDiem2.Rows[i][5];
            }
            DataTable stt = taoCotSTT();
            stt.Merge(bangDiem1);
            dgvBangDiem.DataSource = stt;
            dgvBangDiem.Columns[0].Width = 50;
            dgvBangDiem.Columns[0].ReadOnly = true;
            dgvBangDiem.Columns[1].Visible = false;
            dgvBangDiem.Columns[2].Visible = false;
            dgvBangDiem.Columns[3].HeaderText = "Tên học sinh";
            dgvBangDiem.Columns[3].Width = 210;
            dgvBangDiem.Columns[3].ReadOnly = true;
            dgvBangDiem.Columns[4].HeaderText = "Điểm 15'*";
            dgvBangDiem.Columns[4].Width = 160;
            dgvBangDiem.Columns[5].HeaderText = "Điểm 1T*";
            dgvBangDiem.Columns[5].Width = 160;
            dgvBangDiem.Columns[6].HeaderText = "Điểm TB";
            dgvBangDiem.Columns[6].Width = 160;
            dgvBangDiem.Columns[6].ReadOnly = true;
        }
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
        private bool maMonHopLe(string maMH)
        {
            Regex re = new Regex(@"^[A-Za-z0-9]+$");
            return re.IsMatch(maMH);
        }
        private bool tenMonHopLe(string tenMH)
        {
            Regex re = new Regex(@"^[\p{L}\p{N} ]+$");
            return re.IsMatch(tenMH);
        }
 
        private void kiemTraHopLe()
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.Gray;
            }
            if (txbTenMon.Text == string.Empty || cbNamHoc1.SelectedValue == null || txbMaMon.Text == null)
            {
                btnThem.Enabled = false;
                btnThem.BackColor = Color.Gray;
            }
            else
            {
                btnThem.Enabled = true;
                btnThem.BackColor = Color.FromArgb(255, 128, 0);
            }
        }
        private void loadDanhSachMonHoc()
        {
            DataTable monHoc = mh_objdm.DanhSachMonHoc(cbNamHoc1.SelectedValue.ToString());
            DataTable temp = taoCotSTT();
            temp.Merge(monHoc);
            dgvMonHoc.DataSource = temp;
            dgvMonHoc.Columns[1].Width = 75;
            dgvMonHoc.Columns[2].Width = 250;
            dgvMonHoc.Columns[2].HeaderText = "Mã môn học";
            dgvMonHoc.Columns[3].Width = 370;
            dgvMonHoc.Columns[3].HeaderText = "Tên môn học";
        }        
        #endregion              

        

        
                
    }

}
