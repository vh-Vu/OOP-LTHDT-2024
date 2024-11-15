/*using Newtonsoft.Json;
using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
	*//*public class LuuTruMatHang : ILuuTru<MatHang>
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
			int id = int.Parse(File.ReadAllText(nextID));
			matHang.MaMH= id;
			File.WriteAllText(nextID, (++id).ToString());

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

		public void Xoa(int ma)
		{
			List<MatHang> ds = DocDanhSach();
			for (int i = 0; i < ds.Count; i++)
			{
				if (ds[i].MaMH == ma)
				{
					ds.Remove(ds[i]);
					break;
				}
			}
			LuuDanhSach(ds);
		}
	}*//*
}
*/