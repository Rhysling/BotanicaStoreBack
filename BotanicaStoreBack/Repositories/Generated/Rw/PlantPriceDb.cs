using System;
using System.Collections.Generic;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using Microsoft.Extensions.Options;

namespace BotanicaStoreBack.Repos
{ 
	public class PlantPriceDb : RepositoryBase
	{
		public PlantPriceDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public bool Insert(PlantPrice entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(PlantPrice entity)
		{
			db.Update(entity);
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

		public bool Destroy(int id)
		{
			db.Delete<PlantPrice>(id);
			return true;
		}


		public PlantPrice FindBy(int id)
		{
			return db.SingleOrDefaultById<PlantPrice>(id);
		}

		public IEnumerable<PlantPrice> All()
		{
			return db.Fetch<PlantPrice>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [PlantPrices]");
		}
	}
}	
	
