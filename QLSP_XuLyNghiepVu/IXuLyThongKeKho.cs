using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
    public interface IXuLyThongKeKho
    {
        void CapNhatThongTin(int Ma, int SoLuong);
        void ThemSanPhamMoi(int Ma, int soLuong);
        void XoaSanPhamKho(int Ma);
        List<int[]> DocDanhSachThongKe();
    }
}
