using BotanicaStoreBack.Models;
using System.Collections.Generic;

namespace BotanicaStoreBack.Repos
{
	public interface IvwPlantPriceSummaryDb
	{
		List<vwPlantPriceSummary> All();
		IEnumerable<vwPlantPriceSummary> FilteredList(string str1, string str2);
	}
}