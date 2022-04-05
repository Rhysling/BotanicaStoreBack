using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class LinkDb : RepositoryBase
	{
		public LinkDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

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

		public bool UnDelete(int id)
		{
			string sql = $"UPDATE Links SET IsDeleted = 0 WHERE (LinkId = {id})";
			db.Execute(sql);
			return true;
		}

		public bool Delete(int id)
		{
			string sql = $"UPDATE Links SET IsDeleted = 1 WHERE (LinkId = {id})";
			db.Execute(sql);
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


		public List<Link> All(bool includeDeleted = false)
		{
			string sql = includeDeleted ? "" : "WHERE (IsDeleted = 0) ";
			sql += "ORDER BY SortOrder, Title";

			return db.Fetch<Link>(sql);
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

