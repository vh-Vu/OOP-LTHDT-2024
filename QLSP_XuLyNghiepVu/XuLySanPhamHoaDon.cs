using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public class XuLySanPhamHoaDon : IXuLySanPhamHoaDon
	{
		private IXuLySanPham _xuLySanPham;
		public XuLySanPhamHoaDon (IXuLySanPham XuLySanPham) {
			this._xuLySanPham = XuLySanPham;
		}

		public List<SPHoaDon> LocSP(List<SPHoaDon> SPHD)
		{
			var ketQua = new List<SPHoaDon>();
			var dsSanPham = _xuLySanPham.DocDanhSachSanPham();
			for (int i = 0; i < dsSanPham.Count; i++)
			{
				if (SPHD[i].Ma != dsSanPham[i].Ma) throw new Exception("Danh sách chi tiết hóa đơn không hợp lệ");
				if (SPHD[i].SoLuong > 0)
				{
					SPHD[i].CapNhat(dsSanPham[i].Ten, dsSanPham[i].Gia, dsSanPham[i].HanSuDung);
					ketQua.Add(SPHD[i]);
				}
			}
			if (ketQua.Count < 1) throw new Exception("Danh sách chi tiết các sản phẩm trong hóa đơn không hợp lệ");
			return ketQua;
		}

    }
}
