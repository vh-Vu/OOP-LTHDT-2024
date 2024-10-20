using QLSP_Entity;
using QLSP_LuuTru;
using System.Net;

namespace QLSP_XuLyNghiepVu
{
	public class XuLySanPham : IXuLySanPham
	{
		private ILuuTruSanPham _luuTruSanPham;
		public XuLySanPham(ILuuTruSanPham LuuSanPham)
		{
			_luuTruSanPham = LuuSanPham;
		}
		public void ThemSanPham(SanPham s)
		{
			SanPham sp =  _luuTruSanPham.TimSanPhamTheoTen(s.Ten);
			if (sp!=null)
				throw new Exception("ID da ton tai");
			_luuTruSanPham.LuuSanPham(s);
		}
		public List<SanPham> DocDanhSachSanPham()
		{
			return _luuTruSanPham.DocDanhSach();
		}
	}
}
