using QLSP_Entity;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace QLSP_LuuTru
{
	public class LuuTruSanPham
	{
		private const string FilePath = @"D:\sanpham.json";
		public void LuuSanPham(SanPham s)
		{
			List<SanPham> dsSanPham = DocDanhSach();
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
	}
}
