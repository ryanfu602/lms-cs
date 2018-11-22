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
	[Authorize]
	public class LecturerController : ApiController
	{
		private readonly ILecturerManager _lecturermanager;

		public LecturerController(ILecturerManager lecturermanager)
		{
			_lecturermanager = lecturermanager;
		}


		[HttpGet]
		[Route("api/lecturer")]
		public IHttpActionResult Get(string sortString = "id", string sortOrder = "asc", string searchValue = "", int pageSize = 10, int pageNumber = 1)
		{
			SearchAttribute search = new SearchAttribute()
			{
				SearchValue = searchValue,
				SortOrder = sortOrder,
				SortString = sortString,
				PageNumber = pageNumber,
				PageSize = pageSize
			};
			LecturerSearchDto lecturer = _lecturermanager.SearchLecturer(search);

			return Ok(lecturer);
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



		[HttpPost]
		[Route("api/lecturer/createlecturercourse")]
		public IHttpActionResult Post(LecturerCourse lc)
		{
			var ret = _lecturermanager.CreateLecturerCourse(lc);
			if (ret == 0)
			{
				return Ok();
			}
			else if (ret == 1)
			{
				return BadRequest("Lecturer does not existd");
			}
			else if (ret == 2)
			{
				return BadRequest("Course  does not existd");
			}
			else if (ret == 3)
			{
				return BadRequest("Only one course can be selectd");
			}


			return BadRequest("an unkown error");

		}

		[HttpDelete]
		[Route("api/lecturer/deletelecturercourse")]
		public IHttpActionResult Deletelc(int lecturerId,int courseId)
		{
			var lc = _lecturermanager.DeleteLecturerCourseById(lecturerId,courseId);
			if (lc == 1)
			{
				return BadRequest("LecturerCourse does not existd");
			}
			return Ok();
		}

		[HttpGet]
		[Route("api/lecturer/getlecturercourse")]
		public IHttpActionResult Getlc(int lecturerId)
		{
			var lc = _lecturermanager.getLecturerCourseById(lecturerId);
			if (lc != null)
			{
				return Ok(lc);
			}
			return NotFound();
			
		}


	}
	
}
