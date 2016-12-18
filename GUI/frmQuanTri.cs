using System;
using System.Collections.Generic;
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
    public partial class frmQuanTri : Form
    {
        NguoiDungBUS nd_objdm = new NguoiDungBUS();
        NamHocBUS nh_objdm = new NamHocBUS();
        HocKyBUS hk_objdm = new HocKyBUS();
        frmQuanLyHocSinh parent;
        bool taiKhoanHopLe = false;
        bool matKhauHopLe = false;
        bool loaiNguoiDungHopLe = false;
        bool reMatKhauHopLe = false;
        #region Sự kiện form
        public frmQuanTri(ref frmQuanLyHocSinh form)
        {
            InitializeComponent();
            parent = form;
        }
        private void frmQuanTri_Load(object sender, EventArgs e)
        {
            kiemTraHopLe();
            cbLoaiNguoiDung.Items.Add("Hiệu trưởng");
            cbLoaiNguoiDung.Items.Add("Ban giám hiệu");
            cbLoaiNguoiDung.Items.Add("Giáo viên");
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Chọn";
            checkColumn.Width = 60;
            dgvNguoiDung.Columns.Add(checkColumn);
            dgvNamHoc.ForeColor = Color.Black;
            loadDanhSachnguoiDung();
            loadDanhSachNamHoc();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Sự kiện tab Người Dùng
        private void cbLoaiNguoiDung_DropDownClosed(object sender, EventArgs e)
        {
            if (cbLoaiNguoiDung.SelectedItem == null)
            {
                labLoaiNguoiDungErr.Text = "Vui lòng chọn loại người dùng";
                labLoaiNguoiDungErr.ForeColor = Color.Red;
                loaiNguoiDungHopLe = false;
                kiemTraHopLe();
            }
            else
            {
                labLoaiNguoiDungErr.Text = "Loại người dùng hợp lệ";
                labLoaiNguoiDungErr.ForeColor = Color.Green;
                loaiNguoiDungHopLe = true;
                kiemTraHopLe();
            }
        }
        // Thay đổi hiển thị mật khẩu
        private void chbHienThi_CheckStateChanged(object sender, EventArgs e)
        {
            txbMatKhau.PasswordChar = chbHienThi.Checked ? '\0' : '*';
        }
        // Nhấn nút thêm để thêm người dùng
        private void btnThem_Click(object sender, EventArgs e)
        {
            string matKhau = NguoiDungBUS.ChuyenDoiPassword(txbMatKhau.Text);
            nd_objdm.ThemNguoiDung(txbTaiKhoan.Text, matKhau, cbLoaiNguoiDung.SelectedItem.ToString());
            txbMatKhau.Text = string.Empty;
            txbTaiKhoan.Text = string.Empty;
            txbReMatKhau.Text = string.Empty;
            kiemTraHopLe();
            loadDanhSachnguoiDung();
        }
        // Kiểm tra các dòng được chọn bằng checkbox
        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvNguoiDung.Rows)
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
        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgvNguoiDung.Rows)
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
        // Nhấn nút xóa để xóa những người dùng được chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa những người dùng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvNguoiDung.SelectedRows)
                {
                    if (row.Cells[2].Value != null)
                    {
                        if (row.Cells[2].Value.Equals("Hiệu trưởng"))
                        {
                            if (MessageBox.Show(String.Format("Không thể xóa người dùng \"{0}\" loại người dùng \"Hiệu trưởng\"\nBạn có muốn tiếp tục?", row.Cells[1].Value.ToString().Trim()), "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
                            nd_objdm.XoaNguoiDung(row.Cells[1].Value.ToString());
                        }
                    }
                }
            }
            loadDanhSachnguoiDung();
            kiemTraHopLe();
        }
        // Kiểm tra ràng buộc tên tài khoản
        private void txbTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (txbTaiKhoan.Text == string.Empty)
            {
                labTaiKhoanErr.Text = "Tên tài khoản không được để trống";
                labTaiKhoanErr.ForeColor = Color.Red;
                taiKhoanHopLe = false;
                kiemTraHopLe();
            }
            else if (txbTaiKhoan.Text.Length < 5)
            {
                labTaiKhoanErr.Text = "Tên tài khoản từ 5 - 10 ký tự";
                labTaiKhoanErr.ForeColor = Color.Red;
                taiKhoanHopLe = false;
                kiemTraHopLe();
            }
            else if (!kiemTraTaiKhoanHopLe(txbTaiKhoan.Text))
            {
                labTaiKhoanErr.Text = "Tên tài khoản không chứa ký tự\nđặc biệt và khoản trắng";
                labTaiKhoanErr.ForeColor = Color.Red;
                taiKhoanHopLe = false;
                kiemTraHopLe();
            }
            else
            {
                if (nd_objdm.KiemTraNguoiDung(txbTaiKhoan.Text))
                {
                    labTaiKhoanErr.Text = "Tên tài khoản đã được sử dụng";
                    labTaiKhoanErr.ForeColor = Color.Red;
                    taiKhoanHopLe = false;
                    kiemTraHopLe();
                }
                else
                {
                    labTaiKhoanErr.Text = "Tên tài khoản hợp lệ";
                    labTaiKhoanErr.ForeColor = Color.Green;
                    taiKhoanHopLe = true;
                    kiemTraHopLe();
                }
            }
        }
        // Kiểm tra ràng buộc mật khẩu
        private void txbMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txbMatKhau.Text == string.Empty)
            {
                labMatKhauErr.Text = "Mật khẩu không được để trống";
                labMatKhauErr.ForeColor = Color.Red;
                matKhauHopLe = false;
                kiemTraHopLe();
            }
            else if (txbMatKhau.Text.Length < 8)
            {
                labMatKhauErr.Text = "Mật khẩu phải từ 8 - 16 ký tự";
                labMatKhauErr.ForeColor = Color.Red;
                matKhauHopLe = false;
                kiemTraHopLe();
            }
            else
            {
                labMatKhauErr.Text = "Mật khẩu có thể sử dụng";
                labMatKhauErr.ForeColor = Color.Green;
                matKhauHopLe = true;
                kiemTraHopLe();
            }
        }
        // Kiểm tra ràng buộc lặp lại mật khẩu
        private void txbReMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txbMatKhau.Text == txbReMatKhau.Text)
            {
                labReMatKhauErr.Text = "Hợp lệ";
                labReMatKhauErr.ForeColor = Color.Green;
                reMatKhauHopLe = true;
                kiemTraHopLe();
            }
            else
            {
                labReMatKhauErr.Text = "Không đúng với mật khẩu";
                labReMatKhauErr.ForeColor = Color.Red;
                reMatKhauHopLe = false;
                kiemTraHopLe();
            }
        }
        #endregion

        #region Sự kiện tab Khóa Học
        private void txbNam_Validated(object sender, EventArgs e)
        {
            if (txbNamBatDau.Text != string.Empty && txbNamKetThuc.Text != string.Empty)
            {
                if (int.Parse(txbNamKetThuc.Text) > int.Parse(txbNamBatDau.Text))
                {
                    labNamErr.Text = "Năm hợp lệ";
                    labNamErr.ForeColor = Color.Green;
                    btnThemNam.BackColor = Color.FromArgb(255, 128, 0);
                    btnThemNam.Enabled = true;
                }
                else
                {
                    labNamErr.Text = "Năm bắt đầu phải lớn hơn năm kết thúc";
                    labNamErr.ForeColor = Color.Red;
                    btnThemNam.BackColor = Color.Gray;
                    btnThemNam.Enabled = false;
                }
                if (txbNamBatDau.Text == string.Empty || txbNamKetThuc.Text == string.Empty)
                {
                    labNamErr.Text = "Xin vui lòng nhập đầy đủ năm";
                    labNamErr.ForeColor = Color.Red;
                    btnThemNam.BackColor = Color.Gray;
                    btnThemNam.Enabled = false;
                }
                if (nh_objdm.NamHocTonTai(int.Parse(txbNamBatDau.Text), int.Parse(txbNamKetThuc.Text)))
                {
                    labNamErr.Text = "Năm học đã tồn tại";
                    labNamErr.ForeColor = Color.Red;
                    btnThemNam.BackColor = Color.Gray;
                    btnThemNam.Enabled = false;
                }
            }
        }
        // Kiểm tra ràng buộc các textbox năm
        private void txbNam_TextChanged(object sender, EventArgs e)
        {
            if (txbNamBatDau.Text != string.Empty && txbNamKetThuc.Text != string.Empty)
            {
                if (int.Parse(txbNamKetThuc.Text) > int.Parse(txbNamBatDau.Text))
                {
                    labNamErr.Text = "Năm hợp lệ";
                    labNamErr.ForeColor = Color.Green;
                    btnThemNam.BackColor = Color.FromArgb(255, 128, 0);
                    btnThemNam.Enabled = true;
                }
                else
                {
                    labNamErr.Text = "Năm bắt đầu phải lớn hơn năm kết thúc";
                    labNamErr.ForeColor = Color.Red;
                    btnThemNam.BackColor = Color.Gray;
                    btnThemNam.Enabled = false;
                }
                if (txbNamBatDau.Text == string.Empty || txbNamKetThuc.Text == string.Empty)
                {
                    labNamErr.Text = "Xin vui lòng nhập đầy đủ năm";
                    labNamErr.ForeColor = Color.Red;
                    btnThemNam.BackColor = Color.Gray;
                    btnThemNam.Enabled = false;
                }
                if (nh_objdm.NamHocTonTai(int.Parse(txbNamBatDau.Text), int.Parse(txbNamKetThuc.Text)))
                {
                    labNamErr.Text = "Năm học đã tồn tại";
                    labNamErr.ForeColor = Color.Red;
                    btnThemNam.BackColor = Color.Gray;
                    btnThemNam.Enabled = false;
                }
                else if (nh_objdm.TimNamBatDau(int.Parse(txbNamBatDau.Text)).Rows.Count > 0)
                {
                    labNamErr.Text = "Hai năm học không được\ncó cùng năm bắt đầu";
                    labNamErr.ForeColor = Color.Red;
                    btnThemNam.BackColor = Color.Gray;
                    btnThemNam.Enabled = false;
                }
            }
        }
        // Nhấn nút thêm để thêm năm học
        private void btnThemNam_Click(object sender, EventArgs e)
        {
            string maNam = nh_objdm.MaNamHoc(txbNamBatDau.Text, txbNamKetThuc.Text);
            nh_objdm.ThemNamHoc(maNam, int.Parse(txbNamBatDau.Text), int.Parse(txbNamKetThuc.Text));
            loadDanhSachNamHoc();
            List<string> maHocKy = hk_objdm.MaHocKy(maNam);
            hk_objdm.ThemHocKy(maHocKy[0], "1", maNam);
            hk_objdm.ThemHocKy(maHocKy[1], "2", maNam);
        }
        #endregion 
        
        #region Hàm chức năng
        // Load dữ liệu cho datagridview người dùng
        private void loadDanhSachnguoiDung()
        {
            dgvNguoiDung.ForeColor = Color.Black;
            DataTable nguoiDung = nd_objdm.DanhSachNguoiDung();
            dgvNguoiDung.DataSource = nguoiDung;
            dgvNguoiDung.Columns[0].ReadOnly = false;
            dgvNguoiDung.Columns[1].Name = "TaiKhoan";
            dgvNguoiDung.Columns[2].Name = "LoaiNguoiDung";
            dgvNguoiDung.Columns[1].HeaderText = "Tên tài khoản";
            dgvNguoiDung.Columns[2].HeaderText = "Loại người dùng";
            dgvNguoiDung.Columns[1].ReadOnly = true;
            dgvNguoiDung.Columns[2].ReadOnly = true;
            dgvNguoiDung.Columns[1].Width = 253;
            dgvNguoiDung.Columns[2].Width = 254;
        }
        // Load dữ liệu cho datagridview năm học
        private void loadDanhSachNamHoc()
        {
            DataTable dsNamHoc = nh_objdm.DanhSachNamHoc();
            dgvNamHoc.DataSource = dsNamHoc;
            dgvNamHoc.Columns[0].Width = 544;
            dgvNamHoc.Columns[0].HeaderText = "Năm Học";
        }
        // Kiểm tra ràng buộc hợp lệ cho các nút chức năng
        private void kiemTraHopLe()
        {
            if (taiKhoanHopLe && matKhauHopLe && reMatKhauHopLe && loaiNguoiDungHopLe)
            {
                btnThem.Enabled = true;
                btnThem.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnThem.Enabled = false;
                btnThem.BackColor = Color.Gray;
            }
            if (dgvNguoiDung.SelectedRows.Count > 0)
            {
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.Gray;
            }
        }
        // Kiểm tra chỉ cho nhập int
        private void int_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // Kiểm tra tên tài khoản hợp lệ
        private bool kiemTraTaiKhoanHopLe(string tk)
        {
            Regex re = new Regex("^[a-zA-Z0-9]{5,10}$");
            return re.IsMatch(tk);
        }
        #endregion

    }
}
