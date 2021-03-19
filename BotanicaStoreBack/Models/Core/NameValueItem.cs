using System;
using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models.Core
{
	[TypeScriptModel]
	public class NameValueItem
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}
}