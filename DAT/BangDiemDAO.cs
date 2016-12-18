using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class BangDiemDAO: DBConnection
    {
        public BangDiemDAO() : base() { }
        // Trả về mã bảng điểm, mã quá trình học, điểm trung bình
        public DataTable DanhSachBangDiem(string maNH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachBangDiem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaNamHoc", maNH);
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
        // Trả về mã học sinh, tên học sinh, điểm, mã loại điểm, điểm trung bình
        public DataTable TimBangDiem(string maLop, string maMH, string maHK)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimBangDiem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaMon", maMH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaHocKy", maHK);
                cmd.Parameters.Add(p);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Close();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public bool ThemBangDiem(string maBD, string maQT, string maMH, float diemTB)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemBangDiem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaBangDiem", maBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaQuaTrinh", maQT);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaMonHoc", maMH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@DiemTB", diemTB);
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
        public bool SuaDiemTB(string maBD, double diemTB)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SuaDiemTB", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaBangDiem", maBD);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@diemTB", diemTB);
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
        public bool XoaBangDiem(string maBD)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("XoaBangDiem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaBangDiem", maBD);                
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
        // Trả về điểm trung bình
        public DataTable TimDiemTBMon(string maMH, string maQTH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimDiemTBMon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaMonHoc", maMH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaQuaTrinh", maQTH);
                cmd.Parameters.Add(p);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Close();
                da.Fill(dt);
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
