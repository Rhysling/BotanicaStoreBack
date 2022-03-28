using BotanicaStoreBack.Models.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Services.Mailer
{
	public class MailgunService
	{
		private HttpClient client;
		private string domain;

		public MailgunService(HttpClient client, IOptions<AppSettings> settings)
		{
			var s = settings.Value.Mailgun;
			domain = s.Domain;
			client.BaseAddress = new Uri(s.BaseUrl);
			client.DefaultRequestHeaders.Add("Authorization", s.AuthValue);
			client.DefaultRequestHeaders.Add("Accept", "*/*");

			this.client = client;
		}

		public async Task<HttpResponseMessage> SendWishListMessage(WishListMessage wlm)
		{
			var d = new Dictionary<string, string> {
				{"to", wlm.To },
				{"from", "Pamela Harlow <pamela@polson.com>" },
				{"cc", "Pamela Harlow <pamela@polson.com>" },
				{"bcc", "rkummer@polson.com" },
				{"subject", wlm.Subject },
				{"html", wlm.RenderHtmlBody() },
				{"text", wlm.RenderTextBody() }
			};

			var content = new FormUrlEncodedContent(d);

			var request = new HttpRequestMessage {
				RequestUri = new Uri(domain + "/messages", UriKind.Relative),
				Method = HttpMethod.Post,
				Content = content
			};

			return await client.SendAsync(request);
		}

		public async Task<HttpResponseMessage> SendTestMessage()
		{
			var d = new Dictionary<string, string> {
				{"to", "Rob Kummer <rkummer@polson.com>" },
				{"from", "Pandala <pamela@polson.com>" },
				{"subject", "Test Message One" },
				{"text", "Here is my text email body!" }
			};

			var content = new FormUrlEncodedContent(d);

			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(domain + "/messages", UriKind.Relative),
				Method = HttpMethod.Post,
				Content = content
			};

			return await client.SendAsync(request);
		}
	}
}
