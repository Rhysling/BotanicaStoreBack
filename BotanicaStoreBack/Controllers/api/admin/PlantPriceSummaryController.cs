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
	public class PlantPriceSummaryController : ControllerBase
	{
		private readonly vwPlantPriceSummaryDb db;

		public PlantPriceSummaryController(IvwPlantPriceSummaryDb db)
		{
			this.db = (vwPlantPriceSummaryDb)db;
		}

		// GET: api/admin/<PlantController>
		[HttpGet]
		public List<vwPlantPriceSummary> Get()
		{
			return db.All();
		}
	}
}
