using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAT;
using DTO;

namespace BUS
{
    public class HocKyBUS
    {
        HocKyDAO hkd = new HocKyDAO();

        // Thêm học kỳ
        public bool ThemHocKy(string maHK, string tenHK, string maNH)
        {
            return hkd.ThemHocKy(maHK, tenHK, maNH);
        }

        // Tìm học kỳ
        public DataTable TimHocKy(string maNH)
        {
            return hkd.TimHocKy(maNH);
        }

        public List<string> MaHocKy(string maNam)
        {
            string hk1 = maNam.Substring(2, 2) + "-" + maNam.Substring(7, 2) + "-1";
            string hk2 = maNam.Substring(2, 2) + "-" + maNam.Substring(7, 2) + "-2";
            return new List<string> { hk1, hk2 };
        }
    }
}
