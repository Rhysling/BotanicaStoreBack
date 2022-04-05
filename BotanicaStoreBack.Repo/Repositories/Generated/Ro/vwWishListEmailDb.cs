using BotanicaStoreBack.Repo.Models;

namespace BotanicaStoreBack.Repo.Repos
{
	public class vwWishListEmailDb : RepositoryBase
	{
		public vwWishListEmailDb(ConnStr connStr)
			: base(connStr.Value)
		{
			//no op.
		}

		public vwWishListEmail GetByWlId(int wlId)
		{
			var wl = db.FirstOrDefault<vwWishListEmail>("WHERE (WlId = @0)", wlId);
			wl.Items = db.Fetch<vwWishListEmailItem>("WHERE (WlId = @0)", wlId);
			return wl;
		}

		public vwWishListEmail GetByUserId(int userId)
		{
			var wl = db.FirstOrDefault<vwWishListEmail>("WHERE (UserId = @0) AND (EmailedDate IS null) AND (IsClosed = 0)", userId);

			if (wl is not null)
				wl.Items = db.Fetch<vwWishListEmailItem>("WHERE (WlId = @0)", wl.WlId);

			return wl;
		}


	}
}	
