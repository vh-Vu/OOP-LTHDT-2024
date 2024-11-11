using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages
{
    public class MH_SuaMatHangModel : PageModel
    {
        private IXuLyMatHang _xuLyMatHang;
        public MatHang MatHang { get; set; }
        [BindProperty(SupportsGet = true)]
        public int MaMH { get; set; }
        [BindProperty]
        public string TenMatHang { get; set; }
        public string Chuoi =string.Empty;
        public MH_SuaMatHangModel(): base()
        {
            _xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();

		}
        public void OnGet()
        {
            if(MaMH == 0)
            {
                Chuoi = "Ma mat hang khong hop le";
                return;
            }
			MatHang = _xuLyMatHang.DocMatHang(MaMH);
            if (MatHang == null) Chuoi = "Khong tim thay mat hang nay";
        }
        public void OnPost() {
            try
            {
				if (MaMH == 0)
				{
					Chuoi = "Ma mat hang khong hop le";
					return;
				}
                if (string.IsNullOrEmpty(TenMatHang)) throw new Exception("Ten mat hang khong hop le");
				MatHang = _xuLyMatHang.DocMatHang(MaMH);
				if (MatHang == null) Chuoi = "Khong tim thay mat hang nay";
                else
                {
                    MatHang.TenMH = TenMatHang;
                    _xuLyMatHang.SuaMatHang(MatHang);
                    Response.Redirect("/MH_DanhSachMatHang");
                }

			}
			catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
