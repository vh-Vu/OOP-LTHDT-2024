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
		private ILuuTru<MatHang> _luuTruMatHang;

		public XuLyMatHang (ILuuTru<MatHang> dsMatHang){
			_luuTruMatHang = dsMatHang;
		}

		public List<MatHang> DocDanhSachMatHang(string Keyword ="")
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();
			var ketQua = new List<MatHang>();
			foreach(var mh in dsMatHang)
			{
				if(mh.Ten.Contains(Keyword)) ketQua.Add(mh);
			}
			return ketQua;
		}

		public void ThemMatHang(MatHang matHang)
		{
			MatHang mh = _luuTruMatHang.TimTheoTen(matHang.Ten);
			if (mh != null)
				throw new Exception("ID da ton tai");
			matHang.Ma = _luuTruMatHang.CapPhatID();
			_luuTruMatHang.Them(matHang);
		}

		public void SuaMatHang(MatHang matHang)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();
			int p= -1;
			for (int i = 0; i < dsMatHang.Count; i++)
			{
				if (dsMatHang[i].Ma != matHang.Ma && matHang.Ten == dsMatHang[i].Ten) throw new Exception("Ten mat hang da ton tai");
				if (dsMatHang[i].Ma == matHang.Ma)
				{
					p = i;
				}
			}
			if (p==-1) throw new Exception("Mat hang khong ton tai");
			dsMatHang[p] = matHang;
			_luuTruMatHang.LuuDanhSach(dsMatHang);
		}
		public void XoaMatHang(MatHang matHang)
		{
			_luuTruMatHang.Xoa(matHang.Ma);
		}
		public void ThemSanPhamVaoMatHang(int maMh , int maSanPham)
		{
			var matHang = DocMatHang(maMh) ?? throw new Exception("Mat hang khong ton tai");
			matHang.ThemSanPham(maSanPham);
			SuaMatHang(matHang);
		}
		public void XoaSanPhamRaKhoiMatHang(int maMh, int maSanPham)
		{
			var matHang = DocMatHang(maMh) ?? throw new Exception("Mat hang khong ton tai");
			matHang.XoaSanPham(maSanPham);
			SuaMatHang(matHang);
		}
		public void SanPhamThayDoiMatHang(int maMhCu, int maMhMoi, int maSanPham)
		{
			var matHangCu = DocMatHang(maMhCu);
			var matHangMoi = DocMatHang(maMhMoi);
			if (matHangCu == null || matHangMoi == null) throw new Exception("Mat hang khong ton tai");
			matHangCu.XoaSanPham(maSanPham);
			matHangMoi.ThemSanPham(maSanPham);
			SuaMatHang(matHangCu);
			SuaMatHang(matHangMoi);
		}

		public MatHang DocMatHang(int maMH)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();
			foreach (var MatHang in dsMatHang)
			{
				if (MatHang.Ma == maMH) return MatHang;
			}
			return null;
		}
		
	}
}
