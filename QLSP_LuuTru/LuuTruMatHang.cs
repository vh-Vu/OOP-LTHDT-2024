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
	public class LuuTruMatHang : ILuuTru<MatHang>
	{
		string filepath = @"D:\mathang.json";
		string nextID = @"D:\MHID.txt";

		public List<MatHang> DocDanhSach()
		{
			StreamReader file = new StreamReader(filepath);
			string data = file.ReadToEnd();
			List<MatHang> dsMatHang = JsonConvert.DeserializeObject<List<MatHang>>(data);
			file.Close();
			return dsMatHang;

		}

		public void Them(MatHang matHang)
		{
			StreamReader reader = new StreamReader(nextID);
			int id = int.Parse(reader.ReadToEnd());
			reader.Close();
			matHang.MaMH= id;
			StreamWriter writer = new StreamWriter(nextID);
			writer.Write(++id);
			writer.Close();
			var dsMatHang = DocDanhSach();
			dsMatHang.Add(matHang);
			LuuDanhSach(dsMatHang);
		}

		public void LuuDanhSach(List<MatHang> ds)
		{
			string dsSanPhamMoi = JsonConvert.SerializeObject(ds);
			StreamWriter file = new StreamWriter(filepath);
			file.Write(dsSanPhamMoi);
			file.Close();
		}

		public MatHang TimTheoTen(string ten)
		{
			List<MatHang> dsMatHang = DocDanhSach();
			foreach (MatHang item in dsMatHang)
			{
				if (item.TenMH == ten) return item;
			}
			return null;
		}
	}
}
