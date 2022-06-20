using BotanicaStoreBack.Repo.Models;
using NPoco;
using Slugify;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BotanicaStoreBack.Runner.Runs
{
	public static class SlugMaker
	{
		public static void Create()
		{
			//using var db = new NPoco.Database("Server=localhost;Database=BotanicaStoreDb;Trusted_Connection=True;", DatabaseType.SqlServer2012, SqlClientFactory.Instance);

			//var plants = db.Fetch<Plant>(" ");
			List<Plant> plants = new List<Plant> {
				new Plant {
					PlantId = 123,
					Genus = "Aarful Genus",
					Species = "The species here"
				},
				new Plant {
					PlantId = 456,
					Genus = "Bing Bong Goo",
					Species = "var. with a dot"
				},
				new Plant {
					PlantId = 789,
					Genus = "Dotty.dot with.. dots...",
					Species = ".dot .."
				},
			};


			var config = new SlugHelperConfiguration();
			config.StringReplacements.Add(".", "");
			var helper = new SlugHelper(config);

			foreach (var p in plants)
			{
				p.Slug = helper.GenerateSlug($"{p.Genus} {p.Species} {p.PlantId}");
				//db.Save(p);
			}

			var x = plants;

		}
	}
}
