using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class NamHocDAO: DBConnection
    {
        public NamHocDAO() : base() { }
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
                SqlParameter p = new SqlParameter("@MaNam", maNH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NamBatDau", namBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NamKetThuc", namKT);
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
                con.Close();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        // Trả về mã năm
        public DataTable DanhSachNamhoc()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachNamHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }
        // Trả về mã năm
        public DataTable TimNamHoc(int namBD, int namKT)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimNamHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamBatDau", namBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NamKetThuc", namKT);
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
        // Trả về năm bắt đầu
        public DataTable TimNamBatDau(int namBD)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimNamBatDau", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamBatDau", namBD);
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
