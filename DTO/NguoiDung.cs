using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string LoaiNguoiDung { get; set; }
        public NguoiDung() { }
        public NguoiDung(string tenDN, string mk, string loaiND)
        {
            TenDangNhap = tenDN;
            MatKhau = mk;
            LoaiNguoiDung = loaiND;
        }
    }
}
