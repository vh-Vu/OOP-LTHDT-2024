using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class SanPhamLuuKho
	{
		public int Ma {  get; set; }
		public int TonKho {  get; set; }
		public DateOnly HanSuDung { get; set; }
		public SanPhamLuuKho(int Ma, int TonKho, DateOnly HanSuDung)
		{
			if (Ma <= 0) throw new Exception("Ma khong hop le");
			this .Ma = Ma;
			this.TonKho = TonKho;
			this.HanSuDung = HanSuDung;
		}
		public void Nhap(int SoLuong)
		{
			this.TonKho += SoLuong;
		}
		public void Xuat(int SoLuong)
		{
			if (SoLuong > this.TonKho) throw new Exception($"Sản phẩm có mã \"{this.Ma}\" không đủ số lượng sản phẩm tồn dư trong kho");
			this.TonKho -= SoLuong;
		}
		public bool ConHanSuDung()
		{
			return this.HanSuDung >= DateOnly.FromDateTime(DateTime.Now.Date);
		}
	}
}
