using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using Slugify;
using System;
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

		// GET: api/admin/Plants
		[HttpGet]
		public List<Plant> Get()
		{
			return db.All();
		}

		// PUT api/admin/Plants/GetForIds *** [id list in body]
		[HttpPut("[action]")]
		public List<Plant> GetForIds([FromBody] int[] ids)
		{
			return db.ByIds(ids);
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

		// POST api/admin/PlantController
		[HttpPost]
		public IActionResult Post([FromBody] Plant plant)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			plant = db.Save(plant);

			if (String.IsNullOrWhiteSpace(plant.Slug))
			{
				var helper = new SlugHelper();
				plant.Slug = helper.GenerateSlug($"{plant.Genus} {plant.Species} {plant.PlantId}");
				plant = db.Save(plant);
			}
			
			return Ok(plant);
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
		
		// POST api/admin/Plants/Delete?plantId=123
		[HttpPost("[action]")]
		public bool Delete([FromQuery] int plantId)
		{
			db.Delete(plantId);
			return true;
		}

	}
}
