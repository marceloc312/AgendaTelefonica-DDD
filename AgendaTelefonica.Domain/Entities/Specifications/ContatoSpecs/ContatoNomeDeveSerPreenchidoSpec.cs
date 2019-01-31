using AgendaTelefonica.Domain.Contracts.Specification;
using System;

namespace AgendaTelefonica.Domain.Entities.Specifications.ContatoSpecs
{
	public class ContatoNomeDeveSerPreenchidoSpec : ISpecification<Contato>
	{
		public bool IsSatisfiedBy(Contato entity)
		{
			return !string.IsNullOrEmpty(entity.Nome) && !String.IsNullOrWhiteSpace(entity.Nome);
		}
	}
}
