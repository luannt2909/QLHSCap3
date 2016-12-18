using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.Win32;
using System.Windows;
using DTO;




namespace DAT.ConnectDatabase
{
    public partial class frmConnectDatabase : Form
    {
        #region Các biến
        private bool IntegratedSecurity;
        private Server LayTenCSDLCuaServer;
        private ServerConnection ServerConn;
        private string TenServer;
        private string TenCSDL;
        private string TenTaiKhoan;
        private string MatKhau;
        private string ThongTinKetNoiServer;
        private string ThongTinKetNoiCSDL;
        private bool KetQuaKetNoiServer = false;
        private bool KetQuaKetNoiCSDL = false ;
        private List<string> DanhSachTenServer;
        public static string ChuoiKetNoiCSDL = null;
        #endregion

        public frmConnectDatabase()
        {
            InitializeComponent();
        }

        #region Sự kiện của form

        // Sự kiện Form load
        private void frmConnectDatabase_Load(object sender, EventArgs e)
        {
            
            IntegratedSecurity = true;
            pnKetNoiServer.Enabled = true;
            pnKetNoiCSDL.Enabled = false;
            btnLuu.Enabled = false;
            DanhSachTenServer = LayTatCaTenServer();

            foreach (string s in DanhSachTenServer)
                cbTenServer.Items.Add(s);

            cbTenServer.SelectedIndex = 0;
            cbKieuXacThuc.SelectedIndex = 0;
        }

        // Sự kiện của comboBox # Tên Server
        private void cbTenServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            TenServer = cbTenServer.Text;
        }

