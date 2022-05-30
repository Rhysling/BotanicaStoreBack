using BotanicaStoreBack.Models.Core;
using BotanicaStoreBack.Repo.Models;
using BotanicaStoreBack.Repo.Repos;
using BotanicaStoreBack.Services.LinqExt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BotanicaStoreBack.Services;

public class PicAudit
{
	private readonly PlantDb db;

	private readonly string picFilePath;
	private readonly string orphanPath;

	public PicAudit(AppSettings aps, PlantDb db)
	{
		this.db = db;

		picFilePath = Directory.GetCurrentDirectory();

		if (aps.IsDev)
		{
			int ix = picFilePath.IndexOf(@"BotanicaStoreBack\BotanicaStoreBack");
			picFilePath = picFilePath.Remove(ix + 35);
			picFilePath = picFilePath.Replace(@"BotanicaStoreBack\BotanicaStoreBack", @"BotanicaStoreFront\public\plantpics");
		}
		else
			picFilePath = Path.Combine(picFilePath, @"wwwroot\plantpics");

		orphanPath = Path.Combine(picFilePath, "orphans");
	}

	public PicAuditResult GetAuditResults()
	{
		return RunAudit();
	}

	public PicAuditResult MoveOrphans()
	{
		var res = RunAudit();

		foreach (string f in res.OrphanPicNames)
		{
			string fn = f + ".jpg";
			File.Move(Path.Combine(picFilePath, fn), Path.Combine(orphanPath, fn), true);
		}

		return RunAudit();
	}

	private PicAuditResult RunAudit()
	{
		var res = new PicAuditResult();
		var plants = db.AllWithPictures();

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
		res.OrphanPicNames = q.Where(a => a.Db is null).Select(a => a.Fs).ToList();
		res.MissingPicNames = q.Where(a => a.Fs is null).Select(a => a.Db).ToList();
		res.PlantIdsMissingPics = res.MissingPicNames.Select(a => Int32.Parse(a[1..5])).Distinct().ToList();
		res.OldOrphanCount = (new DirectoryInfo(orphanPath)).GetFiles().Length;


		//p0022_00_220418-122523.jpg
		//[{"picId":0,"key":"220418-122523","pvt":0},{"picId":1,"key":"220418-122523","pvt":0},{"picId":2,"key":"220418-122523","pvt":0}]

		return res;
	}

}
