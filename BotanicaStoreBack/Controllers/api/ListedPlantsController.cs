using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BotanicaStoreBack.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ListedPlantsController : ControllerBase
	{
		private readonly AppSettings opts;
		private readonly vwListedPlantDb db;

		public ListedPlantsController(IOptions<AppSettings> options, IvwListedPlantDb db)
		{
			opts = options.Value;
			this.db = (vwListedPlantDb)db;
		}

		// GET: api/<ListedPlantsController>
		[HttpGet]
		public List<vwListedPlant> Get()
		{
			return db.All();
		}

	}
}
