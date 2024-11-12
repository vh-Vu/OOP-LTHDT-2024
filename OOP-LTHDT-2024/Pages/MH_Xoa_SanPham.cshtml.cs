using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages
{
    public class MH_Xoa_SanPhamModel : PageModel
    {
		public SanPham SanPham { get; set; }
		private IXuLySanPham _xuLySanPham;
		private IXuLyMatHang _xuLyMatHang;


		[BindProperty(SupportsGet = true)]
		public int MaSp { get; set; }

		public string Chuoi = string.Empty;
		public MH_Xoa_SanPhamModel() : base()
		{
			_xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
			_xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();
		}

		public void OnGet()
		{
			if (MaSp == 0)
			{
				Chuoi = "Ma san pham khong hop le";
				return;
			}
			SanPham = _xuLySanPham.DocSanPham(MaSp);
			if (SanPham == null) Chuoi = "Khong tim thay san pham";
		}
		public void OnPost()
		{
			try
			{
				if (MaSp == 0) throw new Exception("Ma san pham khong hop le");
				SanPham = _xuLySanPham.DocSanPham(MaSp);
				if (SanPham == null) throw new Exception("Khong tim thay san pham");
				_xuLySanPham.XoaSanPham(SanPham);
				_xuLyMatHang.XoaSanPhamRaKhoiMatHang(SanPham);
				Response.Redirect("/MH_DanhSachSanPham");
			}
			catch (Exception e)
			{
				Chuoi = e.Message;
			}
		}
	}
}
