using AutoMapper;
using BL.Interfaces;
using Data.Repositories;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
	public class StudentManager : IStudentManager
	{
		private IStudentRepository _studentRepository;
		private ICourseRepository _courseRepository;
		private IStudentCoursesRepository _studentcourseRepository;

		public StudentManager(IStudentRepository studentRepository, ICourseRepository courseRepository, IStudentCoursesRepository studentcourseRepository)
		{
			_studentRepository = studentRepository;
			_courseRepository = courseRepository;
			_studentcourseRepository = studentcourseRepository;
		}


		public Student CreateStudent(Student student)
		{
			if (!_studentRepository.Records.Any(x => x.Email == student.Email))
			{
				return(_studentRepository.Add(student));
			}
			else
			{
				return null;	
			}
		}

		public StudentDto GetStudentById(int id)
		{
			return Mapper.Map<Student, StudentDto>(_studentRepository.GetById(id));
		}

		public List<StudentDto> GetStudentByPage(int startid, int maxrecord, string str, string order,string flag)
		{
			if (startid <= 0)
			{
				startid = 1;
			}

			if (maxrecord <= 0)
			{
				maxrecord = 10;
			}

			var std = _studentRepository.Records.Where(x => x.FirstName.Contains(str) ||x.LastName.Contains(str) ||x.Email.Contains(str));

			/* default by  id,asc*/
			if (order == "name")
			{
				if (flag == "desc")
				{
					return Mapper.Map<List<Student>, List<StudentDto>>(std.OrderByDescending(x => x.FirstName).Skip(startid - 1).Take(maxrecord).ToList());
				}
				return Mapper.Map<List<Student>, List<StudentDto>>(std.OrderBy(x => x.FirstName).Skip(startid - 1).Take(maxrecord).ToList());
			}
			else if (order == "email")
			{
				if (flag == "desc")
				{
					return Mapper.Map<List<Student>, List<StudentDto>>(std.OrderByDescending(x => x.Email).Skip(startid - 1).Take(maxrecord).ToList());
				}
				return Mapper.Map<List<Student>, List<StudentDto>>(std.OrderBy(x => x.Email).Skip(startid - 1).Take(maxrecord).ToList());
			}
			else
			{
				if (flag == "desc")
				{
					return Mapper.Map<List<Student>, List<StudentDto>>(std.OrderByDescending(x => x.Id).Skip(startid - 1).Take(maxrecord).ToList());
				}
				return Mapper.Map<List<Student>, List<StudentDto>>(std.OrderBy(x => x.Id).Skip(startid - 1).Take(maxrecord).ToList());
			}
		}

		public Student DeleteStudentById(int id)
		{
			var student = _studentRepository.GetById(id);
			if (student != null)
			{
				_studentRepository.Delete(student);
			}
			
			return student;
		}

		public List<StudentDto> GetAllStudents()
		{
			return  Mapper.Map<List<Student>, List<StudentDto>>( _studentRepository.GetAll().ToList());
		}

		public Student ModifyStudentById(int id, Student student)
		{
			var std = _studentRepository.GetById(id);
			if (std != null)
			{
				std.FirstName = student.FirstName;
				std.LastName = student.LastName;
				std.Gender = student.Gender;
				std.DateOfBirth = student.DateOfBirth;
				std.Email = student.Email;
				std.Credit = student.Credit;
				return _studentRepository.Update(std);
			}
			return std;
		}

		public StudentCourse CreateStudentCourse(StudentCourse sc)
		{
			var student = _studentRepository.GetById(sc.StudentId);
			if (student == null)
			{
				return null;
			}

			var course = _courseRepository.GetById(sc.CourseId);
			if(student == null)
			{
				return null;
			}

			return (_studentcourseRepository.Add(sc));
		}
	}
}
