using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStoreBack.Models;

namespace BotanicaStoreBack.Repositories
{ 
	public class ResourceItemDb : Repositories.Core.IIdentityRepository<ResourceItem>
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public int Save(ResourceItem entity)
		{
			db.Save<ResourceItem>(entity);
			return entity.ItemId;
		}

		public bool Save(IEnumerable<ResourceItem> items)
		{
			foreach (ResourceItem item in items)
			{
				db.Save<ResourceItem>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<ResourceItem>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<ResourceItem>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<ResourceItem>(id);
			return true;
		}


		public ResourceItem FindBy(int id)
		{
			return db.SingleOrDefaultById<ResourceItem>(id);
		}

		public IEnumerable<ResourceItem> All()
		{
			return db.Fetch<ResourceItem>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(ItemId) FROM ResourceItems; ";
			sql += "DBCC CHECKIDENT ('ResourceItems', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

