using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using DAT;
using DTO;

namespace BUS
{
    public class NguoiDungBUS
    {
        NguoiDungDAO ndd = new NguoiDungDAO();

        // Tìm người dùng
        public DataTable TimNguoiDung(string tenDN, string matKhau)
        {
            return ndd.TimNguoiDung(tenDN, matKhau);
        }

        // Thêm người dùng
        public bool ThemNguoiDung(string tenDN, string matKhau, string loaiND)
        {
            return ndd.ThemNguoiDung(tenDN, matKhau, loaiND);
        }

        // Xóa người dùng
        public bool XoaNguoiDung(string tenDN)
        {
            return ndd.XoaNguoiDung(tenDN);
        }

        // Kiem tra tồn tại người dùng
        public bool KiemTraNguoiDung(string tenDN)
        {
            DataTable dt = ndd.KiemTraNguoiDung(tenDN);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //  Danh sách người dùng
        public DataTable DanhSachNguoiDung()
        {
            return ndd.DanhSachNguoiDung();
        }

        // Chuyển đổi mật khẩu sang MD5
        public static string ChuyenDoiPassword(string matkhau)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.ASCII.GetBytes(matkhau));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
