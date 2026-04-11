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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		[NPoco.Column]
		[StringLength(50)]
		[Required()]
		public string KeyName { get; set; }

		[NPoco.Column]
		[StringLength(2047)]
		public string KeyValue { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

	}
}
