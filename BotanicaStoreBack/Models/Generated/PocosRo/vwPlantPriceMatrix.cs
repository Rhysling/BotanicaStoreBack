using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwPlantPriceMatrix")]
	[ExplicitColumns]
	public partial class vwPlantPriceMatrix : BotanicaStoreBackDB.Record<vwPlantPriceMatrix>
	{
		[NPoco.Column] 
		public int PotSizeId { get; set; }

		[NPoco.Column] 
		public string PotDescription { get; set; }

		[NPoco.Column] 
		public string PotShorthand { get; set; }

		[NPoco.Column] 
		public int SortOrder { get; set; }

		[NPoco.Column] 
		public int? PlantId { get; set; }

		[NPoco.Column] 
		public decimal? Price { get; set; }

		[NPoco.Column] 
		public bool? IsAvailable { get; set; }

	}
}
