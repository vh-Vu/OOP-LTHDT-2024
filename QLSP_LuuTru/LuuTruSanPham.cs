﻿/*using QLSP_Entity;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace QLSP_LuuTru
{
	*//*public class LuuTruSanPham: ILuuTru<SanPham>
	{
		private const string FilePath = @"D:\sanpham.json";
		private const string nextID = @"D:\SPID.txt";
		public void Them(SanPham s)
		{
			int id = int.Parse(File.ReadAllText(nextID));
			s.MaSP = id;
			File.WriteAllText(nextID, (++id).ToString());

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
		public SanPham TimTheoTen(string ten)
		{
			List<SanPham> dsSanPham = DocDanhSach();
			foreach (SanPham item in dsSanPham)
			{
				if (item.Ten == ten) return item;
			}
			return null;
		}

		public void Xoa(int ma)
		{
			List<SanPham> dsSanPham = DocDanhSach();
			for (int i = 0; i < dsSanPham.Count; i++)
			{
				if (dsSanPham[i].MaSP == ma)
				{
					dsSanPham.Remove(dsSanPham[i]);
					break;
				}
			}
			LuuDanhSach(dsSanPham);
		}
	}*//*
}
*/