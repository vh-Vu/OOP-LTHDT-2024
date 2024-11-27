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
		public bool DaXoa { get; set; }
		public List<int> DanhSachSanPham { get; set; }
		public MatHang(string Ten) {
			CapNhat(Ten);
			DaXoa = false;
			DanhSachSanPham = new List<int>();
		}
		public static void KiemTraDieuKien(string Ten)
		{
			if (string.IsNullOrEmpty(Ten))
			{ throw new Exception("Ten mat hang khong hop le"); }
		}
		public void CapNhat(string Ten)
		{
			KiemTraDieuKien(Ten);
			if(Ten.Trim()!=this.Ten)
			this.Ten = Ten.Trim();
		}
		public void XoaSanPham(int s)
		{
			if (!TonTaiSanPham(s)) throw new Exception("Sản phẩm không có trong danh sách mặt hàng");
			this.DanhSachSanPham.Remove(s);
		}
		public void ThemSanPham(int s)
		{
			if (TonTaiSanPham(s))	throw new Exception("Sản phẩm đã tồn tại trong danh sách mặt hàng");
			this.DanhSachSanPham.Add(s);
		}

		private bool TonTaiSanPham(int MaSp)
		{
			return this.DanhSachSanPham.Contains(MaSp);
		}

		public void ThayDoiViTriSanPhamTrongMatHang(MatHang Moi,int MaSp)
		{
			if (!TonTaiSanPham(MaSp))		throw new Exception("Sản phẩm không có trong danh sách mặt hàng cũ");
			if (Moi.TonTaiSanPham(MaSp))	throw new Exception("Sản phẩm đã tồn tại trong danh sách mặt hàng mới");
			DanhSachSanPham.Remove(MaSp);
			Moi.DanhSachSanPham.Add(MaSp);

		}
		public void Xoa()
		{
			this.DaXoa = true;
		}
	}
}
