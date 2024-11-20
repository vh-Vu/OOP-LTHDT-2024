using QLSP_Entity;
using QLSP_LuuTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyKho : IXuLyKho
	{
		private ILuuTruKho _luuTruKho;

        public XuLyKho(ILuuTruKho luuTruKho)
		{
			this._luuTruKho = luuTruKho;
		}
        public void NhapKho(List<SanPhamHoaDon> dsNhapKho)
		{
			var dsspkho = _luuTruKho.DocDanhSach();
			for (int i = 0; i < dsNhapKho.Count; i++)
			{
				var sanPhamNhapKho = dsNhapKho[i];
				bool tonTaiSanPham = false;
				for(int j = 0; j < dsspkho.Count; j++)
				{
					if (dsspkho[j].Ma == sanPhamNhapKho.SanPham.Ma)
					{
						tonTaiSanPham = true;
						dsspkho[j].Nhap(sanPhamNhapKho.SoLuong);
						break;
					}
				}
				if (!tonTaiSanPham)
				{
					var SanPhamLuuKho = new SanPhamLuuKho(sanPhamNhapKho.SanPham.Ma, sanPhamNhapKho.SanPham.MatHang, sanPhamNhapKho.SoLuong);
					dsspkho.Add(SanPhamLuuKho);
				}

			}
			_luuTruKho.LuuDanhSach(dsspkho);
		}
		public void XuatKho(List<SanPhamHoaDon> dsXuatKho,bool xuat= true)
		{
			var dsspkho = _luuTruKho.DocDanhSach();
			for (int i = 0; i < dsXuatKho.Count; i++)
			{
				var sanPhamNhapKho = dsXuatKho[i];
				bool tonTaiSanPham = false;
				for (int j = 0; j < dsspkho.Count; j++)
				{
					if (dsspkho[j].Ma == sanPhamNhapKho.SanPham.Ma)
					{
						tonTaiSanPham = true;
						dsspkho[j].Xuat(sanPhamNhapKho.SoLuong);
						break;
					}
				}
				if (!tonTaiSanPham) throw new Exception("San pham khong ton tai trong kho");

			}
			_luuTruKho.LuuDanhSach(dsspkho);
		}

		public void XoaSanPhamKho(int ma)
		{
			var dsspkho = _luuTruKho.DocDanhSach();
			for(int i = 0; i < dsspkho.Count; i++)
			{
				if (dsspkho[i].Ma == ma) {
					if (dsspkho[i].TonKho > 0) throw new Exception("San pham con ton kho, khong the xoa");
					dsspkho.RemoveAt(i);
					break;
				}
			}
			_luuTruKho.LuuDanhSach(dsspkho);
		}
		public List<SanPhamLuuKho> DocDanhSachKho()
		{
			return _luuTruKho.DocDanhSach();
		}

	}
}
