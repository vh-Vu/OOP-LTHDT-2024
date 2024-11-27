using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.PurchaseInvoice
{
    public class MH_ThemHoaDonNhapModel : PageModel
    {
		private IXuLySanPham _xuLySanPham;
		private IXuLyHoaDon _xuLyHoaDon;
        public List<SanPham> DanhSachSanPham { get;set; }
		[BindProperty]  public List<SPHoaDon> SPHoaDon { get;set; }
        public string Chuoi = string.Empty;
		public string Message = string.Empty;
		[BindProperty] public string TenKhachHang { get; set; }
		[BindProperty] public DateOnly NgayTaoHD { get; set; }
		[BindProperty] public int SDT { get; set; }
		[BindProperty] public string DiaChi { get; set; }

		public MH_ThemHoaDonNhapModel() :base() { 
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
            _xuLyHoaDon = ObjectCreater.TaoDoiTuongXuLyHoaDonNhap();

        }
        public void OnGet()
        {
			DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
			Chuoi = "Vui long day du thong tin";
        }
        public void OnPost()
        {
			try { 			
				DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
				if ( SPHoaDon.Count != DanhSachSanPham.Count) throw new Exception("Số lượng sản phẩm trong hóa đơn không hợp lệ");

				var HD = new HoaDon(TenKhachHang, NgayTaoHD, SDT, DiaChi);
				_xuLyHoaDon.ThemHoaDon(HD,SPHoaDon);

				Chuoi = "Thêm thành công!";
				Message = "Bạn cần xác nhận nhập hàng ở giao diện quản lý Danh Sách Hóa Đơn";


			}
			catch (Exception ex)
			{
				Chuoi = ex.Message;
			}
		}
    }
}
