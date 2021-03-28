using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{
	public class UserDb : RepositoryBase, IUserDb
	{
		public UserDb(IOptions<AppSettings> options)
			: base(options)
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

		public IEnumerable<User> All()
		{
			return db.Fetch<User>(" ");
		}

	}
}	

