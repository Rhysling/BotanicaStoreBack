using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crosserator.Models.Core;
using Crosserator.Services.FiltersAttributes;

namespace Crosserator.Models.ViewModels
{
	[TypeScriptModel]
	public class CrossBriefListVM
	{
		public CrossBriefListVM()
		{
			Mode = "cross";
			ShowCrossList = false;
			CrossYearSL = ApLists.GetCrossNumberYearEnumList();
		}

		public string Mode { get; set; } // display - edit - cross - ""
		public bool ShowCrossList { get; set; }
		public int CrossNumberYear { get; set; }

		public List<SeedCrossBrief> SeedCrossList { get; set; }
		public List<NameValueItem> CrossYearSL { get; set; }
	}
}