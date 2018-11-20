﻿using Data.Database;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
	public class LecturerCoursesRepository : GenericRepository<LecturerCourse>, ILecturerCoursesRepository
	{
		public LecturerCoursesRepository(LMSEntities context) : base(context)
		{

		}
	}
}
