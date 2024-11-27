using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class SPHoaDon
	{
		public int Ma { get; set; }
		public int SoLuong  { get; set; }
		public string Ten {  get; set; }
		public int Gia {  get; set; }
		public DateOnly HanSuDung { get; set; }
		public double ThanhTien { get; set; }
		public SPHoaDon()
		{

		}
		public SPHoaDon(int ma, int soLuong)
		{
			Ma = ma;
			SoLuong = soLuong;
		}
		public void CapNhat(string Ten, int Gia, DateOnly HanSuDung)
		{
			this.Ten = Ten;
			this.Gia = Gia;
			this.HanSuDung = HanSuDung;
			this.ThanhTien = this.Gia*this.SoLuong;
		}
	}
}
