using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class QuaTrinhHocDAO: DBConnection
    {
        public QuaTrinhHocDAO() : base() { }
        public bool ThemQuaTrinhHoc(string maQTH, string maHS, string maLop, string maHK, double diemTBHK)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemQuaTrinhHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaQuaTrinhHoc", maQTH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaHS", maHS);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaHocKy", maHK);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@DiemTBHK", diemTBHK);
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
        // Trả về điểm trung bình học kỳ
        public DataTable TimDiemTBHocKy(string maQTH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TimDiemTBHocKy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaQuaTrinh", maQTH);
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
        // Trả về điểm tbhk của các học sinh trong lớp
        public DataTable DanhSachDiemTBHK(string maLop, string maHK)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DanhSachDiemTBHK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaHocKy", maHK);
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
        public bool SuaDiemTBHK(string maQTH, double diemTBHK)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SuaDiemTBHK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaQTH", maQTH);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@DiemTBHK", diemTBHK);
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
        public bool SuaLopQuaTrinh(string maHS, string maLop, string maLopMoi)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SuaLopQuaTrinh", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaHS", maHS);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLopMoi", maLopMoi);
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
        public bool XoaQuaTrinh(string maQTH)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("XoaQuaTrinhHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaQuaTrinh", maQTH);
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
