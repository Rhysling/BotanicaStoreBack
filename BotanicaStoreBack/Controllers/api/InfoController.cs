﻿using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class InfoController : ControllerBase
	{
		private readonly CalendarDb db;

		public InfoController(CalendarDb db)
		{
			this.db = db;
		}

		//// GET: api/<InfoController>
		//[HttpGet]
		//public List<Plant> Get()
		//{
		//	return db.All().Take(5).ToList();
		//}

		// GET: api/<InfoController>
		[HttpGet]
		public List<Calendar> Get()
		{
			//return Directory.GetCurrentDirectory();
			return db.AllFuture();
		}

	}
}
