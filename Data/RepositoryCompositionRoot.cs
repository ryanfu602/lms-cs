﻿using Autofac;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	namespace Data
	{
		public class RepositoryCompositionRoot
		{
			public static void RegisterTypes(ContainerBuilder builder)
			{
				var currentAssembly = Assembly.GetExecutingAssembly();

				builder.RegisterAssemblyTypes(currentAssembly)
					.Where(t => t.Name.EndsWith("Repository"))
					.AsImplementedInterfaces();
				builder.RegisterType<LMSEntities>().AsSelf().InstancePerRequest();
			}
		}
	}
}
