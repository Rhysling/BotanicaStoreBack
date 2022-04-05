using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BotanicaStoreBack.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class LinksController : ControllerBase
	{
		private readonly LinkDb db;

		public LinksController(LinkDb db)
		{
			this.db = db;
		}

		// GET: api/Links/GetAll
		[HttpGet("[action]")]
		public List<Link> GetAll([FromQuery] bool includeDeleted = false)
		{
			return db.All(includeDeleted);
		}

		// POST: api/Links/Save
		[HttpPost("[action]")]
		[AdminAuthorize]
		public Link Save([FromBody] Link item)
		{
			db.Save(item);
			return item;
		}

		// POST: api/Links/SetDeleted
		[HttpPost("[action]")]
		[AdminAuthorize]
		public bool SetDeleted([FromQuery] int linkId, [FromQuery] bool isDeleted = true)
		{
			if (isDeleted)
				db.Delete(linkId);
			else
				db.UnDelete(linkId);

			return true;
		}

	}
}
