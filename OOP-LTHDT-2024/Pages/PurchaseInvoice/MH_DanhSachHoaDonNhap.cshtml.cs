using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP_LTHDT_2024.Pages.PurchaseInvoice
{
    public class MH_DanhSachHoaDonNhapModel : PageModel
    {
        private IXuLyHoaDon _xulyHoaDon;
        public List<HoaDon> DanhSachHoaDon {  get; set; }
       
        public string Chuoi = string.Empty;
        [BindProperty] public DateOnly fromDate {  get; set; }
		[BindProperty] public DateOnly toDate { get; set; }

		public MH_DanhSachHoaDonNhapModel() :base() {
            _xulyHoaDon = ObjectCreater.TaoDoiTuongXuLyHoaDonNhap();
        }

		public void OnGet()
        {
            try
            {
				DanhSachHoaDon = _xulyHoaDon.DocDanhSach();

			}
			catch (Exception ex)
			{
				Chuoi = ex.Message;
			}
		}
        public void OnPost()
        {
			try
			{
				if (fromDate == null && toDate == null) DanhSachHoaDon = _xulyHoaDon.DocDanhSach();
				if (fromDate == null) DanhSachHoaDon = _xulyHoaDon.DocDanhSach(toDate: toDate);
				else if (toDate == null) DanhSachHoaDon = _xulyHoaDon.DocDanhSach(fromDate);
				else DanhSachHoaDon = _xulyHoaDon.DocDanhSach(fromDate,toDate);

			}
			catch (Exception ex)
			{
				Chuoi = ex.Message;
			}
		}
    }
}
