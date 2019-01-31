using AgendaTelefonica.Data.Context.Contracts;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Data.Context
{
	public class AgendaContext : IDbContext
	{
		private const string CurrentSessionKey = "nhibernate.current_session";
		private readonly ISessionFactory _sessionFactory;
		private ITransaction _transaction;
		private ISession _session;
		public AgendaContext()
		{
			_sessionFactory = FluentConfigure();
			CreateCurrentSession();
		}

		public ISession Session => _session;
		void CreateCurrentSession()
		{
			_session = _sessionFactory.OpenSession();
		}
		 void CloseSession()
		{
			_sessionFactory.Close();
		}
		 void CloseSessionFactory()
		{
			if (_sessionFactory != null)
			{
				_sessionFactory.Close();
			}
		}

		public ISessionFactory FluentConfigure()
		{
			return Fluently.Configure()
				//which database
				.Database(
					MsSqlConfiguration.MsSql2012
						.ConnectionString(
							cs => cs.FromConnectionStringWithKey
								  ("DBConnection")) //connection string from app.config
													//.ShowSql()
						)
				//2nd level cache
				.Cache(
					c => c.UseQueryCache()
						.UseSecondLevelCache()
						.ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
				//find/set the mappings
				//.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMapping>())
				.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
				.BuildSessionFactory();
		}

		public void SaveChanges()
		{
			if (_transaction == null)
				return;

			_transaction.Commit();
			_transaction.Dispose();
			_transaction = null;
		}

		public void Rollback()
		{
			if (_transaction == null)
				return;

			_transaction.Rollback();
			_transaction.Dispose();
			_transaction = null;
		}

		public void Dispose()
		{
			_session.Close();
			_session?.Dispose();
		}

		public void BeginTransaction()
		{
			_transaction =_session .BeginTransaction();
		}
	}
}
