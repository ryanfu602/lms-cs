using Data.Database;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class LecturerCoursesRepository : GenericRepository<LecturerCourse>, ILecturerCoursesRepository
	{
		public LecturerCoursesRepository(LMSEntities context) : base(context)
		{

		}

		public LecturerCourse getLecturerCourseById(int id)
		{
			return Records.FirstOrDefault(x => x.CourseId == id);
		}

		public LMSEntities Context => _context;

		public int GetLecturerCourseNumber(int lecturerId, int courseId)
		{
			return Records.Where(x => x.LecturerId == lecturerId && x.CourseId == courseId).Count();
		}
		public LecturerCourse GetLecturerCourse(int lecturerId, int courseId)
		{
			return Records.FirstOrDefault(x => x.LecturerId == lecturerId && x.CourseId == courseId);
		}
	}
}
