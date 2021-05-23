using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Runner.Demo
{
	public static class Formatters
	{
		public static string DateTimeFormatter(DateTime dt)
		{
			return dt.ToString("M/d/yyyy-h:mm tt");
		}

	}
}
