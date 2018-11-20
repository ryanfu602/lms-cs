using BL.Interfaces;
using Data.Database;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    public class TestController : ApiController
    {

		private readonly IUserManager _userManager;

		public TestController(IUserManager userManager)
		{
			_userManager = userManager;
		}

		[HttpPost]
		[Route("api/test/createuser")]
		public IHttpActionResult Post(UserRegisterDto user)
		{
			var userDisplay = _userManager.CreateUser(user);
			return Ok(userDisplay);
		}



		[HttpGet]
		[Route("api/test")]
		public IHttpActionResult Test()
		{
			using (LMSEntities context = new LMSEntities())
			{
				var students = context.Students.ToList();
				return Ok(students);
			}
		}


        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
		
        }
    }
}
