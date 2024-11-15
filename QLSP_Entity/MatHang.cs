using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class MatHang: IEntity
	{
		public int Ma {  get; set; }
		public string Ten { get; set; }
		public List<int> DanhSachSanPham { get; set; }
		public MatHang(string TenMH) { 
			if(string.IsNullOrEmpty(TenMH))
			{ throw new Exception("Ten mat hang khong hop le"); }
			this.Ten = TenMH;
			DanhSachSanPham = new List<int>();
		}

		public void XoaSanPham(int s)
		{
			if (!this.DanhSachSanPham.Contains(s))
				throw new Exception("San pham khong co trong danh sach");
			this.DanhSachSanPham.Remove(s);
		}
		public void ThemSanPham(int s)
		{
			if (this.DanhSachSanPham.Contains(s))
				throw new Exception("San pham da ton tai");
			this.DanhSachSanPham.Add(s);
		}
	}
}
