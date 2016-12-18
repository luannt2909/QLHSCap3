using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinh
    {
        public string MaHocSinh { get; set; }
        public string TenHocSinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public HocSinh() { }
        public HocSinh(string maHS, string tenHS, DateTime ngaySinh, bool gioiTinh, string diaChi, string email)
        {
            MaHocSinh = maHS;
            TenHocSinh = tenHS;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            Email = email;
        }
    }
}
