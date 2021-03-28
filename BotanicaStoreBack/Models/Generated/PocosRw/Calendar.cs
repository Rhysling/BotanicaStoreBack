

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
	[TableName("Calendar")]
	[PrimaryKey("ItemId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Calendar : BotanicaStoreBackDB.Record<Calendar>
	{
		[NPoco.Column]
		public int ItemId { get; set; }

		[NPoco.Column]
		public DateTime? BeginDate { get; set; }

		[NPoco.Column]
		public DateTime? EndDate { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string EventTime { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string Title { get; set; }

		[NPoco.Column]
		[StringLength(100)]
		public string Location { get; set; }

		[NPoco.Column]
		[StringLength(500)]
		public string Description { get; set; }

		[NPoco.Column]
		public bool? IsSpecial { get; set; }

	}
}