using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAT;
using DTO;

namespace BUS
{
    public class CT_TongKetMonHocBUS
    {
        CT_TongKetMonHocDAO ctmh = new CT_TongKetMonHocDAO();

        // Lấy mã chi tiết, mã tổng kết môn, mã lớp, số lượng đạt, tỉ lệ đạt
        public bool ThemCTBaoCaoMonHoc(string maCT, string maTK, string maLop, int sld, double tld)
        {
            return ctmh.ThemCTBaoCaoMonHoc(maCT, maTK, maLop, sld, tld);
        }
        // tạo mã chi tiết tổng kết môn học
        public string MaCTBaoCaoMonHoc(string maTK, string maLop)
        {
            return maTK + maLop;
        }
    }
}
