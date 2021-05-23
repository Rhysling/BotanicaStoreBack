using BotanicaStoreBack.Services.FiltersAttributes;

namespace BotanicaStoreBack.Models.Core
{
	[TypeScriptModel]
	public class UserClient
	{
		public int UserId { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
		public string Token { get; set; }
		public bool IsAdmin { get; set; }
		public double TaxRate { get; set; }
	}
}
