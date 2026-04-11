using NPoco;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("vwPlantPriceSummary")]
	[ExplicitColumns]
	public partial class vwPlantPriceSummary : BotanicaStoreBackDB.Record<vwPlantPriceSummary>
	{
		[NPoco.Column] 
		public int PlantId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		[NPoco.Column]
		public string Genus { get; set; }

		[NPoco.Column] 
		public string Species { get; set; }

		[NPoco.Column] 
		public string Available { get; set; }

		[NPoco.Column] 
		public string NotAvailable { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

	}
}
