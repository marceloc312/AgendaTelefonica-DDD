using AgendaTelefonica.ApplicationService.Contracts.Common;
using AgendaTelefonica.Data.Context.Contracts;
using AgendaTelefonica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.ApplicationService.Service
{
	public class AppService : ITransactionAppService
	{

		readonly IUnitOfWork _uow;

		public AppService(IUnitOfWork unitOfWork)
		{
			_uow = unitOfWork;
			ValidationResult = new ValidationResult();
		}

		protected ValidationResult ValidationResult { get; private set; }

		public virtual void BeginTransaction()
		{
			_uow.BeginTransaction();
		}

		public virtual void Rollback()
		{
			_uow.Rollback();
		}
		public virtual void Commit()
		{
			_uow.SaveChanges();
		}
	}
}
