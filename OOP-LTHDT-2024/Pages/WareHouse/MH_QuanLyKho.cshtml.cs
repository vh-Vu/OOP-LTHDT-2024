using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.WareHouse
{
    public class MH_QuanLyKhoModel : PageModel
    {
        private IXuLyKho _xuLyKho { get; set; }
        private IXuLySanPham _xuLySanPham { get; set; }
        private IXuLyMatHang _xuLyMatHang { get; set; }
        public List<SanPham> DanhSachSanPham { get; set; }
        public List<SanPhamLuuKho> DanhSachSanPhamLuuKho {  get; set; }
        public List<MatHang> DanhSachMatHang { get; set; }
        public DateOnly CurrentDay { get; set; }   
        public MH_QuanLyKhoModel() : base()
        {
			_xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
			_xuLyKho = ObjectCreater.TaoDoiTuongXuLyKho();
            _xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();

		}
		public void OnGet()
        {
			CurrentDay = DateOnly.FromDateTime(DateTime.Now.Date);
			DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
			DanhSachSanPhamLuuKho = _xuLyKho.DocDanhSachKho();
			DanhSachMatHang = _xuLyMatHang.DocDanhSachMatHang();
		}
    }
}
