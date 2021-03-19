using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using FalahCapital.Models;

namespace FalahCapital.Services.MailMessages
{
	public class RegistrationNoticeMessage
	{
		private UtilitiesMaster.Mailer.Mailer _mailer;
		private string _fromEmail = Services.AppSettings.EmailFromAddress;
		private string _fromName = Services.AppSettings.EmailFromName;
		private string _subject = "Falah Capital Registration";
		private string _body;
		private List<MailAddress> _tos = new List<MailAddress> {
			new MailAddress("rpkummer@hotmail.com"),
			new MailAddress("thom@polson.com")
		};

		private string _fileName = "RegistrationNoticeMessage.html";
		private string _mailContentFilePath = Services.AppSettings.MailContentFilePath;

		public RegistrationNoticeMessage(Registration reg)
		{
			_mailer = new UtilitiesMaster.Mailer.Mailer(AppSettings.EmailServer, AppSettings.EmailPw, AppSettings.EmailLoginAddress, AppSettings.IsProduction);

			var replacements = new Dictionary<string, string> {
				{"RegistrationDate", reg.RegistrationDate.ToString("G")},
				{"Email", reg.Email},
				{"FirstName", reg.FirstName ?? "None"},
				{"LastName", reg.LastName ?? "None"},
				{"Company", reg.Company ?? "None"},
				{"Comment", reg.Comment ?? "None"}
			};

			var mc = new UtilitiesMaster.Mailer.MailContent(_mailContentFilePath, _fileName);
			mc.MergeBody(replacements);
			_body = mc.Body;
			
		}

		public void Send()
		{
			_mailer.SendMessage(_tos, _fromEmail, _fromName, _subject, _body, null, null, null);
		}
	}
}