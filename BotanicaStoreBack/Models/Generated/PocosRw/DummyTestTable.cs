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
	[TableName("DummyTestTable")]
	[PrimaryKey("FirstKey, SecondKey", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class DummyTestTable : BotanicaStoreBackDB.Record<DummyTestTable>
	{
		[NPoco.Column]
		public int FirstKey { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string SecondKey { get; set; }

		[NPoco.Column]
		public DateTime LastThing { get; set; }

		[NPoco.Column]
		[StringLength(10)]
		public string Info { get; set; }

		[NPoco.Column]
		[StringLength(10)]
		public string MoreStuff { get; set; }

		[NPoco.Column]
		public byte[] ByteThing { get; set; }

		[NPoco.Column]
		public byte[] BigByteThing { get; set; }

	}
}
