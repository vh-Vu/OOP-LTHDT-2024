using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
    public interface ILuuTruKho
    {
        void LuuDanhSach(List<SanPhamLuuKho> dsspKho);
        List<SanPhamLuuKho> DocDanhSach();
    }
}
