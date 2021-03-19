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
	[TableName("PlantView")]
	[ExplicitColumns]
	public partial class PlantView : BotanicaStoreBackDB.Record<PlantView>
	{
		[NPoco.Column] 
		public string Genus { get; set; }

		[NPoco.Column] 
		public string Species { get; set; }

		[NPoco.Column] 
		public string Common { get; set; }

	}
}
