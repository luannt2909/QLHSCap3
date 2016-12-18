using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BUS;

namespace GUI
{
    public partial class frmHocSinh : Form
    {
        HocSinhBUS hs_objdm = new HocSinhBUS();
        NamHocBUS nh_objdm = new NamHocBUS();
        ThamSoBUS ts_objdm = new ThamSoBUS();
        LopBUS lop_objdm = new LopBUS();
        GioiTinhBUS gt_objdm = new GioiTinhBUS();
        QuaTrinhHocBUS qth_objdm = new QuaTrinhHocBUS();
        HocKyBUS hk_objdm = new HocKyBUS();
        BangDiemBUS bd_objdm = new BangDiemBUS();
        CT_BangDiemBUS ctbd_objdm = new CT_BangDiemBUS();
        MonHocBUS mh_objdm = new MonHocBUS();
        LopBUS lh_objdm = new LopBUS();
        bool lopHopLe = true;
        bool tenHopLe = false;
        int tuoiToiThieu = 0;
        int tuoiToiDa = 0;
        string temp_tenHS;
        DateTime lowerLimit;
        DateTime upperLimit;
        int siSoToiDa = 0;
        #region Sự kiện form
        public frmHocSinh()
        {
            InitializeComponent();
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            kiemTraHopLe();
            loadNamHoc();         
            DataTable tuoiMinDT = ts_objdm.TimGiaTriThamSo("TuoiToiThieu");
            DataTable tuoiMaxDT = ts_objdm.TimGiaTriThamSo("TuoiToiDa");
            DataTable siSoMaxDT = ts_objdm.TimGiaTriThamSo("SiSoToiDa");
            tuoiToiThieu = int.Parse(tuoiMinDT.Rows[0]["GiaTriThamSo"].ToString());
            tuoiToiDa = int.Parse(tuoiMaxDT.Rows[0]["GiaTriThamSo"].ToString());
            siSoToiDa = int.Parse(siSoMaxDT.Rows[0]["GiaTriThamSo"].ToString());
            gioiHanNgaySinh(ref dtpNgaySinh, tuoiToiThieu, tuoiToiDa);
            dgvDanhSachHocSinh.Columns.Add(taoCheckColumn());
        }
        #endregion

