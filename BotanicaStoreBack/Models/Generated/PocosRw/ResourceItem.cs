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
	[TableName("ResourceItems")]
	[PrimaryKey("ItemId", AutoIncrement = true)]
	[ExplicitColumns]
	public partial class ResourceItem : BotanicaStoreBackDB.Record<ResourceItem>
	{
		[NPoco.Column]
		public int ItemId { get; set; }

		[NPoco.Column]
		[StringLength(8)]
		public string KeyString { get; set; }

		[NPoco.Column]
		[StringLength(1023)]
		public string Description { get; set; }

		[NPoco.Column]
		[StringLength(100)]
		public string FileName { get; set; }

		[NPoco.Column]
		[StringLength(20)]
		public string FileType { get; set; }

		[NPoco.Column]
		public byte[] FileData { get; set; }

		[NPoco.Column]
		public int? FileDataByteLength { get; set; }

		[NPoco.Column]
		[StringLength(20)]
		public string FileSize { get; set; }

		[NPoco.Column]
		public int? IconGroup { get; set; }

		[NPoco.Column]
		public DateTime? LastUpdate { get; set; }

		[NPoco.Column]
		public int? UpdatedBy { get; set; }

		[NPoco.Column]
		public bool? IsDeleted { get; set; }

	}
}
