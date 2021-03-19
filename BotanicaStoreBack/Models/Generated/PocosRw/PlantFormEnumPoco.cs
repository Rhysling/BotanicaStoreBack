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
	[TableName("PlantFormEnum")]
	[PrimaryKey("Id", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class PlantFormEnumPoco : BotanicaStoreBackDB.Record<PlantFormEnumPoco>, Repositories.Core.IKeyed<int>
	{
		[NPoco.Column]
		public int Id { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string Name { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string Description { get; set; }

	}
}
