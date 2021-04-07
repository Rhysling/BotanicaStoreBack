using BotanicaStoreBack.Services.FiltersAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Models.Core
{
	[TypeScriptModel]
	public class UserClient
	{
		public string Email { get; set; }
		public string FullName { get; set; }
		public string Token { get; set; }
		public bool IsAdmin { get; set; }
	}
}
