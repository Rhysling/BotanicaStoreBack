using NPoco;
using System.ComponentModel.DataAnnotations;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("Links")]
	[PrimaryKey("LinkId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Link : BotanicaStoreBackDB.Record<Link>
	{
		[NPoco.Column]
		public int LinkId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		[NPoco.Column]
		[StringLength(100)]
		public string Title { get; set; }

		[NPoco.Column]
		[StringLength(2047)]
		public string Description { get; set; }

		[NPoco.Column]
		[StringLength(1023)]
		public string Url { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

		[NPoco.Column]
		public int SortOrder { get; set; }

		[NPoco.Column]
		public bool IsDeleted { get; set; }

	}
}
