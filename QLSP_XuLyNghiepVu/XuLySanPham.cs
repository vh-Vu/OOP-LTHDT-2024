using QLSP_Entity;
using QLSP_LuuTru;
using System.Net;

namespace QLSP_XuLyNghiepVu
{
	public class XuLySanPham : IXuLySanPham
	{
		private ILuuTru<SanPham> _luuTruSanPham;
		private IXuLyMatHang _xulyMatHang;
		public XuLySanPham(ILuuTru<SanPham> LuuSanPham, IXuLyMatHang xulyMatHang)
		{
			_luuTruSanPham = LuuSanPham;
			_xulyMatHang = xulyMatHang;
		}
		public void ThemSanPham(SanPham s)
		{
			SanPham sp =  _luuTruSanPham.TimTheoTen(s.Ten);

			if (sp!=null)	throw new Exception("ID da ton tai");
			s.Ma = _luuTruSanPham.CapPhatID();
			_xulyMatHang.ThemSanPhamVaoMatHang(s.MatHang,s.Ma);
			_luuTruSanPham.Them(s);
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
		
		public void SuaSanPham(SanPham s)
		{
			var dsSanPham = _luuTruSanPham.DocDanhSach();
			int p = -1;

			for(int i = 0; i < dsSanPham.Count; i++)
			{
				if (dsSanPham[i].Ma == s.Ma)
				{
					p = i;
					continue;
				}
				if (dsSanPham[i].Ten == s.Ten) throw new Exception("Ten san pham da ton tai");
			}

			if(p==-1) throw new Exception("San pham khong ton tai");

			if (dsSanPham[p].MatHang!= s.MatHang) _xulyMatHang.SanPhamThayDoiMatHang(dsSanPham[p].MatHang, s.MatHang, s.Ma);
			
			dsSanPham[p] = s;
			_luuTruSanPham.LuuDanhSach(dsSanPham);
		}
		public void XoaSanPham(SanPham s)
		{
			_xulyMatHang.XoaSanPhamRaKhoiMatHang(s.MatHang, s.Ma);
			_luuTruSanPham.Xoa(s.Ma);
		}
		public SanPham DocSanPham(int maSP)
		{
			var dsSanPham = _luuTruSanPham.DocDanhSach();
			foreach(var SanPham in dsSanPham)
			{
				if (SanPham.Ma == maSP) return SanPham;
			}
			return null;
		}


	}
}
