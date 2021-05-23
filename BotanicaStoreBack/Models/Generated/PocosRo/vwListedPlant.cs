using System;
using NPoco;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models
{
	[TypeScriptModel]
	[TableName("vwListedPlants")]
	[ExplicitColumns]
	public partial class vwListedPlant : BotanicaStoreBackDB.Record<vwListedPlant>
	{
		[NPoco.Column] 
		public int PlantId { get; set; }

		[NPoco.Column] 
		public string Genus { get; set; }

		[NPoco.Column] 
		public string Species { get; set; }

		[NPoco.Column] 
		public string Common { get; set; }

		[NPoco.Column] 
		public string Description { get; set; }

		[NPoco.Column] 
		public string PlantSize { get; set; }

		[NPoco.Column] 
		public string PlantType { get; set; }

		[NPoco.Column] 
		public string PlantZone { get; set; }

		[NPoco.Column]
		public bool IsNwNative { get; set; }

		[NPoco.Column] 
		public bool HasSmallPic { get; set; }

		[NPoco.Column] 
		public string BigPicIds { get; set; }

		[NPoco.Column]
		public bool IsFeatured { get; set; }

		[NPoco.Column]
		public string Availability { get; set; }
	}
}
