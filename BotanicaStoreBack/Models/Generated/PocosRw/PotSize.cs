using System.ComponentModel.DataAnnotations;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("PotSizes")]
	[PrimaryKey("Id", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class PotSize : BotanicaStoreBackDB.Record<PotSize>
	{
		[NPoco.Column]
		public int Id { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string PotDescription { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string PotShorthand { get; set; }

		[NPoco.Column]
		public int SortOrder { get; set; }

	}
}
