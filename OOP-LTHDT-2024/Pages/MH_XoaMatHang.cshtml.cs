using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages
{
    public class MH_XoaMatHangModel : PageModel
    {
        private IXuLyMatHang _xuLyMatHang;
        public MatHang MatHang { get; set; }
        [BindProperty(SupportsGet =true)]
        public int MaMH { get; set; }
        public string Chuoi = string.Empty;
		public MH_XoaMatHangModel() :base() {
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
            if (MatHang == null) Chuoi = "Mat hang khong ton tai";
        }
        public void OnPost()
        {
            try
            {
				if (MaMH == 0)
				{
					Chuoi = "Ma mat hang khong hop le";
					return;
				}
				MatHang = _xuLyMatHang.DocMatHang(MaMH);
				if (MatHang == null) Chuoi = "Mat hang khong ton tai";
                else
                {
                    _xuLyMatHang.XoaMatHang(MatHang);
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
