using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class SanPhamHoaDon
    {
		public SanPham SanPham { get; set; }
		public int SoLuong { get; set; }
        public long ThanhTien {  get; set; }
		public SanPhamHoaDon()
		{
		}
		public SanPhamHoaDon(SanPham SanPham , int SoLuong)
		{
			this.SanPham = SanPham;
            this.SoLuong = SoLuong;

        }

		public void CapNhatSoLuong(int SoLuong)
		{
			if (SoLuong < 0) throw new Exception("mesage");
			this.SoLuong = SoLuong;

        }
		public void CapNhatThanhTien()
		{
			this.ThanhTien = this.SanPham.Gia * this.SoLuong;
		}
	
	}
}
