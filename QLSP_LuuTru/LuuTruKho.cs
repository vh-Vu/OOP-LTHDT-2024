using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace QLSP_LuuTru
{
	public class LuuTruKho: ILuuTruKho
    {
		string _filePath = @"Data\Kho.json";
        public void LuuDanhSach(List<SanPhamLuuKho> dsspKho)
		{
			StreamWriter file = new StreamWriter(_filePath);
			var ds = JsonConvert.SerializeObject(dsspKho);
			file.Write(ds);
			file.Close();
		}

		public List<SanPhamLuuKho> DocDanhSach()
		{
			StreamReader file = new StreamReader(_filePath);
			string json = file.ReadToEnd();
			var  ds = JsonConvert.DeserializeObject<List<SanPhamLuuKho>>(json);
			file.Close();
			return ds;
		}


    }
}
