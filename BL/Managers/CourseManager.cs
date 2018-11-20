using AutoMapper;
using BL.Interfaces;
using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
	public class CourseManager : ICourseManager
	{

		private ICourseRepository _courseRepository;

		public CourseManager(ICourseRepository courseRepository)
		{
			_courseRepository = courseRepository;
		}
		public Course CreateCourse(Course course)
		{
			if (!_courseRepository.Records.Any(x => x.Title == course.Title))
			{
				return (_courseRepository.Add(course));
			}
			else
			{
				return null;
			}
		}

		public Course DeleteCourseById(int id)
		{
			var course = _courseRepository.GetById(id);
			if (course != null)
			{
				_courseRepository.Delete(course);
			}

			return course;
		}

		public List<Course> GetAllCourse()
		{
			return _courseRepository.GetAll().ToList();
		}

		public Course GetCourseById(int id)
		{
			return _courseRepository.GetById(id);
		}

		public List<Course> GetCourseByPage(int startid, int maxrecord, string str, string order, string flag)
		{
			if (startid <= 0)
			{
				startid = 1;
			}

			if (maxrecord <= 0)
			{
				maxrecord = 10;
			}

			var course = _courseRepository.Records.Where(x => x.Title.Contains(str) || x.Language.Contains(str) || x.Description.Contains(str));

			/* default by  id,asc*/
			if (order == "title")
			{
				if (flag == "desc")
				{
					return course.OrderByDescending(x => x.Title).Skip(startid - 1).Take(maxrecord).ToList();
				}
				return course.OrderBy(x => x.Title).Skip(startid - 1).Take(maxrecord).ToList();
			}
			else if (order == "language")
			{
				if (flag == "desc")
				{
					return course.OrderByDescending(x => x.Language).Skip(startid - 1).Take(maxrecord).ToList();
				}
				return course.OrderBy(x => x.Language).Skip(startid - 1).Take(maxrecord).ToList();
			}
			else
			{
				if (flag == "desc")
				{
					return course.OrderByDescending(x => x.Id).Skip(startid - 1).Take(maxrecord).ToList();
				}
				return course.OrderBy(x => x.Id).Skip(startid - 1).Take(maxrecord).ToList();
			}
		}

		public Course UpdateCourserById(int id, Course course)
		{
			var course1 = _courseRepository.GetById(id);
			if (course1 != null)
			{
				course1.Title = course.Title;
				course1.Description = course.Description;
				course1.Fee = course.Fee;
				course1.MaxStudent = course.MaxStudent;
				course1.Language = course.Language;

				return _courseRepository.Update(course1);
			}
			return course1;
		}
	}
}
