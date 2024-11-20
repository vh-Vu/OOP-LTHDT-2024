using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.Category
{
    public class MH_ThemMatHangModel : PageModel
    {
        [BindProperty]
        public string TenMatHang { get; set; }
        public string Chuoi = string.Empty;
        IXuLyMatHang _xuLyMatHang;
        public MH_ThemMatHangModel() : base()
        {
            _xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();
        }
        public void OnGet()
        {
            Chuoi = "Vui long ten mat hang";
        }
        public void OnPost()
        {
            try
            {
                MatHang mh = new MatHang(TenMatHang);
                _xuLyMatHang.ThemMatHang(mh);
                Chuoi = "Them thanh cong";
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
