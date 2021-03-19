using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SquishIt.Framework;
using SquishIt.Mvc;

namespace Crosserator.Services
{
	public static class SquishBundles
	{
		public static MvcHtmlString BaseCss()
		{
			var bun = Bundle.Css()
				//.Add("~/assets/components/bootstrap/less/aaa-bootstrap.css")
				//.Add("~/assets/components/font-awesome/less/font-awesome.css")

				.Add("~/assets/css/aaa-ap.css");

			if (AppSettings.IsProduction)
			{
				return bun.ForceRelease().MvcRender("~/assets/bundles/BaseCss_#.css");
			}
			else
			{
				return bun.ForceDebug().MvcRender("~/assets/bundles/BaseCss_#.css");
			}
		}

		public static MvcHtmlString BaseJs()
		{
			var bun = Bundle.JavaScript()

				// Global
				.Add("~/assets/js/lib/rpk-utilities.js")
				//.Add("~/assets/lib/json3-3.2.4.min.js")
				//.Add("~/assets/lib/modernizr-2.8.1.custom.js")

				// Libraries
				.Add("~/assets/js/npmlib/jquery.js")
				.Add("~/assets/js/lib/dwb-pubsub.js")
				.Add("~/assets/js/npmlib/lodash.js")
				//.Add("~/assets/js/lib/jquery.whenAll.js")
				//.Add("~/assets/js/lib/ractive-0.8.1.js")
				.Add("~/assets/js/lib/parsley-2.0.7.js")

				.Add("~/assets/components/sweet-alert/sweet-alert.js")
				.Add("~/assets/components/carousel-modal/js/bootstrap-carousel.js")
				.Add("~/assets/components/carousel-modal/js/ap-modal-carousel.js")
				//.Add("~/assets/lib/jquery.timeago-1.1.0.js")
				//.Add("~/assets/lib/jquery.signalR-1.0.1.min.js")
				.Add("~/assets/js/npmlib/toastr.js");



			if (AppSettings.IsProduction)
			{
				bun.Add("~/assets/js/npmlib/vue.min.js");
				return bun.ForceRelease().MvcRender("~/assets/bundles/BaseJs_#.js");
			}
			else
			{
				bun.Add("~/assets/js/npmlib/vue.js");
				return bun.ForceDebug().MvcRender("~/assets/bundles/BaseJs_#.js");
			}
		}

		public static MvcHtmlString ApJs()
		{
			var bun = Bundle.JavaScript()
				.Add("~/assets/js/ap/ap-ui.js")
				.Add("~/assets/js/ap/ap-vw-seedcrosslist.js")
				.Add("~/assets/js/ap/ap-vw-displayedit.js")
				.Add("~/assets/js/ap/ap-vw-crossedit.js")
				.Add("~/assets/js/ap/ap-vw-pollenlist.js")
				.Add("~/assets/js/ap/ap-vw-filter.js")
				.Add("~/assets/js/ap/ap.js");

			if (AppSettings.IsProduction)
				return bun.ForceRelease().MvcRender("~/assets/bundles/Ap_#.js");
			else
				return bun.ForceDebug().MvcRender("~/assets/bundles/Ap_#.js");
		}

		public static MvcHtmlString ApAccountManageJs()
		{
			var bun = Bundle.JavaScript()
				.Add("~/assets/js/ap/ap-page-account-manage.js")
				.Add("~/assets/js/ap/ap.js");

			if (AppSettings.IsProduction)
				return bun.ForceRelease().MvcRender("~/assets/bundles/ApAccountManage_#.js");
			else
				return bun.ForceDebug().MvcRender("~/assets/bundles/ApAccountManage_#.js");
		}

		public static MvcHtmlString ApAdminJs()
		{
			var bun = Bundle.JavaScript()
				.Add("~/assets/js/ap/ap-page-admin-picaudit.js")
				.Add("~/assets/js/ap/ap.js");

			if (AppSettings.IsProduction)
				return bun.ForceRelease().MvcRender("~/assets/bundles/ApAdmin_#.js");
			else
				return bun.ForceDebug().MvcRender("~/assets/bundles/ApAdmin_#.js");
		}
	}
}