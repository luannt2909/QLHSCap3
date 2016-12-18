using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class CT_BangDiemDAO: DBConnection
    {
        public CT_BangDiemDAO() : base() { }
        public bool ThemCTBangDiem(string maBD, string maLD, float diem)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemCTBangDiem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaBangDiem", maBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLoaiDiem", maLD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@Diem", diem);
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
        public bool SuaCTBangDiem(string maBD, string maLD, double diem)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SuaCTBangDiem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaBangDiem", maBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLoaiDiem", maLD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@Diem", diem);
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
