using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TongKetMonHoc
    {
        public string MaTongKetMonHoc { get; set; }
        public string MaMonHoc { get; set; }
        public string MaHocKy { get; set; }
        public TongKetMonHoc() { }
        public TongKetMonHoc(string maTKMH, string maMH, string maHK)
        {
            MaTongKetMonHoc = maTKMH;
            MaMonHoc = maMH;
            MaHocKy = maHK;
        }
    }
}
