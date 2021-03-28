using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class vwCalTpDb : RepositoryBase
	{
		public vwCalTpDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public IEnumerable<vwCalTp> All()
		{
			return db.Fetch<vwCalTp>(" ");
		}

		//Example - filtered list:
		public IEnumerable<vwCalTp> FilteredList(string str1, string str2)
		{
			return db.Fetch<vwCalTp>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}
		
		//Example - paged & filtered list:
		public Page<vwCalTp> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<vwCalTp>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}	
