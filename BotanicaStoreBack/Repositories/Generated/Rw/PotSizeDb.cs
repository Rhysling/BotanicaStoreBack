using System;
using System.Collections.Generic;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using Microsoft.Extensions.Options;

namespace BotanicaStoreBack.Repos
{ 
	public class PotSizeDb : RepositoryBase
	{
		public PotSizeDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public bool Insert(PotSize entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(PotSize entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<PotSize>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<PotSize>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<PotSize>(id);
			return true;
		}


		public PotSize FindBy(int id)
		{
			return db.SingleOrDefaultById<PotSize>(id);
		}

		public IEnumerable<PotSize> All()
		{
			return db.Fetch<PotSize>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [PotSizes]");
		}
	}
}	
	
