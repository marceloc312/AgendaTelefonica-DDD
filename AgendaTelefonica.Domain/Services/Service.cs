using AgendaTelefonica.Domain.Contracts.Repository;
using AgendaTelefonica.Domain.Contracts.Service;
using AgendaTelefonica.Domain.Contracts.Validation;
using AgendaTelefonica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AgendaTelefonica.Domain.Services
{
	public class Service<TEntity> : IService<TEntity>
		where TEntity : class
	{
		#region Constructor

		private readonly IRepository<TEntity> _repository;
		readonly ValidationResult _validationResult;

		public Service(IRepository<TEntity> repository)
		{
			_repository = repository;
			_validationResult = new ValidationResult();
		}

		#endregion

		#region Properties
		protected IRepository<TEntity> Repository { get { return _repository; } }
		protected ValidationResult ValidationResult { get { return _validationResult; } }

		#endregion

		#region Read Methods

		public virtual TEntity Get(int id)
		{
			return _repository.Get(id);
		}

		public virtual IEnumerable<TEntity> All()
		{
			return _repository.All();
		}

		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _repository.Find(predicate);
		}

		#endregion

		#region CRUD Methods

		public virtual ValidationResult Add(TEntity entity)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;

			var selfValidationEntity = entity as ISelfValidation;
			if (selfValidationEntity != null && !selfValidationEntity.IsValid())
				return selfValidationEntity.ValidationResult;


			_repository.Add(entity);
			return _validationResult;
		}

		public virtual ValidationResult Update(TEntity entity)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;

			var selfValidationEntity = entity as ISelfValidation;
			if (selfValidationEntity != null && !selfValidationEntity.IsValid())
				return selfValidationEntity.ValidationResult;

			_repository.Update(entity);
			return _validationResult;
		}

		public virtual ValidationResult Delete(TEntity entity)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;

			_repository.Delete(entity);
			return _validationResult;
		}

		public ValidationResult SaveOrUpdate(TEntity entity)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;

			var selfValidationEntity = entity as ISelfValidation;
			if (selfValidationEntity != null && !selfValidationEntity.IsValid())
				return selfValidationEntity.ValidationResult;

			_repository.SaveOrUpdate(entity);
			return _validationResult;
		}

		#endregion
	}
}
