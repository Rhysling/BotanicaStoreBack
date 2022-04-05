using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
