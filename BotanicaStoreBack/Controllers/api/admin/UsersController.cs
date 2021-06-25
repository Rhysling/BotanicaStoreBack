using BotanicaStoreBack.Models;
using BotanicaStoreBack.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Controllers.api.admin
{
	[Route("api/admin/[controller]")]
	[AdminAuthorize]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserDb db;

		public UsersController(UserDb db)
		{
			this.db = db;
		}

		// GET: api/admin/Users/GetDetails
		[HttpGet("[action]")]
		public List<vwUserDetail> GetDetails()
		{
			return db.AllDetails();
		}

	}
}
