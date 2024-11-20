using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.Category
{
    public class MH_DanhSachMatHangModel : PageModel
    {
		public List<MatHang> DanhSachMatHang { get; set; }
		public IXuLyMatHang _xuLyMatHang;
		[BindProperty]
		public string Keyword { get; set; }
		public string chuoi = string.Empty;
		public MH_DanhSachMatHangModel() : base()
		{
			_xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();
		}
		public void OnGet()
		{
			try
			{
				DanhSachMatHang = _xuLyMatHang.DocDanhSachMatHang();

			}
			catch (Exception ex)
			{
				chuoi = ex.Message;
			}
		}
		public void OnPost()
		{
			try
			{
				if (string.IsNullOrEmpty(Keyword)) Keyword = "";
				DanhSachMatHang = _xuLyMatHang.DocDanhSachMatHang(Keyword);

			}
			catch (Exception ex)
			{
				chuoi = ex.Message;
			}
		}
	}
}
