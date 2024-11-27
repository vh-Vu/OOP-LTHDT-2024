using System.Text.Json;

namespace QLSP_Entity
{
	public class SanPham : IEntity
	{
		private int _ma;
		private string _ten;
		private bool _daXoa;
		private int _gia;
		private DateOnly _hanSuDung;
		private int _namSanXuat;
		private string _congTySanXuat;
		private int _matHang;
		public int Ma { get { return _ma; } set { if (value == 0) throw new Exception("Du lieu khong hop le"); _ma= value ; } }
		public string Ten {
			get
			{
				return _ten;
			} 
			set
			{
				if (string.IsNullOrEmpty(value)) throw new Exception("Ten san pham khong hop le");
				_ten = value.Trim();
			}
		}
		public bool DaXoa { get { return _daXoa; } set {_daXoa = value; } }

		public int Gia { get { return _gia; }
			set {
				if (value < 0) throw new Exception("Gia san pham khong hop le");
				_gia = value;
			} 
		}

		public DateOnly HanSuDung { get {return _hanSuDung; }
			set {
				_hanSuDung = value;
			}
		}
		public int NamSanXuat { get { return _namSanXuat; }
			set {
				int currentYear = DateTime.Now.Year;
				if (value > currentYear || value < 2000) throw new Exception("Nam san xuat khong hop le");
				_namSanXuat = value;
			} 
		}
		public string CongTySanXuat { get { return _congTySanXuat; }
			set {
				if (string.IsNullOrEmpty(value)) throw new Exception("Ten cong ty khong hop le");
				_congTySanXuat = value.Trim();
			} 
		}
		public int MatHang { get { return _matHang; }
			set {
				_matHang = value;
			} }
		public SanPham(string ten, int gia, DateOnly HanSuDung, int namSanXuat, string congTySanXuat, int matHang)
		{
			CapNhat(ten, gia, HanSuDung, namSanXuat, congTySanXuat, matHang);
			this._daXoa = false;
		}

		public void Xoa()
		{
			_daXoa = true;
		}

		public void CapNhat(string ten, int gia, DateOnly HanSuDung, int namSanXuat, string congTySanXuat, int matHang)
		{
			this.Ten = ten;
			this.Gia = gia;
			this.HanSuDung = HanSuDung;
			this.NamSanXuat = namSanXuat;
			this.CongTySanXuat = congTySanXuat;
			this._matHang = matHang;
		}
	}
}
