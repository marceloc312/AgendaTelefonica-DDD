using AgendaTelefonica.ApplicationService.Contracts;
using AgendaTelefonica.ApplicationService.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.InversionOfControl.Modules
{
	public class AppServiceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IAppServiceContato>().To<AppServiceContato>();
			Bind<IAppServiceNotification>().To<AppServiceNotification>();
		}
	}
}
