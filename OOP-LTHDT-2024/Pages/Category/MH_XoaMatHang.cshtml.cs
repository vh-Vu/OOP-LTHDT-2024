using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSP_Entity;
using QLSP_XuLyNghiepVu;

namespace OOP_LTHDT_2024.Pages.Category
{
    public class MH_XoaMatHangModel : PageModel
    {
        private IXuLyMatHang _xuLyMatHang;
        [BindProperty(SupportsGet = true)] public int MaMH { get; set; }
        public MatHang MatHang { get; set; }
        public string Chuoi = string.Empty;
        public MH_XoaMatHangModel() : base()
        {
            _xuLyMatHang = ObjectCreater.TaoDoiTuongXuLyMatHang();

        }
        public void OnGet()
        {
            if (MaMH == 0)
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
                    throw new Exception("Ma mat hang khong hop le");
                }
                MatHang = _xuLyMatHang.DocMatHang(MaMH);
                if (MatHang == null)
                {
                    throw new Exception("Mat hang khong ton tai");
                }
                if (MatHang.DanhSachSanPham.Count > 0)
                {
                    throw new Exception("Con san pham trong mat hang vui long chinh sua truoc khi xoa");
                }
                _xuLyMatHang.XoaMatHang(MatHang);
                Response.Redirect("/Category/MH_DanhSachMatHang");
            }
            catch (Exception ex)
            {
                Chuoi = ex.Message;
            }
        }
    }
}
