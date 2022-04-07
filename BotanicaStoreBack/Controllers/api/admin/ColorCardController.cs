using BotanicaStoreBack.ColorCards;
using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BotanicaStoreBack.Controllers.api.admin;

[Route("api/admin/[controller]")]
[AdminAuthorize]
[ApiController]
public class ColorCardController : ControllerBase
{
	private readonly PlantDb db;

	public ColorCardController(PlantDb db)
	{
		this.db = db;
	}

	// GET api/admin/ColorCard/ForFlag/5
	[HttpGet("[action]/{flag}")]
	public ActionResult ForFlag(string flag)
	{
		string fileName = $"ColorCards_{flag}_{DateTime.Now.ToString("yyMMdd-HHmmss")}.docx";
		var plants = db.ByFlag(flag);
		var docBuilder = new DocBuilder(plants);
		var bytes = docBuilder.Create();
		return File(bytes, "application/docx", fileName);
	}

}
