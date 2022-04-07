using BotanicaStoreBack.ColorCards;
using BotanicaStoreBack.Repo.Models;
using NPoco;
using System;
using System.Data.SqlClient;

namespace BotanicaStoreBack.Runner.Runs;

public static class ColorCardMaker
{
	public static void Create()
	{
		// Set a path to document.
		var dt = DateTime.Now;
		string docPath = $@"D:\yy\tp7\ColorCards_{dt.ToString("yyMMdd-HHmmss")}.docx";

		using var db = new NPoco.Database("Server=localhost;Database=BotanicaStoreDb;Trusted_Connection=True;", DatabaseType.SqlServer2012, SqlClientFactory.Instance);

		var plants = db.Fetch<Plant>("WHERE Flag = '5' ORDER BY Genus, Species");

		var docBuilder = new DocBuilder(plants);
		var bytes = docBuilder.Create();

		System.IO.File.WriteAllBytes(docPath, bytes);

		// Open the result for demonstration purposes.
		System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(docPath) { UseShellExecute = true });
	}
}
