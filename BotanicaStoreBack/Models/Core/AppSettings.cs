using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Models.Core
{
	public class AppSettings
	{
		public string BotanicaStoreDb_ConnectionString { get; set; }
		public string AdminPw { get; set; }
		public AS_Jwt Jwt { get; set; }
	}

	public class AS_Jwt
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
	}
}
