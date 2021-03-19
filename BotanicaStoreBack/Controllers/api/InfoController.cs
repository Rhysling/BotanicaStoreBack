using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repositories;
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
