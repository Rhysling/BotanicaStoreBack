using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStoreBack.Models;

namespace BotanicaStoreBack.Repositories
{ 
	public class SubscriberDb : Repositories.Core.IIdentityRepository<Subscriber>
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public int Save(Subscriber entity)
		{
			db.Save<Subscriber>(entity);
			return entity.ItemId;
		}

		public bool Save(IEnumerable<Subscriber> items)
		{
			foreach (Subscriber item in items)
			{
				db.Save<Subscriber>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Subscriber>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Subscriber>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Subscriber>(id);
			return true;
		}


		public Subscriber FindBy(int id)
		{
			return db.SingleOrDefaultById<Subscriber>(id);
		}

		public IEnumerable<Subscriber> All()
		{
			return db.Fetch<Subscriber>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(ItemId) FROM Subscribers; ";
			sql += "DBCC CHECKIDENT ('Subscribers', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

