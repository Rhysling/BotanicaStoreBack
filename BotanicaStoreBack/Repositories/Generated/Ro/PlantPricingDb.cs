using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{
	public class PlantPricingDb : RepositoryBase
	{
		public PlantPricingDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public List<vwPlantPriceSummary> AllSummaries()
		{
			return db.Fetch<vwPlantPriceSummary>("ORDER BY Genus, Species");
		}

		public List<vwPlantsAvailable> AllAvailable()
		{
			return db.Fetch<vwPlantsAvailable> ("ORDER BY PlantName, SortOrder");
		}

		// *** For vwPlantPriceMatrix

		public List<vwPlantPriceMatrix> GetMatrixForPlant(int plantId)
		{
			string sql = $@"
SELECT
	ps.Id AS PotSizeId,
	ps.PotDescription,
	ps.PotShorthand,
	ps.SortOrder,
	{plantId} AS PlantId,
	pp.Price,
	isnull(pp.IsAvailable, 0) AS IsAvailable

FROM
	PotSizes ps

	LEFT OUTER JOIN
	(
	SELECT
		PotSizeId,
		Price,
		IsAvailable
	FROM
		PlantPrices
	WHERE
		(PlantId = {plantId})
	)  pp
	ON (ps.Id = pp.PotSizeId)

ORDER BY
	ps.SortOrder";

			return db.Fetch<vwPlantPriceMatrix>(sql);
		}


		// More methods here ***
	}
}	
