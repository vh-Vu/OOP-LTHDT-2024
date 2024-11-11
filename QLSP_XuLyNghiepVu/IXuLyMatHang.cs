using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLyMatHang
	{
		void ThemMatHang(MatHang matHang);
		List<MatHang> DocDanhSachMatHang(string Keyword = "");
		void SuaMatHang(MatHang matHang);
		void XoaMatHang(MatHang matHang);
		void ThemSanPhamVaoMatHang(SanPham sanPham);
		void XoaSanPhamRaKhoiMatHang(SanPham sanPham);
		void SanPhamThayDoiMatHang(SanPham sanPham, int maMatHangMoi);

	}
}
