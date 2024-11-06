using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public interface IXuLyMatHang
	{
		void ThemMatHang(MatHang matHang);
		List<MatHang> DocDanhSachMatHang();
	}
}
