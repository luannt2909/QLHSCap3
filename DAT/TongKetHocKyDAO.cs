using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class TongKetHocKyDAO: DBConnection
    {
        public TongKetHocKyDAO() : base() { }
        //mã tổng kết hk, mã lớp, mã học kỳ, số lượng đạt, tỉ lệ đạt
        public bool ThemBaoCaoHocKy(string maBCHK, string maLop, string maHK, int sld, float tld)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemBaoCaoHocKy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaTongKetHocKy", maBCHK);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaHocKy", maHK);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@SoLuongDat", sld);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TiLeDat", tld);
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        
        // Trả về tên lớp, sỉ số, số lượng đạt, tỉ lệ đạt
        public DataTable TimBaoCaoHocKy(string maHK)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimBaoCaoHocKy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@HocKy", maHK);
                cmd.Parameters.Add(p);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public bool XoaBaoCaoHocKy(string maHK)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("XoaBaoCaoHocKy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaHocKy", maHK);
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
    }
}
