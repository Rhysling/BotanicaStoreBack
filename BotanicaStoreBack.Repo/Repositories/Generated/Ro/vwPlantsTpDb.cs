using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class vwPlantsTpDb : RepositoryBase
	{
		public vwPlantsTpDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public IEnumerable<vwPlantsTp> All()
		{
			return db.Fetch<vwPlantsTp>(" ");
		}

		//Example - filtered list:
		public IEnumerable<vwPlantsTp> FilteredList(string str1, string str2)
		{
			return db.Fetch<vwPlantsTp>("WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}
		
		//Example - paged & filtered list:
		public Page<vwPlantsTp> PagedFilteredList(string str1, string str2, long page, long itemsPerPage)
		{
			return db.Page<vwPlantsTp>(page, itemsPerPage, "WHERE (v1=@p1) AND (v2=@p2)", new {p1 = str1, p2 = str2});
		}

		// More methods here ***
	}
}	
