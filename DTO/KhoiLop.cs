using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoiLop
    {
        public string MaKhoiLop { get; set; }
        public string TenKhoiLop { get; set; }
        public string MaNamHoc { get; set; }
        public int SoLop { get; set; }
        public KhoiLop() { }
        public KhoiLop(string maKL, string tenKL, string maNH, int soLop)
        {
            MaKhoiLop = maKL;
            TenKhoiLop = tenKL;
            MaNamHoc = maNH;
            SoLop = soLop;
        }
    }
}
