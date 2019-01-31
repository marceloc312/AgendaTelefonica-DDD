using AgendaTelefonica.Domain.Contracts.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Domain.Entities.Specifications.ContatoSpecs
{
public	class ContatoTelefoneDeveSerInformadoSpec : ISpecification<Contato>
	{
		public bool IsSatisfiedBy(Contato entity)
		{
			return entity.Telefone.Any();
		}
	}
}
