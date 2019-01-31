using AgendaTelefonica.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.ApplicationService.Contracts.Common
{
public	interface IAppService<TEntity>
	{
		ValidationResult SaveOrUpdate(TEntity entity);
		ValidationResult Delete(TEntity entity);
		TEntity Get(int id);
		IEnumerable<TEntity> All();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
	}
}
