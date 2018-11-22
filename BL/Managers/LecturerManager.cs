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
	public class LecturerManager : ILecturerManager
	{
		private ILecturerRepository _lecturerRepository;
		private ICourseRepository _courseRepository;
		private ILecturerCoursesRepository _lecturercourseRepository;

		public LecturerManager(ILecturerRepository lecturerRepository,ICourseRepository courseRepository, ILecturerCoursesRepository lecturercourseRepository)
		{
			_lecturerRepository = lecturerRepository;
			_courseRepository = courseRepository;
			_lecturercourseRepository = lecturercourseRepository;
		}

		public Lecturer CreateLecturer(Lecturer lecturer)
		{
			if (!_lecturerRepository.Records.Any(x => x.Email == lecturer.Email))
			{
				return (_lecturerRepository.Add(lecturer));
			}
			else
			{
				return null;
			}
		}

		public Lecturer DeleteLecturerById(int id)
		{
			var lecturer = _lecturerRepository.GetById(id);
			if (lecturer != null)
			{
				_lecturerRepository.Delete(lecturer);
			}

			return lecturer;
		}

		public List<Lecturer> GetAllLecturer()
		{
			return _lecturerRepository.GetAll().ToList();
		}

		public Lecturer GetLecturerById(int id)
		{
			return _lecturerRepository.GetById(id);
		}

		public LecturerSearchDto SearchLecturer(SearchAttribute search)
		{
			if (search.PageNumber == 0)
			{
				search.PageNumber = 1;
			}
			if (search.PageSize == 0)
			{
				search.PageSize = 10;
			}
			var std = _lecturerRepository.Records.Where(x => x.Name.Contains(search.SearchValue) || x.StaffNumber.Contains(search.SearchValue) || x.Email.Contains(search.SearchValue));
			var count = (search.PageNumber - 1) * search.PageSize;
			var total = std.Count();
			/* default by  id,asc*/

			if (search.SortString == "name")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.Name).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.Name).Skip(count).Take(search.PageSize);
				}
			}
			else if (search.SortString == "staffnumber")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.StaffNumber).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.StaffNumber).Skip(count).Take(search.PageSize);
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
			else if (search.SortString == "bibliography")
			{
				if (search.SortOrder == "desc")
				{
					std = std.OrderByDescending(x => x.Bibliography).Skip(count).Take(search.PageSize);
				}
				else
				{
					std = std.OrderBy(x => x.Bibliography).Skip(count).Take(search.PageSize);
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

			var SearchResult = new LecturerSearchDto
			{
				PageSize = search.PageSize,
				TotalPage = total / search.PageSize + (total % search.PageSize == 0 ? 0 : 1),
				TotalNum = total
			};

			SearchResult.PageNumber = search.PageNumber > SearchResult.TotalPage ? 1 : search.PageNumber;

			SearchResult.Lecturers = Mapper.Map<List<Lecturer>, List<LecturerDto>>(std.ToList());
			return SearchResult;
		}

		public Lecturer UpdateLecturerById(int id, Lecturer lecturer)
		{
			var let= _lecturerRepository.GetById(id);
			if (let != null)
			{
				let.Name = lecturer.Name;
				let.StaffNumber = lecturer.StaffNumber;
				let.Email = lecturer.Email;
				let.Bibliography = lecturer.Bibliography;
  
				return _lecturerRepository.Update(let);
			}
			return let;
		}


		public List<Course> getLecturerCourseById(int id) {
			var query = from c in _lecturerRepository.Context.Courses
						join lc in _lecturerRepository.Context.LecturerCourses on c.Id equals lc.CourseId
						where lc.LecturerId == id
						select c;
			return query.ToList();
		}


		public int CreateLecturerCourse(LecturerCourse lc)
		{
			var student = _lecturerRepository.GetById(lc.LecturerId);
			if (student == null)
			{
				return 1;
			}

			var course = _courseRepository.GetById(lc.CourseId);
			if (student == null)
			{
				return 2;
			}

			var count = _lecturercourseRepository.GetLecturerCourseNumber(lc.LecturerId, lc.CourseId);
			if (count > 0)
			{
				return 3;
			}


			_lecturercourseRepository.Add(lc);
			return 0;
		}
		public int DeleteLecturerCourseById(int lecturerId,int courseId)
		{
			var lecturercourse = _lecturercourseRepository.GetLecturerCourse(lecturerId, courseId);
			if (lecturercourse != null)
			{
				_lecturercourseRepository.Delete(lecturercourse);
			}
			else {
				return 1;
			}

			return 0;
		}
		

	}
}
