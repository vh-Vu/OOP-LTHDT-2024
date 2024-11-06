using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSP_Entity;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLySanPham
	{
		void ThemSanPham(SanPham s);
		public List<SanPham> DocDanhSachSanPham(string Keyword="");
		public SanPham DocSanPham(int maSP);
		public void SuaSanPham(SanPham s);
		public void XoaSanPham(SanPham s);

	}
}
