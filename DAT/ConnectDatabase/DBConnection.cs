using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace DAT
{
    public class DBConnection
    {
        protected SqlConnection con;
        // Thiết lập kết nối
        public string LuuChuoiKetNoiCSDL = File.ReadAllText(@"Script\\ChuoiKetNoiCSDL.txt");
        public DBConnection()
        {
            try
            {
                con = new SqlConnection(@"" + LuuChuoiKetNoiCSDL + "");
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}
