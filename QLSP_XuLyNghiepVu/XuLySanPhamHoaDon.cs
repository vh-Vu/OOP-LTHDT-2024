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

		public List<SanPhamHoaDon> LocSanPham(List<int?> SoLuong)
		{
			var ketQua = new List<SanPhamHoaDon>();
			var dsSanPham = _xuLySanPham.DocDanhSachSanPham();
			for (int i = 0; i < dsSanPham.Count; i++)
			{
				if (SoLuong[i].HasValue && SoLuong[i].Value > 0)
				{
					var sphd = new SanPhamHoaDon(dsSanPham[i], SoLuong[i].Value);
					sphd.CapNhatThanhTien();
					ketQua.Add(sphd);
				}
			}
			if (ketQua.Count < 1) throw new Exception("Danh sách chi tiết các sản phẩm trong hóa đơn không hợp lệ");
			return ketQua;
		}

		public void KiemTraTinhHopLe(List<SanPhamHoaDon> danhSachHoaDon)
		{
            var dssp = _xuLySanPham.DocTatCaDanhSachSanPham();
            foreach (var hdsp in danhSachHoaDon)
            {
                foreach (var sp in dssp)
                {
                    if (sp.Ma == hdsp.SanPham.Ma)
                    {
                        if (sp.DaXoa) throw new Exception("Có sản phẩm trong hóa đơn không tồn tại, vui lòng sửa");
                        break;
                    }
                }
            }
        }

    }
}
