using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FalahCapital.Models;

namespace FalahCapital.Services.MailMessages
{
	public class UserConfirmMessage
	{
		private UtilitiesMaster.Mailer.Mailer _mailer;
		private System.Net.Mail.MailMessage _msg;

		public UserConfirmMessage(UtilitiesMaster.Mailer.Mailer mailer, string filePath, string fileName, User user, string apPath)
		{
			_mailer = mailer;

			_msg = new System.Net.Mail.MailMessage();



		}

		public void Send()
		{
			_mailer.SendMessage(_msg);
		}
	}
}