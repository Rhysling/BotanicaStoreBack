using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class vwWishListFlatDb : RepositoryBase
	{
		public vwWishListFlatDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		// ***** in WishListDb *****
	}
}	
