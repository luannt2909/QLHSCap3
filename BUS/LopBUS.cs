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
    public class LopBUS
    {
        LopDAO ld = new LopDAO();
        
        // Lấy danh sách
        public DataTable DanhSachLop(string maNam)
        {
            return ld.DanhSachLop(maNam);
        }

        // Sửa sỉ số
        public bool TangSiSo(string maLop)
        {
            return ld.TangSiSo(maLop);
        }

        // Thêm lớp
        public bool ThemLop(string maLop, string tenLop, string maKL)
        {
            return ld.ThemLop(maLop, tenLop, maKL);
        }

        // Sửa lớp
        public bool SuaLop(string maLop, string maLopMoi, string tenLop, string maKL)
        {
            return ld.SuaLop(maLop, maLopMoi, tenLop, maKL);
        }

        // Tìm lớp
        public DataTable TimLop(string maLop)
        {
            return ld.TimLop(maLop);
        }

        // Danh sách lớp theo khối lớp
        public DataTable DanhSachLopTheoKhoiLop(string maKL)
        {
            return ld.DanhSachLopTheoKhoiLop(maKL);
        }

        // Xóa lớp
        public bool XoaLop(string maLop)
        {
            return ld.XoaLop(maLop);
        }

        // Tạo mã lớp
        public static string MaLop(string tenLop, string maNam)
        {
            return tenLop + maNam.Substring(0,4);
        }        

        // Tìm lớp theo môn học
        public DataTable TimLopTheoMon(string maMH)
        {
            return ld.TimLopTheoMon(maMH);
        }
    }
}
