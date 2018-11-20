﻿using AutoMapper;
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


		public StudentSearchDto SearchStudent(SearchAttribute search)
		{
			if (search.PageNumber == 0)
			{
				search.PageNumber = 1;
			}
			if (search.PageSize == 0)
			{
				search.PageSize = 10;
			}
			var std = _studentRepository.Records.Where(x => x.FirstName.Contains(search.SearchValue) || x.LastName.Contains(search.SearchValue) || x.Email.Contains(search.SearchValue));
			var count = (search.PageNumber - 1) * search.PageSize;
			var total = std.Count();
			/* default by  id,asc*/
		
			if (search.SortString == "firstname")
			{
				if (search.SortOrder == "desc")
				{
				   std= std.OrderByDescending(x => x.FirstName).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.FirstName).Skip(count).Take(search.PageSize);
				}
			}
			else if (search.SortString == "lastname")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.LastName).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.LastName).Skip(count).Take(search.PageSize);
				}
			}
			else if (search.SortString == "email")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.Email).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.Email).Skip(count).Take(search.PageSize);
				}				
			}
			else if (search.SortString == "dateofbirth")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.DateOfBirth).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.DateOfBirth).Skip(count).Take(search.PageSize);
				}
			}
			else if (search.SortString == "credit")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.Credit).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.Credit).Skip(count).Take(search.PageSize);
				}
			}
			else if (search.SortString == "gender")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.Gender).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.Gender).Skip(count).Take(search.PageSize);
				}
			}
			else
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.Id).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.Id).Skip(count).Take(search.PageSize);
				}
			}

			var SearchResult = new StudentSearchDto
			{
				PageSize = search.PageSize,
				TotalPage = total / search.PageSize + (total % search.PageSize == 0 ? 0 : 1),
				TotalNum = total
			};

			SearchResult.PageNumber = search.PageNumber > SearchResult.TotalPage ? 1 : search.PageNumber;

			SearchResult.Students = Mapper.Map<List<Student>, List<StudentDto>>(std.ToList());
			return SearchResult;
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
