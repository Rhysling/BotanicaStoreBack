using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FalahCapital.Services.MailMessages
{
	public static class TestMessage
	{
		public static void Send()
		{
			var _mailer = new UtilitiesMaster.Mailer.Mailer(AppSettings.EmailServer, AppSettings.EmailPw, AppSettings.EmailLoginAddress, AppSettings.IsProduction);

			string _fromEmail = Services.AppSettings.EmailFromAddress;
			string _fromName = Services.AppSettings.EmailFromName;
			string _subject = "Test Message";
			string _body = "Test message sent to: rpkummer@hotmail.com, rkummer@polson.com, rpkummer@gmail.com, kummer@seanet.com, rkummer@acanthusgroup.net";
			List<MailAddress> _tos = new List<MailAddress> {
				new MailAddress("rpkummer@hotmail.com"),
				new MailAddress("rkummer@polson.com"),
				new MailAddress("rpkummer@gmail.com"),
				new MailAddress("kummer@seanet.com"),
				new MailAddress("rkummer@acanthusgroup.net")
			};

			_mailer.SendMessage(_tos, _fromEmail, _fromName, _subject, _body, null, null, null);
		}
	}
}