using System;
using System.Data.SqlClient;
using BotanicaStoreBack.Models.Core;
using Microsoft.Extensions.Options;
using NPoco;

namespace BotanicaStoreBack.Repositories
{
	public abstract class RepositoryBase : IDisposable
	{
		protected NPoco.Database db;
		bool _disposed = false;
		private readonly AppSettings opts;

		public RepositoryBase(IOptions<AppSettings> options)
		{
			opts = options.Value;
			db = new NPoco.Database(opts.BotanicaStoreBack_ConnectionString, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
		}

		public RepositoryBase(AppSettings options)
		{
			opts = options;
			db = new NPoco.Database(opts.BotanicaStoreBack_ConnectionString, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~RepositoryBase()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			if (disposing)
			{
				// free other managed objects that implement, IDisposable only

				if (db != null)
					db.Dispose();
			}

			// Release any unmanaged objects. Set the object references to null
			db = null;

			_disposed = true;
		}
	}
}