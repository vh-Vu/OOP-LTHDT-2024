using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.PurchaseInvoice
{
    public class MH_XoaHoaDonNhapModel : PageModel
    {
        private IXuLyHoaDon _xuLyHoaDon;
        public HoaDon HoaDon { get; set; }
        [BindProperty(SupportsGet =true)] public int ma { get; set; }

        public string Chuoi = string.Empty;

		public MH_XoaHoaDonNhapModel() : base()
        {
            _xuLyHoaDon = ObjectCreater.TaoDoiTuongXuLyHoaDonNhap();

		}
        public void OnGet()
        {
            try
            {
                if (ma == 0) throw new Exception("Mã hóa đơn không hợp lệ");
                HoaDon = _xuLyHoaDon.DocHoaDon(ma) ?? throw new Exception("Không tìm thấy hóa đơn này");
                if (HoaDon.XacNhan) throw new Exception("Sản phẩm không thể bị xóa");
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
                if (ma == 0) throw new Exception("Mã hóa đơn không hợp lệ");
                HoaDon = _xuLyHoaDon.DocHoaDon(ma) ?? throw new Exception("Không tìm thấy hóa đơn này");
                if (HoaDon.XacNhan) throw new Exception("Sản phẩm không thể bị xóa");
                _xuLyHoaDon.XoaHoaDon(HoaDon);
				Response.Redirect("MH_DanhSachHoaDonNhap");
			}
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
