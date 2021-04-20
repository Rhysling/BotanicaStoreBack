using BotanicaStoreBack.Models;
using System.Collections.Generic;

namespace BotanicaStoreBack.Repos
{
	public interface IPlantDb
	{
		List<Plant> All();
		bool Delete(IEnumerable<int> ids);
		bool Delete(int id);
		bool Destroy(int id);
		Plant FindBy(int id);
		bool Save(IEnumerable<Plant> items);
		int Save(Plant entity);
	}
}