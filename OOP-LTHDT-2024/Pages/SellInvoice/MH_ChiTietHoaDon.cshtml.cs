using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.SellInvoice
{
    public class MH_ChiTietHoaDonModel : PageModel
    {
        private IXuLyHoaDon _xuLyHoaDon;
        private IXuLySanPham _xuLySanPham;
        [BindProperty(SupportsGet =true)]public int ma {  get; set; }
        public HoaDon HoaDon{ get;set;}
        public string Chuoi = string.Empty;
		public MH_ChiTietHoaDonModel() : base()
        {
            _xuLyHoaDon = ObjectCreater.TaoDoiTuongXuLyHoaDonXuat();
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
		}
		public void OnGet()
        {
            try
            {
                if (ma == 0) throw new Exception("Mã sản phẩm không hợp lệ");
				HoaDon = _xuLyHoaDon.DocHoaDon(ma) ?? throw new Exception("Hóa đơn không tồn tại");

			}catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
        public void OnPost()
        {
            try
            {
				if (ma == 0) throw new Exception("Mã sản phẩm không hợp lệ");
				HoaDon = _xuLyHoaDon.DocHoaDon(ma) ?? throw new Exception("Hóa đơn không tồn tại");
				var lastTime = _xuLySanPham.DocThoiGianCapNhat();
				if (HoaDon.NgayCapNhatHoaDon < lastTime) throw new Exception("Có thông tin sản phẩm đã được cập nhật vui lòng cập nhật lại hóa đơn");
				_xuLyHoaDon.XacNhanHoaDon(HoaDon,false);
                Response.Redirect("MH_DanhSachHoaDonXuat");
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
