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
		public List<MatHang> DanhSachMatHang { get; set; }

		private IXuLySanPham _xuLySanPham;
        private IXuLyMatHang _xuLyMatHang;
        [BindProperty]
		public string Keyword { get; set; }
		public string chuoi = string.Empty;
        public MH_DanhSachSanPhamModel() : base()
        {
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
			_xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();

		}
        public void OnGet()
        {
			try
			{
				DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
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
				DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham(Keyword);
				DanhSachMatHang = _xuLyMatHang.DocDanhSachMatHang();

			}
			catch (Exception ex)
            {
                chuoi = ex.Message;
            }
		}
	}
}
