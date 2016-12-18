using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAT;
using DTO;

namespace BUS
{
    public class KhoiLopBUS
    {
        KhoiLopDAO kld = new KhoiLopDAO();
        public bool ThemKhoiLop(string maKL, string tenKL, string maNH)
        {
            return kld.ThemKhoiLop(maKL, tenKL, maNH);
        }

        public DataTable TimKhoiLop(string maNH)
        {
            return kld.TimKhoiLop(maNH);
        }
        public bool XoaKhoiLop(string maKL)
        {
            return kld.XoaKhoiLop(maKL);
        }
        public string MaKhoiLop(string tenKL, string maNam)
        {
            return tenKL + maNam.Substring(0, 4);
        }
        public bool ThayDoiKhoiLop(string maKL, string maKLM, string tenKL)
        {
            return kld.ThayDoiKhoiLop(maKL, maKLM, tenKL);
        }
        public DataTable ChonKhoiLop(string maKL)
        {
            return kld.ChonKhoiLop(maKL);
        }
    }
}
