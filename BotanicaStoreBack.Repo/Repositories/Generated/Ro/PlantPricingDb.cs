using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class PlantPricingDb : RepositoryBase
	{
		public PlantPricingDb(ConnStr connStr)
			: base(connStr.Value)
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
