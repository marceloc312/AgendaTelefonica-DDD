using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.ApplicationService.Contracts.Common
{
	public interface ITransactionAppService
	{
		void BeginTransaction();
		void Commit();
		void Rollback();
	}
}
