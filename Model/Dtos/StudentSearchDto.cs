using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
	public class StudentSearchDto
	{
		public int StartId { get; set; }
		public int MaxRecord{ get; set; }
		public string SearchString{ get; set; }
		public string Order { get; set; }
		public string Flag { get; set; }
	}
}
