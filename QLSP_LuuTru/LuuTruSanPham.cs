using QLSP_Entity;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace QLSP_LuuTru
{
	public class LuuTruSanPham: ILuuTruSanPham
	{
		private const string FilePath = @"D:\sanpham.json";
		public void LuuSanPham(SanPham s)
		{
			List<SanPham> dsSanPham = DocDanhSach();
			int maxId = 0;
			foreach(SanPham item in  dsSanPham)
			{
				if(item.MaSP >maxId) maxId = item.MaSP;
			}
			s.MaSP = maxId+1;
			dsSanPham.Add(s);
			LuuDanhSach(dsSanPham);
		}

		public List<SanPham> DocDanhSach()
		{
			StreamReader file = new StreamReader(FilePath);
			string json = file.ReadToEnd();
			List<SanPham> dsSanPham = JsonConvert.DeserializeObject<List<SanPham>>(json);
			file.Close();
			return dsSanPham;
		}
		public void LuuDanhSach(List<SanPham> ds)
		{
			string dsSanPhamMoi = JsonConvert.SerializeObject(ds);
			StreamWriter file = new StreamWriter(FilePath);
			file.Write(dsSanPhamMoi);
			file.Close();
		}
		public SanPham TimSanPhamTheoTen(string ten)
		{
			List<SanPham> dsSanPham = DocDanhSach();
			foreach (SanPham item in dsSanPham)
			{
				if (item.Ten == ten) return item;
			}
			return null;
		}
	}
}
