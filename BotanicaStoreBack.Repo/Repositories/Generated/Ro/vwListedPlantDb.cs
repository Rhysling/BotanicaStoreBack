using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class vwListedPlantDb : RepositoryBase
	{
		public vwListedPlantDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public vwListedPlant FeaturedPlant()
		{
			return db.Fetch<vwListedPlant>("WHERE (IsFeatured = 1)").FirstOrDefault();
		}

		public List<vwListedPlant> All()
		{
			return db.Fetch<vwListedPlant>("ORDER BY Genus, Species");
		}

		public Plant FindBySlug(string slug)
		{
			return db.FirstOrDefault<Plant>("WHERE (Slug = @0)", slug);
		}

		//Example - filtered list:
		public List<vwListedPlant> FilteredList(string str1, string str2)
		{
			return db.Fetch<vwListedPlant>("WHERE (v1=@p1) AND (v2=@p2)", new { p1 = str1, p2 = str2 });
		}


		// More methods here ***
	}
}	
