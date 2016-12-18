using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuaTrinhHoc
    {
        public string MaQuaTrinhHoc { get; set; }
        public string MaLop { get; set; }
        public string MaHocSinh { get; set; }
        public string MaHocKy { get; set; }
        public float DiemTBHK { get; set; }
        public QuaTrinhHoc() { }
        public QuaTrinhHoc(string maQuaTrinh, string maHS, string maLop, string maHK, float diemTB)
        {
            MaQuaTrinhHoc = maQuaTrinh;
            MaHocSinh = maHS;
            MaLop = maLop;
            MaHocKy = maHK;
            DiemTBHK = diemTB;
        }
    }
}
