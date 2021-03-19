using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalahCapital.Services.Filters
{
	public class TrafficLogActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var hx = filterContext.HttpContext;
			var tDb = new FalahCapital.Repositories.TrafficLogDb();
			var t = new FalahCapital.Models.TrafficLog {
				LogDate = DateTime.Now,
				SessionId = hx.Session.SessionID,
				HostAddress = hx.Request.UserHostAddress,
				HostName = hx.Request.UserHostName,
				UrlReferer = (hx.Request.UrlReferrer == null) ? "" : hx.Request.UrlReferrer.ToString(),
				RawUrl = hx.Request.RawUrl,
				UserAgent = hx.Request.UserAgent
			};
			tDb.Save(t);

			base.OnActionExecuting(filterContext);
		}
	}
}