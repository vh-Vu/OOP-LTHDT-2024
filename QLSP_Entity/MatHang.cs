using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_Entity
{
	public class MatHang
	{
		public int MaMH {  get; set; }
		public string TenMH { get; set; }
		public List<int> DanhSachSanPham { get; set; }
		public MatHang(string TenMH) { 
			if(string.IsNullOrEmpty(TenMH))
			{ throw new Exception("Ten mat hang khong hop le"); }
			this.TenMH = TenMH;	
			DanhSachSanPham = new List<int>();
		}
	}
}
