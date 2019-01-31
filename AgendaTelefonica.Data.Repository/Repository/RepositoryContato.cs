using AgendaTelefonica.Data.Context.Contracts;
using AgendaTelefonica.Data.Repository.Common;
using AgendaTelefonica.Domain.Contracts.Repository;
using AgendaTelefonica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Data.Repository.Repository
{
	public class RepositoryContato : RepositoryBase<Contato>, IRepositoryContato
	{
		public RepositoryContato(IDbContext dbContext) : base(dbContext)
		{
		}

	}
}