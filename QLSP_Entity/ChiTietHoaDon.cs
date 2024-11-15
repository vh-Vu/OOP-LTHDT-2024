using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class ChiTietHoaDon
	{
		public int MaSP { get; set; }
		public string TenSP { get; set; }
		public int SoLuongSP { get; set; }
		public int GiaTienSP { get; set; }
		//public long ThanhTien {  get; set; }
		public ChiTietHoaDon()
		{
		}
		public ChiTietHoaDon(int maSP, string tenSP, int soLuongSP, int giaTienSP)
		{
			this.MaSP = maSP;
			this.TenSP = tenSP;
			this.SoLuongSP = soLuongSP;
			this.GiaTienSP = giaTienSP;
		}

		public int ThanhThien()
		{
			return this.SoLuongSP * this.GiaTienSP;
		}
	}
}
