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

		List<Lecturer> GetLecturerByPage(int startid, int maxrecord, string str, string order, string flag);

		Lecturer DeleteLecturerById(int id);

		Lecturer UpdateLecturerById(int id, Lecturer lecturer);
	}
}
