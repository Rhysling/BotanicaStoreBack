using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwPlantPriceSummary")]
	[ExplicitColumns]
	public partial class vwPlantPriceSummary : BotanicaStoreBackDB.Record<vwPlantPriceSummary>
	{
		[NPoco.Column] 
		public int PlantId { get; set; }

		[NPoco.Column]
		public string Genus { get; set; }

		[NPoco.Column] 
		public string Species { get; set; }

		[NPoco.Column] 
		public string Available { get; set; }

		[NPoco.Column] 
		public string NotAvailable { get; set; }

	}
}
