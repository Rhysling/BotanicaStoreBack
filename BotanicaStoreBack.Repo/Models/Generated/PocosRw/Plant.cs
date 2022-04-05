using NPoco;
using System.ComponentModel.DataAnnotations;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("Plants")]
	[PrimaryKey("PlantId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class Plant : BotanicaStoreBackDB.Record<Plant>
	{
		[NPoco.Column]
		public int PlantId { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string Genus { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string Species { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string Family { get; set; }

		[NPoco.Column]
		[StringLength(1023)]
		public string Description { get; set; }

		[NPoco.Column]
		[StringLength(1023)]
		public string WebDescription { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string PlantSize { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string PlantType { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string PlantZone { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string PictureLocation { get; set; }

		[NPoco.Column]
		public bool IsNwNative { get; set; }

		[NPoco.Column]
		public bool HasSmallPic { get; set; }

		[NPoco.Column]
		[StringLength(50)]
		public string BigPicIds { get; set; }

		[NPoco.Column]
		public bool IsListed { get; set; }

		[NPoco.Column]
		public bool IsFeatured { get; set; }

		[NPoco.Column]
		public DateTime LastUpdate { get; set; }

		[NPoco.Column]
		[StringLength(2)]
		public string Flag { get; set; }

		// Computed Columns

		public string LastUpdateFormatted => LastUpdate.CompareTo(DateTime.Now.AddYears(-20)) < 0 ? "None" : LastUpdate.ToString("M/d/yy-h:mmtt");

	}
}
