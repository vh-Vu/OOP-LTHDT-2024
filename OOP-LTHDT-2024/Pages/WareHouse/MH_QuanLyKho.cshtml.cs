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
        private IXuLyThongKeKho _xuLyThongKeKho { get; set; }
        public List<SanPham> DanhSachSanPham { get; set; }
        public List<SanPhamLuuKho> DanhSachSanPhamLuuKho {  get; set; }
        public List<MatHang> DanhSachMatHang { get; set; }
        public List<int[]> ThongKeSanPhamLuuKho { get; set; }
		public List<int[]> ThongKeSanPhamLuuKhoHetHanSuDung { get; set; }
        public int TongSoSanPhamHetHan = 0;
        public DateOnly Current = DateOnly.FromDateTime(DateTime.Now.Date);

        public MH_QuanLyKhoModel() : base()
        {
			_xuLySanPham = ObjectCreater.TaoDoiTuongXuLySanPham();
			_xuLyKho = ObjectCreater.TaoDoiTuongXuLyKho();
            _xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();
            _xuLyThongKeKho = ObjectCreater.TaoDoiTuongXyLyThongKeKho();

        }
		public void OnGet()
        {
			DanhSachSanPham = _xuLySanPham.DocDanhSachSanPham();
			DanhSachSanPhamLuuKho = _xuLyKho.DocDanhSachKho();
			DanhSachMatHang = _xuLyMatHang.DocDanhSachMatHang();
            ThongKeSanPhamLuuKho = _xuLyThongKeKho.DocDanhSachThongKe();
            ThongKeSanPhamLuuKhoHetHanSuDung = new List<int[]>();
            foreach(var splk  in ThongKeSanPhamLuuKho)
            {
                int soLuong = _xuLyKho.SanPhamHetHan(splk[0]);
                if(soLuong > 0)
                {
                    TongSoSanPhamHetHan += soLuong;
					ThongKeSanPhamLuuKhoHetHanSuDung.Add(new int[] { splk[0], soLuong });

				}
            }

		}
    }
}
