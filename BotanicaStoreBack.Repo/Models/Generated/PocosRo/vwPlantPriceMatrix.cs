using NPoco;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("vwPlantPriceMatrix")]
	[ExplicitColumns]
	public partial class vwPlantPriceMatrix : BotanicaStoreBackDB.Record<vwPlantPriceMatrix>
	{
		[NPoco.Column] 
		public int PotSizeId { get; set; }

		[NPoco.Column]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		public string PotDescription { get; set; }

		[NPoco.Column] 
		public string PotShorthand { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

		[NPoco.Column] 
		public int SortOrder { get; set; }

		[NPoco.Column] 
		public int PlantId { get; set; }

		[NPoco.Column] 
		public decimal? Price { get; set; }

		[NPoco.Column] 
		public bool IsAvailable { get; set; }

	}
}
