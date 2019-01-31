using AgendaTelefonica.Data.Context;
using AgendaTelefonica.Data.Context.Contracts;
using AgendaTelefonica.Data.Repository.Repository;
using AgendaTelefonica.Domain.Contracts.Repository;
using Ninject.Modules;

namespace AgendaTelefonica.InversionOfControl.Modules
{
	public class RepostoryModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IRepositoryContato>().To<RepositoryContato>().InSingletonScope();
			Bind<IDbContext>().To<AgendaContext>().InSingletonScope();
			Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
		}
	}
}
