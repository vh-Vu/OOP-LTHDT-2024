using Newtonsoft.Json;
using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
    public class LuuTruThongKe: ILuuTruThongKe
    {
        string _filePath = @"Data\ThongKeKho.json";
        public void LuuDanhSachThongKe(List<int[]> ThongKe)
        {
			StreamWriter file = new StreamWriter(_filePath);
            var ds = JsonConvert.SerializeObject(ThongKe);
            file.Write(ds);
            file.Close();
        }

        public List<int[]> DocDanhSachThongKe()
        {   
            StreamReader file = new StreamReader(_filePath);
            string json = file.ReadToEnd();
            var ds = JsonConvert.DeserializeObject<List<int[]>>(json);
            file.Close();
            return ds;
        }
    }
}
