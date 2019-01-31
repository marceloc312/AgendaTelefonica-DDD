using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.ApplicationService.Contracts
{
	public interface IAppServiceNotification
	{
		int Notify(string message);
	}
}
