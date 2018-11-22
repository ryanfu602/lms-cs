using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public interface IStudentCoursesRepository : IGenericRepository<StudentCourse>
	{
		int GetByStudentCourseId(int studentId, int courseId);
		List<StudentCourse> GetStudentCourse(int id);
		int getStudentCourseNumber(int courseId);
	}
}
