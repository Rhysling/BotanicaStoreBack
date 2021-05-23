using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models.Core
{
	[TypeScriptModel]
	public class PlantIdName
	{
		public int PlantId { get; set; }
		public string PlantName { get; set; }
	}
}
