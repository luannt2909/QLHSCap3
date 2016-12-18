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
using BUS;

namespace GUI
{
    public partial class frmBaoCao : Form
    {
        NamHocBUS nh_objdm = new NamHocBUS();
        HocKyBUS hk_objdm = new HocKyBUS();
        MonHocBUS mh_objdm = new MonHocBUS();
        TongKetHocKyBUS tkhk_objdm = new TongKetHocKyBUS();
        TongKetMonHocBUS tkmh_objdm = new TongKetMonHocBUS();
        ThamSoBUS ts_objdm = new ThamSoBUS();
        KhoiLopBUS kl_objdm = new KhoiLopBUS();
        LopBUS lh_objdm = new LopBUS();
        BangDiemBUS bd_objdm = new BangDiemBUS();
        CT_TongKetMonHocBUS cttkmh_objdm = new CT_TongKetMonHocBUS();
        QuaTrinhHocBUS qth_objdm = new QuaTrinhHocBUS();
        float diemDat;
        float diemDatMon;

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
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            loadNamHoc(cbNamHoc1);
            loadNamHoc(cbNamHoc2);
            diemDat = float.Parse((ts_objdm.TimGiaTriThamSo("DiemDat")).Rows[0][0].ToString());
            diemDatMon = float.Parse((ts_objdm.TimGiaTriThamSo("DiemDat")).Rows[0][0].ToString());
            kiemTraHopLe();
        }
        #endregion

