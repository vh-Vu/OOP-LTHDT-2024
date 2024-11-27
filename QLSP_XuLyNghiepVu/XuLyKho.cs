using QLSP_Entity;
using QLSP_LuuTru;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public class XuLyKho : IXuLyKho
	{
		private ILuuTruKho _luuTruKho;
		private IXuLyThongKeKho _xuLyThongKeKho;

        public XuLyKho(ILuuTruKho luuTruKho, IXuLyThongKeKho xuLyThongKeKho)
		{
			this._luuTruKho = luuTruKho;
			this._xuLyThongKeKho = xuLyThongKeKho;

        }
        public void NhapKho(List<SPHoaDon> dsNhapKho)
		{
			var dsspkho = _luuTruKho.DocDanhSach();
			foreach( var sanPhamNhapKho in dsNhapKho)
			{
				bool tonTaiSanPham = false;
				bool CapNhatThongKe = false;
				for(int j = 0; j < dsspkho.Count; j++)
				{
					if (dsspkho[j].Ma == sanPhamNhapKho.Ma)
					{
						CapNhatThongKe = true;
						_xuLyThongKeKho.CapNhatThongTin(sanPhamNhapKho.Ma, sanPhamNhapKho.SoLuong);
						if (dsspkho[j].HanSuDung == sanPhamNhapKho.HanSuDung){
							tonTaiSanPham = true;
							dsspkho[j].Nhap(sanPhamNhapKho.SoLuong);
							break;
						}
					}
				}
				if (!tonTaiSanPham)
				{
					var SanPhamLuuKho = new SanPhamLuuKho(sanPhamNhapKho.Ma, sanPhamNhapKho.SoLuong, sanPhamNhapKho.HanSuDung);
					dsspkho.Add(SanPhamLuuKho);
				}
				if (!CapNhatThongKe)
					_xuLyThongKeKho.ThemSanPhamMoi(sanPhamNhapKho.Ma, sanPhamNhapKho.SoLuong);

			}
			_luuTruKho.LuuDanhSach(dsspkho);
		}
		public void XuatKho(List<SPHoaDon> dsXuatKho)
		{
			var dsspkho = _luuTruKho.DocDanhSach();
			foreach (var sanPhamXuatKho in dsXuatKho)
			{
				var DSSanPhamKhoTheoMa = new List<int>();

				for (int j = 0; j < dsspkho.Count; j++)
				{
					if (dsspkho[j].Ma == sanPhamXuatKho.Ma)
						DSSanPhamKhoTheoMa.Add(j);

				}
				if (DSSanPhamKhoTheoMa.Count <1) throw new Exception("Sản phẩm không tồn tại trong kho");

				// Đếm sản phẩm còn tồn kho và còn hạn sử dụng
				int SanPhamTonKho = 0;
				for (int j = DSSanPhamKhoTheoMa.Count - 1; j >= 0; j--)
				{
					int i = DSSanPhamKhoTheoMa[j];
					if (!dsspkho[i].ConHanSuDung()) DSSanPhamKhoTheoMa.RemoveAt(j);
					else SanPhamTonKho += dsspkho[i].TonKho;				
				}
				if (DSSanPhamKhoTheoMa.Count < 1) throw new Exception("Chỉ còn lại sản phẩm hết hạn");
				if (SanPhamTonKho < sanPhamXuatKho.SoLuong) throw new Exception("Số lượng hàng tồn kho không đủ đáp ứng");
				//Xuất các lần lượt sản phẩm trong kho 
				int SanPhamCanXuat = sanPhamXuatKho.SoLuong;
				foreach (var num in DSSanPhamKhoTheoMa)
				{
					if (SanPhamCanXuat == 0) break;
					int soLuong = dsspkho[num].TonKho;
					if (SanPhamCanXuat > soLuong) SanPhamCanXuat -= soLuong;
					else
					{
						soLuong = SanPhamCanXuat;
						SanPhamCanXuat = 0;
					}
							
					dsspkho[num].Xuat(soLuong);
				}
                _xuLyThongKeKho.CapNhatThongTin(sanPhamXuatKho.Ma, -sanPhamXuatKho.SoLuong);

            }
            _luuTruKho.LuuDanhSach(dsspkho);
		}

		public void XoaSanPhamKho(int Ma)
		{
			var dsspkho = _luuTruKho.DocDanhSach();
			for(int i = dsspkho.Count -1; i >= 0; i--)
			{
				if (dsspkho[i].Ma == Ma) {
					dsspkho.RemoveAt(i);
				}
			}
			_luuTruKho.LuuDanhSach(dsspkho);
		}
		public List<SanPhamLuuKho> DocDanhSachKho()
		{
			return _luuTruKho.DocDanhSach();
		}

		public int SanPhamHetHan(int Ma)
		{
			var dsspKho = _luuTruKho.DocDanhSach();
			int ketQua = 0;
			foreach(var spk  in dsspKho) 
				if (!spk.ConHanSuDung() && spk.Ma == Ma) ketQua +=spk.TonKho; 
			return ketQua;
		}


	}
}
