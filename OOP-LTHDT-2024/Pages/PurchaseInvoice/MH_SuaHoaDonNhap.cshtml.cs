using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.PurchaseInvoice
{
    public class MH_SuaHoaDonNhapModel : PageModel
    {
        private IXuLyHoaDon _xuLyHoaDon;
        private IXuLySanPham _xuLySanPham;
        [BindProperty(SupportsGet =true)]public int ma {  get; set; }
        public HoaDon HoaDon { get; set; }
		[BindProperty] public List<int?> SoLuong { get; set; }
		[BindProperty] public string TenKhachHang { get; set; }
		[BindProperty] public DateOnly NgayTaoHD { get; set; }
		[BindProperty] public int SDT { get; set; }
		[BindProperty] public string DiaChi { get; set; }
		public List<SanPham> DanhSachSanPham { get; set; }  
        public string Chuoi = string.Empty;
        public MH_SuaHoaDonNhapModel(): base()
        {
            _xuLyHoaDon = ObjectCreater.TaoDoiTuongXuLyHoaDonNhap();
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
        }

		public void OnGet()
        {
            try
            {
                if (ma == 0) throw new Exception("Mã hóa đơn không hợp lệ");
                HoaDon = _xuLyHoaDon.DocHoaDon(ma) ?? throw new Exception("Không tìm thấy hóa đơn này");
                if (HoaDon.XacNhan) throw new Exception("Sản phẩm không thể bị sửa");
                DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();

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
                if (HoaDon.XacNhan) throw new Exception("Sản phẩm không thể bị sửa");
                DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
				if (SoLuong.Count == 0 || SoLuong.Count != DanhSachSanPham.Count) throw new Exception("Số lượng sản phẩm trong hóa đơn không hợp lệ");
				HoaDon.CapNhat(TenKhachHang, NgayTaoHD, SDT, DiaChi);
				_xuLyHoaDon.SuaHoaDon(HoaDon, SoLuong);
                Response.Redirect("MH_DanhSachHoaDonNhap");
			}
			catch (Exception ex)
			{
				Chuoi = ex.Message;
			}
		}
	}
}
