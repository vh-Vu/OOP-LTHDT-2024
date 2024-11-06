using QLSP_LuuTru;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024
{
	public class ObjectCreater
	{
		public static IXuLySanPham TaoDoiTuongXuLySanPham()
		{
			ILuuTruSanPham sp = new LuuTruSanPham();
			return new XuLySanPham(sp);
		}
		public static IXuLyMatHang TaoDoiTuongXuLyMatHang()
		{
			ILuuTruMatHang mh = new LuuTruMatHang();
			return new XuLyMatHang(mh);
		}
	}
}
