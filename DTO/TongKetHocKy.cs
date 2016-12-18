using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TongKetHocKy
    {
        public string MaTongKetHocKy { get; set; }
        public string MaHocKy { get; set; }
        public string MaLop { get; set; }
        public int SoLuongDat { get; set; }
        public float TiLeDat { get; set; }
        public TongKetHocKy() { }
        public TongKetHocKy(string maTKHK, string maHK, string maLop, int soLuong, float tiLe)
        {
            MaTongKetHocKy = maTKHK;
            MaHocKy = maHK;
            MaLop = maLop;
            SoLuongDat = soLuong;
            TiLeDat = tiLe;
        }
    }
}
