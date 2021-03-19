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
	[TableName("Keys")]
	[PrimaryKey("KeyName", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class Key : BotanicaStoreBackDB.Record<Key>
	{
		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string KeyName { get; set; }

		[NPoco.Column]
		[StringLength(2047)]
		public string KeyValue { get; set; }

	}
}
