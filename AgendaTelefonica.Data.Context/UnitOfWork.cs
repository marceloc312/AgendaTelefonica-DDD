using AgendaTelefonica.Data.Context.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Data.Context
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		//private readonly ContextManager<TContext> _contextManager =ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;

		private readonly IDbContext _dbContext;
		private bool _disposed;

		public UnitOfWork(IDbContext dbContext)
		{
			_dbContext = dbContext;

		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void BeginTransaction()
		{
			_dbContext.BeginTransaction();
			_disposed = false;
		}

		public void Rollback()
		{
			_dbContext.Rollback();
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
			}
			_disposed = true;
		}
	}
}