using BotanicaStoreBack.Repo.Models;
using NPoco;
using System;
using System.Data.SqlClient;
using System.Text;

namespace BotanicaStoreBack.Runner.Runs
{
	public static class DtConversion
	{
		public static string FromShoppingListAdmin()
		{
			var sb = new StringBuilder();

			using (var db = new NPoco.Database("Server=localhost;Database=BotanicaStoreDb;Trusted_Connection=True;", DatabaseType.SqlServer2012, SqlClientFactory.Instance))
			{
				var sm = db.Fetch<vwShoppingListSummary>("");

				string tzn = "Pacific Standard Time";

				foreach (var s in sm)
				{
					sb.AppendLine($"{s.CreatedDate} - {s.CreatedDate.Kind}");
					try
					{
						TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById(tzn);
						DateTime pstTime = TimeZoneInfo.ConvertTimeFromUtc(s.CreatedDate, pstZone);
						sb.AppendLine($"Local: {pstTime:M/d/yy h:mm tt} {(pstZone.IsDaylightSavingTime(pstTime) ? "PDT" : "PST")}.");
					}
					catch (ArgumentException)
					{
						sb.AppendLine("Input time must be Utc.");
					}
					catch (TimeZoneNotFoundException)
					{
						sb.AppendLine($"The registry does not define the {tzn} zone.");
					}
					catch (InvalidTimeZoneException)
					{
						sb.AppendLine($"Registry data on the {tzn} zone has been corrupted.");
					}
					sb.AppendLine();
				}

				//sb.AppendLine($"{s.CreatedDate} - {s.CreatedDate.Kind}");
				//sb.AppendLine($"{s.CreatedDate} - {s.LastUpdateDate} - {(s.EmailedDate.HasValue ? s.EmailedDate.Value : "open")}");
				//sb.AppendLine($"Local: {pstTime} {(pstZone.IsDaylightSavingTime(pstTime) ? pstZone.DaylightName : pstZone.StandardName)}.");
			}

			return sb.ToString();
		}
	}
}
