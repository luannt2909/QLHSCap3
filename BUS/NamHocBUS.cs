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
    public class NamHocBUS
    {
        NamHocDAO nhd = new NamHocDAO();

        // Thêm năm học
        public bool ThemNamHoc(string maNH, int namBD, int namKT)
        {
            return nhd.ThemNamHoc(maNH, namBD, namKT);
        }

        // Sửa năm học
        public bool SuaNamHoc(string maNH, int namBD, int namKT)
        {
            return nhd.SuaNamHoc(maNH, namBD, namKT);
        }        

        //Lấy danh sách năm học
        public DataTable DanhSachNamHoc()
        {
            return nhd.DanhSachNamhoc();
        }

        // Kiểm tra tồn tại năm học
        public bool NamHocTonTai(int namBD, int namKT)
        {
            DataTable dt = nhd.TimNamHoc(namBD, namKT);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Tìm năm bắt đầu
        public DataTable TimNamBatDau(int namBD)
        {
            return nhd.TimNamBatDau(namBD);
        }
        // Tạo mã năm học
        public string MaNamHoc(string nbd, string nkt)
        {
            return nbd + "-" + nkt;
        }
    }
}
