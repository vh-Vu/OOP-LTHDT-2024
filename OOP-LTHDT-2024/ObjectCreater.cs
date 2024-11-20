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

			return new XuLySanPham(sp, TaoDoiTuongXuLyMatHang(), TaoDoiTuongXuLyKho());
		}
		public static IXuLyMatHang TaoDoiTuongXuLyMatHang()
		{
			ILuuTru<MatHang> mh = new LuuTru<MatHang>(@"D:\mathang.json", @"D:\MHID.txt");
			return new XuLyMatHang(mh);
		}
		public static IXuLySanPhamHoaDon TaoDoiTuongXuLySanPhamHoaDon()
		{
			return new XuLySanPhamHoaDon(TaoDoiTuongXuLySanPham());
		}
		public static IXuLyHoaDon TaoDoiTuongXuLyHoaDonNhap()
		{
			ILuuTru<HoaDon> hd = new LuuTru<HoaDon>(@"H:\HDM.json", @"H:\HDMID.txt");
			return new XuLyHoaDon(hd, TaoDoiTuongXuLySanPhamHoaDon(), TaoDoiTuongXuLyKho());
		}
		public static IXuLyHoaDon TaoDoiTuongXuLyHoaDonXuat()
		{
            ILuuTru<HoaDon> hd = new LuuTru<HoaDon>(@"H:\HDB.json", @"H:\HDBID.txt");
            return new XuLyHoaDon(hd,TaoDoiTuongXuLySanPhamHoaDon(), TaoDoiTuongXuLyKho());
		}

		public static IXuLyKho TaoDoiTuongXuLyKho()
		{
			ILuuTruKho luutrukho = new LuuTruKho();
            IXuLyKho xulykho = new XuLyKho(luutrukho);
			return xulykho;
		}
	}
}
