using Data.Database;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
		public StudentRepository(LMSEntities context) : base(context)
		{

		}

		public LMSEntities Context => _context;
	}
}
