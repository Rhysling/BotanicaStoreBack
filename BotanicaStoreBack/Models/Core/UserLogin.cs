﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models.Core
{
	[TypeScriptModel]
	public class UserLogin
	{
		public string Email { get; set; }
		public string FullName { get; set; }
		public string Pw { get; set; }
	}
}
