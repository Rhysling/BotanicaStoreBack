using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class PlantDb : RepositoryBase
	{
		public PlantDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public Plant FindBy(int id)
		{
			return db.SingleOrDefaultById<Plant>(id);
		}

		public List<Plant> All()
		{
			return db.Fetch<Plant>(" ");
		}

		public List<Plant> ByFlag(string flag)
		{
			return db.Fetch<Plant>("WHERE (Flag = @0) ORDER BY Genus, Species", flag);
		}

		public string GetNextBigPicId(int PlantId)
		{
			string sql = "SELECT BigPicIds FROM Plants WHERE (PlantId = @0)";
			string? ids = db.Fetch<string>(sql, PlantId).FirstOrDefault();

			if (String.IsNullOrWhiteSpace(ids))
				return "1";

			return (ids.Split(',').Select(a => Int32.Parse(a)).Max() + 1).ToString();
		}


		public int Save(Plant plant)
		{
			plant.Flag = String.IsNullOrWhiteSpace(plant.Flag) ? null : plant.Flag.Trim();
			plant.LastUpdate = DateTime.Now;

			db.Save(plant);
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
			string? ids = db.Fetch<string>(sql, ppid.PlantId).FirstOrDefault();

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


		public List<vwFlagSummary> FlagSummaries()
		{
			return db.Fetch<vwFlagSummary>("ORDER BY LastUpdate DESC");
		}

		public void RemoveFlag(string flag)
		{
			string sql = $"UPDATE Plants SET Flag = null WHERE (Flag = @0)";
			db.Execute(sql, flag);
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

