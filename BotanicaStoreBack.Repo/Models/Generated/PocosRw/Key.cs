using NPoco;
using System.ComponentModel.DataAnnotations;

namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	[TableName("Keys")]
	[PrimaryKey("KeyName", AutoIncrement = false)]
	[ExplicitColumns]
	public partial class Key : BotanicaStoreBackDB.Record<Key>
	{
		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string KeyName { get; set; }

		[NPoco.Column]
		[StringLength(2047)]
		public string KeyValue { get; set; }

	}
}
