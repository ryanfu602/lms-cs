using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
	public class StudentCourseDto
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public string FistName { get; set; }
		public string LastName { get; set; }
		public int CourseId { get; set; }
		public string Title { get; set; }
	}
}
