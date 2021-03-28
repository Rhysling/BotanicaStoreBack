using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TableName("vwPlantsTp")]
	[ExplicitColumns]
	public partial class vwPlantsTp : BotanicaStoreBackDB.Record<vwPlantsTp>
	{
		[NPoco.Column] 
		public int PlantId { get; set; }

		[NPoco.Column] 
		public string Genus { get; set; }

		[NPoco.Column] 
		public string Species { get; set; }

	}
}
