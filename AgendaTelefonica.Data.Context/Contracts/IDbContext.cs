using NHibernate;

namespace AgendaTelefonica.Data.Context.Contracts
{
	public interface IDbContext
	{
		ISession Session { get; }
		void BeginTransaction();
		void Rollback();
		void SaveChanges();
		void Dispose();
	}
}
