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
    public class CT_BangDiemBUS
    {
        CT_BangDiemDAO ctbd = new CT_BangDiemDAO();

        // Thêm chi tiết bảng điểm
        public bool ThemCTBangDiem(string maBD, string maLD, float diem)
        {
            return ctbd.ThemCTBangDiem(maBD, maLD, diem);
        }
        // Sửa chi tiết bảng điểm
        public bool SuaCTBangDiem(string maBD, string maLD, double diem)
        {
            return ctbd.SuaCTBangDiem(maBD, maLD, diem);
        }
    }
}
