using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
	public interface ILecturerManager
	{
		Lecturer CreateLecturer(Lecturer lecturer);

		Lecturer GetLecturerById(int id);

		List<Lecturer> GetAllLecturer();

		LecturerSearchDto SearchLecturer(SearchAttribute search);

		Lecturer DeleteLecturerById(int id);

		Lecturer UpdateLecturerById(int id, Lecturer lecturer);

		List<Course> getLecturerCourseById(int id);
		int CreateLecturerCourse( LecturerCourse lc);
		int DeleteLecturerCourseById(int lecturerId, int courseId);
	}
}
