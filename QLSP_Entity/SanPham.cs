namespace QLSP_Entity
{
	public class SanPham : IEntity
	{
		public int Ma { get; set; }
		public string Ten { get; set; }
		public bool DaXoa { get; set; }
		public int Gia { get; set; }
		public DateOnly HanSuDung { get; set; }
		public int NamSanXuat { get; set; }
		public string CongTySanXuat { get; set; }
		public int MatHang { get; set; }
		public SanPham(string ten, int gia, DateOnly HanSuDung, int namSanXuat, string congTySanXuat, int matHang)
		{
			CapNhatSanPham(ten, gia, HanSuDung, namSanXuat, congTySanXuat, matHang);
			DaXoa = false;
		}

		public void CapNhatSanPham(string ten, int gia, DateOnly HanSuDung, int namSanXuat, string congTySanXuat, int matHang)
		{
			KiemTraDieuKien(ten, gia, HanSuDung, namSanXuat, congTySanXuat, matHang);

			this.Ten = ten.Trim();
			this.Gia = gia;
			this.HanSuDung = HanSuDung;
			this.NamSanXuat = namSanXuat;
			this.CongTySanXuat = congTySanXuat.Trim();
			this.MatHang = matHang;
		}


		public static void KiemTraDieuKien(string ten, int gia, DateOnly HanSuDung, int namSanXuat, string congTySanXuat, int matHang)
		{
			if (string.IsNullOrEmpty(ten)) throw new Exception("Ten san pham khong hop le");
			if (gia <= 0) throw new Exception("Gia san pham khong hop le");
			if (string.IsNullOrEmpty(congTySanXuat)) throw new Exception("Ten cong ty khong hop le");
			if (HanSuDung < DateOnly.FromDateTime(DateTime.Now.Date)) throw new Exception("Han su dung khong hop le");
			int currentYear = DateTime.Now.Year;
			if (namSanXuat > currentYear || namSanXuat < 2000) throw new Exception("Nam san xuat khong hop le");
			if (matHang <= 0) throw new Exception("Mat hang khong hop le");
		}
	}
}
