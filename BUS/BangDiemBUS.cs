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
    public class BangDiemBUS
    {
        BangDiemDAO bdd = new BangDiemDAO();

        // Lấy về mã bảng điểm, mã quá trình học, điểm trung bình
        public DataTable DanhSachBangDiem(string maNH)
        {
            return bdd.DanhSachBangDiem(maNH);
        }
        // Lấy về mã học sinh, tên học sinh, điểm, mã loại điểm, điểm trung bình
        public DataTable TimBangDiem(string maLop, string maMH, string maHK)
        {
            return bdd.TimBangDiem(maLop, maMH, maHK);
        }
        // Thêm bảng điểm
        public bool ThemBangDiem(string maBD, string maQT, string maMH, float diemTB)
        {
            return bdd.ThemBangDiem(maBD, maQT, maMH, diemTB);
        }
        // Sửa bảng điểm
        public bool SuaDiemTB(string maBD, double diemTB)
        {
            return bdd.SuaDiemTB(maBD, diemTB);
        }

        // Tính điểm trung bình môn học
        public double TinhDiemTrungBinh(double diem15, double diem1T, float heSo15, float heSo1T)
        {
            return Math.Round((double)((diem15 * heSo15 + diem1T * heSo1T) / (heSo15 + heSo1T)), 1);
        }
        
        // Tạo mã bảng điểm
        public string TaoMaBangDiem(string maQTH, string maMH)
        {
            return maQTH + "-" + maMH;
        }
        // Tìm điểm trung bình môn
        public double TimDiemTrungBinhMon(string maMH, string maQTH)
        {
            DataTable dt = bdd.TimDiemTBMon(maMH, maQTH);
            return double.Parse(dt.Rows[0][0].ToString());
        }
        // Xóa bảng điểm
        public bool XoaBangDiem(string maBD)
        {
            return bdd.XoaBangDiem(maBD);
        }
    }
}
