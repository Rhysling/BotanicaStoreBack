namespace BotanicaStoreBack.Repo.Models
{
	[TypeScriptModel]
	public class PlantPicId
	{
		public int PlantId { get; set; }
		public int PicId { get; set; }
		public string Key { get; set; } = "";
		public int Pvt { get; set; }
	}
}
