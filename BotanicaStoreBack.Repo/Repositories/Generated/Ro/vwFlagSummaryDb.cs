using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{ 
	public class vwFlagSummaryDb : RepositoryBase
	{
		public vwFlagSummaryDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public IEnumerable<vwFlagSummary> All()
		{
			return db.Fetch<vwFlagSummary>("ORDER BY LastUpdate DESC");
		}

		//Example - filtered list:
		public IEnumerable<vwFlagSummary> FilteredList(string str1, string str2)
		{
			return db.Fetch<vwFlagSummary>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}
		

		// More methods here ***
	}
}	
