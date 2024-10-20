using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
	public interface ILuuTruSanPham
	{
		public void LuuSanPham(SanPham s);
		public List<SanPham> DocDanhSach();
		public void LuuDanhSach(List<SanPham> ds);
		public SanPham TimSanPhamTheoTen(string ten);

	}
}
