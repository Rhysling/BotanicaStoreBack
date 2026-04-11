using NPoco;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("vwPlantsAvailable")]
	[ExplicitColumns]
	public partial class vwPlantsAvailable : BotanicaStoreBackDB.Record<vwPlantsAvailable>
	{
		[NPoco.Column] 
		public int PlantId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		[NPoco.Column]
		public string PlantName { get; set; }

		[NPoco.Column] 
		public int PotSizeId { get; set; }

		[NPoco.Column] 
		public string PotDescription { get; set; }

		[NPoco.Column] 
		public string PotShorthand { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

		[NPoco.Column] 
		public int SortOrder { get; set; }

		[NPoco.Column]
		public decimal Price { get; set; }


		public string? QtyEntered { get; set; }
		public bool? IsValid { get; set; }
	}
}
