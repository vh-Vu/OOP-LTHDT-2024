using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages
{
    public class MH_ThemSanPhamModel : PageModel
    {
        [BindProperty]
        public string TenSanPham { get; set; }
        [BindProperty]
		public int Gia { get; set; }
        public string Chuoi { get; set; } = string.Empty;
        private IXuLySanPham _xuLySanPham;

        public MH_ThemSanPhamModel() : base() {
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
		}
        public void OnGet()
        {
            Chuoi = "Vui long nhap san pham";
        }

		public void OnPost()
        {
            try
            {
				SanPham sanPham = new SanPham(TenSanPham, Gia);
				_xuLySanPham.ThemSanPham(sanPham);
				Chuoi = "Them thanh cong";
			}
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
		}
    }
}