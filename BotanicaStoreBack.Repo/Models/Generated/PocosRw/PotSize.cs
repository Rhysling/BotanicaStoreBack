using NPoco;
using System.ComponentModel.DataAnnotations;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("PotSizes")]
	[PrimaryKey("Id", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class PotSize : BotanicaStoreBackDB.Record<PotSize>
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

		[NPoco.Column]
		public int SortOrder { get; set; }

	}
}
