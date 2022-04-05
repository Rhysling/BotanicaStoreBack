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
	public class ShoppingListController : ControllerBase
	{
		private readonly vwShoppingListSummaryDb db;

		public ShoppingListController(vwShoppingListSummaryDb db)
		{
			this.db = db;
		}

		// GET api/admin/ShoppingList/GetAll
		[HttpGet("[action]")]
		public List<vwShoppingListSummary> GetAll()
		{
			return db.GetAll(true);
		}

		// GET api/admin/c/GetItems?listId=1
		[HttpGet("[action]")]
		public List<vwShoppingListItem> GetItems([FromQuery] int listId)
		{
			return db.ItemsByListId(listId);
		}

		// POST api/admin/ShoppingList/SetIsClosed?listId=1&isClosed=true
		[HttpPost("[action]")]
		public bool SetIsClosed([FromQuery] int listId, [FromQuery] bool isClosed)
		{
			db.UpdateClosed(listId, isClosed);
			return true;
		}

	}
}
