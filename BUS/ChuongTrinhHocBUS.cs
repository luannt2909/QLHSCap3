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
    public class ChuongTrinhHocBUS
    {
        ChuongTrinhHocDAO cth = new ChuongTrinhHocDAO();

        // Tạo chương trình học
        public bool ThemChuongTrinhHoc(string maKL, string maMH, float hs)
        {
            return cth.ThemChuongTrinhHoc(maKL, maMH, hs);
        }
        // Sửa chương trình học
        public bool SuaChuongTrinhHoc(string maKL, string maMH, float hs)
        {
            return cth.SuaChuongTrinhHoc(maKL, maMH, hs);
        }
        // Tìm chương trình học
        public DataTable TimChuongTrinhHoc(string maKL)
        {
            return cth.TimChuongTrinhHoc(maKL);
        }
        // Tìm môn học chưa có trong chương trình
        public DataTable TimChuongTrinhHocChuaCo(string maNH, string maKL)
        {
            return cth.TimChuongTrinhHocChuaCo(maNH, maKL);
        }
        // Xóa chương trình học
        public bool XoaChuongTrinhHoc(string maKL, string maMH)
        {
            return cth.XoaChuongTrinhHoc(maKL, maMH);
        }
        // Tìm hệ số môn học
        public float HeSoMonHoc(string maLop, string maMH)
        {
            DataTable dt = cth.HeSoMonHoc(maLop, maMH);
            return float.Parse(dt.Rows[0][0].ToString());
        }
    }
}
