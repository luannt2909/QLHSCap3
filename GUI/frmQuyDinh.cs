using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using System.Globalization;

namespace GUI
{
    public partial class frmQuyDinh : Form
    {
        ThamSoBUS objdm = new ThamSoBUS();
        #region Sự kiện form
        public frmQuyDinh()
        {
            InitializeComponent();
        }

        private void frmQuyDinh_Load(object sender, EventArgs e)
        {
            DataTable dt = objdm.DanhSachThamSo();
            txbTuoiToiThieu.Text = dt.Rows[0]["GiaTriThamSo"].ToString();
            txbTuoiToiDa.Text = dt.Rows[1]["GiaTriThamSo"].ToString();
            txbSiSoToiDa.Text = dt.Rows[2]["GiaTriThamSo"].ToString();
            txbDiemToiThieu.Text = dt.Rows[3]["GiaTriThamSo"].ToString();
            txbDiemToiDa.Text = dt.Rows[4]["GiaTriThamSo"].ToString();
            txbDiemDat.Text = dt.Rows[5]["GiaTriThamSo"].ToString();
            txbDiemDatMon.Text = dt.Rows[6]["GiaTriThamSo"].ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Sự kiện chính
        // Nhấn nút lưu để lưu để lưu các giá trị tham số
        private void btnLuu_Click(object sender, EventArgs e)
        {
            objdm.ThayDoiThamSo("TuoiToiThieu", int.Parse(txbTuoiToiThieu.Text));
            objdm.ThayDoiThamSo("TuoiToiDa", int.Parse(txbTuoiToiDa.Text));
            objdm.ThayDoiThamSo("SiSoToiDa", int.Parse(txbSiSoToiDa.Text));
            objdm.ThayDoiThamSo("DiemToiThieu", float.Parse(txbDiemToiThieu.Text));
            objdm.ThayDoiThamSo("DiemToiDa", float.Parse(txbDiemToiDa.Text));
            objdm.ThayDoiThamSo("DiemDat", float.Parse(txbDiemDat.Text));
            objdm.ThayDoiThamSo("DiemDatMon", float.Parse(txbDiemDatMon.Text));
            MessageBox.Show("Lưu thành công");
        }
        #endregion

        #region Hàm chức năng
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

        // Kiểm tra chỉ cho nhập int
        private void int_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        #endregion

    }
}
