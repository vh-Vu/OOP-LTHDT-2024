using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages
{
    public class MH_Sua_SanPhamModel : PageModel
    {

        public SanPham SanPham { get; set; }
        public List<MatHang> DsMatHang { get; set; }  
		private IXuLySanPham _xuLySanPham;
        private IXuLyMatHang _xuLyMatHang;
        
		[BindProperty (SupportsGet =true)]
		public int MaSp { get; set; }
		[BindProperty]
        public string TenSanPham { get; set; }
		[BindProperty]
        public int Gia { get; set; }
        [BindProperty]
        public string CongTySanXuat { get; set; }
		[BindProperty]

		public DateOnly HanSuDung { get; set; }
		[BindProperty]

		public int NamSanXuat { get; set; }
		[BindProperty]

		public int MatHang {  get; set; }
		public string Chuoi = string.Empty;
        public MH_Sua_SanPhamModel() : base() {
            _xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
            _xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();
        }

		public void OnGet()
        {
            if (MaSp == 0)
            {
                Chuoi = "Ma san pham khong hop le";
                return;
            }
            SanPham = _xuLySanPham.DocSanPham(MaSp);
            if (SanPham == null) Chuoi = "Khong tim thay san pham";
            else
				DsMatHang = _xuLyMatHang.DocDanhSachMatHang();

		}
        public void OnPost()
        {
            try
            {
                if (MaSp == 0) throw new Exception("Ma san pham khong hop le");
                   
                SanPham = _xuLySanPham.DocSanPham(MaSp);

                if (SanPham == null) throw new Exception("Khong tim thay san pham");
                DsMatHang = _xuLyMatHang.DocDanhSachMatHang();

				if (SanPham.MatHang != MatHang)
                {
                    if(!_xuLyMatHang.MaMatHangTonTai(MatHang))	throw new Exception ("Mat hang khong ton tai");
                    _xuLyMatHang.SanPhamThayDoiMatHang(SanPham, MatHang);
                }

                SanPham.Ten = TenSanPham;
                SanPham.Gia = Gia;
                SanPham.NamSanXuat = NamSanXuat;
                SanPham.HanSuDung = HanSuDung;
                SanPham.CongTySanXuat = CongTySanXuat;
                SanPham.KiemTraDieuKien();
				_xuLySanPham.SuaSanPham(SanPham);
                Response.Redirect("/MH_DanhSachSanPham");
                
            }
            catch (Exception e)
            {
                Chuoi = e.Message;
            }
        }
    }
}
