using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DAT.ConnectDatabase
{
    public partial class frmDBConnection : Form
    {
        private Server TenServer;
        private ServerConnection KetNoiServer;
        public bool _IsOKClicked = false;

        #region Các sự kiện của Form
        public frmDBConnection()
        {
            InitializeComponent();
        }

        // Sự kiện loan của form
        private void frmDBConnection_Load(object sender, EventArgs e)
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\");
            }
            catch (Exception)
            {
                rk = Registry.LocalMachine.OpenSubKey(@"\SOFTWARE\Microsoft\Microsoft SQL Server\");
            }

            if (rk != null)
            {
                IEnumerable<string> instances = (String[])rk.GetValue("InstalledInstances");
                if (instances != null)
                {
                    foreach (string instance in instances)
                    {
                        cbTenServer.Items.Add(@"localhost\" + instances);
                    }
                }
            }

            if (cbTenServer.Items.Count > 0)
                cbTenServer.SelectedIndex = 0;
        }

        // Sự kiện chọn thay đổi của comboBox #cbTimServer
        private void cbTenServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTenServer.Text = null;
        }

        // Sự kiện click của button #Tìm Server
        private void btnTimServer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tìm kiếm các máy chủ có thể mất nhiều thời gian."
                                + "\nBạn có thể gõ Tên máy chủ hoặc IP của máy chủ."
                                + "\nBạn có chắc chắn muốn tìm các máy chủ hoạt động trong mạng LAN?",
                                "Network finding...",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                TimSQLServer();
            }
        }
        
        
        // Sự kiện lick của radio button #Sử dụng chứng thực Windows
        private void rdbChungThucWindows_CheckedChanged(object sender, EventArgs e)
        {
            txbTenTaiKhoan.Enabled = false;
            txbMatKhau.Enabled = false;
        }

        // Sự kiện lick của radio button #Sử dụng chứng thực Server
        private void rdbChungthucServer_CheckedChanged(object sender, EventArgs e)
        {
            txbTenTaiKhoan.Enabled = true;
            txbMatKhau.Enabled = true;
        }

        // Sự kiện click của button #Kết nối
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbTenServer.Text))
            {
                this.Cursor = Cursors.WaitCursor;
                string message = ConnectDatabase();
                this.Cursor = Cursors.Default;

                if (string.IsNullOrEmpty(message))
                {
                    cbTenCSDL.Enabled = true;
                    btnTaoMoi.Enabled = true;
                    txbTenCSDLMoi.Enabled = true;
                }
                else
                {
                    MessageBox.Show(message, "SQL Authetication", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                // Hiển thị lỗi không chọn Server
                MessageBox.Show("Bạn hãy chọn hoặc gõ Tên máy chủ để thực hiện!", "Server not selected",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        // Sự kiện của comboBox #cbTenCSDL
        private void cbTenCSDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTaoDuLieuMau.Enabled = false;
        }

        // Sự kiện của button #Tạo mới
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!String.IsNullOrEmpty(txbTenCSDLMoi.Text))
            //    {
            //        if (cbTenCSDL.Items.Contains(txbTenCSDLMoi.Text))
            //        {
            //            MessageBox.Show("Database đã tồn tại");
            //            return;
            //        }
            //        else
            //        {
            //            this.Cursor = Cursors.WaitCursor;
            //            string data = Properties.Resources.CreateDatabase;
            //            string data2 = Properties.Resources.StroredProcedures;
            //            string dbName = txbTenCSDLMoi.Text;
            //            var newDB = new Database(TenServer, dbName);
            //            newDB.Create();
            //            DanhSachCSDL();

            //            data = data.Replace("[PlaceHolder]", dbName);
            //            data2 = data2.Replace("[PlaceHolder]", dbName);
            //            TenServer.ConnectionContext.ExecuteNonQuery(data);
            //            TenServer.ConnectionContext.ExecuteNonQuery(data2);
            //            cbTenCSDL.SelectedItem = cbTenCSDL.Items[cbTenCSDL.Items.IndexOf(dbName)];
            //            btnTaoDuLieuMau.Enabled = true;

            //            MessageBox.Show("Đã tạo database thành công", "Success");
            //            this.Cursor = Cursors.Default;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui lòng nhập tên database");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Đã có lỗi xảy ra" + ex.Message, "Error");
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        // Sự kiện lick của button #Tạo dữ liệu mẫu
        private void btnTaoDuLieuMau_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    string data = Properties.Resources.InitData;


            //    data = data.Replace("[PlaceHolder]", txbTenCSDLMoi.Text);

            //    TenServer.Databases[txbTenCSDLMoi.Text].ExecuteNonQuery(data);
            //    MessageBox.Show("Đã tạo dữ liệu mẫu thành công", "Success");
            //    btnTaoDuLieuMau.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Đã có lỗi xảy ra" + ex.Message, "Error");
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        // Sự kiện lick của button #OK
        private void btnOK_Click(object sender, EventArgs e)
        {
        //    if (CheckDatabase(cbTenCSDL.Text))
        //    {
        //        Settings.Default.Server = cbTenServer.Text;
        //        Settings.Default.SQLAuthenticationMode = rdbChungThucServer.Checked;
        //        Settings.Default.DatabaseName = cbTenCSDL.SelectedItem.ToString();
        //        if (rdbChungThucServer.Checked)
        //        {
        //            Settings.Default.UserName = txbTenTaiKhoan.Text;
        //            Settings.Default.Password = txbMatKhau.Text;
        //            Settings.Default.SavePassword = true;
        //        }
        //        else
        //        {
        //            Settings.Default.UserName = string.Empty;
        //            Settings.Default.Password = string.Empty;
        //            Settings.Default.SavePassword = false;
        //        }

        //        Settings.Default.ConnectString = TaoChuoiKetNoi();
        //        Settings.Default.Save();

        //        DialogResult = DialogResult.OK;
        //        _IsOKClicked = true;
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cơ sở dữ liệu đang chọn không đúng chuẩn!" + "\nVui lòng chọn đúng cơ sở dữ liệu hoặc tạo cơ sở dữ liệu mới");
        //    }
        }

        // Sự kiện lick của button #Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Các hàm chức năng
        // Tìm kiếm SQL Server
        private void TimSQLServer()
        {
            this.Cursor = Cursors.WaitCursor;
            cbTenServer.Items.Clear();

            DataTable table = SmoApplication.EnumAvailableSqlServers(false);

            foreach (DataRow item in table.Rows)
            {
                cbTenServer.Items.Add(item["Name"]);
            }
            if (cbTenServer.Items.Count > 0)
                cbTenServer.SelectedIndex = 0;

            this.Cursor = Cursors.Default;
        }

        // Danh sách cơ sở dữ liệu
        private void DanhSachCSDL()
        {
            cbTenCSDL.Items.Clear();
            // Kiểm tra xem cơ sở dữ liệu có tồn tại trong hệ thống hay không
            foreach (Database db in TenServer.Databases)
                if (!db.IsSystemObject)
                    cbTenCSDL.Items.Add(db.Name);

            if (cbTenCSDL.Items.Count > 0)
                cbTenCSDL.SelectedIndex = 0;
        }

        // Kết nối đến cơ sở dữ liệu được chọn
        private string ConnectDatabase()
        {
            if (!string.IsNullOrEmpty(cbTenServer.Text))
            {
                try
                {
                    KetNoiServer = new ServerConnection(cbTenServer.Text);
                    //Kiểm tra loại chứng thực được sử dụng
                    if (rdbChungThucWindows.Checked)
                    {
                        KetNoiServer.LoginSecure = true;
                        TenServer = new Server(KetNoiServer);
                    }
                    else
                    {
                        // Tạo kết nối mới đến cơ sở dữ liệu đã chọn
                        KetNoiServer.LoginSecure = false;
                        KetNoiServer.Login = txbTenTaiKhoan.Text;
                        KetNoiServer.Password = txbMatKhau.Text;
                        // Tạo 1 đối tượng SQL Server mới
                        TenServer = new Server(KetNoiServer);
                    }
                    DanhSachCSDL();
                    return String.Empty;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "Không có server nào được chọn";
        }

        // Check if enought table in database
        //private bool CheckDatabase(string dbname)
        //{
        //    string data = Properties.Resources.CheckTable;
        //    var dsTables = TenServer.Databases[dbname].ExecuteWithResults(data);
        //    return dsTables.Tables[0].Rows.Count > 0;
        //}

        // Tạo chuỗi kết nối
        //private string TaoChuoiKetNoi()
        //{
        //    string ChuoiKetNoi;
        //    if (!Settings.Default.SQLAuthenticationMode)
        //    {
        //        ChuoiKetNoi = @"Server=" + Settings.Default.Server + ";Database=" + Settings.Default.DatabaseName +
        //                     ";Trusted_Connection=True;";
        //    }
        //    else
        //    {
        //        ChuoiKetNoi = @"Server=" + Settings.Default.Server + ";Database=" + Settings.Default.DatabaseName +
        //                     ";Integrated Security=SSPI;User ID=" + Settings.Default.UserName + ";Password=" +
        //                     Settings.Default.Password + ";";
        //    }
        //    return ChuoiKetNoi;
        //}
        #endregion

        

        

        

        

        


        

       

        

        

        

        

        

        

        
    }
}
