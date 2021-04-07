using BotanicaStoreBack.Models;
using System.Collections.Generic;

namespace BotanicaStoreBack.Repos
{
	public interface IvwListedPlantDb
	{
		List<vwListedPlant> All();
		List<vwListedPlant> FilteredList(string str1, string str2);
	}
}