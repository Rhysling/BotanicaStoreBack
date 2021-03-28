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
	public class InfoController : ControllerBase
	{
		private readonly AppSettings opts;

		public InfoController(IOptions<AppSettings> options)
		{
			opts = options.Value;
		}

		// GET: api/<InfoController>
		[HttpGet]
		public IEnumerable<Plant> Get()
		{
			using (var db = new PlantDb(opts))
			{
				var p = db.All().Take(5);
				return p;
			}
		}

		
	}
}
