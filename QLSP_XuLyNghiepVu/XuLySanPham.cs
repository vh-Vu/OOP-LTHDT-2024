﻿using QLSP_Entity;
using QLSP_LuuTru;
using System.Net;

namespace QLSP_XuLyNghiepVu
{
	public class XuLySanPham : IXuLySanPham
	{
		private ILuuTru<SanPham> _luuTruSanPham;
		private IXuLyMatHang _xulyMatHang;
		private IXuLyKho _xuLyKho;
        private IXuLyThongKeKho _xuLyThongKeKho;

        public XuLySanPham(ILuuTru<SanPham> LuuSanPham, IXuLyMatHang xulyMatHang, IXuLyKho xuLyKho, IXuLyThongKeKho xuLyThongKeKho)
		{
			_luuTruSanPham = LuuSanPham;
			_xulyMatHang = xulyMatHang;
			_xuLyKho = xuLyKho;
			_xuLyThongKeKho = xuLyThongKeKho;

        }
		public void ThemSanPham(SanPham s)
		{
			SanPham sp =  _luuTruSanPham.TimTheoTen(s.Ten);

			if (sp!=null && !sp.DaXoa)	throw new Exception("ID da ton tai");
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
				if(SanPham.Ten.Contains(Keyword) && !SanPham.DaXoa) ketQua.Add(SanPham);
			}
			return ketQua;
		}
		
		public void SuaSanPham(int Ma, string Ten, int Gia, DateOnly HanSuDung, int NamSanXuat, string CongTySanXuat, int MatHang)
		{
			var dsSanPham = _luuTruSanPham.DocDanhSach();
			int p = -1;

			for(int i = 0; i < dsSanPham.Count; i++)
			{
				if (dsSanPham[i].Ma == Ma)
				{
					p = i;
					continue;
				}
				if (dsSanPham[i].Ten == Ten && !dsSanPham[i].DaXoa) throw new Exception("Ten san pham da ton tai");
			}

			if(p==-1) throw new Exception("San pham khong ton tai");
			int maMHCu = dsSanPham[p].MatHang;
			dsSanPham[p].CapNhat(Ten,Gia, HanSuDung, NamSanXuat, CongTySanXuat, MatHang);
			if (maMHCu != MatHang) _xulyMatHang.SanPhamThayDoiMatHang(maMHCu, MatHang, Ma);
			_luuTruSanPham.LuuDanhSach(dsSanPham);
		}

		public void XoaSanPham(SanPham s)
		{
            _xuLyThongKeKho.XoaSanPhamKho(s.Ma);
            _xuLyKho.XoaSanPhamKho(s.Ma);
			_xulyMatHang.XoaSanPhamRaKhoiMatHang(s.MatHang, s.Ma);
			_luuTruSanPham.Xoa(s.Ma);
		}
		public SanPham DocSanPham(int maSP)
		{
			var dsSanPham = _luuTruSanPham.DocDanhSach();
			foreach(var SanPham in dsSanPham)
			{
				if (SanPham.Ma == maSP && !SanPham.DaXoa) return SanPham;
			}
			return null;
		}
		public DateTime DocThoiGianCapNhat()
		{
			return _luuTruSanPham.DocThoiGianCapNhat();
		}

	}
}
