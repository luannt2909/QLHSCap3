using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lop
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaKhoiLop { get; set; }
        public int SiSo { get; set; }
        public Lop() { }
        public Lop(string maLop, string tenLop, string maKhoiLop)
        {
            MaLop = maLop;
            TenLop = tenLop;
            MaKhoiLop = maKhoiLop;
            SiSo = 0;
        }
    }
}
