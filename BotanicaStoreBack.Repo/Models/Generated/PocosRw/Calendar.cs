using NPoco;
using System.ComponentModel.DataAnnotations;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("Calendar")]
	[PrimaryKey("ItemId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Calendar : BotanicaStoreBackDB.Record<Calendar>
	{
		[NPoco.Column]
		public int ItemId { get; set; }

		[NPoco.Column]
		public DateTime BeginDate { get; set; }

		[NPoco.Column]
		public DateTime? EndDate { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string? EventTime { get; set; }

		[NPoco.Column]
		[StringLength(50)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

		[NPoco.Column]
		[StringLength(100)]
		public string? Location { get; set; }

		[NPoco.Column]
		[StringLength(500)]
		public string? Description { get; set; }

		[NPoco.Column]
		public bool IsSpecial { get; set; }


		public string BeginDateFormatted => BeginDate.ToString("dddd MMMM d, yyyy");

		public string EndDateFormatted => EndDate.HasValue ?
			EndDate.Value.ToString("dddd MMMM d, yyyy")
			: "";
	}
}
