using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;
using System.Linq;

namespace OOP_LTHDT_2024.Pages.Product
{
    public class MH_ThemSanPhamModel : PageModel
    {
        [BindProperty]
        public string TenSanPham { get; set; }
        [BindProperty]
		public int Gia { get; set; }
		[BindProperty]
		public string CongTySanXuat { get; set; }
		[BindProperty]
		public int NamSanXuat { get; set; }
		[BindProperty]
		public DateOnly HanSuDung { get; set; }
		[BindProperty]
		public int MatHang { get; set; }
		public string Chuoi { get; set; } = string.Empty;
        private IXuLySanPham _xuLySanPham;
        private IXuLyMatHang _xuLyMatHang;
        public List<MatHang> DsMatHang { get; set; }

        public MH_ThemSanPhamModel() : base() {
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
			_xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();
		}
        public void OnGet()
        {
            Chuoi = "Vui long nhap san pham";
            DsMatHang = _xuLyMatHang.DocDanhSachMatHang();
            if(DsMatHang.Count == 0)
            {
                Chuoi = "Khong co mat hang kha dung, vui long tao mat hang truoc";
            }
        }

		public void OnPost()
        {
            try
            {
				DsMatHang = _xuLyMatHang.DocDanhSachMatHang();
                if (DsMatHang.Count == 0) throw new Exception("Khong co mat hang kha dung, vui long tao mat hang truoc");
				SanPham sanPham = new SanPham(TenSanPham, Gia, HanSuDung, NamSanXuat, CongTySanXuat, MatHang);
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
