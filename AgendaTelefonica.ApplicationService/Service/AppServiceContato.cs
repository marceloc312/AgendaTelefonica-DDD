using AgendaTelefonica.ApplicationService.Contracts;
using AgendaTelefonica.Data.Context.Contracts;
using AgendaTelefonica.Domain.Contracts.Service;
using AgendaTelefonica.Domain.Entities;
using AgendaTelefonica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AgendaTelefonica.ApplicationService.Service
{
	public class AppServiceContato : AppService, IAppServiceContato
	{
		readonly IServiceContato _service;
		public AppServiceContato(IServiceContato service, IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_service = service;
		}

		public IEnumerable<Contato> All()
		{
			BeginTransaction();
			var result = _service.All();
			Commit();
			return result;
		}

		public IEnumerable<Contato> Find(Expression<Func<Contato, bool>> predicate)
		{
			BeginTransaction();
			var result = _service.Find(predicate); Commit();
			return result;
		}

		public Contato Get(int id)
		{
			BeginTransaction();
			var result = _service.Get(id); Commit();
			return result;
		}
		public ValidationResult Delete(Contato entity)
		{
			BeginTransaction();
			ValidationResult.Add(_service.Delete(entity));
			if (ValidationResult.IsValid)
				Commit();
			else
				Rollback();
			return ValidationResult;
		}


		public ValidationResult SaveOrUpdate(Contato entity)
		{
			BeginTransaction();
			ValidationResult.Add(_service.SaveOrUpdate(entity));
			if (ValidationResult.IsValid)
				Commit();
			else
				Rollback();

			return ValidationResult;
		}
	}
}
