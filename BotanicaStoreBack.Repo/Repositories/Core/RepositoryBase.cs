using NPoco;
using System.Data.SqlClient;

namespace BotanicaStoreBack.Repo.Repos
{
	public abstract class RepositoryBase : IDisposable
	{
		protected NPoco.Database db;
		bool _disposed = false;

		public RepositoryBase(string connStr)
		{
			db = new NPoco.Database(connStr, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
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
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
			db = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

			_disposed = true;
		}
	}
}