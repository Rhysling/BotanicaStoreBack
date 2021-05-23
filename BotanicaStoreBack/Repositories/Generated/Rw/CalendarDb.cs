using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{
	public class CalendarDb : RepositoryBase
	{
		public CalendarDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public int Save(Calendar entity)
		{
			db.Save<Calendar>(entity);
			return entity.ItemId;
		}

		public bool Save(IEnumerable<Calendar> items)
		{
			foreach (Calendar item in items)
			{
				db.Save<Calendar>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Calendar>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Calendar>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Calendar>(id);
			return true;
		}


		public List<Calendar> AllFuture()
		{
			string refDate = DateTime.Now.ToShortDateString();
			string sql = $"WHERE (BeginDate >= '{refDate}') OR (EndDate >= '{refDate}') ORDER BY BeginDate";
			return db.Fetch<Calendar>(sql);
		}

		public Calendar NextFuture()
		{
			return AllFuture().FirstOrDefault();
		}

		public List<Calendar> All()
		{
			return db.Fetch<Calendar>("ORDER BY BeginDate DESC");
		}


		public void ReseedKey()
		{
			string sql = "DECLARE @@MaxId int; ";
			sql += "SELECT @@MaxId = MAX(ItemId) FROM Calendar; ";
			sql += "DBCC CHECKIDENT ('Calendar', RESEED, @@MaxId) WITH NO_INFOMSGS;";

			db.Execute(sql);
		}

	}
}	

