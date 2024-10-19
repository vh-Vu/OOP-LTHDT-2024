using QLSP_Entity;
using QLSP_LuuTru;

namespace QLSP_XuLyNghiepVu
{
	public class XuLySanPham
	{
		public void ThemSanPham(SanPham s)
		{
			LuuTruSanPham LuuTru = new LuuTruSanPham();
			LuuTru.LuuSanPham(s);
		}
	}
}
