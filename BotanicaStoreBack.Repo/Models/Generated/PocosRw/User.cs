using NPoco;
using System.ComponentModel.DataAnnotations;

namespace BotanicaStoreBack.Repo.Models
{
	[TableName("Users")]
	[PrimaryKey("UserId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class User : BotanicaStoreBackDB.Record<User>
	{
		[NPoco.Column]
		public int UserId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string Email { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

		[NPoco.Column]
		[StringLength(100)]
		public string? FullName { get; set; }

		[NPoco.Column]
		public bool IsAdmin { get; set; }

		[NPoco.Column]
		public DateTime CreatedDate { get; set; }

		[NPoco.Column]
		public DateTime LastLoginDate { get; set; }

		[NPoco.Column]
		public int LoginCount { get; set; }

	}
}
