using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwWishListEmailItems")]
	[ExplicitColumns]
	public partial class vwWishListEmailItem : BotanicaStoreBackDB.Record<vwWishListEmailItem>
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
		public decimal Price { get; set; }

		[NPoco.Column] 
		public int Qty { get; set; }

	}
}
