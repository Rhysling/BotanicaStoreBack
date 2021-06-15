using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwShoppingListItems")]
	[ExplicitColumns]
	public partial class vwShoppingListItem : BotanicaStoreBackDB.Record<vwShoppingListItem>
	{
		[NPoco.Column] 
		public int WlId { get; set; }

		[NPoco.Column] 
		public int PlantId { get; set; }

		[NPoco.Column] 
		public string PlantName { get; set; }

		[NPoco.Column] 
		public int PotSizeId { get; set; }

		[NPoco.Column] 
		public string PotDescription { get; set; }

		[NPoco.Column] 
		public int SortOrder { get; set; }

		[NPoco.Column]
		public int Qty { get; set; }

		[NPoco.Column] 
		public decimal Price { get; set; }

		[NPoco.Column] 
		public decimal? CurrentPrice { get; set; }

		[NPoco.Column] 
		public bool? IsCurrentlyAvailable { get; set; }

	}
}
