namespace BotanicaStoreBack.Repo.Models
{
	public class ConnStr
	{
		private static string val;

		public string Value {
			get {
				return val;
			}
			set {
				val = value;
			}
		}

		public static ConnStr Current => new ConnStr { Value = val };
	}
}
