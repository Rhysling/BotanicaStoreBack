using NPoco;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("WishLists")]
	[PrimaryKey("WlId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class WishList : BotanicaStoreBackDB.Record<WishList>
	{
		[NPoco.Column]
		public int WlId { get; set; }

		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		public DateTime CreatedDate { get; set; }

		[NPoco.Column]
		public DateTime LastUpdateDate { get; set; }

		[NPoco.Column]
		public DateTime? EmailedDate { get; set; }

		[NPoco.Column]
		public bool IsClosed { get; set; }

		// *** Display Properties ***

		public string CreatedDateFormatted => $"{CreatedDate.ToShortDateString()} {CreatedDate.ToShortTimeString()}";

		public string LastUpdateDateFormatted => $"{LastUpdateDate.ToShortDateString()} {LastUpdateDate.ToShortTimeString()}";

		public string EmailedDateFormatted => (EmailedDate.HasValue)
			? $"{EmailedDate.Value.ToShortDateString()} {EmailedDate.Value.ToShortTimeString()}"
			: "None";

	}
}
