using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	 public interface IXuLyKho
	{
		void NhapKho(List<SPHoaDon> dsNhapKho);
		void XuatKho(List<SPHoaDon> dsXuatKho);
		void XoaSanPhamKho(int Ma);      
		public List<SanPhamLuuKho> DocDanhSachKho();
		int SanPhamHetHan(int Ma);
    }
}
