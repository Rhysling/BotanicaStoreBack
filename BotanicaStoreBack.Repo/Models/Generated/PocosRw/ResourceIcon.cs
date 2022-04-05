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
	[TableName("ResourceIcons")]
	[PrimaryKey("FileType", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class ResourceIcon : BotanicaStoreBackDB.Record<ResourceIcon>
	{
		[NPoco.Column]
		[StringLength(10)]
		[Required()]
		public string FileType { get; set; }

		[NPoco.Column]
		public int IconGroup { get; set; }

	}
}
