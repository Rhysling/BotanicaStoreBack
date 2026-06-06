using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class CalendarDb : RepositoryBase
	{
		public CalendarDb(ConnStr connStr)
			: base(connStr.Value)
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
			string refDate = DateTime.Now.ToString("yyyy-MM-dd");
			string sql = $"WHERE (BeginDate >= '{refDate}') OR (EndDate >= '{refDate}') ORDER BY BeginDate";
			return db.Fetch<Calendar>(sql);
		}

		public Calendar? NextFuture()
		{
			return AllFuture().FirstOrDefault();
		}

		public List<Calendar> All()
		{
			return db.Fetch<Calendar>("ORDER BY BeginDate DESC");
		}


		public void ReseedKey()
		{
			string sql = "UPDATE sqlite_sequence SET seq = (SELECT COALESCE(MAX(ItemId), 0) FROM Calendar) WHERE name = 'Calendar'";
			db.Execute(sql);
		}

	}
}	

