using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Crosserator.Models.Core;
using Crosserator.Services.FiltersAttributes;

namespace Crosserator.Models.ViewModels
{
	[TypeScriptModel]
	public class CrossEditVM
	{
		public CrossEditVM()
		{
			Mode = "cross";
			ShowCrossList = false;
			CrossYearSL = ApLists.GetCrossNumberYearEnumList();
		}

		public string Mode { get; set; } // display - edit - cross - ""
		public string SeedPlantName { get; set; }
		public Cross Cross { get; set; }
		public int NextCrossNumberForYear { get; set; }
		public bool ShowCrossList { get; set; }

		public List<NameValueItem> CrossPlantSL { get; set; }
		public List<NameValueItem> CrossYearSL { get; set; }
		public List<string> Errors { get; set; }
	}
}