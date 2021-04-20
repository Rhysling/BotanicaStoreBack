using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models.Core
{
	[TypeScriptModel]
	public class PlantPicId
	{
		public int PlantId { get; set; }
		public string PicId { get; set; }
	}
}
