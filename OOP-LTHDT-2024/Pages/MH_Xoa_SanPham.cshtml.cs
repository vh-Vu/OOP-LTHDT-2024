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

		[BindProperty(SupportsGet = true)]
		public int MaSp { get; set; }
		[BindProperty]
		public string TenSanPham { get; set; }
		[BindProperty]
		public int Gia { get; set; }
		public string Chuoi = string.Empty;
		public MH_Xoa_SanPhamModel() : base()
		{
			_xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
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
				if (MaSp == 0)
				{
					Chuoi = "Ma san pham khong hop le";
					return;
				}
				SanPham = _xuLySanPham.DocSanPham(MaSp);
				if (SanPham == null) Chuoi = "Khong tim thay san pham";
				else
				{
					SanPham.Ten = TenSanPham;
					SanPham.Gia = Gia;
					_xuLySanPham.XoaSanPham(SanPham);
					Response.Redirect("/MH_DanhSachSanPham");
				}
			}
			catch (Exception e)
			{
				Chuoi = e.Message;
			}
		}
	}
}