using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class vwShoppingListSummaryDb : RepositoryBase
	{
		public vwShoppingListSummaryDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		
		public List<vwShoppingListSummary> GetAll(bool includeClosed)
		{
			string sql = includeClosed ? "" : "WHERE (IsClosed = 0)";
			sql += " ORDER BY LastUpdateDate DESC";

			return db.Fetch<vwShoppingListSummary>(sql);
		}

		public List<vwShoppingListItem> ItemsByListId(int listId)
		{
			string sql = $"WHERE (WlId = {listId}) ORDER BY PlantName, SortOrder";
			return db.Fetch<vwShoppingListItem>(sql);
		}

		public bool UpdateClosed(int wlId, bool isClosed)
		{
			int val = isClosed ? 1 : 0;
			string sql = $"UPDATE WishLists SET IsClosed = {val} WHERE (WlId = {wlId})";
			db.Execute(sql);
			return true;
		}
	}
}	
