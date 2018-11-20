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
	public class LecturerManager : ILecturerManager
	{
		private ILecturerRepository _lecturerRepository;

		public LecturerManager(ILecturerRepository lecturerRepository)
		{
			_lecturerRepository = lecturerRepository;
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

		public List<Lecturer> GetLecturerByPage(int startid, int maxrecord, string str, string order, string flag)
		{
			if (startid <= 0)
			{
				startid = 1;
			}

			if (maxrecord <= 0)
			{
				maxrecord = 10;
			}

			var lecturer = _lecturerRepository.Records.Where(x => x.Name.Contains(str) || x.StaffNumber.Contains(str) || x.Email.Contains(str));

			/* default by  id,asc*/
			if (order == "name")
			{
				if (flag == "desc")
				{
					return lecturer.OrderByDescending(x => x.Name).Skip(startid - 1).Take(maxrecord).ToList();
				}
				return lecturer.OrderBy(x => x.Name).Skip(startid - 1).Take(maxrecord).ToList();
			}
			else if (order == "language")
			{
				if (flag == "desc")
				{
					return lecturer.OrderByDescending(x => x.StaffNumber).Skip(startid - 1).Take(maxrecord).ToList();
				}
				return lecturer.OrderBy(x => x.StaffNumber).Skip(startid - 1).Take(maxrecord).ToList();
			}
			else
			{
				if (flag == "desc")
				{
					return lecturer.OrderByDescending(x => x.Id).Skip(startid - 1).Take(maxrecord).ToList();
				}
				return lecturer.OrderBy(x => x.Id).Skip(startid - 1).Take(maxrecord).ToList();
			}
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
	}
}
