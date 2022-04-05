using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("tpPlantPricesOld")]
	[PrimaryKey("PlantId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class tpPlantPricesOld : BotanicaStoreBackDB.Record<tpPlantPricesOld>
	{
		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string Offered { get; set; }

	}
}
