namespace QLSP_Entity
{
	public class SanPham
	{
		public int MaSP { get; set; }
		public string Ten { get; set; }
		public int Gia { get; set; }
		public SanPham(string ten, int gia)
		{
			if (string.IsNullOrEmpty(ten))
			{
				throw new Exception("Ten san pham khong hop le");
			}
			if (gia <= 0)
			{
				throw new Exception("Gia san pham khong hop le");
			}
			this.Ten = ten;
			this.Gia = gia;
		}
	}
}
