using BotanicaStoreBack.Runner.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Runner.Runs
{
	public static class Test
	{
		public static string DtFormats()
		{
			var lst = new List<DateTime> {
				new DateTime(2021, 4, 28, 13, 23, 45),
				new DateTime(2021, 5, 1, 0, 1, 59),
				new DateTime(2021, 5, 12, 0, 0, 0)
			};

			return string.Join("\r\n", lst.Select(a => $"{a.ToShortDateString()} {a.ToShortTimeString()} -- {Formatters.DateTimeFormatter(a)}"));
		}
	}
}
