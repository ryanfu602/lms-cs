using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
	public interface ICourseManager
	{
		Course CreateCourse(Course course);

		Course GetCourseById(int id);

		List<Course> GetAllCourse();

		List<Course> GetCourseByPage(int startid, int maxrecord, string str, string order, string flag);

		Course DeleteCourseById(int id);

		Course UpdateCourserById(int id, Course course);
	}
}
