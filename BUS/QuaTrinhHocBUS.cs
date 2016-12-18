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
    public class QuaTrinhHocBUS
    {
        QuaTrinhHocDAO qthd = new QuaTrinhHocDAO();

        // Thêm quá trình học
        public bool ThemQuaTrinhHoc(string maQTH, string maHS, string maLop, string maHK, double diemTBHK)
        {
            return qthd.ThemQuaTrinhHoc(maQTH, maHS, maLop, maHK, diemTBHK);
        }

        // Sửa điểm TBHK quá trình học
        public bool SuaDiemTBHK(string maQTH, double diemTBHK)
        {
            return qthd.SuaDiemTBHK(maQTH, diemTBHK);
        }

        // Sửa lớp quá trình học
        public bool SuaLopQuaTrinh(string maHS, string maLop, string maLopMoi)
        {
            return qthd.SuaLopQuaTrinh(maHS, maLop, maLopMoi);
        }

        // Mã quá trình học
        public string MaQuaTrinhHoc(string maHS, string maLop, string maHK)
        {
            return maHS + maLop + "-" + maHK;
        }
        public bool XoaQuaTrinhHoc(string maQTH)
        {
            return qthd.XoaQuaTrinh(maQTH);
        }

        public float DiemTBHK(string maQTH)
        {
            DataTable dt = qthd.TimDiemTBHocKy(maQTH);
            float diem = float.Parse(dt.Rows[0][0].ToString());
            return diem;
        }
        public DataTable DanhSachDiemTBHK (string maLop, string maHK)
        {
            return qthd.DanhSachDiemTBHK(maLop, maHK);
        }
        public double TinhDiemTrungBinhHocKy(List<double> diemList, List<double> heSoList)
        {
            double result = 0;
            double tongHeSo = 0;
            foreach (float heSo in heSoList)
            {
                tongHeSo += heSo;
            }
            for (int i = 0; i < diemList.Count; i++)
            {
                result += diemList[i] * heSoList[i];
            }
            return result / tongHeSo;
        }
    }
}
