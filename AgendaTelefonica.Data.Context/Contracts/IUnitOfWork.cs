namespace AgendaTelefonica.Data.Context.Contracts
{
	public interface IUnitOfWork
	{
		void BeginTransaction();
		void SaveChanges();
		void Rollback();
	}
}