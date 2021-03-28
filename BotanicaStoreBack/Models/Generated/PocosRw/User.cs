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
	[TableName("Users")]
	[PrimaryKey("UserId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class User : BotanicaStoreBackDB.Record<User>
	{
		[NPoco.Column]
		public int UserId { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string Email { get; set; }

		[NPoco.Column]
		[StringLength(100)]
		public string FullName { get; set; }

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
