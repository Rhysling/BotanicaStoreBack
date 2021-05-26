using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;
using System.Linq;

namespace BotanicaStoreBack.Repos
{
	public class WishListDb : RepositoryBase
	{
		public WishListDb(IOptions<AppSettings> options)
			: base(options)
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

		public bool MarkListEmailed(int userId)
		{
			string sql = $"UPDATE WishLists SET EmailedDate = '{DateTime.Now:s}' WHERE (UserId = {userId}) AND (EmailedDate IS NULL) AND (IsClosed = 0)";
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

