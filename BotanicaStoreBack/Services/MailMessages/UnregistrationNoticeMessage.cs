using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using FalahCapital.Models;

namespace FalahCapital.Services.MailMessages
{
	public class UnregistrationNoticeMessage
	{
		private UtilitiesMaster.Mailer.Mailer _mailer;
		private string _fromEmail = Services.AppSettings.EmailFromAddress;
		private string _fromName = Services.AppSettings.EmailFromName;
		private string _subject = "Unregistration from Falah Capital";
		private string _body;
		private List<MailAddress> _tos = new List<MailAddress> {
			new MailAddress("rpkummer@hotmail.com"),
			new MailAddress("thom@polson.com")
		};

		private string _fileName = "UnregisterNoticeMessage.html";
		private string _mailContentFilePath = Services.AppSettings.MailContentFilePath;

		public UnregistrationNoticeMessage(Registration originalReg, int regCount)
		{
			_mailer = new UtilitiesMaster.Mailer.Mailer(AppSettings.EmailServer, AppSettings.EmailPw, AppSettings.EmailLoginAddress, AppSettings.IsProduction);

			var replacements = new Dictionary<string, string> {
				{"UnregDate", DateTime.Now.ToString("G")},
				{"RegCount", regCount.ToString()},
				{"RegistrationDate", originalReg.RegistrationDate.ToString("G")},
				{"Email", originalReg.Email},
				{"FirstName", originalReg.FirstName ?? "None"},
				{"LastName", originalReg.LastName ?? "None"},
				{"Company", originalReg.Company ?? "None"},
				{"Comment", originalReg.Comment ?? "None"}
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