using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FalahCapital.Models;

namespace FalahCapital.Services
{
	public class MessagingService
	{
		public bool SendConfirmEmail(User user)
		{
			var mailer = new UtilitiesMaster.Mailer.Mailer(AppSettings.EmailServer, AppSettings.EmailPw, AppSettings.EmailLoginAddress, AppSettings.IsProduction);

			string sf = @"<p style=""font-weight:bold;"">Thank you for registering with the XXXXXXXXXXXXXXXXXX application.</p>";
			sf += @"<p><a href=""" + AppSettings.ApPath + @"Account/Confirmation/{0}"">Please click here to activate your account</a>.</p><br /><br />";
			sf += @"Alternatively, you may copy this link into your browser's address bar:<br />" + AppSettings.ApPath + @"Account/Confirmation/{0}";
			string body = String.Format(sf, user.ConfirmKey);

			return mailer.SendMessage(user.Email, user.FullName, AppSettings.EmailFromAddress, AppSettings.EmailFromName, "Confirm Registration", body);
		} // End Function

		public bool SendPasswordResetEmail(User user, string pw)
		{
			var mailer = new UtilitiesMaster.Mailer.Mailer(AppSettings.EmailServer, AppSettings.EmailPw, AppSettings.EmailLoginAddress, AppSettings.IsProduction);

			string sf = @"<p style=""font-weight:bold;"">Password has been reset for '{0}'.</p>";
			sf += @"<p>Your new temporary password is: {1}</p>";
			sf += @"<p><a href=""" + AppSettings.ApPath + "Account/LogOn?un=" + System.Web.HttpUtility.UrlEncode(user.Email) + @""">Log on here</a>, then change your password.</p>";
			string body = String.Format(sf, user.Email, pw);

			return mailer.SendMessage(user.Email, user.FullName, AppSettings.EmailFromAddress, AppSettings.EmailFromName, "Password Reset", body);
		}

	}
}

