using QLSP_Entity;
using QLSP_LuuTru;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024
{
	public class ObjectCreater
	{
		public static IXuLySanPham TaoDoiTuongXuLySanPham()
		{
			ILuuTru<SanPham> sp = new LuuTru<SanPham>(@"Data\sanpham.json", @"Data\SPID.txt", @"Data\SP_LastEdit");

			return new XuLySanPham(sp, TaoDoiTuongXuLyMatHang(), TaoDoiTuongXuLyKho(), TaoDoiTuongXyLyThongKeKho());
		}
		public static IXuLyMatHang TaoDoiTuongXuLyMatHang()
		{
			ILuuTru<MatHang> mh = new LuuTru<MatHang>(@"Data\mathang.json", @"Data\MHID.txt", @"Data\MH_LastEdit");
			return new XuLyMatHang(mh);
		}
		public static IXuLySanPhamHoaDon TaoDoiTuongXuLySanPhamHoaDon()
		{
			return new XuLySanPhamHoaDon(TaoDoiTuongXuLySanPham());
		}
		public static IXuLyHoaDon TaoDoiTuongXuLyHoaDonNhap()
		{
			ILuuTru<HoaDon> hd = new LuuTru<HoaDon>(@"Data\HoaDonNhap.json", @"Data\HDNID.txt", @"Data\HDN_LastEdit");
			return new XuLyHoaDon(hd, TaoDoiTuongXuLySanPhamHoaDon(), TaoDoiTuongXuLyKho());
		}
		public static IXuLyHoaDon TaoDoiTuongXuLyHoaDonXuat()
		{
            ILuuTru<HoaDon> hd = new LuuTru<HoaDon>(@"Data\HoaDonXuat.json", @"Data\HDXID.txt", @"Data\HDX_LastEdit");
            return new XuLyHoaDon(hd,TaoDoiTuongXuLySanPhamHoaDon(), TaoDoiTuongXuLyKho());
		}

		public static IXuLyKho TaoDoiTuongXuLyKho()
		{
			ILuuTruKho luutrukho = new LuuTruKho();
            IXuLyKho xulykho = new XuLyKho(luutrukho, TaoDoiTuongXyLyThongKeKho());
			return xulykho;
		}

		public static IXuLyThongKeKho TaoDoiTuongXyLyThongKeKho()
		{
            ILuuTruThongKe luuTruThongKe = new LuuTruThongKe();
            IXuLyThongKeKho xuLyThongKeKho = new XuLyThongKeKho(luuTruThongKe);
			return xuLyThongKeKho;

        }
	}
}
