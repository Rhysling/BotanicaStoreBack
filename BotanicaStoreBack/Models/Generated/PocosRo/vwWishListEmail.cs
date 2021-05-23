using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;
using System.Collections.Generic;

namespace BotanicaStoreBack.Models
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

		[NPoco.Column] 
		public string Email { get; set; }

		[NPoco.Column] 
		public string FullName { get; set; }


		public List<vwWishListEmailItem> Items { get; set; }

	}
}
