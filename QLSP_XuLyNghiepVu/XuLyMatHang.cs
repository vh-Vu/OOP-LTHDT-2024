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

		public List<MatHang> DocDanhSachMatHang()
		{
			return _luuTruMatHang.DocDanhSachMatHang();
		}

		public void ThemMatHang(MatHang matHang)
		{
			_luuTruMatHang.ThemMatHang(matHang);
		}
	}
}
