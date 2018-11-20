using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
	public interface IUserManager
	{
		UserDisplayDto CreateUser(UserRegisterDto user);
		User FindUser(string userName, string password);
	}
}
