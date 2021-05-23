using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BotanicaStoreBack.Models;
using BotanicaStoreBack.Models.Core;

namespace BotanicaStoreBack.Repos
{
	public class WishListDb : RepositoryBase
	{
		public WishListDb(IOptions<AppSettings> options)
			: base(options)
		{
			//no op.
		}

		public List<vwWishListFlat> GetListForUser(int userId)
		{
			string sql = $"WHERE (UserId = {userId}) AND (EmailedDate IS NULL) AND (IsClosed = 0) ORDER BY PlantName, Price";
			return db.Fetch<vwWishListFlat>(sql);
		}

		public int AddUpdateItem(WishListItem item, int userId)
		{
			if (item.WlId < 1)
			{
				string sql = $@"
SELECT max(WlId)
WHERE (UserId = {userId}) AND (EmailedDate IS NULL) AND (IsClosed = 0)";

				item.WlId = db.ExecuteScalar<int?>(sql) ?? 0;

				if (item.WlId < 1)
				{
					DateTime dt = DateTime.Now;
					var wl = new WishList
					{
						UserId = userId,
						CreatedDate = dt,
						LastUpdateDate = dt,
						EmailedDate = null,
						IsClosed = false
					};

					db.Insert(wl);
					item.WlId = wl.WlId;
				}
			}

			db.Save(item);

			return 0;
		}

		public bool MarkListEmailed(int userId)
		{
			string sql = $"UPDATE WishLists SET EmailedDate = '{DateTime.Now:s}' WHERE (UserId = {userId}) AND (EmailedDate IS NULL) AND (IsClosed = 0)";
			db.Execute(sql);
			return true;
		}

	}
}

