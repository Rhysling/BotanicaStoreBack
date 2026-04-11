using NPoco;

namespace BotanicaStoreBack.Repo.Models
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		[NPoco.Column]
		public string PlantName { get; set; }

		[NPoco.Column] 
		public int PotSizeId { get; set; }

		[NPoco.Column] 
		public string PotDescription { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

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
