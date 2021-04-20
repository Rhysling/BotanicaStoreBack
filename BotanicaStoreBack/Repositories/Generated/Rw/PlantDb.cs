using System;
using System.Collections.Generic;
using System.Linq;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using Microsoft.Extensions.Options;

namespace BotanicaStoreBack.Repos
{
	public class PlantDb : RepositoryBase, IPlantDb
	{
		public PlantDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public Plant FindBy(int id)
		{
			return db.SingleOrDefaultById<Plant>(id);
		}

		public List<Plant> All()
		{
			return db.Fetch<Plant>("ORDER BY Genus, Species");
		}

		public string GetNextBigPicId(int PlantId)
		{
			string sql = "SELECT BigPicIds FROM Plants WHERE (PlantId = @0)";
			string ids = db.Fetch<string>(sql, PlantId).FirstOrDefault();

			if (ids is null || ids == "")
				return "1";

			return (ids.Split(',').Select(a => Int32.Parse(a)).Max() + 1).ToString();
		}


		public int Save(Plant plant)
		{
			plant.LastUpdate = DateTime.Now;

			db.Save<Plant>(plant);
			return plant.PlantId;
		}

		// *** Updates **
		public void SetFeatured(PlantToggle pt)
		{
			string sql = "UPDATE Plants SET IsFeatured = 0";
			db.Execute(sql);
			sql = $"UPDATE Plants SET IsFeatured = {(pt.Val ? "1" : "0")} WHERE PlantId = {pt.PlantId}";
			db.Execute(sql);
		}

		public void SetListed(PlantToggle pt)
		{
			string sql = $"UPDATE Plants SET IsListed = {(pt.Val ? "1" : "0")} WHERE PlantId = {pt.PlantId}";
			db.Execute(sql);
		}

		public void UpdatePictures(PlantPicId ppid)
		{
			string sql;

			if (ppid.PicId == "sm")
			{
				sql = $"UPDATE Plants SET HasSmallPic = 1 WHERE PlantId = {ppid.PlantId}";
				db.Execute(sql);
				return;
			}

			sql = "SELECT BigPicIds FROM Plants WHERE (PlantId = @0)";
			string ids = db.Fetch<string>(sql, ppid.PlantId).FirstOrDefault();

			if (String.IsNullOrWhiteSpace(ids))
				ids = ppid.PicId;
			else
				ids += "," + ppid.PicId;

			sql = $"UPDATE Plants SET BigPicIds = '{ids}' WHERE PlantId = {ppid.PlantId}";
			db.Execute(sql);
		}

		public void DeletePictures(PlantPicId ppid)
		{
			string sql;

			if (ppid.PicId == "sm")
			{
				sql = $"UPDATE Plants SET HasSmallPic = 0 WHERE PlantId = {ppid.PlantId}";
				db.Execute(sql);
				return;
			}

			sql = "SELECT BigPicIds FROM Plants WHERE (PlantId = @0)";
			string ids = db.Fetch<string>(sql, ppid.PlantId).FirstOrDefault() ?? "";

			ids = String.Join(',', ids.Split(',').Where(a => a != ppid.PicId));

			sql = $"UPDATE Plants SET BigPicIds = '{ids}' WHERE PlantId = {ppid.PlantId}";
			db.Execute(sql);
		}


		public bool Save(IEnumerable<Plant> items)
		{
			foreach (Plant item in items)
			{
				db.Save<Plant>(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			db.Delete<Plant>(id);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Plant>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Plant>(id);
			return true;
		}


	}
}	

