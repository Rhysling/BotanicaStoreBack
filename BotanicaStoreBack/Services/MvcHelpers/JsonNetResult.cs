using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Crosserator.Services.MvcHelpers
{

	/// <summary>
	/// Simple Json Result that implements the Json.NET serialiser offering more versatile serialisation
	/// </summary>
	public class JsonNetResult : ActionResult
	{
		public JsonNetResult()
		{
		}

		public JsonNetResult(object responseBody)
		{
			ResponseBody = responseBody;
		}

		public JsonNetResult(object responseBody, JsonSerializerSettings settings)
		{
			Settings = settings;
		}

		private JsonSerializerSettings _settings = new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() };

		/// <summary>Gets or sets the serialiser settings</summary>
		public JsonSerializerSettings Settings
		{
			get
			{
				return _settings;
			}
			set
			{
				_settings = value;
			}
		}

		/// <summary>Gets or sets the encoding of the response</summary>
		public Encoding ContentEncoding { get; set; }

		/// <summary>Gets or sets the content type for the response</summary>
		public string ContentType { get; set; }

		/// <summary>Gets or sets the body of the response</summary>
		public object ResponseBody { get; set; }

		/// <summary>Gets the formatting types depending on whether we are in debug mode</summary>
		private Formatting Formatting
		{
			get
			{
				return AppSettings.IsProduction ? Formatting.None : Formatting.Indented;
			}
		}

		/// <summary>
		/// Serialises the response and writes it out to the response object
		/// </summary>
		/// <param name="context">The execution context</param>
		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			HttpResponseBase response = context.HttpContext.Response;

			// set content type
			if (!string.IsNullOrEmpty(ContentType))
			{
				response.ContentType = ContentType;
			}
			else
			{
				response.ContentType = "application/json";
			}

			// set content encoding
			if (ContentEncoding != null)
			{
				response.ContentEncoding = ContentEncoding;
			}

			if (ResponseBody != null)
			{
				response.Write(JsonConvert.SerializeObject(ResponseBody, Formatting, Settings));
			}
		}
	}
}