        // Sự kiện của comboBox # Kiểu xác thực
        private void cbKieuXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbKieuXacThuc.SelectedIndex == 0)
            {
                txbMatKhau.Clear();
                txbMatKhau.Enabled = false;
                txbTenTaiKhoan.Enabled = false;
                txbThongTinKetNoiServer.Clear();
                txbTenTaiKhoan.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
                IntegratedSecurity = true;
                chbHienThiMatKhau.Enabled = false;
            }
            else
            {
                txbMatKhau.Clear();
                txbMatKhau.Enabled = true;
                txbThongTinKetNoiServer.Clear();
                txbTenTaiKhoan.Clear();
                txbTenTaiKhoan.Enabled = true;
                IntegratedSecurity = false;
                chbHienThiMatKhau.Enabled = true;
            }
        }

        // Sự kiện của textBox # Tên tài khoản
        private void txbTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            TenTaiKhoan = txbTenTaiKhoan.Text;
        }

        // Sự kiện của textBox # Mật khẩu
        private void txbMatKhau_TextChanged(object sender, EventArgs e)
        {
            MatKhau = txbMatKhau.Text;
            if (cbKieuXacThuc.SelectedIndex == 1)
                txbMatKhau.UseSystemPasswordChar = true;
        }

        // Sự kiện của checkbox # Hiển thị mật khẩu
        private void chbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienThiMatKhau.Checked == true)
                txbMatKhau.UseSystemPasswordChar = false;
            else
                txbMatKhau.UseSystemPasswordChar = true;
        }

        // Sự kiện của button # Kết nối
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if(cbKieuXacThuc.SelectedIndex == 0)
                {
                    if (KetNoiDenServer(ChuoiKetNoiDenServer(TenServer, "master", IntegratedSecurity)))
                    {
                        KetQuaKetNoiServer = true;
                        ServerConn = new ServerConnection(cbTenServer.Text);
                        LayTenCSDLCuaServer = new Server(ServerConn);
                    }
                }
                else
                {
                    if (KetNoiDenServer(ChuoiKetNoiDenServer(TenServer, "master", TenTaiKhoan, MatKhau, IntegratedSecurity)))
                    {
                        KetQuaKetNoiServer = true;
                        ServerConn = new ServerConnection(cbTenServer.Text);
                        LayTenCSDLCuaServer = new Server(ServerConn);
                    }
                }
                DanhSachCSDL();
                if(KetQuaKetNoiServer == true)
                {
                    this.Cursor = Cursors.Default;
                    ThongTinKetNoiServer = "\nKết nối đến SQL Server thành công! Tên Server: " + TenServer;
                    pnKetNoiServer.Enabled = false;
                    pnKetNoiCSDL.Enabled = true;
                    btnKiemTra.Enabled = false;
                    btnXoa.Enabled = false;
                    btnTaoMoi.Enabled = false;
                    btnTaoDuLieuMau.Enabled = false;
                    txbThongTinKetNoiServer.Text = ThongTinKetNoiServer;

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    ThongTinKetNoiServer = "\nKết nối đến SQL Server thất bại!\nXin kiểm tra lại!";
                    pnKetNoiServer.Enabled = true;
                    pnKetNoiCSDL.Enabled = false;
                    txbThongTinKetNoiServer.Text = ThongTinKetNoiServer;
                }                
            }
            catch(Exception ex)
            {
                this.Cursor = Cursors.Default;
                ThongTinKetNoiServer = "Có lỗi xảy ra: " + ex.Message;
                txbThongTinKetNoiServer.Text = ThongTinKetNoiServer;
            }
            this.Cursor = Cursors.Default;

        }

        // Sự kiện của textBox # Thông tin kết nối server
        private void txbThongTinKetNoiServer_TextChanged(object sender, EventArgs e)
        {
            txbThongTinKetNoiServer.Text = ThongTinKetNoiServer;
        }

        // Sự kiện của comboBox # Tên cơ sở dữ liệu
        private void cbTenCSDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            TenCSDL = cbTenCSDL.Text;
            btnKiemTra.Enabled = true;
            btnXoa.Enabled = true;
            btnTaoMoi.Enabled = false;
            btnTaoDuLieuMau.Enabled = false;
            btnLuu.Enabled = false;
            txbTaoCSDLMoi.Text = null;
        }

       

        // Sự kiện của button # Kiểm tra
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                

                if (KiemTraCSDL(cbTenCSDL.Text) == true)
                {
                    this.Cursor = Cursors.Default;
                    btnTaoDuLieuMau.Enabled = true;
                    btnXoa.Enabled = true;
                    btnTaoMoi.Enabled = false;
                    btnKiemTra.Enabled = true;
                    btnLuu.Enabled = true;
                    KetQuaKetNoiCSDL = true;
                    ThongTinKetNoiCSDL = "Cơ sở dữ liệu hợp lệ! Tên cơ sở dữ liệu: " + cbTenCSDL.Text;
                    txbThongTinKetNoiCSDL.Text = ThongTinKetNoiCSDL;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    btnKiemTra.Enabled = true;
                    btnXoa.Enabled = true;
                    btnTaoMoi.Enabled = false;
                    btnTaoDuLieuMau.Enabled = false;
                    btnLuu.Enabled = false;
                    KetQuaKetNoiCSDL = false;
                    ThongTinKetNoiCSDL = "Cơ sở dữ liệu không hợp lệ! Vui lòng tạo mới hoặc chọn cơ sở dữ liệu khác!";
                    txbThongTinKetNoiCSDL.Text = ThongTinKetNoiCSDL;
                }
            }
            catch
            {
                ThongTinKetNoiCSDL = "Tên cơ sở dữ liệu không hợp lệ! Xin kiểm tra lại.";
                txbThongTinKetNoiCSDL.Clear();
                txbThongTinKetNoiCSDL.Text = "Lỗi: " + ThongTinKetNoiCSDL;
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }


        // Sự kiện của button # Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string temp = File.ReadAllText(@"Script\\ChuoiKetNoiCSDL.txt");
            if (temp.Contains(cbTenCSDL.Text) == true)
            {
                MessageBox.Show("Không thể xóa cơ sở dữ liệu " + TenCSDL + ". Vì bạn đang dùng cuối kết nối CSDL này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;

            }
            else
            {
                try
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa cơ sở dữ liệu " + TenCSDL, "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (cbKieuXacThuc.SelectedIndex == 0)
                        {
                            string LayChuoiKetNoi = ChuoiKetNoiDenServer(TenServer, "master", IntegratedSecurity);
                            if (XoaCSDL(LayChuoiKetNoi, TenCSDL) == true)
                            {
                                this.Cursor = Cursors.Default;
                                txbThongTinKetNoiCSDL.Clear();
                                txbThongTinKetNoiCSDL.Text = "Đã xóa thành công cơ sở dữ liệu '" + TenCSDL + "' từ SQL Server " + TenServer;
                                btnKiemTra.Enabled = false;
                                btnXoa.Enabled = false;
                                btnTaoMoi.Enabled = false;
                                btnTaoDuLieuMau.Enabled = false;
                                btnLuu.Enabled = false;
                                txbTaoCSDLMoi.Clear();
                                cbTenCSDL.Items.Remove(TenCSDL);
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                txbThongTinKetNoiCSDL.Text = "Có lỗi xảy ra! Không thể xóa cơ sở dữ liệu: " + TenCSDL;
                            }

                        }
                        else
                        {
                            string LayChuoiKetNoi = ChuoiKetNoiDenServer(TenServer, "master", TenTaiKhoan, MatKhau, IntegratedSecurity);
                            if (XoaCSDL(LayChuoiKetNoi, TenCSDL) == true)
                            {
                                this.Cursor = Cursors.Default;
                                txbThongTinKetNoiCSDL.Clear();
                                txbThongTinKetNoiCSDL.Text = "Đã xóa thành công cơ sở dữ liệu '" + TenCSDL + "' từ SQL Server " + TenServer;
                                btnKiemTra.Enabled = true;
                                btnXoa.Enabled = false;
                                btnTaoMoi.Enabled = false;
                                btnTaoDuLieuMau.Enabled = false;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                txbThongTinKetNoiCSDL.Text = "Có lỗi xảy ra! Không thể xóa cơ sở dữ liệ: " + TenCSDL;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    ThongTinKetNoiCSDL = ex.Message;
                    txbThongTinKetNoiCSDL.Text = "Có lỗi xãy ra: " + ThongTinKetNoiCSDL;
                }
            }
            this.Cursor = Cursors.Default;
        }

        // Sự kiện của textBox #Tạo CSDL mới

        private void txbTaoCSDLMoi_TextChanged(object sender, EventArgs e)
        {
            TenCSDL = txbTaoCSDLMoi.Text;
            
            cbTenCSDL.SelectedIndex = -1;
            btnKiemTra.Enabled = false;
            btnXoa.Enabled = false;
            btnTaoMoi.Enabled = true;
            btnLuu.Enabled = false;
        }
      
        // Sử kiện của button # Tạo mới
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string ChuoiKetNoi = "";
                TenCSDL = txbTaoCSDLMoi.Text;

                if (cbTenCSDL.Items.Contains(TenCSDL) || (KiemTraKyTu(TenCSDL) == false))
                {
                    txbThongTinKetNoiCSDL.Text = "Tên cơ sở dữ liệu không hợp lệ! Xin kiểm tra lại.";
                    this.Cursor = Cursors.Default;
                    return;
                }

                if (cbKieuXacThuc.SelectedIndex == 0)
                    ChuoiKetNoi = ChuoiKetNoiDenServer(TenServer, "master", IntegratedSecurity);
                else
                    ChuoiKetNoi = ChuoiKetNoiDenServer(TenServer, "master", TenTaiKhoan, MatKhau, IntegratedSecurity);

                if (TaoMoiCSDL(ChuoiKetNoi, TenCSDL, @"Script\\TaoMoiCSDL.sql") == true)
                {
                    btnKiemTra.Enabled = false;
                    btnXoa.Enabled = true;
                    btnTaoMoi.Enabled = true;
                    btnTaoDuLieuMau.Enabled = false;
                    KetQuaKetNoiCSDL = true;
                    txbThongTinKetNoiCSDL.Clear();
                    txbThongTinKetNoiCSDL.Text = "Tạo cơ sở dữ liệu '" + TenCSDL + "' thành công";
                    txbTaoCSDLMoi.Clear();
                    btnKetNoi_Click(sender, e);
                    cbTenCSDL.SelectedValue = "" + TenCSDL;
                    this.Cursor = Cursors.Default;
                }
                else 
                {
                    KetQuaKetNoiCSDL = false;
                    this.Cursor = Cursors.Default;
                    txbThongTinKetNoiCSDL.Text = "Lỗi xảy ra! Tạo cơ sở dữ liệu không thành công.";
                    btnTaoDuLieuMau.Enabled = false;
                    XoaCSDL(ChuoiKetNoi, TenCSDL);
                }
            }
            catch(Exception ex)
            {
                ThongTinKetNoiCSDL = ex.Message;
                txbThongTinKetNoiCSDL.Text = "Có lỗi xảy ra: " + ThongTinKetNoiCSDL;
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }

        


        // Sự kiện của button # Tạo dữ liệu mẫu
        private void btnTaoDuLieuMau_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                string ChuoiKetNoi = "";
                if (cbKieuXacThuc.SelectedIndex == 0)
                    ChuoiKetNoi = ChuoiKetNoiDenServer(TenServer, TenCSDL, IntegratedSecurity);
                else
                    ChuoiKetNoi = ChuoiKetNoiDenServer(TenServer, TenCSDL, TenTaiKhoan, MatKhau, IntegratedSecurity);
       
                if (TaoDuLieuMau(ChuoiKetNoi, @"Script\\TaoDuLieuMau.sql") == true)
                {
                    this.Cursor = Cursors.Default;
                    btnKiemTra.Enabled = true;
                    btnXoa.Enabled = true;
                    btnTaoMoi.Enabled = false;
                    btnTaoDuLieuMau.Enabled = true;
                    txbThongTinKetNoiCSDL.Text = "Tạo dữ liệu mẫu cho cơ sở dữ liệu " + TenCSDL + " thành công!";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    btnKiemTra.Enabled = true;
                    btnXoa.Enabled = true;
                    btnTaoMoi.Enabled = false;
                    btnTaoDuLieuMau.Enabled = true;
                    txbThongTinKetNoiCSDL.Text = "Lỗi xảy ra, tạo dữ liệu không thành công!";
                }
            }
            catch(Exception ex)
            {
                this.Cursor = Cursors.Default;
                txbThongTinKetNoiCSDL.Text = "Lỗi: " + ex.Message;
            }
            this.Cursor = Cursors.Default;
        }



        // Sự kiện của button # Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
        
            try
            {
                if(KetQuaKetNoiServer == true)
                {
                    if (IntegratedSecurity == true)
                        ChuoiKetNoiCSDL = ChuoiKetNoiDenServer(TenServer, TenCSDL, IntegratedSecurity);
                    else
                        ChuoiKetNoiCSDL = ChuoiKetNoiDenServer(TenServer, TenCSDL, TenTaiKhoan, MatKhau, IntegratedSecurity);
                }

                if (KetQuaKetNoiCSDL == true)
                {
                    if (IntegratedSecurity == true)
                        ChuoiKetNoiCSDL = ChuoiKetNoiDenServer(TenServer, TenCSDL, IntegratedSecurity);
                    else
                        ChuoiKetNoiCSDL = ChuoiKetNoiDenServer(TenServer, TenCSDL, TenTaiKhoan, MatKhau, IntegratedSecurity);

                    File.WriteAllText(@"Script\\ChuoiKetNoiCSDL.txt", ChuoiKetNoiCSDL);

                    txbThongTinKetNoiCSDL.Text = "Cơ sở dữ liệu hợp lệ! Sẵn sàng làm việc!\nNhấn thoát để bắt đầu chương trình.";
                }
            }
            catch(Exception ex)
            {
                txbThongTinKetNoiCSDL.Text = ex.Message;
            }
            this.Cursor = Cursors.Default;
        }


        // Sự kiện của button # Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region Hàm chức năng khác
        // Lấy danh sách các server có trong máy
        public static List<string> KiemTraServer()
        {
            List<string> instanceNameArr = new List<string>();

            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        instanceNameArr.Add(instanceName);
                    }
                }
            }
            return instanceNameArr;
        }

        public static List<string> LayTatCaTenServer()
        {
            List<string> listServer = KiemTraServer();
            List<string> listTenServer = new List<string>();
            string macineName = Environment.MachineName;
            listTenServer.Add(macineName);
            foreach (string s in listServer)
            {
                listTenServer.Add(macineName + @"\" + s);
            }
            return listTenServer;
        }

        // Kiểm tra kết nối
        public static bool KetNoiDenServer(string connectionString)
        {

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

       
        // Xây dựng cuỗi kết nối
        public static string ChuoiKetNoiDenServer(string server, string db, string UserName, string Password, bool IntegratedSecurity)
        {
            return "Data Source=" + server.Trim() + ";Initial Catalog=" + db.Trim() + ";Integrated Security=" + IntegratedSecurity + ";User ID=" + UserName.Trim() + ";Password=" + Password + ";";
        }

        public static string ChuoiKetNoiDenServer(string server, string db, bool IntegratedSecurity)
        {
            return "Data Source=" + server.Trim() + ";Initial Catalog=" + db.Trim() + ";Integrated Security=" + IntegratedSecurity + ";";
        }

        

        // Lấy danh sách cơ sở dữ liệu có trong máy
        private void DanhSachCSDL()
        {
            cbTenCSDL.Items.Clear();
            
            foreach (Database db in LayTenCSDLCuaServer.Databases)
            {
               
                if (!db.IsSystemObject)
                {
                    cbTenCSDL.Items.Add(db.Name);
                }
            }
            cbTenCSDL.SelectedIndex = -1;
        }

        // Kiểm tra cơ sở dữ liệu có hợp lệ hay không
        private bool KiemTraCSDL(string tenCSDL)
        {
            string data = File.ReadAllText(@"Script\\KiemTraCSDL.sql");
            var dsTables = LayTenCSDLCuaServer.Databases[tenCSDL].ExecuteWithResults(data);
            return dsTables.Tables[0].Rows.Count > 0;
        }

        // Xóa cơ sở dữ liệu
        public static bool XoaCSDL(string ChuoiKetNoi, string db)
        {
            SqlConnection connection = new SqlConnection(ChuoiKetNoi);
            try
            {
                SqlCommand cmd = new SqlCommand("ALTER DATABASE " + db + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE", connection);
                cmd.CommandType = CommandType.Text;

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Drop Database " + db.Trim();

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;

            }
            catch
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return false;
            }
        }

        // Tạo mới cơ sở dữ liệu
        public static bool TaoMoiCSDL(string connectionString, string databaseName, string path)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string strscript = File.ReadAllText(path);
                strscript = strscript.Replace("[QLHS]", "[" + databaseName + "]");
                DateTime dt = DateTime.Now;
                string nam1 = dt.Year.ToString();
                string nam2 = (dt.Year+1).ToString();
                strscript = strscript.Replace("2015", nam1);
                strscript = strscript.Replace("2016", nam2);
                string[] allCmd = strscript.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = connection;
                connection.Open();

                sqlCmd.CommandText = " USE [master]";
                sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = "CREATE DATABASE [" + databaseName + "]";
                sqlCmd.ExecuteNonQuery();
                sqlCmd.CommandText = "USE [" + databaseName + "]";
                sqlCmd.ExecuteNonQuery();
                

                for (int i = 0; i < allCmd.Length; i++)
                {
                    sqlCmd.CommandText = allCmd[i];
                    sqlCmd.ExecuteNonQuery();
                }
                connection.Close();
                return true;

            }
            catch
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return false;
            }
        }

        // Kiểm tra ký tự hợp lệ
        public bool KiemTraKyTu(string s)
        {
            char []temp = s.ToCharArray();
            for (int i = 0; i < temp.Length; i++ )
            {
                if ((temp[i] >= 'a' && temp[i] <= 'z') || (temp[i] >= 'A' && temp[i] <= 'Z') || temp[i] == '\b')
                    return true;
            }
            return false;
        }

        // Tạo dữ liệu mẫu
        public static bool TaoDuLieuMau(string connectionString, string path)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string strscript = File.ReadAllText(path);
                string[] allCmd = strscript.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = connection;

                connection.Open();
                for (int i = 0; i < allCmd.Length; i++)
                {
                    sqlCmd.CommandText = allCmd[i];
                    sqlCmd.ExecuteNonQuery();
                }
                connection.Close();
                return true;

            }
            catch
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return false;
            }

        }

        #endregion                          
    }
}
