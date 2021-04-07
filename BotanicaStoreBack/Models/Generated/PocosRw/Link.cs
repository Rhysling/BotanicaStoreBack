using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("Links")]
	[PrimaryKey("LinkId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Link : BotanicaStoreBackDB.Record<Link>
	{
		[NPoco.Column]
		public int LinkId { get; set; }

		[NPoco.Column]
		[StringLength(100)]
		public string LinkTitle { get; set; }

		[NPoco.Column]
		[StringLength(2047)]
		public string Description { get; set; }

		[NPoco.Column]
		[StringLength(1023)]
		public string URL { get; set; }

		[NPoco.Column]
		public int? SortOrder { get; set; }

		[NPoco.Column]
		public bool? IsDeleted { get; set; }

	}
}
