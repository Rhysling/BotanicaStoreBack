using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using Microsoft.Extensions.Options;

namespace BotanicaStoreBack.Repos
{ 
	public class PlantDb : RepositoryBase
	{
		public PlantDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public PlantDb(AppSettings options)
			: base(options)
		{
			//no op.
		}


		public int Save(Plant entity)
		{
			db.Save<Plant>(entity);
			return entity.PlantId;
		}

		public bool Save(IEnumerable<Plant> items)
		{
			foreach (Plant item in items)
			{
				db.Save<Plant>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Plant>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Plant>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Plant>(id);
			return true;
		}


		public Plant FindBy(int id)
		{
			return db.SingleOrDefaultById<Plant>(id);
		}

		public IEnumerable<Plant> All()
		{
			return db.Fetch<Plant>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(PlantId) FROM Plants; ";
			sql += "DBCC CHECKIDENT ('Plants', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

