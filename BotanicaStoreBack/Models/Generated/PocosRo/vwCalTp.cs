using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwCalTp")]
	[ExplicitColumns]
	public partial class vwCalTp : BotanicaStoreBackDB.Record<vwCalTp>
	{
		[NPoco.Column] 
		public int ItemId { get; set; }

		[NPoco.Column] 
		public DateTime? BeginDate { get; set; }

		[NPoco.Column] 
		public string Title { get; set; }

		[NPoco.Column] 
		public string Description { get; set; }

		[NPoco.Column] 
		public bool? IsSpecial { get; set; }

	}
}
