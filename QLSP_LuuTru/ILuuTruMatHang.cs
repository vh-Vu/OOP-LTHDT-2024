using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
	public interface ILuuTruMatHang
	{
		List<MatHang> DocDanhSachMatHang();
		void ThemMatHang(MatHang matHang);
		void LuuDanhSachMatHang(List<MatHang> ds);
	}
}
