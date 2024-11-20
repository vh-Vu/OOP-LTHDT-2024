using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	 public interface IXuLyKho
	{
		void NhapKho(List<SanPhamHoaDon> dsNhapKho);
		void XuatKho(List<SanPhamHoaDon> dsXuatKho, bool xuat = true);
		void XoaSanPhamKho(int ma);
		List<SanPhamLuuKho> DocDanhSachKho();
	}
}
