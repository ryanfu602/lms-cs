using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
	public class LecturerSearchDto
	{
		public List<LecturerDto> Lecturers { get; set; }
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public int TotalPage { get; set; }
		public int TotalNum { get; set; }
	}
}
