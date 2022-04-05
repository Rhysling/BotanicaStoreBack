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
	[TableName("Subscribers")]
	[PrimaryKey("ItemId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Subscriber : BotanicaStoreBackDB.Record<Subscriber>
	{
		[NPoco.Column]
		public int ItemId { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string FirstName { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string LastName { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string ExtraName { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string Email { get; set; }

		[NPoco.Column]
		[StringLength(100)]
		public string Address1 { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string Address2 { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string City { get; set; }

		[NPoco.Column]
		[StringLength(3)]
		public string State { get; set; }

		[NPoco.Column]
		[StringLength(10)]
		public string ZipCode { get; set; }

		[NPoco.Column]
		public bool SendNotices { get; set; }

		[NPoco.Column]
		public bool MailCalendar { get; set; }

		[NPoco.Column]
		public bool IsDeleted { get; set; }

		[NPoco.Column]
		[StringLength(255)]
		public string Notes { get; set; }

		[NPoco.Column]
		public DateTime? AddedDate { get; set; }

		[NPoco.Column]
		public DateTime? LastUpdate { get; set; }

	}
}
