using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAT;

namespace BUS
{    
    public class GioiTinhBUS
    {
        GioiTinhDAO gt = new GioiTinhDAO();
        public DataTable DanhSachGioiTinh()
        {
            return gt.DanhSachGioiTinh();
        }
    }
}
