using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
	public interface IStudentManager
	{
		Student CreateStudent(Student student);

		StudentDto GetStudentById(int id);

		List<StudentDto> GetAllStudents();

		StudentSearchDto SearchStudent(SearchAttribute search);

		Student DeleteStudentById( int id );

		Student ModifyStudentById(int id, Student student );

		int CreateStudentCourse(StudentCourse studentcourse);

		List<StudentCourse> GetStudentCourse(int id);

		StudentCourse DeleteStudentCourse(int id);


	}
}
