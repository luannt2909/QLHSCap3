using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using DAT.ConnectDatabase;
using DAT;
using BUS;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string ketNoi = File.ReadAllText(@"Script\ChuoiKetNoiCSDL.txt");

                if (ketNoi == string.Empty)
                {
                    frmConnectDatabase con = new frmConnectDatabase();
                    Application.Run(con);
                    ketNoi = File.ReadAllText(@"Script\ChuoiKetNoiCSDL.txt");
                    if (ketNoi == string.Empty)
                    {
                        if (MessageBox.Show("Kết nối dữ liệu chưa thành công, chương trình sẽ không hoạt động.", "Kết nối không thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            con.Close();
                        }
                    }
                    else
                    {
                        NguoiDungBUS nd_objdm = new NguoiDungBUS();
                        DataTable nguoiDung = nd_objdm.DanhSachNguoiDung();
                        if (nguoiDung.Rows.Count > 0)
                        {
                            Application.Run(new frmQuanLyHocSinh());
                        }
                        else
                        {
                            Application.Run(new frmDangKy());
                            DataTable nguoiDungMoi = nd_objdm.DanhSachNguoiDung();
                            if (nguoiDungMoi.Rows.Count > 0)
                            {
                                Application.Run(new frmQuanLyHocSinh());
                            }
                        }
                    }
                }
                else
                {
                    NguoiDungBUS nd_objdm = new NguoiDungBUS();
                    DataTable nguoiDung = nd_objdm.DanhSachNguoiDung();
                    if (nguoiDung.Rows.Count > 0)
                    {
                        Application.Run(new frmQuanLyHocSinh());
                    }
                    else
                    {
                        Application.Run(new frmDangKy());
                        DataTable nguoiDungMoi = nd_objdm.DanhSachNguoiDung();
                        if (nguoiDungMoi.Rows.Count > 0)
                        {
                            Application.Run(new frmQuanLyHocSinh());
                        }
                    }
                }
            }
            catch
            {

                if (MessageBox.Show("Tập tin ChuoiKetNoiCSDL.txt không tồn tại. Bạn có muốn tạo mới?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    File.WriteAllText(@"Script\ChuoiKetNoiCSDL.txt", "");
                    frmConnectDatabase con = new frmConnectDatabase();
                    Application.Run(con);
                    string ketNoi = File.ReadAllText(@"Script\ChuoiKetNoiCSDL.txt");
                    if (ketNoi == string.Empty)
                    {
                        if (MessageBox.Show("Kết nối dữ liệu chưa thành công, chương trình sẽ không hoạt động.", "Kết nối không thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            con.Close();
                        }
                    }
                    else
                    {
                        NguoiDungBUS nd_objdm = new NguoiDungBUS();
                        DataTable nguoiDung = nd_objdm.DanhSachNguoiDung();
                        if (nguoiDung.Rows.Count > 0)
                        {
                            Application.Run(new frmQuanLyHocSinh());
                        }
                        else
                        {
                            Application.Run(new frmDangKy());
                            DataTable nguoiDungMoi = nd_objdm.DanhSachNguoiDung();
                            if (nguoiDungMoi.Rows.Count > 0)
                            {
                                Application.Run(new frmQuanLyHocSinh());
                            }
                        }
                    }
                }
            }
            
        }
    }
}
