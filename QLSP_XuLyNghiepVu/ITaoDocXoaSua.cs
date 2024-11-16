using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_XuLyNghiepVu
{
	public interface ITaoDocXoaSua<T>
	{
		void Tao(T item);
		T DocMotDonVi(int ma);
		void Sua(T item);
		void Xoa(T item);
		List<T> DocDanhSach(string keyword = "");
	}
}
