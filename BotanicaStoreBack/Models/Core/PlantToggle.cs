using BotanicaStoreBack.Services.FiltersAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanicaStoreBack.Models.Core
{
	[TypeScriptModel]
	public class PlantToggle
	{
		public int PlantId { get; set; }
		public bool Val { get; set; }
	}
}
