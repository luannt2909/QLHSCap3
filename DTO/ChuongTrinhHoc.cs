using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuongTrinhHoc
    {
        public string MaKhoiLop { get; set; }
        public string MaMonHoc { get; set; }
        public float HeSo { get; set; }
        public ChuongTrinhHoc() { }
        public ChuongTrinhHoc(string maKL, string maMH, float hs)
        {
            MaKhoiLop = maKL;
            MaMonHoc = maMH;
            HeSo = hs;
        }
    }
}
