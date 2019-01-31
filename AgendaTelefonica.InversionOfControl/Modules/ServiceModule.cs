using AgendaTelefonica.Domain.Contracts.Service;
using AgendaTelefonica.Domain.Services;
using Ninject.Modules;

namespace AgendaTelefonica.InversionOfControl.Modules
{
	public class ServiceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IServiceContato>().To<ServiceContato>();
		}
	}
}
