using BL.Interfaces;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    public class LecturerController : ApiController
    {
		private readonly ILecturerManager _lecturermanager;

		public LecturerController(ILecturerManager lecturermanager)
		{
			_lecturermanager = lecturermanager;
		}

		[HttpPost]
		[Route("api/lecturer/searchlecturer")]
		public IHttpActionResult Post(StudentSearchDto s)
		{
			return Ok(_lecturermanager.GetLecturerByPage(s.StartId, s.MaxRecord, s.SearchString, s.Order, s.Flag));
		}


		// GET: api/Student
		public IHttpActionResult Get()
		{
			return Ok(_lecturermanager.GetAllLecturer());
		}

		// GET: api/Student/5
		public IHttpActionResult Get(int id)
		{
			var let = _lecturermanager.GetLecturerById(id);
			if (let == null)
			{
				return NotFound();
			}
			return Ok(let);
		}

		// POST: 
		public IHttpActionResult Post(Lecturer lecturer)
		{

			if (_lecturermanager.CreateLecturer(lecturer) != null)
			{
				return Ok(lecturer);
			}
			else
			{
				return BadRequest("Lecturer already exist");
			}

		}

		// PUT: api/Student/5
		public IHttpActionResult Put(int id, Lecturer lecturer)
		{
			var let = _lecturermanager.UpdateLecturerById(id, lecturer);
			if (let != null)
			{
				return Ok(let);
			}
			else
			{
				return BadRequest("The lecturer does not exist");
			}
		}

		// DELETE: api/Student/5
		public IHttpActionResult Delete(int id)
		{
			var let = _lecturermanager.DeleteLecturerById(id);
			if (let == null)
			{
				return NotFound();
			}
			return Ok(let);
		}
	}
}
