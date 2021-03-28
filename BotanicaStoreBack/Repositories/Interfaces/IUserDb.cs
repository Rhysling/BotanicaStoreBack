using BotanicaStoreBack.Models;
using System.Collections.Generic;

namespace BotanicaStoreBack.Repos
{
	public interface IUserDb
	{
		IEnumerable<User> All();
		bool Delete(IEnumerable<int> ids);
		bool Delete(int id);
		bool Destroy(int id);
		User FindByEmail(string email);
		User FindById(int id);
		bool Save(IEnumerable<User> items);
		int Save(User entity);
	}
}