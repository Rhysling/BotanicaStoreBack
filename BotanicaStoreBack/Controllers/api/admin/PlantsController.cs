using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
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

		// GET api/<PlantsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}


		// GET api/admin/Plants/FlagSummaries
		[HttpGet("[action]")]
		public List<vwFlagSummary> FlagSummaries()
		{
			return db.FlagSummaries();
		}

		// POST api/admin/Plants/RemoveFlag?flag=xx
		[HttpPost("[action]")]
		public bool RemoveFlag([FromQuery] string flag)
		{
			db.RemoveFlag(flag);
			return true;
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
