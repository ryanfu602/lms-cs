using BL.Interfaces;
using Data.Database;
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
    public class StudentController : ApiController
    {

		private readonly IStudentManager _studentmanager;

		public StudentController(IStudentManager studentmanager)
		{
			_studentmanager = studentmanager;
		}

		[HttpPost]
		[Route("api/student/searchstudent")]
		public IHttpActionResult Post(StudentSearchDto s)
		{
			return Ok( _studentmanager.GetStudentByPage(s.StartId,s.MaxRecord,s.SearchString,s.Order,s.Flag));
		}


		// GET: api/Student
		public IHttpActionResult Get()
        {
			return Ok( _studentmanager.GetAllStudents());
        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
			var student = _studentmanager.GetStudentById(id);
			
	
			if (student == null)
			{
				return NotFound();
			}
			return Ok(student);
        }

        // POST: api/Student
        public IHttpActionResult Post(Student student)
        {

			if (_studentmanager.CreateStudent(student) != null)
			{
				return Ok(student);
			}
			else
			{
				return BadRequest("Students already exist");
			}
			
        }


		[HttpPost]
		[Route("api/student/createstudentcourse")]
		public IHttpActionResult Post(StudentCourse sc)
		{

			if (_studentmanager.CreateStudentCourse(sc) != null)
			{
				return Ok(sc);
			}
			else
			{
				return BadRequest("StudentCourse already exist");
			}

		}


		// PUT: api/Student/5
		public IHttpActionResult Put( int id, Student student )
        {
			var std = _studentmanager.ModifyStudentById(id, student);
			if ( std!= null)
			{
				return Ok(std);
			}
			else
			{
				return BadRequest("The student does not exist");
			}
		}

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {
			var student = _studentmanager.DeleteStudentById(id);
			if (student == null)
			{
				return NotFound();
			}
			return Ok();
        }
    }
}