        #region Sự kiện tab báo cáo môn học
        private void cbNamHoc1_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc1.SelectedItem != null)
            {
                loadHocKy(cbHocKy1, cbNamHoc1.SelectedValue.ToString());
                loadMonHoc();
            }
        }
        private void cbHocKy1_DropDownClosed(object sender, EventArgs e)
        {
            if (cbHocKy1.SelectedItem != null && cbMonHoc.SelectedItem != null)
            {
                loadBaoCaoMon();
                kiemTraHopLe();
            }
        }

        private void cbMonHoc_DropDownClosed(object sender, EventArgs e)
        {
            if (cbHocKy1.SelectedItem != null && cbMonHoc.SelectedItem != null)
            {
                loadBaoCaoMon();
                kiemTraHopLe();
            }
        }

        // Nhấn nút Báo Cáo Môn để tạo báo cáo môn học
        private void btnBaoCaoMon_Click(object sender, EventArgs e)
        {
            // Kiểm tra báo cáo môn tồn tại
            DataTable baoCao = tkmh_objdm.DanhSachBaoCaoMonHoc(cbHocKy1.SelectedValue.ToString());
            if (baoCao.Rows.Count > 0) // Báo cáo môn đã tồn tại
            {
                if (MessageBox.Show("Đã tồn tại báo cáo cho học kỳ này. Để tạo mới, tất cả báo cáo cũ sẽ bị xóa\nBạn có muốn tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tkmh_objdm.XoaBaoCaoMon(cbNamHoc1.SelectedValue.ToString());
                    DataTable mon = mh_objdm.DanhSachMonHoc(cbNamHoc1.SelectedValue.ToString());
                    List<string> monList = new List<string>();
                    foreach (DataRow row in mon.Rows)
                    {
                        monList.Add(row[0].ToString());
                    }
                    foreach (string maMH in monList)
                    {
                        string maTKMH = tkmh_objdm.MaTongKetMonHoc(maMH, cbHocKy1.SelectedValue.ToString());
                        tkmh_objdm.ThemBaoCaoMonHoc(maTKMH, maMH, cbHocKy1.SelectedValue.ToString());
                        DataTable lop = lh_objdm.TimLopTheoMon(maMH);
                        List<string> lopList = new List<string>();
                        List<int> siSoList = new List<int>();
                        foreach (DataRow row in lop.Rows)
                        {
                            lopList.Add(row[0].ToString());
                            siSoList.Add(int.Parse(row[1].ToString()));
                        }
                        for (int i = 0; i < lopList.Count; i++)
                        {
                            List<float> diemList = new List<float>();
                            DataTable dt = bd_objdm.TimBangDiem(lopList[i], maMH, cbHocKy1.SelectedValue.ToString());
                            foreach (DataRow row in dt.Rows)
                            {
                                diemList.Add(float.Parse(row[5].ToString()));
                            }
                            int soLuongDat = 0;
                            foreach (float diem in diemList)
                            {
                                if (diem > diemDatMon)
                                {
                                    soLuongDat++;
                                }
                            }
                            soLuongDat /= 2;
                            double tiLeDat = 0;
                            if (siSoList[i] > 0)
                            {
                                tiLeDat = ((double)soLuongDat / siSoList[i]) * 100;
                            }
                            tiLeDat = Math.Round(tiLeDat, 2);
                            string maCTTKM = cttkmh_objdm.MaCTBaoCaoMonHoc(maTKMH, lopList[i]);
                            cttkmh_objdm.ThemCTBaoCaoMonHoc(maCTTKM, maTKMH, lopList[i], soLuongDat, tiLeDat);
                        }
                    }
                }
            }
            else // Chưa tồn tại báo cáo
            {
                DataTable mon = mh_objdm.DanhSachMonHoc(cbNamHoc1.SelectedValue.ToString());
                List<string> monList = new List<string>();
                foreach (DataRow row in mon.Rows)
                {
                    monList.Add(row[0].ToString());
                }
                foreach (string maMH in monList)
                {
                    string maTKMH = tkmh_objdm.MaTongKetMonHoc(maMH, cbHocKy1.SelectedValue.ToString());
                    tkmh_objdm.ThemBaoCaoMonHoc(maTKMH, maMH, cbHocKy1.SelectedValue.ToString());
                    DataTable lop = lh_objdm.TimLopTheoMon(maMH);
                    List<string> lopList = new List<string>();
                    List<int> siSoList = new List<int>();
                    foreach (DataRow row in lop.Rows)
                    {
                        lopList.Add(row[0].ToString());
                        siSoList.Add(int.Parse(row[1].ToString()));
                    }
                    for (int i = 0; i < lopList.Count; i++)
                    {
                        List<float> diemList = new List<float>();
                        DataTable dt = bd_objdm.TimBangDiem(lopList[i], maMH, cbHocKy1.SelectedValue.ToString());
                        foreach (DataRow row in dt.Rows)
                        {
                            diemList.Add(float.Parse(row[5].ToString()));
                        }
                        int soLuongDat = 0;
                        foreach (float diem in diemList)
                        {
                            if (diem > diemDatMon)
                            {
                                soLuongDat++;
                            }
                        }
                        soLuongDat /= 2;
                        double tiLeDat = 0;
                        if (siSoList[i] > 0)
                        {
                            tiLeDat = ((double)soLuongDat / siSoList[i]) * 100;
                        }
                        tiLeDat = Math.Round(tiLeDat, 2);
                        string maCTTKM = cttkmh_objdm.MaCTBaoCaoMonHoc(maTKMH, lopList[i]);
                        cttkmh_objdm.ThemCTBaoCaoMonHoc(maCTTKM, maTKMH, lopList[i], soLuongDat, tiLeDat);
                    }
                }                
            }
            loadBaoCaoMon();
            kiemTraHopLe();
        }
        
        // Sự kiện của button In báo cáo môn học
        private void btnInBaoCaoMon_Click(object sender, EventArgs e)
        {
            if (dgvBaoCaoMon.Rows.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocumentBaoCaoMon;
                printDialog.UseEXDialog = true;

                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    printDocumentBaoCaoMon.DocumentName = "Báo cáo môn học";
                    printDocumentBaoCaoMon.Print();
                }
            }
            else
                MessageBox.Show("Không có dữ liệu để in", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void printDocumentBaoCaoMon_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                foreach (DataGridViewColumn dgvGridCol in dgvBaoCaoMon.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void printDocumentBaoCao_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                    foreach (DataGridViewColumn GridCol in dgvBaoCaoMon.Columns)
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
                while (iCount <= dgvBaoCaoMon.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvBaoCaoMon.Rows[iCount];
                    // Đặt độ cao của cell
                    iCellHeight = GridRow.Height + 5;
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
                            e.Graphics.DrawString("BÁO CÁO TỔNG KẾT MÔN HỌC", new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, new Point(150, 10));
                            e.Graphics.DrawString("Năm học: " + cbNamHoc1.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(100, 100));
                            e.Graphics.DrawString("Học kỳ: " + cbHocKy1.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(380, 100));
                            e.Graphics.DrawString("Môn: " + cbMonHoc.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(580, 100));


                            // Vẽ cột              
                            iTopMargin = e.MarginBounds.Top + 80;
                            foreach (DataGridViewColumn GridCol in dgvBaoCaoMon.Columns)
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

        #region Sự kiện tab báo cáo học kỳ
        private void cbNamHoc2_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc2.SelectedItem != null)
            {
                loadHocKy(cbHocKy2, cbNamHoc2.SelectedValue.ToString());
                kiemTraHopLe();
            }
        }

        private void cbHocKy2_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc2.SelectedItem != null && cbHocKy2.SelectedItem != null)
            {
                loadBaoCaoHocKy();
                kiemTraHopLe();
            }
        }
        // Nhấn nút báo cáo học kỳ để tạo báo cáo học kỳ
        private void btnBaoCaoHocKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra báo cáo tồn tại
            DataTable baoCao = tkhk_objdm.TimBaoCaoHocKy(cbHocKy2.SelectedValue.ToString());
            if (baoCao.Rows.Count > 0) // Báo cáo đã tồn tại
            {
                if (MessageBox.Show("Đã tồn tại báo cáo cho học kỳ này. Để tạo mới, tất cả báo cáo cũ sẽ bị xóa\nBạn có muốn tiếp tục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tkhk_objdm.XoaBaoCaoHocKy(cbHocKy2.SelectedValue.ToString());
                    List<string> lopList = new List<string>();
                    List<int> siSoList = new List<int>();
                    DataTable lop = lh_objdm.DanhSachLop(cbNamHoc2.SelectedValue.ToString());
                    foreach (DataRow row in lop.Rows)
                    {
                        lopList.Add(row[0].ToString());
                        siSoList.Add(int.Parse(row[1].ToString()));
                    }
                    for (int i = 0; i < lopList.Count; i++)
                    {
                        string maTKHK = tkhk_objdm.MaTongKetHocKy(lopList[i], cbHocKy2.SelectedValue.ToString());
                        int soLuongDat = 0;
                        float tiLeDat = 0;
                        DataTable diem = qth_objdm.DanhSachDiemTBHK(lopList[i], cbHocKy2.SelectedValue.ToString());
                        List<float> diemList = new List<float>();
                        foreach (DataRow row in diem.Rows)
                        {
                            diemList.Add(float.Parse(row[0].ToString()));
                        }
                        foreach (float d in diemList)
                        {
                            if (d >= diemDat)
                            {
                                soLuongDat++;
                            }
                        }
                        if (siSoList[i] > 0)
                        {
                            tiLeDat = (float)(soLuongDat / siSoList[i]);
                        }
                        tkhk_objdm.ThemBaoCaoHocKy(maTKHK, lopList[i], cbHocKy2.SelectedValue.ToString(), soLuongDat, tiLeDat);
                    }
                }
            }
            else // Báo cáo chưa tồn tại
            {
                List<string> lopList = new List<string>();
                List<int> siSoList = new List<int>();
                DataTable lop = lh_objdm.DanhSachLop(cbNamHoc2.SelectedValue.ToString());
                foreach (DataRow row in lop.Rows)
                {
                    lopList.Add(row[0].ToString());
                    siSoList.Add(int.Parse(row[1].ToString()));
                }
                for (int i = 0; i < lopList.Count; i++)
                {
                    string maTKHK = tkhk_objdm.MaTongKetHocKy(lopList[i], cbHocKy2.SelectedValue.ToString());
                    int soLuongDat = 0;
                    float tiLeDat = 0;
                    DataTable diem = qth_objdm.DanhSachDiemTBHK(lopList[i], cbHocKy2.SelectedValue.ToString());
                    List<float> diemList = new List<float>();
                    foreach (DataRow row in diem.Rows)
                    {
                        diemList.Add(float.Parse(row[0].ToString()));
                    }
                    foreach (float d in diemList)
                    {
                        if (d >= diemDat)
                        {
                            soLuongDat++;
                        }
                    }
                    if (siSoList[i] > 0)
                    {
                        tiLeDat = (float)(soLuongDat / siSoList[i]);
                    }
                    tkhk_objdm.ThemBaoCaoHocKy(maTKHK, lopList[i], cbHocKy2.SelectedValue.ToString(), soLuongDat, tiLeDat);
                }
            }
            loadBaoCaoHocKy();
            kiemTraHopLe();
        }

        // Sự kiện của button in báo cáo tổng kết học kỳ
        private void btnInBaoCaoHocKy_Click(object sender, EventArgs e)
        {
            if (dgvBaoCaoHocKy.Rows.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocumentBaoCaoHocKy;
                printDialog.UseEXDialog = true;

                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    printDocumentBaoCaoHocKy.DocumentName = "Báo cáo tổng kết học kỳ";
                    printDocumentBaoCaoHocKy.Print();
                }
            }
            else
                MessageBox.Show("Không có dữ liệu để in", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void printDocumentBaoCaoHocKy_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                foreach (DataGridViewColumn dgvGridCol in dgvBaoCaoHocKy.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void printDocumentBaoCaoHocKy_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                    foreach (DataGridViewColumn GridCol in dgvBaoCaoHocKy.Columns)
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
                while (iCount <= dgvBaoCaoHocKy.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvBaoCaoHocKy.Rows[iCount];
                    // Đặt độ cao của cell
                    iCellHeight = GridRow.Height + 5;
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
                            e.Graphics.DrawString("BÁO CÁO TỔNG KẾT HỌC KỲ", new Font("Times New Roman", 25, FontStyle.Bold), Brushes.Black, new Point(150, 10));
                            e.Graphics.DrawString("Năm học: " + cbNamHoc2.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(100, 100));
                            e.Graphics.DrawString("Học kỳ: " + cbHocKy2.Text, new Font("Times New Roman", 15, FontStyle.Bold), Brushes.Black, new Point(500, 100));

                            // Vẽ cột              
                            iTopMargin = e.MarginBounds.Top + 80;
                            foreach (DataGridViewColumn GridCol in dgvBaoCaoHocKy.Columns)
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

        #region Hàm chức năng
        // Load dữ liệu cho các combobox Năm Học
        private void loadNamHoc(ComboBox cb)
        {
            ComboBox temp = cb;
            DataTable namHoc = nh_objdm.DanhSachNamHoc();
            temp.DataSource = namHoc;
            temp.DisplayMember = "MaNam";
            temp.ValueMember = "MaNam";
            temp.SelectedItem = null;
        }
        // Load dữ liệu cho các combobox Học Kỳ
        private void loadHocKy(ComboBox cb, string maNam)
        {
            ComboBox temp = cb;
            DataTable hocKy = hk_objdm.TimHocKy(maNam);
            temp.DataSource = hocKy;
            temp.DisplayMember = "TenHocKy";
            temp.ValueMember = "MaHocKy";
            temp.SelectedItem = null;
        }
        // Load dữ liệu cho combobox Môn Học
        private void loadMonHoc()
        {
            DataTable mon = mh_objdm.DanhSachMonHoc(cbNamHoc1.SelectedValue.ToString());
            cbMonHoc.DataSource = mon;
            cbMonHoc.DisplayMember = "TenMonHoc";
            cbMonHoc.ValueMember = "MaMonHoc";
            cbMonHoc.SelectedItem = null;
        }
        // Load dữ liệu cho DataGridView Báo Cáo Môn
        private void loadBaoCaoMon()
        {
            DataTable baoCao = tkmh_objdm.TimBaoCaoMonHoc(cbMonHoc.SelectedValue.ToString(), cbHocKy1.SelectedValue.ToString());
            DataTable stt = taoCotSTT();
            stt.Merge(baoCao);
            dgvBaoCaoMon.DataSource = stt;
            dgvBaoCaoMon.ForeColor = Color.Black;
            dgvBaoCaoMon.Columns[0].Width = 50;
            dgvBaoCaoMon.Columns[1].HeaderText = "Tên Lớp";
            dgvBaoCaoMon.Columns[1].Width = 220;
            dgvBaoCaoMon.Columns[2].HeaderText = "Sỉ số";
            dgvBaoCaoMon.Columns[2].Width = 220;
            dgvBaoCaoMon.Columns[3].HeaderText = "Số lượng đạt";
            dgvBaoCaoMon.Columns[3].Width = 220;
            dgvBaoCaoMon.Columns[4].HeaderText = "Tỉ lệ đạt(%)";
            dgvBaoCaoMon.Columns[4].Width = 220;
        }
        // Load dữ liệu cho DataGridView Báo Cáo Học Kỳ
        private void loadBaoCaoHocKy()
        {
            DataTable baoCao = tkhk_objdm.TimBaoCaoHocKy(cbHocKy2.SelectedValue.ToString());
            DataTable stt = taoCotSTT();
            stt.Merge(baoCao);
            dgvBaoCaoHocKy.DataSource = stt;
            dgvBaoCaoHocKy.ForeColor = Color.Black;
            dgvBaoCaoHocKy.Columns[0].Width = 50;
            dgvBaoCaoHocKy.Columns[1].HeaderText = "Tên Lớp";
            dgvBaoCaoHocKy.Columns[1].Width = 220;
            dgvBaoCaoHocKy.Columns[2].HeaderText = "Sỉ số";
            dgvBaoCaoHocKy.Columns[2].Width = 220;
            dgvBaoCaoHocKy.Columns[3].HeaderText = "Số lượng đạt";
            dgvBaoCaoHocKy.Columns[3].Width = 220;
            dgvBaoCaoHocKy.Columns[4].HeaderText = "Tỉ lệ đạt(%)";
            dgvBaoCaoHocKy.Columns[4].Width = 220;
        }
        // Tạo datatable với một cột STT
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
        // Kiểm tra các ràng buộc cho các nút chức năng
        private void kiemTraHopLe()
        {
            if (cbHocKy1.SelectedItem != null && cbHocKy1.SelectedItem != null && cbMonHoc.SelectedItem != null)
            {
                btnBaoCaoMon.Enabled = true;
                btnBaoCaoMon.BackColor = Color.FromArgb(192, 64, 0);
            }
            else
            {
                btnBaoCaoMon.Enabled = false;
                btnBaoCaoMon.BackColor = Color.Gray;
            }
            if (dgvBaoCaoMon.Rows.Count > 0)
            {
                btnInBaoCaoMon.Enabled = true;
                btnInBaoCaoMon.BackColor = Color.Blue;
            }
            else
            {
                btnInBaoCaoMon.Enabled = false;
                btnInBaoCaoMon.BackColor = Color.Gray;
            } if (cbHocKy2.SelectedItem != null && cbHocKy2.SelectedItem != null)
            {
                btnBaoCaoHocKy.Enabled = true;
                btnBaoCaoHocKy.BackColor = Color.FromArgb(192, 64, 0);
            }
            else
            {
                btnBaoCaoHocKy.Enabled = false;
                btnBaoCaoHocKy.BackColor = Color.Gray;
            }
            if (dgvBaoCaoHocKy.Rows.Count > 0)
            {
                btnInBaoCaoHocKy.Enabled = true;
                btnInBaoCaoHocKy.BackColor = Color.Blue;
            }
            else
            {
                btnInBaoCaoHocKy.Enabled = false;
                btnInBaoCaoHocKy.BackColor = Color.Gray;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion            

        

        

        

        
    }
}
