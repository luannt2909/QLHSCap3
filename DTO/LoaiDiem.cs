using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiDiem
    {
        public string MaLoaiDiem { get; set; }
        public string TenLoaiDiem { get; set; }
        public float HeSo { get; set; }
        public LoaiDiem() { }
        public LoaiDiem(string maLD, string tenLD, float hs)
        {
            MaLoaiDiem = maLD;
            TenLoaiDiem = tenLD;
            HeSo = hs;
        }
    }
}
