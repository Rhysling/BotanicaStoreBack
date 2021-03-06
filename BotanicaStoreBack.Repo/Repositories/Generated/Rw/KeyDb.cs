using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class KeyDb : RepositoryBase
	{
		public KeyDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public bool Insert(Key entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(Key entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(string id)
		{
			db.Delete<Key>((object)id);
			return true;
		}

		public bool Delete(IEnumerable<string> ids)
		{
			foreach (string id in ids)
			{
				db.Delete<Key>(id);
			}
			return true;
		}

		public bool Destroy(string id)
		{
			db.Delete<Key>((object)id);
			return true;
		}


		public Key FindBy(string id)
		{
			return db.SingleOrDefaultById<Key>((object)id);
		}

		public IEnumerable<Key> All()
		{
			return db.Fetch<Key>(" ");
		}

		public string MaxId()
		{
			return db.Single<string>("SELECT MAX(Id) FROM [Keys]");
		}
	}
}	
	
