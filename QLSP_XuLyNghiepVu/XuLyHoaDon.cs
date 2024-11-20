using QLSP_Entity;
using QLSP_LuuTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyHoaDon : IXuLyHoaDon
	{
		private ILuuTru<HoaDon> _luuTruHoaDonMua;
		private IXuLySanPhamHoaDon _xuLySanPhamHoaDon;
		private IXuLyKho _xuLyKho;
		public XuLyHoaDon(ILuuTru<HoaDon> luuTruHoaDonMua, IXuLySanPhamHoaDon xuLySanPhamHoaDon, IXuLyKho xuLyKho)
		{
			this._luuTruHoaDonMua = luuTruHoaDonMua;
			this._xuLySanPhamHoaDon = xuLySanPhamHoaDon;
			this._xuLyKho = xuLyKho;
        }
		
		public void ThemHoaDon(HoaDon hd, List<int?> SoLuong)
		{
			var ChiTietHD = _xuLySanPhamHoaDon.LocSanPham(SoLuong);
            hd.ChiTietHD = ChiTietHD;
			hd.Ma = _luuTruHoaDonMua.CapPhatID();
			hd.CapNhatThanhTien();
			_luuTruHoaDonMua.Them(hd);
		}

		public void XacNhanHoaDon(HoaDon hd, bool Nhap = true)
		{
			_xuLySanPhamHoaDon.KiemTraTinhHopLe(hd.ChiTietHD);
			var dsHD = _luuTruHoaDonMua.DocDanhSach();
			int p = -1;
			for (int i = 0; i < dsHD.Count; i++)
			{
				if (dsHD[i].Ma == hd.Ma) p = i;
			}

			if (p == -1) throw new Exception("Hóa đơn không tồn tại trong danh sách");
			if (Nhap) _xuLyKho.NhapKho(dsHD[p].ChiTietHD);
			else _xuLyKho.XuatKho(dsHD[p].ChiTietHD);
			dsHD[p].XacNhanHoaDon();
			_luuTruHoaDonMua.LuuDanhSach(dsHD);
		}

		public void XoaHoaDon(HoaDon hd)
		{

			_luuTruHoaDonMua.Xoa(hd.Ma);
		}

        public void SuaHoaDon(HoaDon hd, List<int?> SoLuong)
        {
			try
			{

				var ChiTietHD = _xuLySanPhamHoaDon.LocSanPham(SoLuong);

                var dsHD = _luuTruHoaDonMua.DocDanhSach();
				int p = -1;
				for(int i = 0; i < dsHD.Count; i++)
				{
					if (dsHD[i].Ma == hd.Ma) p = i;
                }

				if (p  == -1) throw new Exception("Hóa đơn không tồn tại trong danh sách");

                dsHD[p].CapNhat(hd.Ten, hd.NgayTaoHD, hd.SDT, hd.DiaChi);
                dsHD[p].ChiTietHD = ChiTietHD;
				dsHD[p].CapNhatThanhTien();
				_luuTruHoaDonMua.LuuDanhSach(dsHD);

			}
			catch (Exception ex)
			{
				throw new Exception($"Thông báo:\n {ex.Message}");
			}
        }
		public List<HoaDon> DocDanhSach(DateOnly fromDate = default, DateOnly toDate = default)
		{
			if (fromDate == default)	fromDate = new DateOnly(2000, 1, 1);
			if (toDate == default)	toDate = DateOnly.FromDateTime(DateTime.Now);
			var dsHD = _luuTruHoaDonMua.DocDanhSach();
			var ketQua = new List<HoaDon>();

			foreach(HoaDon hd in dsHD) 
				if (!hd.DaXoa && hd.NgayTaoHD>=fromDate && hd.NgayTaoHD<=toDate) 
					ketQua.Add(hd);

			return ketQua;
		}
		public HoaDon DocHoaDon(int maHD)
		{
			var dsHD = _luuTruHoaDonMua.DocDanhSach();
			foreach (var HD in dsHD) if(HD.Ma==maHD && !HD.DaXoa) return HD;
			return null;
		}
	}
}
