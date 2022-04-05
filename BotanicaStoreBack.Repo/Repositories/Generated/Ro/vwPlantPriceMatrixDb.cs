using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{ 
	public class vwPlantPriceMatrixDb : RepositoryBase
	{
		public vwPlantPriceMatrixDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		// **** SEE vwPlantPricingDb ****

	}
}	
