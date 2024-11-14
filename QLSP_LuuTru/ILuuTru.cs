using QLSP_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_LuuTru
{
	public interface ILuuTru<T>
	{
		List<T> DocDanhSach();
		void LuuDanhSach(List<T> ds);
		T TimTheoTen(string ten);

		void Them(T t);

	}
}
