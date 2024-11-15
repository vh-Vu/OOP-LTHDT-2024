using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class HoaDon
	{
		public int MaHD {  get; set; }
		public DateOnly NgayTaoHD { get; set; }
		public string TenDoiTac { get; set; }
		public string SDT { get; set; }
		public string DiaChi {  get; set; }
		public List<ChiTietHoaDon> ChiTietHD { get; set; }
		public HoaDon(int MaHD, string TenDoiTac, string SDT, string DiaChi, List<ChiTietHoaDon> ChiTietHD) { 
			this.MaHD = MaHD;
			this.TenDoiTac = TenDoiTac;
			this.SDT = SDT;
			this.DiaChi = DiaChi;
			this.ChiTietHD = ChiTietHD;
			XacThucHoaDon();
		}
		public void XacThucHoaDon()
		{
			if (string.IsNullOrEmpty(TenDoiTac)) throw new Exception("Ten Doi Tac khong hop le");
			if (string.IsNullOrEmpty(SDT)) throw new Exception("So dien thoai khong hop le");
			if (string.IsNullOrEmpty(DiaChi)) throw new Exception("Dia chi khong hop le");
			if (ChiTietHD.Count == 0) throw new Exception("Danh sach san pham trong hoa don khong hop le");
		}
	}
}
