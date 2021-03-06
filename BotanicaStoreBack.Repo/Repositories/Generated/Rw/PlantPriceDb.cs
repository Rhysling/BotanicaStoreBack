using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class PlantPriceDb : RepositoryBase
	{
		public PlantPriceDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public List<PlantPrice> GetAllForPlant(int plantId)
		{
			return db.Fetch<PlantPrice>("WHERE (PlantId = @0)", plantId);
		}

		public bool UpdateAllForPlant(int plantId, List<PlantPrice> plantPrices)
		{
			db.Execute("DELETE FROM PlantPrices WHERE (PlantId = @0)", plantId);

			if ((plantPrices is not null) && plantPrices.Any())
			{
				var pp = plantPrices.Where(a => a.Price is not null).Select(a => { a.PlantId = plantId; return a; });

				foreach (var p in pp)
					db.Save(p);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<PlantPrice>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<PlantPrice>(id);
			}
			return true;
		}

	}
}	
	
