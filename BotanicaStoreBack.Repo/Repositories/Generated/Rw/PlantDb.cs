using BotanicaStoreBack.Repo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BotanicaStoreBack.Repo.Repos
{
	public class PlantDb : RepositoryBase
	{
		public PlantDb(ConnStr connStr)
			: base(connStr.Value)
		{
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				Formatting = Formatting.None,
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}

		public List<Plant> All()
		{
			return db.Fetch<Plant>("WHERE (IsDeleted = 0) ORDER BY Genus, Species");
		}

		public List<Plant> ByFlag(string flag)
		{
			return db.Fetch<Plant>("WHERE (Flag = @0) ORDER BY Genus, Species", flag);
		}

		public List<Plant> ByIds(IEnumerable<int> ids)
		{
			return db.Fetch<Plant>($"WHERE (PlantId IN ({String.Join(',',ids)})) ORDER BY Genus, Species");
		}

		public List<Plant> AllWithPictures()
		{
			return db.Fetch<Plant>("WHERE (len(Pics) > 2) ORDER BY Genus, Species");
		}


		public int GetNextBigPicId(int PlantId)
		{
			string sql = "SELECT Pics FROM Plants WHERE (PlantId = @0)";
			string? ids = db.Fetch<string>(sql, PlantId).FirstOrDefault();

			if (String.IsNullOrWhiteSpace(ids))
				return 1;

			var pics = JsonConvert.DeserializeObject<List<PlantPicId>>(ids);

			if (pics is null || pics.Count == 0)
				return 1;

			return pics.Select(a => a.PicId).Max() + 1;
		}


		public Plant Save(Plant plant)
		{
			plant.Flag = String.IsNullOrWhiteSpace(plant.Flag) ? null : plant.Flag.Trim();
			plant.LastUpdate = DateTime.UtcNow;

			db.Save(plant);
			return plant;
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
			List<PlantPicId> ppidList;
			string sql;

			sql = "SELECT Pics FROM Plants WHERE (PlantId = @0)";
			string? json = db.Fetch<string>(sql, ppid.PlantId).FirstOrDefault();

			if (String.IsNullOrWhiteSpace(json))
				ppidList = new();
			else
				ppidList = JsonConvert.DeserializeObject<List<PlantPicId>>(json) ?? new();

			var ppidListNew = ppidList.Where(a => a.PicId != ppid.PicId).ToList();
			ppidListNew.Add(ppid);
			var ppidListOut = ppidListNew.Select(a => new { a.PicId, a.Key, a.Pvt }).OrderBy(a => a.PicId).ToList();

			string nw = DateTime.UtcNow.ToString("s");
			sql = $"UPDATE Plants SET Pics = '{JsonConvert.SerializeObject(ppidListOut)}', LastUpdate='{nw}' WHERE PlantId = {ppid.PlantId}";
			db.Execute(sql);


		}

		public void DeletePictures(PlantPicId ppid)
		{
			List<PlantPicId> ppidList;
			string sql;

			sql = "SELECT Pics FROM Plants WHERE (PlantId = @0)";
			string? json = db.Fetch<string>(sql, ppid.PlantId).FirstOrDefault();

			if (String.IsNullOrWhiteSpace(json))
				ppidList = new();
			else
				ppidList = JsonConvert.DeserializeObject<List<PlantPicId>>(json) ?? new();

			var ppidListNew = ppidList.Where(a => a.PicId != ppid.PicId).ToList();
			var ppidListOut = ppidListNew.Select(a => new { a.PicId, a.Key, a.Pvt }).OrderBy(a => a.PicId).ToList();

			string nw = DateTime.UtcNow.ToString("s");
			sql = $"UPDATE Plants SET Pics = '{JsonConvert.SerializeObject(ppidListOut)}', LastUpdate='{nw}' WHERE PlantId = {ppid.PlantId}";
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
				db.Save(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			string nw = DateTime.UtcNow.ToString("s");
			string sql = $"UPDATE Plants SET IsListed = 0, IsFeatured = 0, LastUpdate='{nw}', Flag = null, IsDeleted = 1 WHERE PlantId = {id}";
			db.Execute(sql);
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

