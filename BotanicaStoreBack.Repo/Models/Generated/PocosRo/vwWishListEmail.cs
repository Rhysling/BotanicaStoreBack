using NPoco;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("vwWishListEmail")]
	[ExplicitColumns]
	public partial class vwWishListEmail : BotanicaStoreBackDB.Record<vwWishListEmail>
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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		[NPoco.Column]
		public string Email { get; set; }

		[NPoco.Column] 
		public string FullName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


		public List<vwWishListEmailItem> Items { get; set; } = [];
	}
}
