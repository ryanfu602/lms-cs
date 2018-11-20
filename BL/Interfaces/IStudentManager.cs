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

		List<StudentDto> GetStudentByPage(int startid, int maxrecord, string str, string order, string flag);

		Student DeleteStudentById( int id );

		Student ModifyStudentById(int id, Student student );

		StudentCourse CreateStudentCourse(StudentCourse studentcourse);


	}
}
