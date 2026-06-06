using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.LinqExt;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using NPoco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BotanicaStoreBack.Runner.Runs;

public static class PicAudit
{
	public static void RunAuditClass()
	{
		var aps = new AppSettings();
		aps.IsProductionString = "false";

		var cs = new ConnStr();
		string dbPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\BotanicaStoreBack\Db\BotanicaDevSqlite.db"));
		cs.Value = $"Data Source={dbPath}";
		var db = new PlantDb(cs);

		var pa = new BotanicaStoreBack.Services.PicAudit(aps, db);
		var res = pa.GetAuditResults();

		var x = res;

	}

	public static void RunAuditHere()
	{
		// Set a path to document.
		var dt = DateTime.Now;
		string docPath = $@"D:\yy\tp7\PicAudit_{dt.ToString("yyMMdd-HHmmss")}.txt";
		string picFilePath = @"D:\UserData\Documents\AppDev\BotanicaStoreFront\public\plantpics";

		//string dir = Directory.GetCurrentDirectory();

		//if (opts.IsDev)
		//	dir = dir.Replace(@"BotanicaStoreBack\BotanicaStoreBack", @"BotanicaStoreFront\public\plantpics");
		//else
		//	dir = Path.Combine(dir, @"wwwroot\plantpics");

		string orphanPath = Path.Combine(picFilePath, "orphans");

		string dbPathH = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\BotanicaStoreBack\Db\BotanicaDevSqlite.db"));
		using var db = new NPoco.Database($"Data Source={dbPathH}", DatabaseType.SQLite, SqliteFactory.Instance);

		var plants = db.Fetch<Plant>("WHERE (length(Pics) > 2) ORDER BY PlantId");

		var dbPicNames = plants.SelectMany(p =>
			JsonConvert.DeserializeObject<List<PlantPicId>>(p.Pics)
			.Select(a => { a.PlantId = p.PlantId; return a; })
			.Select(a => $"p{a.PlantId:D4}_{a.PicId:D2}_{a.Key}")
		).ToList();

		var di = new DirectoryInfo(picFilePath);
		var fsPicNames = di.GetFiles()
			.Where(a => a.Name.StartsWith("p") && a.Extension == ".jpg")
			.Select(a => Path.GetFileNameWithoutExtension(a.FullName))
			.ToList();

		var q = dbPicNames.FullOuterJoin(fsPicNames, a => a, b => b, (a, b, _) => new { Db = a, Fs = b });
		var orphans = q.Where(a => a.Db is null).Select(a => a.Fs).ToList();
		var missing = q.Where(a => a.Fs is null).Select(a => a.Db).ToList();

		// Move Orphans

		foreach (string f in orphans)
		{
			string fn = f + ".jpg";
			File.Move(Path.Combine(picFilePath, fn), Path.Combine(orphanPath, fn), true);
		}


		//p0022_00_220418-122523.jpg
		//[{"picId":0,"key":"220418-122523","pvt":0},{"picId":1,"key":"220418-122523","pvt":0},{"picId":2,"key":"220418-122523","pvt":0}]

		var sb = new StringBuilder();

		sb.AppendLine("ORPHANS");
		sb.AppendLine(String.Join("\r\n", orphans));
		sb.AppendLine();
		sb.AppendLine("MISSING");
		sb.AppendLine(String.Join("\r\n", missing));

		File.WriteAllText(docPath, sb.ToString());

	}

}
