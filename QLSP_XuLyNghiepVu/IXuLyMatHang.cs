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
		void ThemSanPhamVaoMatHang(int maMh, int maSanPham);
		void XoaSanPhamRaKhoiMatHang(int maMh, int maSanPham);
		void SanPhamThayDoiMatHang(int maMhCu, int maMhMoi, int maSanPham);
		MatHang DocMatHang(int maMH);
	}
}
