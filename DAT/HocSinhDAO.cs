using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAT
{
    public class HocSinhDAO: DBConnection
    {
        public HocSinhDAO() : base(){}
        public bool ThemHocSinh(string maHS, string tenHS, string gioiTinh, DateTime ngaySinh, string diaChi, string email)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemHS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaHS", maHS);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TenHS", tenHS);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@GioiTinh", gioiTinh);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NgaySinh", ngaySinh);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@DiaChi", diaChi);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@Email", email);
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;                
            }
            catch(Exception)
            {
                con.Close();
                return false;
            }
        }

        // Trả về tên, lớp, điểm tb học kỳ, tên học kỳ
        public DataTable DanhSachHocSinh(string namHoc)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachHS", con);
                SqlParameter p = new SqlParameter("@NamHoc", namHoc);
                cmd.CommandType = CommandType.StoredProcedure;
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
            }
            return null;
        }
        public bool XoaHocSinh(string maHS)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("XoaHS", con);
                SqlParameter p = new SqlParameter("@MaHS", maHS);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception)
            {
                con.Close();
            }
            return false;
        }
        public bool SuaHocSinh(string maHS, string tenHS, string gioiTinh, DateTime ngaySinh, string diaChi, string email)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SuaHS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaHS", maHS);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TenHS", tenHS);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@GioiTinh", gioiTinh);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@NgaySinh", ngaySinh);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@DiaChi", diaChi);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@Email", email);
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
                
            }
            catch(Exception)
            {
                con.Close();
                throw;
            }
        }
        // Trả về tên học sinh, giới tính, ngày sinh, địa chỉ
        public DataTable DanhSachHocSinhTheoLop(string maLop)
        {
            try 
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachHSTheoLop", con);
                SqlParameter p = new SqlParameter("@MaLop", maLop);
                cmd.CommandType = CommandType.StoredProcedure;
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
        // Trả về mã học sinh
        public DataTable MaHocSinhTheoLop(string maLop)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("MaHSTheoLop", con);
                SqlParameter p = new SqlParameter("@MaLop", maLop);
                cmd.CommandType = CommandType.StoredProcedure;
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
        // Trả về mã học sinh, tên học sinh
        public DataTable DanhSachHocSinhDaChuyen(string maLop)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachHocSinhDaChuyen", con);
                SqlParameter p = new SqlParameter("@MaLop", maLop);
                cmd.CommandType = CommandType.StoredProcedure;
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
        // Trả về tên học sinh, mã học sinh
        public DataTable DanhSachHocSinhChuyenLop(string maLop1, string maLop2)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachHocSinhChuyenLop", con);
                SqlParameter p = new SqlParameter("@MaLop1", maLop1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLop2", maLop2);
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
        // Trả về mã học sinh, tên học sinh, giới tính, ngày sinh, địa chỉ, email
        public DataTable HoSoHocSinhTheoLop(string maLop)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("HoSoHSTheoLop", con);
                SqlParameter p = new SqlParameter("@MaLop", maLop);
                cmd.CommandType = CommandType.StoredProcedure;
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
        // Trả về số lượng học sinh
        public DataTable TimSoHocSinh(string maNH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimSoHocSinh", con);
                SqlParameter p = new SqlParameter("@NamHoc", maNH);
                cmd.CommandType = CommandType.StoredProcedure;
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
