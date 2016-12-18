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
    public class TongKetMonHocBUS
    {
        TongKetMonHocDAO tkmhd = new TongKetMonHocDAO();

        // Tạo báo cáo
        public bool ThemBaoCaoMonHoc(string maTKMH, string maMH, string maHK)
        {
            return tkmhd.ThemBaoCaoMonHoc(maTKMH, maMH, maHK);
        }

       
        public bool XoaBaoCaoMon(string maNH)
        {
            return tkmhd.XoaBaoCaoMon(maNH);
        }

        // Tìm báo cáo môn
        public DataTable TimBaoCaoMonHoc(string maMH, string maHK)
        {
            return tkmhd.TimBaoCaoMonHoc(maMH, maHK);
        }

        // Mã tổng kết môn học
        public string MaTongKetMonHoc(string maMH, string maHK)
        {
            return maMH + maHK;
        }

        // Danh sách tổng kết môn học theo học kỳ
        public  DataTable DanhSachBaoCaoMonHoc(string maHK)
        {
            return tkmhd.DanhSachBaoCaoMonHoc(maHK);
        }
    }
}
