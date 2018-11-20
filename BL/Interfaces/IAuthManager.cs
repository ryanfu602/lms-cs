using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
	public interface IAuthManager
	{
		User FindUser(string userName, string passwordHash);
	}
}
