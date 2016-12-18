using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class HocKyDAO: DBConnection
    {
        public HocKyDAO() : base() { }
        public bool ThemHocKy(string maHK, string tenHK, string maNH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemHocKy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaHocKy", maHK);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TenHocKy", tenHK);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaNam", maNH);
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
        // Trả về mã học kỳ, tên học kỳ
        public DataTable TimHocKy(string maNH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimHocKy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaNam", maNH);
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
    }
}
