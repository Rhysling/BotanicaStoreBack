using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("PlantPrices")]
	[PrimaryKey("PlantId, PotSizeId", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class PlantPrice : BotanicaStoreBackDB.Record<PlantPrice>
	{
		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		public int PotSizeId { get; set; }

		[NPoco.Column]
		public decimal Price { get; set; }

		[NPoco.Column]
		public bool IsAvailable { get; set; }

	}
}
