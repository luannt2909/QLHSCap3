using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    public class CT_TongKetMonHocDAO: DBConnection
    {
        public CT_TongKetMonHocDAO() : base() { }
        // Mã chi tiết, mã tổng kết môn, mã lớp, số lượng đạt, tỉ lệ đạt
        public bool ThemCTBaoCaoMonHoc(string maCT, string maTK, string maLop, int sld, double tld)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemCTBaoCaoMonHoc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaCTTongKetMonHoc", maCT);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaTongKetMonHoc", maTK);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@SoLuongDat", sld);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TiLeDat", tld);
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
