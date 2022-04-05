using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStoreBack.Models;

namespace BotanicaStoreBack.Repositories
{ 
	public class ResourceIconDb	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public bool Insert(ResourceIcon entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(ResourceIcon entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(string id)
		{
			db.Delete<ResourceIcon>((object)id);
			return true;
		}

		public bool Delete(IEnumerable<string> ids)
		{
			foreach (string id in ids)
			{
				db.Delete<ResourceIcon>(id);
			}
			return true;
		}

		public bool Destroy(string id)
		{
			db.Delete<ResourceIcon>((object)id);
			return true;
		}


		public ResourceIcon FindBy(string id)
		{
			return db.SingleOrDefaultById<ResourceIcon>((object)id);
		}

		public IEnumerable<ResourceIcon> All()
		{
			return db.Fetch<ResourceIcon>(" ");
		}

		public string MaxId()
		{
			return db.Single<string>("SELECT MAX(Id) FROM [ResourceIcons]");
		}
	}
}	
	
