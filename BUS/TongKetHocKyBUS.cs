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
    public class TongKetHocKyBUS
    {
        TongKetHocKyDAO tkhkd = new TongKetHocKyDAO();

        // Tạo báo cáo 
        public bool ThemBaoCaoHocKy(string maBCHK, string maLop, string maHK, int sld, float tld)
        {
            return tkhkd.ThemBaoCaoHocKy(maBCHK, maLop, maHK, sld, tld);
        }


        // Tìm báo cáo
        public DataTable TimBaoCaoHocKy(string maHK)
        {
            return tkhkd.TimBaoCaoHocKy(maHK);
        }

        // Xóa các báo cáo
        public bool XoaBaoCaoHocKy(string maHK)
        {
            return tkhkd.XoaBaoCaoHocKy(maHK);
        }
        // Tạo mã báo cáo học kỳ
        public string MaTongKetHocKy(string maLop, string maHK)
        {
            return maLop + maHK;
        }
    }
}
