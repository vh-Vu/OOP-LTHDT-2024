using QLSP_Entity;
using QLSP_LuuTru;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024
{
	public class ObjectCreater
	{
		public static IXuLySanPham TaoDoiTuongXuLySanPham()
		{
			ILuuTru<SanPham> sp = new LuuTru<SanPham>(@"D:\sanpham.json", @"D:\SPID.txt");

			return new XuLySanPham(sp, TaoDoiTuongXuLyMatHang());
		}
		public static IXuLyMatHang TaoDoiTuongXuLyMatHang()
		{
			ILuuTru<MatHang> mh = new LuuTru<MatHang>(@"D:\mathang.json", @"D:\MHID.txt");
			return new XuLyMatHang(mh);
		}
	}
}
