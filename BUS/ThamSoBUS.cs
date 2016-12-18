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
    public class ThamSoBUS
    {
        ThamSoDAO tsd = new ThamSoDAO();

        // Thay đổi tham số
        public bool ThayDoiThamSo(string tenTS, float gtTS)
        {
            return tsd.ThayDoiThamSo(tenTS, gtTS);
        }

        // trả về giá trị tham số
        public DataTable TimGiaTriThamSo(string tenTS)
        {
            return tsd.TimGiaTriThamSo(tenTS);
        }

        // Toàn bộ tham số
        public DataTable DanhSachThamSo()
        {
            return tsd.DanhSachThamSo();
        }
    }
}
