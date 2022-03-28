using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Models.Core
{
	public class AppSettings
	{
		public string BotanicaStoreDb_ConnectionString { get; set; }
		public string BotanicaStoreAdminPw { get; set; }
		public double TaxRate { get; set; }
		public AS_Jwt Jwt { get; set; }
		public AS_Mailgun Mailgun { get; set; }
		public bool IsDev { get; set; }
	}

	public class AS_Jwt
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
	}

	public class AS_Mailgun
	{
		public string AuthValue { get; set; }
		public string BaseUrl { get; set; }
		public string Domain { get; set; }
		public string FromEmail { get; set; }
	}
}
