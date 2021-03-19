using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FalahCapital.Models;

namespace FalahCapital.Services.MailMessages
{
	public class RegistrationWelcomeMessage
	{
		private UtilitiesMaster.Mailer.Mailer _mailer;
		private string _toEmail;
		private string _toName;
		private string _fromEmail = Services.AppSettings.EmailFromAddress;
		private string _fromName = Services.AppSettings.EmailFromName;
		private string _subject = "Welcome from Falah Capital";
		private string _body;

		private string _apPath = Services.AppSettings.ApPath;
		private string _fileName = "RegistrationWelcomeMessage.html";
		private string _mailContentFilePath = Services.AppSettings.MailContentFilePath;

		public RegistrationWelcomeMessage(string toEmail)
		{
			_mailer = new UtilitiesMaster.Mailer.Mailer(AppSettings.EmailServer, AppSettings.EmailPw, AppSettings.EmailLoginAddress, AppSettings.IsProduction);
			_toEmail = toEmail;
			_toName = "Registrant";

			var replacements = new Dictionary<string, string> {
				{"ApPath", _apPath}
			};

			var mc = new UtilitiesMaster.Mailer.MailContent(_mailContentFilePath, _fileName);
			mc.MergeBody(replacements);
			_body = mc.Body;
			
		}

		public void Send()
		{
			_mailer.SendMessage(_toEmail, _toName, _fromEmail, _fromName, _subject, _body);
		}
	}
}