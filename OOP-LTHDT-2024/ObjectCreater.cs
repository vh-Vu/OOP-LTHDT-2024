using QLSP_Entity;
using QLSP_LuuTru;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024
{
	public class ObjectCreater
	{
		public static IXuLySanPham TaoDoiTuongXuLySanPham()
		{
			ILuuTru<SanPham> sp = new LuuTru<SanPham>(@"Data\sanpham.json", @"Data\SPID.txt");

			return new XuLySanPham(sp, TaoDoiTuongXuLyMatHang(), TaoDoiTuongXuLyKho());
		}
		public static IXuLyMatHang TaoDoiTuongXuLyMatHang()
		{
			ILuuTru<MatHang> mh = new LuuTru<MatHang>(@"Data\mathang.json", @"Data\MHID.txt");
			return new XuLyMatHang(mh);
		}
		public static IXuLySanPhamHoaDon TaoDoiTuongXuLySanPhamHoaDon()
		{
			return new XuLySanPhamHoaDon(TaoDoiTuongXuLySanPham());
		}
		public static IXuLyHoaDon TaoDoiTuongXuLyHoaDonNhap()
		{
			ILuuTru<HoaDon> hd = new LuuTru<HoaDon>(@"Data\HoaDonNhap.json", @"Data\HDNID.txt");
			return new XuLyHoaDon(hd, TaoDoiTuongXuLySanPhamHoaDon(), TaoDoiTuongXuLyKho());
		}
		public static IXuLyHoaDon TaoDoiTuongXuLyHoaDonXuat()
		{
            ILuuTru<HoaDon> hd = new LuuTru<HoaDon>(@"Data\HoaDonXuat.json", @"Data\HDXID.txt");
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
