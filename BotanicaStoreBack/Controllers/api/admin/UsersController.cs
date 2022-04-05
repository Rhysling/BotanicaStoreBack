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
