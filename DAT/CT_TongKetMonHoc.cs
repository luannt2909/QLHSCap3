using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAT
{
    class CT_TongKetMonHoc: DBConnection
    {
        public CT_TongKetMonHoc() : base() { }
        // Mã chi tiết, mã tổng kết môn, mã lớp, số lượng đạt, tỉ lệ đạt
        public bool ThemCTBaoCaoMonHoc(string maCT, string maTK, string maLop, int sld, int tld)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("ThemCTBaoCaoMon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@MaCTTongKetMon", maCT);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaTongKetMon", maTK);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@MaLop", maLop);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@SoLuongDat", sld);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@TiLeDat", tld);
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
