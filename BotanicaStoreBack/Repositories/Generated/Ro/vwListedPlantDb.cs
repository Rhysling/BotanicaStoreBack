using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{
	public class vwListedPlantDb : RepositoryBase, IvwListedPlantDb
	{
		public vwListedPlantDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public List<vwListedPlant> All()
		{
			return db.Fetch<vwListedPlant>("ORDER BY Genus, Species");
		}

		//Example - filtered list:
		public List<vwListedPlant> FilteredList(string str1, string str2)
		{
			return db.Fetch<vwListedPlant>("WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}


		// More methods here ***
	}
}	
