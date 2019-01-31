using AgendaTelefonica.Data.Context.Contracts;
using AgendaTelefonica.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Data.Repository.Common
{
	public class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable
		where TEntity : class
	{

		public RepositoryBase(IDbContext dbContext)
		{
			Context = dbContext;
		}

		public IDbContext Context { get; }

		public void Add(TEntity entity)
		{
			Context.Session.Save(entity);
		}

		public void SaveOrUpdate(TEntity entity)
		{
			Context.Session.SaveOrUpdate(entity);
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			var query = Context.Session.Query<TEntity>().Where(predicate);
			return query.ToList();
		}

		public TEntity Get(int id)
		{
			return Context.Session.Get<TEntity>(id);
		}


		public void Update(TEntity entity)
		{
			Context.Session.Update(entity);
		}

		public IEnumerable<TEntity> All()
		{
			var query = Context.Session.Query<TEntity>();
			return query.ToList();
		}

		public void Delete(TEntity entity)
		{
			Context.Session.Delete(entity);
		}

		#region Dispose

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing) return;

			if (Context == null) return;
			Context.Dispose();
		}


		#endregion
	}
}
