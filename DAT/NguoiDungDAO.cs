using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAT
{
    public class NguoiDungDAO: DBConnection
    {
        public NguoiDungDAO() : base() { }
        // Trả về tên đăng nhập, loại người dùng
        public DataTable TimNguoiDung(string tenDN, string matKhau)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimNguoiDung", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDangNhap", tenDN);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MatKhau", matKhau);
                cmd.Parameters.Add(p);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch(Exception)
            {
                con.Close();
                throw;
            }
        }
        public bool ThemNguoiDung(string tenDN, string matKhau, string loaiND)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemNguoiDung", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDangNhap", tenDN);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MatKhau", matKhau);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@LoaiNguoiDung", loaiND);
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
        public bool XoaNguoiDung(string tenDN)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("XoaNguoiDung", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDangNhap", tenDN);
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
        // Trả về tên đăng nhập 
        public DataTable KiemTraNguoiDung(string tenDN)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("KiemTraNguoiDung", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@TenDangNhap", tenDN);
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
        // Trả về tên đăng nhập, loại người dùng
        public DataTable DanhSachNguoiDung()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachNguoiDung", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
