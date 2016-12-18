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
    public class MonHocBUS
    {
        static MonHocDAO mhd = new MonHocDAO();

        // Thêm môn học
        public bool ThemMonHoc(string maMH, string tenMH, string maNH)
        {
            return mhd.ThemMonHoc(maMH, tenMH, maNH);
        }

        // Xóa môn học
        public bool XoaMonHoc(string maMH)
        {
            return mhd.XoaMonHoc(maMH);
        }

        // Sửa tên môn học
        public bool SuaMonHoc(string maMH, string maMHmoi, string tenMH)
        {
            return mhd.SuaMonHoc(maMH, maMHmoi, tenMH);
        }
        // Danh sách môn học
        public DataTable DanhSachMonHoc(string maNam)
        {
            return mhd.DanhSachMonHoc(maNam);
        }
        // Danh sách môn học theo lớp
        public DataTable DanhSachMonHocTheoLop(string maLop)
        {
            return mhd.DanhSachMonHocTheoLop(maLop);
        }
        public DataTable DanhSachMonHocTheoKhoiLop(string maKL)
        {
            return mhd.DanhSachMonHocTheoKhoiLop(maKL);
        }
        // Kiểm tra môn học đã tồn tại
        public bool MonHocTonTai(string maMH)
        {
            DataTable dt = mhd.TimMonHoc(maMH);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Kiểm tra tồn tại môn học trong chương trình học
        public static bool MonTonTaiTrongChuongTrinhHoc(string maMH)
        {
            DataTable dt = mhd.TimMonHocTrongChuongTrinhHoc(maMH);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
