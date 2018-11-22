using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public interface ILecturerCoursesRepository : IGenericRepository<LecturerCourse>
	{
		LecturerCourse getLecturerCourseById(int id);
		int GetLecturerCourseNumber(int lecturerId, int courseId);
		LecturerCourse GetLecturerCourse(int lecturerId, int courseId);
	}
}
