using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocKy
    {
        public string MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public string MaNamHoc { get; set; }
        public HocKy() { }
        public HocKy(string maHK, string tenHK, string maNH)
        {
            MaHocKy = maHK;
            TenHocKy = tenHK;
            MaNamHoc = maNH;
        }
    }
}
