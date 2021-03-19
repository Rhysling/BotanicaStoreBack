using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using FalahCapital.Services;

namespace FalahCapital.Services.Extensions
{
	public static class ControllerExtensions
	{
		public static JsonNetResult JsonEx(this Controller controller, object responseBody)
		{
			return new JsonNetResult(responseBody);
		}

		public static JsonNetResult JsonEx(this Controller controller, object responseBody, JsonSerializerSettings settings)
		{
			return new JsonNetResult(responseBody, settings);
		}
	}
}