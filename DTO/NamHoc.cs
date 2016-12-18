using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NamHoc
    {
        public string MaNamHoc { get; set; }
        public int NamBatDau { get; set; }
        public int NamKetThuc { get; set; }
        public NamHoc() { }
        public NamHoc(string maNH, int namBD, int namKT)
        {
            MaNamHoc = maNH;
            NamBatDau = namBD;
            NamKetThuc = namKT;
        }
    }
}
