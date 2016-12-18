using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAT;

namespace BUS
{
    public class LoaiDiemBUS
    {
        public LoaiDiemDAO ldd = new LoaiDiemDAO();
        // Tìm hệ số điểm
        public float HeSoDiem(string maLD)
        {
            DataTable dt = ldd.HeSoDiem(maLD);
            float heSo = float.Parse(dt.Rows[0][0].ToString());
            return heSo;
        }
        // Cập nhật hệ số
        public bool SuaHeSo(string maLD, float heSo)
        {
            return ldd.SuaHeSo(maLD, heSo);
        }
    }
}
