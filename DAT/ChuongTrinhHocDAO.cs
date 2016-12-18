using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class ChuongTrinhHocDAO: DBConnection
    {
        public ChuongTrinhHocDAO() : base() { }
        public bool ThemChuongTrinhHoc(string maKL, string maMH, float hs)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemChuongTrinhHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaMonHoc", maMH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaKhoiLop", maKL);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@HeSo", hs);
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
        public bool SuaChuongTrinhHoc(string maKL, string maMH, float hs)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SuaChuongTrinhHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaMonHoc", maMH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaKhoiLop", maKL);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@HeSo", hs);
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
        public bool XoaChuongTrinhHoc(string maKL, string maMH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("XoaChuongTrinhHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaMonHoc", maMH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaKhoiLop", maKL);
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
        // Trả về mã môn học, tên môn học, hệ số
        public DataTable TimChuongTrinhHoc(string maKL)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimChuongTrinhHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaKhoiLop", maKL);
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
        // Trả về mã môn học, tên môn học
        public DataTable TimChuongTrinhHocChuaCo(string maNH, string maKL)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimChuongTrinhHocChuaCo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaKhoiLop", maKL);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NamHoc", maNH);
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
        // Trả về hệ số môn
        public DataTable HeSoMonHoc(string maLop, string maMH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("HeSoMonHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaMonHoc", maMH);
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
