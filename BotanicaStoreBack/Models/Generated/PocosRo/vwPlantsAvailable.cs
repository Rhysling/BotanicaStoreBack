using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwPlantsAvailable")]
	[ExplicitColumns]
	public partial class vwPlantsAvailable : BotanicaStoreBackDB.Record<vwPlantsAvailable>
	{
		[NPoco.Column] 
		public int PlantId { get; set; }

		[NPoco.Column] 
		public string PlantName { get; set; }

		[NPoco.Column] 
		public int PotSizeId { get; set; }

		[NPoco.Column] 
		public string PotDescription { get; set; }

		[NPoco.Column] 
		public string PotShorthand { get; set; }

		[NPoco.Column] 
		public int SortOrder { get; set; }

		[NPoco.Column]
		public decimal Price { get; set; }


		public string QtyEntered { get; set; }
		public bool? IsValid { get; set; }
	}
}
