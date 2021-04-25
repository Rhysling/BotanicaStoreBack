using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{
	public class vwPlantPriceSummaryDb : RepositoryBase, IvwPlantPriceSummaryDb
	{
		public vwPlantPriceSummaryDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public List<vwPlantPriceSummary> All()
		{
			return db.Fetch<vwPlantPriceSummary>("ORDER BY Genus, Species");
		}

		//Example - filtered list:
		public IEnumerable<vwPlantPriceSummary> FilteredList(string str1, string str2)
		{
			return db.Fetch<vwPlantPriceSummary>("WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}


		// More methods here ***
	}
}	
