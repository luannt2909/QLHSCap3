using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThamSo
    {
        public string TenThamSo { get; set; }
        public int GiaTriThamSo { get; set; }

        public ThamSo() { }
        public ThamSo(string TenTS, int GiaTri)
        {
            TenThamSo = TenTS;
            GiaTriThamSo = GiaTri;
        }
    }
}
