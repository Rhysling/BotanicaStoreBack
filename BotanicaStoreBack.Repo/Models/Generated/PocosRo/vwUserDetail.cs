using NPoco;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("vwUserDetails")]
	[ExplicitColumns]
	public partial class vwUserDetail : BotanicaStoreBackDB.Record<vwUserDetail>
	{
		[NPoco.Column] 
		public int UserId { get; set; }

		[NPoco.Column] 
		public string Email { get; set; }

		[NPoco.Column] 
		public string FullName { get; set; }

		[NPoco.Column] 
		public bool IsAdmin { get; set; }

		[NPoco.Column] 
		public DateTime CreatedDate { get; set; }

		[NPoco.Column] 
		public DateTime LastLoginDate { get; set; }

		[NPoco.Column] 
		public int LoginCount { get; set; }

		[NPoco.Column] 
		public int CountAll { get; set; }

		[NPoco.Column] 
		public int CountPending { get; set; }

		[NPoco.Column] 
		public int CountClosed { get; set; }


		public string CreatedDateFormatted => FormatDate(CreatedDate);
		
		public string LastLoginDateFormatted => FormatDate(LastLoginDate);

		private static string FormatDate(DateTime dt)
		{
			string tzn = "Pacific Standard Time";

			try
			{
				TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById(tzn);
				DateTime pstTime = TimeZoneInfo.ConvertTimeFromUtc(dt, pstZone);
				return $"{pstTime:M/d/yy h:mm tt} {(pstZone.IsDaylightSavingTime(pstTime) ? "PDT" : "PST")}";
			}
			catch (ArgumentException)
			{
				return "Input time must be Utc.";
			}
			catch (TimeZoneNotFoundException)
			{
				return $"The registry does not define the {tzn} zone.";
			}
			catch (InvalidTimeZoneException)
			{
				return $"Registry data on the {tzn} zone has been corrupted.";
			}
			catch
			{
				return "Someting went wrong formatting.";
			}
		}


	}
}
