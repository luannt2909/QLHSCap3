using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class KhoiLopDAO: DBConnection
    {
        public KhoiLopDAO() : base() { }
        public bool ThemKhoiLop(string maKL, string tenKL, string maNH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemKhoiLop", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaKhoiLop", maKL);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TenKhoiLop", tenKL);
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
        // Trả về mã khối lớp, tên khối lớp, số lớp
        public DataTable TimKhoiLop(string maNH)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimKhoiLop", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@NamHoc", maNH);
                cmd.Parameters.Add(p);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch(Exception)
            {
                con.Close();
                throw;
            }
        }
        // Trả về mã khối lớp, tên khối lớp, mã năm học, số lớp
        public DataTable ChonKhoiLop(string maKL)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ChonKhoiLop", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaKhoiLop", maKL);
                cmd.Parameters.Add(p);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public bool ThayDoiKhoiLop(string maKL, string maKLM, string tenKL)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThayDoiKhoiLop", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaKhoiLop", maKL);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaKhoiLopMoi", maKLM);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TenKhoiLop", tenKL);
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
        public bool XoaKhoiLop(string maKL)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("XoaKhoiLop", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaKhoiLop", maKL);
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
