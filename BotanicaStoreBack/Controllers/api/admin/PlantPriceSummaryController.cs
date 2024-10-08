﻿using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.FiltersAttributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BotanicaStoreBack.Controllers.api.admin
{
	[Route("api/admin/[controller]")]
	[AdminAuthorize]
	[ApiController]
	public class PlantPriceSummaryController : ControllerBase
	{
		private readonly PlantPricingDb db;

		public PlantPriceSummaryController(PlantPricingDb db)
		{
			this.db = (PlantPricingDb)db;
		}

		// GET: api/admin/PlantPriceSummary/GetSummary
		[HttpGet("[action]")]
		public List<vwPlantPriceSummary> GetSummary()
		{
			return db.AllSummaries();
		}

		// GET: api/admin/PlantPriceSummary/GetSummary
		[HttpGet("[action]")]
		public List<vwPlantPriceMatrix> GetMatrix(int plantId)
		{
			return db.GetMatrixForPlant(plantId);
		}
	}
}
