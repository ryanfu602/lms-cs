using BL.Interfaces;
using LMS.Filters;
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
	public class CourseController : ApiController
	{
		private readonly ICourseManager _coursemanager;

		public CourseController(ICourseManager coursemanager)
		{
			_coursemanager = coursemanager;
		}


		public IHttpActionResult Get()
		{
			return Ok(_coursemanager.GetAllCourse());
		}

		// GET: api/Student/5
		public IHttpActionResult Get(int id)
		{
			var course = _coursemanager.GetCourseById(id);
			if (course == null)
			{
				return NotFound();
			}
			return Ok(course);
		}

		// POST: api/Student
		public IHttpActionResult Post(Course course)
		{
			if (_coursemanager.CreateCourse(course) != null)
			{
				return Ok(course);
			}
			else
			{
				return BadRequest("Course already exist");
			}

		}

		// PUT: api/Student/5
		public IHttpActionResult Put(int id, Course course)
		{
			var course1 = _coursemanager.UpdateCourserById(id, course);
			if (course1 != null)
			{
				return Ok(course1);
			}
			else
			{
				return BadRequest("The course does not exist");
			}
		}

		// DELETE: api/Student/5
		public IHttpActionResult Delete(int id)
		{
			var course = _coursemanager.DeleteCourseById(id);
			if (course == null)
			{
				return NotFound();
			}
			return Ok(course );
		}
	}
}
