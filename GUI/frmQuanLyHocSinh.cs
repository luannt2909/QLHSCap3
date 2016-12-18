using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAT.ConnectDatabase;
using DAT;


namespace GUI
{
    public partial class frmQuanLyHocSinh : Form
    {
        public DataTable nguoiDung;
        public string nguoiDungHienTai;

        #region Sự kiện form
        public frmQuanLyHocSinh()
        {
            InitializeComponent();
        }
        private void frmQuanLyHocSinh_Load(object sender, EventArgs e)
        {
            phanQuyen("Khách");
        }
        #endregion

        #region Sự kiện chính
        // Nhấn nút Quản Trị
        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            frmQuanLyHocSinh temp = new frmQuanLyHocSinh();
            temp = this;
            frmQuanTri form = new frmQuanTri(ref temp);
            form.ShowDialog();
        }

        // Nhấn nút Hồ Sơ Học Sinh
        private void btnTiepNhanHocSinh_Click(object sender, EventArgs e)
        {
            frmHocSinh form = new frmHocSinh();
            form.ShowDialog();
        }

        // Nhấn nút Quản Lý Lớp Học
        private void btnDanhSachLop_Click(object sender, EventArgs e)
        {
            frmQuanLyLopHoc form = new frmQuanLyLopHoc();
            form.ShowDialog();
        }

        // Nhấn nút Quản Lý Môn Học
        private void btnQuanLyMonHoc_Click(object sender, EventArgs e)
        {
            frmQuanLyMonHoc form = new frmQuanLyMonHoc();
            form.ShowDialog();
        }

        // Nhấn nút Tra Cứu
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            frmTraCuu form = new frmTraCuu();
            form.ShowDialog();
        }

        // Nhấn nút Báo Cáo
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao form = new frmBaoCao();
            form.ShowDialog();
        }

        // Nhấn nút Quy Định
        private void btnQuyDinh_Click(object sender, EventArgs e)
        {
            frmQuyDinh form = new frmQuyDinh();
            form.ShowDialog();
        }

        // Nhấn nút Thông Tin Sản Phẩm
        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem form = new frmThongTinPhanMem();
            form.ShowDialog();
        }

        // Nhấn nút Đăng Nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmQuanLyHocSinh temp = new frmQuanLyHocSinh();
            temp = this;
            frmDangNhap form = new frmDangNhap(ref temp);
            form.ShowDialog();

            // Đăng nhập thành công
            if (nguoiDung != null)
            {
                labDangNhap.Text = "Chào mừng, " + nguoiDung.Rows[0]["TenDangNhap"].ToString();
                nguoiDungHienTai = nguoiDung.Rows[0]["TenDangNhap"].ToString();
                string loaiNguoiDung = nguoiDung.Rows[0]["LoaiNguoiDung"].ToString();
                phanQuyen(loaiNguoiDung);
                Point location = new Point(278, 14);
                btnDangNhap.Location = location;
            }
        }
        // Nhấn bút database
        private void btnDatabase_Click(object sender, EventArgs e)
        {
            frmConnectDatabase form = new frmConnectDatabase();
            form.ShowDialog();  
        }
        #endregion Sự kiện chính

        #region Hàm chức năng
        // Phân quyền người dùng
        private void phanQuyen(string loaiNguoiDung)
        {
            if (loaiNguoiDung == "Hiệu trưởng")
            {
                btnQuyDinh.Enabled = true;
                btnQuyDinh.BackColor = Color.FromArgb(0, 0, 64);
                labQuyDinh.BackColor = Color.FromArgb(0, 0, 64);
                btnNguoiDung.Enabled = true;
                btnNguoiDung.BackColor = Color.FromArgb(64, 0, 64);
                labQuanTri.BackColor = Color.FromArgb(64, 0, 64);
                btnQuanLyMonHoc.Enabled = false;
                btnQuanLyMonHoc.BackColor = Color.Gray;
                labQuanLyMonHoc.BackColor = Color.Gray;
                btnTiepNhanHocSinh.Enabled = false;
                btnTiepNhanHocSinh.BackColor = Color.Gray;
                labTiepNhanHocSinh.BackColor = Color.Gray;
                btnDanhSachLop.Enabled = false;
                btnDanhSachLop.BackColor = Color.Gray;
                labQuanLyLopHoc.BackColor = Color.Gray;
            }
            if (loaiNguoiDung == "Ban giám hiệu")
            {
                btnQuyDinh.Enabled = false;
                btnQuyDinh.BackColor = Color.Gray;
                labQuyDinh.BackColor = Color.Gray;
                btnNguoiDung.Enabled = false;
                btnNguoiDung.BackColor = Color.Gray;
                labQuanTri.BackColor = Color.Gray;
                btnQuanLyMonHoc.Enabled = false;
                btnQuanLyMonHoc.BackColor = Color.Gray;
                labQuanLyMonHoc.BackColor = Color.Gray;
                btnTiepNhanHocSinh.Enabled = true;
                btnTiepNhanHocSinh.BackColor = Color.FromArgb(192, 64, 0);
                labTiepNhanHocSinh.BackColor = Color.FromArgb(192, 64, 0);
                btnDanhSachLop.Enabled = true;
                btnDanhSachLop.BackColor = Color.Maroon;
                labQuanLyLopHoc.BackColor = Color.Maroon;
            }
            if (loaiNguoiDung == "Giáo viên")
            {
                btnQuyDinh.Enabled = false;
                btnQuyDinh.BackColor = Color.Gray;
                labQuyDinh.BackColor = Color.Gray;
                btnNguoiDung.Enabled = false;
                btnNguoiDung.BackColor = Color.Gray;
                labQuanTri.BackColor = Color.Gray;
                btnQuanLyMonHoc.Enabled = true;
                btnQuanLyMonHoc.BackColor = Color.FromArgb(192, 192, 0);
                labQuanLyMonHoc.BackColor = Color.FromArgb(192, 192, 0);
                btnTiepNhanHocSinh.Enabled = false;
                btnTiepNhanHocSinh.BackColor = Color.Gray;
                labTiepNhanHocSinh.BackColor = Color.Gray;
                btnDanhSachLop.Enabled = false;
                btnDanhSachLop.BackColor = Color.Gray;
                labQuanLyLopHoc.BackColor = Color.Gray;
            }
            if (loaiNguoiDung == "Khách")
            {
                btnQuyDinh.Enabled = false;
                btnQuyDinh.BackColor = Color.Gray;
                labQuyDinh.BackColor = Color.Gray;
                btnNguoiDung.Enabled = false;
                btnNguoiDung.BackColor = Color.Gray;
                labQuanTri.BackColor = Color.Gray;
                btnQuanLyMonHoc.Enabled = false;
                btnQuanLyMonHoc.BackColor = Color.Gray;
                labQuanLyMonHoc.BackColor = Color.Gray;
                btnTiepNhanHocSinh.Enabled = false;
                btnTiepNhanHocSinh.BackColor = Color.Gray;
                labTiepNhanHocSinh.BackColor = Color.Gray;
                btnDanhSachLop.Enabled = false;
                btnDanhSachLop.BackColor = Color.Gray;
                labQuanLyLopHoc.BackColor = Color.Gray;
            }
        }
        #endregion

       
    }
}
