using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Controllers.api.admin
{
	[Route("api/admin/[controller]")]
	[AdminAuthorize]
	[ApiController]
	public class PlantPriceController : ControllerBase
	{
		private readonly PlantPriceDb db;

		public PlantPriceController(PlantPriceDb db)
		{
			this.db = (PlantPriceDb)db;
		}

		// POST: api/admin/PlantPrice/UpdateAllForPlant
		[HttpPost("[action]")]
		public bool UpdateAllForPlant([FromBody] List<PlantPrice> plantPrices, [FromQuery] int plantId)
		{
			db.UpdateAllForPlant(plantId, plantPrices);
			return true;
		}
	}
}
