using AgendaTelefonica.Domain.Contracts.Specification;
using System;

namespace AgendaTelefonica.Domain.Entities.Specifications.EmailSpecs
{
	public	class EmailEnderecoDeveSerPreenchidoSpec : ISpecification<ContatoEmail>
	{
		public bool IsSatisfiedBy(ContatoEmail entity)
		{
			return !String.IsNullOrEmpty(entity.Endereco) && !String.IsNullOrWhiteSpace(entity.Endereco);
		}
	}
}
