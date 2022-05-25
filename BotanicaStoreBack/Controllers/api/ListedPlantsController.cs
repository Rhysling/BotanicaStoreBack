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

		// GET api/ListedPlants/GetFeaturedPlant
		[HttpGet("[action]")]
		public vwListedPlant GetFeaturedPlant()
		{
			return db.FeaturedPlant();
		}

		// GET api/ListedPlants/FindBySlug?slug=abc
		[HttpGet("[action]")]
		public IActionResult FindBySlug([FromQuery] string slug)
		{
			var p = db.FindBySlug(slug);

			if (p == null)
				return NotFound();

			(p.CardLine1, p.CardLine2, _) = ColorCards.Utils.LineSplit(p.Genus, p.Species);

			return Ok(p);
		}
	}
}
