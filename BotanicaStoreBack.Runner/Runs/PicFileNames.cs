using System;
using BotanicaStoreBack.Repo.Models;
using NPoco;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BotanicaStoreBack.Runner.Runs;

public static class PicFileNames
{
	public static void ConvertNames()
	{
		// p0818_sm.jpg
		// pnnnn_nn_yymmdd-hhmmss.jpg

		string pathIn = @"D:\yy\tpBotanicaPicsIn\";
		string pathOut = @"D:\yy\tpBotanicaPicsOut\";
		string keyNow = DateTime.Now.ToString("yyMMdd-HHmmss");
		var sb = new StringBuilder();
		sb.AppendLine($"Begin -- Key = {keyNow}");

		JsonConvert.DefaultSettings = () => new JsonSerializerSettings
		{
			Formatting = Formatting.None,
			ContractResolver = new CamelCasePropertyNamesContractResolver()
		};


		using var db = new NPoco.Database("Server=localhost;Database=BotanicaStoreDb;Trusted_Connection=True;", DatabaseType.SqlServer2012, SqlClientFactory.Instance);

		var picList = new List<PlantPicId>();

		// where PlantId in (183, 1255)
		var plants = db.Fetch<Plant>("ORDER BY PlantId");

		//foreach (var plant in plants)
		//{
		//	picList = JsonConvert.DeserializeObject<List<PlantPicId>>(plant.Pics);
		//}
		//picList.Clear();

		foreach (var p in plants)
		{
			if (p.HasSmallPic)
			{
				picList.Add(new PlantPicId { PlantId = p.PlantId, PicId = 0, Key = keyNow });

				string fn = $"p{p.PlantId:0000}_sm.jpg";
				string fnIn = Path.Combine(pathIn, fn);
				if (File.Exists(fnIn))
					File.Copy(fnIn, Path.Combine(pathOut, $"p{p.PlantId:0000}_00_{keyNow}.jpg"));
				else
					sb.AppendLine($"Not found - {fn}");
			}

			if (p.BigPicIds.Length > 0)
			{
				var ids = p.BigPicIds.Split(',');
				picList.AddRange(ids.Select(a => new PlantPicId { PlantId = p.PlantId, PicId = Convert.ToInt32(a), Key = keyNow }));

				foreach (var id in ids)
				{
					string fn = $"p{p.PlantId:0000}_{id.PadLeft(2, '0')}.jpg";
					string fnIn = Path.Combine(pathIn, fn);
					if (File.Exists(fnIn))
						File.Copy(fnIn, Path.Combine(pathOut, $"p{p.PlantId:0000}_{id.PadLeft(2, '0')}_{keyNow}.jpg"));
					else
						sb.AppendLine($"Not found - {fn}");
				}
			}
		}

		// Save PicList to Db

		var plg = picList.GroupBy(a => a.PlantId).ToList();

		foreach (var g in plg)
		{
			var p = plants.Single(a => a.PlantId == g.Key);
			var picJson = JsonConvert.SerializeObject(g.Select(a => new { a.PicId, a.Key, a.Pvt }).ToArray());
			p.Pics = picJson;
			db.Save(p);
			//Console.WriteLine($"PlantId = {g.Key} | {picJson}");
		}


		// Write Log
		File.WriteAllText(Path.Combine(pathOut, "aaLog.txt"), sb.ToString());

	}
}
