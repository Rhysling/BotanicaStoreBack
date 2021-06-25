using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ListedPlantsController : ControllerBase
	{
		private readonly vwListedPlantDb db;

		public ListedPlantsController(vwListedPlantDb db)
		{
			this.db = db;
		}

		// GET: api/<ListedPlantsController>
		[HttpGet]
		public List<vwListedPlant> Get()
		{
			return db.All();
		}

		[Route("[action]")]
		public vwListedPlant GetFeaturedPlant()
		{
			return db.FeaturedPlant();
		}
	}
}
