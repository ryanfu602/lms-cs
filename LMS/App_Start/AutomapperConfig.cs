using AutoMapper;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App_Start
{
	public class AutomapperConfig
	{
		public static void Initialize()
		{
			Mapper.Initialize(config =>
			{
				config.CreateMap<Student, StudentDto>();

			});
		}
	}
}