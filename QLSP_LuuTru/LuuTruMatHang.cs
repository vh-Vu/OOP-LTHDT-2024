using Newtonsoft.Json;
using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
	public class LuuTruMatHang : ILuuTruMatHang
	{
		string filepath = @"D:\mathang.json";

		public List<MatHang> DocDanhSachMatHang()
		{
			StreamReader file = new StreamReader(filepath);
			string data = file.ReadToEnd();
			List<MatHang> dsMatHang = JsonConvert.DeserializeObject<List<MatHang>>(data);
			file.Close();
			return dsMatHang;

		}

		public void ThemMatHang(MatHang matHang)
		{
			int maxId = 0;
			var dsMatHang = DocDanhSachMatHang();
			int soLuongMatHang = dsMatHang.Count;
			if (soLuongMatHang == 0) maxId = 1;
			else maxId = dsMatHang[soLuongMatHang - 1].MaMH+1;
			matHang.MaMH = maxId;
			dsMatHang.Add(matHang);
			LuuDanhSachMatHang(dsMatHang);
		}

		public void LuuDanhSachMatHang(List<MatHang> ds)
		{
			string dsSanPhamMoi = JsonConvert.SerializeObject(ds);
			StreamWriter file = new StreamWriter(filepath);
			file.Write(dsSanPhamMoi);
			file.Close();
		}
	}
}
