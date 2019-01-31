using AgendaTelefonica.ApplicationService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.ApplicationService.Service
{
	public class AppServiceNotification : IAppServiceNotification
	{
		public int Notify(string message)
		{

			//Aqui implementa aqlguma lógica para notificar ao suporte ou registrar algum log
			return 0;
		}
	}
}
