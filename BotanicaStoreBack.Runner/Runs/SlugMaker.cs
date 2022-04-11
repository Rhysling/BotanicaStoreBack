using BotanicaStoreBack.Repo.Models;
using NPoco;
using Slugify;
using System;
using System.Data.SqlClient;

namespace BotanicaStoreBack.Runner.Runs
{
	public static class SlugMaker
	{
		public static void Create()
		{
			using var db = new NPoco.Database("Server=localhost;Database=BotanicaStoreDb;Trusted_Connection=True;", DatabaseType.SqlServer2012, SqlClientFactory.Instance);

			var plants = db.Fetch<Plant>(" ");
			var helper = new SlugHelper();

			foreach (var p in plants)
			{
				p.Slug = helper.GenerateSlug($"{p.Genus} {p.Species} {p.PlantId}");
				db.Save(p);
			}

		}
	}
}
