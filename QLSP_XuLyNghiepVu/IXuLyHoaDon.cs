using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLyHoaDon
	{
		void ThemHoaDon(HoaDon hd, List<SPHoaDon> CTHD);
		void XoaHoaDon(HoaDon hd);
		void SuaHoaDon(HoaDon hd, List<SPHoaDon> SoLuong);
		List<HoaDon> DocDanhSach(DateOnly fromDate = default, DateOnly toDate = default);
		HoaDon DocHoaDon(int maHD);
		void XacNhanHoaDon(HoaDon hd,bool Nhap = true);

	}
}
