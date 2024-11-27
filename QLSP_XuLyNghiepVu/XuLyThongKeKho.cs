using QLSP_LuuTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
    public class XuLyThongKeKho : IXuLyThongKeKho
    {
        private ILuuTruThongKe _luuTruThongKe;
        public XuLyThongKeKho(ILuuTruThongKe luuTruThongKe)
        {
            this._luuTruThongKe = luuTruThongKe;
        }
        public void CapNhatThongTin(int Ma, int SoLuong)
        {
            var ThongKeKho = _luuTruThongKe.DocDanhSachThongKe();
            for (int i = 0; i < ThongKeKho.Count; i++)
            {
                if (ThongKeKho[i][0] == Ma)
                {
                    ThongKeKho[i][1] += SoLuong;
                    break;
                }
            }
            _luuTruThongKe.LuuDanhSachThongKe(ThongKeKho);
        }

        public void ThemSanPhamMoi(int Ma, int soLuong)
        {
            var ThongKeKho = _luuTruThongKe.DocDanhSachThongKe();
            ThongKeKho.Add(new int[] { Ma, soLuong });
			ThongKeKho.Sort((a, b) => a[0] - b[0]);
			_luuTruThongKe.LuuDanhSachThongKe(ThongKeKho);
        }

        public void XoaSanPhamKho(int Ma)
        {
            var ThongKeKho = _luuTruThongKe.DocDanhSachThongKe();
			for (int i = 0; i < ThongKeKho.Count; i++)
            {
                if (ThongKeKho[i][0] == Ma)
                {
                    if (ThongKeKho[i][1] > 0) throw new Exception("San pham con ton kho, khong the xoa");
                    ThongKeKho.RemoveAt(i);
                    break;
                }
            }
			_luuTruThongKe.LuuDanhSachThongKe(ThongKeKho);
		}

		public List<int[]> DocDanhSachThongKe()
        {
            return _luuTruThongKe.DocDanhSachThongKe();
        }

    }
}
