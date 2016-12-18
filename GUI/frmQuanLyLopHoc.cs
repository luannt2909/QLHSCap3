using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BUS;

namespace GUI
{
    public partial class frmQuanLyLopHoc : Form
    {
        LopBUS lh_objdm = new LopBUS();
        NamHocBUS nh_objdm = new NamHocBUS();
        HocSinhBUS hs_objdm = new HocSinhBUS();
        KhoiLopBUS kl_objdm = new KhoiLopBUS();
        ChuongTrinhHocBUS cth_objdm = new ChuongTrinhHocBUS();
        QuaTrinhHocBUS qth_objdm = new QuaTrinhHocBUS();
        HocKyBUS hk_objdm = new HocKyBUS();
        BangDiemBUS bd_objdm = new BangDiemBUS();
        CT_BangDiemBUS ctbd_objdm = new CT_BangDiemBUS();
        string temp_tenLop;
        string temp_heSo;
        string temp_tenKhoi;

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
        public frmQuanLyLopHoc()
        {
            InitializeComponent();
        }
        private void frmQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            loadNamHoc(cbNamHoc1);
            loadNamHoc(cbNamHoc2);
            loadNamHoc(cbNamHoc3);
            loadNamHoc(cbNamHoc4);
            loadNamHoc(cbNamHoc5);
            loadNamHoc(cbNamHoc6);
            dgvLop.Columns.Add(taoCheckColumn());
            dgvMon1.Columns.Add(taoCheckColumn());
            dgvMon2.Columns.Add(taoCheckColumn());
            dgvLop1.Columns.Add(taoCheckColumn());
            dgvLop2.Columns.Add(taoCheckColumn());
            dgvKhoiLop.Columns.Add(taoCheckColumn());
            kiemTraHopLe();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Sự kiện tab Danh Sách Lớp
        private void cbNamHoc1_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc1.SelectedValue != null)
            {
                loadDanhSachLop(cbNamHoc1.SelectedValue.ToString(), cbLop);
            }
        }

        private void cbLop_DropDownClosed(object sender, EventArgs e)
        {
            if (cbLop.SelectedValue != null)
            {
                DataTable lop = lh_objdm.TimLop(cbLop.SelectedValue.ToString());
                DataTable hocSinh = hs_objdm.DanhSachHocSinhTheoLop(cbLop.SelectedValue.ToString());
                DataColumn sttCol = new DataColumn();
                DataTable stt = taoCotSTT();
                stt.Merge(hocSinh);
                labSiSo.Text = lop.Rows[0]["SiSo"].ToString();
                dgvHocSinh.DataSource = stt;
                dgvHocSinh.Columns[0].Width = 60;
                dgvHocSinh.Columns[1].HeaderText = "Tên";
                dgvHocSinh.Columns[1].Width = 250;
                dgvHocSinh.Columns[2].HeaderText = "Giới tính";
                dgvHocSinh.Columns[2].Width = 100;
                dgvHocSinh.Columns[3].HeaderText = "Ngày sinh";
                dgvHocSinh.Columns[3].Width = 150;
                dgvHocSinh.Columns[4].HeaderText = "Địa chỉ";
                dgvHocSinh.Columns[4].Width = 205;

            }
            kiemTraHopLe();
        }

        // Sự kiện của button In danh sách lớp
        private void btnInDanhSachLop_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocumentDSL;
            printDialog.UseEXDialog = true;

            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocumentDSL.DocumentName = "Danh sách lớp";
                printDocumentDSL.Print();
            }
        }

        private void printDocumentDSL_BeginPrint(object sender, PrintEventArgs e)
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

        private void printDocumentDSL_PrintPage(object sender, PrintPageEventArgs e)
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
                            e.Graphics.DrawString("DANH SÁCH LỚP", new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, new Point(280, 10));
                            e.Graphics.DrawString("Năm học: " + cbNamHoc1.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(100, 100));
                            e.Graphics.DrawString("Lớp: " + cbLop.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(400, 100));
                            e.Graphics.DrawString("Sĩ số: " + labSiSo.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(650, 100));

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
                                e.Graphics.DrawString(Cel.Value.ToString().Replace("00:00:00", ""), Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor), new RectangleF((int)arrColumnCoor[i], (float)iTopMargin,
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

        #region Sự kiện tab Quản Lý Lớp
        private void cbNamHoc2_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc2.SelectedItem != null)
            {
                loadKhoiLop(cbKhoiLop1, cbNamHoc2);
                dgvLop.DataSource = null;
                dgvLop.Rows.Clear();
            }
        }
        
        private void cbKhoiLop_DropDownClosed(object sender, EventArgs e)
        {
            if(cbKhoiLop1.SelectedItem != null)
            {
                loadDanhSachCacLop();
            }
            kiemTraHopLe();
        }

        // Nhấn nút xóa để xóa các lớp đã chọn
        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa những lớp đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLop.SelectedRows)
                {
                    if (row.Cells[4].Value != null)
                    {
                        if (!row.Cells[4].Value.Equals(0))
                        {
                            if (MessageBox.Show(String.Format("Không thể xóa lớp \"{0}\" có sỉ số lớn hơn 0\nBạn có muốn tiếp tục?", row.Cells[3].Value.ToString().Trim()), "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
                            lh_objdm.XoaLop(row.Cells[2].Value.ToString());
                        }
                        
                    }
                }
                loadDanhSachCacLop();
                kiemTraHopLe();
            }
        }
        // Kiểm tra các lớp đã được chọn, và gán các giá trị tạm
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvLop.Rows[e.RowIndex].Cells[e.ColumnIndex] != null && e.ColumnIndex == 3)
                {
                    temp_tenLop = dgvLop.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
            foreach (DataGridViewRow row in dgvLop.Rows)
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
        // Hoàn thành chỉnh sửa dữ liệu
        private void dgvLop_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string maLop = dgvLop.Rows[e.RowIndex].Cells[2].Value.ToString();
                string tenLop = dgvLop.Rows[e.RowIndex].Cells[3].Value.ToString();
                string maKL = cbKhoiLop1.SelectedValue.ToString();
                if (tenLop == string.Empty && tenLop != temp_tenLop)
                {
                    dgvLop.Rows[e.RowIndex].Cells[3].Value = temp_tenLop;
                    MessageBox.Show("Tên lớp không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }

                else if (!kiemTraLopHopLe(tenLop, cbNamHoc2.SelectedValue.ToString()) && tenLop != temp_tenLop)
                {
                    dgvLop.Rows[e.RowIndex].Cells[3].Value = temp_tenLop;
                    MessageBox.Show("Lớp đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                else if (tenLop != temp_tenLop)
                {
                    string maLopMoi = LopBUS.MaLop(dgvLop.Rows[e.RowIndex].Cells[3].Value.ToString(), cbNamHoc2.SelectedValue.ToString());
                    lh_objdm.SuaLop(maLop, maLopMoi, tenLop, maKL);
                    loadDanhSachCacLop();                                    
                }
            }
            kiemTraHopLe();
        }
        // Nhấn nút thêm để thêm lớp
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            if (!kiemTraLopHopLe(txbTenLop.Text, cbNamHoc2.SelectedValue.ToString()))
            {
                MessageBox.Show("Lớp đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lh_objdm.ThemLop(LopBUS.MaLop(txbTenLop.Text, cbNamHoc2.SelectedValue.ToString()), txbTenLop.Text, cbKhoiLop1.SelectedValue.ToString());
                txbTenLop.Text = string.Empty;
                loadDanhSachCacLop();
                kiemTraHopLe();
            }
        }
        // Kiểm tra lớp đã tồn tại
        public bool kiemTraLopHopLe(string tenLop, string maNam)
        {
            DataTable lop = lh_objdm.TimLop(LopBUS.MaLop(tenLop, maNam));
            if (lop.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // Kiểm tra các lớp được chọn
        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) 
            {
                foreach (DataGridViewRow row in dgvLop.Rows)
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
        #endregion

        #region Sự kiện tab chương trình học
        private void cbNamHoc3_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc3.SelectedItem != null)
            {
                loadKhoiLop(cbKhoiLop2, cbNamHoc3);
                dgvMon1.DataSource = null;
                dgvMon1.Rows.Clear();
                dgvMon2.DataSource = null;
                dgvMon2.Rows.Clear();
            }
        }

        private void cbKhoiLop2_DropDownClosed(object sender, EventArgs e)
        {
            if (cbKhoiLop2.SelectedItem != null)
            {
                loadDanhSachMonChuaCo();
                loadDanhSachMonDaCo();
            }
        }        
        // Kiểm tra các môn chưa có đã chọn
        private void dgvMon1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvMon1.Rows)
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
        // Kiểm tra các môn chưa có đã chọn
        private void dgvMon1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMon1.Rows)
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
        // Kiểm tra các môn đã có đã chọn
        private void dgvMon2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvMon2.Rows[e.RowIndex].Cells[e.ColumnIndex] != null && e.ColumnIndex == 4)
                {
                    temp_heSo = dgvMon2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
            foreach (DataGridViewRow row in dgvMon2.Rows)
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
        // Kiểm tra các môn đã có đã chọn
        private void dgvMon2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvMon2.Rows)
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
        // Hoàn thành sửa dữ liệu hệ số môn
        private void dgvMon2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dgvMon2.CurrentCell.Value != null)
                {
                    if (dgvMon2.CurrentCell.Value.ToString() != temp_heSo)
                    {
                        if (string.IsNullOrEmpty(dgvMon2.CurrentCell.Value.ToString()))
                        {
                            dgvMon2.CurrentCell.Value = temp_heSo;
                            MessageBox.Show("Hệ số không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!heSoHopLe(dgvMon2.CurrentCell.Value.ToString()))
                        {
                            dgvMon2.CurrentCell.Value = temp_heSo;
                            MessageBox.Show("Hệ số phải là số thực", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            cth_objdm.SuaChuongTrinhHoc(cbKhoiLop2.SelectedValue.ToString(), dgvMon2.CurrentRow.Cells[2].Value.ToString(), float.Parse(dgvMon2.CurrentCell.Value.ToString()));
                            dgvMon2.BeginInvoke(new MethodInvoker(() => {loadDanhSachMonDaCo();}));
                        }
                    }
                }
            }
            kiemTraHopLe();
        }
        // Nhấn nút thêm để thêm môn
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMon1.SelectedRows)
            {
                if (row.Index != -1)
                {
                    cth_objdm.ThemChuongTrinhHoc(cbKhoiLop2.SelectedValue.ToString(), row.Cells[2].Value.ToString(), 1.0f);
                    DataTable lop = lh_objdm.DanhSachLopTheoKhoiLop(cbKhoiLop2.SelectedValue.ToString());
                    List<string> lopList = new List<string>();
                    foreach (DataRow lopRow in lop.Rows)
                    {
                        lopList.Add(lopRow[0].ToString());
                    }
                    foreach (string maLop in lopList)
                    {
                        DataTable hs = hs_objdm.MaHocSinhTheoLop(maLop);
                        List<string> hsList = new List<string>();
                        foreach (DataRow hsRow in hs.Rows)
                        {
                            hsList.Add(hsRow[0].ToString());
                        }
                        foreach (string maHS in hsList)
                        {
                            string maQTH1 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "1");
                            string maQTH2 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "2");
                            string maBD1 = bd_objdm.TaoMaBangDiem(maQTH1, row.Cells[2].Value.ToString());
                            string maBD2 = bd_objdm.TaoMaBangDiem(maQTH2, row.Cells[2].Value.ToString());
                            bd_objdm.ThemBangDiem(maBD1, maQTH1, row.Cells[2].Value.ToString(), 0f);
                            bd_objdm.ThemBangDiem(maBD2, maQTH2, row.Cells[2].Value.ToString(), 0f);
                            ctbd_objdm.ThemCTBangDiem(maBD1, "15Phut", 0f);
                            ctbd_objdm.ThemCTBangDiem(maBD1, "1T", 0f);
                            ctbd_objdm.ThemCTBangDiem(maBD2, "15Phut", 0f);
                            ctbd_objdm.ThemCTBangDiem(maBD2, "1T", 0f);
                        }
                    }
                }
            }

            loadDanhSachMonChuaCo();
            loadDanhSachMonDaCo();
            kiemTraHopLe();
        }
        // Nhấn nút xóa môn để xóa
        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMon2.SelectedRows)
            {
                if(row.Index != -1)
                {
                    cth_objdm.XoaChuongTrinhHoc(cbKhoiLop2.SelectedValue.ToString(), row.Cells[2].Value.ToString());
                    DataTable lop = lh_objdm.DanhSachLopTheoKhoiLop(cbKhoiLop2.SelectedValue.ToString());
                    List<string> lopList = new List<string>();
                    foreach (DataRow lopRow in lop.Rows)
                    {
                        lopList.Add(lopRow[0].ToString());
                    }
                    foreach (string maLop in lopList)
                    {
                        DataTable hs = hs_objdm.MaHocSinhTheoLop(maLop);
                        List<string> hsList = new List<string>();
                        foreach (DataRow hsRow in hs.Rows)
                        {
                            hsList.Add(hsRow[0].ToString());
                        }
                        foreach (string maHS in hsList)
                        {
                            string maQTH1 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "1");
                            string maQTH2 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "2");
                            string maBD1 = bd_objdm.TaoMaBangDiem(maQTH1, row.Cells[2].Value.ToString());
                            string maBD2 = bd_objdm.TaoMaBangDiem(maQTH2, row.Cells[2].Value.ToString());
                            bd_objdm.XoaBangDiem(maBD1);
                            bd_objdm.XoaBangDiem(maBD2);
                        }
                    }
                }                
            }
            loadDanhSachMonChuaCo();
            loadDanhSachMonDaCo();
            kiemTraHopLe();
        }
        // Ràng buộc tên lớp chỉ được chứa ký tự trong latin alphabet và số
        private void txbTenLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex re = new Regex(@"[^A-Za-z0-9]+");
            if (!char.IsControl(e.KeyChar) && re.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            kiemTraHopLe();
        }
        #endregion

        #region Sự kiện tab Chuyển Lớp
        private void cbNamHoc4_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc4.SelectedValue != null)
            {
                loadDanhSachLop(cbNamHoc4.SelectedValue.ToString(), cbLop1);
                dgvLop1.DataSource = null;
                dgvLop1.Rows.Clear();
            }
        }
        private void cbNamHoc5_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc5.SelectedValue != null)
            {
                loadDanhSachLop(cbNamHoc5.SelectedValue.ToString(), cbLop2);
                dgvLop2.DataSource = null;
                dgvLop2.Rows.Clear();
            }
        }

        private void cbLop1_DropDownClosed(object sender, EventArgs e)
        {
            if (cbLop1.SelectedValue != null)
            {
                if (cbLop2.SelectedValue != null)
                {
                    loadDanhSachHocSinhChuyenLop(cbLop1.SelectedValue.ToString(), cbLop2.SelectedValue.ToString());
                    kiemTraHopLe();
                }
                else
                {
                    loadDanhSachHocSinhChuyenLop(cbLop1.SelectedValue.ToString(), string.Empty);
                    kiemTraHopLe();
                }
            }
        }

        private void cbLop2_DropDownClosed(object sender, EventArgs e)
        {
            if (cbLop2.SelectedValue != null)
            {
                loadDanhSachHocSinhDaChuyen(cbLop2.SelectedValue.ToString());
                if(cbLop1.SelectedValue != null)
                {
                    loadDanhSachHocSinhChuyenLop(cbLop1.SelectedValue.ToString(), cbLop2.SelectedValue.ToString());
                }
                kiemTraHopLe();
            }
        }
        // Kiểm tra các học sinh chưa chuyển được chọn
        private void dgvLop1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvLop1.Rows)
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
        // Kiểm tra các học sinh chưa chuyển được chọn
        private void dgvLop1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvLop1.Rows)
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
        // Kiểm tra các học sinh đã chuyển được chọn
        private void dgvLop2_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            foreach (DataGridViewRow row in dgvLop2.Rows)
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
        // Kiểm tra các học sinh đã chuyển được chọn
        private void dgvLop2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvLop2.Rows)
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
        // Nhấn nút chuyển để chuyển học sinh
        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn chuyển các học sinh đã chọn?\n(Dữ liệu ở lớp cũ vẫn sẽ tồn tại)", "Xác nhận chuyển", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLop1.SelectedRows)
                {
                    if (row.Index != -1)
                    {
                        string maHS = row.Cells[2].Value.ToString();
                        string maLop = cbLop2.SelectedValue.ToString();
                        string maQTH1 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "1");
                        string maQTH2 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "2");
                        qth_objdm.ThemQuaTrinhHoc(maQTH1, maHS, maLop, hk_objdm.MaHocKy(cbNamHoc5.SelectedValue.ToString())[0], 0F);
                        qth_objdm.ThemQuaTrinhHoc(maQTH2, maHS, maLop, hk_objdm.MaHocKy(cbNamHoc5.SelectedValue.ToString())[1], 0F);
                        
                    }
                }
                loadDanhSachHocSinhChuyenLop(cbLop1.SelectedValue.ToString(), cbLop2.SelectedValue.ToString());
                loadDanhSachHocSinhDaChuyen(cbLop2.SelectedValue.ToString());
                kiemTraHopLe();
            }
        }
        // Nhấn nút xóa để xóa học sinh đã chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có muốn xóa những học sinh đã chọn ra khỏi lớp {0}?", cbLop2.SelectedValue.ToString()), "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLop2.SelectedRows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        string maHS = row.Cells[2].Value.ToString();
                        string maLop = cbLop2.SelectedValue.ToString();
                        string maQTH1 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "1");
                        string maQTH2 = qth_objdm.MaQuaTrinhHoc(maHS, maLop, "2");
                        if (qth_objdm.DiemTBHK(maQTH1) != 0 || qth_objdm.DiemTBHK(maQTH2) != 0)
                        {
                            if (MessageBox.Show("Không thể xóa học sinh có quá trình học ở lớp\nBạn có muốn tiếp tục?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
                            qth_objdm.XoaQuaTrinhHoc(maQTH1);
                            qth_objdm.XoaQuaTrinhHoc(maQTH2);                            
                        }

                    }
                }
                if (cbLop1.SelectedItem != null)
                {
                    loadDanhSachHocSinhChuyenLop(cbLop1.SelectedValue.ToString(), cbLop2.SelectedValue.ToString());
                }
                loadDanhSachHocSinhDaChuyen(cbLop2.SelectedValue.ToString());
                kiemTraHopLe();
            }
        }
        #endregion

        #region Sự kiện tab Quản Lý Khối Lớp
        private void cbNamHoc6_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc6.SelectedValue != null)
            {
                loadDanhSachKhoiLop();
            }
        }
        // Ràng buộc tên khối chỉ có ký tự latin alphabet và chữ số
        private void txbTenKhoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex re = new Regex(@"[^A-Za-z0-9]+");
            if (!char.IsControl(e.KeyChar) && re.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            kiemTraHopLe();
        }        
        // Kiểm tra khối lớp được chọn và gán các giá trị tạm
        private void dgvKhoiLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                temp_tenKhoi = dgvKhoiLop.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            foreach (DataGridViewRow row in dgvKhoiLop.Rows)
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
        // Kiểm tra khối lớp được chọn và gán các giá trị tạm
        private void dgvKhoiLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvKhoiLop.Rows)
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
        // Hoàn tất sửa thông tin khối lớp
        private void dgvKhoiLop_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != -1 && cbNamHoc6.SelectedValue != null)
            {
                string maKhoiLop = dgvKhoiLop.Rows[e.RowIndex].Cells[2].Value.ToString();
                string tenKhoiLop = dgvKhoiLop.Rows[e.RowIndex].Cells[3].Value.ToString();
                string maNam = cbNamHoc6.SelectedValue.ToString();
                string maKhoiLopMoi = kl_objdm.MaKhoiLop(tenKhoiLop, maNam);
                if (tenKhoiLop == string.Empty)
                {
                    dgvKhoiLop.CurrentCell.Value = temp_tenKhoi;
                    MessageBox.Show("Tên khối lớp không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Regex.IsMatch(tenKhoiLop, @"[^A-Za-z0-9]+"))
                {
                    dgvKhoiLop.CurrentCell.Value = temp_tenKhoi;
                    MessageBox.Show("Tên khối lớp không được chứa khoảng trống và ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (khoiLopTonTai(maKhoiLopMoi))
                {
                    dgvKhoiLop.CurrentCell.Value = temp_tenKhoi;
                    MessageBox.Show("Khối lớp đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!dgvKhoiLop.CurrentRow.Cells[4].Value.Equals(0))
                {
                    dgvKhoiLop.CurrentCell.Value = temp_tenKhoi;
                    MessageBox.Show(String.Format("Không thể thay đổi khối \"{0}\" có số lớp lớn hơn 0", dgvKhoiLop.CurrentRow.Cells[3].Value.ToString()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    kl_objdm.ThayDoiKhoiLop(maKhoiLop, maKhoiLopMoi, tenKhoiLop);
                    loadDanhSachKhoiLop();
                }
            }
            kiemTraHopLe();
        }        
        // Nhấn nút thêm để thêm khối lớp
        private void btnThemKhoi_Click(object sender, EventArgs e)
        {
            string maNam = cbNamHoc6.SelectedValue.ToString();
            string tenKL = txbTenKhoi.Text;
            string maKL = kl_objdm.MaKhoiLop(tenKL, maNam);
            if (khoiLopTonTai(maKL))
            {
               MessageBox.Show("Khối lớp đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else
            {
                kl_objdm.ThemKhoiLop(maKL, tenKL, maNam);
                txbTenKhoi.Text = string.Empty;
                loadDanhSachKhoiLop();
                kiemTraHopLe();
            }
        }
        // Nhấn nút xóa để xóa khối lớp
        private void btnXoaKhoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa những lớp đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvKhoiLop.SelectedRows)
                {
                    if (row.Cells[4].Value != null)
                    {
                        if (!row.Cells[4].Value.Equals(0))
                        {
                            if (MessageBox.Show(String.Format("Không thể xóa khối \"{0}\" có số lớplớn hơn 0\nBạn có muốn tiếp tục?", row.Cells[3].Value.ToString()), "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
                            kl_objdm.XoaKhoiLop(row.Cells[2].Value.ToString());
                        }

                    }
                }
                loadDanhSachKhoiLop();
                kiemTraHopLe();
            }
        }
        #endregion

        #region Hàm chức năng
        // Tạo checkbox column cho datagridview
        private DataGridViewCheckBoxColumn taoCheckColumn()
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Chọn";
            checkColumn.Width = 55;
            return checkColumn;
        }
        // Load dữ liệu cho combobox năm học
        private void loadNamHoc(ComboBox cb)
        {
            ComboBox temp = cb;
            DataTable namHoc = nh_objdm.DanhSachNamHoc();
            temp.DataSource = namHoc;
            temp.DisplayMember = "MaNam";
            temp.ValueMember = "MaNam";
            temp.SelectedItem = null;
        }
        // Load dữ liệu cho combobox lớp 
        private void loadDanhSachLop(string maNH, ComboBox cbLop)
        {
            DataTable dsLop = lh_objdm.DanhSachLop(maNH);
            cbLop.DataSource = dsLop;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "MaLop";
            cbLop.SelectedItem = null;
        }
        // Kiểm tra khối lớp đã tồn tại
        private bool khoiLopTonTai(string maKL)
        {
            DataTable khoiLop = kl_objdm.ChonKhoiLop(maKL);
            if (khoiLop.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Load dữ liệu cho datagridview khối lớp
        private void loadDanhSachKhoiLop()
        {
            DataTable khoiLop = kl_objdm.TimKhoiLop(cbNamHoc6.SelectedValue.ToString());
            DataTable stt = taoCotSTT();
            stt.Merge(khoiLop);
            dgvKhoiLop.DataSource = stt;
            dgvKhoiLop.Columns[1].ReadOnly = true;
            dgvKhoiLop.Columns[1].Width = 50;
            dgvKhoiLop.Columns[2].HeaderText = "Mã khối lớp";
            dgvKhoiLop.Columns[2].Width = 300;
            dgvKhoiLop.Columns[2].ReadOnly = true;
            dgvKhoiLop.Columns[3].HeaderText = "Tên khối lớp*";
            dgvKhoiLop.Columns[3].Width = 300;
            dgvKhoiLop.Columns[4].HeaderText = "Số lớp";
            dgvKhoiLop.Columns[4].Width = 70;
            dgvKhoiLop.Columns[4].ReadOnly = true;
        }
        // Load dữ liệu cho datagridview học sinh chuyển lớp
        private void loadDanhSachHocSinhChuyenLop(string maLop1, string maLop2)
        {
            DataTable hocSinh = hs_objdm.DanhSachHocSinhChuyenLop(maLop1, maLop2);
            DataTable stt = taoCotSTT();
            stt.Merge(hocSinh);
            dgvLop1.DataSource = stt;
            dgvLop1.Columns[1].ReadOnly = true;
            dgvLop1.Columns[1].Width = 51;
            dgvLop1.Columns[2].HeaderText = "Mã Học Sinh";
            dgvLop1.Columns[2].Width = 100;
            dgvLop1.Columns[2].ReadOnly = true;
            dgvLop1.Columns[3].HeaderText = "Tên Học Sinh";
            dgvLop1.Columns[3].Width = 140;
            dgvLop1.Columns[3].ReadOnly = true;
        }
        // Load dữ liệu cho datagridview học sinh đã chuyển lớp
        private void loadDanhSachHocSinhDaChuyen(string maLop)
        {
            DataTable hocSinh = hs_objdm.DanhSachHocSinhDaChuyen(maLop);
            DataTable stt = taoCotSTT();
            stt.Merge(hocSinh);
            dgvLop2.DataSource = stt;
            dgvLop2.Columns[1].ReadOnly = true;
            dgvLop2.Columns[1].Width = 51;
            dgvLop2.Columns[2].HeaderText = "Mã Học Sinh";
            dgvLop2.Columns[2].Width = 100;
            dgvLop2.Columns[2].ReadOnly = true;
            dgvLop2.Columns[3].HeaderText = "Tên Học Sinh";
            dgvLop2.Columns[3].Width = 158;
            dgvLop2.Columns[3].ReadOnly = true;
        }
        // Load dữ liệu cho datagridview danh sách các lớp
        private void loadDanhSachCacLop()
        {
            DataTable lop = lh_objdm.DanhSachLopTheoKhoiLop(cbKhoiLop1.SelectedValue.ToString());
            DataTable stt = taoCotSTT();
            stt.Merge(lop);
            dgvLop.DataSource = stt;
            dgvLop.Columns[1].Width = 60;
            dgvLop.Columns[1].ReadOnly = true;
            dgvLop.Columns[2].HeaderText = "Mã Lớp";
            dgvLop.Columns[2].ReadOnly = true;
            dgvLop.Columns[2].Width = 230;
            dgvLop.Columns[3].HeaderText = "Tên Lớp*";
            ((DataGridViewTextBoxColumn)dgvLop.Columns[3]).MaxInputLength = 10;
            dgvLop.Columns[3].Width = 230;
            dgvLop.Columns[4].HeaderText = "Sỉ Số";
            dgvLop.Columns[4].ReadOnly = true;
            dgvLop.Columns[4].Width = 175;
        }
        // Tạo datatable vơi cột STT
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
        // Kiểm tra ràng buộc hợp lệ các nút chức năng
        private void kiemTraHopLe()
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                btnXoaLop.Enabled = true;
                btnXoaLop.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnXoaLop.Enabled = false;
                btnXoaLop.BackColor = Color.Gray;
            }
            if (txbTenLop.Text == string.Empty || cbNamHoc2.SelectedValue == null || cbKhoiLop1.SelectedValue == null)
            {
                btnThemLop.Enabled = false;
                btnThemLop.BackColor = Color.Gray;
            }
            else
            {
                btnThemLop.Enabled = true;
                btnThemLop.BackColor = Color.FromArgb(255, 128, 0);
            }
            if (dgvMon1.SelectedRows.Count > 0)
            {
                btnThemMon.Enabled = true;
                btnThemMon.BackColor = Color.FromArgb(255, 128, 0);
            }
            else
            {
                btnThemMon.Enabled = false;
                btnThemMon.BackColor = Color.Gray;
            }
            if (dgvMon2.SelectedRows.Count > 0)
            {
                btnXoaMon.Enabled = true;
                btnXoaMon.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnXoaMon.Enabled = false;
                btnXoaMon.BackColor = Color.Gray;
            }
            if (dgvLop1.SelectedRows.Count > 0 && cbLop2.SelectedValue != null)
            {
                btnChuyen.Enabled = true;
                btnChuyen.BackColor = Color.FromArgb(0, 0, 192);
            }
            else
            {
                btnChuyen.Enabled = false;
                btnChuyen.BackColor = Color.Gray;
            }
            if (dgvLop2.SelectedRows.Count > 0)
            {
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.Gray;
            }
            if (txbTenKhoi.Text != string.Empty)
            {
                btnThemKhoi.Enabled = true;
                btnThemKhoi.BackColor = Color.FromArgb(255, 128, 0);
            }
            else
            {
                btnThemKhoi.Enabled = false;
                btnThemKhoi.BackColor = Color.Gray;
            }
            if (dgvKhoiLop.SelectedRows.Count > 0)
            {
                btnXoaKhoi.Enabled = true;
                btnXoaKhoi.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnXoaKhoi.Enabled = false;
                btnXoaKhoi.BackColor = Color.Gray;
            }
            if (dgvHocSinh.Rows.Count > 0)
            {
                btnInDanhSachLop.Enabled = true;
                btnInDanhSachLop.BackColor = Color.Blue;
            }
            else
            {
                btnInDanhSachLop.Enabled = false;
                btnInDanhSachLop.BackColor = Color.Gray;
            }
        }
        // Load dữ liệu cho comobobox khối lớp
        private void loadKhoiLop(ComboBox kl, ComboBox nh)
        {
            DataTable khoiLop = kl_objdm.TimKhoiLop(nh.SelectedValue.ToString());
            kl.DataSource = khoiLop;
            kl.DisplayMember = "TenKhoiLop";
            kl.ValueMember = "MaKhoiLop";
            kl.SelectedItem = null;
        }
        // Load dữ liệu cho datagridview các môn chưa có trong chương trình học
        private void loadDanhSachMonChuaCo()
        {
            DataTable monHoc = cth_objdm.TimChuongTrinhHocChuaCo(cbNamHoc3.SelectedValue.ToString(), cbKhoiLop2.SelectedValue.ToString());
            DataTable stt = taoCotSTT();
            stt.Merge(monHoc);
            dgvMon1.DataSource = stt;
            dgvMon1.Columns[1].Width = 40;
            dgvMon1.Columns[1].ReadOnly = true;
            dgvMon1.Columns[2].Width = 125;
            dgvMon1.Columns[2].HeaderText = "Mã Môn Học";
            dgvMon1.Columns[2].ReadOnly = true;
            dgvMon1.Columns[3].Width = 130;
            dgvMon1.Columns[3].HeaderText = "Tên Môn Học";
            dgvMon1.Columns[3].ReadOnly = true;
        }
        // Load dữ liệu cho datagridview các môn đã có trong chương trình học
        private void loadDanhSachMonDaCo()
        {
            DataTable monHoc = cth_objdm.TimChuongTrinhHoc(cbKhoiLop2.SelectedValue.ToString());
            DataTable stt = taoCotSTT();
            stt.Merge(monHoc);
            dgvMon2.DataSource = stt;
            dgvMon2.Columns[1].Width = 45;
            dgvMon2.Columns[1].ReadOnly = true;
            dgvMon2.Columns[2].Width = 130;
            dgvMon2.Columns[2].HeaderText = "Mã Môn Học";
            dgvMon2.Columns[2].ReadOnly = true;
            dgvMon2.Columns[3].Width = 130;
            dgvMon2.Columns[3].ReadOnly = true;
            dgvMon2.Columns[3].HeaderText = "Tên Môn Học";
            dgvMon2.Columns[4].Width = 75;
            dgvMon2.Columns[4].HeaderText = "Hệ Số*";
        }
        // Kiểm tra hệ số hợp lệ
        private bool heSoHopLe(string heSo)
        {
            float temp;
            return float.TryParse(heSo, out temp);
        }
        #endregion

        

       
       
        
        
    }
}
