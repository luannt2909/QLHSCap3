using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangDiem
    {
        public string MaBangDiem { get; set; }
        public string MaMonHoc { get; set; }
        public string MaQuaTrinhHoc { get; set; }
        public float DiemTB { get; set; }
        public BangDiem() { }
        public BangDiem(string maBD, string maMH, string maQTH, float diemTB)
        {
            MaBangDiem = maBD;
            MaMonHoc = maMH;
            MaQuaTrinhHoc = maQTH;
            DiemTB = diemTB;
        }
    }
}
