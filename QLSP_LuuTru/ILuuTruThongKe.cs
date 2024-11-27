using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
    public interface ILuuTruThongKe
    {
        List<int[]> DocDanhSachThongKe();
        void LuuDanhSachThongKe(List<int[]> ThongKe);
    }
}
