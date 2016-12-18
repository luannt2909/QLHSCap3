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
    public partial class frmDangKy : Form
    {
        NguoiDungBUS nd_objdm = new NguoiDungBUS();
        bool taiKhoanHopLe = false;
        bool matKhauHopLe = false;
        bool reMatKhauHopLe = false;
        public frmDangKy()
        {
            InitializeComponent();
            kiemTraHopLe();
        }

        #region Sự kiện chính
        // Kiểm tra hiển thị mật khẩu
        private void cbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            txbMatKhau.PasswordChar = cbHienThi.Checked == true ? '\0' : '*';
        }
        // Tạo tài khoản
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string matKhau = NguoiDungBUS.ChuyenDoiPassword(txbMatKhau.Text);
            nd_objdm.ThemNguoiDung(txbTaiKhoan.Text, matKhau, "Hiệu trưởng");
            this.Close();
        }
        // Kiểm tra tài khoản có hợp lệ
        private void txbTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (txbTaiKhoan.Text == string.Empty)
            {
                labTaiKhoanErr.Text = "Tên tài khoản không được để trống";
                labTaiKhoanErr.ForeColor = Color.Red;
                taiKhoanHopLe = false;
                kiemTraHopLe();
            }
            else if (kiemTraTaiKhoanHopLe(txbTaiKhoan.Text))
            {
                labTaiKhoanErr.Text = "Tên tài khoản hợp lệ";
                labTaiKhoanErr.ForeColor = Color.Green;
                taiKhoanHopLe = true;
                kiemTraHopLe();
            }
            else
            {
                labTaiKhoanErr.Text = "Tên tài khoản không hợp lệ";
                labTaiKhoanErr.ForeColor = Color.Red;
                taiKhoanHopLe = false;
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Hàm chức năng
        // Kiểm tra tên tài khoản hợp lệ
        private bool kiemTraTaiKhoanHopLe(string tk)
        {
            Regex re = new Regex("^[a-zA-Z0-9]{5,10}$");
            return re.IsMatch(tk);
        }

        // Kiểm tra hợp lệ cho nút xác nhận
        private void kiemTraHopLe()
        {
            if (taiKhoanHopLe && matKhauHopLe && reMatKhauHopLe)
            {
                btnXacNhan.Enabled = true;
            }
            else
            {
                btnXacNhan.Enabled = false;
            }
        }
        
        #endregion

        
    }
}
