using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class WishListDb : RepositoryBase
	{
		public WishListDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		// *** vwWishListFlat ***
		public List<vwWishListFlat> GetListForUser(int userId)
		{
			string sql = $"WHERE (UserId = {userId}) AND (EmailedDate IS NULL) AND (IsClosed = 0) ORDER BY PlantName, SortOrder";
			return db.Fetch<vwWishListFlat>(sql);
		}

		public List<vwWishListFlat> GetListById(int wlId)
		{
			string sql = $"WHERE (WlId = {wlId}) ORDER BY PlantName, SortOrder";
			return db.Fetch<vwWishListFlat>(sql);
		}


		// *** WishList ***

		public WishList GetOrCreateCurrent(int userId)
		{
			string sql = $"WHERE (UserId = {userId}) AND (EmailedDate IS NULL) AND (IsClosed = 0)";

			var wls = db.Fetch<WishList>(sql);
			if (wls.Any())
				return wls[0];

			var nw = DateTime.Now;
			WishList wl = new WishList {
				UserId = userId,
				CreatedDate = nw,
				LastUpdateDate = nw
			};

			db.Save(wl);
			return wl;
		}

		public bool MarkListEmailed(int wlId)
		{
			string sql = $"UPDATE WishLists SET EmailedDate = '{DateTime.Now:s}' WHERE (WlId = {wlId})";
			db.Execute(sql);
			return true;
		}

		public bool UpdateClosed(int wlId, bool isClosed)
		{
			int val = isClosed ? 1 : 0;
			string sql = $"UPDATE WishLists SET IsClosed = {val} WHERE (WlId = {wlId})";
			db.Execute(sql);
			return true;
		}


		// *** WishListItem ***

		public bool AddUpdateItem(WishListItem item)
		{
			string sql;

			if (item.Qty < 1)
			{
				sql = $"DELETE FROM WishListItems WHERE (WlId = {item.WlId}) AND (PlantId = {item.PlantId}) AND (PotSizeId = {item.PotSizeId})";
				db.Execute(sql);
			}
			else
			{
				db.Save(item);
			}

			sql = $"UPDATE WishLists SET LastUpdateDate = '{DateTime.Now:s}' WHERE (WlId = {item.WlId})";
			db.Execute(sql);

			return true;
		}


	}
}

