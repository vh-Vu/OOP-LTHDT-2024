using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class HoaDon : IEntity
	{
		public int Ma {  get; set; }
		public DateOnly NgayTaoHD { get; set; }
		public string Ten { get; set; }
		public bool DaXoa { get; set; }
		public int SDT { get; set; }
		public string DiaChi {  get; set; }
		public bool XacNhan { get; set; }
		public List<SanPhamHoaDon> ChiTietHD { get; set; }
		public long ThanhTien { get; set; }
		public HoaDon(string Ten, DateOnly NgayTaoHD, int SDT, string DiaChi) { 
			CapNhat(Ten, NgayTaoHD, SDT, DiaChi);
			DaXoa = false;
			this.XacNhan = false;
		}
		public static void XacThucHoaDon(string Ten, DateOnly NgayTaoHD, int SDT, string DiaChi)
		{
			if (string.IsNullOrEmpty(Ten)) throw new Exception("Ten Doi Tac khong hop le");
			int InvoiceYear = NgayTaoHD.Year;
			if (InvoiceYear < 2000 || InvoiceYear > 2025) throw new Exception("Ngay tao hoa don khong hop le");
			if (SDT<1) throw new Exception("So dien thoai khong hop le");
			if (string.IsNullOrEmpty(DiaChi)) throw new Exception("Dia chi khong hop le");
		}
		public void CapNhat(string Ten, DateOnly NgayTaoHD, int SDT, string DiaChi)
		{
			XacThucHoaDon(Ten, NgayTaoHD, SDT, DiaChi);
			this.Ten = Ten.Trim();
			this.SDT = SDT;
			this.DiaChi = DiaChi.Trim(); 
			this.NgayTaoHD = NgayTaoHD;

        }

		public void CapNhatThanhTien()
		{
			this.ThanhTien = 0;
			foreach (var sp in ChiTietHD)
			{
				this.ThanhTien += sp.ThanhTien;
			}
		}

		public void XacNhanHoaDon()
		{
			this.XacNhan = true;
		}
	}
}
