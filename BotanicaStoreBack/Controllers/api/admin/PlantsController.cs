using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BotanicaStoreBack.Controllers.api.admin
{
	[Route("api/admin/[controller]")]
	[AdminAuthorize]
	[ApiController]
	public class PlantsController : ControllerBase
	{
		private readonly PlantDb db;

		public PlantsController(PlantDb db)
		{
			this.db = db;
		}

		// GET: api/admin/<PlantController>
		[HttpGet]
		public List<Plant> Get()
		{
			return db.All();
		}

		// GET api/<PlantsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// Save / Update ******

		// POST api/admin/<PlantController>
		[HttpPost]
		public int Post([FromBody] Plant plant)
		{
			var m = ModelState.IsValid;

			if (m)
			{
				return db.Save(plant);
			}

			return -1;
		}

		// POST api/admin/<PlantController>/[action]
		[HttpPost("[action]")]
		public bool SetFeatured([FromBody] PlantToggle value)
		{
			db.SetFeatured(value);
			return true;
		}

		// POST api/admin/<PlantController>/[action]
		[HttpPost("[action]")]
		public bool SetListed([FromBody] PlantToggle value)
		{
			db.SetListed(value);
			return true;
		}

	}
}
