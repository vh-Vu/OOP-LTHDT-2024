namespace QLSP_Entity
{
	public class SanPham
	{
		public int MaSP { get; set; }
		public string Ten { get; set; }
		public int Gia { get; set; }
		public DateOnly HanDung { get; set; }
		public int NamSanXuat { get; set; }
		public string CongTySanXuat { get; set; }
		public int MatHang { get; set; }
		public SanPham(string ten, int gia, DateOnly hanDung, int namSanXuat, string congTySanXuat, int matHang)
		{
			if (string.IsNullOrEmpty(ten)) throw new Exception("Ten san pham khong hop le");
			if (gia <= 0) throw new Exception("Gia san pham khong hop le");
			if (string.IsNullOrEmpty(congTySanXuat))  throw new Exception("Ten cong ty khong hop le");
			if (hanDung < DateOnly.FromDateTime(DateTime.Now)) throw new Exception("Han su dung khong hop le");
			int currentYear = DateTime.Now.Year;
			if(namSanXuat> currentYear) throw new Exception("Nam san xuat khong hop le");
			if (matHang <= 0) throw new Exception("Mat hang khong hop le");
			
			
			this.Ten = ten;
			this.Gia = gia;
			this.HanDung = hanDung;
			this.NamSanXuat = namSanXuat;
			this.CongTySanXuat = congTySanXuat;
			this.MatHang = matHang;
		}
	}
}
