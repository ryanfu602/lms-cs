using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
	public class StudentSearchDto
	{
		public List<StudentDto> Students { get; set; }
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public int TotalPage { get; set; }
		public int TotalNum { get; set; }
	}
}
