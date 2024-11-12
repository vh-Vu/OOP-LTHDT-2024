using QLSP_Entity;
using QLSP_LuuTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyMatHang : IXuLyMatHang
	{
		private ILuuTruMatHang _luuTruMatHang;

		public XuLyMatHang (ILuuTruMatHang dsMatHang){
			_luuTruMatHang = dsMatHang;
		}

		public List<MatHang> DocDanhSachMatHang(string Keyword ="")
		{
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();
			var ketQua = new List<MatHang>();
			foreach(var mh in dsMatHang)
			{
				if(mh.TenMH.Contains(Keyword)) ketQua.Add(mh);
			}
			return ketQua;
		}

		public void ThemMatHang(MatHang matHang)
		{
			_luuTruMatHang.ThemMatHang(matHang);
		}

		public void SuaMatHang(MatHang matHang)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();
			for (int i = 0; i < dsMatHang.Count; i++)
			{
				if (dsMatHang[i].MaMH == matHang.MaMH)
				{
					dsMatHang[i] = matHang; break;
				}
			}
			_luuTruMatHang.LuuDanhSachMatHang(dsMatHang);
		}
		public void XoaMatHang(MatHang matHang)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();
			for (int i = 0; i < dsMatHang.Count; i++)
			{
				if (dsMatHang[i].MaMH == matHang.MaMH)
				{
					dsMatHang.Remove(dsMatHang[i]); break;
				}
			}
			_luuTruMatHang.LuuDanhSachMatHang(dsMatHang);
		}
		public void ThemSanPhamVaoMatHang(SanPham sanPham)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();
			for (int i = 0;i < dsMatHang.Count; i++)
			{
				if (dsMatHang[i].MaMH== sanPham.MatHang)
				{
					dsMatHang[i].DanhSachSanPham.Add(sanPham.MaSP); break;	
				}
			}
			_luuTruMatHang.LuuDanhSachMatHang(dsMatHang);
		}
		public void XoaSanPhamRaKhoiMatHang(SanPham sanPham)
		{
			var dsMatHang = DocDanhSachMatHang();
			for (int i = 0; i < dsMatHang.Count; i++)
			{
				if (dsMatHang[i].MaMH == sanPham.MatHang)
				{
					dsMatHang[i].DanhSachSanPham.Remove(sanPham.MaSP); break;
				}
			}
			_luuTruMatHang.LuuDanhSachMatHang(dsMatHang);
		}
		public void SanPhamThayDoiMatHang(SanPham sanPham, int maMatHangMoi)
		{
			XoaSanPhamRaKhoiMatHang(sanPham);
			sanPham.MatHang = maMatHangMoi;
			ThemSanPhamVaoMatHang(sanPham);
		}

		public MatHang DocMatHang(int maMH)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();
			foreach (var MatHang in dsMatHang)
			{
				if (MatHang.MaMH == maMH) return MatHang;
			}
			return null;
		}
		public bool MaMatHangTonTai(int maMH)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSachMatHang();
			foreach (var MatHang in dsMatHang)
			{
				if (MatHang.MaMH == maMH) return true;
			}
			return false;
		}
	}
}
