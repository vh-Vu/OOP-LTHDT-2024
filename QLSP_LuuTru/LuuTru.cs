using Newtonsoft.Json;
using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
	public class LuuTru <T>: ILuuTru<T> where T : IEntity
	{
		private string _filePath;
		private string _IDFile;
		public LuuTru(string filePath, string IDFile) {
			this._filePath = filePath;
			this._IDFile = IDFile;
		}
		public void Them(T t)
		{
			int id = int.Parse(File.ReadAllText(_IDFile));
			t.Ma = id;
			File.WriteAllText(_IDFile, (++id).ToString());

			List<T> dsSanPham = DocDanhSach();
			dsSanPham.Add(t);
			LuuDanhSach(dsSanPham);
		}
		public List<T> DocDanhSach()
		{
			StreamReader file = new StreamReader(_filePath);
			string json = file.ReadToEnd();
			List<T> ds = JsonConvert.DeserializeObject<List<T>>(json);
			file.Close();
			return ds;
		}
		public void LuuDanhSach(List<T> ds)
		{
			string dsMoi = JsonConvert.SerializeObject(ds);
			StreamWriter file = new StreamWriter(_filePath);
			file.Write(dsMoi);
			file.Close();
		}
		public T TimTheoTen(string ten)
		{
			List<T> dsMatHang = DocDanhSach();
			foreach (T item in dsMatHang)
			{
				if (item.Ten == ten) return item;
			}
			return default;
		}


		public void Xoa(int ma)
		{
			List<T> dsSanPham = DocDanhSach();
			for (int i = 0; i < dsSanPham.Count; i++)
			{
				if (dsSanPham[i].Ma == ma)
				{
					dsSanPham.Remove(dsSanPham[i]);
					break;
				}
			}
			LuuDanhSach(dsSanPham);
		}
	}
}
