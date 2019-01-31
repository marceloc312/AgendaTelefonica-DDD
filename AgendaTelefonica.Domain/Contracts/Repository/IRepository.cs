﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Domain.Contracts.Repository
{
	public interface IRepository<TEntity>
		 where TEntity : class
	{
		void Add(TEntity entity);
		void Update(TEntity entity);
		void SaveOrUpdate(TEntity entity);
		void Delete(TEntity entity);
		TEntity Get(int id);
		IEnumerable<TEntity> All();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);		
	}
}