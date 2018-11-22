using Data.Database;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class StudentCoursesRepository : GenericRepository<StudentCourse>, IStudentCoursesRepository
	{
		public StudentCoursesRepository(LMSEntities context) : base(context)
		{
			
		}

		public int GetByStudentCourseId(int studentId, int courseId)
		{
			return Records.Where(x => x.StudentId == studentId && x.CourseId == courseId).Count();
		}

		public List<StudentCourse> GetStudentCourse(int id)
		{
			return Records.Where(x => x.StudentId == id).ToList();
		}

		public int getStudentCourseNumber(int courseId)
		{
			return Records.Where(x => x.CourseId == courseId).Count();
		}
	}
}

