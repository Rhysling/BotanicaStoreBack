using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
