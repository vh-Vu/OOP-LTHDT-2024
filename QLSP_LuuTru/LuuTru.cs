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
		private string _lastTimeUpdate;
		public LuuTru(string filePath, string IDFile,string LastTimeEditFile) {
			this._filePath = filePath;
			this._IDFile = IDFile;
			this._lastTimeUpdate = LastTimeEditFile;
		}

		public int CapPhatID()
		{
			int id = int.Parse(File.ReadAllText(_IDFile));
			File.WriteAllText(_IDFile, (++id).ToString());
			return id;
		}
		public void Them(T t)
		{
			List<T> ds = DocDanhSach();
			ds.Add(t);
			LuuDanhSach(ds);
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
			SuaThoiGianCapNhat();
		}
		public T TimTheoTen(string ten)
		{
			List<T> ds = DocDanhSach();
			foreach (T item in ds)
			{
				if (item.Ten == ten) return item;
			}
			return default;
		}


		public void Xoa(int ma)
		{
			List<T> ds = DocDanhSach();
			for (int i = 0; i < ds.Count; i++)
			{
				if (ds[i].Ma == ma)
				{
					ds[i].Xoa();
					break;
				}
			}
			LuuDanhSach(ds);
		}

		private void SuaThoiGianCapNhat()
		{
			string currentTime = DateTime.Now.ToString();
			File.WriteAllText(_lastTimeUpdate, currentTime);
		}
		public DateTime DocThoiGianCapNhat()
		{
			var lastTime = DateTime.Parse(File.ReadAllText(_lastTimeUpdate));
			return lastTime;

		}
	}
}
