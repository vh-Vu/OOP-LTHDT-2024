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
		public List<SanPham> DocDanhSachSanPham(string Keyword="")
		{
			var dsSanPham = _luuTruSanPham.DocDanhSach();
			var ketQua = new List<SanPham>();
			foreach(var SanPham in dsSanPham)
			{
				if(SanPham.Ten.Contains(Keyword)) ketQua.Add(SanPham);
			}
			return ketQua;
		}
	}
}
