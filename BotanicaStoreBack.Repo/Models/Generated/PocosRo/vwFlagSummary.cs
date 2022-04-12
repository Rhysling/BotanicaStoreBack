using BotanicaStoreBack.Repo.Models.Core;
using NPoco;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("vwFlagSummary")]
	[ExplicitColumns]
	public partial class vwFlagSummary : BotanicaStoreBackDB.Record<vwFlagSummary>
	{
		[NPoco.Column] 
		public string? Flag { get; set; }

		[NPoco.Column] 
		public int? PlantCount { get; set; }

		[NPoco.Column] 
		public DateTime? LastUpdate { get; set; }


		// Computed
		public string LastUpdateFormatted => Utils.ToShortPT(LastUpdate);

	}
}
