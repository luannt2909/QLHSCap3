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
    public class HocSinhBUS
    {
        static HocSinhDAO hsd = new HocSinhDAO();

        // Thêm học sinh
        public bool ThemHocSinh(string maHS, string tenHS, string gioiTinh, DateTime ngaySinh, string diaChi, string email)
        {
            return hsd.ThemHocSinh(maHS, tenHS, gioiTinh, ngaySinh, diaChi, email);
        }
        // Lấy tên, lớp, điểm tb học kỳ, tên học kỳ
         public DataTable DanhSachHocSinh(string namHoc)
        {
            return hsd.DanhSachHocSinh(namHoc);
        }
        // Xóa học sinh
        public bool XoaHocSinh(string maHS)
        {
            return hsd.XoaHocSinh(maHS);
        }
        // Sửa thông tin học sinh
        public bool SuaHocSinh(string maHS, string tenHS, string gioiTinh, DateTime ngaySinh, string diaChi, string email)
        {
            return hsd.SuaHocSinh(maHS, tenHS, gioiTinh, ngaySinh, diaChi, email);
        }
        // Lấy tên học sinh, giới tính, ngày sinh, địa chỉ
        public DataTable DanhSachHocSinhTheoLop(string maLop)
        {
            return hsd.DanhSachHocSinhTheoLop(maLop);
        }
        // Danh sách học sinh theo lớp
        public DataTable HoSoHocSinhTheoLop(string maLop)
        {
            return hsd.HoSoHocSinhTheoLop(maLop);
        }
        // Danh sách mã học sinh theo lớp
        public DataTable MaHocSinhTheoLop(string maLop)
        {
            return hsd.MaHocSinhTheoLop(maLop);
        }
        // Danh sách học sinh có thể chuyển lớp
        public DataTable DanhSachHocSinhChuyenLop(string maLop1, string maLop2)
        {
            return hsd.DanhSachHocSinhChuyenLop(maLop1, maLop2);
        }
        // Danh sách học sinh đã có trong lớp
        public DataTable DanhSachHocSinhDaChuyen(string maLop)
        {
            return hsd.DanhSachHocSinhDaChuyen(maLop);
        }
        // Tạo mã học sinh
        public string taoMaHocSinh(int soHocSinh, string nam)
        {
            string maHS = nam.Substring(2);
            for (int i = soHocSinh.ToString().Length; i <= 5; i++)
            {
                maHS += "0";
            }
            maHS += (soHocSinh + 1).ToString();
            return maHS;
        }
        public DataTable TimSoHocSinh(string maNH)
        {
            return hsd.TimSoHocSinh(maNH);
        }
        public static string MaHocSinh(string maNH)
        {
            DataTable dt = hsd.TimSoHocSinh(maNH);
            string soHocSinh = ((int.Parse(dt.Rows[0][0].ToString()) + 1)/2).ToString();
            for (int i = soHocSinh.Length; i < 5; i++)
            {
                soHocSinh = "0" + soHocSinh;
            }
            return maNH.Substring(2, 2) + soHocSinh;
        }
    }
}
