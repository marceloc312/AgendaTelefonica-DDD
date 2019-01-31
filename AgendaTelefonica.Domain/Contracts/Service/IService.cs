using AgendaTelefonica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AgendaTelefonica.Domain.Contracts.Service
{
	public interface IService<TEntity>
   where TEntity : class
	{
		TEntity Get(int id);
		IEnumerable<TEntity> All();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
		ValidationResult Add(TEntity entity);
		ValidationResult Update(TEntity entity);
		ValidationResult SaveOrUpdate(TEntity entity);
		ValidationResult Delete(TEntity entity);
	}
}