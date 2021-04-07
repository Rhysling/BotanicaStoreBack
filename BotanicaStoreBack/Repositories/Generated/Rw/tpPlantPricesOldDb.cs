using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class tpPlantPricesOldDb : RepositoryBase
	{
		public tpPlantPricesOldDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public int Save(tpPlantPricesOld entity)
		{
			db.Save<tpPlantPricesOld>(entity);
			return entity.PlantId;
		}

		public bool Save(IEnumerable<tpPlantPricesOld> items)
		{
			foreach (tpPlantPricesOld item in items)
			{
				db.Save<tpPlantPricesOld>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<tpPlantPricesOld>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<tpPlantPricesOld>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<tpPlantPricesOld>(id);
			return true;
		}


		public tpPlantPricesOld FindBy(int id)
		{
			return db.SingleOrDefaultById<tpPlantPricesOld>(id);
		}

		public IEnumerable<tpPlantPricesOld> All()
		{
			return db.Fetch<tpPlantPricesOld>(" ");
		}


		public void ReseedKey()
		{
			string sql ="DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(PlantId) FROM tpPlantPricesOld; ";
			sql += "DBCC CHECKIDENT ('tpPlantPricesOld', RESEED, @@MaxId) WITH NO_INFOMSGS;";
			
			db.Execute(sql);
		}

	}
}	

