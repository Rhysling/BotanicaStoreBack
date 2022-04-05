


using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{ 
	public class DummyTestTableDb : RepositoryBase
	{
		public DummyTestTableDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public bool Insert(DummyTestTable entity)
		{
			db.Insert(entity);
			return true;
		}

		public bool Update(DummyTestTable entity)
		{
			db.Update(entity);
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<DummyTestTable>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<DummyTestTable>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<DummyTestTable>(id);
			return true;
		}


		public DummyTestTable FindBy(int id)
		{
			return db.SingleOrDefaultById<DummyTestTable>(id);
		}

		public IEnumerable<DummyTestTable> All()
		{
			return db.Fetch<DummyTestTable>(" ");
		}

		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [DummyTestTable]");
		}
	}
}	
	
