namespace BotanicaStoreBack.Repo.Models.Core;

internal static class Utils
{
	internal static string ToShortPT(DateTime? dateIn)
	{
		DateTime dt = dateIn ?? new DateTime(1950, 1, 1);

		if (dt.CompareTo(DateTime.Now.AddYears(-30)) < 0) return "None";

		TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
		DateTime pstDateTime = TimeZoneInfo.ConvertTimeFromUtc(dt.ToUniversalTime(), pstZone);
		return pstDateTime.ToString("M/d/yy-h:mmtt") + (pstZone.IsDaylightSavingTime(pstDateTime) ? " PDT" : " PST");
	}

}
