using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_TongKetMonHoc
    {
        public string MaTongKetMonHoc { get; set; }
        public string MaLop { get; set; }
        public int SoLuongDat { get; set; }
        public float TiLeDat { get; set; }
        public CT_TongKetMonHoc() { }
        public CT_TongKetMonHoc(string maTKMH, string maLop, int soLuong, float tiLe)
        {
            MaTongKetMonHoc = maTKMH;
            MaLop = maLop;
            SoLuongDat = soLuong;
            TiLeDat = tiLe;
        }
    }
}
