using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.Mailer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class WishListController : ControllerBase
	{
		private readonly WishListDb dbWL;
		private readonly vwWishListEmailDb dbWLE;
		private readonly PlantPricingDb dbPP;
		private readonly MailgunService mailgunService;
		private readonly AppSettings settings;

		public WishListController(WishListDb dbWL, PlantPricingDb dbPP, vwWishListEmailDb dbWLE, MailgunService mailgunService, IOptions<AppSettings> opts)
		{
			this.dbWL = dbWL;
			this.dbWLE = dbWLE;
			this.dbPP = dbPP;
			this.mailgunService = mailgunService;
			settings = opts.Value;
		}

		// GET: api/WishList/GetOrCreateCurrent
		[HttpGet("[action]")]
		[Authorize]
		public WishList GetOrCreateCurrent()
		{
			string userId = HttpContext.User.Claims.Where(a => a.Type == "UserId").Select(a => a.Value).FirstOrDefault() ?? "xx";

			if (int.TryParse(userId, out int uid))
				return dbWL.GetOrCreateCurrent(uid);

			Response.StatusCode = (int)HttpStatusCode.Unauthorized;
			return null;
		}

		// GET: api/WishList/GetListById
		[HttpGet("[action]")]
		[Authorize]
		public List<vwWishListFlat> GetListById([FromQuery]int wlId)
		{
			return dbWL.GetListById(wlId);
		}

		// GET: api/WishList/GetCurrentListForUser
		[HttpGet("[action]")]
		[Authorize]
		public List<vwWishListFlat> GetCurrentList()
		{
			string userId = HttpContext.User.Claims.Where(a => a.Type == "UserId").Select(a => a.Value).FirstOrDefault() ?? "xx";

			if (int.TryParse(userId, out int uid))
				return dbWL.GetListForUser(uid);

			Response.StatusCode = (int)HttpStatusCode.Unauthorized;
			return null;
		}

		// POST: api/WishList/EmailCurrentList
		[HttpPost("[action]")]
		[Authorize]
		public async Task<string> EmailCurrentList()
		{
			string userId = HttpContext.User.Claims.Where(a => a.Type == "UserId").Select(a => a.Value).FirstOrDefault() ?? "xx";
			_ = int.TryParse(userId, out int uid);

			if (uid == 0)
			{
				Response.StatusCode = (int)HttpStatusCode.Unauthorized;
				return "Unauthorized";
			}

			var wle = dbWLE.GetByUserId(uid);
			if (wle is null)
			{
				Response.StatusCode = (int)HttpStatusCode.OK;
				return "No list found";
			}

			var wlm = new WishListMessage(wle, settings.TaxRate);

			// *** send email -- production or connected ***
			var res = await mailgunService.SendWishListMessage(wlm);

			if (res.IsSuccessStatusCode)
				dbWL.MarkListEmailed(wle.WlId);

			Response.StatusCode = (int)res.StatusCode;
			return res.ReasonPhrase ?? "";
			// *** END ***


			// *** send to file ***
			//string fn = $"wl_{wle.WlId}_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
			//string bp = Path.Combine(Directory.GetCurrentDirectory(), "TestEmails", fn);
			//System.IO.File.WriteAllText(bp + ".html", wlm.RenderHtmlBody());
			//System.IO.File.WriteAllText(bp + ".txt", wlm.RenderTextBody());
			//dbWL.MarkListEmailed(uid);
			//return await Task.FromResult("Done");
			// *** END ***

		}



		// GET: api/WishList/GetAvailablePlants
		[HttpGet("[action]")]
		public List<vwPlantsAvailable> GetAvailablePlants()
		{
			return dbPP.AllAvailable();
		}

		// POST: api/WishList/AddUpdateItem
		[HttpPost("[action]")]
		[Authorize]
		public bool AddUpdateItem([FromBody] WishListItem item)
		{
			dbWL.AddUpdateItem(item);
			return true;
		}

	}
}
