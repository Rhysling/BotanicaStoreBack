using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class UserDb : RepositoryBase
	{
		public UserDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public int Save(User entity)
		{
			db.Save<User>(entity);
			return entity.UserId;
		}

		public bool Save(IEnumerable<User> items)
		{
			foreach (User item in items)
			{
				db.Save<User>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<User>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<User>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<User>(id);
			return true;
		}


		public User FindById(int id)
		{
			return db.SingleOrDefaultById<User>(id);
		}

		public User FindByEmail(string email)
		{
			return db.FirstOrDefault<User>("WHERE Email = @0", email);
		}

		public List<vwUserDetail> AllDetails()
		{
			return db.Fetch<vwUserDetail>(" ");
		}

	}
}	

