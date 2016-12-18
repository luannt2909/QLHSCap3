using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    class NamHoc: DBConnection
    {
        public NamHoc() : base() { }
        public bool ThemNamHoc(string maNH, int namBD, int namKT) 
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemNamHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("MaNamHoc", maNH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("NamBatDau", namBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("NamKetThuc", namKT);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public bool SuaNamHoc(string maNH, int namBD, int namKT)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SuaNamhoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaNam", maNH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NamBatDay", namBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NamKetThuc", namKT);
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
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
