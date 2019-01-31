using AgendaTelefonica.Domain.Contracts.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Domain.Entities.Specifications.TelefoneSpecs
{
public	class TelefoneNumeroDeveSerPreenchidoSpec : ISpecification<ContatoTelefone>
	{
		public bool IsSatisfiedBy(ContatoTelefone entity)
		{
			return !string.IsNullOrEmpty(entity.DDD) && !String.IsNullOrWhiteSpace(entity.DDD);
		}
	}
}
