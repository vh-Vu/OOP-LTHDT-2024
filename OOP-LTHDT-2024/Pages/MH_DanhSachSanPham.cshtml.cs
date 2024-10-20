using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages
{
    public class MH_DanhSachSanPhamModel : PageModel
    {
        public List<SanPham> DanhSachSanPham { get; set; }
        public IXuLySanPham _xuLySanPham;
        public MH_DanhSachSanPhamModel() : base()
        {
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
        }
        public void OnGet()
        {
            DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
		}
    }
}
