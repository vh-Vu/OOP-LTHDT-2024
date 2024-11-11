using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;
using System.Diagnostics.Eventing.Reader;

namespace OOP_LTHDT_2024.Pages
{
    public class MH_DanhSachSanPhamModel : PageModel
    {
        public List<SanPham> DanhSachSanPham { get; set; }
        public IXuLySanPham _xuLySanPham;
        [BindProperty]
		public string Keyword { get; set; }
		public string chuoi = string.Empty;
        public MH_DanhSachSanPhamModel() : base()
        {
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
        }
        public void OnGet()
        {
			try
			{
				DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();

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
				DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham(Keyword);

			}catch(Exception ex)
            {
                chuoi = ex.Message;
            }
		}
	}
}
