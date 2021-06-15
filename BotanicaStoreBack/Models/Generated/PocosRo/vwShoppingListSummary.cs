using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwShoppingListSummary")]
	[ExplicitColumns]
	public partial class vwShoppingListSummary : BotanicaStoreBackDB.Record<vwShoppingListSummary>
	{
		string createdDateFormatted = null;
		string lastUpdateDateFormatted = null;
		string emailedDateFormatted = null;


		[NPoco.Column]
		public int WlId { get; set; }

		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		public DateTime CreatedDate { get; set; }

		[NPoco.Column]
		public DateTime LastUpdateDate { get; set; }

		[NPoco.Column]
		public DateTime? EmailedDate { get; set; }

		[NPoco.Column]
		public bool IsClosed { get; set; }

		[NPoco.Column]
		public string UserFullName { get; set; }

		[NPoco.Column]
		public string Email { get; set; }

		[NPoco.Column]
		public int TotalCount { get; set; }

		[NPoco.Column]
		public decimal TotalPretax { get; set; }


		public string CreatedDateFormatted
		{
			get
			{
				if (createdDateFormatted is null)
					createdDateFormatted = FormatDate(CreatedDate);

				return createdDateFormatted;
			}
		}

		public string LastUpdateDateFormatted
		{
			get
			{
				if (lastUpdateDateFormatted is null)
					lastUpdateDateFormatted = FormatDate(LastUpdateDate);

				return lastUpdateDateFormatted;
			}
		}

		public string EmailedDateFormatted
		{
			get
			{
				if (emailedDateFormatted is null)
					emailedDateFormatted = EmailedDate.HasValue ? FormatDate(EmailedDate.Value) : "open";

				return emailedDateFormatted;
			}
		}


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
