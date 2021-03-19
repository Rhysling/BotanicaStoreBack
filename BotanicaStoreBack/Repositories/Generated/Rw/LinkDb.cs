using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStoreBack.Models;

namespace BotanicaStoreBack.Repositories
{ 
	public class LinkDb : Repositories.Core.IIdentityRepository<Link>
	{
		private NPoco.Database db = new NPoco.Database(Services.AppSettings.ConnectionString, DatabaseType.SqlServer2008) { Mapper = new Core.CustomTypeMapper() };

		public int Save(Link entity)
		{
			db.Save<Link>(entity);
			return entity.LinkId;
		}

		public bool Save(IEnumerable<Link> items)
		{
			foreach (Link item in items)
			{
				db.Save<Link>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Link>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Link>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Link>(id);
			return true;
		}


		public Link FindBy(int id)
		{
			return db.SingleOrDefaultById<Link>(id);
		}

		public IEnumerable<Link> All()
		{
			return db.Fetch<Link>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(LinkId) FROM Links; ";
			sql += "DBCC CHECKIDENT ('Links', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

