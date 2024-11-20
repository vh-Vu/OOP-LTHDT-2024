using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLySanPhamHoaDon
	{
		List<SanPhamHoaDon> LocSanPham(List<int?> SoLuong);
		void KiemTraTinhHopLe(List<SanPhamHoaDon> danhSachHoaDon);

    }
}
