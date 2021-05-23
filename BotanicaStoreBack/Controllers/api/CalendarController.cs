using BotanicaStoreBack.Models;
using BotanicaStoreBack.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalendarController : ControllerBase
	{
		private readonly CalendarDb db;

		public CalendarController(CalendarDb db)
		{
			this.db = db;
		}

		// GET: api/Calendar/GetNext
		[HttpGet("[action]")]
		public Calendar GetNext()
		{
			return db.NextFuture();
		}

		// GET: api/Calendar/GetAllFuture
		[HttpGet("[action]")]
		public List<Calendar> GetAllFuture()
		{
			return db.AllFuture();
		}

		// GET: api/Calendar/GetAll
		[HttpGet("[action]")]
		[AdminAuthorize]
		public List<Calendar> GetAll()
		{
			return db.All();
		}

		// POST api/Calendar/Save
		[HttpPost("[action]")]
		[AdminAuthorize]
		public Calendar Save([FromBody] Calendar item)
		{
			db.Save(item);
			return item;
		}

	}

}
