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
    public partial class frmDangNhap : Form
    {
        NguoiDungBUS objdm = new NguoiDungBUS();
        public DataTable user = new DataTable();
        public frmQuanLyHocSinh parent;
        #region Sự kiện chính
        public frmDangNhap(ref frmQuanLyHocSinh form)
        {
            InitializeComponent();
            parent = form;
        }

        // Thay đổi hiển thị mật khẩu
        private void chbHienThi_CheckedChanged(object sender, EventArgs e)
        {
             txbMatKhau.PasswordChar = chbHienThi.Checked == true? '\0' : '*';
        }

        // Kiểm tra tài khoản có hợp lệ
        private void txbTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (kiemTraHopLe(txbTaiKhoan.Text))
            {
                labError.Text = "Tên tài khoản hợp lệ";
                labError.ForeColor = Color.Green;
                btnDangNhap.Enabled = true;
            }
            else
            {
                labError.Text = "Tên tài khoản không hợp lệ";
                labError.ForeColor = Color.Red;
                btnDangNhap.Enabled = false;
            }
        }
        // Ràng buộc tài khoản chỉ có ký tự alphabet và số
        private bool kiemTraHopLe(string str)
        {
            Regex re = new Regex("^[a-zA-Z0-9]{5,10}$");
            return re.IsMatch(str);
        }

        // Đăng nhập bằng nút đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txbMatKhau.Text != string.Empty)
            {
                string matKhau = NguoiDungBUS.ChuyenDoiPassword(txbMatKhau.Text);
                DataTable nguoiDung = objdm.TimNguoiDung(txbTaiKhoan.Text, matKhau);
                if (nguoiDung != null)
                {
                    if (nguoiDung.Rows.Count > 0)
                    {
                        user = nguoiDung;
                        parent.nguoiDung = user;
                        this.Close();
                    }
                    else
                    {
                        labLoginError.ForeColor = Color.Red;
                        labLoginError.Text = "Tên đăng nhập không tồn\ntại hoặc sai mật khẩu";
                    }
                }
            }
        }

        // Đăng nhập bằng nút enter
        private void txbMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
        // Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
