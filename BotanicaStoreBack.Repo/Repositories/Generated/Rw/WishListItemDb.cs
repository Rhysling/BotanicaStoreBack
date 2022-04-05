using System;
using System.Collections.Generic;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using Microsoft.Extensions.Options;

namespace BotanicaStoreBack.Repos
{ 
	public class WishListItemDb : RepositoryBase
	{
		public WishListItemDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}


		// ***** DO NOT USE -- Handle in WishListDb *****


		public int MaxId()
		{
			return db.Single<int>("SELECT MAX(Id) FROM [WishListItems]");
		}
	}
}	
	