        #region Sự kiện chính
        private void cbLop_DropDownClosed(object sender, EventArgs e)
        {
            if (cbLop.SelectedItem == null)
            {
                labLopErr.Text = "Phải chọn lớp";
                labLopErr.ForeColor = Color.Red;
                lopHopLe = false;
                kiemTraHopLe();
            }
            else
            {
                labLopErr.Text = "Lớp hợp lệ";
                labLopErr.ForeColor = Color.Green;
                lopHopLe = true;
                kiemTraHopLe();
                if (dgvDanhSachHocSinh.Rows.Count <= 0)
                {
                    taoDanhSachHocSinh();
                }
                else
                {
                    loadDanhSachHocSinh();
                }
            }
            
        }        
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Ràng buộc textbox Họ Tên chỉ cho phép ký tự Unicode và khoảng trắng
        private void txbHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(e.KeyChar.ToString(), @"^[\p{L} ]+$"))
            {
                e.Handled = true;
            }            
        }

        private void cbNamHoc_DropDownClosed(object sender, EventArgs e)
        {
            if (cbNamHoc.SelectedItem != null)
            {
                loadDanhSachLop();
                cbLop.SelectedItem = null;
                dgvDanhSachHocSinh.DataSource = null;
                dgvDanhSachHocSinh.Rows.Clear();
                kiemTraHopLe();
            }
        }
        // Nhấn nút thêm để thêm học sinh
        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable lop = lh_objdm.TimLop(cbLop.SelectedValue.ToString());
            if (int.Parse(lop.Rows[0][1].ToString()) < siSoToiDa)
            {
                string maHS = HocSinhBUS.MaHocSinh(cbNamHoc.SelectedValue.ToString());
                if (rdbNam.Checked)
                {
                    hs_objdm.ThemHocSinh(maHS, txbHoTen.Text, "Nam", dtpNgaySinh.Value, txbDiaChi.Text, txbEmail.Text);
                }
                if (rdbNu.Checked)
                {
                    hs_objdm.ThemHocSinh(maHS, txbHoTen.Text, "Nữ", dtpNgaySinh.Value, txbDiaChi.Text, txbEmail.Text);
                }
                DataTable mon = mh_objdm.DanhSachMonHocTheoLop(cbLop.SelectedValue.ToString());
                List<string> monList = new List<string>();
                foreach (DataRow row in mon.Rows)
                {
                    monList.Add(row.ItemArray[0].ToString());
                }
                List<string> hk = hk_objdm.MaHocKy(cbNamHoc.SelectedValue.ToString());
                string maQTH1 = qth_objdm.MaQuaTrinhHoc(maHS, cbLop.SelectedValue.ToString(), "1");
                string maQTH2 = qth_objdm.MaQuaTrinhHoc(maHS, cbLop.SelectedValue.ToString(), "2");
                qth_objdm.ThemQuaTrinhHoc(maQTH1, maHS, cbLop.SelectedValue.ToString(), hk[0], 0F);
                qth_objdm.ThemQuaTrinhHoc(maQTH2, maHS, cbLop.SelectedValue.ToString(), hk[1], 0F);
                foreach (string maMH in monList)
                {
                    string maBD = bd_objdm.TaoMaBangDiem(maQTH1, maMH);
                    bd_objdm.ThemBangDiem(maBD, maQTH1, maMH, 0F);
                    ctbd_objdm.ThemCTBangDiem(maBD, "15Phut", 0F);
                    ctbd_objdm.ThemCTBangDiem(maBD, "1T", 0F);
                } foreach (string maMH in monList)
                {
                    string maBD = bd_objdm.TaoMaBangDiem(maQTH2, maMH);
                    bd_objdm.ThemBangDiem(maBD, maQTH2, maMH, 0F);
                    ctbd_objdm.ThemCTBangDiem(maBD, "15Phut", 0F);
                    ctbd_objdm.ThemCTBangDiem(maBD, "1T", 0F);
                }
                loadDanhSachHocSinh();
                txbHoTen.Text = string.Empty;
                txbEmail.Text = string.Empty;
                txbDiaChi.Text = string.Empty;
                kiemTraHopLe();
                lop_objdm.TangSiSo(cbLop.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Lớp đã đạt sỉ số tối đa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Kiểm tra textbox Họ tên có trống hay không
        private void txbHoTen_TextChanged(object sender, EventArgs e)
        {
            if (txbHoTen.Text == string.Empty)
            {
                labTenErr.Text = "Tên không để trống";
                labTenErr.ForeColor = Color.Red;
                tenHopLe = false;
                kiemTraHopLe();
            }
            else
            {
                labTenErr.Text = "Tên hợp lệ";
                labTenErr.ForeColor = Color.Green;
                tenHopLe = true;
                kiemTraHopLe();
            }
        }
        // Nhấn nút xóa để xóa học sinh được chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa những học sinh đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvDanhSachHocSinh.SelectedRows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        hs_objdm.XoaHocSinh(row.Cells[2].Value.ToString());                     

                    }
                }
                kiemTraHopLe();
                loadDanhSachHocSinh();
            }
        }
        // Kiểm tra các dòng được chọn bằng checkbox
        private void dgvDanhSachHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvDanhSachHocSinh.Rows[e.RowIndex] != null)
                {
                    temp_tenHS = dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[3].Value.ToString();                    
                }
            }
            foreach (DataGridViewRow row in dgvDanhSachHocSinh.Rows)
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
        // Kiểm tra các dòng được chọn bằng checkbox
        private void dgvDanhSachHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvDanhSachHocSinh.Rows)
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
        // Cập nhật dữ liệu học sinh khi datagridview được thay đổi
        private void dgvDanhSachHocSinh_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

            }
            else if (dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[3].Value.ToString() == string.Empty)
            {
                dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[3].Value = temp_tenHS;
                MessageBox.Show("Tên không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Regex.IsMatch(dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[3].Value.ToString().ToString(), @"^[\p{L} ]+$"))
            {
                dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[3].Value = temp_tenHS;
                MessageBox.Show("Tên không được chứa số và ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string maHS = dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[2].Value.ToString();
                string tenHS = dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[3].Value.ToString();
                string gioiTinh = dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[4].Value.ToString();
                DateTime ngaySinh = (DateTime)dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[5].Value;
                string diaChi = dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[7].Value.ToString();
                string email = dgvDanhSachHocSinh.Rows[e.RowIndex].Cells[6].Value.ToString();
                hs_objdm.SuaHocSinh(maHS, tenHS, gioiTinh, ngaySinh, diaChi, email);
                dgvDanhSachHocSinh.BeginInvoke(new MethodInvoker(() => { loadDanhSachHocSinh(); }));
                kiemTraHopLe();
            }
        }
        #endregion

        #region Hàm chức năng
        // Tạo DataTable với cột STT
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
        // Tạo cột checkbox cho DataGridView
        private DataGridViewCheckBoxColumn taoCheckColumn()
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Chọn";
            checkColumn.Width = 50;
            return checkColumn;
        }
        // Load dữ liệu cho DataGridView học sinh
        private void loadDanhSachHocSinh()
        {
            DataTable hocSinh = hs_objdm.HoSoHocSinhTheoLop(cbLop.SelectedValue.ToString());
            DataTable temp = taoCotSTT();
            temp.Merge(hocSinh);
            dgvDanhSachHocSinh.DataSource = temp;
        }
        // Khởi tạo datagridview học sinh
        private void taoDanhSachHocSinh()
        {
            upperLimit = minNgaySinh(tuoiToiThieu);
            lowerLimit = maxNgaySinh(tuoiToiDa);
            dgvDanhSachHocSinh.AutoGenerateColumns = false;

            DataTable hocSinh = hs_objdm.HoSoHocSinhTheoLop(cbLop.SelectedValue.ToString());
            DataTable temp = taoCotSTT();
            DataTable gt = gt_objdm.DanhSachGioiTinh();
            temp.Merge(hocSinh);
            BindingSource gioiTinhSource = new BindingSource();
            gioiTinhSource.DataSource = gt;
            dgvDanhSachHocSinh.DataSource = temp;

            DataGridViewTextBoxColumn stt = new DataGridViewTextBoxColumn();
            stt.DataPropertyName = "STT";
            stt.HeaderText = "STT";

            DataGridViewTextBoxColumn maHS = new DataGridViewTextBoxColumn();
            maHS.DataPropertyName = "MaHocSinh";
            maHS.HeaderText = "Mã học sinh";

            DataGridViewTextBoxColumn tenHS = new DataGridViewTextBoxColumn();
            tenHS.DataPropertyName = "TenHocSinh";
            tenHS.HeaderText = "Tên học sinh*";

            DataGridViewComboBoxColumn gioiTinh = new DataGridViewComboBoxColumn();
            gioiTinh.DataSource = gioiTinhSource;
            gioiTinh.DisplayMember = "GioiTinh";
            gioiTinh.ValueMember = "GioiTinh";
            gioiTinh.DataPropertyName = "GioiTinh";
            gioiTinh.HeaderText = "Giới tính*";

            CalendarColumn ngaySinh = new CalendarColumn();
            ngaySinh.DataPropertyName = "NgaySinh";
            ngaySinh.HeaderText = "Ngày sinh*";
            ngaySinh.MaxDate = upperLimit;
            ngaySinh.MinDate = lowerLimit;

            DataGridViewTextBoxColumn email = new DataGridViewTextBoxColumn();
            email.HeaderText = "Email*";
            email.DataPropertyName = "Email";

            DataGridViewTextBoxColumn diaChi = new DataGridViewTextBoxColumn();
            diaChi.HeaderText = "Địa chỉ*";
            diaChi.DataPropertyName = "DiaChi";

            dgvDanhSachHocSinh.Columns.Add(stt);
            dgvDanhSachHocSinh.Columns.Add(maHS);
            dgvDanhSachHocSinh.Columns.Add(tenHS);
            dgvDanhSachHocSinh.Columns.Add(gioiTinh);
            dgvDanhSachHocSinh.Columns.Add(ngaySinh);
            dgvDanhSachHocSinh.Columns.Add(email);
            dgvDanhSachHocSinh.Columns.Add(diaChi);

            dgvDanhSachHocSinh.Columns[1].ReadOnly = true;
            dgvDanhSachHocSinh.Columns[1].Width = 56;
            dgvDanhSachHocSinh.Columns[2].Width = 144;
            dgvDanhSachHocSinh.Columns[2].ReadOnly = true;
            dgvDanhSachHocSinh.Columns[3].Width = 172;
            dgvDanhSachHocSinh.Columns[4].Width = 100;
            dgvDanhSachHocSinh.Columns[5].Width = 100;
            dgvDanhSachHocSinh.Columns[6].Width = 172;
            dgvDanhSachHocSinh.Columns[7].Width = 172;
        }
        // Load dữ liệu cho combobox lớp
        private void loadDanhSachLop()
        {
            DataTable dsLop = lop_objdm.DanhSachLop(cbNamHoc.SelectedValue.ToString());
            cbLop.DataSource = dsLop;
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "MaLop";
            cbLop.SelectedItem = null;
        }
        // Load dữ liệu cho combobox năm học
        private void loadNamHoc()
        {
            DataTable namHoc = nh_objdm.DanhSachNamHoc();
            cbNamHoc.DataSource = namHoc;
            cbNamHoc.DisplayMember = "MaNam";
            cbNamHoc.ValueMember = "MaNam";
            cbNamHoc.SelectedItem = null;
        }
        // Giới hạn ngày sinh theo độ tuổi quy định
        private void gioiHanNgaySinh(ref DateTimePicker dtp, int tuoiMin, int tuoiMax)
        {
            DateTimePicker datePicker = dtp;
            DateTime now = DateTime.Now;
            TimeSpan lowerLimit = now.AddYears(tuoiMin) - now;
            TimeSpan upperLimit = now.AddYears(tuoiMax) - now;
            datePicker.MinDate = now.Subtract(upperLimit);
            datePicker.MaxDate = now.Subtract(lowerLimit);
        }
        // Trả về ngày sinh tối thiểu
        private DateTime minNgaySinh(int tuoiMin)
        {
            DateTime now = DateTime.Now;
            TimeSpan lowerLimit = now.AddYears(tuoiMin) - now;
            return now.Subtract(lowerLimit);
        }
        // Trả về ngày sinh tối đa
        private DateTime maxNgaySinh(int tuoiMax)
        {
            DateTime now = DateTime.Now;
            TimeSpan upperLimit = now.AddYears(tuoiMax) - now;
            return now.Subtract(upperLimit);
        }
        // Kiểm tra ràng buộc các nút chức năng
        private void kiemTraHopLe()
        {
            if (tenHopLe && lopHopLe)
            {
                btnThem.Enabled = true;
                btnThem.BackColor = Color.FromArgb(255, 128, 0);
            }
            else
            {
                btnThem.Enabled = false;
                btnThem.BackColor = Color.Gray;
            }
            if (dgvDanhSachHocSinh.SelectedRows.Count > 0)
            {
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(198, 0, 0);
            }
            else
            {
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.Gray;
            }
        }
        #endregion
    }
}
