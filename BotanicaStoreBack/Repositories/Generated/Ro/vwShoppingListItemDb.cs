using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class vwShoppingListItemDb : RepositoryBase
	{
		public vwShoppingListItemDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}


		// *** Use vwShoppingListSummaryDb ***


	}
}	
