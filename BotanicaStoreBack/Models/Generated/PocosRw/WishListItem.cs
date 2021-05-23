using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("WishListItems")]
	[PrimaryKey("WlId, PlantId, PotSizeId", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class WishListItem : BotanicaStoreBackDB.Record<WishListItem>
	{
		[NPoco.Column]
		public int WlId { get; set; }

		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		public int PotSizeId { get; set; }

		[NPoco.Column]
		public decimal Price { get; set; }

		[NPoco.Column]
		public int Qty { get; set; }

	}
}
