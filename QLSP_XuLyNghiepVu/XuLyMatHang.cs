using Newtonsoft.Json.Bson;
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
				if(mh.Ten.Contains(Keyword) && !mh.DaXoa) ketQua.Add(mh);
			}
			return ketQua;
		}

		public void ThemMatHang(MatHang matHang)
		{
			MatHang mh = _luuTruMatHang.TimTheoTen(matHang.Ten);
			if (mh != null && !mh.DaXoa) throw new Exception("Mặt hàng đã tồn tại");
			matHang.Ma = _luuTruMatHang.CapPhatID();
			_luuTruMatHang.Them(matHang);
		}

		public void SuaMatHang(int Ma, string Ten)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();
			int p= -1;
			for (int i = 0; i < dsMatHang.Count; i++)
			{
				if (dsMatHang[i].Ma == Ma)
				{
					p = i;
					continue;
				}
				if (Ten == dsMatHang[i].Ten && !dsMatHang[i].DaXoa) throw new Exception("Tên mặt hàng mới đã tồn tại");

			}
			if (p==-1) throw new Exception("Mặt hàng không tồn tại");
			dsMatHang[p].CapNhat(Ten);
			_luuTruMatHang.LuuDanhSach(dsMatHang);
		} 
		public void XoaMatHang(MatHang matHang)
		{ 
			_luuTruMatHang.Xoa(matHang.Ma);
		}
		public void ThemSanPhamVaoMatHang(int maMh , int maSanPham)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();
			int index = IndexMatHang(dsMatHang, maMh);
			if(index == -1) throw new Exception("Mặt hàng không tồn tại");
			dsMatHang[index].ThemSanPham(maSanPham);
			_luuTruMatHang.LuuDanhSach(dsMatHang);
		}
		public void XoaSanPhamRaKhoiMatHang(int maMh, int maSanPham)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();
			int index = IndexMatHang(dsMatHang, maMh);
			if (index == -1) throw new Exception("Mặt hàng không tồn tại");
			dsMatHang[index].XoaSanPham(maSanPham);
			_luuTruMatHang.LuuDanhSach(dsMatHang);
		}
		public void SanPhamThayDoiMatHang(int maMhCu, int maMhMoi, int maSanPham)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();

			int indexMatHangCu = IndexMatHang(dsMatHang,maMhCu);
			if(indexMatHangCu == -1) throw new Exception("Mặt hàng trước khi sửa của sản phẩm không tồn tại");

			int indexMatHangMoi = IndexMatHang(dsMatHang, maMhMoi);
			if (indexMatHangMoi == -1) throw new Exception("Mặt hàng sau khi sửa của sản phẩm không tồn tại");

			dsMatHang[indexMatHangCu].ThayDoiViTriSanPhamTrongMatHang(dsMatHang[indexMatHangMoi], maSanPham);
			_luuTruMatHang.LuuDanhSach(dsMatHang);
		}

		public MatHang DocMatHang(int maMH)
		{
			var dsMatHang = _luuTruMatHang.DocDanhSach();
			foreach (var MatHang in dsMatHang)
			{
				if (MatHang.Ma == maMH && !MatHang.DaXoa) return MatHang;
			}
			return null;
		}

		private int IndexMatHang(List<MatHang> dsMatHang, int Ma)
		{
			for (int i = 0; i < dsMatHang.Count; i++)
				if (dsMatHang[i].Ma == Ma) return i;
			return -1;
		}
	}
}
