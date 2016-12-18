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
        public static SqlConnection KetNoi()
        {
            string sChuoiKetNoi = @"Data source=(local); Initial Catalog=QLHS;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            conn.Open();
            return conn;
        }

        // Đóng kết nối
        public static void DongKetnoi(SqlConnection conn)
        {
            conn.Close();
        }

        // Hàm lấy Datatable cho câu lệnh Select
        public static DataTable LayDatatable(string sTruyVan, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Hàm truy vân không trả về kết quả
        public static bool ThucThiTruyVanKhongTraKetQua(string sTruyVan, SqlConnection conn)
        {
            try
            {
                SqlCommand com = new SqlCommand(sTruyVan, conn);
                com.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        ////public DBConnection()
        ////{
        ////    try
        ////    {
        ////        con = new SqlConnection(@"Data Source=(local);Initial Catalog=QLHS;Integrated Security=True");
        ////    }
        ////    catch (Exception)
        ////    {
        ////        throw;
        ////    }
        ////}
    }
}
