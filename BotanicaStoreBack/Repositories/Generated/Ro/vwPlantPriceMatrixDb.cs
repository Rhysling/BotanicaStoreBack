using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class vwPlantPriceMatrixDb : RepositoryBase
	{
		public vwPlantPriceMatrixDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public IEnumerable<vwPlantPriceMatrix> All()
		{
			return db.Fetch<vwPlantPriceMatrix>(" ");
		}

		//Example - filtered list:
		public List<vwPlantPriceMatrix> FullListForPlant(int plantId)
		{
			return db.Fetch<vwPlantPriceMatrix>("WHERE (PlantId=@0) OR (PlantId IS null) ORDER BY SortOrder", plantId);
		}
		

		// More methods here ***
	}
}	
