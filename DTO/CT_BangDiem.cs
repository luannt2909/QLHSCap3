using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_BangDiem
    {
        public string MaBangDiem { get; set; }
        public string MaLoaiDiem { get; set; }
        public float Diem { get; set; }
        public CT_BangDiem() { }
        public CT_BangDiem(string maBD, string maLD, float diem)
        {
            MaBangDiem = maBD;
            MaLoaiDiem = maLD;
            Diem = diem;
        }
    }
}
